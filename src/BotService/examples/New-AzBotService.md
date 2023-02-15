### Example 1: Create a new bot
```powershell
New-AzBotService -resourcegroupname BotTest-rg -name BotTest1 -ApplicationId "af5fce4d-ee68-4b25-be09-f3222582e133" -Location global -Sku F0 -Description "123134" -Registration
```
```output
Etag                                   Kind Location Name     SkuName SkuTier Zone
----                                   ---- -------- ----     ------- ------- ----
"060085fb-0000-1800-0000-5fd71d7c0000" bot  global   BotTest1 F0              {}
```

Create a new Bot by ResourceGroupName and ApplicationId

### Example 2: Create a new Web App
```powershell
New-AzBotService -resourcegroupname BotTest-rg -name BotTest2 -ApplicationId "b1ab1727-0465-4255-a1bb-976210af972c" -Location global -Sku F0 -Description "123134" -Webapp
```
```output
Etag                                   Kind Location Name     SkuName SkuTier Zone
----                                   ---- -------- ----     ------- ------- ----
"06008351-0000-0200-0000-5fd732870000" sdk  global   BotTest2 F0              {}
```

Create a new Web App by ResourceGroupName and ApplicationId
