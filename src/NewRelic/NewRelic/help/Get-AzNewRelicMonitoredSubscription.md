---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicmonitoredsubscription
schema: 2.0.0
---

# Get-AzNewRelicMonitoredSubscription

## SYNOPSIS
List the subscriptions currently being monitored by the NewRelic monitor resource.

## SYNTAX

### Get (Default)
```
Get-AzNewRelicMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNewRelicMonitoredSubscription -InputObject <INewRelicIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List the subscriptions currently being monitored by the NewRelic monitor resource.

## EXAMPLES

### Example 1: List the subscriptions monitored by the NewRelic monitor resource
```powershell
Get-AzNewRelicMonitoredSubscription -MonitorName test-01 -ResourceGroupName group-test
```

```output
Id                        : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group-test/providers/NewRelic.Observability/monitors/test-01/monitoredSubscriptions/default
MonitoredSubscriptionList : {}
Name                      : default
PatchOperation            : 
ProvisioningState         : 
ResourceGroupName         : group-test
Type                      : NewRelic.Observability/monitors/monitoredSubscriptions
```

This command lists the subscriptions currently being monitored by the NewRelic monitor resource.

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS
