---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/update-azfrontdoor
schema: 2.0.0
---

# Update-AzFrontDoor

## SYNOPSIS
update a new Front Door with a Front Door name under the specified subscription and resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BackendPool <IBackendPool[]>] [-BackendPoolSettingEnforceCertificateNameCheck <String>]
 [-BackendPoolSettingSendRecvTimeoutSecond <Int32>] [-EnabledState <String>] [-FriendlyName <String>]
 [-FrontendEndpoint <IFrontendEndpoint[]>] [-HealthProbeSetting <IHealthProbeSettingsModel[]>]
 [-LoadBalancingSetting <ILoadBalancingSettingsModel[]>] [-Location <String>] [-RoutingRule <IRoutingRule[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoor -InputObject <IFrontDoorIdentity> [-BackendPool <IBackendPool[]>]
 [-BackendPoolSettingEnforceCertificateNameCheck <String>] [-BackendPoolSettingSendRecvTimeoutSecond <Int32>]
 [-EnabledState <String>] [-FriendlyName <String>] [-FrontendEndpoint <IFrontendEndpoint[]>]
 [-HealthProbeSetting <IHealthProbeSettingsModel[]>] [-LoadBalancingSetting <ILoadBalancingSettingsModel[]>]
 [-Location <String>] [-RoutingRule <IRoutingRule[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a new Front Door with a Front Door name under the specified subscription and resource group.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
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

### -BackendPool
Backend pools available to routing rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IBackendPool[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendPoolSettingEnforceCertificateNameCheck
Whether to enforce certificate name check on HTTPS requests to all backend pools.
No effect on non-HTTPS requests.

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

### -BackendPoolSettingSendRecvTimeoutSecond
Send and receive timeout on forwarding request to the backend.
When timeout is reached, the request fails and returns.

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

### -EnabledState
Operational status of the Front Door load balancer.
Permitted values are 'Enabled' or 'Disabled'

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

### -FriendlyName
A friendly name for the frontDoor

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

### -FrontendEndpoint
Frontend endpoints available to routing rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint[]
Parameter Sets: (All)
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LoadBalancingSetting
Load balancing settings associated with this Front Door instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ILoadBalancingSettingsModel[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

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

### -Name
Name of the Front Door which is globally unique.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoor

## NOTES

## RELATED LINKS

