---
external help file:
Module Name: Az.MixedReality
online version: https://learn.microsoft.com/powershell/module/az.mixedreality/new-azmixedrealityremoterenderingaccountkey
schema: 2.0.0
---

# New-AzMixedRealityRemoteRenderingAccountKey

## SYNOPSIS
Regenerate specified Key of a Remote Rendering Account

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzMixedRealityRemoteRenderingAccountKey -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Serial <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzMixedRealityRemoteRenderingAccountKey -InputObject <IMixedRealityIdentity> [-Serial <Int32>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Regenerate specified Key of a Remote Rendering Account

## EXAMPLES

### Example 1: Regenerate specified Key of a Remote Rendering Account.
```powershell
New-AzMixedRealityRemoteRenderingAccountKey -AccountName azpstestrenderingaccount -ResourceGroupName azps_test_group -Serial 1
```

```output
PrimaryKey              SecondaryKey
----------              ------------
H9BrXT******8QJ3S/cIzE= VOR11nS******RtYevu5U5fTHM=
```

Regenerate specified Key of a Remote Rendering Account.

## PARAMETERS

### -AccountName
Name of an Mixed Reality Account.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity
Parameter Sets: RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of an Azure resource group.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Serial
.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.IMixedRealityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IAccountKeys

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMixedRealityIdentity>`: Identity Parameter
  - `[AccountName <String>]`: Name of an Mixed Reality Account.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location in which uniqueness will be verified.
  - `[ResourceGroupName <String>]`: Name of an Azure resource group.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)

## RELATED LINKS

