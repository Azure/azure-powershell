---
external help file: Az.DynatraceObservability-help.xml
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/update-azdynatracemonitorplan
schema: 2.0.0
---

# Update-AzDynatraceMonitorPlan

## SYNOPSIS
Upgrades the billing Plan for Dynatrace monitor resource.

## SYNTAX

### UpgradeExpanded (Default)
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PlanDataBillingCycle <String>] [-PlanDataEffectiveDate <DateTime>] [-PlanDataPlanDetail <String>]
 [-PlanDataUsageType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaJsonString
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaJsonFilePath
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Upgrade
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Request <IUpgradePlanRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Update-AzDynatraceMonitorPlan -InputObject <IDynatraceObservabilityIdentity> [-PlanDataBillingCycle <String>]
 [-PlanDataEffectiveDate <DateTime>] [-PlanDataPlanDetail <String>] [-PlanDataUsageType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpgradeViaIdentity
```
Update-AzDynatraceMonitorPlan -InputObject <IDynatraceObservabilityIdentity> -Request <IUpgradePlanRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Upgrades the billing Plan for Dynatrace monitor resource.

## EXAMPLES

### Example 1: Upgrade the monitor to a PAYG monthly plan
```powershell
Update-AzDynatraceMonitorPlan -ResourceGroupName "rg-dynatrace" -MonitorName "dynatrace-monitor1" `
	-PlanDataPlanDetail "dynatrace-enterprise" -PlanDataUsageType "PAYG" -PlanDataBillingCycle "MONTHLY" `
	-PlanDataEffectiveDate (Get-Date) -PassThru
```

Upgrades the billing plan for the Dynatrace monitor to the specified enterprise plan with a monthly Pay-As-You-Go cycle, returning True on success.

### Example 2: Upgrade using a JSON payload
```powershell
$json = @{ 
	planData = @{ 
		planDetail = "dynatrace-enterprise"; 
		usageType = "PAYG"; 
		billingCycle = "MONTHLY"; 
		effectiveDate = (Get-Date).ToString("o") 
	} 
} | ConvertTo-Json -Depth 4
Update-AzDynatraceMonitorPlan -ResourceGroupName "rg-dynatrace" -MonitorName "dynatrace-monitor1" -JsonString $json -PassThru
```

Performs the same upgrade using a JSON request body, which is convenient for automation scenarios or when the plan details are generated dynamically.

## PARAMETERS

### -AsJob
Run the command as a job

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity
Parameter Sets: UpgradeViaIdentityExpanded, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
different billing cycles like MONTHLY/WEEKLY.
this could be enum

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
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
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDataPlanDetail
plan id as published by Dynatrace

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDataUsageType
different usage type like PAYG/COMMITTED.
this could be enum

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The billing plan properties for the upgrade plan call.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IUpgradePlanRequest
Parameter Sets: Upgrade, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IUpgradePlanRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
