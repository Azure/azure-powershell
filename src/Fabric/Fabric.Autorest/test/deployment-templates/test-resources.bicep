@description('The capacity resource name.')
param capacityName string

@description('The location of the resource.')
param location string

@description('The Sku tier of the resource.')
param skuTier string

@description('The Sku name of the resource.')
param skuName string

@description('The administration members of the resource.')
param administrationMembers array

@description('The dictionary of tags')
param tags object

resource fabricCapacity 'Microsoft.Fabric/capacities@2023-11-01' = {
  name: capacityName
  location: location
  sku: {
      name: skuName
      tier: skuTier
  }
  properties: {
    administration: {
        members: administrationMembers
    }
  }
  tags: tags
}

output CAPACITY_ID string = fabricCapacity.id
