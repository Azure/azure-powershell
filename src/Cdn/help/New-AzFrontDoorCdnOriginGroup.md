---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnorigingroup
schema: 2.0.0
---

# New-AzFrontDoorCdnOriginGroup

## SYNOPSIS
Creates a new origin group within the specified profile.

## SYNTAX

```
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSettingProbeIntervalInSecond <Int32>]
 [-HealthProbeSettingProbePath <String>] [-HealthProbeSettingProbeProtocol <ProbeProtocol>]
 [-HealthProbeSettingProbeRequestType <HealthProbeRequestType>]
 [-LoadBalancingSettingAdditionalLatencyInMillisecond <Int32>] [-LoadBalancingSettingSampleSize <Int32>]
 [-LoadBalancingSettingSuccessfulSamplesRequired <Int32>] [-SessionAffinityState <EnabledState>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new origin group within the specified profile.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -HealthProbeSettingProbeIntervalInSecond
The number of seconds between health probes.Default is 240sec.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthProbeSettingProbePath
The path relative to the origin that is used to determine the health of the origin.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthProbeSettingProbeProtocol
Protocol to use for health probe.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProbeProtocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthProbeSettingProbeRequestType
The type of health probe request that is made.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.HealthProbeRequestType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancingSettingAdditionalLatencyInMillisecond
The additional latency in milliseconds for probes to fall into the lowest latency bucket

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancingSettingSampleSize
The number of samples to consider for load balancing decisions

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancingSettingSuccessfulSamplesRequired
The number of samples within the sample period that must succeed

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
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

### -OriginGroupName
Name of the origin group which is unique within the endpoint.

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

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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

### -SessionAffinityState
Whether to allow session affinity on this host.
Valid options are 'Enabled' or 'Disabled'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

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

### -TrafficRestorationTimeToHealedOrNewEndpointsInMinute
Time in minutes to shift the traffic to the endpoint gradually when an unhealthy endpoint comes healthy or a new endpoint is added.
Default is 10 mins.
This property is currently not supported.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdOriginGroup

## NOTES

ALIASES

## RELATED LINKS

