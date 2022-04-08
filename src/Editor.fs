module Editor

type Language =
    | JavaScript
    | TypeScript

module Types =
    type Model =
        { Editor: Monaco.IStandaloneCodeEditor option
          Language: Language
          Value: string }
    
    type Message =
        | SetEditor of Monaco.IStandaloneCodeEditor option
        | SetValue of string
        | SetLanguage of Language

module State =
    open Elmish
    open Types

    let init () =
        { Editor = None; Language = JavaScript; Value = "console.log('Hello, world!')" }, Cmd.none

    let update (message: Message) (model: Model) =
        match message with
        | SetEditor editor -> { model with Editor = editor }, Cmd.none
        | SetValue value -> { model with Value = value }, Cmd.none  
        | SetLanguage language -> { model with Language = language }, Cmd.none

let private lowercase (str: string) = str.ToLower()

module View =
    open Fable.React.Standard
    open Fable.React.Props

    open Monaco
    open Types

    let private mount (model: Model) (dispatch: Message -> unit) (element: Browser.Types.Element) =
        if model.Editor.IsSome then ()
        elif element = null then ()
        else
            let editor = { language = model.Language |> string |> lowercase
                           value = model.Value }
                           |> monaco.editor.create element

            editor.onDidChangeModelContent(fun _ -> editor.getValue() |> SetValue |> dispatch)

            editor |> Some |> SetEditor |> dispatch        

    let root (model: Model) (dispatch: Message -> unit) =
        div [ Ref (mount model dispatch)
              Style [ Height "100%"
                      Width "100%" ] ] 
            []
