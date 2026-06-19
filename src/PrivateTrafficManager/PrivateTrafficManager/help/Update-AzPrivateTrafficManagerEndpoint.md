---
external help file: Az.PrivateTrafficManager-help.xml
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/update-azprivatetrafficmanagerendpoint
schema: 2.0.0
---

# Update-AzPrivateTrafficManagerEndpoint

## SYNOPSIS
Update a Private Traffic Manager endpoint.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPrivateTrafficManagerEndpoint -Name <String> -PrivateTrafficManagerProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AlwaysServe <String>] [-EndpointStatus <String>]
 [-HealthPolicyId <String>] [-MonitoringTarget <String>] [-Priority <Int64>] [-Target <String>]
 [-Weight <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzPrivateTrafficManagerEndpoint -Name <String> -PrivateTrafficManagerProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzPrivateTrafficManagerEndpoint -Name <String> -PrivateTrafficManagerProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityPrivateTrafficManagerProfileExpanded
```
Update-AzPrivateTrafficManagerEndpoint -Name <String>
 -PrivateTrafficManagerProfileInputObject <IPrivateTrafficManagerIdentity> [-AlwaysServe <String>]
 [-EndpointStatus <String>] [-HealthPolicyId <String>] [-MonitoringTarget <String>] [-Priority <Int64>]
 [-Target <String>] [-Weight <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPrivateTrafficManagerEndpoint -InputObject <IPrivateTrafficManagerIdentity> [-AlwaysServe <String>]
 [-EndpointStatus <String>] [-HealthPolicyId <String>] [-MonitoringTarget <String>] [-Priority <Int64>]
 [-Target <String>] [-Weight <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a Private Traffic Manager endpoint.

## EXAMPLES

### Example 1: Update the weight of an endpoint
```powershell
Update-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-primary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Weight 80
```

```output
Name                  Target                     EndpointStatus Weight Priority ProvisioningState
----                  ------                     -------------- ------ -------- -----------------
web-endpoint-primary  primary.contoso.internal.  Enabled        80     1        Succeeded
```

This command updates the weight of the specified endpoint to 80.

### Example 2: Disable an endpoint
```powershell
Update-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-secondary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -EndpointStatus "Disabled"
```

```output
Name                    Target       EndpointStatus Weight Priority ProvisioningState
----                    ------       -------------- ------ -------- -----------------
web-endpoint-secondary  10.10.10.25  Disabled       40              Succeeded
```

This command disables the specified endpoint so it no longer receives traffic.

## PARAMETERS

### -AlwaysServe
Indicates whether endpoint is Always Serve or not.
Always Serve endpoints are always considered to be healthy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -EndpointStatus
The status of the endpoint.
If the endpoint is Enabled, it is probed for endpoint health and is included in the traffic routing method.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthPolicyId
The health policy associated with this endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -MonitoringTarget
Monitoring target is where Private Traffic Manager will gather health information.If MonitoringTarget is not configured EndpointTarget will be used instead.
If the EndpointTarget is IPv6 then the Monitoring Target MUST be configured.
Monitoring Target cannot be an IPv6 address.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Private Traffic Manager endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityPrivateTrafficManagerProfileExpanded
Aliases: EndpointName

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

### -Priority
The priority of this endpoint when using the 'Priority' traffic routing method.
Possible values are from 1 to 1000, lower values represent higher priority.
This is an optional parameter.
If specified, it must be specified on all endpoints, and no two endpoints can share the same priority value.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateTrafficManagerProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: UpdateViaIdentityPrivateTrafficManagerProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateTrafficManagerProfileName
The name of the Private Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
The fully-qualified DNS name or IP address of the endpoint.
Traffic Manager returns this value in DNS responses to direct traffic to this endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Weight
The weight of this endpoint when using the 'Weighted' traffic routing method.
Possible values are from 1 to 1000.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IEndpoint

## NOTES

## RELATED LINKS
