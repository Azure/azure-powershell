---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/update-azpool
schema: 2.0.0
---

# Update-AzPool

## SYNOPSIS
This only replaces the Pool properties specified in the request.
For example,\nif the Pool has a StartTask associated with it, and a request does not specify\na StartTask element, then the Pool keeps the existing StartTask.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPool -Endpoint <String> -Id <String> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId]
 [-ApplicationPackageReference <IBatchApplicationPackageReference[]>]
 [-AutomaticOSUpgradePolicyDisableAutomaticRollback] [-AutomaticOSUpgradePolicyEnableAutomaticOsupgrade]
 [-AutomaticOSUpgradePolicyOsrollingUpgradeDeferral] [-AutomaticOSUpgradePolicyUseRollingUpgradePolicy]
 [-AutoUserElevationLevel <String>] [-AutoUserScope <String>]
 [-CertificateReference <IBatchCertificateReference[]>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>] [-DisplayName <String>] [-EnableInterNodeCommunication]
 [-EndpointConfigurationInboundNatPool <IBatchInboundNatPool[]>] [-IdentityReferenceResourceId <String>]
 [-Metadata <IBatchMetadataItem[]>] [-MountConfiguration <IMountConfiguration[]>]
 [-NetworkConfigurationDynamicVnetAssignmentScope <String>] [-NetworkConfigurationEnableAcceleratedNetworking]
 [-NetworkConfigurationSubnetId <String>] [-PublicIPAddressConfigurationIpaddressId <String[]>]
 [-PublicIPAddressConfigurationIpaddressProvisioningType <String>] [-RegistryPassword <SecureString>]
 [-RegistryServer <String>] [-RegistryUsername <String>] [-ResourceTag <Hashtable>]
 [-RollingUpgradePolicyEnableCrossZoneUpgrade] [-RollingUpgradePolicyMaxBatchInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent <Int32>]
 [-RollingUpgradePolicyPauseTimeBetweenBatch <TimeSpan>] [-RollingUpgradePolicyPrioritizeUnhealthyInstance]
 [-RollingUpgradePolicyRollbackFailedInstancesOnPolicyBreach] [-StartTaskCommandLine <String>]
 [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>] [-StartTaskMaxTaskRetryCount <Int32>]
 [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess] [-TargetNodeCommunicationMode <String>]
 [-TaskSchedulingPolicyNodeFillType <String>] [-TaskSlotsPerNode <Int32>] [-UpgradePolicyMode <String>]
 [-UserAccount <IUserAccount[]>] [-UserIdentityUsername <String>]
 [-VirtualMachineConfiguration <IVirtualMachineConfigurationUpdate>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPool -Endpoint <String> -InputObject <IBatchIdentity> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>] [-IfUnmodifiedSince <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId]
 [-ApplicationPackageReference <IBatchApplicationPackageReference[]>]
 [-AutomaticOSUpgradePolicyDisableAutomaticRollback] [-AutomaticOSUpgradePolicyEnableAutomaticOsupgrade]
 [-AutomaticOSUpgradePolicyOsrollingUpgradeDeferral] [-AutomaticOSUpgradePolicyUseRollingUpgradePolicy]
 [-AutoUserElevationLevel <String>] [-AutoUserScope <String>]
 [-CertificateReference <IBatchCertificateReference[]>]
 [-ContainerSettingContainerHostBatchBindMount <IContainerHostBatchBindMountEntry[]>]
 [-ContainerSettingContainerRunOption <String>] [-ContainerSettingImageName <String>]
 [-ContainerSettingWorkingDirectory <String>] [-DisplayName <String>] [-EnableInterNodeCommunication]
 [-EndpointConfigurationInboundNatPool <IBatchInboundNatPool[]>] [-IdentityReferenceResourceId <String>]
 [-Metadata <IBatchMetadataItem[]>] [-MountConfiguration <IMountConfiguration[]>]
 [-NetworkConfigurationDynamicVnetAssignmentScope <String>] [-NetworkConfigurationEnableAcceleratedNetworking]
 [-NetworkConfigurationSubnetId <String>] [-PublicIPAddressConfigurationIpaddressId <String[]>]
 [-PublicIPAddressConfigurationIpaddressProvisioningType <String>] [-RegistryPassword <SecureString>]
 [-RegistryServer <String>] [-RegistryUsername <String>] [-ResourceTag <Hashtable>]
 [-RollingUpgradePolicyEnableCrossZoneUpgrade] [-RollingUpgradePolicyMaxBatchInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyInstancePercent <Int32>]
 [-RollingUpgradePolicyMaxUnhealthyUpgradedInstancePercent <Int32>]
 [-RollingUpgradePolicyPauseTimeBetweenBatch <TimeSpan>] [-RollingUpgradePolicyPrioritizeUnhealthyInstance]
 [-RollingUpgradePolicyRollbackFailedInstancesOnPolicyBreach] [-StartTaskCommandLine <String>]
 [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>] [-StartTaskMaxTaskRetryCount <Int32>]
 [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess] [-TargetNodeCommunicationMode <String>]
 [-TaskSchedulingPolicyNodeFillType <String>] [-TaskSlotsPerNode <Int32>] [-UpgradePolicyMode <String>]
 [-UserAccount <IUserAccount[]>] [-UserIdentityUsername <String>]
 [-VirtualMachineConfiguration <IVirtualMachineConfigurationUpdate>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzPool -Endpoint <String> -Id <String> -JsonFilePath <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzPool -Endpoint <String> -Id <String> -JsonString <String> [-TimeOut <Int32>]
 [-ClientRequestId <String>] [-IfMatch <String>] [-IfModifiedSince <String>] [-IfNoneMatch <String>]
 [-IfUnmodifiedSince <String>] [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This only replaces the Pool properties specified in the request.
For example,\nif the Pool has a StartTask associated with it, and a request does not specify\na StartTask element, then the Pool keeps the existing StartTask.

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

### -ApplicationPackageReference
A list of Packages to be installed on each Compute Node in the Pool.
Changes to Package references affect all new Nodes joining the Pool, but do not affect Compute Nodes that are already in the Pool until they are rebooted or reimaged.
If this element is present, it replaces any existing Package references.
If you specify an empty collection, then all Package references are removed from the Pool.
If omitted, any existing Package references are left unchanged.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchApplicationPackageReference[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomaticOSUpgradePolicyEnableAutomaticOsupgrade
Indicates whether OS upgrades should automatically be applied to scale set instances in a rolling fashion when a newer version of the OS image becomes available.
\<br /\>\<br /\> If this is set to true for Windows based pools, [WindowsConfiguration.enableAutomaticUpdates](https://learn.microsoft.com/rest/api/batchservice/pool/add?tabs=HTTP#windowsconfiguration) cannot be set to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUserElevationLevel
The elevation level of the auto user.
The default value is nonAdmin.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUserScope
The scope for the auto user.
The default value is pool.
If the pool is running Windows a value of Task should be specified if stricter isolation between tasks is required.
For example, if the task mutates the registry in a way which could impact other tasks, or if certificates have been specified on the pool which should not be accessible by normal tasks but should be accessible by StartTasks.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateReference
If this element is present, it replaces any existing Certificate references configured on the Pool.If omitted, any existing Certificate references are left unchanged.For Windows Nodes, the Batch service installs the Certificates to the specified Certificate store and location.For Linux Compute Nodes, the Certificates are stored in a directory inside the Task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the Task to query for this location.For Certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and Certificates are placed in that directory.Warning: This property is deprecated and will be removed after February, 2024.
Please use the [Azure KeyVault Extension](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide) instead.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchCertificateReference[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientRequestId
The caller-generated request identity, in the form of a GUID with no decoration
such as curly braces, e.g.
9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.

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

### -ContainerSettingContainerHostBatchBindMount
The paths you want to mounted to container task.
If this array is null or be not present, container task will mount entire temporary disk drive in windows (or AZ_BATCH_NODE_ROOT_DIR in Linux).
It won't' mount any data paths into container if this array is set as empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IContainerHostBatchBindMountEntry[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingContainerRunOption
Additional options to the container create command.
These additional options are supplied as arguments to the "docker create" command, in addition to those controlled by the Batch Service.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingImageName
The Image to use to create the container in which the Task will run.
This is the full Image reference, as would be specified to "docker pull".
If no tag is provided as part of the Image name, the tag ":latest" is used as a default.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSettingWorkingDirectory
The location of the container Task working directory.
The default is 'taskWorkingDirectory'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -DisplayName
The display name for the Pool.
The display name need not be unique and can contain any Unicode characters up to a maximum length of 1024.
This field can be updated only when the pool is empty.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableInterNodeCommunication
Whether the Pool permits direct communication between Compute Nodes.
Enabling inter-node communication limits the maximum size of the Pool due to deployment restrictions on the Compute Nodes of the Pool.
This may result in the Pool not reaching its desired size.
The default value is false.\<br /\>\<br /\>This field can be updated only when the pool is empty.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com).

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

### -EndpointConfigurationInboundNatPool
A list of inbound NAT Pools that can be used to address specific ports on an individual Compute Node externally.
The maximum number of inbound NAT Pools per Batch Pool is 5.
If the maximum number of inbound NAT Pools is exceeded the request fails with HTTP status code 400.
This cannot be specified if the IPAddressProvisioningType is NoPublicIPAddresses.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchInboundNatPool[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The ID of the Pool to get.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: PoolId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityReferenceResourceId
The ARM resource id of the user assigned identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
An ETag value associated with the version of the resource known to the client.
The operation will be performed only if the resource's current ETag on the
service exactly matches the value specified by the client.

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

### -IfModifiedSince
A timestamp indicating the last modified time of the resource known to the
client.
The operation will be performed only if the resource on the service has
been modified since the specified time.

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
An ETag value associated with the version of the resource known to the client.
The operation will be performed only if the resource's current ETag on the
service does not match the value specified by the client.

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

### -IfUnmodifiedSince
A timestamp indicating the last modified time of the resource known to the
client.
The operation will be performed only if the resource on the service has
not been modified since the specified time.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
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

### -Metadata
A list of name-value pairs associated with the Pool as metadata.
If this element is present, it replaces any existing metadata configured on the Pool.
If you specify an empty collection, any metadata is removed from the Pool.
If omitted, any existing metadata is left unchanged.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchMetadataItem[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MountConfiguration
Mount storage using specified file system for the entire lifetime of the pool.
Mount the storage using Azure fileshare, NFS, CIFS or Blobfuse based file system.\<br /\>\<br /\>This field can be updated only when the pool is empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IMountConfiguration[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationDynamicVnetAssignmentScope
The scope of dynamic vnet assignment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationEnableAcceleratedNetworking
Whether this pool should enable accelerated networking.
Accelerated networking enables single root I/O virtualization (SR-IOV) to a VM, which may lead to improved networking performance.
For more details, see: https://learn.microsoft.com/azure/virtual-network/accelerated-networking-overview.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationSubnetId
The ARM resource identifier of the virtual network subnet which the Compute Nodes of the Pool will join.
This is of the form /subscriptions/{subscription}/resourceGroups/{group}/providers/{provider}/virtualNetworks/{network}/subnets/{subnet}.
The virtual network must be in the same region and subscription as the Azure Batch Account.
The specified subnet should have enough free IP addresses to accommodate the number of Compute Nodes in the Pool.
If the subnet doesn't have enough free IP addresses, the Pool will partially allocate Nodes and a resize error will occur.
The 'MicrosoftAzureBatch' service principal must have the 'Classic Virtual Machine Contributor' Role-Based Access Control (RBAC) role for the specified VNet.
The specified subnet must allow communication from the Azure Batch service to be able to schedule Tasks on the Nodes.
This can be verified by checking if the specified VNet has any associated Network Security Groups (NSG).
If communication to the Nodes in the specified subnet is denied by an NSG, then the Batch service will set the state of the Compute Nodes to unusable.
Only ARM virtual networks ('Microsoft.Network/virtualNetworks') are supported.
If the specified VNet has any associated Network Security Groups (NSG), then a few reserved system ports must be enabled for inbound communication, including ports 29876 and 29877.
Also enable outbound connections to Azure Storage on port 443.
For more details see: https://learn.microsoft.com/azure/batch/nodes-and-pools#virtual-network-vnet-and-firewall-configuration

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ocpdate
The time the request was issued.
Client libraries typically set this to the
current system clock time; set it explicitly if you are calling the REST API
directly.

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

### -PassThru
Returns true when the command succeeds

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

### -PublicIPAddressConfigurationIpaddressId
The list of public IPs which the Batch service will use when provisioning Compute Nodes.
The number of IPs specified here limits the maximum size of the Pool - 100 dedicated nodes or 100 Spot/Low-priority nodes can be allocated for each public IP.
For example, a pool needing 250 dedicated VMs would need at least 3 public IPs specified.
Each element of this collection is of the form: /subscriptions/{subscription}/resourceGroups/{group}/providers/Microsoft.Network/publicIPAddresses/{ip}.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIPAddressConfigurationIpaddressProvisioningType
The provisioning type for Public IP Addresses for the Pool.
The default value is BatchManaged.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryServer
The registry URL.
If omitted, the default is "docker.io".

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryUsername
The user name to log into the registry server.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceTag
The user-specified tags associated with the pool.
The user-defined tags to be associated with the Azure Batch Pool.
When specified, these tags are propagated to the backing Azure resources associated with the pool.
This property can only be specified when the Batch account was created with the poolAllocationMode property set to 'UserSubscription'.\<br /\>\<br /\>This field can be updated only when the pool is empty.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnClientRequestId
Whether the server should return the client-request-id in the response.

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

### -RollingUpgradePolicyEnableCrossZoneUpgrade
Allow VMSS to ignore AZ boundaries when constructing upgrade batches.
Take into consideration the Update Domain and maxBatchInstancePercent to determine the batch size.
This field is able to be set to true or false only when using NodePlacementConfiguration as Zonal.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradePolicyPauseTimeBetweenBatch
The wait time between completing the update for all virtual machines in one batch and starting the next batch.
The time duration should be specified in ISO 8601 format..

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskCommandLine
The command line of the StartTask.
The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion.
If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux.
If the command line refers to file paths, it should use a relative path (relative to the Task working directory), or use the Batch provided environment variable (https://learn.microsoft.com/azure/batch/batch-compute-node-environment-variables).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskEnvironmentSetting
A list of environment variable settings for the StartTask.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IEnvironmentSetting[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskMaxTaskRetryCount
The maximum number of times the Task may be retried.
The Batch service retries a Task if its exit code is nonzero.
Note that this value specifically controls the number of retries.
The Batch service will try the Task once, and may then retry up to this limit.
For example, if the maximum retry count is 3, Batch tries the Task up to 4 times (one initial try and 3 retries).
If the maximum retry count is 0, the Batch service does not retry the Task.
If the maximum retry count is -1, the Batch service retries the Task without limit, however this is not recommended for a start task or any task.
The default value is 0 (no retries).

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskResourceFile
A list of files that the Batch service will download to the Compute Node before running the command line.
There is a maximum size for the list of resource files.
When the max size is exceeded, the request will fail and the response error code will be RequestEntityTooLarge.
If this occurs, the collection of ResourceFiles must be reduced in size.
This can be achieved using .zip files, Application Packages, or Docker Containers.
Files listed under this element are located in the Task's working directory.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IResourceFile[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskWaitForSuccess
Whether the Batch service should wait for the StartTask to complete successfully (that is, to exit with exit code 0) before scheduling any Tasks on the Compute Node.
If true and the StartTask fails on a Node, the Batch service retries the StartTask up to its maximum retry count (maxTaskRetryCount).
If the Task has still not completed successfully after all retries, then the Batch service marks the Node unusable, and will not schedule Tasks to it.
This condition can be detected via the Compute Node state and failure info details.
If false, the Batch service will not wait for the StartTask to complete.
In this case, other Tasks can start executing on the Compute Node while the StartTask is still running; and even if the StartTask fails, new Tasks will continue to be scheduled on the Compute Node.
The default is true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetNodeCommunicationMode
The desired node communication mode for the pool.
If this element is present, it replaces the existing targetNodeCommunicationMode configured on the Pool.
If omitted, any existing metadata is left unchanged.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskSchedulingPolicyNodeFillType
How Tasks are distributed across Compute Nodes in a Pool.
If not specified, the default is spread.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskSlotsPerNode
The number of task slots that can be used to run concurrent tasks on a single compute node in the pool.
The default value is 1.
The maximum value is the smaller of 4 times the number of cores of the vmSize of the pool or 256.\<br /\>\<br /\>This field can be updated only when the pool is empty.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeOut
The maximum time that the server can spend processing the request, in seconds.
The default is 30 seconds.
If the value is larger than 30, the default will be used instead.".

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

### -UpgradePolicyMode
Specifies the mode of an upgrade to virtual machines in the scale set.\<br /\>\<br /\> Possible values are:\<br /\>\<br /\> **Manual** - You control the application of updates to virtual machines in the scale set.
You do this by using the manualUpgrade action.\<br /\>\<br /\> **Automatic** - All virtual machines in the scale set are automatically updated at the same time.\<br /\>\<br /\> **Rolling** - Scale set performs updates in batches with an optional pause time in between.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAccount
The list of user Accounts to be created on each Compute Node in the Pool.
This field can be updated only when the pool is empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IUserAccount[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserIdentityUsername
The name of the user identity under which the Task is run.
The userName and autoUser properties are mutually exclusive; you must specify one but not both.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualMachineConfiguration
The virtual machine configuration for the Pool.
This property must be specified.\<br /\>\<br /\>This field can be updated only when the pool is empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IVirtualMachineConfigurationUpdate
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize
The size of virtual machines in the Pool.
For information about available sizes of virtual machines in Pools, see Choose a VM size for Compute Nodes in an Azure Batch Pool (https://learn.microsoft.com/azure/batch/batch-pool-vm-sizes).\<br /\>\<br /\>This field can be updated only when the pool is empty.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### System.Boolean

## NOTES

## RELATED LINKS

