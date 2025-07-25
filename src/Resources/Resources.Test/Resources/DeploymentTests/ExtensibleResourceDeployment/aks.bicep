param location string = resourceGroup().location
param baseName string
param dnsPrefix string
param linuxAdminUsername string
param sshRSAPublicKey string

var osDiskSizeGB = 0
var agentCount = 3
var agentVMSize = 'standard_f2s_v2' //'Standard_DS2_v2'
var resourceNamee = toLower('${baseName}${uniqueString(resourceGroup().id)}')

resource aks 'Microsoft.ContainerService/managedClusters@2020-09-01' = {
  name: resourceNamee
  location: location
  properties: {
    dnsPrefix: dnsPrefix
    agentPoolProfiles: [
      {
        name: 'agentpool'
        osDiskSizeGB: osDiskSizeGB
        count: agentCount
        vmSize: agentVMSize
        osType: 'Linux'
        mode: 'System'
      }
    ]
    linuxProfile: {
      adminUsername: linuxAdminUsername
      ssh: {
        publicKeys: [
          {
            keyData: sshRSAPublicKey
          }
        ]
      }
    }
  }
  identity: {
    type: 'SystemAssigned'
  }
}

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: resourceNamee
  location: location
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId
    accessPolicies: []
    enabledForTemplateDeployment: true
  }
}

resource secret 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault
  name: 'kubeconfig'
  properties: {
    value: aks.listClusterAdminCredential().kubeconfigs[0].value
  }
}

output keyVaultId string = keyVault.id
output secretName string = secret.name
