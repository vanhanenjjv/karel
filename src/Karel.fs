module Karel

open Fable.Core
open Fable.Core.JS

module Types =
    type Direction =
        | Left
        | Right

    type Karel =
        { turn: Direction -> unit
          move: unit -> unit
          pickup: unit -> unit
          drop: unit -> unit }

    type Window =
        inherit Browser.Types.Window
        abstract Karel: Karel with get, set

    type Model =
        { Position: int32 * int32 }

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

module State =
    open Types

    [<Global>]
    let private window: Window = jsNative

    let init () =
        window.Karel <- { turn = turn
                          move = move
                          pickup = pickup
                          drop = drop }

    let update (message: Message) (model: Model) =
        match message with
        | Execute code -> 


