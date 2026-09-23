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

Updates the monitor's billing plan directly by specifying each field. Returns True on success.

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

Passes plan properties as a JSON string. Useful for scripting scenarios where you materialize JSON externally.

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

