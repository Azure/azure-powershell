### Example 1: Get Configuration by SubscriptionId
```powershell
Get-AzAdvisorConfiguration
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default False   10
```

Get Configuration by SubscriptionId

### Example 2: Get Configuration by ResourceGroupName
```powershell
Get-AzAdvisorConfiguration -ResourceGroupName lnxtest
```

```output
Name                                         Exclude LowCpuThreshold
----                                         ------- ---------------
9e223dbe-3399-4e19-88eb-0975f02ac87f-lnxtest False
```

 Get Configuration by ResourceGroupName




