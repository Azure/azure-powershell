---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Aks.dll-Help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/set-azakscluster
schema: 2.0.0
---

# Set-AzAksCluster

## SYNOPSIS
Update or create a managed Kubernetes cluster.

## SYNTAX

### defaultParameterSet (Default)
```
Set-AzAksCluster [-NodePoolMode <String>] [-AcrNameToDetach <String>] [-NodeImageOnly] [-ControlPlaneOnly]
 [-AutoScalerProfile <ManagedClusterPropertiesAutoScalerProfile>] [-EnableUptimeSLA] [-EnableOidcIssuer]
 [-ResourceGroupName] <String> [-Name] <String> [[-ServicePrincipalIdAndSecret] <PSCredential>]
 [-Location <String>] [-LinuxProfileAdminUserName <String>] [-DnsNamePrefix <String>]
 [-KubernetesVersion <String>] [-NodeName <String>] [-NodeMinCount <Int32>] [-NodeMaxCount <Int32>]
 [-EnableNodeAutoScaling] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>] [-NodeVmSize <String>]
 [-NodePoolLabel <Hashtable>] [-NodePoolTag <Hashtable>] [-SshKeyValue <String>] [-AcrNameToAttach <String>]
 [-AsJob] [-Tag <Hashtable>] [-LoadBalancerAllocatedOutboundPort <Int32>]
 [-LoadBalancerManagedOutboundIpCount <Int32>] [-LoadBalancerOutboundIp <String[]>]
 [-LoadBalancerOutboundIpPrefix <String[]>] [-LoadBalancerIdleTimeoutInMinute <Int32>]
 [-ApiServerAccessAuthorizedIpRange <String[]>] [-EnableApiServerAccessPrivateCluster]
 [-ApiServerAccessPrivateDnsZone <String>] [-EnableApiServerAccessPrivateClusterPublicFQDN]
 [-FqdnSubdomain <String>] [-EnableManagedIdentity] [-AssignIdentity <String>] [-AutoUpgradeChannel <String>]
 [-DiskEncryptionSetID <String>] [-DisableLocalAccount] [-HttpProxy <String>] [-HttpsProxy <String>]
 [-HttpProxyConfigNoProxyEndpoint <String[]>] [-HttpProxyConfigTrustedCa <String>]
 [-AksCustomHeader <Hashtable>] [-AadProfile <ManagedClusterAADProfile>]
 [-WindowsProfileAdminUserPassword <SecureString>] [-EnableAHUB] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Set-AzAksCluster -InputObject <PSKubernetesCluster> [-NodePoolMode <String>] [-AcrNameToDetach <String>]
 [-NodeImageOnly] [-ControlPlaneOnly] [-AutoScalerProfile <ManagedClusterPropertiesAutoScalerProfile>]
 [-EnableUptimeSLA] [-EnableOidcIssuer] [-Location <String>] [-LinuxProfileAdminUserName <String>]
 [-DnsNamePrefix <String>] [-KubernetesVersion <String>] [-NodeName <String>] [-NodeMinCount <Int32>]
 [-NodeMaxCount <Int32>] [-EnableNodeAutoScaling] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>]
 [-NodeVmSize <String>] [-NodePoolLabel <Hashtable>] [-NodePoolTag <Hashtable>] [-SshKeyValue <String>]
 [-AcrNameToAttach <String>] [-AsJob] [-Tag <Hashtable>] [-LoadBalancerAllocatedOutboundPort <Int32>]
 [-LoadBalancerManagedOutboundIpCount <Int32>] [-LoadBalancerOutboundIp <String[]>]
 [-LoadBalancerOutboundIpPrefix <String[]>] [-LoadBalancerIdleTimeoutInMinute <Int32>]
 [-ApiServerAccessAuthorizedIpRange <String[]>] [-EnableApiServerAccessPrivateCluster]
 [-ApiServerAccessPrivateDnsZone <String>] [-EnableApiServerAccessPrivateClusterPublicFQDN]
 [-FqdnSubdomain <String>] [-EnableManagedIdentity] [-AssignIdentity <String>] [-AutoUpgradeChannel <String>]
 [-DiskEncryptionSetID <String>] [-DisableLocalAccount] [-HttpProxy <String>] [-HttpsProxy <String>]
 [-HttpProxyConfigNoProxyEndpoint <String[]>] [-HttpProxyConfigTrustedCa <String>]
 [-AksCustomHeader <Hashtable>] [-AadProfile <ManagedClusterAADProfile>]
 [-WindowsProfileAdminUserPassword <SecureString>] [-EnableAHUB] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### IdParameterSet
```
Set-AzAksCluster [-NodePoolMode <String>] [-AcrNameToDetach <String>] [-NodeImageOnly] [-ControlPlaneOnly]
 [-Id] <String> [-AutoScalerProfile <ManagedClusterPropertiesAutoScalerProfile>] [-EnableUptimeSLA]
 [-EnableOidcIssuer] [-Location <String>] [-LinuxProfileAdminUserName <String>] [-DnsNamePrefix <String>]
 [-KubernetesVersion <String>] [-NodeName <String>] [-NodeMinCount <Int32>] [-NodeMaxCount <Int32>]
 [-EnableNodeAutoScaling] [-NodeCount <Int32>] [-NodeOsDiskSize <Int32>] [-NodeVmSize <String>]
 [-NodePoolLabel <Hashtable>] [-NodePoolTag <Hashtable>] [-SshKeyValue <String>] [-AcrNameToAttach <String>]
 [-AsJob] [-Tag <Hashtable>] [-LoadBalancerAllocatedOutboundPort <Int32>]
 [-LoadBalancerManagedOutboundIpCount <Int32>] [-LoadBalancerOutboundIp <String[]>]
 [-LoadBalancerOutboundIpPrefix <String[]>] [-LoadBalancerIdleTimeoutInMinute <Int32>]
 [-ApiServerAccessAuthorizedIpRange <String[]>] [-EnableApiServerAccessPrivateCluster]
 [-ApiServerAccessPrivateDnsZone <String>] [-EnableApiServerAccessPrivateClusterPublicFQDN]
 [-FqdnSubdomain <String>] [-EnableManagedIdentity] [-AssignIdentity <String>] [-AutoUpgradeChannel <String>]
 [-DiskEncryptionSetID <String>] [-DisableLocalAccount] [-HttpProxy <String>] [-HttpsProxy <String>]
 [-HttpProxyConfigNoProxyEndpoint <String[]>] [-HttpProxyConfigTrustedCa <String>]
 [-AksCustomHeader <Hashtable>] [-AadProfile <ManagedClusterAADProfile>]
 [-WindowsProfileAdminUserPassword <SecureString>] [-EnableAHUB] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Update or create a managed Kubernetes cluster.

