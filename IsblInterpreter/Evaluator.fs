#light

module Evaluator

open IsblAst
open IsblParser
open IsblLexer
open Microsoft.FSharp.Text.Lexing

let parseText text = 
    let lexbuf = Lexing.LexBuffer<_>.FromString text
    try 
        IsblParser.start IsblLexer.token lexbuf
    with e -> 
        let pos = lexbuf.EndPos
        printf "Error near line %d, character %d\n" pos.Line pos.Column
        failwith "!"

let rec evalE (env: Map<string, int>) = function
    | Val v          -> if env.ContainsKey v then env.[v]
                        else failwith ("unbound variable: " + v)
    | Int i          -> i
    | Plus  (e1, e2) -> evalE env e1 + evalE env e2
    | Minus (e1, e2) -> evalE env e1 - evalE env e2

and eval (env: Map<string, int>) = function
    | Assign (v, e) ->
         env.Add(v, evalE env e)
    | While (e, body) ->
         let rec loop env e body =
             if evalE env e <> 0 then
                 loop (eval env body) e body
             else env
         loop env e body
    | Seq stmts ->
         List.fold eval env stmts
    | IfThen (e, stmts) -> 
         if evalE env e <> 0 then List.fold eval env stmts else env
    | IfThenElse (e, stmts1, stmts2) ->
         if evalE env e <> 0 then List.fold eval env stmts1 else List.fold eval env stmts2
    | Print e ->
         printf "%d" (evalE env e); env


let interpret text =       
    match parseText text with
        | Prog stmts -> 
            eval Map.empty (Seq stmts)
        



