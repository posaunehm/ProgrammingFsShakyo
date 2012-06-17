module ProgrammingFsShakyo.Chapter3

open System
open System.IO
open System.Text.RegularExpressions

[<Literal>]
let Bill = "Bill Gates"

let ExecuteChapter3 = 

    let square x = x * x

    //宣言的な加算の書き方
    let imperaticeSum numbers = 
        //ミュータブル宣言。こういう書き方もあるのね。
        let mutable total = 0
        for i in numbers do
            let x = square i
            //代入はこう書くのか・・・
            total <- total + x
        total

    let ans = imperaticeSum [1 .. 10]

    //関数型な加算の書き方
    let functionalSum numbers = 
        numbers
        //パイプ演算だ！これは関数型プログラミングの範疇で書かれるのね。
        |> Seq.map square
        |> Seq.sum

    let ans = functionalSum [1 .. 100]

    //匿名関数
    let ret = (fun x -> x + 3) 5
    let ret = List.map (fun i -> i * i ) [1 .. 10]

    //部分関数適用
    //2つのstirngを引数に持つ関数
    let appendFile filename (text : string) = 
        use file = new StreamWriter(filename, true)
        file.WriteLine(text)
        file.Close()
    appendFile @"Log.txt" "Processing Event X..."

    //カリー化を行う。第一引数にのみ引数を割り当て
    let appendLogFile = appendFile @"Log.txt"
    appendLogFile "Processing Evenct Y..."

    //ラムダ式を使う
    List.iter (fun i -> printfn "%d" i) [1 .. 10]
    //部分関数適用で新たな式を作る
    List.iter (printfn "%d") [1 .. 10]

    //再帰関数
    //キーワードはrec。recキーワードにより関数定義が終わるまでにその関数を呼ぶことが許可される
    let rec factorial x = 
        if x <= 1 then 1
        else
            x * factorial (x - 1)

    let ans = factorial 5

    //再帰によるforループ
    let rec forLoop body times = 
        if times <= 0 then ()
        else
            body()
            forLoop body (times - 1)
    //再帰によるwhileループ
    let rec whileLoop predicate body = 
        if predicate() then
            body()
            whileLoop predicate body
        else
            ()
    forLoop (fun () -> printfn "Looping...") 3

    //相互再帰
    //andでつなぐことで、そちらで定義される関数も呼び出すことができる。
    //recの有効範囲を拡張しているようなイメージ
    let rec isOdd x = 
        if x = 0 then false
        elif x = 1 then true
        else isEven(x - 1)
    and isEven x = 
        if x = 0 then true
        elif x = 1 then false
        else isOdd(x - 1)

    let ans = isOdd 9
    let ans = isEven 100
        
    //演算子の定義
    //会場の演算子を定義する
    let (!) = factorial
    let ans = !5

    //正規表現の一致を定義する
    let (===) str (regex : string) = 
        Regex.Match(str, regex).Success

    let ans =  "The quick brown fox" === "The (.*) fox"

    //逆に定義済み演算子を関数として用いることも可能
    let ans = List.fold (+) 0 [1 .. 10]
    let ans = List.fold (*) 1 [1 .. 5]
    let minus = (-)

    let ans = minus 5 3

    //関数の組立（Function Composition）
    //フォルダのファイルサイズを取得
    //こう書くとほとんど型推論が働かず、冗長
    let sizeOfFolder folder =
        //フォルダ直下にある全てのファイルを取得 
        let filesInFolder : string [] = 
            Directory.GetFiles(
                folder, "*.*",
                SearchOption.AllDirectories)
        //直下にある全てのファイルからFileInfoクラスを作成
        let fileInfos : FileInfo[] = 
            Array.map
                (fun (file : string) -> new FileInfo(file))
                filesInFolder
        //直下にあるファイルの大きさを取得
        let fileSizes : Int64 [] = 
            Array.map
                (fun (info :  FileInfo) -> info.Length)
                fileInfos
        //全てのファイルサイズを合計する
        Array.sum fileSizes

    //とりあえず冗長なので、引数をインライン化
    //第二引数へは関数をひたすらネストさせていく
    //意味的には下から上へ登っていくのでわかりづらい！！
    let uglySizeOfFolder folder = 
        Array.sum
            (Array.map
                (fun (info : FileInfo) -> info.Length)
                (Array.map
                    (fun file -> new FileInfo(file))
                    (Directory.GetFiles(
                        folder, "*.*",
                        SearchOption.AllDirectories))))

    //そこでPipe-forward演算子を用いる
    //let (|>) x f = f x
    [1..3] |> List.iter (printfn "%d")
    //List.iter (printfn "%d" [1..3]と同値

    //Pipe-Forward演算子によって型推論が働くようになる
    //単に第二引数を先に評価するようにするから？
    let sizeOfFolderPiped folder = 
        Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)
            |> Array.map (fun file -> new FileInfo(file))
            |> Array.map (fun info -> info.Length)
            |> Array.sum
    
    //Forward Composition演算子
    //前方合成演算子        
    //let (>>) f g x = g (f x)
    //部分関数適用を逆転するイメージ？
    let sizeOfFolderComposed = 
        let getFiles folder = 
            Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)

        getFiles
        >> Array.map (fun file -> new FileInfo(file))
        >> Array.map (fun info -> info.Length)
        >> Array.sum
    //適用結果：val sizeOfFolderComposed : (string -> int64)
    //関数が戻り値となっている

    //もう一例
    let square x = x * x
    let toString (x:int) = x.ToString()
    let strlen (x:string) = x.Length;
    let lenOfSquare = square >> toString >> strlen

    let ans = lenOfSquare 128

    //こう書くと自明の型推論が！
    //ただラムダ式書きまくりなので割と微妙
    let lenOfSquare =
        fun x -> x * x
        >> fun x -> x.ToString()
        >> fun x -> x.Length

    let ans = lenOfSquare 128

    //Pipe-Backward演算子
    //後方パイプ演算子
    //普通の関数適用順序で適用するだけ、、、
    List.iter (printfn "%d") [1 .. 3]
    List.iter (printfn "%d") <| [1 .. 3]
    
    //だが演算順序が微妙に変わる
    printfn "sprintf適用の結果は%sです" (sprintf "(%d,%d)" 1 3)
    printfn "sprintf適用の結果は%sです" <| sprintf "(%d,%d)" 1 3
    //↑括弧が消えてる！

    //Backward compososition parameter
    //後方合成演算子
    let square x = x * x
    let negate x = -x
    
    //前方合成すると
    let ans = (square >> negate) -10
    //10^2 * -1 = -100
    
    //明示的に逆順適用
    let ans = (square << negate) -10
    //(-1 * 10)^2 = 100
    //実はこれだよね
    let ans = square (negate -10)

    //空リストのフィルタリングにも使う
    let ans = [[1];[];[4;5;6;];[3;4;];[];[];[];[9]] |> List.filter (not << List.isEmpty)
    //こうすれば同じ順番でかけるけど、だいぶ冗長
    let ans = [[1];[];[4;5;6;];[3;4;];[];[];[];[9]] |> List.filter (fun x -> not (List.isEmpty x))

    //パターンマッチ
    let isOdd x = (x % 2 = 1)
    //単純なパターンマッチ
    let descriveNumber x = 
        match isOdd x with
        | true -> printfn "x is odd"
        | false -> printfn "x is Even"

    [1 .. 10]
    |> List.iter descriveNumber
    //and演算子
    let testAnd x y = 
        match x,y with
        |true, true -> true
    //  |true,false -> false
        |false,true -> false
        |false,false -> false
    //ワイルドカード"_"を使うとこんな感じに省略できる
    let testAnd x y = 
        match x, y with
        | true,true -> true
        | _, _      -> false

    //型マッチがうまくいかない場合、まず警告が発生
    let testAnd x y = 
        match x,y with
        |true, true -> true
    //  |true,false -> false
        |false,true -> false
        |false,false -> false
    //マッチするパターンがないと、例外発生
    //testAnd true,false

    //名前付きパターンマッチ
    let greet name = 
        match name with
        | "Robert" -> printfn "Hello, Bob"
        | "William" -> printfn "Hello, Bill"
        //変数として受け取ることができる！
        | x -> printfn "Hello, %s" x
    greet "Robert"
    greet "Hiroshi"

    //リテラル値のパターンマッチ
    let bill = "Bill Gates"
    let greet name = 
        match name with
        | bill -> "Hello Bill"
        | x    -> sprintf "Hello, %s" x
        //↑この規則には一致しない（変数billは新しいリテラルとして認識される)

    let ans = greet "Hiroshi"
    //Hello Bill
    
