### Example 1: Get by fabric name
```powershell
Get-AzMigrateLocalReplicationFabric -ResourceGroupName "test-rg" -Name "testsrcappreplicationfabric"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationFabrics/testsrcappreplicationfabric
Location                     : southeastasia
Name                         : testsrcappreplicationfabric
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.FabricModelProperties
SystemDataCreatedAt          : 8/11/2023 6:39:04 PM
SystemDataCreatedBy          : testuser@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/11/2023 6:48:29 PM
SystemDataLastModifiedBy     : testuser@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DataReplication/replicationFabrics
```

Retrieves a fabric by its name. 

### Example 2: Get by fabric input object
```powershell
$InputObject = Get-AzMigrateLocalReplicationFabric -ResourceGroupName "test-rg" -Name "testsrcappreplicationfabric"

Get-AzMigrateLocalReplicationFabric -InputObject $InputObject

$InputObject | Get-AzMigrateLocalReplicationFabric
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationFabrics/testsrcappreplicationfabric
Location                     : southeastasia
Name                         : testsrcappreplicationfabric
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.FabricModelProperties
SystemDataCreatedAt          : 8/11/2023 6:39:04 PM
SystemDataCreatedBy          : testuser@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/11/2023 6:48:29 PM
SystemDataLastModifiedBy     : testuser@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DataReplication/replicationFabrics
```

Retrieves a fabric by the fabric itself as an input object.

### Example 3: List by resource group name
```powershell
Get-AzMigrateLocalReplicationFabric -ResourceGroupName "test-rg"
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationFabrics/testsrcappreplicationfabric
Location                     : southeastasia
Name                         : testsrcappreplicationfabric
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.FabricModelProperties
SystemDataCreatedAt          : 8/11/2023 6:39:04 PM
SystemDataCreatedBy          : testuser@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/11/2023 6:48:29 PM
SystemDataLastModifiedBy     : testuser@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DataReplication/replicationFabrics

Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationFabrics/testtgtappreplicationfabric
Location                     : southeastasia
Name                         : testtgtappreplicationfabric
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.FabricModelProperties
SystemDataCreatedAt          : 8/11/2023 9:16:46 PM
SystemDataCreatedBy          : testuser@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/11/2023 9:16:46 PM
SystemDataLastModifiedBy     : testuser@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DataReplication/replicationFabrics
```

Retrieves all fabrics from a resource group by name.

### Example 4: List all fabircs
```powershell
Get-AzMigrateLocalReplicationFabric
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationFabrics/testsrcappreplicationfabric
Location                     : southeastasia
Name                         : testsrcappreplicationfabric
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.FabricModelProperties
SystemDataCreatedAt          : 8/11/2023 6:39:04 PM
SystemDataCreatedBy          : testuser@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/11/2023 6:48:29 PM
SystemDataLastModifiedBy     : testuser@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DataReplication/replicationFabrics

Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.DataReplication/replicationFabrics/testtgtappreplicationfabric
Location                     : southeastasia
Name                         : testtgtappreplicationfabric
Property                     : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.FabricModelProperties
SystemDataCreatedAt          : 8/11/2023 9:16:46 PM
SystemDataCreatedBy          : testuser@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/11/2023 9:16:46 PM
SystemDataLastModifiedBy     : testuser@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DataReplication/replicationFabrics

...
```

Retrieves all fabrics from a subscription.

