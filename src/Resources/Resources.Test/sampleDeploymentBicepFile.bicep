param location string = 'westus'
param baseName string = 'mysa'

var storageSku = 'Standard_LRS'

resource stg 'Microsoft.Storage/storageAccounts@2019-06-01' = {
  name: '${baseName}${uniqueString(resourceGroup().id)}'
  location: location
  kind: 'Storage'
  sku: {
    name: storageSku
  }
}

output storageId string = stg.id
