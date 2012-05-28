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


    ()