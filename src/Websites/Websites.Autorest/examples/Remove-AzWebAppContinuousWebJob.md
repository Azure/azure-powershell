### Example 1: Delete a continuous web job for an app
```powershell
PS C:\> Remove-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-01

```

This command deletes a continuous web job for an app.

### Example 2: Delete a continuous web job for an app by pipeline
```powershell
PS C:\> Get-AzWebAppContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name continuousjob-02 | Remove-AzWebAppContinuousWebJob

```

This command deletes a continuous web job for an app by pipeline.