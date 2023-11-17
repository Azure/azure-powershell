### Example 1: Set advisor configuration by subscription id
```powershell
Set-AzAdvisorConfiguration -Exclude -LowCpuThreshold 20
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default True    20
```

 Set advisor configuration by subscription id

### Example 2:  Set advisor configuration by resource group name
```powershell
Set-AzAdvisorConfiguration -Exclude
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default True
```

Set advisor configuration by resource group name

