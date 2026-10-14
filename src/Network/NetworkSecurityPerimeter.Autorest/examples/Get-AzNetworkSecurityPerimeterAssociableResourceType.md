### Example 1: List NetworkSecurityPerimeter AssociableResourceTypes
```powershell
Get-AzNetworkSecurityPerimeterAssociableResourceType -Location eastus2euap
```

```output
Name
----
Microsoft.Sql.servers
Microsoft.Storage.storageAccounts
Microsoft.EventHub.namespaces
Microsoft.CognitiveServices.accounts
Microsoft.Search.searchServices
Microsoft.Purview.accounts
Microsoft.ContainerService.managedClusters
Microsoft.KeyVault.vaults
Microsoft.OperationalInsights.workspaces
Microsoft.Insights.dataCollectionEndpoints
Microsoft.ServiceBus.namespaces
```

List NetworkSecurityPerimeter AssociableResourceTypes

### Example 2: List AssociableResourceTypes with new properties
```powershell
Get-AzNetworkSecurityPerimeterAssociableResourceType -Location eastus2euap | Select-Object DisplayName, ReadinessState, OutboundSupported, Description, ServiceTag
```

```output
DisplayName                                         ReadinessState OutboundSupported Description ServiceTag
-----------                                         -------------- ----------------- ----------- ----------
Microsoft.AppConfiguration/configurationStores      Onboarding                  True             {}
Microsoft.CognitiveServices/accounts                GA                          True             {}
Microsoft.DocumentDB/databaseAccounts               Preview                     True             {}
Microsoft.EventGrid/domains                         Preview                     True             {}
Microsoft.Sql/servers                               Preview                     True             {}
Microsoft.KeyVault/vaults                           GA                         False             {}
```

List AssociableResourceTypes showing the new ReadinessState, OutboundSupported, Description, and ServiceTag properties