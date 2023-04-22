// #r "FParsec.dll"

// fsharpi
// #load "main.fs";;

module M

open System
open type System.Console
let version : string = "V0.1"

// f0 :: int -> int -> int
let f0 x y = x + y
// f1 :: int*int -> int
let f1 (x,y) = x + y

module Enumerate =

    let enumerate1 (xs: 'a array) = 
        let mutable idx : int = 0
        [| for x in xs -> {|index = idx; value = x|} |]

    let enumerate2 (xs: 'a array) : {|index:int; value:'a|} array =
        let mutable idx : int = 0
        [| for x in xs -> {|index = idx; value = x|} |]

    // let inc (x: int) : int =
    //     x <- x + 1

    let enumerate (xs: 'a array) : {|index:int; value:'a|} array =
        let mutable idx : int = 0
        [| for x in xs -> {|index = (idx <- idx + 1; idx); value = x|} |]

    let test () =
        printfn "%A\n" (enumerate1 [|1;2;3;4;5|])
        printfn "%A\n" (enumerate2 [|1;2;3;4;5|])
        let xs = [|1;2;3;4;5|] in (printfn "length = %A\n" xs.Length)
        printfn "%A\n" (enumerate [|10;20;30;40;50|])

module Main =

    // fsharpi cannot read module with =
    let v : string = "V0.1"

    open Enumerate
    let enumerate = Enumerate.enumerate

    // let findall (xs: 'a array, x: 'a) : ('a option) array =
    //     [| for x' in (enumerate xs) -> if x = x'.value then Some x'.index else None |]

    // let findall (xs: 'a array, x: 'a) : 'a array =
    //     Array.filter (fun o -> if o = None then false else true)  
    //         [| for x' in (enumerate xs) -> if x = x'.value then Some x'.index else None |]

    // let findall (xs: 'a array, x: 'a) : int array =
    //     [| for x' in (enumerate xs) -> if x = x'.value then x'.index else -1 |]

    let findall (xs: 'a array, x: 'a) : int array =
        [| for x' in (enumerate xs) do if x = x'.value then yield x'.index |]

    let findall' xs x : int array =
        [| for x' in (enumerate xs) -> if x = x'.value then x'.index else -1 |]


    [<EntryPoint>]
    let main (args:string[]) : int =
        let xs = [|0; 1; 2; 3; 4; 5; 1; 2; 3; 4; 5; 6; 7; 1|]
        let ys = findall (xs, 1) in
        let ys' = findall' xs 1 in
        printfn "xs = %A\n" xs
        printfn "ys = %A\n" ys
        printfn "ys' = %A\n" ys'
        0


