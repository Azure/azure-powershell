### Example 1: Validate the data connection parameters
```powershell
PS C:\>  $dataConnectionProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.EventHubDataConnection -Property @{Location=$location; Kind=$kind; EventHubResourceId=$eventHubResourceId; DataFormat=$dataFormat; ConsumerGroup='$Default'; Compression= "None"; TableName = $tableName; MappingRuleName = $tableMappingName}
PS C:\>  $dataConnectionValidation = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DataConnectionValidation -Property @{DataConnectionName=$dataConnectionName; Property=$dataConnectionProperties}
PS C:\> Invoke-AzKustoDataConnectionValidation -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Parameter $dataConnectionValidation

ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command checks if the data connection parameters are valid.