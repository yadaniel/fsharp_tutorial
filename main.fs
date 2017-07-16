(* example showing array usage *) 

open System

module A =
    () 

module B =
    (* arrays are zero indexed, fixed length collection of mutable data *)
    let arr0 = Array.init 10 (fun x -> 0)
    let arr1 = Array.create 10 -1
    let arrx : int[] = Array.zeroCreate 10  // type must be given in the variable declaration
    let arr2 = [| for i in 0..10 -> i |]
    let arr3 = [| for i in [0..10] -> i |]
    let arr4 = [| for i in 0..10 do yield i |]
    let arr5 = [| for i in [0..10] do yield i |]
    //let arr6 = [| for i = 0 to 10 -> i |]             // why is this case not allowed?
    let arr7 = [| for i = 0 to 10 do yield i |]
    let arr8 = [| 0;1;2;3;4;5;6;7;8;9;10 |]

module C =
    let arr : int[] = [|1;2;3|]
    let zerofirst () =
        arr.[0] <- 0        // function has access to arr defined in the outer scope

let incr (v : int byref) = 
    v <- v + 1

let incr' (v : int ref) =
    //v.Value <- v.Value + 1
    v := v.Value + 1

// mutable variables are on stack
let mutable x : int = 1
x <- x + 1
printfn "x = %A" x
incr &x     // taking address of mutable variable
printfn "x = %A" x


// ref creates a cell on heap and wraps the value of expression
let y : int ref = ref 1
y := 2                  // changing the value inside the cell
printfn "y = %A" !y     // accessing the value inside the cell (bang operator)
y.Value <- 3            // mutable variable is wrapped inside the cell
printfn "y = %A" !y
incr' y
printfn "y = %A" !y
incr &y.contents
//incr &y.Value     // why does Value not work?
printfn "y = %A" !y

// alternative syntax for ref
let y1 : Ref<int> = ref 10
let y2 : int ref = ref 10

// sum type (enumeration)
type S1 = A | B | C
type S2 = A | B | C | D

// product type tuple
type P = int*int*int

// product type record syntax
type PR = {x1 : int; x2 : int; x3 : int} 

type Q2 = {q1 : int; q2 : int; q3 : int}
type Q3 = {q1 : int; q2 : int; q3 : int}

// discriminated union
type DU =
    | A
    | B of int
    //| C of {q1 : int; q2 : int} // unnamed record construct is depricated
    | C1 of Q1                      // chain with and (required when types are referencing each other)
    | C2 of Q2                      // OR reference the explicit record defined previously
    | D of int*int*int
    | E of int array
    | F of int option
    | G of float option
and Q1 = {q1 : int; q2 : int; q3 : int}

type Q4 = {q1 : int; q2 : int; q3 : int}
    
let s1 = S1.A
let s2 = S2.A
let s3 = DU.A
let p1 = 1,1,1
let p2 = {x1 = 1; x2 = 1; x3 = 1}
let p3 = {p2 with x2 = 2; x3 = 3}
let d1 = DU.F None
let d2 = DU.F (Some 1)
let d3 = DU.G None
let d4 = DU.G (Some 1.0)

let qa1 = {q1 = 1; q2 = 2; q3 = 3}    // of which type Q2,Q3,Q1? => Q4 see below (seems that the last type declaration wins)
let qa2 = {q1 = 1; q2 = 2; q3 = 3}    // of which type Q2,Q3,Q1? => Q4 see below
let qb : Q2 = {q1 = 3; q2 = 2; q3 = 1}
let qc : Q3 = {q1 = 3; q2 = 2; q3 = 1}

let f a b =
    a + b 

[<EntryPoint>]
let main(args: string array) : int =    // option 1
//let main(args: string[]) : int =      // option 2
    printfn "%A" "test"
    C.arr |> printfn "%A"
    C.zerofirst()
    C.arr |> printfn "%A"
    printfn "%A" (if qa1 = qa2 then "ja" else "nein")
    //printfn "%A" (if qb = qc then "ja" else "nein")   // expressions of types Q2 and Q3 can not be compared
    printfn "%A" (1u.GetType())
    printfn "%A" (qa1.GetType())
    printfn "%A" (qa2.GetType())
    printfn "%A" (qb.GetType())
    printfn "%A" (qc.GetType())
    printfn "%A" B.arr0
    printfn "%A" B.arr1
    0

