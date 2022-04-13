module App

module Types =
    type Model =
        { Editor: Editor.Types.Model
          Karel: Karel.Types.Model }

    type Message =
        | EditorMessage of Editor.Types.Message
        | KarelMessage of Karel.Types.Message

module State =
    open Elmish

    open Types

    let init () =
        let (editor, editorCmd) = Editor.State.init()
        let (karel, karelCmd) = Karel.State.init()
        let (model, cmd) = { Editor = editor; Karel = karel }, Cmd.none
        model, Cmd.batch [ cmd
                           Cmd.map EditorMessage editorCmd
                           Cmd.map KarelMessage karelCmd ]
                    
    let update (message: Message) (model: Model) =
        match message with
        | EditorMessage message -> 
            let (editor, editorCmd) = Editor.State.update message model.Editor
            { model with Editor = editor }, Cmd.map EditorMessage editorCmd
        | KarelMessage message ->
            let (karel, karelCmd) = Karel.State.update message model.Karel
            { model with Karel = karel }, Cmd.map KarelMessage karelCmd

module View =
    open Fable.Core.JS
    open Fable.Core.JsInterop
    open Fable.React.Standard
    open Fable.React.Helpers
    open Fable.React.Props

    open Types

    let run: string -> unit = importMember "./runner.js"

    let root (model: Model) (dispatch: Message -> unit) =
        let editor = Editor.View.root model.Editor (EditorMessage >> dispatch)

        let run _ = model.Editor.Value |> Karel.Types.Execute |> (KarelMessage >> dispatch)

        div 
            [ Style [ Height "100%" ] ] 
            [ button 
                  [ OnClick run ]
                  [ str "Run" ]
              Grid.view { Columns = 4; Rows = 2 }
              editor ]
