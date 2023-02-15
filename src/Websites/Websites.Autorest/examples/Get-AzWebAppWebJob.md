### Example 1: List webjobs for an app
```powershell
PS C:\> Get-AzWebAppWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 

Name                               Kind WebJobType
----                               ---- ----------
appService-test01/triggeredjob-01
appService-test01/triggeredjob-02
appService-test01/continuousjob-01
appService-test01/continuousjob-02
```

This command lists webjobs for an app.
