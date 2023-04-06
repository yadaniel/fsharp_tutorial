open System
open System.IO
open type System.IO.File
open type System.IO.Directory
// open System.Data
// open System.Windows
// open System.Windows.Forms

// fsharpc main.fs
// mono ./main.exe

module Tools =
    type A = A0 | A1 | A2 | A3
    type B = B0 of int | B1 of int*int | B2 of int*int*int

open Tools  // use A, B
// open type Tools.A    // use Tools.A
// open type Tools.B    // use Tools.B

let f0 unit : Tools.A = A0
let f1 unit : Tools.B = B0 1
let f2 unit : B = B0 1

let readlines (fname:string) : string array option =
    if File.Exists(fname) then
        let lines = File.ReadAllText(fname).Split("\n")
        Some lines
        // Some [|""|]
    else 
        None

let usage (err:int) : int =
    Console.WriteLine("usage: readlines <fname>")
    err

[<EntryPoint>]
let main_real (argv: string[]) : int =
    let n = argv.Length
    let err = 
        if n = 1  then
            match readlines argv.[0] with
                | None -> 1
                | Some lines -> 
                    let mutable cnt = 0
                    for line in lines do
                        Console.WriteLine($"{cnt}: {line}")
                        cnt <- cnt + 1
                    0
        else if n = 0 then
            Console.WriteLine("no file given")
            usage (1)
        else
            usage (2)
    let msg = "info"
    //
    Console.WriteLine($"length = {argv.Length}, msg = {msg}, err={err}")
    // System.Environment.Exit(err)
    err


