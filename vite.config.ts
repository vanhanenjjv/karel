import { defineConfig } from 'vite'

import monacoEditorPlugin from 'vite-plugin-monaco-editor'

export default defineConfig({
  publicDir: 'static',
  plugins: [monacoEditorPlugin()],
  css: {
    postcss: './postcss.config.js'
  }
})
