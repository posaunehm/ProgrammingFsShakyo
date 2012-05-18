module ProgrammingFsShakyo.Chapter2

open System.Numerics

let writeln (s : string) = System.Console.WriteLine s

let ExecuteChapter2 =
    let answerToEverything = 42UL
    let pi = 3.1415926M
    let avogadro = 6.022e23

    let hex = 0xFCAF
    let oct = 0o7771L
    let bin = 0b00101010y

    let overflow = 32767s + 1s
    let underflow = -32768s - 1s
    //キツい型チェックはC#っぽい。以下はコンパイルエラー
    //let underflow = -32768 - 1s

    //Big Integer
    let megabyte = 1024I * 1024I
    let gigabyte = megabyte * 1024I
    let terabyte = gigabyte * 1024I
    let petabyte = terabyte * 1024I
    let exabyte = petabyte * 1024I
    let zettabyte = exabyte * 1024I

    //型変換
    let CasInt = int 'C'
    let CasByte = 'C'B

    //文字列型
    let password = "abracadabra"
    let multiline = "この文字列は
    改行
    されています"
    let first = multiline.[0]
    let second = multiline.[1]
    //バイト配列への変換
    let hello = "Hello"B

    //ブール型
    //各ブール演算子の真偽表を出力する
    let printTruthTable f = 
        printfn "     |true   | false |"
        printfn "     +-------+-------+"
        printfn "true + %5b | %5b |" (f true true) (f true false)
        printfn "false+ %5b | %5b |" (f false true) (f false false)
        printfn "     +-------+-------+"
        printfn ""
        ()
    
    printTruthTable (&&)
    printTruthTable (||)
    
    //関数定義
    let square x =  x * x
    let ans = square 4

    let addOne x = x + 1
    let ans = addOne 10

    let add x y = x + y
    let ans = add 3 7

    //こうすると・・・？
    let addOneFloat x = x + 1.0
    let ans = addOneFloat 5.2   //floatのみ今度は受け付ける

    //明示的に型を指定もできる
    let addFloat (x : float) y = x + y
    let ans = addFloat 4.0 5.0

    //ジェネリック
    let ident x = x
    let ans = ident 5
    let ans = ident 10.0
    let ans = ident 50L
    //明示的に書く
    let ident (x : 'a) = x
    let ans = ident 5
    let ans = ident 10.0
    let ans = ident 50L
    //算術演算でも書いてみる
    let addGeneric (x : 'a) y = x + y
    let ans = addGeneric 5 5 //制約された！？
    //let ans addgeneric 5.0 5.0
    // ↑コンパイルエラー

    //スコープ
    let moduleValue = 1
    let f = 
        let functionValue = "hoge"
        0
    //let y = functionValue
    //↑functionValueはスコープ外のためコンパイルエラー

    //スコープ（関数スコープ）
    let f fParam = 
        let g gParam = fParam + gParam + moduleValue

        let a = g 1
        let b = g 2
        a + b

    let ans = f 3

    //制御文
    let printGreeting shouldGreet greeting = 
        if shouldGreet then
            printfn "%s" greeting

    printGreeting false "Hello"
    printGreeting true "World"

    //３項演算子みたいな制御文
    let isEven x = 
        if x % 2  = 0 then 
            "はい、偶数です"
        else
            "いえ、奇数です"
    
    writeln (isEven 3)
    writeln (isEven 8)

    //else系の制御文確認
    let isWeekday day = 
        if day = System.DayOfWeek.Monday then true
        elif day = System.DayOfWeek.Tuesday then true
        elif day = System.DayOfWeek.Wednesday then true
        elif day = System.DayOfWeek.Thursday then true
        elif day = System.DayOfWeek.Friday then true
        else false

    printfn "%b" (isWeekday System.DateTime.Now.DayOfWeek)

    //コアタイプ：Unit
    let x = ()
    //関数の戻り値を無視する （= Unit型だと思う）
    ignore (square 11)

    //こんな感じのをいっぱい書けばいい？まとめて書く方法がある？
    let ignoreClone (arg : 'a) = ()
    ignoreClone (square 11)
    //ignoreClone (3.5 + 4.2)
    //↑コンパイルエラー

    //Tuple
    let dinner = ("鯖の干物", "餃子")
    //タイプは自由
    let zeros = (0,0L,0.0f,0I)
    //ネストも可能
    let nested = (1,(2.0,3M),(4L,'5',"6"))
    //一つはTupleではない（当たり前か。。。）
    let single = (3)

    //fstとsndによるアクセス（二要素のみ）
    let first = fst dinner
    let seconf = snd dinner
    //let firstZero = fst zeros
    //↑コンパイルエラー

    //letバインディングによる割り当て
    let zero1,zero2,zero3,zero4 = zeros
    //当然数が足りないと怒られる
    //let zero1, zero2 = zeros

    //こんなこともできた！ネストもそのまま書ける
    let fitst, (second1,second2), third = nested

    //List
    let vowels = ['a';'e';'i';'o';'u';]
    let emptyList = [];

    //こう書くと一要素のリストにタプルが入る残念な感じに
    let vowels_2 = ['a','e','i','o','u']

    //Listも当然イミュータブルなので追加とか削除はできない。
    //リストを結合させるつける@演算子か先頭ににつけるconsか
    let odds = [1;3;5;7;9;]
    let evens = [2;4;6;8;10;]
    //結合
    let connected = odds @ evens
    //先頭に要素付加
    let connected = 0 :: odds
    //色々くっつけるのもOK
    let connceted = -6 :: -4 ::  -2 :: 0 :: evens
    
    //Range記法
    //開始値 → インクリメント値 → 終了値
    let tens = [0 .. 10 .. 50]
    //一致しなくてもOK
    let twelves = [0 .. 20 .. 50]
    //デクリメントもできる
    let countDown = [5L .. -1L .. 0L]

    //List Comprehension記法
    let numberNear x = 
        [
            yield x - 1
            yield x
            yield x + 1
        ]

    let numberNear3 =  numberNear 3


    0