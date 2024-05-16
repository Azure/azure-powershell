### Example 1: Get Security Connector DevOps Configuration
```powershell
Get-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01
```

```output
AuthorizationCode               : 
AutoDiscovery                   : Disabled
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default
Name                            : default
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : Resource creation successful.
ProvisioningStatusUpdateTimeUtc : 
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
TopLevelInventoryList           : 
Type                            : Microsoft.Security/securityConnectors/devops
```

### Example 2: Try to get non existing Security Connector DevOps Configuration 
```powershell
Get-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName securityconnectors-tests -SecurityConnectorName aws-sdktest01
```

```output
Get-AzSecurityConnectorDevOpsConfiguration_Get: DevOps configuration was not found
```



