---
external help file:
Module Name: Az.HealthBot
online version: https://docs.microsoft.com/powershell/module/az.healthbot/update-azhealthbot
schema: 2.0.0
---

# Update-AzHealthBot

## SYNOPSIS
Patch a HealthBot.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHealthBot -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Sku <SkuName>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHealthBot -InputObject <IHealthBotIdentity> [-Sku <SkuName>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch a HealthBot.

## EXAMPLES

### Example 1: update HealthBot by Resourcegroupname and Name
```powershell
PS C:\> update-AzHealthBot -ResourceGroupName youriTest -Name yourihealthbot -Sku S1

Location Name           SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
-------- ----           ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----
eastus   yourihealthbot 2020/12/29 8:19:10  test@microsoft.com User                    2020/12/30 6:12:33       test@microsoft.com    User                         Microsoft.HealthBot/health…
```

update HealthBot by Resourcegroupname and Name

### Example 2: update HealthBot by InputObject
```powershell
PS C:\> $getHealth = Get-AzHealthBot -ResourceGroupName youriTest -Name yourihealthbot
Update-AzHealthBot -InputObject $getHealth -Sku F0

Location Name           SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
-------- ----           ------------------- -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----
eastus   yourihealthbot 2020/12/29 8:19:10  test@microsoft.com User                    2020/12/30 6:12:33       test@microsoft.com    User                         Microsoft.HealthBot/health…
```

update HealthBot by InputObject

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.IHealthBotIdentity
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The name of the HealthBot SKU

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags for a HealthBot.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.IHealthBotIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IHealthBotIdentity>: Identity Parameter
  - `[BotName <String>]`: The name of the Bot resource.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the Bot resource group in the user subscription.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

