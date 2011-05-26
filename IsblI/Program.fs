#light
open Evaluator

let sample = "counter := 100; accum := 0; \n\
              while counter do \n\
              begin \n\
                  counter := counter - 1; \n\
                  print accum; \n\
                  accum := accum + counter \n\
              end; \n\
              print accum"

interpret sample |> ignore

System.Console.ReadKey() |> ignore
