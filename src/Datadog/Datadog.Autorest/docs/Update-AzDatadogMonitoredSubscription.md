---
external help file:
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/update-azdatadogmonitoredsubscription
schema: 2.0.0
---

# Update-AzDatadogMonitoredSubscription

## SYNOPSIS
Update the subscriptions that are being monitored by the Datadog monitor resource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDatadogMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>]
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDatadogMonitoredSubscription -InputObject <IDatadogIdentity>
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityMonitorExpanded
```
Update-AzDatadogMonitoredSubscription -ConfigurationName <String> -MonitorInputObject <IDatadogIdentity>
 [-MonitoredSubscriptionList <IMonitoredSubscription[]>] [-Operation <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDatadogMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDatadogMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the subscriptions that are being monitored by the Datadog monitor resource

## EXAMPLES

### Example 1: Enable monitoring for a subscription
```powershell
Update-AzDatadogMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myDatadogMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Add"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20250611.MonitoringTagRules
```

This command adds a subscription to the Datadog monitor for monitoring, enabling log and metric collection from the specified subscription.

### Example 2: Disable monitoring for a subscription
```powershell
Update-AzDatadogMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myDatadogMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Delete"
```

```output
SubscriptionId                        Status     Error TagRules
--------------                        ------     ----- --------
12345678-1234-1234-1234-123456789012 Disabled         Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20250611.MonitoringTagRules
```

This command removes a subscription from the Datadog monitor, disabling log and metric collection from the specified subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoredSubscription[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS

