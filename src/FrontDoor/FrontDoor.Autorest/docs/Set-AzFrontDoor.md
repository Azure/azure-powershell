---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/set-azfrontdoor
schema: 2.0.0
---

# Set-AzFrontDoor

## SYNOPSIS
Update a new Front Door with a Front Door name under the specified subscription and resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzFrontDoor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BackendPool <IBackendPool[]>] [-BackendPoolsSetting <IBackendPoolsSettings>] [-EnabledState <String>]
 [-FriendlyName <String>] [-FrontendEndpoint <IFrontendEndpoint[]>]
 [-HealthProbeSetting <IHealthProbeSettingsModel[]>] [-LoadBalancingSetting <ILoadBalancingSettingsModel[]>]
 [-RoutingRule <IRoutingRule[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Set-AzFrontDoor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BackendPool <IBackendPool[]>] [-EnabledState <String>] [-FrontendEndpoint <IFrontendEndpoint[]>]
 [-HealthProbeSetting <IHealthProbeSettingsModel[]>] [-LoadBalancingSetting <ILoadBalancingSettingsModel[]>]
 [-RoutingRule <IRoutingRule[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ByResourceIdWithBackendPoolsSettingParameterSet
```
Set-AzFrontDoor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BackendPool <IBackendPool[]>] [-BackendPoolsSetting <IBackendPoolsSettings>] [-EnabledState <String>]
 [-FrontendEndpoint <IFrontendEndpoint[]>] [-HealthProbeSetting <IHealthProbeSettingsModel[]>]
 [-LoadBalancingSetting <ILoadBalancingSettingsModel[]>] [-RoutingRule <IRoutingRule[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByResourceIdWithCertificateNameCheckParameterSet
```
Set-AzFrontDoor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BackendPool <IBackendPool[]>] [-DisableCertificateNameCheck] [-EnabledState <String>]
 [-FrontendEndpoint <IFrontendEndpoint[]>] [-HealthProbeSetting <IHealthProbeSettingsModel[]>]
 [-LoadBalancingSetting <ILoadBalancingSettingsModel[]>] [-RoutingRule <IRoutingRule[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Set-AzFrontDoor -Name <String> -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Set-AzFrontDoor -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a new Front Door with a Front Door name under the specified subscription and resource group.

## EXAMPLES

### Example 1: update an existing Front Door with FrontDoorName and ResourceGroupName.
```powershell
Set-AzFrontDoor -Name "frontDoor1" -ResourceGroupName "resourceGroup1" -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
```

```output
BackendPool          : {backendpool1}
BackendPoolsSetting  : {backendPoolsSetting1}
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {frontendEndpoint1}
HealthProbeSetting   : {HealthProbeSetting1}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting1}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

update an existing FrontDoor.

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

### -BackendPool
Backend pools available to routing rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool[]
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendPoolsSetting
Settings for all backendPools

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPoolsSettings
Parameter Sets: ByResourceIdWithBackendPoolsSettingParameterSet, UpdateExpanded
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

### -DisableCertificateNameCheck


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ByResourceIdWithCertificateNameCheckParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnabledState
Operational status of the Front Door load balancer.
Permitted values are 'Enabled' or 'Disabled'

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
A friendly name for the frontDoor

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendEndpoint
Frontend endpoints available to routing rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint[]
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthProbeSetting
Health probe settings associated with this Front Door instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHealthProbeSettingsModel[]
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancingSetting
Load balancing settings associated with this Front Door instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel[]
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Front Door which is globally unique.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FrontDoorName

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

### -RoutingRule
Routing rules associated with this Front Door.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRoutingRule[]
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ByResourceIdParameterSet, ByResourceIdWithBackendPoolsSettingParameterSet, ByResourceIdWithCertificateNameCheckParameterSet, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoor

## NOTES

## RELATED LINKS

