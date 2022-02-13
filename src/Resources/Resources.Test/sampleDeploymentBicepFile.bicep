param location string = 'westus'
param name string = 'bezstorage007'
var storageSku = 'Standard_LRS'

resource stg 'Microsoft.Storage/storageAccounts@2019-06-01' = {
  name: name
  location: location
  kind: 'Storage'
  sku: {
    name: storageSku
  }
}

output storageId string = stg.id