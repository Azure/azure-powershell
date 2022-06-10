---
external help file:
Module Name: Az.EngagementFabric
online version: https://docs.microsoft.com/en-us/powershell/module/az.engagementfabric/test-azengagementfabricnameavailability
schema: 2.0.0
---

# Test-AzEngagementFabricNameAvailability

## SYNOPSIS
Check availability of EngagementFabric resource

## SYNTAX

### CheckExpanded (Default)
```
Test-AzEngagementFabricNameAvailability -ResourceGroupName <String> -Name <String> -Type <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzEngagementFabricNameAvailability -ResourceGroupName <String>
 -Parameter <ICheckNameAvailabilityParameter> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzEngagementFabricNameAvailability -InputObject <IEngagementFabricIdentity>
 -Parameter <ICheckNameAvailabilityParameter> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzEngagementFabricNameAvailability -InputObject <IEngagementFabricIdentity> -Name <String> -Type <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check availability of EngagementFabric resource

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
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name to be checked

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameter for name availability check
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.Api20180901Preview.ICheckNameAvailabilityParameter
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
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
Parameter Sets: Check, CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The fully qualified resource type for the name to be checked

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.Api20180901Preview.ICheckNameAvailabilityParameter

### Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.IEngagementFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EngagementFabric.Models.Api20180901Preview.ICheckNameAvailabilityResult

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

PARAMETER <ICheckNameAvailabilityParameter>: The parameter for name availability check
  - `Name <String>`: The name to be checked
  - `Type <String>`: The fully qualified resource type for the name to be checked

## RELATED LINKS