//    ↓なぜかLiteral属性が効かない・・・
//    Literal属性をつけるとOK
    let greet name = 
        match name with
        | Bill -> "Hello Bill"
        | x    -> sprintf "Hello, %s" x

    //whenガード節
    let highLowGame () =
        let rng = new Random()
        let secretNumber = rng.Next() % 100

        let rec highLowGameStep () =

            printfn "秘密の数字を考えてください:"
            let guessStr = Console.ReadLine()
            let guess = Int32.Parse(guessStr)

            match guess with
            | input when input > secretNumber
                -> printfn "秘密の数字はより小さいです"
                   highLowGameStep()
            | input when input = secretNumber
                -> printfn "正解！！"
                   ()
            //ワイルドカードも使える！
            | _
                -> printfn "秘密の数字はより大きいです"
                   highLowGameStep()

        highLowGameStep()

    //パターンマッチのグルーピング
    let vowelTest c = 
        match c with
        | 'a' | 'b' | 'i' | 'o' | 'u'
            -> true
        | _ -> false
    //他の記法。
    let describeNumbers x y = 
        match x, y with
        | 1, _
        | _, 1
            -> "数字のどちらかは1ですよ"
        //論理演算子が使える？
        | (2,_) & (_,2)
            -> "数字は両方とも2ですよ"
        | _ -> "それ以外ですね"
        
    //構造化データのパターンマッチ
    let testXor x y = 
       match x, y with
       //1変数で受け取るとtupleとして取れる
       | tpl when fst tpl <> snd tpl
           -> true
       | true, true -> false
       | false, false -> false
    //リスト型を受け取る例
    let rec listLength l = 
        match l with
        | []    -> 0
        | hd :: tail -> 1 + listLength tail


    ()