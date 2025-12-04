---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/get-azdatadogmonitoredsubscription
schema: 2.0.0
---

# Get-AzDatadogMonitoredSubscription

## SYNOPSIS
List the subscriptions currently being monitored by the Datadog monitor resource.

## SYNTAX

### List (Default)
```
Get-AzDatadogMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityMonitor
```
Get-AzDatadogMonitoredSubscription -ConfigurationName <String> -MonitorInputObject <IDatadogIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDatadogMonitoredSubscription -ConfigurationName <String> -MonitorName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDatadogMonitoredSubscription -InputObject <IDatadogIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List the subscriptions currently being monitored by the Datadog monitor resource.

## EXAMPLES

### Example 1: Get monitored subscriptions for a Datadog monitor
```powershell
Get-AzDatadogMonitoredSubscription -ResourceGroupName datadog-rg -MonitorName monitordd01
```

```output
Id                           : /subscriptions/YYYYYYYY-ZZZZ-AAAA-BBBB-000011112222/resourceGroups/datadog-rg/providers/Microsoft.Datadog/monitors/monitordd01/monitoredSubscriptions/default
MonitoredSubscriptionList    : {{
                                 "tagRules": {
                                   "provisioningState": "Accepted"
                                 },
                                 "subscriptionId": "/SUBSCRIPTIONS/AAAAAAAA-BBBB-CCCC-DDDD-DBDD3AB55AC5",
                                 "status": "Active"
                               }}
Name                         : default
Operation                    :
ResourceGroupName            : datadog-rg
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Datadog/monitors/monitoredSubscriptions
```

Lists the subscriptions currently being monitored by the specified Datadog monitor resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS
