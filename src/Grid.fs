module Grid

open Fable.React
open Fable.React.Helpers
open Fable.React.Props
open Zanaptak.TypedCssClasses

type tw = CssClasses<"https://unpkg.com/tailwindcss@^1.0/dist/tailwind.min.css", Naming.Verbatim>

type Props =
    { Columns: int
      Rows: int }

let private cell (position : int * int) =
    let className = System.String.Join(" ", [
        tw.``bg-blue-400``
        tw.``font-bold``
    ])

    div [ClassName className] [str "asd"]

let view (props : Props) =
    let cells = seq {
         for y in 1..props.Rows do
            for x in 1..props.Columns do
                yield div [ClassName "grid-row"] [cell (x, y)]
    }    

    div [] cells

        
