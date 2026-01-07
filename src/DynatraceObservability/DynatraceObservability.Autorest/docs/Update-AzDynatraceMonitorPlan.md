---
external help file:
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
 [-PlanDataUsageType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Upgrade
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> -Request <IUpgradePlanRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeViaIdentity
```
Update-AzDynatraceMonitorPlan -InputObject <IDynatraceObservabilityIdentity> -Request <IUpgradePlanRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Update-AzDynatraceMonitorPlan -InputObject <IDynatraceObservabilityIdentity> [-PlanDataBillingCycle <String>]
 [-PlanDataEffectiveDate <DateTime>] [-PlanDataPlanDetail <String>] [-PlanDataUsageType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaJsonFilePath
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeViaJsonString
```
Update-AzDynatraceMonitorPlan -MonitorName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Upgrades the billing Plan for Dynatrace monitor resource.

## EXAMPLES

### Example 1: Upgrade a monitor plan using expanded parameters
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"

# Move from trial/preview plan to committed monthly plan
$result = Update-AzDynatraceMonitorPlan -ResourceGroupName $rg -MonitorName $monitor `
	-PlanDataUsageType COMMITTED `
	-PlanDataBillingCycle "1-Month" `
	-PlanDataPlanDetail "dynatrace_azure_enterprise@TIDgmz7xq9ge3py" `
	-PlanDataEffectiveDate (Get-Date) -PassThru
```

```output
True
```

Updates the monitor's billing plan directly by specifying each field.
Returns True on success.

### Example 2: Use a request object (Upgrade parameter set)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"

# Construct upgrade request object
$req = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.UpgradePlanRequest]::new()
$req.PlanData = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.PlanData]::new()
$req.PlanData.UsageType = "COMMITTED"
$req.PlanData.BillingCycle = "1-Month"
$req.PlanData.PlanDetails = "dynatrace_azure_enterprise@TIDgmz7xq9ge3py"
$req.PlanData.EffectiveDate = Get-Date

$ok = Update-AzDynatraceMonitorPlan -ResourceGroupName $rg -MonitorName $monitor -Request $req -PassThru
```

```output
True
```

Shows how to supply all plan data via the -Request object instead of individual parameters.

### Example 3: Pipeline identity usage
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"

Get-AzDynatraceMonitor -ResourceGroupName $rg -Name $monitor | \
	Update-AzDynatraceMonitorPlan -PlanDataUsageType COMMITTED -PlanDataBillingCycle "1-Month" -PlanDataPlanDetail "dynatrace_azure_enterprise@TIDgmz7xq9ge3py" -PassThru
```

Performs the upgrade by piping the monitor object (identity) and specifying expanded plan fields.

### Example 4: JSON string input
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$json = '{"planData":{"usageType":"COMMITTED","billingCycle":"1-Month","planDetails":"dynatrace_azure_enterprise@TIDgmz7xq9ge3py","effectiveDate":"' + (Get-Date).ToString("o") + '"}}'
Update-AzDynatraceMonitorPlan -ResourceGroupName $rg -MonitorName $monitor -JsonString $json -PassThru
```

Passes plan properties as a JSON string.
Useful for scripting scenarios where you materialize JSON externally.

### Example 5: JSON file path input
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$jsonPath = Join-Path $PWD 'upgrade-plan.json'
@{ planData = @{ usageType = 'COMMITTED'; billingCycle = '1-Month'; planDetails = 'dynatrace_azure_enterprise@TIDgmz7xq9ge3py'; effectiveDate = (Get-Date) } } | ConvertTo-Json -Depth 5 | Set-Content -Path $jsonPath -Encoding UTF8
Update-AzDynatraceMonitorPlan -ResourceGroupName $rg -MonitorName $monitor -JsonFilePath $jsonPath -PassThru
```

Reads the plan update payload from a JSON file on disk.

### Example 6: Dry run with -WhatIf
```powershell
Update-AzDynatraceMonitorPlan -ResourceGroupName "myResourceGroup" -MonitorName "myDynatraceMonitor" -PlanDataUsageType COMMITTED -PlanDataBillingCycle "1-Month" -PlanDataPlanDetail "dynatrace_azure_enterprise@TIDgmz7xq9ge3py" -WhatIf
```

Shows what would change without performing the actual update.

### Example 7: Verify plan after update
```powershell
Update-AzDynatraceMonitorPlan -ResourceGroupName $rg -MonitorName $monitor -PlanDataUsageType COMMITTED -PlanDataBillingCycle "1-Month" -PlanDataPlanDetail "dynatrace_azure_enterprise@TIDgmz7xq9ge3py" -PassThru | Out-Null
$updated = Get-AzDynatraceMonitor -ResourceGroupName $rg -Name $monitor
$updated.planData | Format-List UsageType,BillingCycle,PlanDetails,EffectiveDate
```

Retrieves the monitor to validate the new plan details after a successful upgrade.

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
Parameter Sets: UpgradeViaIdentity, UpgradeViaIdentityExpanded
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
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
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
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
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
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
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

