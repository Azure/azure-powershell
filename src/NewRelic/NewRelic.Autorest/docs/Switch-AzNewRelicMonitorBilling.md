---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/switch-aznewrelicmonitorbilling
schema: 2.0.0
---

# Switch-AzNewRelicMonitorBilling

## SYNOPSIS
Switches the billing for NewRelic monitor resource.

## SYNTAX

### SwitchExpanded (Default)
```
Switch-AzNewRelicMonitorBilling -MonitorName <String> -ResourceGroupName <String> -UserEmail <String>
 [-SubscriptionId <String>] [-AzureResourceId <String>] [-OrganizationId <String>]
 [-PlanDataBillingCycle <BillingCycle>] [-PlanDataEffectiveDate <DateTime>] [-PlanDataPlanDetail <String>]
 [-PlanDataUsageType <UsageType>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SwitchViaIdentityExpanded
```
Switch-AzNewRelicMonitorBilling -InputObject <INewRelicIdentity> -UserEmail <String>
 [-AzureResourceId <String>] [-OrganizationId <String>] [-PlanDataBillingCycle <BillingCycle>]
 [-PlanDataEffectiveDate <DateTime>] [-PlanDataPlanDetail <String>] [-PlanDataUsageType <UsageType>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Switches the billing for NewRelic monitor resource.

## EXAMPLES

### Example 1: Switches the billing for NewRelic monitor resource.
```powershell
Switch-AzNewRelicMonitorBilling -MonitorName test-03 -ResourceGroupName ps-test -UserEmail v-jiaji@microsoft.com -PlanDataBillingCycle 'WEEKLY'
```

Switches the billing for NewRelic monitor resource.

## PARAMETERS

### -AzureResourceId
Azure resource Id

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: SwitchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Name of the Monitors resource

```yaml
Type: System.String
Parameter Sets: SwitchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationId
Organization id

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDataBillingCycle
Different billing cycles like MONTHLY/WEEKLY.
this could be enum

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Support.BillingCycle
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDataEffectiveDate
date when plan was applied

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDataPlanDetail
plan id as published by NewRelic

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

### -PlanDataUsageType
Different usage type like PAYG/COMMITTED.
this could be enum

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Support.UsageType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SwitchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SwitchExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEmail
User Email

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.INewRelicMonitorResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <INewRelicIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Name of the Monitors resource
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleSetName <String>]`: Name of the TagRule
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

