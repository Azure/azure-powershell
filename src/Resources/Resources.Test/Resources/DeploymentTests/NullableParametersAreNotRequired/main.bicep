// sample from https://github.com/Azure/bicep/issues/12538
targetScope = 'subscription'
param yourName string?

output greeting string = !empty(yourName)
  ? 'Hello, ${yourName}. Nice to meet you!'
  : 'Hey, nice to meet you!'

// verify this also works with nullable custom types
param optionalCustomType customType?
type customType = {
  age: int
}

param requiredNullableCustomType nullableCustomType
type nullableCustomType = {
  age: int
}?

type customTypeWithRequired = customType!

param optionalRequiredCustomType customTypeWithRequired?

// repro for https://github.com/Azure/bicep/issues/13350
type nullableArrayOfObjectsType = {
  property1: string
}[]?

param param1 nullableArrayOfObjectsType

output output1 nullableArrayOfObjectsType = param1
