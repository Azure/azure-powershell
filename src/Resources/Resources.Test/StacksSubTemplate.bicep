targetScope = 'subscription'

@description('An array of the allowed locations, all other locations will be denied by the created policy.')
param allowedLocations array = [
  'westus'
]
param policyDefinitionName string

resource policyDefinition 'Microsoft.Authorization/policyDefinitions@2020-03-01' = {
  name: policyDefinitionName
  properties: {
    policyType: 'Custom'
    mode: 'All'
    parameters: {}
    policyRule: {
      if: {
        not: {
          field: 'location'
          in: allowedLocations
        }
      }
      then: {
        effect: 'audit'
      }
    }
  }
}
