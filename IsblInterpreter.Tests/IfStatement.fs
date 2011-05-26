#light

module IfStatement

open Xunit
open Evaluator

[<Fact>]
let IfOnTrueVariableExecutesIfBody() =
  let sample = @"
    a := 1;
    if (a)
      a := 3
    endif"   
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(3))

[<Fact>]
let IfOnFalseVariableExecutesIfBody() =
  let sample = @"
    a := 0;
    if (a)
      a := 3
    endif"   
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(0))

[<Fact>]
let IfBodyCanContainStatementList() =
  let sample = @"
    a := 1;
    if (a)
      a := 3;
      a := 4
    endif"   
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(4))

[<Fact>]
let IfOnFalseExecutesElseBody() =
  let sample = @"
    a := 0;
    if (a)
      a := 3
    else
      a := 4
    endif"   
  let env = interpret sample
  Assert.True(env.TryFind("a") = Some(4))

