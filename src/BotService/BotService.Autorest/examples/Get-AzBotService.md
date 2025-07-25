### Example 1: List by subscription
```powershell
Get-AzBotService
```

```output
Etag                                   Kind Location Name      SkuName SkuTier Zone
----                                   ---- -------- ----      ------- ------- ----
"4f003041-0000-1800-0000-6281fec80000" bot  global   botTest1  F0              {}
"0d0018e1-0000-1800-0000-6371e9540000" bot  global   botTest2  F0              {}
"05000ef7-0000-0200-0000-5fd7065a0000" sdk  global   botTest3  S1              {}
"0600ef2b-0000-0200-0000-5fd727a70000" sdk  global   botTest4  S1              {}
```

Returns BotService resources belonging to current subscription.

### Example 2: Get by Name and ResourceGroupName
```powershell
Get-AzBotService -Name botTest1 -ResourceGroupName botTest-rg
```

```output
Etag                                   Kind Location Name      SkuName SkuTier Zone
----                                   ---- -------- ----      ------- ------- ----
"4f003041-0000-1800-0000-6281fec80000" bot  global   botTest1  F0              {}
```

Returns a BotService specified by Name and ResourceGroupName.

### Example 3: GetViaIdentity
```powershell
Get-AzBotService -InputObject $botTest1
```

```output
Etag                                   Kind Location Name      SkuName SkuTier Zone
----                                   ---- -------- ----      ------- ------- ----
"4f003041-0000-1800-0000-6281fec80000" bot  global   botTest1  F0              {}
```

Returns a BotService specified by the input IBotServiceIdentity.

### Example 4: List by resource group
```powershell
Get-AzBotService -ResourceGroupName botTest-rg
```

```output
Etag                                   Kind Location Name      SkuName SkuTier Zone
----                                   ---- -------- ----      ------- ------- ----
"4f003041-0000-1800-0000-6281fec80000" bot  global   botTest1  F0              {}
"05000ef7-0000-0200-0000-5fd7065a0000" sdk  global   botTest3  S1              {}
```

Returns all the resources of a particular type belonging to a resource group.
