---
external help file:
Module Name: Az.PowerBiDedicated
online version: https://docs.microsoft.com/en-us/powershell/module/az.powerbidedicated/test-azpowerbidedicatedcapacitynameavailability
schema: 2.0.0
---

# Test-AzPowerBiDedicatedCapacityNameAvailability

## SYNOPSIS
Check the name availability in the target location.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzPowerBiDedicatedCapacityNameAvailability -Location <String> [-SubscriptionId <String>] [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzPowerBiDedicatedCapacityNameAvailability -Location <String>
 -CapacityParameter <ICheckCapacityNameAvailabilityParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzPowerBiDedicatedCapacityNameAvailability -InputObject <IPowerBiDedicatedIdentity>
 -CapacityParameter <ICheckCapacityNameAvailabilityParameters> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzPowerBiDedicatedCapacityNameAvailability -InputObject <IPowerBiDedicatedIdentity> [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the name availability in the target location.

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

### -CapacityParameter
Details of capacity name request body.
To construct, see NOTES section for CAPACITYPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.Api202101.ICheckCapacityNameAvailabilityParameters
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.IPowerBiDedicatedIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The region name which the operation will lookup into.

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

### -Name
Name for checking availability.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
A unique identifier for a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
The resource type of PowerBI dedicated.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.Api202101.ICheckCapacityNameAvailabilityParameters

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.IPowerBiDedicatedIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiDedicated.Models.Api202101.ICheckCapacityNameAvailabilityResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CAPACITYPARAMETER <ICheckCapacityNameAvailabilityParameters>: Details of capacity name request body.
  - `[Name <String>]`: Name for checking availability.
  - `[Type <String>]`: The resource type of PowerBI dedicated.

INPUTOBJECT <IPowerBiDedicatedIdentity>: Identity Parameter
  - `[DedicatedCapacityName <String>]`: The name of the dedicated capacity. It must be a minimum of 3 characters, and a maximum of 63.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The region name which the operation will lookup into.
  - `[ResourceGroupName <String>]`: The name of the Azure Resource group of which a given PowerBIDedicated capacity is part. This name must be at least 1 character in length, and no more than 90.
  - `[SubscriptionId <String>]`: A unique identifier for a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VcoreName <String>]`: The name of the auto scale v-core. It must be a minimum of 3 characters, and a maximum of 63.

## RELATED LINKS

