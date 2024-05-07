---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdnorigingroup
schema: 2.0.0
---

# Update-AzFrontDoorCdnOriginGroup

## SYNOPSIS
Updates an existing origin group within a profile.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorCdnOriginGroup -OriginGroupName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <EnabledState>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorCdnOriginGroup -InputObject <ICdnIdentity> [-HealthProbeSetting <IHealthProbeParameters>]
 [-LoadBalancingSetting <ILoadBalancingSettingsParameters>] [-SessionAffinityState <EnabledState>]
 [-TrafficRestorationTimeToHealedOrNewEndpointsInMinute <Int32>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing origin group within a profile.

## EXAMPLES

### Example 1: Update an AzureFrontDoor origin group under the profile
```powershell
$updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 3
Update-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -LoadBalancingSetting $updateLoadBalancingSetting
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Update an AzureFrontDoor origin group under the profile

### Example 2: Update an AzureFrontDoor origin group under the profile via identity
```powershell
$updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 3
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 | Update-AzFrontDoorCdnOriginGroup -LoadBalancingSetting $updateLoadBalancingSetting
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Update an AzureFrontDoor origin group under the profile via identity

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

### -HealthProbeSetting
Health probe settings to the origin that is used to determine the health of the origin.
To construct, see NOTES section for HEALTHPROBESETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IHealthProbeParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LoadBalancingSetting
Load balancing settings for a backend pool
To construct, see NOTES section for LOADBALANCINGSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.ILoadBalancingSettingsParameters
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
Name of the origin group which is unique within the profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IAfdOriginGroup

## NOTES

## RELATED LINKS

