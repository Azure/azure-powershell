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
