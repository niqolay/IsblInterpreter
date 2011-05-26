#light

module FSharpAssert

let throws command =
  try
    do command()
    false
  with
    | _ -> true 

let throwsSpecific(command, exceptionType: System.Type) =
  try
    do command()
    false
  with
    | err -> exceptionType.IsAssignableFrom(err.GetType())

