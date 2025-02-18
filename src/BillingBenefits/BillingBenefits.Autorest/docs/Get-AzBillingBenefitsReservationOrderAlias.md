---
external help file:
Module Name: Az.BillingBenefits
online version: https://learn.microsoft.com/powershell/module/az.billingbenefits/get-azbillingbenefitsreservationorderalias
schema: 2.0.0
---

# Get-AzBillingBenefitsReservationOrderAlias

## SYNOPSIS
Get a reservation order alias.

## SYNTAX

### Get (Default)
```
Get-AzBillingBenefitsReservationOrderAlias -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingBenefitsReservationOrderAlias -InputObject <IBillingBenefitsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a reservation order alias.

## EXAMPLES

### Example 1: Get a reservation order alias.
```powershell
Get-AzBillingBenefitsReservationOrderAlias -Name "PSRITest2"
```

```output
Name      DisplayName SkuName       Location Term BillingPlan ReservedResourceType ReservationOrderId
----      ----------- -------       -------- ---- ----------- -------------------- ------------------
PSRITest2 PSRITest2   Standard_B1ls westus   P1Y  P1M         VirtualMachines      /providers/Microsoft.Capacity/reservationOrders/8d5aacd0-f098-4202-8d4d-1e7cb8a3ac…
```

Get a reservation order alias.

### Example 2: Get a reservation order alias via identity.
```powershell
$identity = @{
                        ReservationOrderAliasName = "PSRITest2"
}

$response = Get-AzBillingBenefitsReservationOrderAlias -InputObject $identity
```

```output
Name      DisplayName SkuName       Location Term BillingPlan ReservedResourceType ReservationOrderId
----      ----------- -------       -------- ---- ----------- -------------------- ------------------
PSRITest2 PSRITest2   Standard_B1ls westus   P1Y  P1M         VirtualMachines      /providers/Microsoft.Capacity/reservationOrders/8d5aacd0-f098-4202-8d4d-1e7cb8a3ac…
```

Get a reservation order alias via identity.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.IBillingBenefitsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the reservation order alias

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ReservationOrderAliasName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.IBillingBenefitsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.Api20221101.IReservationOrderAliasResponse

## NOTES

## RELATED LINKS

