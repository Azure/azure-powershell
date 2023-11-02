type foo = {
  abc: string
}

type bar = 'abc' | 'def'
type aliasInt = int

param array int[]
param object { def: string }
param objectRef foo
param enum 'abc' | 'def' | 'ghi'
param enumRef bar
param int2 aliasInt
