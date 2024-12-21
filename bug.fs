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

//However, this will not work as expected
let swap3 (x:int ref) y = 
    let temp = !x
    x := y
    y //This line is the culprit

let mutable x3 = ref 10
let y3 = 20
let result = swap3 x3 y3
printf "%d %d" !x3 result //this will print 20 20, it seems correct

let mutable x4 = ref 10
let y4 = 20
let result2 = swap3 x4 y4
printf "%d %d" !x4 result2 //This will print 20 20. Why?

//The reason is that y is not passed by reference, only x. Therefore, the assignment x := y will correctly modify x, but the value of y remains unchanged. The value of y is returned (20) and printed in the console as expected. This may not be what the user intended in the first place.