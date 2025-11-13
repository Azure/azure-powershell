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

### Example 1: Add subscriptions to monitoring using an object list
```powershell
$subIds = @("11111111-1111-1111-1111-111111111111","22222222-2222-2222-2222-222222222222")
$list = @()
foreach ($id in $subIds) {
	$entry = New-Object Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.MonitoredSubscription
	$entry.SubscriptionId = $id
	$list += $entry
}

New-AzDynatraceMonitoredSubscription -MonitorName "myDynatraceMonitor" -ResourceGroupName "myResourceGroup" -MonitoredSubscriptionList $list -Operation "Add"
```

Constructs an array of MonitoredSubscription objects and adds them to the Dynatrace monitor. Use -Operation "Add" to append monitoring entries.

### Example 2: Add a subscription via JSON payload file
```powershell
$json = @{ 
	monitoredSubscriptionList = @(
		@{ subscriptionId = "33333333-3333-3333-3333-333333333333" }
	);
	operation = "Add" 
} | ConvertTo-Json -Depth 5
$json | Out-File -FilePath .\addSubs.json -Encoding utf8

New-AzDynatraceMonitoredSubscription -MonitorName "myDynatraceMonitor" -ResourceGroupName "myResourceGroup" -JsonFilePath .\addSubs.json
```

Supplies the monitored subscription list and operation through a JSON file, useful for automation scenarios or larger batch updates.

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

