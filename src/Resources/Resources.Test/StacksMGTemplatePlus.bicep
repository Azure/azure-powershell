targetScope = 'managementGroup'

param subId string
param moduleName string
param policyDefinitionName1 string
param policyDefinitionName2 string

module policy 'StacksSubTemplatePlus.bicep' = {
  name: moduleName
  scope: subscription(subId)
  params: {
    policyDefinitionName1: policyDefinitionName1
    policyDefinitionName2: policyDefinitionName2
  }
}
