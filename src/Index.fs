
module Index

open Fable.Core.JsInterop
open Elmish
open Elmish.React

open App

importSideEffects "./style.css"

Program.mkProgram State.init State.update View.root
|> Program.withReactBatched "app"
|> Program.run
