### Example 1: Update the Bot by Name and ResourceGroupName
```powershell
Update-AzBotService -Name 'youri-apptest' -ResourceGroupName 'youriBotTest' -kind Bot
```
```output
Etag                                   Kind Location Name            SkuName SkuTier Type
----                                   ---- -------- ----            ------- ------- ----
"0700e71b-0000-1800-0000-5fd73ed80000" Bot  global   youri-apptest                   Microsoft.BotService/botServices
```

Update the Bot by Name and ResourceGroupName

### Example 2: Update the Bot by InputObject
```powershell
$getAzbot = Get-AzBotService -Name 'youri-apptest' -ResourceGroupName 'youriBotTest'
Update-AzBotService -InputObject $getAzbot -kind sdk
```
```output
Etag                                   Kind Location Name            SkuName SkuTier Type
----                                   ---- -------- ----            ------- ------- ----
"07008b1c-0000-1800-0000-5fd73f9e0000" sdk  global   youri-apptest                   Microsoft.BotService/botServices
```

Update the Bot by InputObject

