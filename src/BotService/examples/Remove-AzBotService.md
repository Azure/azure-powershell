### Example 1: Delete the BotService By Name and ResourceGroupName
```powershell
PS C:\> Remove-AzBotService -Name youri-bot -ResourceGroupName youriBotTest

```

Delete the BotService By Name and ResourceGroupName

### Example 2: Delete the BotService By InputObject
```powershell
PS C:\> $getservice = Get-AzBotService -Name youriechobottest -ResourceGroupName youriBotTest
Remove-AzBotService -InputObject $getservice

```
Delete the BotService By InputObject