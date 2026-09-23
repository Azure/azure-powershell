---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/update-azelasticmonitoredsubscription
schema: 2.0.0
---

# Update-AzElasticMonitoredSubscription

## SYNOPSIS
Update subscriptions to be monitored by the Elastic monitor resource, ensuring optimal observability and performance.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzElasticMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzElasticMonitoredSubscription -InputObject <IElasticIdentity>
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMonitorExpanded
```
Update-AzElasticMonitoredSubscription -ConfigurationName <String> -MonitorInputObject <IElasticIdentity>
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzElasticMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzElasticMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update subscriptions to be monitored by the Elastic monitor resource, ensuring optimal observability and performance.

## EXAMPLES

### Example 1: Enable monitoring for a subscription
```powershell
Update-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Add"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command adds a subscription to the Elastic monitor for monitoring, enabling log and metric collection from the specified subscription.

### Example 2: Disable monitoring for a subscription
```powershell
Update-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Delete"
```

```output
SubscriptionId                        Status     Error TagRules
--------------                        ------     ----- --------
12345678-1234-1234-1234-123456789012 Disabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command removes a subscription from monitoring, disabling log and metric collection from the specified subscription.

### Example 3: Update monitored subscription using pipeline from Get-AzElasticMonitor
```powershell
Get-AzElasticMonitor -ResourceGroupName "myResourceGroup" -Name "myElasticMonitor" | Update-AzElasticMonitoredSubscription -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Add"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command updates monitored subscription configuration by piping an Elastic monitor object from Get-AzElasticMonitor.

### Example 4: Update multiple subscriptions in batch
```powershell
$subscriptions = @("12345678-1234-1234-1234-123456789012", "87654321-4321-4321-4321-210987654321")
foreach ($sub in $subscriptions) {
    Update-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId $sub -Operation "Add"
}
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
87654321-4321-4321-4321-210987654321 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command demonstrates updating monitoring configuration for multiple subscriptions in a batch operation, useful for managing monitoring at scale.

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

### -ConfigurationName
The configuration name.
Only 'default' value is supported.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IMonitoredSubscription[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: UpdateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityMonitorExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS

