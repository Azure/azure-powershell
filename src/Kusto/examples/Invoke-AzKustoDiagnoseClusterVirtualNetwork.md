### Example 1: Show network connectivity diagnosis for external resources 
```powershell
PS C:\> Invoke-AzKustoDiagnoseClusterVirtualNetwork -ResourceGroupName "testrg" -ClusterName "testnewkustocluster"

```

The above command diagnoses network connectivity status for external resources on which the cluster "testnewkustocluster" is dependent on
