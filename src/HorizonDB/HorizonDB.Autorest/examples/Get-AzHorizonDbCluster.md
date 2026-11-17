### Example 1: List clusters in the current subscription
```powershell
Get-AzHorizonDbCluster | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: List clusters in a resource group
```powershell
Get-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : westcentralus
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Get a cluster
```powershell
Get-AzHorizonDbCluster -ResourceGroupName 'example-resource-group' -Name 'example-cluster' | Format-List -Property Name, Location, PostgreSqlVersion, CreationMode, State, ProvisioningState, BackupGeoRedundancy, BackupRetentionDay
```

```output
Name                : example-cluster
Location            : eastus2
PostgreSqlVersion   : 17
CreationMode        : Create
State               : Ready
ProvisioningState   : Succeeded
BackupGeoRedundancy : Enabled
BackupRetentionDay  : 14
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
