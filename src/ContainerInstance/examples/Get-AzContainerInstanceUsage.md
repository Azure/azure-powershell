### Example 1: Get the usage of the location
```powershell
PS C:\> Get-AzContainerInstanceUsage -Location eastus

CurrentValue Limit Unit
------------ ----- ----
9            100   Count
9            100   Count
1            48    Count
0            0     Count
0            0     Count
0            0     Count
0            3000  Count
```

Get the usage for the current subscription in the region `eastus`.