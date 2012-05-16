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

    0