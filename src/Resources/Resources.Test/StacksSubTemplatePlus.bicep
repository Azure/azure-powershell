targetScope = 'subscription'

@description('An array of the allowed locations, all other locations will be denied by the created policy.')
param allowedLocations1 array = [
  'westus'
]

@description('An array of the allowed locations, all other locations will be denied by the created policy.')
param allowedLocations2 array = [
  'eastus'
]

param policyDefinitionName1 string
param policyDefinitionName2 string

resource policyDefinition1 'Microsoft.Authorization/policyDefinitions@2020-03-01' = {
  name: policyDefinitionName1
  properties: {
    policyType: 'Custom'
    mode: 'All'
    parameters: {}
    policyRule: {
      if: {
        not: {
          field: 'location'
          in: allowedLocations1
        }
      }
      then: {
        effect: 'audit'
      }
    }
  }
}

resource policyDefinition2 'Microsoft.Authorization/policyDefinitions@2020-03-01' = {
  name: policyDefinitionName2
  properties: {
    policyType: 'Custom'
    mode: 'All'
    parameters: {}
    policyRule: {
      if: {
        not: {
          field: 'location'
          in: allowedLocations2
        }
      }
      then: {
        effect: 'audit'
      }
    }
  }
}
