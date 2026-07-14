---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/update-azmissioncommunity
schema: 2.0.0
---

# Update-AzMissionCommunity

## SYNOPSIS
Update a CommunityResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMissionCommunity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AddressSpace <String[]>] [-CommunityRoleAssignment <IRoleAssignmentItem[]>] [-DnsServer <String[]>]
 [-EnableSystemAssignedIdentity <Boolean>] [-FirewallSku <String>]
 [-FlowLogDestinationCustomWorkspaceResourceId <String>] [-FlowLogDestinationDiagnosticSettingsName <String>]
 [-FlowLogDestinationType <String>] [-GovernedServiceList <IGovernedServiceItem[]>]
 [-GranularApprovalSetting <IApprovalSettings>] [-MaintenanceModeConfigurationJustification <String>]
 [-MaintenanceModeConfigurationMode <String>] [-MaintenanceModeConfigurationPrincipal <IPrincipal[]>]
 [-MonitoringSettingDiagnosticDestination <IMonitoringDestination[]>] [-PolicyOverride <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMissionCommunity -InputObject <IMissionIdentity> [-AddressSpace <String[]>]
 [-CommunityRoleAssignment <IRoleAssignmentItem[]>] [-DnsServer <String[]>]
 [-EnableSystemAssignedIdentity <Boolean>] [-FirewallSku <String>]
 [-FlowLogDestinationCustomWorkspaceResourceId <String>] [-FlowLogDestinationDiagnosticSettingsName <String>]
 [-FlowLogDestinationType <String>] [-GovernedServiceList <IGovernedServiceItem[]>]
 [-GranularApprovalSetting <IApprovalSettings>] [-MaintenanceModeConfigurationJustification <String>]
 [-MaintenanceModeConfigurationMode <String>] [-MaintenanceModeConfigurationPrincipal <IPrincipal[]>]
 [-MonitoringSettingDiagnosticDestination <IMonitoringDestination[]>] [-PolicyOverride <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a CommunityResource

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

### -AddressSpace
Address spaces list

```yaml
Type: System.String[]
Parameter Sets: (All)
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

### -CommunityRoleAssignment
Community role assignments

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IRoleAssignmentItem[]
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

### -DnsServer
DNS Servers.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallSku
SKU of the community's Azure Firewall (Basic, Standard, Premium).
Standard is the default

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

### -FlowLogDestinationCustomWorkspaceResourceId
Log analytics workspace resource ID for custom workspace

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

### -FlowLogDestinationDiagnosticSettingsName
Custom name for diagnostic settings

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

### -FlowLogDestinationType
The type of monitoring workspace destination

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

### -GovernedServiceList
List of services governed by a community.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IGovernedServiceItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GranularApprovalSetting
Granular approval requirements for various actions on the community's resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IApprovalSettings
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaintenanceModeConfigurationJustification
Justification for entering or exiting Maintenance Mode

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

### -MaintenanceModeConfigurationMode
Current mode of Maintenance Mode Configuration

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

### -MaintenanceModeConfigurationPrincipal
The user, group or service principal object affected by Maintenance Mode

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IPrincipal[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringSettingDiagnosticDestination
Log Analytics workspace destinations where diagnostic logs will be stored.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMonitoringDestination[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the communityResource Resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: CommunityName

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

### -PolicyOverride
Policy override setting for the community.
Specifies whether to apply enclave-specific policies or disable policy enforcement.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ICommunityResource

## NOTES

## RELATED LINKS