## EXAMPLES

### Example 1:
```powershell
Get-AzAksCluster -ResourceGroupName group -Name myCluster | Set-AzAksCluster -NodeCount 5
```

Set the number of nodes in the Kubernetes cluster to 5.

### Example 2: Update an AKS cluster with AutoScalerProfile.
When you update an AKS cluster, you can configure granular details of the cluster autoscaler by changing the default values in the cluster-wide autoscaler profile.

```powershell
$AutoScalerProfile=@{
    ScanInterval="40s"
    Expander="priority"
}
$AutoScalerProfile=[Microsoft.Azure.Management.ContainerService.Models.ManagedClusterPropertiesAutoScalerProfile]$AutoScalerProfile

Get-AzAksCluster -ResourceGroupName group -Name myCluster | Set-AzAksCluster -AutoScalerProfile $AutoScalerProfile
```

### Example 3: Update an AKS cluster with AadProfile.
When you update an AKS cluster, you can configure the AAD profile.

```powershell
$AKSAdminGroup=New-AzADGroup -DisplayName myAKSAdminGroup -MailNickname myAKSAdminGroup
$AadProfile=@{
    managed=$true
    enableAzureRBAC=$false
    adminGroupObjectIDs=[System.Collections.Generic.List[string]]@($AKSAdminGroup.Id)
}
$AadProfile=[Microsoft.Azure.Management.ContainerService.Models.ManagedClusterAADProfile]$AadProfile

Set-AzAksCluster -ResourceGroupName myResourceGroup -Name myAKSCluster -AadProfile $AadProfile
```

## PARAMETERS

### -AadProfile
The Azure Active Directory configuration.

