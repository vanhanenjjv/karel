function move() {
  this.postMessage(['Move'])
}

function turn(Direction) {
  this.postMessage(['Turn', Direction])
}

function pickup() {
  this.postMessage(['Pickup'])
}

function drop() {
  this.postMessage(['Drop'])
}

onmessage = function (event) {  
  const code = event.data
  const func = new Function(code)
  this.postMessage(['Start'])
  func()
  this.postMessage(['End'])
}
