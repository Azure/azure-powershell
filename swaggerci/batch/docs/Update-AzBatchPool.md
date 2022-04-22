---
external help file:
Module Name: Az.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/update-azbatchpool
schema: 2.0.0
---

# Update-AzBatchPool

## SYNOPSIS
Updates the properties of an existing pool.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzBatchPool -AccountName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-ApplicationLicense <String[]>] [-ApplicationPackage <IApplicationPackageReference[]>]
 [-AutoScaleEvaluationInterval <TimeSpan>] [-AutoScaleFormula <String>]
 [-AutoUserElevationLevel <ElevationLevel>] [-AutoUserScope <AutoUserScope>]
 [-Certificate <ICertificateReference[]>] [-ContainerSettingContainerRunOption <String>]
 [-ContainerSettingImageName <String>] [-ContainerSettingWorkingDirectory <ContainerWorkingDirectory>]
 [-DeploymentConfiguration <IDeploymentConfiguration>] [-DisplayName <String>]
 [-EndpointConfigurationInboundNatPool <IInboundNatPool[]>]
 [-FixedScaleNodeDeallocationOption <ComputeNodeDeallocationOption>] [-FixedScaleResizeTimeout <TimeSpan>]
 [-FixedScaleTargetDedicatedNode <Int32>] [-FixedScaleTargetLowPriorityNode <Int32>]
 [-IdentityReferenceResourceId <String>] [-IdentityType <PoolIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-InterNodeCommunication <InterNodeCommunicationState>]
 [-Metadata <IMetadataItem[]>] [-MountConfiguration <IMountConfiguration[]>]
 [-NetworkConfigurationDynamicVNetAssignmentScope <DynamicVNetAssignmentScope>]
 [-NetworkConfigurationSubnetId <String>] [-PublicIPAddressConfigurationIpaddressId <String[]>]
 [-PublicIPAddressConfigurationProvision <IPAddressProvisioningType>] [-RegistryPassword <String>]
 [-RegistryServer <String>] [-RegistryUserName <String>] [-StartTaskCommandLine <String>]
 [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>] [-StartTaskMaxTaskRetryCount <Int32>]
 [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess]
 [-TaskSchedulingPolicyNodeFillType <ComputeNodeFillType>] [-TaskSlotsPerNode <Int32>]
 [-UserAccount <IUserAccount[]>] [-UserIdentityUserName <String>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzBatchPool -InputObject <IBatchIdentity> [-IfMatch <String>] [-ApplicationLicense <String[]>]
 [-ApplicationPackage <IApplicationPackageReference[]>] [-AutoScaleEvaluationInterval <TimeSpan>]
 [-AutoScaleFormula <String>] [-AutoUserElevationLevel <ElevationLevel>] [-AutoUserScope <AutoUserScope>]
 [-Certificate <ICertificateReference[]>] [-ContainerSettingContainerRunOption <String>]
 [-ContainerSettingImageName <String>] [-ContainerSettingWorkingDirectory <ContainerWorkingDirectory>]
 [-DeploymentConfiguration <IDeploymentConfiguration>] [-DisplayName <String>]
 [-EndpointConfigurationInboundNatPool <IInboundNatPool[]>]
 [-FixedScaleNodeDeallocationOption <ComputeNodeDeallocationOption>] [-FixedScaleResizeTimeout <TimeSpan>]
 [-FixedScaleTargetDedicatedNode <Int32>] [-FixedScaleTargetLowPriorityNode <Int32>]
 [-IdentityReferenceResourceId <String>] [-IdentityType <PoolIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-InterNodeCommunication <InterNodeCommunicationState>]
 [-Metadata <IMetadataItem[]>] [-MountConfiguration <IMountConfiguration[]>]
 [-NetworkConfigurationDynamicVNetAssignmentScope <DynamicVNetAssignmentScope>]
 [-NetworkConfigurationSubnetId <String>] [-PublicIPAddressConfigurationIpaddressId <String[]>]
 [-PublicIPAddressConfigurationProvision <IPAddressProvisioningType>] [-RegistryPassword <String>]
 [-RegistryServer <String>] [-RegistryUserName <String>] [-StartTaskCommandLine <String>]
 [-StartTaskEnvironmentSetting <IEnvironmentSetting[]>] [-StartTaskMaxTaskRetryCount <Int32>]
 [-StartTaskResourceFile <IResourceFile[]>] [-StartTaskWaitForSuccess]
 [-TaskSchedulingPolicyNodeFillType <ComputeNodeFillType>] [-TaskSlotsPerNode <Int32>]
 [-UserAccount <IUserAccount[]>] [-UserIdentityUserName <String>] [-VMSize <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an existing pool.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the Batch account.

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

### -ApplicationLicense
The list of application licenses must be a subset of available Batch service application licenses.
If a license is requested which is not supported, pool creation will fail.

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

### -ApplicationPackage
Changes to application package references affect all new compute nodes joining the pool, but do not affect compute nodes that are already in the pool until they are rebooted or reimaged.
There is a maximum of 10 application package references on any given pool.
To construct, see NOTES section for APPLICATIONPACKAGE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IApplicationPackageReference[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScaleFormula
A formula for the desired number of compute nodes in the pool.

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

### -AutoUserElevationLevel
The default value is nonAdmin.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.ElevationLevel
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.AutoUserScope
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Certificate
For Windows compute nodes, the Batch service installs the certificates to the specified certificate store and location.
For Linux compute nodes, the certificates are stored in a directory inside the task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the task to query for this location.
For certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and certificates are placed in that directory.
To construct, see NOTES section for CERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.ICertificateReference[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.ContainerWorkingDirectory
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeploymentConfiguration
Using CloudServiceConfiguration specifies that the nodes should be creating using Azure Cloud Services (PaaS), while VirtualMachineConfiguration uses Azure Virtual Machines (IaaS).
To construct, see NOTES section for DEPLOYMENTCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IDeploymentConfiguration
Parameter Sets: (All)
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
Parameter Sets: (All)
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
To construct, see NOTES section for ENDPOINTCONFIGURATIONINBOUNDNATPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IInboundNatPool[]
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.ComputeNodeDeallocationOption
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the Batch Pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.PoolIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the Batch pool.

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

### -IfMatch
The entity state (ETag) version of the pool to update.
This value can be omitted or set to "*" to apply the operation unconditionally.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -InterNodeCommunication
This imposes restrictions on which nodes can be assigned to the pool.
Enabling this value can reduce the chance of the requested number of nodes to be allocated in the pool.
If not specified, this value defaults to 'Disabled'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.InterNodeCommunicationState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
The Batch service does not assign any meaning to metadata; it is solely for the use of user code.
To construct, see NOTES section for METADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IMetadataItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MountConfiguration
This supports Azure Files, NFS, CIFS/SMB, and Blobfuse.
To construct, see NOTES section for MOUNTCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IMountConfiguration[]
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
Aliases: PoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkConfigurationDynamicVNetAssignmentScope
The scope of dynamic vnet assignment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.DynamicVNetAssignmentScope
Parameter Sets: (All)
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
If the specified VNet has any associated Network Security Groups (NSG), then a few reserved system ports must be enabled for inbound communication.
For pools created with a virtual machine configuration, enable ports 29876 and 29877, as well as port 22 for Linux and port 3389 for Windows.
For pools created with a cloud service configuration, enable ports 10100, 20100, and 30100.
Also enable outbound connections to Azure Storage on port 443.
For cloudServiceConfiguration pools, only 'classic' VNETs are supported.
For more details see: https://docs.microsoft.com/en-us/azure/batch/batch-api-basics#virtual-network-vnet-and-firewall-configuration

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

### -PublicIPAddressConfigurationIpaddressId
The number of IPs specified here limits the maximum size of the Pool - 100 dedicated nodes or 100 Spot/low-priority nodes can be allocated for each public IP.
For example, a pool needing 250 dedicated VMs would need at least 3 public IPs specified.
Each element of this collection is of the form: /subscriptions/{subscription}/resourceGroups/{group}/providers/Microsoft.Network/publicIPAddresses/{ip}.

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

### -PublicIPAddressConfigurationProvision
The default value is BatchManaged

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.IPAddressProvisioningType
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTaskEnvironmentSetting
A list of environment variable settings for the start task.
To construct, see NOTES section for STARTTASKENVIRONMENTSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IEnvironmentSetting[]
Parameter Sets: (All)
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
If the maximum retry count is -1, the Batch service retries the task without limit, however this is not recommended for a start task or any task.
The default value is 0 (no retries).

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

### -StartTaskResourceFile
A list of files that the Batch service will download to the compute node before running the command line.
To construct, see NOTES section for STARTTASKRESOURCEFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IResourceFile[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskSchedulingPolicyNodeFillType
How tasks should be distributed across compute nodes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Support.ComputeNodeFillType
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAccount
The list of user accounts to be created on each node in the pool.
To construct, see NOTES section for USERACCOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IUserAccount[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize
For information about available sizes of virtual machines for Cloud Services pools (pools created with cloudServiceConfiguration), see Sizes for Cloud Services (https://azure.microsoft.com/documentation/articles/cloud-services-sizes-specs/).
Batch supports all Cloud Services VM sizes except ExtraSmall.
For information about available VM sizes for pools using images from the Virtual Machines Marketplace (pools created with virtualMachineConfiguration) see Sizes for Virtual Machines (Linux) (https://azure.microsoft.com/documentation/articles/virtual-machines-linux-sizes/) or Sizes for Virtual Machines (Windows) (https://azure.microsoft.com/documentation/articles/virtual-machines-windows-sizes/).
Batch supports all Azure VM sizes except STANDARD_A0 and those with premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2 series).

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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.IPool

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


APPLICATIONPACKAGE <IApplicationPackageReference[]>: Changes to application package references affect all new compute nodes joining the pool, but do not affect compute nodes that are already in the pool until they are rebooted or reimaged. There is a maximum of 10 application package references on any given pool.
  - `Id <String>`: The ID of the application package to install. This must be inside the same batch account as the pool. This can either be a reference to a specific version or the default version if one exists.
  - `[Version <String>]`: If this is omitted, and no default version is specified for this application, the request fails with the error code InvalidApplicationPackageReferences. If you are calling the REST API directly, the HTTP status code is 409.

CERTIFICATE <ICertificateReference[]>: For Windows compute nodes, the Batch service installs the certificates to the specified certificate store and location. For Linux compute nodes, the certificates are stored in a directory inside the task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the task to query for this location. For certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and certificates are placed in that directory.
  - `Id <String>`: The fully qualified ID of the certificate to install on the pool. This must be inside the same batch account as the pool.
  - `[StoreLocation <CertificateStoreLocation?>]`: The default value is currentUser. This property is applicable only for pools configured with Windows nodes (that is, created with cloudServiceConfiguration, or with virtualMachineConfiguration using a Windows image reference). For Linux compute nodes, the certificates are stored in a directory inside the task working directory and an environment variable AZ_BATCH_CERTIFICATES_DIR is supplied to the task to query for this location. For certificates with visibility of 'remoteUser', a 'certs' directory is created in the user's home directory (e.g., /home/{user-name}/certs) and certificates are placed in that directory.
  - `[StoreName <String>]`: This property is applicable only for pools configured with Windows nodes (that is, created with cloudServiceConfiguration, or with virtualMachineConfiguration using a Windows image reference). Common store names include: My, Root, CA, Trust, Disallowed, TrustedPeople, TrustedPublisher, AuthRoot, AddressBook, but any custom store name can also be used. The default value is My.
  - `[Visibility <CertificateVisibility[]>]`: Which user accounts on the compute node should have access to the private data of the certificate.

DEPLOYMENTCONFIGURATION <IDeploymentConfiguration>: Using CloudServiceConfiguration specifies that the nodes should be creating using Azure Cloud Services (PaaS), while VirtualMachineConfiguration uses Azure Virtual Machines (IaaS).
  - `[CloudServiceConfigurationOSFamily <String>]`: Possible values are: 2 - OS Family 2, equivalent to Windows Server 2008 R2 SP1. 3 - OS Family 3, equivalent to Windows Server 2012. 4 - OS Family 4, equivalent to Windows Server 2012 R2. 5 - OS Family 5, equivalent to Windows Server 2016. 6 - OS Family 6, equivalent to Windows Server 2019. For more information, see Azure Guest OS Releases (https://azure.microsoft.com/documentation/articles/cloud-services-guestos-update-matrix/#releases).
  - `[CloudServiceConfigurationOSVersion <String>]`: The default value is * which specifies the latest operating system version for the specified OS family.
  - `[ContainerConfigurationContainerImageName <String[]>]`: This is the full image reference, as would be specified to "docker pull". An image will be sourced from the default Docker registry unless the image is fully qualified with an alternative registry.
  - `[ContainerConfigurationContainerRegistry <IContainerRegistry[]>]`: If any images must be downloaded from a private registry which requires credentials, then those credentials must be provided here.
    - `[IdentityReferenceResourceId <String>]`: The ARM resource id of the user assigned identity.
    - `[Password <String>]`: The password to log into the registry server.
    - `[RegistryServer <String>]`: If omitted, the default is "docker.io".
    - `[UserName <String>]`: The user name to log into the registry server.
  - `[DiskEncryptionConfigurationTarget <DiskEncryptionTarget[]>]`: On Linux pool, only "TemporaryDisk" is supported; on Windows pool, "OsDisk" and "TemporaryDisk" must be specified.
  - `[EphemeralOSDiskSettingPlacement <DiffDiskPlacement?>]`: This property can be used by user in the request to choose which location the operating system should be in. e.g., cache disk space for Ephemeral OS disk provisioning. For more information on Ephemeral OS disk size requirements, please refer to Ephemeral OS disk size requirements for Windows VMs at https://docs.microsoft.com/en-us/azure/virtual-machines/windows/ephemeral-os-disks#size-requirements and Linux VMs at https://docs.microsoft.com/en-us/azure/virtual-machines/linux/ephemeral-os-disks#size-requirements.
  - `[ImageReferenceId <String>]`: This property is mutually exclusive with other properties. The Shared Image Gallery image must have replicas in the same region as the Azure Batch account. For information about the firewall settings for the Batch node agent to communicate with the Batch service see https://docs.microsoft.com/en-us/azure/batch/batch-api-basics#virtual-network-vnet-and-firewall-configuration.
  - `[ImageReferenceOffer <String>]`: For example, UbuntuServer or WindowsServer.
  - `[ImageReferencePublisher <String>]`: For example, Canonical or MicrosoftWindowsServer.
  - `[ImageReferenceSku <String>]`: For example, 18.04-LTS or 2022-datacenter.
  - `[ImageReferenceVersion <String>]`: A value of 'latest' can be specified to select the latest version of an image. If omitted, the default is 'latest'.
  - `[NodePlacementConfigurationPolicy <NodePlacementPolicyType?>]`: Allocation policy used by Batch Service to provision the nodes. If not specified, Batch will use the regional policy.
  - `[VirtualMachineConfigurationDataDisk <IDataDisk[]>]`: This property must be specified if the compute nodes in the pool need to have empty data disks attached to them.
    - `DiskSizeGb <Int32>`: The initial disk size in GB when creating new data disk.
    - `Lun <Int32>`: The lun is used to uniquely identify each data disk. If attaching multiple disks, each should have a distinct lun. The value must be between 0 and 63, inclusive.
    - `[Caching <CachingType?>]`: Values are:           none - The caching mode for the disk is not enabled.          readOnly - The caching mode for the disk is read only.          readWrite - The caching mode for the disk is read and write.           The default value for caching is none. For information about the caching options see: https://blogs.msdn.microsoft.com/windowsazurestorage/2012/06/27/exploring-windows-azure-drives-disks-and-images/.
    - `[StorageAccountType <StorageAccountType?>]`: If omitted, the default is "Standard_LRS". Values are:           Standard_LRS - The data disk should use standard locally redundant storage.          Premium_LRS - The data disk should use premium locally redundant storage.
  - `[VirtualMachineConfigurationExtension <IVMExtension[]>]`: If specified, the extensions mentioned in this configuration will be installed on each node.
    - `Name <String>`: The name of the virtual machine extension.
    - `Publisher <String>`: The name of the extension handler publisher.
    - `Type <String>`: The type of the extensions.
    - `[AutoUpgradeMinorVersion <Boolean?>]`: Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
    - `[ProtectedSetting <IAny>]`: The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all. 
    - `[ProvisionAfterExtension <String[]>]`: Collection of extension names after which this extension needs to be provisioned.
    - `[Setting <IAny>]`: Any object
    - `[TypeHandlerVersion <String>]`: The version of script handler.
  - `[VirtualMachineConfigurationLicenseType <String>]`: This only applies to images that contain the Windows operating system, and should only be used when you hold valid on-premises licenses for the nodes which will be deployed. If omitted, no on-premises licensing discount is applied. Values are:           Windows_Server - The on-premises license is for Windows Server.          Windows_Client - The on-premises license is for Windows Client.         
  - `[VirtualMachineConfigurationNodeAgentSkuId <String>]`: The Batch node agent is a program that runs on each node in the pool, and provides the command-and-control interface between the node and the Batch service. There are different implementations of the node agent, known as SKUs, for different operating systems. You must specify a node agent SKU which matches the selected image reference. To get the list of supported node agent SKUs along with their list of verified image references, see the 'List supported node agent SKUs' operation.
  - `[WindowConfigurationEnableAutomaticUpdate <Boolean?>]`: If omitted, the default value is true.

ENDPOINTCONFIGURATIONINBOUNDNATPOOL <IInboundNatPool[]>: The maximum number of inbound NAT pools per Batch pool is 5. If the maximum number of inbound NAT pools is exceeded the request fails with HTTP status code 400. This cannot be specified if the IPAddressProvisioningType is NoPublicIPAddresses.
  - `BackendPort <Int32>`: This must be unique within a Batch pool. Acceptable values are between 1 and 65535 except for 22, 3389, 29876 and 29877 as these are reserved. If any reserved values are provided the request fails with HTTP status code 400.
  - `FrontendPortRangeEnd <Int32>`: Acceptable values range between 1 and 65534 except ports from 50000 to 55000 which are reserved by the Batch service. All ranges within a pool must be distinct and cannot overlap. If any reserved or overlapping values are provided the request fails with HTTP status code 400.
  - `FrontendPortRangeStart <Int32>`: Acceptable values range between 1 and 65534 except ports from 50000 to 55000 which are reserved. All ranges within a pool must be distinct and cannot overlap. If any reserved or overlapping values are provided the request fails with HTTP status code 400.
  - `Name <String>`: The name must be unique within a Batch pool, can contain letters, numbers, underscores, periods, and hyphens. Names must start with a letter or number, must end with a letter, number, or underscore, and cannot exceed 77 characters.  If any invalid values are provided the request fails with HTTP status code 400.
  - `Protocol <InboundEndpointProtocol>`: The protocol of the endpoint.
  - `[NetworkSecurityGroupRule <INetworkSecurityGroupRule[]>]`: The maximum number of rules that can be specified across all the endpoints on a Batch pool is 25. If no network security group rules are specified, a default rule will be created to allow inbound access to the specified backendPort. If the maximum number of network security group rules is exceeded the request fails with HTTP status code 400.
    - `Access <NetworkSecurityGroupRuleAccess>`: The action that should be taken for a specified IP address, subnet range or tag.
    - `Priority <Int32>`: Priorities within a pool must be unique and are evaluated in order of priority. The lower the number the higher the priority. For example, rules could be specified with order numbers of 150, 250, and 350. The rule with the order number of 150 takes precedence over the rule that has an order of 250. Allowed priorities are 150 to 4096. If any reserved or duplicate values are provided the request fails with HTTP status code 400.
    - `SourceAddressPrefix <String>`: Valid values are a single IP address (i.e. 10.10.10.10), IP subnet (i.e. 192.168.1.0/24), default tag, or * (for all addresses).  If any other values are provided the request fails with HTTP status code 400.
    - `[SourcePortRange <String[]>]`: Valid values are '*' (for all ports 0 - 65535) or arrays of ports or port ranges (i.e. 100-200). The ports should in the range of 0 to 65535 and the port ranges or ports can't overlap. If any other values are provided the request fails with HTTP status code 400. Default value will be *.

INPUTOBJECT <IBatchIdentity>: Identity Parameter
  - `[AccountName <String>]`: A name for the Batch account which must be unique within the region. Batch account names must be between 3 and 24 characters in length and must use only numbers and lowercase letters. This name is used as part of the DNS name that is used to access the Batch service in the region in which the account is created. For example: http://accountname.region.batch.azure.com/.
  - `[ApplicationName <String>]`: The name of the application. This must be unique within the account.
  - `[CertificateName <String>]`: The identifier for the certificate. This must be made up of algorithm and thumbprint separated by a dash, and must match the certificate data in the request. For example SHA1-a3d1c5.
  - `[DetectorId <String>]`: The name of the detector.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The region for which to retrieve Batch service quotas.
  - `[PoolName <String>]`: The pool name. This must be unique within the account.
  - `[PrivateEndpointConnectionName <String>]`: The private endpoint connection name. This must be unique within the account.
  - `[PrivateLinkResourceName <String>]`: The private link resource name. This must be unique within the account.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the Batch account.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)
  - `[VersionName <String>]`: The version of the application.

METADATA <IMetadataItem[]>: The Batch service does not assign any meaning to metadata; it is solely for the use of user code.
  - `Name <String>`: The name of the metadata item.
  - `Value <String>`: The value of the metadata item.

MOUNTCONFIGURATION <IMountConfiguration[]>: This supports Azure Files, NFS, CIFS/SMB, and Blobfuse.
  - `[AzureBlobFileSystemConfigurationAccountKey <String>]`: This property is mutually exclusive with both sasKey and identity; exactly one must be specified.
  - `[AzureBlobFileSystemConfigurationAccountName <String>]`: The Azure Storage Account name.
  - `[AzureBlobFileSystemConfigurationBlobfuseOption <String>]`: These are 'net use' options in Windows and 'mount' options in Linux.
  - `[AzureBlobFileSystemConfigurationContainerName <String>]`: The Azure Blob Storage Container name.
  - `[AzureBlobFileSystemConfigurationRelativeMountPath <String>]`: All file systems are mounted relative to the Batch mounts directory, accessible via the AZ_BATCH_NODE_MOUNTS_DIR environment variable.
  - `[AzureBlobFileSystemConfigurationSasKey <String>]`: This property is mutually exclusive with both accountKey and identity; exactly one must be specified.
  - `[AzureFileShareConfigurationAccountKey <String>]`: The Azure Storage account key.
  - `[AzureFileShareConfigurationAccountName <String>]`: The Azure Storage account name.
  - `[AzureFileShareConfigurationAzureFileUrl <String>]`: This is of the form 'https://{account}.file.core.windows.net/'.
  - `[AzureFileShareConfigurationMountOption <String>]`: These are 'net use' options in Windows and 'mount' options in Linux.
  - `[AzureFileShareConfigurationRelativeMountPath <String>]`: All file systems are mounted relative to the Batch mounts directory, accessible via the AZ_BATCH_NODE_MOUNTS_DIR environment variable.
  - `[CifMountConfigurationMountOption <String>]`: These are 'net use' options in Windows and 'mount' options in Linux.
  - `[CifMountConfigurationPassword <String>]`: The password to use for authentication against the CIFS file system.
  - `[CifMountConfigurationRelativeMountPath <String>]`: All file systems are mounted relative to the Batch mounts directory, accessible via the AZ_BATCH_NODE_MOUNTS_DIR environment variable.
  - `[CifMountConfigurationSource <String>]`: The URI of the file system to mount.
  - `[CifMountConfigurationUsername <String>]`: The user to use for authentication against the CIFS file system.
  - `[IdentityReferenceResourceId <String>]`: The ARM resource id of the user assigned identity.
  - `[NfMountConfigurationMountOption <String>]`: These are 'net use' options in Windows and 'mount' options in Linux.
  - `[NfMountConfigurationRelativeMountPath <String>]`: All file systems are mounted relative to the Batch mounts directory, accessible via the AZ_BATCH_NODE_MOUNTS_DIR environment variable.
  - `[NfMountConfigurationSource <String>]`: The URI of the file system to mount.

STARTTASKENVIRONMENTSETTING <IEnvironmentSetting[]>: A list of environment variable settings for the start task.
  - `Name <String>`: The name of the environment variable.
  - `[Value <String>]`: The value of the environment variable.

STARTTASKRESOURCEFILE <IResourceFile[]>: A list of files that the Batch service will download to the compute node before running the command line.
  - `[AutoStorageContainerName <String>]`: The autoStorageContainerName, storageContainerUrl and httpUrl properties are mutually exclusive and one of them must be specified.
  - `[BlobPrefix <String>]`: The property is valid only when autoStorageContainerName or storageContainerUrl is used. This prefix can be a partial filename or a subdirectory. If a prefix is not specified, all the files in the container will be downloaded.
  - `[FileMode <String>]`: This property applies only to files being downloaded to Linux compute nodes. It will be ignored if it is specified for a resourceFile which will be downloaded to a Windows node. If this property is not specified for a Linux node, then a default value of 0770 is applied to the file.
  - `[FilePath <String>]`: If the httpUrl property is specified, the filePath is required and describes the path which the file will be downloaded to, including the filename. Otherwise, if the autoStorageContainerName or storageContainerUrl property is specified, filePath is optional and is the directory to download the files to. In the case where filePath is used as a directory, any directory structure already associated with the input data will be retained in full and appended to the specified filePath directory. The specified relative path cannot break out of the task's working directory (for example by using '..').
  - `[HttpUrl <String>]`: The autoStorageContainerName, storageContainerUrl and httpUrl properties are mutually exclusive and one of them must be specified. If the URL points to Azure Blob Storage, it must be readable from compute nodes. There are three ways to get such a URL for a blob in Azure storage: include a Shared Access Signature (SAS) granting read permissions on the blob, use a managed identity with read permission, or set the ACL for the blob or its container to allow public access.
  - `[IdentityReferenceResourceId <String>]`: The ARM resource id of the user assigned identity.
  - `[StorageContainerUrl <String>]`: The autoStorageContainerName, storageContainerUrl and httpUrl properties are mutually exclusive and one of them must be specified. This URL must be readable and listable from compute nodes. There are three ways to get such a URL for a container in Azure storage: include a Shared Access Signature (SAS) granting read and list permissions on the container, use a managed identity with read and list permissions, or set the ACL for the container to allow public access.

USERACCOUNT <IUserAccount[]>: The list of user accounts to be created on each node in the pool.
  - `Name <String>`: The name of the user account.
  - `Password <String>`: The password for the user account.
  - `[ElevationLevel <ElevationLevel?>]`: nonAdmin - The auto user is a standard user without elevated access. admin - The auto user is a user with elevated access and operates with full Administrator permissions. The default value is nonAdmin.
  - `[LinuxUserConfigurationGid <Int32?>]`: The uid and gid properties must be specified together or not at all. If not specified the underlying operating system picks the gid.
  - `[LinuxUserConfigurationSshPrivateKey <String>]`: The private key must not be password protected. The private key is used to automatically configure asymmetric-key based authentication for SSH between nodes in a Linux pool when the pool's enableInterNodeCommunication property is true (it is ignored if enableInterNodeCommunication is false). It does this by placing the key pair into the user's .ssh directory. If not specified, password-less SSH is not configured between nodes (no modification of the user's .ssh directory is done).
  - `[LinuxUserConfigurationUid <Int32?>]`: The uid and gid properties must be specified together or not at all. If not specified the underlying operating system picks the uid.
  - `[WindowUserConfigurationLoginMode <LoginMode?>]`: Specifies login mode for the user. The default value for VirtualMachineConfiguration pools is interactive mode and for CloudServiceConfiguration pools is batch mode.

## RELATED LINKS

