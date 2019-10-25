---
external help file:
Module Name: Az.Aks
online version: https://docs.microsoft.com/en-us/powershell/module/az.aks/get-azaks
schema: 2.0.0
---

# Get-AzAks

## SYNOPSIS
Gets the details of the managed cluster with a specified resource group and name.

## SYNTAX

### List (Default)
```
Get-AzAks [-SubscriptionId <String[]>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GroupNameParameterSet
```
Get-AzAks [-ResourceGroupName] <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IdParameterSet
```
Get-AzAks [-Id] <String> [-SubscriptionId <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Get-AzAks -InputObject <IManagedCluster> [-SubscriptionId <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NameParameterSet
```
Get-AzAks [-ResourceGroupName] <String> [-Name] <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the details of the managed cluster with a specified resource group and name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -Id
Id of a managed Kubernetes cluster

```yaml
Type: System.String
Parameter Sets: IdParameterSet
Aliases: ResourceId

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
A PSKubernetesCluster object, normally passed through the pipeline.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IManagedCluster
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: GroupNameParameterSet, NameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IManagedCluster

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IManagedCluster

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IManagedCluster>: A PSKubernetesCluster object, normally passed through the pipeline.
  - `Location <String>`: Resource location
  - `AadProfileClientAppId <String>`: The client AAD application ID.
  - `AadProfileServerAppId <String>`: The server AAD application ID.
  - `LinuxProfileAdminUsername <String>`: The administrator username to use for Linux VMs.
  - `ServicePrincipalProfileClientId <String>`: The ID for the service principal.
  - `SshPublicKey <IContainerServiceSshPublicKey[]>`: The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
    - `KeyData <String>`: Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without headers.
  - `WindowProfileAdminUsername <String>`: The administrator username to use for Windows VMs.
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AadProfileServerAppSecret <String>]`: The server AAD application secret.
  - `[AadProfileTenantId <String>]`: The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
  - `[AddonProfile <IManagedClusterPropertiesAddonProfiles>]`: Profile of managed cluster add-on.
    - `[(Any) <IManagedClusterAddonProfile>]`: This indicates any property can be added to this object.
  - `[AgentPoolProfile <IManagedClusterAgentPoolProfile[]>]`: Properties of the agent pool.
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
  - `[ApiServerAccessProfileAuthorizedIPRange <String[]>]`: Authorized IP Ranges to kubernetes API server.
  - `[ApiServerAccessProfileEnablePrivateCluster <Boolean?>]`: Whether to create the cluster as a private cluster or not.
  - `[DnsPrefix <String>]`: DNS prefix specified when creating the managed cluster.
  - `[EnablePodSecurityPolicy <Boolean?>]`: (PREVIEW) Whether to enable Kubernetes Pod security policy.
  - `[EnableRbac <Boolean?>]`: Whether to enable Kubernetes Role-Based Access Control.
  - `[IdentityType <ResourceIdentityType?>]`: The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI for the managed cluster, service principal will be used instead.
  - `[KubernetesVersion <String>]`: Version of Kubernetes specified when creating the managed cluster.
  - `[LoadBalancerProfileEffectiveOutboundIP <IResourceReference[]>]`: The effective outbound IP resources of the cluster load balancer.
    - `[Id <String>]`: The fully qualified Azure resource id.
  - `[ManagedOutboundIPCount <Int32?>]`: Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. 
  - `[NetworkProfileDnsServiceIP <String>]`: An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified in serviceCidr.
  - `[NetworkProfileDockerBridgeCidr <String>]`: A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range.
  - `[NetworkProfileLoadBalancerSku <LoadBalancerSku?>]`: The load balancer sku for the managed cluster.
  - `[NetworkProfileNetworkPlugin <NetworkPlugin?>]`: Network plugin used for building Kubernetes network.
  - `[NetworkProfileNetworkPolicy <NetworkPolicy?>]`: Network policy used for building Kubernetes network.
  - `[NetworkProfilePodCidr <String>]`: A CIDR notation IP range from which to assign pod IPs when kubenet is used.
  - `[NetworkProfileServiceCidr <String>]`: A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
  - `[NodeResourceGroup <String>]`: Name of the resource group containing agent pool nodes.
  - `[OutboundIPPrefixPublicIpprefix <IResourceReference[]>]`: A list of public IP prefix resources.
  - `[OutboundIPPublicIP <IResourceReference[]>]`: A list of public IP resources.
  - `[ServicePrincipalProfileSecret <String>]`: The secret password associated with the service principal in plain text.
  - `[WindowProfileAdminPassword <String>]`: The administrator password to use for Windows VMs.

## RELATED LINKS

