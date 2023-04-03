---
external help file:
Module Name: Az.BillingBenefitsRp
online version: https://learn.microsoft.com/powershell/module/az.billingbenefitsrp/get-azbillingbenefitsrpsavingsplanorderalias
schema: 2.0.0
---

# Get-AzBillingBenefitsRpSavingsPlanOrderAlias

## SYNOPSIS
Get a savings plan.

## SYNTAX

### Get (Default)
```
Get-AzBillingBenefitsRpSavingsPlanOrderAlias -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingBenefitsRpSavingsPlanOrderAlias -InputObject <IBillingBenefitsRpIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a savings plan.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.IBillingBenefitsRpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the savings plan order alias

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SavingsPlanOrderAliasName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.IBillingBenefitsRpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefitsRp.Models.Api20221101.ISavingsPlanOrderAliasModel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IBillingBenefitsRpIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationOrderAliasName <String>]`: Name of the reservation order alias
  - `[SavingsPlanId <String>]`: ID of the savings plan
  - `[SavingsPlanOrderAliasName <String>]`: Name of the savings plan order alias
  - `[SavingsPlanOrderId <String>]`: Order ID of the savings plan

## RELATED LINKS

