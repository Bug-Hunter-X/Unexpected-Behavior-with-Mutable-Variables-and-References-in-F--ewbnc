let mutable x = 10
let mutable y = 20

let swap x y = 
    let temp = x
    x <- y
    y <- temp

swap x y
printf "%d %d" x y //This will print 20 20 as expected

let swap2 (x:int ref) (y:int ref) = 
    let temp = !x
    x := !y
    y := temp

let mutable x2 = ref 10
let mutable y2 = ref 20
swap2 x2 y2
printf "%d %d" !x2 !y2 // This will also print 20 20 as expected

//The correct way to swap values with references
let swap3 (x:int ref) (y:int ref) = 
    let temp = !x
    x := !y
    y := temp

let mutable x3 = ref 10
let mutable y3 = ref 20
swap3 x3 y3
printf "%d %d" !x3 !y3 //This will print 20 10 as expected

//Another example
let swap4 x y = 
    (y, x) //Tuple return

let a = 10
let b = 20
let (a1, b1) = swap4 a b
printf "%d %d" a1 b1