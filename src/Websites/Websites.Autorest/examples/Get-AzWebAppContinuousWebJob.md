### Example 1: List continuous webs for an app
```powershell
PS C:\> Get-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01

Name                               Kind WebJobType ResourceGroupName
----                               ---- ---------- -----------------
appService-test01/continuousjob-01                 webjob-rg-test
appService-test01/continuousjob-02                 webjob-rg-test
```

This command lists continuous webs for an app.

### Example 2: Get continuous web for an app
```powershell
PS C:\> Get-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01

Name                               Kind WebJobType ResourceGroupName
----                               ---- ---------- -----------------
appService-test01/continuousjob-01                 webjob-rg-test
```

This command gets continuous web for an app.

### Example 3: Get continuous web for an app by pipeline
```powershell
PS C:\> $webjob = Get-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01
PS C:\> Start-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01 
PS C:\> $webjob.Id | Get-AzWebAppContinuousWebJob

Name                               Kind WebJobType ResourceGroupName
----                               ---- ---------- -----------------
appService-test01/continuousjob-01                 webjob-rg-test
```

This command gets continuous web for an app by pipeline.