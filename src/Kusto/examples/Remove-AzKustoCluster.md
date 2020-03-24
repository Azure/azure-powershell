### Example 1 - Delete an existing Kusto cluster by name

```
PS C:\> Remove-AzKustoCluster -ResourceGroupName testrg -Name mykustocluster
```

The above command deletes the Kusto cluster named "mykustocluster" in the resource group "testrg".

### Example 2 - Delete an existing Kusto cluster by piping

```
PS C:\> Get-AzKustoCluster -ResourceGroupName testrg -Name mykustocluster | Remove-AzKustoCluster
```

The above command gets the Kusto cluster named "mykustocluster" in the resource group "testrg" using the `Get-AzKustoCluster` cmdlet, and then pipes the result to `Remove-AzKustoCluster` to delete it.
