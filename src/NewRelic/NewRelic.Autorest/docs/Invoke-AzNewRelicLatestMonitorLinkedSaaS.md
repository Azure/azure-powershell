---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/invoke-aznewreliclatestmonitorlinkedsaas
schema: 2.0.0
---

# Invoke-AzNewRelicLatestMonitorLinkedSaaS

## SYNOPSIS
Returns the latest SaaS linked to the newrelic organization of the underlying monitor.

## SYNTAX

### Latest (Default)
```
Invoke-AzNewRelicLatestMonitorLinkedSaaS -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LatestViaIdentity
```
Invoke-AzNewRelicLatestMonitorLinkedSaaS -InputObject <INewRelicIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns the latest SaaS linked to the newrelic organization of the underlying monitor.

## EXAMPLES

### Example 1: Get latest linked SaaS resource for a NewRelic monitor
```powershell
Invoke-AzNewRelicLatestMonitorLinkedSaaS -MonitorName "test-01" -ResourceGroupName "ps-test"
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/ps-test/providers/NewRelic.Observability/monitors/test-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : test-01-saas
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
OrganizationId           : 987654321
AccountId                : 123456789
CreatedDate              : 6/27/2023 8:30:45 AM
LastModifiedDate         : 6/27/2023 8:30:45 AM
```

Retrieves the latest SaaS resource linked to the specified NewRelic monitor

### Example 2: Get latest linked SaaS resource using pipeline
```powershell
$monitor = Get-AzNewRelicMonitor -Name "test-01" -ResourceGroupName "ps-test"
$monitor | Invoke-AzNewRelicLatestMonitorLinkedSaaS
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/ps-test/providers/NewRelic.Observability/monitors/test-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : test-01-saas
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
OrganizationId           : 987654321
AccountId                : 123456789
CreatedDate              : 6/27/2023 8:30:45 AM
LastModifiedDate         : 6/27/2023 8:30:45 AM
```

Retrieves the latest SaaS resource linked to the NewRelic monitor using pipeline input

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
Parameter Sets: LatestViaIdentity
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
Parameter Sets: Latest
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
Parameter Sets: Latest
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
Parameter Sets: Latest
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ILatestLinkedSaaSResponse

## NOTES

## RELATED LINKS

