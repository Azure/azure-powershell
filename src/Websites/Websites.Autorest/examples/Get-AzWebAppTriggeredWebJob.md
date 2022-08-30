### Example 1: List triggered webs for an app
```powershell
PS C:\> Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01

Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test   
appService-test01/triggeredjob-02                 webjob-rg-test  
```

This command lists triggered webs for an app.

### Example 2: Get triggered web for an app
```powershell
PS C:\> Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01

Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test
```

This command gets triggered web for an app.

### Example 3: Get triggered web for an app by pipeline
```powershell
PS C:\> $webjob = Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01
PS C:\> Start-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01 
PS C:\> $webjob.Id | Get-AzWebAppTriggeredWebJob

Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test
```

This command gets triggered web for an app by pipeline.