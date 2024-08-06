param myArray array
param myString string
param myObject object
param myInt int
param myBool bool
@secure()
param mySecureString string

output all object = {
  array: myArray
  string: myString
  object: myObject
  int: myInt
  bool: myBool
#disable-next-line outputs-should-not-contain-secrets
  secureString: mySecureString
}
