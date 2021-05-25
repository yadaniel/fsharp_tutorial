(* example showing winforms usage *) 

open System
open System.Windows
open System.Windows.Forms

[<EntryPoint; STAThread>]
let main(args: string array) : int =
    let f = new Form()
    let b = new Button(Text = "Exit", Location = new Drawing.Point(10,25))
    b.Click.AddHandler(fun _ _ -> Application.Exit())
    f.Controls.Add(b)
    f.Controls.Add(new Label(Text="Hello world!"))
    f.Controls.Add(new Label(Text="..."))
    Application.Run(f)
    0

