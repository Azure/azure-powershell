### Example 1: List triggered webs for an app
```powershell
Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01
```
```output
Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test   
appService-test01/triggeredjob-02                 webjob-rg-test  
```

This command lists triggered webs for an app.

### Example 2: Get triggered web for an app
```powershell
Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01
```
```output
Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test
```

This command gets triggered web for an app.

### Example 3: Get triggered web for an app by pipeline
```powershell
$webjob = Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01
Start-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01 
$webjob.Id | Get-AzWebAppTriggeredWebJob
```
```output
Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test
```

This command gets triggered web for an app by pipeline.