```yaml
Type: Microsoft.Azure.Management.ContainerService.Models.ManagedClusterAADProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AcrNameToAttach
Grant the 'acrpull' role of the specified ACR to AKS Service Principal, e.g. myacr

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

### -AcrNameToDetach
Disable the 'acrpull' role assignment to the ACR specified by name or resource ID, e.g. myacr

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

### -AksCustomHeader
Aks custom headers used for building Kubernetes network.

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

### -ApiServerAccessAuthorizedIpRange
The IP ranges authorized to access the Kubernetes API server.

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

### -ApiServerAccessPrivateDnsZone
The private DNS zone mode for the cluster.

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

### -AsJob
Run cmdlet in the background

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

### -AssignIdentity
ResourceId of user assign managed identity for cluster.

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

### -AutoScalerProfile
The parameters to be applied to the cluster-autoscaler.

```yaml
Type: Microsoft.Azure.Management.ContainerService.Models.ManagedClusterPropertiesAutoScalerProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoUpgradeChannel
The upgrade channel for auto upgrade. For more information see https://learn.microsoft.com/azure/aks/upgrade-cluster#set-auto-upgrade-channel.

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

### -ControlPlaneOnly
Will only upgrade control plane to target version.

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
```

### -DisableLocalAccount
Local accounts should be disabled on the Managed Cluster.

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

### -DiskEncryptionSetID
The resource ID of the disk encryption set to use for enabling encryption.

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

### -DnsNamePrefix
The DNS name prefix for the cluster.

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

### -EnableAHUB
Whether to enable Azure Hybrid User Benefits (AHUB) for Windows VMs.

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

### -EnableApiServerAccessPrivateCluster
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
```

### -EnableApiServerAccessPrivateClusterPublicFQDN
Whether to create additional public FQDN for private cluster or not.

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

### -EnableManagedIdentity
Using a managed identity to manage cluster resource group.

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

### -EnableNodeAutoScaling
Whether to enable auto-scaler

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

### -EnableOidcIssuer
Whether to enalbe OIDC issuer feature.

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

### -EnableUptimeSLA
Whether to use use Uptime SLA.

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

### -FqdnSubdomain
The FQDN subdomain of the private cluster with custom private dns zone.

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

### -HttpProxy
The HTTP proxy server endpoint to use.

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

### -HttpProxyConfigNoProxyEndpoint
The endpoints that should not go through proxy.

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

### -HttpProxyConfigTrustedCa
Alternative CA cert to use for connecting to proxy servers.

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

### -HttpsProxy
The HTTPS proxy server endpoint to use

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
```

### -InputObject
A PSKubernetesCluster object, normally passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KubernetesVersion
The version of Kubernetes to use for creating the cluster.

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

### -LinuxProfileAdminUserName
User name for the Linux Virtual Machines.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AdminUserName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancerAllocatedOutboundPort
The desired number of allocated SNAT ports per VM.

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

### -LoadBalancerIdleTimeoutInMinute
Desired outbound flow idle timeout in minutes.

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

### -LoadBalancerManagedOutboundIpCount
Desired managed outbound IPs count for the cluster load balancer.

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

### -LoadBalancerOutboundIp
Desired outbound IP resources for the cluster load balancer.

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

### -LoadBalancerOutboundIpPrefix
Desired outbound IP Prefix resources for the cluster load balancer.

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

### -Location
Azure location for the cluster.
Defaults to the location of the resource group.

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
Kubernetes managed cluster Name.

```yaml
Type: System.String
Parameter Sets: defaultParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -NodeImageOnly
Will only upgrade the node image of agent pools.

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

### -NodeMaxCount
Maximum number of nodes for auto-scaling

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

### -NodeMinCount
Minimum number of nodes for auto-scaling.

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

### -NodeName
Unique name of the agent pool profile in the context of the subscription and resource group.

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

### -NodeOsDiskSize
Specifies the size, in GB, of the operating system disk.

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

### -NodePoolLabel
Node pool labels used for building Kubernetes network.

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

### -NodePoolMode
NodePoolMode represents mode of an node pool.

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

### -NodePoolTag
The tags to be persisted on the agent pool virtual machine scale set.

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
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: defaultParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalIdAndSecret
The client id and client secret associated with the AAD application / service principal.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: defaultParameterSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -SubscriptionId
The ID of the subscription.
By default, cmdlets are executed in the subscription that is set in the current context. If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.
Overriding subscriptions only take effect during the lifecycle of the current cmdlet. It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Tags to be applied to the resource

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

### -WindowsProfileAdminUserPassword
The administrator password to use for Windows VMs. Password requirement:At least one lower case, one upper case, one special character !@#$%^&*(), the minimum lenth is 12.

```yaml
Type: System.Security.SecureString
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

### Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Aks.Models.PSKubernetesCluster

## NOTES

## RELATED LINKS
