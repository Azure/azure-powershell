---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/update-azmissionvirtualenclave
schema: 2.0.0
---

# Update-AzMissionVirtualEnclave

## SYNOPSIS
Update a EnclaveResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMissionVirtualEnclave -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BastionEnabled] [-ConnectionCreationApprovalPolicy <String>]
 [-ConnectionCreationMandatoryApprover <IMandatoryApprover[]>]
 [-ConnectionCreationMinimumApproversRequired <Int32>] [-ConnectionUpdateApprovalPolicy <String>]
 [-ConnectionUpdateMandatoryApprover <IMandatoryApprover[]>]
 [-ConnectionUpdateMinimumApproversRequired <Int32>] [-DedicatedHubResourceId <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-EnclaveDefaultSettingDiagnosticDestination <String>]
 [-EnclaveEndpointUpdateApprovalPolicy <String>]
 [-EnclaveEndpointUpdateMandatoryApprover <IMandatoryApprover[]>]
 [-EnclaveEndpointUpdateMinimumApproversRequired <Int32>] [-EnclaveMaintenanceModeApprovalPolicy <String>]
 [-EnclaveMaintenanceModeMandatoryApprover <IMandatoryApprover[]>]
 [-EnclaveMaintenanceModeMinimumApproversRequired <Int32>] [-EnclaveRoleAssignment <IRoleAssignmentItem[]>]
 [-EnclaveVirtualNetworkName <String>] [-EnclaveVirtualNetworkSubnetConfiguration <ISubnetConfiguration[]>]
 [-FlowLogDestinationCustomWorkspaceResourceId <String>] [-FlowLogDestinationDiagnosticSettingsName <String>]
 [-FlowLogDestinationType <String>] [-GovernedServiceList <IGovernedServiceItem[]>]
 [-MaintenanceModeConfigurationJustification <String>] [-MaintenanceModeConfigurationMode <String>]
 [-MaintenanceModeConfigurationPrincipal <IPrincipal[]>]
 [-MonitoringSettingDiagnosticDestination <IMonitoringDestination[]>] [-RbacInheritance <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-WorkloadResourceVisibility <String>]
 [-WorkloadRoleAssignment <IRoleAssignmentItem[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMissionVirtualEnclave -InputObject <IMissionIdentity> [-BastionEnabled]
 [-ConnectionCreationApprovalPolicy <String>] [-ConnectionCreationMandatoryApprover <IMandatoryApprover[]>]
 [-ConnectionCreationMinimumApproversRequired <Int32>] [-ConnectionUpdateApprovalPolicy <String>]
 [-ConnectionUpdateMandatoryApprover <IMandatoryApprover[]>]
 [-ConnectionUpdateMinimumApproversRequired <Int32>] [-DedicatedHubResourceId <String>]
 [-EnableSystemAssignedIdentity <Boolean>] [-EnclaveDefaultSettingDiagnosticDestination <String>]
 [-EnclaveEndpointUpdateApprovalPolicy <String>]
 [-EnclaveEndpointUpdateMandatoryApprover <IMandatoryApprover[]>]
 [-EnclaveEndpointUpdateMinimumApproversRequired <Int32>] [-EnclaveMaintenanceModeApprovalPolicy <String>]
 [-EnclaveMaintenanceModeMandatoryApprover <IMandatoryApprover[]>]
 [-EnclaveMaintenanceModeMinimumApproversRequired <Int32>] [-EnclaveRoleAssignment <IRoleAssignmentItem[]>]
 [-EnclaveVirtualNetworkName <String>] [-EnclaveVirtualNetworkSubnetConfiguration <ISubnetConfiguration[]>]
 [-FlowLogDestinationCustomWorkspaceResourceId <String>] [-FlowLogDestinationDiagnosticSettingsName <String>]
 [-FlowLogDestinationType <String>] [-GovernedServiceList <IGovernedServiceItem[]>]
 [-MaintenanceModeConfigurationJustification <String>] [-MaintenanceModeConfigurationMode <String>]
 [-MaintenanceModeConfigurationPrincipal <IPrincipal[]>]
 [-MonitoringSettingDiagnosticDestination <IMonitoringDestination[]>] [-RbacInheritance <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-WorkloadResourceVisibility <String>]
 [-WorkloadRoleAssignment <IRoleAssignmentItem[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a EnclaveResource

## EXAMPLES

### Example 1: Patch a virtual enclave's tags
```powershell
Update-AzMissionVirtualEnclave -Name 'contoso-enclave' -ResourceGroupName 'mission-rg' -Tag @{ environment = 'production' }
```

```output
Name             Location ResourceGroupName ProvisioningState
----             -------- ----------------- -----------------
contoso-enclave  eastus   mission-rg        Succeeded
```

Updates only the tags on the existing `contoso-enclave` virtual enclave, leaving all other properties unchanged (PATCH semantics).

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### -EnclaveDefaultSettingDiagnosticDestination
Diagnostic Destination.

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

### -EnclaveEndpointUpdateApprovalPolicy
Approval policy (Required or NotRequired).

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

### -EnclaveEndpointUpdateMandatoryApprover
List of mandatory approvers for this approval setting.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMandatoryApprover[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Enclave specific policies

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
The name of the enclaveResource Resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -WorkloadResourceVisibility
Specifies whether resources in the workload resource group(s) are visible through standard RBAC

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

### -WorkloadRoleAssignment
Workload role assignments

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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IEnclaveResource

## NOTES

## RELATED LINKS
