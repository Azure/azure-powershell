### Example 1: Update DevOps configuration
```powershell
Update-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName "securityConnectors-pwsh-tmp" -SecurityConnectorName "ado-sdk-pwsh-test03" -AutoDiscovery Enabled
```

```output
AuthorizationCode               : 
AutoDiscovery                   : Enabled
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/securityConnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/ado-sdk-pwsh-test03/devops/default
Name                            : default
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : Resource creation successful.
ProvisioningStatusUpdateTimeUtc : 
ResourceGroupName               : securityConnectors-pwsh-tmp
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
TopLevelInventoryList           : 
Type                            : Microsoft.Security/securityConnectors/devops
```


