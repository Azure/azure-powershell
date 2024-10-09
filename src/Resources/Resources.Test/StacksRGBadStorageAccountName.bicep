targetScope = 'resourceGroup'

param location string = resourceGroup().location
param name string
var storageSku = 'Standard_LRS'

resource stg 'Microsoft.Storage/storageAccounts@2018-11-01' = {
  name: name
  location: location
  kind: 'Storage'
  sku: {
    name: storageSku
  }
}