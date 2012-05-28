module ProgrammingFsShakyo.Chapter3

open System.IO

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
        



    ()