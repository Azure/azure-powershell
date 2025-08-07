---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/new-azpool
schema: 2.0.0
---

# New-AzPool

## SYNOPSIS
Create a new pool inside the specified account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPool -AccountName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-ApplicationLicense <String[]>]
 [-ApplicationPackage <IApplicationPackageReference[]>] [-AutomaticOSUpgradePolicyDisableAutomaticRollback]
 [-AutomaticOSUpgradePolicyEnableAutomaticOsupgrade] [-AutomaticOSUpgradePolicyOsrollingUpgradeDeferral]
 [-AutomaticOSUpgradePolicyUseRollingUpgradePolicy] [-AutoScaleEvaluationInterval <TimeSpan>]
 [-AutoScaleFormula <String>] [-AutoUserElevationLevel <String>] [-AutoUserScope <String>]
 [-Certificate <ICertificateReference[]>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>]
 [-DeploymentConfigurationVirtualMachineConfiguration <IVirtualMachineConfiguration>] [-DisplayName <String>]
 [-EnableSystemAssignedIdentity] [-EndpointConfigurationInboundNatPool <IInboundNatPool[]>]
 [-FixedScaleNodeDeallocationOption <String>] [-FixedScaleResizeTimeout <TimeSpan>]
 [-FixedScaleTargetDedicatedNode <Int32>] [-FixedScaleTargetLowPriorityNode <Int32>]
 [-IdentityReferenceResourceId <String>] [-InterNodeCommunication <String>] [-Metadata <IMetadataItem[]>]
 [-MountConfiguration <IMountConfiguration[]>] [-NetworkConfigurationDynamicVnetAssignmentScope <String>]
 [-NetworkConfigurationEnableAcceleratedNetworking] [-NetworkConfigurationSubnetId <String>]
 [-PublicIPAddressConfigurationIpaddressId <String[]>] [-PublicIPAddressConfigurationProvision <String>]
 [-RegistryPassword <String>] [-RegistryServer <String>] [-RegistryUserName <String>]
 [-ResourceTag <Hashtable>] [-RollingUpgradePolicyEnableCrossZoneUpgrade]
 [-RollingUpgradePolicyMaxBatchInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent <Int32>]
 [-RollingUpgradePolicyPauseTimeBetweenBatch <String>] [-RollingUpgradePolicyPrioritizeUnhealthyInstance]
 [-RollingUpgradePolicyRollbackFailedInstancesOnPolicyBreach] [-StartTaskCommandLine <String>]
 [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>] [-StartTaskMaxTaskRetryCount <Int32>]
 [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess] [-Tag <Hashtable>]
 [-TargetNodeCommunicationMode <String>] [-TaskSchedulingPolicyNodeFillType <String>]
 [-TaskSlotsPerNode <Int32>] [-UpgradePolicyMode <String>] [-UserAccount <IUserAccount[]>]
 [-UserAssignedIdentity <String[]>] [-UserIdentityUserName <String>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityBatchAccountExpanded
```
New-AzPool -BatchAccountInputObject <IBatchIdentity> -Name <String> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-ApplicationLicense <String[]>]
 [-ApplicationPackage <IApplicationPackageReference[]>] [-AutomaticOSUpgradePolicyDisableAutomaticRollback]
 [-AutomaticOSUpgradePolicyEnableAutomaticOsupgrade] [-AutomaticOSUpgradePolicyOsrollingUpgradeDeferral]
 [-AutomaticOSUpgradePolicyUseRollingUpgradePolicy] [-AutoScaleEvaluationInterval <TimeSpan>]
 [-AutoScaleFormula <String>] [-AutoUserElevationLevel <String>] [-AutoUserScope <String>]
 [-Certificate <ICertificateReference[]>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>]
 [-DeploymentConfigurationVirtualMachineConfiguration <IVirtualMachineConfiguration>] [-DisplayName <String>]
 [-EnableSystemAssignedIdentity] [-EndpointConfigurationInboundNatPool <IInboundNatPool[]>]
 [-FixedScaleNodeDeallocationOption <String>] [-FixedScaleResizeTimeout <TimeSpan>]
 [-FixedScaleTargetDedicatedNode <Int32>] [-FixedScaleTargetLowPriorityNode <Int32>]
 [-IdentityReferenceResourceId <String>] [-InterNodeCommunication <String>] [-Metadata <IMetadataItem[]>]
 [-MountConfiguration <IMountConfiguration[]>] [-NetworkConfigurationDynamicVnetAssignmentScope <String>]
 [-NetworkConfigurationEnableAcceleratedNetworking] [-NetworkConfigurationSubnetId <String>]
 [-PublicIPAddressConfigurationIpaddressId <String[]>] [-PublicIPAddressConfigurationProvision <String>]
 [-RegistryPassword <String>] [-RegistryServer <String>] [-RegistryUserName <String>]
 [-ResourceTag <Hashtable>] [-RollingUpgradePolicyEnableCrossZoneUpgrade]
 [-RollingUpgradePolicyMaxBatchInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent <Int32>]
 [-RollingUpgradePolicyPauseTimeBetweenBatch <String>] [-RollingUpgradePolicyPrioritizeUnhealthyInstance]
 [-RollingUpgradePolicyRollbackFailedInstancesOnPolicyBreach] [-StartTaskCommandLine <String>]
 [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>] [-StartTaskMaxTaskRetryCount <Int32>]
 [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess] [-Tag <Hashtable>]
 [-TargetNodeCommunicationMode <String>] [-TaskSchedulingPolicyNodeFillType <String>]
 [-TaskSlotsPerNode <Int32>] [-UpgradePolicyMode <String>] [-UserAccount <IUserAccount[]>]
 [-UserAssignedIdentity <String[]>] [-UserIdentityUserName <String>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPool -AccountName <String> -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPool -AccountName <String> -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new pool inside the specified account.

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

### -AccountName
The name of the Batch account.

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

### -ApplicationLicense
The list of application licenses must be a subset of available Batch service application licenses.
If a license is requested which is not supported, pool creation will fail.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationPackage
Changes to application package references affect all new compute nodes joining the pool, but do not affect compute nodes that are already in the pool until they are rebooted or reimaged.
There is a maximum of 10 application package references on any given pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IApplicationPackageReference[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomaticOSUpgradePolicyDisableAutomaticRollback
Whether OS image rollback feature should be disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomaticOSUpgradePolicyEnableAutomaticOsupgrade
Indicates whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the OS image becomes available.
\<br /\>\<br /\> If this is set to true for Windows based pools, [WindowsConfiguration.enableAutomaticUpdates](https://learn.microsoft.com/rest/api/batchmanagement/pool/create?tabs=HTTP#windowsconfiguration) cannot be set to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomaticOSUpgradePolicyOsrollingUpgradeDeferral
Defer OS upgrades on the TVMs if they are running tasks.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomaticOSUpgradePolicyUseRollingUpgradePolicy
Indicates whether rolling upgrade policy should be used during Auto OS Upgrade.
Auto OS Upgrade will fallback to the default policy if no policy is defined on the VMSS.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScaleEvaluationInterval
If omitted, the default value is 15 minutes (PT15M).

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScaleFormula
A formula for the desired number of compute nodes in the pool.
Please visit external url https://learn.microsoft.com/azure/batch/batch-automatic-scaling to get more information.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUserElevationLevel
The default value is nonAdmin.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUserScope
The default value is Pool.
If the pool is running Windows a value of Task should be specified if stricter isolation between tasks is required.
For example, if the task mutates the registry in a way which could impact other tasks, or if certificates have been specified on the pool which should not be accessible by normal tasks but should be accessible by start tasks.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BatchAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: CreateViaIdentityBatchAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Certificate
For Windows compute nodes, the Batch service installs the certificates to the specified certificate store and location.
For Linux compute nodes, the certificates are stored in a directory inside the task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the task to query for this location.
For certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and certificates are placed in that directory.Warning: This property is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.ICertificateReference[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingContainerHostBatchBindMount
If this array is null or be not present, container task will mount entire temporary disk drive in windows (or AZ_BATCH_NODE_ROOT_DIR in Linux).
It won't' mount any data paths into container if this array is set as empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IContainerHostBatchBindMountEntry[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingContainerRunOption
These additional options are supplied as arguments to the "docker create" command, in addition to those controlled by the Batch Service.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingImageName
This is the full image reference, as would be specified to "docker pull".
If no tag is provided as part of the image name, the tag ":latest" is used as a default.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingWorkingDirectory
A flag to indicate where the container task working directory is.
The default is 'taskWorkingDirectory'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
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

### -DeploymentConfigurationVirtualMachineConfiguration
The configuration for compute nodes in a pool based on the Azure Virtual Machines infrastructure.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IVirtualMachineConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointConfigurationInboundNatPool
The maximum number of inbound NAT pools per Batch pool is 5.
If the maximum number of inbound NAT pools is exceeded the request fails with HTTP status code 400.
This cannot be specified if the IPAddressProvisioningType is NoPublicIPAddresses.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IInboundNatPool[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FixedScaleNodeDeallocationOption
If omitted, the default value is Requeue.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FixedScaleResizeTimeout
The default value is 15 minutes.
Timeout values use ISO 8601 format.
For example, use PT10M for 10 minutes.
The minimum value is 5 minutes.
If you specify a value less than 5 minutes, the Batch service rejects the request with an error; if you are calling the REST API directly, the HTTP status code is 400 (Bad Request).

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FixedScaleTargetDedicatedNode
At least one of targetDedicatedNodes, targetLowPriorityNodes must be set.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FixedScaleTargetLowPriorityNode
At least one of targetDedicatedNodes, targetLowPriorityNodes must be set.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityReferenceResourceId
The ARM resource id of the user assigned identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The entity state (ETag) version of the pool to update.
A value of "*" can be used to apply the operation only if the pool already exists.
If omitted, this operation will always be applied.

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

### -IfNoneMatch
Set to '*' to allow a new pool to be created, but to prevent updating an existing pool.
Other values will be ignored.

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

### -InterNodeCommunication
This imposes restrictions on which nodes can be assigned to the pool.
Enabling this value can reduce the chance of the requested number of nodes to be allocated in the pool.
If not specified, this value defaults to 'Disabled'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
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

### -Metadata
The Batch service does not assign any meaning to metadata; it is solely for the use of user code.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IMetadataItem[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MountConfiguration
This supports Azure Files, NFS, CIFS/SMB, and Blobfuse.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IMountConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The pool name.
This must be unique within the account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationDynamicVnetAssignmentScope
The scope of dynamic vnet assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationEnableAcceleratedNetworking
Accelerated networking enables single root I/O virtualization (SR-IOV) to a VM, which may lead to improved networking performance.
For more details, see: https://learn.microsoft.com/azure/virtual-network/accelerated-networking-overview.
Please visit external url https://learn.microsoft.com/azure/virtual-network/accelerated-networking-overview to get more information.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationSubnetId
The virtual network must be in the same region and subscription as the Azure Batch account.
The specified subnet should have enough free IP addresses to accommodate the number of nodes in the pool.
If the subnet doesn't have enough free IP addresses, the pool will partially allocate compute nodes and a resize error will occur.
The 'MicrosoftAzureBatch' service principal must have the 'Classic Virtual Machine Contributor' Role-Based Access Control (RBAC) role for the specified VNet.
The specified subnet must allow communication from the Azure Batch service to be able to schedule tasks on the compute nodes.
This can be verified by checking if the specified VNet has any associated Network Security Groups (NSG).
If communication to the compute nodes in the specified subnet is denied by an NSG, then the Batch service will set the state of the compute nodes to unusable.
If the specified VNet has any associated Network Security Groups (NSG), then a few reserved system ports must be enabled for inbound communication，including ports 29876 and 29877.
Also enable outbound connections to Azure Storage on port 443.
For more details see: https://learn.microsoft.com/azure/batch/batch-api-basics#virtual-network-vnet-and-firewall-configuration Please visit external url https://learn.microsoft.com/azure/batch/batch-virtual-network to get more information.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIPAddressConfigurationIpaddressId
The number of IPs specified here limits the maximum size of the Pool - 100 dedicated nodes or 100 Spot/low-priority nodes can be allocated for each public IP.
For example, a pool needing 250 dedicated VMs would need at least 3 public IPs specified.
Each element of this collection is of the form: /subscriptions/{subscription}/resourceGroups/{group}/providers/Microsoft.Network/publicIPAddresses/{ip}.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIPAddressConfigurationProvision
The default value is BatchManaged

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryPassword
The password to log into the registry server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryServer
If omitted, the default is "docker.io".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryUserName
The user name to log into the registry server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the Batch account.

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

### -ResourceTag
The user-defined tags to be associated with the Azure Batch Pool.
When specified, these tags are propagated to the backing Azure resources associated with the pool.
This property can only be specified when the Batch account was created with the poolAllocationMode property set to 'UserSubscription'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyEnableCrossZoneUpgrade
Allow VMSS to ignore AZ boundaries when constructing upgrade batches.
Take into consideration the Update Domain and maxBatchInstancePercent to determine the batch size.
If this field is not set, Azure Azure Batch will not set its default value.
The value of enableCrossZoneUpgrade on the created VirtualMachineScaleSet will be decided by the default configurations on VirtualMachineScaleSet.
This field is able to be set to true or false only when using NodePlacementConfiguration as Zonal.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyMaxBatchInstancePercent
The maximum percent of total virtual machine instances that will be upgraded simultaneously by the rolling upgrade in one batch.
As this is a maximum, unhealthy instances in previous or future batches can cause the percentage of instances in a batch to decrease to ensure higher reliability.
The value of this field should be between 5 and 100, inclusive.
If both maxBatchInstancePercent and maxUnhealthyInstancePercent are assigned with value, the value of maxBatchInstancePercent should not be more than maxUnhealthyInstancePercent.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyMaxUnhealthyInstancePercent
The maximum percentage of the total virtual machine instances in the scale set that can be simultaneously unhealthy, either as a result of being upgraded, or by being found in an unhealthy state by the virtual machine health checks before the rolling upgrade aborts.
This constraint will be checked prior to starting any batch.
The value of this field should be between 5 and 100, inclusive.
If both maxBatchInstancePercent and maxUnhealthyInstancePercent are assigned with value, the value of maxBatchInstancePercent should not be more than maxUnhealthyInstancePercent.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent
The maximum percentage of upgraded virtual machine instances that can be found to be in an unhealthy state.
This check will happen after each batch is upgraded.
If this percentage is ever exceeded, the rolling update aborts.
The value of this field should be between 0 and 100, inclusive.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyPauseTimeBetweenBatch
The wait time between completing the update for all virtual machines in one batch and starting the next batch.
The time duration should be specified in ISO 8601 format.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyPrioritizeUnhealthyInstance
Upgrade all unhealthy instances in a scale set before any healthy instances.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyRollbackFailedInstancesOnPolicyBreach
Rollback failed instances to previous model if the Rolling Upgrade policy is violated.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskCommandLine
The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion.
If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux.
Required if any other properties of the startTask are specified.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskEnvironmentSetting
A list of environment variable settings for the start task.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IEnvironmentSetting[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskMaxTaskRetryCount
The Batch service retries a task if its exit code is nonzero.
Note that this value specifically controls the number of retries.
The Batch service will try the task once, and may then retry up to this limit.
For example, if the maximum retry count is 3, Batch tries the task up to 4 times (one initial try and 3 retries).
If the maximum retry count is 0, the Batch service does not retry the task.
If the maximum retry count is -1, the Batch service retries the task without limit.
Default is 0

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskResourceFile
A list of files that the Batch service will download to the compute node before running the command line.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IResourceFile[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskWaitForSuccess
If true and the start task fails on a compute node, the Batch service retries the start task up to its maximum retry count (maxTaskRetryCount).
If the task has still not completed successfully after all retries, then the Batch service marks the compute node unusable, and will not schedule tasks to it.
This condition can be detected via the node state and scheduling error detail.
If false, the Batch service will not wait for the start task to complete.
In this case, other tasks can start executing on the compute node while the start task is still running; and even if the start task fails, new tasks will continue to be scheduled on the node.
The default is true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

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

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetNodeCommunicationMode
If omitted, the default value is Default.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskSchedulingPolicyNodeFillType
How tasks should be distributed across compute nodes.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskSlotsPerNode
The default value is 1.
The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradePolicyMode
Specifies the mode of an upgrade to virtual machines in the scale set.\<br /\>\<br /\> Possible values are:\<br /\>\<br /\> **Manual** - You control the application of updates to virtual machines in the scale set.
You do this by using the manualUpgrade action.\<br /\>\<br /\> **Automatic** - All virtual machines in the scale set are automatically updated at the same time.\<br /\>\<br /\> **Rolling** - Scale set performs updates in batches with an optional pause time in between.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAccount
The list of user accounts to be created on each node in the pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IUserAccount[]
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserIdentityUserName
The userName and autoUser properties are mutually exclusive; you must specify one but not both.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize
For information about available VM sizes, see Sizes for Virtual Machines in Azure (https://learn.microsoft.com/azure/virtual-machines/sizes/overview).
Batch supports all Azure VM sizes except STANDARD_A0 and those with premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2 series).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityBatchAccountExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IPool

## NOTES

## RELATED LINKS

