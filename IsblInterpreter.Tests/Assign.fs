#light

module Assign.Tests

open Xunit
open Evaluator

[<Fact>]
let Assing_ShouldSetValueOnEnvironment() =
  let sample = "a := 2"
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(2))

[<Fact>]
let Reassing_ShouldResetValueOnEnvironment() =
  let sample = "a := 2; a := 3"
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(3))
