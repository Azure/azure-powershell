targetScope = 'managementGroup'

param subId string
param moduleName string
param policyDefinitionName string

module policy 'StacksSubTemplate.bicep' = {
  name: moduleName
  scope: subscription(subId)
  params: {
    policyDefinitionName: policyDefinitionName
  }
}
