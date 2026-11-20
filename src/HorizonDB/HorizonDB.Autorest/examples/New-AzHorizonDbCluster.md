### Example 1: Create a cluster with geo-redundant backups and a managed identity
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'example-cluster'
    Location = 'eastus2'
    PostgreSqlVersion = '17'
    NetworkPublicAccess = 'Enabled'
    BackupGeoRedundancy = 'Enabled'
    BackupRetentionDay = 14
    UserAssignedIdentity = @("/subscriptions/$subscriptionId/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/fabric-writer")
    Tag = @{ environment = 'production' }
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Updating
ProvisioningState   : InProgress
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Create a cluster using service defaults
```powershell
New-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'minimum-defaults' -Location 'eastus2' -PostgreSqlVersion '18' -BackupGeoRedundancy 'Disabled' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : minimum-defaults
Location            : eastus2
PostgreSqlVersion   : 18
CreationMode        : Create
State               : Updating
ProvisioningState   : InProgress
BackupGeoRedundancy : Disabled
BackupRetentionDay  : 7
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Restore a cluster to a point in time in the same region
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'restored-cluster'
    Location = 'eastus2'
    CreationMode = 'PointInTimeRestore'
    CreationSourceClusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/source-cluster"
    PointInTimeUtc = [datetime]'2026-07-27T12:00:00Z'
    NetworkPublicAccess = 'Disabled'
    BackupRetentionDay = 14
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : restored-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : PointInTimeRestore
State               : Provisioning
ProvisioningState   : Provisioning
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 4: Restore a cluster to another region
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'cross-region-restored-cluster'
    Location = 'westus2'
    CreationMode = 'PointInTimeRestore'
    CreationSourceClusterResourceId = "/subscriptions/$subscriptionId/resourceGroups/example-resource-group/providers/Microsoft.HorizonDb/clusters/source-cluster"
    CreationSourceClusterLocation = 'eastus2'
    PointInTimeUtc = [datetime]'2026-07-27T12:00:00Z'
    NetworkPublicAccess = 'Disabled'
    BackupRetentionDay = 14
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : cross-region-restored-cluster
Location            : westus2
PostgreSqlVersion   : 17
CreationMode        : PointInTimeRestore
State               : Provisioning
ProvisioningState   : Provisioning
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 5: Create a cluster with a customer-managed encryption key
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$identityId = "/subscriptions/$subscriptionId/resourceGroups/identity-resource-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/primary-encryption-identity"
$parameters = @{
    ResourceGroupName = 'example-resource-group'
    Name = 'example-cluster'
    Location = 'eastus2'
    PostgreSqlVersion = '17'
    BackupGeoRedundancy = 'Disabled'
    BackupRetentionDay = 14
    UserAssignedIdentity = @($identityId)
    DataEncryptionType = 'AzureKeyVault'
    DataEncryptionPrimaryKeyUri = 'https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key'
    DataEncryptionPrimaryUserAssignedIdentityId = $identityId
}
New-AzHorizonDbCluster @parameters | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay, DataEncryptionType, DataEncryptionPrimaryKeyUri
```

```output
Name                        : example-cluster
Location                    : eastus2
PostgreSqlVersion           : 17
CreationMode                : Create
State                       : Updating
ProvisioningState           : InProgress
BackupGeoRedundancy         : Disabled
BackupRetentionDay          : 14
DataEncryptionType          : AzureKeyVault
DataEncryptionPrimaryKeyUri : https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
