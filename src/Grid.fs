module Grid

open Fable.React
open Fable.React.Helpers
open Fable.React.Props

type Props =
    { Columns: int
      Rows: int }

let private cell (position : int * int) =
    div [ClassName "grid-cell"] [str "asd"]

let view (props : Props) =
    div [] (seq {
        for y in 1..props.Rows do
            yield div [ClassName "grid-row"] (seq {
                for x in 1..props.Columns do
                    yield cell (x, y)
                })
    })

        
