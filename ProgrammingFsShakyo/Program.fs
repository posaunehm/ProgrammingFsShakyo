open System

//メイン関数
[<EntryPoint>]
let main(args : string[]) = 
    //引数が2つでなければ
    if args.Length <> 2 then
        //例外を吐いて落ちる
        failwith "Error: Expected arguments <greeting> and <thing>"
    
    let greeting, thing = args.[0], args.[1]
    let timeOfDay = DateTime.Now.ToString("hh:mm tt")
    
    printfn "%s, %s at %s" greeting thing timeOfDay
    
    0 
