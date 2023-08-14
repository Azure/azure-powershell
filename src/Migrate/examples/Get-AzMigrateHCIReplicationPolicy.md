### Example 1: Get by policy name
```powershell
Get-AzMigrateHCIReplicationPolicy -ResourceGroupName "test-rg" -VaultName "testproj1234replicationvault" -Name "testproj1234replicationvaultHyperVToAzStackHCIpolicy"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault
                               /replicationPolicies/testproj1234replicationvaultHyperVToAzStackHCIpolicy
Name                         : testproj1234replicationvaultHyperVToAzStackHCIpolicy
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelProperties
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelTags
Type                         : Microsoft.DataReplication/replicationVaults/replicationPolicies
```

Retrieves a policy by its name.

### Example 2: Get by policy input object
```powershell
$policy = Get-AzMigrateHCIReplicationPolicy -ResourceGroupName "test-rg" -VaultName "testproj1234replicationvault" -Name "testproj1234replicationvaultHyperVToAzStackHCIpolicy"

Get-AzMigrateHCIReplicationPolicy -InputObject $policy

$policy | Get-AzMigrateHCIReplicationPolicy
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault
                               /replicationPolicies/testproj1234replicationvaultHyperVToAzStackHCIpolicy
Name                         : testproj1234replicationvaultHyperVToAzStackHCIpolicy
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelProperties
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelTags
Type                         : Microsoft.DataReplication/replicationVaults/replicationPolicies
```

Retrieves a policy by the policy itself as an input object.

### Example 3: List by resource group name and vault name
```powershell
Get-AzMigrateHCIReplicationPolicy -ResourceGroupName "test-rg" -VaultName "testproj1234replicationvault"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationVaults/testproj1234replicationvault
                               /replicationPolicies/testproj1234replicationvaultHyperVToAzStackHCIpolicy
Name                         : testproj1234replicationvaultHyperVToAzStackHCIpolicy
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelProperties
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210216Preview.PolicyModelTags
Type                         : Microsoft.DataReplication/replicationVaults/replicationPolicies
```

Retrieves all policies from vault in some resource group by names.

