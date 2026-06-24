param location string = resourceGroup().location
param deployPotentialCreate bool = int(utcNow('%f')) > 4
param keepPotentialDelete bool = int(utcNow('%f')) > 4

var sameStorageName = take('wvsame${uniqueString(resourceGroup().id)}', 24)
var modifyStorageName = take('wvmod${uniqueString(resourceGroup().id)}', 24)
var createStorageName = take('wvnew${uniqueString(resourceGroup().id)}', 24)
var maybeCreateStorageName = take('wvmaynew${uniqueString(resourceGroup().id)}', 24)
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
    newTag: 'created'
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

resource createStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: createStorageName
  location: location
  tags: {
    scenario: 'create'
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

resource maybeCreateStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = if (deployPotentialCreate) {
  name: maybeCreateStorageName
  location: location
  tags: {
    scenario: 'potential-create'
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

resource maybeDeleteStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = if (keepPotentialDelete) {
  name: maybeDeleteStorageName
  location: location
  tags: {
    scenario: 'potential-delete'
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
    scenario: 'array-and-nested-modify'
    owner: 'what-if-visual-validation'
    changed: 'true'
  }
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.10.0.0/16'
        '10.11.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'default'
        properties: {
          addressPrefix: '10.10.1.0/24'
        }
      }
      {
        name: 'app'
        properties: {
          addressPrefix: '10.11.0.0/24'
        }
      }
    ]
  }
}

