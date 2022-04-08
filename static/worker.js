function evaluate(code) {
  const func = new Function(code)
  const output = func()
  return output
}



onmessage = function (event) {


  const code = event.data
  const output = evaluate(code)
  this.postMessage(output)
  postMessage(output);
}
