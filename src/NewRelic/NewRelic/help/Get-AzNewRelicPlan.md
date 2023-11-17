---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicplan
schema: 2.0.0
---

# Get-AzNewRelicPlan

## SYNOPSIS
List plans data

## SYNTAX

```
Get-AzNewRelicPlan [-SubscriptionId <String[]>] [-AccountId <String>] [-OrganizationId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List plans data

## EXAMPLES

### Example 1: List plans data associated with specified organization
```powershell
Get-AzNewRelicPlan -SubscriptionId 272c26cb-7026-4b37-b190-7cb7b2abecb0 -OrganizationId 9c5445c7-65e3-4bd5-8581-80c65584100f
```

```output
PlanDataUsageType PlanDataBillingCycle PlanDataPlanDetail                                                                      PlanDataEffectiveDate OrgCreationSource AccountCreationSource
----------------- -------------------- ------------------                                                                      --------------------- ----------------- ---------------------
PAYG              MONTHLY              newrelicpaygtestplan2@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg 6/28/2023 9:28:22 AM  LIFTR
```

List plans data associated with specified Organization Id

### Example 2: Link plans account with specified organization in different subscription
```powershell
Get-AzNewRelicPlan -SubscriptionId 272c26cb-7026-4b37-b190-7cb7b2abecb0 -OrganizationId 9c5445c7-65e3-4bd5-8581-80c65584100f -AccountId 3996563
```

Link plans account with specified organization in different subscription

## PARAMETERS

### -AccountId
Account Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -OrganizationId
Organization Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.IPlanDataResource

## NOTES

ALIASES

## RELATED LINKS

