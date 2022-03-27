module Monaco

open Fable.Core.JS
open Fable.Core.JsInterop
open Fetch

type EditorOptions =
    { language: string 
      value: string }

type IModelContentChange =
    abstract text: string

type IModelContentChangedEvent =
    abstract changes: IModelContentChange list

type IStandaloneCodeEditor = 
    abstract onDidChangeModelContent: (IModelContentChangedEvent -> unit) -> unit
    abstract getValue: unit -> string

type IEditor =
    abstract create: Browser.Types.Element -> EditorOptions -> IStandaloneCodeEditor

type IMonaco =
    abstract editor: IEditor

let monaco: IMonaco = importAll "monaco-editor"

monaco?languages?typescript?javascriptDefaults?setCompilerOptions({| noLib = true; allowNonTsExtensions = true |})

promise {
    let! response = fetch "/karel.d.ts" []
    let! karel = response.text()
    monaco?languages?typescript?javascriptDefaults?addExtraLib(karel, "ts:karel.d.ts")
} |> ignore
