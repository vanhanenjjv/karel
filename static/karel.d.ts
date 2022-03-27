declare namespace Karel {
  type Direction =
    | "right"
    | "left"
  
  function move(): void;
  function turn(direction: Direction): void;
  function pickup(): void;
  function drop(): void;
}
