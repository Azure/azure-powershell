### Example 1: Create Azure Synapse workspace data source object
```powershell
New-AzPurviewAzureSynapseWorkspaceDataSourceObject -Kind 'AzureSynapseWorkspace' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -DedicatedSqlEndpoint 'g1euap.sql.azuresynapse.net' -ServerlessSqlEndpoint 'rg1euap-ondemand.sql.azuresynapse.net'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
DedicatedSqlEndpoint     : g1euap.sql.azuresynapse.net
Id                       :
Kind                     : AzureSynapseWorkspace
LastModifiedAt           :
Location                 :
Name                     :
ResourceGroup            :
ResourceName             :
Scan                     :
ServerlessSqlEndpoint    : rg1euap-ondemand.sql.azuresynapse.net
SubscriptionId           :
```

Create Azure Synapse workspace data source object

