module ProgrammingFsShakyo.Chapter2

 

let numericDefn =
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
    

    0