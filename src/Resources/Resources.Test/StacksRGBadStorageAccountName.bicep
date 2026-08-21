targetScope = 'resourceGroup'

param location string = resourceGroup().location
param name string
var storageSku = 'Standard_LRS'

resource stg 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: name
  location: location
  kind: 'StorageV2'
  sku: {
    name: storageSku
  }
  properties: {
    allowSharedKeyAccess: false
  }
}