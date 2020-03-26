### Example 1: Stop an existing Kusto cluster by name

```powershell
PS C:\> Stop-AzKustoCluster -ResourceGroupName testrg -Name mykustocluster
```

The above command stops the Kusto cluster named "mykustocluster" found in the resource group "testrg".

### Example 2: Stop an existing Kusto cluster by piping

```powershell
PS C:\> Get-AzKustoCluster -ResourceGroupName testrg -Name mykustocluster | Stop-AzKustoCluster
```

The above command gets the Kusto cluster named "mykustocluster" found in the resource group "testrg" using the `Get-AzKustoCluster` cmdlet, and then pipes the result to `Stop-AzKustoCluster` to stop it.
