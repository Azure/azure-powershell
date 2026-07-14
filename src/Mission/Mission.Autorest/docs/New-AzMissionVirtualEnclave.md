---
external help file:
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/new-azmissionvirtualenclave
schema: 2.0.0
---

# New-AzMissionVirtualEnclave

## SYNOPSIS
Create a EnclaveResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzMissionVirtualEnclave -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-BastionEnabled] [-CommunityResourceId <String>]
 [-ConnectionCreationApprovalPolicy <String>] [-ConnectionCreationMandatoryApprover <IMandatoryApprover[]>]
 [-ConnectionCreationMinimumApproversRequired <Int32>] [-ConnectionUpdateApprovalPolicy <String>]
 [-ConnectionUpdateMandatoryApprover <IMandatoryApprover[]>]
 [-ConnectionUpdateMinimumApproversRequired <Int32>] [-DedicatedHubResourceId <String>]
 [-EnableSystemAssignedIdentity] [-EnclaveDefaultSettingDiagnosticDestination <String>]
 [-EnclaveEndpointUpdateApprovalPolicy <String>]
 [-EnclaveEndpointUpdateMandatoryApprover <IMandatoryApprover[]>]
 [-EnclaveEndpointUpdateMinimumApproversRequired <Int32>] [-EnclaveMaintenanceModeApprovalPolicy <String>]
 [-EnclaveMaintenanceModeMandatoryApprover <IMandatoryApprover[]>]
 [-EnclaveMaintenanceModeMinimumApproversRequired <Int32>] [-EnclaveRoleAssignment <IRoleAssignmentItem[]>]
 [-EnclaveVirtualNetworkAllowSubnetCommunication] [-EnclaveVirtualNetworkCustomCidrRange <String>]
 [-EnclaveVirtualNetworkName <String>] [-EnclaveVirtualNetworkSize <String>]
 [-EnclaveVirtualNetworkSubnetConfiguration <ISubnetConfiguration[]>]
 [-FlowLogDestinationCustomWorkspaceResourceId <String>] [-FlowLogDestinationDiagnosticSettingsName <String>]
 [-FlowLogDestinationType <String>] [-GovernedServiceList <IGovernedServiceItem[]>]
 [-MaintenanceModeConfigurationJustification <String>] [-MaintenanceModeConfigurationMode <String>]
 [-MaintenanceModeConfigurationPrincipal <IPrincipal[]>]
 [-MonitoringSettingDiagnosticDestination <IMonitoringDestination[]>] [-RbacInheritance <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-WorkloadResourceVisibility <String>]
 [-WorkloadRoleAssignment <IRoleAssignmentItem[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMissionVirtualEnclave -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMissionVirtualEnclave -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a EnclaveResource

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

### -BastionEnabled
Deploy Bastion service (True or False).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CommunityResourceId
Community Resource Id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionCreationApprovalPolicy
Approval policy (Required or NotRequired).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionCreationMandatoryApprover
List of mandatory approvers for this approval setting.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMandatoryApprover[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionCreationMinimumApproversRequired
Minimum number of approvers required for this approval setting.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionUpdateApprovalPolicy
Approval policy (Required or NotRequired).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionUpdateMandatoryApprover
List of mandatory approvers for this approval setting.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMandatoryApprover[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionUpdateMinimumApproversRequired
Minimum number of approvers required for this approval setting.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DedicatedHubResourceId
DedicatedHub Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveDefaultSettingDiagnosticDestination
Diagnostic Destination.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveEndpointUpdateApprovalPolicy
Approval policy (Required or NotRequired).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveEndpointUpdateMandatoryApprover
List of mandatory approvers for this approval setting.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMandatoryApprover[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveEndpointUpdateMinimumApproversRequired
Minimum number of approvers required for this approval setting.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveMaintenanceModeApprovalPolicy
Approval policy (Required or NotRequired).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveMaintenanceModeMandatoryApprover
List of mandatory approvers for this approval setting.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMandatoryApprover[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveMaintenanceModeMinimumApproversRequired
Minimum number of approvers required for this approval setting.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveRoleAssignment
Enclave role assignments

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IRoleAssignmentItem[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkAllowSubnetCommunication
Allow Subnet Communication.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkCustomCidrRange
Custom CIDR Range.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkName
Network Name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkSize
Network Size.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnclaveVirtualNetworkSubnetConfiguration
Subnet Configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.ISubnetConfiguration[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GovernedServiceList
Enclave specific policies

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IGovernedServiceItem[]
Parameter Sets: CreateExpanded
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaintenanceModeConfigurationJustification
Justification for entering or exiting Maintenance Mode

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the enclaveResource Resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualEnclaveName

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

### -RbacInheritance
Controls whether standard Azure RBAC role inheritance applies to the workload resource group(s)

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadResourceVisibility
Specifies whether resources in the workload resource group(s) are visible through standard RBAC

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadRoleAssignment
Workload role assignments

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IRoleAssignmentItem[]
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IEnclaveResource

## NOTES

## RELATED LINKS

