---
external help file:
Module Name: Az.SoftwarePlanRp
online version: https://docs.microsoft.com/en-us/powershell/module/az.softwareplanrp/get-azsoftwareplanrphybridusebenefit
schema: 2.0.0
---

# Get-AzSoftwarePlanRpHybridUseBenefit

## SYNOPSIS
Gets a given plan ID

## SYNTAX

### List (Default)
```
Get-AzSoftwarePlanRpHybridUseBenefit -Scope <String> [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSoftwarePlanRpHybridUseBenefit -PlanId <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSoftwarePlanRpHybridUseBenefit -InputObject <ISoftwarePlanRpIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a given plan ID

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

### -Filter
Supports applying filter on the type of SKU

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SoftwarePlanRp.Models.ISoftwarePlanRpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PlanId
This is a unique identifier for a plan.
Should be a guid.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope at which the operation is performed.
This is limited to Microsoft.Compute/virtualMachines and Microsoft.Compute/hostGroups/hosts for now

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SoftwarePlanRp.Models.ISoftwarePlanRpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SoftwarePlanRp.Models.Api20191201.IHybridUseBenefitModel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISoftwarePlanRpIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[PlanId <String>]`: This is a unique identifier for a plan. Should be a guid.
  - `[Scope <String>]`: The scope at which the operation is performed. This is limited to Microsoft.Compute/virtualMachines and Microsoft.Compute/hostGroups/hosts for now
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

