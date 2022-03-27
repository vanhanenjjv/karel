module App

module Types =
    type Model =
        { Editor: Editor.Types.Model }

    type Message =
        | EditorMessage of Editor.Types.Message

module State =
    open Elmish

    open Types

    let init () =
        let (editor, editorCmd) = Editor.State.init()
        let (model, cmd) = { Editor = editor }, Cmd.none
        model, Cmd.batch [ cmd
                           Cmd.map EditorMessage editorCmd ]
                    
    let update (message: Message) (model: Model) =
        match message with
        | EditorMessage message -> 
            let (editor, editorCmd) = Editor.State.update message model.Editor
            { model with Editor = editor }, Cmd.map EditorMessage editorCmd

module View =
    open Fable.React.Standard
    open Fable.React.Helpers
    open Fable.React.Props

    open Types

    let root (model: Model) (dispatch: Message -> unit) =
        let editor = Editor.View.root model.Editor (EditorMessage >> dispatch)

        div [ Style [ Height "100%" ] ] 
            [ str model.Editor.Value
              editor ]
