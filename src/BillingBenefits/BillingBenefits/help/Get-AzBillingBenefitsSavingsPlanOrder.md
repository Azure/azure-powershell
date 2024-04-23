---
external help file: Az.BillingBenefits-help.xml
Module Name: Az.BillingBenefits
online version: https://learn.microsoft.com/powershell/module/az.billingbenefits/get-azbillingbenefitssavingsplanorder
schema: 2.0.0
---

# Get-AzBillingBenefitsSavingsPlanOrder

## SYNOPSIS
Get a savings plan order.

## SYNTAX

### List (Default)
```
Get-AzBillingBenefitsSavingsPlanOrder [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzBillingBenefitsSavingsPlanOrder -Id <String> [-Expand <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzBillingBenefitsSavingsPlanOrder -InputObject <IBillingBenefitsIdentity> [-Expand <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a savings plan order.

## EXAMPLES

### Example 1: List savings plan orders
```powershell
Get-AzBillingBenefitsSavingsPlanOrder
```

```output
OrderId                              SkuName              Status    ExpiryDate             Term BillingPlan
-------                              -------              ------    ----------             ---- -----------
23420e73-752b-47e8-96d9-6f9ac2bcee27 Compute_Savings_Plan Succeeded 11/30/2023 11:22:53 PM P1Y  P1M        
953fc18d-04d6-4f8a-9f51-6b784cbc4d2a Compute_Savings_Plan Succeeded 11/30/2025 12:36:25 AM P3Y  P1M        
a05e9e28-0adf-4e73-8e24-87bf51ab6cdc Compute_Savings_Plan Succeeded 11/29/2025 2:51:18 AM  P3Y  P1M        
1a06f5fc-2152-40ec-9675-f890ab680df9 Compute_Savings_Plan Succeeded 11/29/2025 2:48:30 AM  P3Y  P1M
```

List savings plan orders

### Example 2: Get a single savings plan order
```powershell
Get-AzBillingBenefitsSavingsPlanOrder -Id 23420e73-752b-47e8-96d9-6f9ac2bcee27
```

```output
OrderId                              SkuName              Status    ExpiryDate             Term BillingPlan
-------                              -------              ------    ----------             ---- -----------
23420e73-752b-47e8-96d9-6f9ac2bcee27 Compute_Savings_Plan Succeeded 11/30/2023 11:22:53 PM P1Y  P1M
```

Get a single savings plan order

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

### -Expand
May be used to expand the detail information of some properties.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Order ID of the savings plan

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SavingsPlanOrderId

Required: True
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.Api20221101.ISavingsPlanOrderModel

## NOTES

## RELATED LINKS
