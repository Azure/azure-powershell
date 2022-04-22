---
external help file:
Module Name: Az.Dfp
online version: https://docs.microsoft.com/en-us/powershell/module/az.dfp/test-azdfpinstancenameavailability
schema: 2.0.0
---

# Test-AzDfpInstanceNameAvailability

## SYNOPSIS
Check the name availability in the target location.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDfpInstanceNameAvailability -Location <String> [-SubscriptionId <String>] [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzDfpInstanceNameAvailability -Location <String>
 -InstanceParameter <ICheckInstanceNameAvailabilityParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzDfpInstanceNameAvailability -InputObject <IDfpIdentity>
 -InstanceParameter <ICheckInstanceNameAvailabilityParameters> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzDfpInstanceNameAvailability -InputObject <IDfpIdentity> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Dfp.Models.IDfpIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceParameter
Details of DFP instance name request body.
To construct, see NOTES section for INSTANCEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dfp.Models.Api20210201Preview.ICheckInstanceNameAvailabilityParameters
Parameter Sets: Check, CheckViaIdentity
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
The resource type of DFP instance.

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

### Microsoft.Azure.PowerShell.Cmdlets.Dfp.Models.Api20210201Preview.ICheckInstanceNameAvailabilityParameters

### Microsoft.Azure.PowerShell.Cmdlets.Dfp.Models.IDfpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dfp.Models.Api20210201Preview.ICheckInstanceNameAvailabilityResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDfpIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[InstanceName <String>]`: The name of the instance. It must be a minimum of 3 characters, and a maximum of 63.
  - `[Location <String>]`: The region name which the operation will lookup into.
  - `[ResourceGroupName <String>]`: The name of the Azure Resource group of which a given DFP instance is part. This name must be at least 1 character in length, and no more than 90.
  - `[SubscriptionId <String>]`: A unique identifier for a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

INSTANCEPARAMETER <ICheckInstanceNameAvailabilityParameters>: Details of DFP instance name request body.
  - `[Name <String>]`: Name for checking availability.
  - `[Type <String>]`: The resource type of DFP instance.

## RELATED LINKS

