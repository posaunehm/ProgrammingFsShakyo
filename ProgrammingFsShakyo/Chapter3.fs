module ProgrammingFsShakyo.Chapter3

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

    ()