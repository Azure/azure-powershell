---
external help file:
Module Name: Az.EngagementFabric
online version: https://docs.microsoft.com/en-us/powershell/module/az.engagementfabric/new-azengagementfabricaccountkey
schema: 2.0.0
---

# New-AzEngagementFabricAccountKey

## SYNOPSIS
Regenerate key of the EngagementFabric account

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzEngagementFabricAccountKey -AccountName <String> -ResourceGroupName <String> -Name <String>
 -Rank <KeyRank> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Regenerate
```
New-AzEngagementFabricAccountKey -AccountName <String> -ResourceGroupName <String>
 -Parameter <IRegenerateKeyParameter> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentity
```
New-AzEngagementFabricAccountKey -InputObject <IEngagementFabricIdentity> -Parameter <IRegenerateKeyParameter>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzEngagementFabricAccountKey -InputObject <IEngagementFabricIdentity> -Name <String> -Rank <KeyRank>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Regenerate key of the EngagementFabric account

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
Account Name

```yaml
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.IEngagementFabricIdentity
Parameter Sets: RegenerateViaIdentity, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of key to be regenerated

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameter to regenerate single EngagementFabric account key
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.Api20180901Preview.IRegenerateKeyParameter
Parameter Sets: Regenerate, RegenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Rank
The rank of the key to be regenerated

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Support.KeyRank
Parameter Sets: RegenerateExpanded, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID

```yaml
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.Api20180901Preview.IRegenerateKeyParameter

### Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.IEngagementFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.Api20180901Preview.IKeyDescription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IEngagementFabricIdentity>: Identity Parameter
  - `[AccountName <String>]`: Account Name
  - `[ChannelName <String>]`: Channel Name
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: Resource Group Name
  - `[SubscriptionId <String>]`: Subscription ID

PARAMETER <IRegenerateKeyParameter>: The parameter to regenerate single EngagementFabric account key
  - `Name <String>`: The name of key to be regenerated
  - `Rank <KeyRank>`: The rank of the key to be regenerated

## RELATED LINKS

