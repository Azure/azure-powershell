### Example 1: 
```powershell
Update-AzStackHciCluster -ResourceGroupName test-rg -Name myCluster3 -DesiredPropertyDiagnosticLevel Enhanced -DesiredPropertyWindowsServerSubscription Disabled
```

```output
Location Name
-------- ----
eastus   myCluster3
```

Updating DiagnosticLevel and WindowsServerSubscription values for a cluster.
