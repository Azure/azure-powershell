---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# New-AzEventHubThrottlingPolicyConfig

## SYNOPSIS
Creates an in memory object of type PSEventHubThrottlingPolicyConfigAttributes

## SYNTAX

```
New-AzEventHubThrottlingPolicyConfig [[-Name] <String>] [-MetricId] <String> [-RateLimitThreshold] <Int64>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates an in memory object of type PSEventHubThrottlingPolicyConfigAttributes  that can be given as inputs to 
New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup. This cmdlet DOES NOT make any REST call.

## EXAMPLES

### Example 1
```powershell
$policy1 = New-AzEventHubThrottlingPolicyConfig -Name policy1 -MetricId IncomingBytes -RateLimitThreshold 12345

$policy2 = New-AzEventHubThrottlingPolicyConfig -Name policy2 -MetricId IncomingMessages -RateLimitThreshold 12345

New-AzEventHubApplicationGroup -ResourceGroupName myresourcegroup -NamespaceName mynamespace -ClientAppGroupIdentifier SASKeyName=myauthkey ` 
-ThrottlingPolicy $policy1, $policy2
```

$policy1 and $policy2 are objects of type PSEventHubApplicationGroupAttributes. The objects can then be fed as input to
-ThrottlingPolicy parameter of cmdlets New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricId
Metric Id on which the throttle limit should be set, MetricId can be discovered by hovering over Metric in the Metrics section of Event Hub Namespace inside Azure Portal

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: IncomingBytes, IncomingMessages, OutgoingBytes, OutgoingMessages

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Throttling Policy

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RateLimitThreshold
The Threshold limit above which the application group will be throttled.Rate limit is always per second.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSEventHubThrottlingPolicyConfigAttributes

## NOTES

## RELATED LINKS
