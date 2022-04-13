module Karel

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop

module Types =
    type Direction =
        | Left
        | Right

    type Karel =
        { turn: Direction -> unit
          move: unit -> unit
          pickup: unit -> unit
          drop: unit -> unit }

    type WorkerMessage =
        | Move
        | Turn of Direction
        | Pickup
        | Drop
        | Start
        | End

    type Window =
        inherit Browser.Types.Window
        abstract Karel: Karel with get, set

    type Model =
        { Worker: Browser.Types.Worker option
          Position: int32 * int32 }

    type Message =
        | Execute of string

let turn (direction: Types.Direction) =
    ()

let move () =

    ()

let pickup () =
    ()

let drop () =
    ()


[<Emit("Worker")>]
let workerConstructor: string -> Browser.Types.Worker = jsNative

let Worker x = 
    let y = createNew workerConstructor x 
    y :?> Browser.Types.Worker

let (|Move|Drop|Turn|Start|End|) (arr: obj array) =
    let t = arr.[0] |> string
    match t with
    | "MOVE" -> Move
    | "DROP" -> Drop
    | "TURN" -> Turn arr.[1]
    
    |
    if value = "hehe" then Test value
    else Meme value

module State =
    open Elmish
    open Types

    [<Global>]
    let private window: Window = jsNative

    let init () =
        let worker = Worker("/worker.js")

        worker.onmessage <- fun event ->
            let message = event.data :?> WorkerMessage
            match message with
            | Turn direction -> console.log("ayy", direction)
            | s -> console.log(s)

        { Position = 0, 0
          Worker = Some worker }, Cmd.none

    let update (message: Message) (model: Model) =
        match message with
        | Execute code -> 
            if model.Worker.IsSome then
                model.Worker.Value.postMessage(code)
            model, Cmd.none

