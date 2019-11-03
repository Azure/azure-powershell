---
external help file:
Module Name: Az.Aks
online version: https://docs.microsoft.com/en-us/powershell/module/az.aks/new-azaks
schema: 2.0.0
---

# New-AzAks

## SYNOPSIS
Creates a managed cluster with the specified configuration for agents and Kubernetes version.

## SYNTAX

```
New-AzAks [-ResourceGroupName] <String> [-Name] <String> [-SubscriptionId <String>]
 [-AadProfileClientAppId <String>] [-AadProfileServerAppId <String>] [-AadProfileServerAppSecret <String>]
 [-AadProfileTenantId <String>] [-AddOnProfile <Hashtable>]
 [-AgentPoolProfile <IManagedClusterAgentPoolProfile[]>] [-AuthorizedIPRange <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-DnsPrefix <String>] [-DnsServiceIP <String>]
 [-DockerBridgeCidr <String>] [-EnablePodSecurityPolicy] [-EnablePrivateCluster] [-EnableRbac]
 [-IdentityType <ResourceIdentityType>] [-KubernetesVersion <String>] [-LinuxProfileAdminUsername <String>]
 [-LoadBalancerProfileEffectiveOutboundIP <IResourceReference[]>] [-LoadBalancerSku <LoadBalancerSku>]
 [-Location <String>] [-ManagedOutboundIPCount <Int32>] [-NetworkPlugin <NetworkPlugin>]
 [-NetworkPolicy <NetworkPolicy>] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>] [-NodeResourceGroup <String>]
 [-NodeVmSize <String>] [-OutboundIPPrefixPublicIpprefix <IResourceReference[]>]
 [-OutboundIPPublicIP <IResourceReference[]>] [-PodCidr <String>] [-ServiceCidr <String>]
 [-ServicePrincipalProfileClientId <String>] [-ServicePrincipalProfileSecret <String>] [-SshKeyValue <String>]
 [-SshPublicKey <IContainerServiceSshPublicKey[]>] [-Tag <Hashtable>]
 [-WindowProfileAdminPassword <SecureString>] [-WindowProfileAdminUsername <String>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a managed cluster with the specified configuration for agents and Kubernetes version.

## EXAMPLES

### Example 1:
```powershell
PS C:\> New-AzAks -ResourceGroupName group -Name myCluster
```

Create a new managed Kubernetes cluster with default params

### Example 2:
```powershell
PS C:\> $addOn = @{enabled=$true}
PS C:\> $addonProfile = @{additionalProperties=($addOn)}
PS C:\> New-AzAks -ResourceGroupName group -Name myCluster -AddOnProfile $addonProfile
```

Create a new managed Kubernetes cluster with AddOnProfile

## PARAMETERS

### -AadProfileClientAppId
The client AAD application ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AadProfileServerAppId
The server AAD application ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AadProfileServerAppSecret
The server AAD application secret.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AadProfileTenantId
The AAD tenant ID to use for authentication.
If not specified, will use the tenant of the deployment subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AddOnProfile
Profile of managed cluster add-on.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AgentPoolProfile
Properties of the agent pool.
To construct, see NOTES section for AGENTPOOLPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedClusterAgentPoolProfile[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -AuthorizedIPRange
Authorized IP Ranges to kubernetes API server.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DnsPrefix
DNS prefix specified when creating the managed cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DnsServiceIP
An IP address assigned to the Kubernetes DNS service.
It must be within the Kubernetes service address range specified in serviceCidr.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DockerBridgeCidr
A CIDR notation IP range assigned to the Docker bridge network.
It must not overlap with any Subnet IP ranges or the Kubernetes service address range.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnablePodSecurityPolicy
(PREVIEW) Whether to enable Kubernetes Pod security policy.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnablePrivateCluster
Whether to create the cluster as a private cluster or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableRbac
Whether to enable Kubernetes Role-Based Access Control.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
The type of identity used for the managed cluster.
Type 'SystemAssigned' will use an implicitly created identity in master components and an auto-created user assigned identity in MC_ resource group in agent nodes.
Type 'None' will not use MSI for the managed cluster, service principal will be used instead.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KubernetesVersion
Version of Kubernetes specified when creating the managed cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LinuxProfileAdminUsername
The administrator username to use for Linux VMs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerProfileEffectiveOutboundIP
The effective outbound IP resources of the cluster load balancer.
To construct, see NOTES section for LOADBALANCERPROFILEEFFECTIVEOUTBOUNDIP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerSku
The load balancer sku for the managed cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedOutboundIPCount
Desired number of outbound IP created/managed by Azure for the cluster load balancer.
Allowed values must be in the range of 1 to 100 (inclusive).
The default value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkPlugin
Network plugin used for building Kubernetes network.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkPolicy
Network policy used for building Kubernetes network.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NodeCount
The default number of nodes for the node pools.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NodeOsDiskSize
The default number of nodes for the node pools.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NodeResourceGroup
Name of the resource group containing agent pool nodes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NodeVmSize
The size of the Virtual Machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -OutboundIPPrefixPublicIpprefix
A list of public IP prefix resources.
To construct, see NOTES section for OUTBOUNDIPPREFIXPUBLICIPPREFIX properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OutboundIPPublicIP
A list of public IP resources.
To construct, see NOTES section for OUTBOUNDIPPUBLICIP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PodCidr
A CIDR notation IP range from which to assign pod IPs when kubenet is used.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServiceCidr
A CIDR notation IP range from which to assign service cluster IPs.
It must not overlap with any Subnet IP ranges.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServicePrincipalProfileClientId
The ID for the service principal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServicePrincipalProfileSecret
The secret password associated with the service principal in plain text.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SshKeyValue
SSH key file value or key file path.
Defaults to {HOME}/.ssh/id_rsa.pub.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SshKeyPath

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SshPublicKey
The list of SSH public keys used to authenticate with Linux-based VMs.
Only expect one key specified.
To construct, see NOTES section for SSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IContainerServiceSshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
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
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowProfileAdminPassword
The administrator password to use for Windows VMs.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowProfileAdminUsername
The administrator username to use for Windows VMs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20191001.IManagedCluster

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### AGENTPOOLPROFILE <IManagedClusterAgentPoolProfile[]>: Properties of the agent pool.
  - `Count <Int32>`: Number of agents (VMs) to host docker containers. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. 
  - `VMSize <ContainerServiceVMSizeTypes>`: Size of agent VMs.
  - `[AvailabilityZone <String[]>]`: (PREVIEW) Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.
  - `[EnableAutoScaling <Boolean?>]`: Whether to enable auto-scaler
  - `[EnableNodePublicIP <Boolean?>]`: Enable public IP for nodes
  - `[MaxCount <Int32?>]`: Maximum number of nodes for auto-scaling
  - `[MaxPod <Int32?>]`: Maximum number of pods that can run on a node.
  - `[MinCount <Int32?>]`: Minimum number of nodes for auto-scaling
  - `[NodeTaint <String[]>]`: Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
  - `[OSDiskSizeGb <Int32?>]`: OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.
  - `[OSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
  - `[OrchestratorVersion <String>]`: Version of orchestrator specified when creating the managed cluster.
  - `[ScaleSetEvictionPolicy <ScaleSetEvictionPolicy?>]`: ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set. Default to Delete.
  - `[ScaleSetPriority <ScaleSetPriority?>]`: ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
  - `[Type <AgentPoolType?>]`: AgentPoolType represents types of an agent pool
  - `[VnetSubnetId <String>]`: VNet SubnetID specifies the VNet's subnet identifier.
  - `[Name <String>]`: Unique name of the agent pool profile in the context of the subscription and resource group.

#### LOADBALANCERPROFILEEFFECTIVEOUTBOUNDIP <IResourceReference[]>: The effective outbound IP resources of the cluster load balancer.
  - `[Id <String>]`: The fully qualified Azure resource id.

#### OUTBOUNDIPPREFIXPUBLICIPPREFIX <IResourceReference[]>: A list of public IP prefix resources.
  - `[Id <String>]`: The fully qualified Azure resource id.

#### OUTBOUNDIPPUBLICIP <IResourceReference[]>: A list of public IP resources.
  - `[Id <String>]`: The fully qualified Azure resource id.

#### SSHPUBLICKEY <IContainerServiceSshPublicKey[]>: The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
  - `KeyData <String>`: Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without headers.

## RELATED LINKS

