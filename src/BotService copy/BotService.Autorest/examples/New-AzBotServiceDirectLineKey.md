### Example 1: Regenerate directLine Key
```powershell
New-AzBotServiceDirectLineKey -ChannelName 'DirectLineChannel' -ResourceGroupName botTest-rg -ResourceName botTest1 -Key key1 -SiteName siteName
```

Regenerates secret keys and returns them for the DirectLine Channel of a particular BotService resource.


