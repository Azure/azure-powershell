### Example 1: Update an existing database by name
```powershell
PS C:\> $2ds = New-TimeSpan -Days 2
PS C:\> $4ds = New-TimeSpan -Days 4
PS C:\> Update-AzSynapseKustoPoolDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName mykustodatabase -Kind ReadWrite -SoftDeletePeriod $4ds -HotCachePeriod $2ds -Location 'East US'

Kind      Location Name                                
----      -------- ----                                
ReadWrite East US  testws/testkustopool/mykustodatabase
```

The above command updates the soft deletion period and hot cache period of the Kusto database "mykustodatabase" in the workspace "testws" found in the resource group "testrg".

### Example 2: Update an existing database via identity
```powershell
PS C:\> $database = Get-AzSynapseKustoPoolDatabase -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testkustopool -DatabaseName mykustodatabase
PS C:\> $2ds = New-TimeSpan -Days 2
PS C:\> $4ds = New-TimeSpan -Days 4
PS C:\> Update-AzSynapseKustoPoolDatabase -InputObject $database -Kind ReadWrite -SoftDeletePeriod $4ds -HotCachePeriod $2ds -Location 'East US'

Kind      Location Name                                
----      -------- ----                                
ReadWrite East US  testws/testkustopool/mykustodatabase
```

The above command updates the soft deletion period and hot cache period of the Kusto database "mykustodatabase" in the workspace "testws" found in the resource group "testrg" via database identity.
