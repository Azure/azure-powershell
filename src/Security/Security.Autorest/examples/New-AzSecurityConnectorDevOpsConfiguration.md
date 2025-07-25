### Example 1: Create new DevOps Configuration for the security connector
```powershell
New-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName "securityconnectors-pwsh-tmp" -SecurityConnectorName "ado-sdk-pwsh-test03" -AutoDiscovery Disabled -TopLevelInventoryList @("org1", "org2") -AuthorizationCode "myAuthorizationCode"
```

```output
AuthorizationCode               : 
AutoDiscovery                   : Disabled
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/securityconnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/ado-sdk-pwsh-test03/devops/default
Name                            : default
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : Resource creation successful.
ProvisioningStatusUpdateTimeUtc : 
ResourceGroupName               : securityconnectors-pwsh-tmp
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
TopLevelInventoryList           : 
Type                            : Microsoft.Security/securityConnectors/devops
```

