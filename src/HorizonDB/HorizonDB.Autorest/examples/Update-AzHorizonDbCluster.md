### Example 1: Update cluster networking, backup retention, and tags
```powershell
$tags = @{
    environment = 'production'
    team = 'data-platform'
}
Update-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' -NetworkPublicAccess 'Disabled' -BackupRetentionDay 21 -Tag $tags | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 21
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Update the customer-managed encryption key reference
```powershell
Update-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' -DataEncryptionPrimaryKeyUri 'https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay, DataEncryptionType, DataEncryptionPrimaryKeyUri
```

```output
Name                        : example-cluster
Location                    : eastus2
PostgreSqlVersion           : 17
CreationMode                : Create
State                       : Ready
ProvisioningState           : Succeeded
BackupGeoRedundancy         : Disabled
BackupRetentionDay          : 14
DataEncryptionType          : AzureKeyVault
DataEncryptionPrimaryKeyUri : https://primary-key-vault.vault.azure.net/keys/horizondb-primary-key
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
