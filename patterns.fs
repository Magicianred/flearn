module patterns

let input = [ (1., 2., 0.); (2., 1., 1.); (3., 0., 1.) ]
let rec search lst = 
    match lst with
    | (1., _, z) :: tail ->
        printfn "found x=1. and z=%f" z; search tail
    | (2., _, _) :: tail ->
        printfn "found x=2."; search tail
    | _ :: tail -> search tail
    | [] -> printfn "done";

let (|Norm|) (a:float, b:float, c:float) = 
    sqrt(a*a + b*b + c*c)
    
let v = (1., 1., 0.)
match v with
| Norm(1.) -> printfn "versor"
| Norm(n) -> printfn "vector"

let (|Vector|Versor|) (a:float, b:float, c:float) = 
    if sqrt(a*a + b*b + c*c) = 1. then Versor
    else Vector
    
match v with
| Versor -> printfn "versor1"
| Vector -> printfn "vector1"


let rec isPalindrome (s:string) (fromIdx:int) (toIdx:int) = 
    if s = null then false
    elif toIdx - fromIdx < 2 then true
    elif s.[fromIdx] = s.[(toIdx - 1)] then
        isPalindrome s (fromIdx + 1) (toIdx - 1)
    else false
 
let (|PALINDROME|_|) (s:string) = 
    if isPalindrome s 0 s.Length then Some s
    else None

let sayPalindrome s = 
    match s with
    | PALINDROME(v) -> printfn "%s palidrome" v
    | _ -> printfn "No pal"

sayPalindrome "aba"  