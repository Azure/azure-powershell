### Example 1: Delete a triggered web job for an app
```powershell
PS C:\> Remove-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01

```

This command deletes a triggered web job for an app.

### Example 2: Delete a triggered web job for an app by pipeline
```powershell
PS C:\> Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-02 | Remove-AzWebAppTriggeredWebJob

```

This command deletes a triggered web job for an app by pipeline.