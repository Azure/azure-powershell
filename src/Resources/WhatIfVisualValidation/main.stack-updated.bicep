param location string = resourceGroup().location

var sameStorageName = take('wvsame${uniqueString(resourceGroup().id)}', 24)
var modifyStorageName = take('wvmod${uniqueString(resourceGroup().id)}', 24)
var deleteStorageName = take('wvdel${uniqueString(resourceGroup().id)}', 24)
var maybeDeleteStorageName = take('wvmaydel${uniqueString(resourceGroup().id)}', 24)

resource sameStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: sameStorageName
  location: location
  tags: {
    scenario: 'no-change'
    owner: 'what-if-visual-validation'
  }
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowSharedKeyAccess: false
    allowBlobPublicAccess: false
    minimumTlsVersion: 'TLS1_2'
  }
}

resource modifyStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: modifyStorageName
  location: location
  tags: {
    scenario: 'modify'
    owner: 'what-if-visual-validation'
    oldTag: 'will-be-deleted'
  }
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowSharedKeyAccess: false
    allowBlobPublicAccess: true
    minimumTlsVersion: 'TLS1_0'
  }
}

resource deleteStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: deleteStorageName
  location: location
  tags: {
    scenario: 'definite-delete'
    owner: 'what-if-visual-validation'
  }
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowSharedKeyAccess: false
    allowBlobPublicAccess: false
    minimumTlsVersion: 'TLS1_2'
  }
}

resource maybeDeleteStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: maybeDeleteStorageName
  location: location
  tags: {
    scenario: 'potential-delete-now-managed'
    owner: 'what-if-visual-validation'
  }
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowSharedKeyAccess: false
    allowBlobPublicAccess: false
    minimumTlsVersion: 'TLS1_2'
  }
}

resource vnet 'Microsoft.Network/virtualNetworks@2023-11-01' = {
  name: 'wv-vnet-${uniqueString(resourceGroup().id)}'
  location: location
  tags: {
    scenario: 'network'
    owner: 'what-if-visual-validation'
  }
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.10.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'default'
        properties: {
          addressPrefix: '10.10.0.0/24'
        }
      }
    ]
  }
}
