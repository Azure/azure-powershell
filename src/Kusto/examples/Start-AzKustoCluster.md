### Example 1: Start a stopped Kusto cluster by name

```powershell
PS C:\> Start-AzKustoCluster -ResourceGroupName testrg -Name mykustocluster
```

The above command starts the stopped Kusto cluster named "mykustocluster" found in the resource group "testrg".

### Example 2: Start a stopped Kusto cluster by piping

```powershell
PS C:\> Get-AzKustoCluster -ResourceGroupName testrg -Name mykustocluster | Start-AzKustoCluster
```

The above command gets the Kusto cluster named "mykustocluster" found in the resource group "testrg" using the `Get-AzKustoCluster` cmdlet, and then pipes the result to `Start-AzKustoCluster` to start it.
