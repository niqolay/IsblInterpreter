module IsblAst

type expr = 
    | Val of string 
    | Int of int
    | Plus of expr * expr
    | Minus of expr * expr

// TODO. NiQ. По идее, IfThen должен быть of expr * Seq, но такое не получается сделать, разбираюсь.
type stmt = 
    | Assign of string * expr
    | While of expr * stmt
    | Seq of stmt list
    | IfThen of expr * stmt list
    | IfThenElse of expr * stmt list * stmt list
    | Print of expr

type prog = Prog of stmt list
