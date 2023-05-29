---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azcdnorigingroup
schema: 2.0.0
---

# New-AzCdnOriginGroup

## SYNOPSIS
Creates a new origin group within the specified endpoint.

## SYNTAX

```
New-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>] [-Origin <IResourceReference[]>]
 [-ResponseBasedOriginErrorDetectionSetting <IResponseBasedOriginErrorDetectionParameters>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new origin group within the specified endpoint.

## EXAMPLES

### Example 1: Create an AzureCDN origin group under the AzureCDN endpoint
```powershell
$healthProbeParameters = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath "/check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
$origin = Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1
New-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001 -HealthProbeSetting $healthProbeParameters -Origin @(@{ Id = $origin.Id })
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Create an AzureCDN origin group under the AzureCDN endpoint

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

### -EndpointName
Name of the endpoint under the profile which is unique globally.

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

### -HealthProbeSetting
Health probe settings to the origin that is used to determine the health of the origin.
To construct, see NOTES section for HEALTHPROBESETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IHealthProbeParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the origin group which is unique within the endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OriginGroupName

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

### -Origin
The source of the content being delivered via CDN within given origin group.
To construct, see NOTES section for ORIGIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the CDN profile which is unique within the resource group.

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

### -ResponseBasedOriginErrorDetectionSetting
The JSON object that contains the properties to determine origin health using real requests/responses.
This property is currently not supported.
To construct, see NOTES section for RESPONSEBASEDORIGINERRORDETECTIONSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IResponseBasedOriginErrorDetectionParameters
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IOriginGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`HEALTHPROBESETTING <IHealthProbeParameters>`: Health probe settings to the origin that is used to determine the health of the origin.
  - `[ProbeIntervalInSecond <Int32?>]`: The number of seconds between health probes.Default is 240sec.
  - `[ProbePath <String>]`: The path relative to the origin that is used to determine the health of the origin.
  - `[ProbeProtocol <ProbeProtocol?>]`: Protocol to use for health probe.
  - `[ProbeRequestType <HealthProbeRequestType?>]`: The type of health probe request that is made.

`ORIGIN <IResourceReference[]>`: The source of the content being delivered via CDN within given origin group.
  - `[Id <String>]`: Resource ID.

`RESPONSEBASEDORIGINERRORDETECTIONSETTING <IResponseBasedOriginErrorDetectionParameters>`: The JSON object that contains the properties to determine origin health using real requests/responses. This property is currently not supported.
  - `[HttpErrorRange <IHttpErrorRangeParameters[]>]`: The list of Http status code ranges that are considered as server errors for origin and it is marked as unhealthy.
    - `[Begin <Int32?>]`: The inclusive start of the http status code range.
    - `[End <Int32?>]`: The inclusive end of the http status code range.
  - `[ResponseBasedDetectedErrorType <ResponseBasedDetectedErrorTypes?>]`: Type of response errors for real user requests for which origin will be deemed unhealthy
  - `[ResponseBasedFailoverThresholdPercentage <Int32?>]`: The percentage of failed requests in the sample where failover should trigger.

## RELATED LINKS

