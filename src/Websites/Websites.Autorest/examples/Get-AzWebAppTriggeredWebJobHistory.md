### Example 1: List triggered web job's history for an app
```powershell
PS C:\> Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01

Kind Name                                                 ResourceGroupName
---- ----                                                 -----------------
     appService-test01/triggeredjob-01/202201040249386155 webjob-rg-test
     appService-test01/triggeredjob-01/202201040236300466 webjob-rg-test
```

This command lists triggered web job's history for an app.

### Example 2: Get triggered web job's history for an app
```powershell
PS C:\> Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01 -Id 202201040236300466

Kind Name                                                 ResourceGroupName
---- ----                                                 -----------------
     appService-test01/triggeredjob-01/202201040236300466 webjob-rg-test
```

This command get triggered web job's history for an app.

### Example 3: Get triggered web job's history for an app by pipeline
```powershell
PS C:\> $logs =  Get-AzWebAppTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01
PS C:\> $logs[0].Id | Get-AzWebAppTriggeredWebJobHistory

Kind Name                                                 ResourceGroupName
---- ----                                                 -----------------
     appService-test01/triggeredjob-01/202201040236300466 webjob-rg-test
```

This command get triggered web job's history for an app by pipeline.

