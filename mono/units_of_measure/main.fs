open System
open type System.Console
open type System.Math
open System.Linq

// nan
// infinity
// -infinity

module Units =
    [<Measure>] type kg
    [<Measure>] type m
    [<Measure>] type s
    [<Measure>] type J = kg*m^2/s^2


module Shapes =
    open Units
    [<RequireQualifiedAccess>]
    type Shape = 
        | Circle of radius:float<m>
        | Square of size:float<m>
        | Rectangle of width:float<m> * height:float<m>
        | Other of area:float<m^2>
        | Undefined

module Main =
    open Units
    open Shapes

    let cubic (x:float<m>) : float<m*m*m> = 
        x*x*x

    let cube (x:float<m>) : float<m^3> = 
        x*x*x

    let w_kinetic (m:float<kg>, v:float<m/s>) : float<J> = 
        0.5*m*v*v

    let w_potential (m:float<kg>, g:float<m/s^2>, h:float<m>) : float<J> = 
        m*g*h

    let area (shape:Shape) : float<m^2> =
        match shape with
            | Shape.Circle r -> 2.0*PI*r*r
            | Shape.Square size -> size*size
            | Shape.Rectangle (width, height) -> width*height
            | Shape.Other area -> area
            | Shape.Undefined -> nan*1.0<m^2>

    let ask_circle () : Shape =
        match Double.TryParse(ReadLine()) with
            | true, n -> Shape.Circle (n*1.0<m>)
            | _ -> Shape.Undefined

    let ask_square () : Shape =
        match Double.TryParse(ReadLine()) with
            | true, n -> Shape.Square (n*1.0<m>)
            | _ -> Shape.Undefined

    let ask_rectangle () : Shape =
        match Double.TryParse(ReadLine()) with
            | true, w -> match Double.TryParse(ReadLine()) with
                            | true, h -> Shape.Rectangle (w*1.0<m>, h*1.0<m>)
                            | _ -> Shape.Undefined
            | _ -> Shape.Undefined

    let ask_user () : Shape =
        let mutable stopped = false
        let mutable shape = Shape.Undefined
        while not stopped do
            Write("input: [c=circle, s=square, r=rectangle]: ")
            stopped <- true
            shape <- match ReadLine() with
                        | "c" -> ask_circle ()
                        | "s" -> ask_square ()
                        | "r" -> ask_rectangle ()
                        | _ ->   stopped <- false
                                 Shape.Undefined
        shape
    
    [<EntryPoint>]
    let main args = 

        let f1: float = 1.0
        let f2: float<m> = 1.0<m>
        let f1_attached: float<m> = f1*1.0<m>
        let f2_stripped = float f2

        // ask_user () |> ignore

        printf "area = %A" (area (ask_user ()))

        // match ReadLine() with
        //     | "a" -> printf "A"
        //     | "b" -> printf "B"
        //     | "c" -> printf "C"
        //     | "d" -> printf "D"
        //     | _ -> printf "else"

        0


