#light

module Assign.Tests

open Xunit
open Evaluator

[<Fact>]
let AssignShouldSetValueOnEnvironment() =
  let sample = "a := 2"
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(2))

[<Fact>]
let ReassingShouldResetValueOnEnvironment() =
  let sample = "a := 2; a := 3"
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(3))

[<Fact>]
let CanAssignFromOneValueToAnother() =
  let sample = "b := 2; a := b"
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(2))

[<Fact>]
let CannotUseNotAssignedVariable() =
  let sample = "a := b"
  FSharpAssert.throws(fun (unit) -> interpret sample |> ignore)
