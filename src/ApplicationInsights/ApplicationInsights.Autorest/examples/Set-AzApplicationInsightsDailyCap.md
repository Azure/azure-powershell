### Example 1: Set daily data volume cap for an application insights resource
```powershell
PS C:\> Set-AzApplicationInsightsDailyCap -ResourceGroupName "testgroup" -Name "test" -DailyCapGB 400 -DisableNotificationWhenHitCap
```

Set the daily data volume cap to 400GB per day and stop send notification when hit cap for resource "test" in resource group "testgroup"

