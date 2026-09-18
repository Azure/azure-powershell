---
external help file: Az.Elastic-help.xml
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticmonitoredsubscription
schema: 2.0.0
---

# Get-AzElasticMonitoredSubscription

## SYNOPSIS
Get detailed information about all subscriptions currently being monitored by the Elastic monitor resource.

## SYNTAX

### List (Default)
```
Get-AzElasticMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityMonitor
```
Get-AzElasticMonitoredSubscription -ConfigurationName <String> -MonitorInputObject <IElasticIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzElasticMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzElasticMonitoredSubscription -InputObject <IElasticIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get detailed information about all subscriptions currently being monitored by the Elastic monitor resource.

## EXAMPLES

### Example 1: List all monitored subscriptions for an Elastic monitor
```powershell
Get-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
87654321-4321-4321-4321-210987654321 Disabled        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command lists all subscriptions that are being monitored by the specified Elastic monitor.

### Example 2: Get a specific monitored subscription by subscription ID
```powershell
Get-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -ConfigurationName "12345678-1234-1234-1234-123456789012"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command gets the monitoring status for a specific subscription within the Elastic monitor.

### Example 3: Get monitored subscription using pipeline from Get-AzElasticMonitor
```powershell
Get-AzElasticMonitor -ResourceGroupName "myResourceGroup" -Name "myElasticMonitor" | Get-AzElasticMonitoredSubscription
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
87654321-4321-4321-4321-210987654321 Disabled        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command gets all monitored subscriptions by piping an Elastic monitor object from Get-AzElasticMonitor.

## PARAMETERS

### -ConfigurationName
The configuration name.
Only 'default' value is supported.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityMonitor, Get
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: GetViaIdentityMonitor
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
Parameter Sets: List, Get
Aliases:

Required: True
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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS
