---
external help file:
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/new-azdynatracemonitoredsubscription
schema: 2.0.0
---

# New-AzDynatraceMonitoredSubscription

## SYNOPSIS
Add the subscriptions that should be monitored by the Dynatrace monitor resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDynatraceMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDynatraceMonitoredSubscription -MonitorName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDynatraceMonitoredSubscription -MonitorName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Add the subscriptions that should be monitored by the Dynatrace monitor resource.

## EXAMPLES

### Example 1: Begin adding subscription monitoring (AddBegin)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id

# Initiate monitoring relationship (AddBegin)
$subs = @([Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new())
$subs[0].Id = "/subscriptions/$subscriptionId"
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -MonitoredSubscriptionList $subs -Operation AddBegin
```

Starts the monitored subscription onboarding workflow.
Some services require a follow-up AddComplete operation.

### Example 2: Complete add workflow (AddComplete)
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$subs = @([Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new())
$subs[0].Id = "/subscriptions/$subscriptionId"
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -MonitoredSubscriptionList $subs -Operation AddComplete
```

Finalizes the monitoring relationship after an earlier AddBegin.

### Example 3: Create via JSON string
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$json = '{"monitoredSubscriptionList":[{"id":"/subscriptions/' + $subscriptionId + '"}],"operation":"AddBegin"}'
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonString $json
```

Uses JSON payload rather than typed objects—helpful for automation or external template generation.

### Example 4: Create via JSON file path
```powershell
$rg = "myResourceGroup"
$monitor = "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$path = Join-Path $PWD 'monitored-subscription.json'
@{ monitoredSubscriptionList = @(@{ id = "/subscriptions/$subscriptionId" }); operation = 'AddBegin' } | ConvertTo-Json -Depth 5 | Set-Content -Path $path -Encoding UTF8
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonFilePath $path
```

Reads creation parameters from a JSON file on disk.

### Example 5: Pipeline identity usage with expanded parameters
```powershell
$monitorObj = Get-AzDynatraceMonitor -ResourceGroupName "myResourceGroup" -Name "myDynatraceMonitor"
$subscriptionId = (Get-AzContext).Subscription.Id
$subObj = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new(); $subObj.Id = "/subscriptions/$subscriptionId"
($monitorObj | New-AzDynatraceMonitoredSubscription -MonitoredSubscriptionList @($subObj) -Operation AddBegin)
```

Demonstrates identity parameter set by piping the monitor object.

### Example 6: Dry run with -WhatIf
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$subObj = [Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription]::new(); $subObj.Id = "/subscriptions/$subscriptionId"
New-AzDynatraceMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myDynatraceMonitor" -MonitoredSubscriptionList @($subObj) -Operation AddBegin -WhatIf
```

Shows the operation details without persisting changes.

### Example 7: JSON validation then completion
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"; $sid = (Get-AzContext).Subscription.Id
$jsonBegin = '{"monitoredSubscriptionList":[{"id":"/subscriptions/' + $sid + '"}],"operation":"AddBegin"}'
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonString $jsonBegin | Out-Null
$jsonComplete = '{"monitoredSubscriptionList":[{"id":"/subscriptions/' + $sid + '"}],"operation":"AddComplete"}'
New-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor -JsonString $jsonComplete
```

Executes the two-step add workflow entirely via JSON payloads.

### Example 8: Verify monitored subscription list
```powershell
$rg = "myResourceGroup"; $monitor = "myDynatraceMonitor"
Get-AzDynatraceMonitoredSubscription -ResourceGroupName $rg -MonitorName $monitor | Select-Object -First 1 | Format-List Id,Name,Type
```

Retrieves and inspects monitored subscription after creation.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoredSubscriptionList
List of subscriptions and the state of the monitoring.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IMonitoredSubscription[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

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

### -Operation
The operation for the patch on the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS

