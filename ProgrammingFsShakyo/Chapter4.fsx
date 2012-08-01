//第4章：宣言的プログラミング
module Chapter4

//default値取得
let defaultArray = Unchecked.defaultof<System.Array>
//typeof
let typeOfInt = typeof<int>
//sizeof
let sizeOfInt = sizeof<int>

//nullの使用
let isNull = function null -> true | _ -> false
isNull "文字列"
isNull (null : string)

