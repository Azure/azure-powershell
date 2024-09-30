---
external help file:
Module Name: Az.BotService
online version: https://learn.microsoft.com/powershell/module/az.botservice/get-azbotservice
schema: 2.0.0
---

# Get-AzBotService

## SYNOPSIS
Returns a BotService specified by the parameters.

## SYNTAX

### List1 (Default)
```
Get-AzBotService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzBotService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBotService -InputObject <IBotServiceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzBotService -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a BotService specified by the parameters.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IBotServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Bot resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BotName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Bot resource group in the user subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IBotServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20220615Preview.IBot

## NOTES

## RELATED LINKS

