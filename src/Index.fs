module Index

open Fable.Core.JsInterop
open Elmish
open Elmish.React

open App

importSideEffects "./tailwind.css"
importSideEffects "./style.css"

Program.mkProgram State.init State.update View.root
|> Program.withReactBatched "app"
|> Program.run
