---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/set-azafdorigingroup 
schema: 2.0.0
---

# Set-AzAfdOriginGroup

## SYNOPSIS
Updates an AFD origin group.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Set-AzAfdOriginGroup [-AdditionalLatencyInMilliseconds <Int32>] -OriginGroupName <String>
 [-ProbeIntervalInSeconds <Int32>] [-ProbePath <String>] [-ProbeProtocol <String>] [-ProbeRequestType <String>]
 -ProfileName <String> -ResourceGroupName <String> [-SampleSize <Int32>] [-SuccessfulSamplesRequired <Int32>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinutes <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Set-AzAfdOriginGroup -OriginGroup <PSAfdOriginGroup> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Set-AzAfdOriginGroup command updates an AFD origin group.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-AzAfdOriginGroup -ResourceGroupName $resourceGroupName -ProfileName $profileName -OriginGroupName $originGroupName -ProbeProtocol "Https" -ProbePath "/health.aspx"
```

Set-AzAfdOriginGroup command updates an AFD origin group.

## PARAMETERS

### -AdditionalLatencyInMilliseconds
The additional latency in milliseconds for probes to fall into the lowest latency bucket.

```yaml
Type: System.Int32
Parameter Sets: ByFieldsParameterSet
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginGroup
The Azure Front Door origin group object.

```yaml
Type: Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdOriginGroup
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OriginGroupName
The Azure Front Door origin group name.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeIntervalInSeconds
The number of seconds between health probes.

```yaml
Type: System.Int32
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbePath
The path relative to the origin that is used to determine the health of the origin.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeProtocol
Protocol to use for health probe.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeRequestType
The type of health probe request that is made.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
The Azure Front Door profile name.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Azure resource group name.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SampleSize
The number of samples to consider for load balancing decisions.

```yaml
Type: System.Int32
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuccessfulSamplesRequired
The number of samples within the sample period that must succeed.

```yaml
Type: System.Int32
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficRestorationTimeToHealedOrNewEndpointsInMinutes
Time in minutes to shift the traffic to the endpoint gradually when an unhealthy endpoint comes healthy or a new endpoint is added.

```yaml
Type: System.Int32
Parameter Sets: ByFieldsParameterSet
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

### Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdOriginGroup

## OUTPUTS

### Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdOriginGroup

## NOTES

## RELATED LINKS
