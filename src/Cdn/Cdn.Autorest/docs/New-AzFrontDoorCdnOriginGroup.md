---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnorigingroup
schema: 2.0.0
---

# New-AzFrontDoorCdnOriginGroup

## SYNOPSIS
Create a new origin group within the specified profile.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AuthenticationScope <String>] [-AuthenticationType <String>]
 [-HealthProbeSetting <IHealthProbeParameters>] [-LoadBalancingSetting <ILoadBalancingSettingsParameters>]
 [-SessionAffinityState <String>] [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>]
 [-UserAssignedIdentityId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileInputObject <ICdnIdentity>
 -OriginGroup <IAfdOriginGroup> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileInputObject <ICdnIdentity>
 [-AuthenticationScope <String>] [-AuthenticationType <String>] [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <String>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>] [-UserAssignedIdentityId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new origin group within the specified profile.

## EXAMPLES

### Example 1: Create an AzureFrontDoor origin group under the AzureFrontDoor profile
```powershell
$healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" -ProbeProtocol "Https" -ProbeRequestType "GET"
$loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200  -SampleSize 5 -SuccessfulSamplesRequired 4
New-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Create an AzureFrontDoor origin group under the AzureFrontDoor profile

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

### -AuthenticationScope
The scope used when requesting token from Microsoft Entra.
For example, for Azure Blob Storage, scope could be "https://storage.azure.com/.default".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationType
The type of the authentication for the origin.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
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

### -HealthProbeSetting
Health probe settings to the origin that is used to determine the health of the origin.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IHealthProbeParameters
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancingSetting
Load balancing settings for a backend pool

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ILoadBalancingSettingsParameters
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
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

### -OriginGroup
AFDOrigin group comprising of origins is used for load balancing to origins when the content cannot be served from Azure Front Door.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdOriginGroup
Parameter Sets: CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdOriginGroup

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdOriginGroup

## NOTES

## RELATED LINKS

