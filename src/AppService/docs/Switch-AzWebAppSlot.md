---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/switch-azwebappslot
schema: 2.0.0
---

# Switch-AzWebAppSlot

## SYNOPSIS
Swaps two deployment slots of an app.

## SYNTAX

### Swap1 (Default)
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-SlotSwapEntity <ICsmSlotEntity>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SwapExpanded1
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 -PreserveVnet <Boolean> -TargetSlot <String> [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SwapExpanded
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 [-PassThru] -PreserveVnet <Boolean> -TargetSlot <String> [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Swap
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 [-PassThru] [-SlotSwapEntity <ICsmSlotEntity>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SwapViaIdentityExpanded1
```
Switch-AzWebAppSlot -InputObject <IWebSiteIdentity> [-PassThru] -PreserveVnet <Boolean> -TargetSlot <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SwapViaIdentityExpanded
```
Switch-AzWebAppSlot -InputObject <IWebSiteIdentity> [-PassThru] -PreserveVnet <Boolean> -TargetSlot <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SwapViaIdentity1
```
Switch-AzWebAppSlot -InputObject <IWebSiteIdentity> [-PassThru] [-SlotSwapEntity <ICsmSlotEntity>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SwapViaIdentity
```
Switch-AzWebAppSlot -InputObject <IWebSiteIdentity> [-PassThru] [-SlotSwapEntity <ICsmSlotEntity>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Swaps two deployment slots of an app.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: SwapViaIdentityExpanded1, SwapViaIdentityExpanded, SwapViaIdentity1, SwapViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: Swap1, SwapExpanded1, SwapExpanded, Swap
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreserveVnet
\<code\>true\</code\> to preserve Virtual Network to the slot during swap; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: SwapExpanded1, SwapExpanded, SwapViaIdentityExpanded1, SwapViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Swap1, SwapExpanded1, SwapExpanded, Swap
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Slot
Name of the source slot.
If a slot is not specified, the production slot is used as the source slot.

```yaml
Type: System.String
Parameter Sets: SwapExpanded, Swap
Aliases: SourceSlotName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SlotSwapEntity
Deployment slot parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ICsmSlotEntity
Parameter Sets: Swap1, Swap, SwapViaIdentity1, SwapViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Swap1, SwapExpanded1, SwapExpanded, Swap
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSlot
Destination deployment slot during swap operation.

```yaml
Type: System.String
Parameter Sets: SwapExpanded1, SwapExpanded, SwapViaIdentityExpanded1, SwapViaIdentityExpanded
Aliases: DestinationSlotName

Required: True
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

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/switch-azwebappslot](https://docs.microsoft.com/en-us/powershell/module/az.website/switch-azwebappslot)

