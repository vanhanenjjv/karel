

export function run(source) {
  console.log(window)
  const func = new Function(source)
  func.bind
  func()
}

