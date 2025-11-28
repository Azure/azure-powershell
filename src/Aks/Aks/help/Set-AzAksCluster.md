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
 [-ResourceGroupName] <String> [-Name] <String> [-Location <String>] [-EnableManagedIdentity]
 [-AssignIdentity <String>] [-AadProfile <ManagedClusterAADProfile>] [-NodeCount <Int32>]
 [-EnableNodeAutoScaling] [-NodeMaxCount <Int32>] [-NodeMinCount <Int32>] [-NodeName <String>]
 [-NodePoolLabel <Hashtable>] [-NodeTaint <String[]>] [-NodeOsDiskSize <Int32>] [-NodePoolTag <Hashtable>]
 [-NodeVmSize <String>] [-NodeWorkloadRuntime <String>] [-EnableAIToolchainOperator]
 [-ApiServerAccessAuthorizedIpRange <String[]>] [-DisableApiServerRunCommand]
 [-EnableApiServerAccessPrivateCluster] [-EnableApiServerAccessPrivateClusterPublicFQDN]
 [-EnableApiServerVnetIntegration] [-ApiServerAccessPrivateDnsZone <String>] [-ApiServerSubnetId <String>]
 [-NodeOSAutoUpgradeChannel <String>] [-NodeAutoUpgradeChannel <String>] [-EnabledMonitorMetric]
 [-BootstrapArtifactSource <String>] [-BootstrapContainerRegistryId <String>] [-DisableLocalAccount]
 [-DiskEncryptionSetID <String>] [-DnsNamePrefix <String>] [-FqdnSubdomain <String>] [-HttpProxy <String>]
 [-HttpsProxy <String>] [-HttpProxyConfigNoProxyEndpoint <String[]>] [-HttpProxyConfigTrustedCa <String>]
 [-AssignKubeletIdentity <String>] [-KubernetesVersion <String>] [-LinuxProfileAdminUserName <String>]
 [-SshKeyValue <String>] [-EnableCostAnalysis] [-EnableAdvancedNetworking]
 [-EnableAdvancedNetworkingObservability] [-EnableAdvancedNetworkingSecurity]
 [-AdvancedNetworkingSecurityPolicy <String>] [-IPFamily <String[]>]
 [-LoadBalancerAllocatedOutboundPort <Int32>] [-LoadBalancerBackendPoolType <String>]
 [-EnableMultipleStandardLoadBalancer] [-LoadBalancerIdleTimeoutInMinute <Int32>]
 [-LoadBalancerManagedOutboundIpCount <Int32>] [-LoadBalancerManagedOutboundIpCountIPv6 <Int32>]
 [-LoadBalancerOutboundIpPrefix <String[]>] [-LoadBalancerOutboundIp <String[]>]
 [-NATGatewayIdleTimeoutInMinute <Int32>] [-NATGatewayManagedOutboundIpCount <Int32>]
 [-NetworkDataplane <String>] [-NetworkPluginMode <String>] [-EnabledStaticEgressGateway]
 [-NodeProvisioningMode <String>] [-NodeProvisioningDefaultPool <String>]
 [-NodeResourceGroupRestrictionLevel <String>] [-EnabledPodIdentity] [-EnablePodIdentityWithKubenet]
 [-EnablePublicNetworkAccess] [-EnableAzureKeyVaultKms] [-AzureKeyVaultKmsKeyId <String>]
 [-AzureKeyVaultKmsNetworkAccess <String>] [-AzureKeyVaultKmsResourceId <String>]
 [-CustomCaTrustCertificate <String[]>] [-DefenderLogAnalyticsWorkspaceResourceId <String>]
 [-EnableDefenderSecurityMonitoring] [-EnableImageCleaner] [-ImageCleanerIntervalHour <Int32>]
 [-EnableWorkloadIdentity] [[-ServicePrincipalIdAndSecret] <PSCredential>] [-SupportPlan <String>]
 [-WindowsProfileAdminUserPassword <SecureString>] [-EnableAHUB] [-EnableKEDA] [-EnableVerticalPodAutoscaler]
 [-Tag <Hashtable>] [-AksCustomHeader <Hashtable>] [-IfMatch <String>] [-IfNoneMatch <String>]
 [-AcrNameToAttach <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Set-AzAksCluster -InputObject <PSKubernetesCluster> [-NodePoolMode <String>] [-AcrNameToDetach <String>]
 [-NodeImageOnly] [-ControlPlaneOnly] [-AutoScalerProfile <ManagedClusterPropertiesAutoScalerProfile>]
 [-EnableUptimeSLA] [-EnableOidcIssuer] [-Location <String>] [-EnableManagedIdentity]
 [-AssignIdentity <String>] [-AadProfile <ManagedClusterAADProfile>] [-NodeCount <Int32>]
 [-EnableNodeAutoScaling] [-NodeMaxCount <Int32>] [-NodeMinCount <Int32>] [-NodeName <String>]
 [-NodePoolLabel <Hashtable>] [-NodeTaint <String[]>] [-NodeOsDiskSize <Int32>] [-NodePoolTag <Hashtable>]
 [-NodeVmSize <String>] [-NodeWorkloadRuntime <String>] [-EnableAIToolchainOperator]
 [-ApiServerAccessAuthorizedIpRange <String[]>] [-DisableApiServerRunCommand]
 [-EnableApiServerAccessPrivateCluster] [-EnableApiServerAccessPrivateClusterPublicFQDN]
 [-EnableApiServerVnetIntegration] [-ApiServerAccessPrivateDnsZone <String>] [-ApiServerSubnetId <String>]
 [-NodeOSAutoUpgradeChannel <String>] [-NodeAutoUpgradeChannel <String>] [-EnabledMonitorMetric]
 [-BootstrapArtifactSource <String>] [-BootstrapContainerRegistryId <String>] [-DisableLocalAccount]
 [-DiskEncryptionSetID <String>] [-DnsNamePrefix <String>] [-FqdnSubdomain <String>] [-HttpProxy <String>]
 [-HttpsProxy <String>] [-HttpProxyConfigNoProxyEndpoint <String[]>] [-HttpProxyConfigTrustedCa <String>]
 [-AssignKubeletIdentity <String>] [-KubernetesVersion <String>] [-LinuxProfileAdminUserName <String>]
 [-SshKeyValue <String>] [-EnableCostAnalysis] [-EnableAdvancedNetworking]
 [-EnableAdvancedNetworkingObservability] [-EnableAdvancedNetworkingSecurity]
 [-AdvancedNetworkingSecurityPolicy <String>] [-IPFamily <String[]>]
 [-LoadBalancerAllocatedOutboundPort <Int32>] [-LoadBalancerBackendPoolType <String>]
 [-EnableMultipleStandardLoadBalancer] [-LoadBalancerIdleTimeoutInMinute <Int32>]
 [-LoadBalancerManagedOutboundIpCount <Int32>] [-LoadBalancerManagedOutboundIpCountIPv6 <Int32>]
 [-LoadBalancerOutboundIpPrefix <String[]>] [-LoadBalancerOutboundIp <String[]>]
 [-NATGatewayIdleTimeoutInMinute <Int32>] [-NATGatewayManagedOutboundIpCount <Int32>]
 [-NetworkDataplane <String>] [-NetworkPluginMode <String>] [-EnabledStaticEgressGateway]
 [-NodeProvisioningMode <String>] [-NodeProvisioningDefaultPool <String>]
 [-NodeResourceGroupRestrictionLevel <String>] [-EnabledPodIdentity] [-EnablePodIdentityWithKubenet]
 [-EnablePublicNetworkAccess] [-EnableAzureKeyVaultKms] [-AzureKeyVaultKmsKeyId <String>]
 [-AzureKeyVaultKmsNetworkAccess <String>] [-AzureKeyVaultKmsResourceId <String>]
 [-CustomCaTrustCertificate <String[]>] [-DefenderLogAnalyticsWorkspaceResourceId <String>]
 [-EnableDefenderSecurityMonitoring] [-EnableImageCleaner] [-ImageCleanerIntervalHour <Int32>]
 [-EnableWorkloadIdentity] [-SupportPlan <String>] [-WindowsProfileAdminUserPassword <SecureString>]
 [-EnableAHUB] [-EnableKEDA] [-EnableVerticalPodAutoscaler] [-Tag <Hashtable>] [-AksCustomHeader <Hashtable>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-AcrNameToAttach <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### IdParameterSet
```
Set-AzAksCluster [-NodePoolMode <String>] [-AcrNameToDetach <String>] [-NodeImageOnly] [-ControlPlaneOnly]
 [-Id] <String> [-AutoScalerProfile <ManagedClusterPropertiesAutoScalerProfile>] [-EnableUptimeSLA]
 [-EnableOidcIssuer] [-Location <String>] [-EnableManagedIdentity] [-AssignIdentity <String>]
 [-AadProfile <ManagedClusterAADProfile>] [-NodeCount <Int32>] [-EnableNodeAutoScaling] [-NodeMaxCount <Int32>]
 [-NodeMinCount <Int32>] [-NodeName <String>] [-NodePoolLabel <Hashtable>] [-NodeTaint <String[]>]
 [-NodeOsDiskSize <Int32>] [-NodePoolTag <Hashtable>] [-NodeVmSize <String>] [-NodeWorkloadRuntime <String>]
 [-EnableAIToolchainOperator] [-ApiServerAccessAuthorizedIpRange <String[]>] [-DisableApiServerRunCommand]
 [-EnableApiServerAccessPrivateCluster] [-EnableApiServerAccessPrivateClusterPublicFQDN]
 [-EnableApiServerVnetIntegration] [-ApiServerAccessPrivateDnsZone <String>] [-ApiServerSubnetId <String>]
 [-NodeOSAutoUpgradeChannel <String>] [-NodeAutoUpgradeChannel <String>] [-EnabledMonitorMetric]
 [-BootstrapArtifactSource <String>] [-BootstrapContainerRegistryId <String>] [-DisableLocalAccount]
 [-DiskEncryptionSetID <String>] [-DnsNamePrefix <String>] [-FqdnSubdomain <String>] [-HttpProxy <String>]
 [-HttpsProxy <String>] [-HttpProxyConfigNoProxyEndpoint <String[]>] [-HttpProxyConfigTrustedCa <String>]
 [-AssignKubeletIdentity <String>] [-KubernetesVersion <String>] [-LinuxProfileAdminUserName <String>]
 [-SshKeyValue <String>] [-EnableCostAnalysis] [-EnableAdvancedNetworking]
 [-EnableAdvancedNetworkingObservability] [-EnableAdvancedNetworkingSecurity]
 [-AdvancedNetworkingSecurityPolicy <String>] [-IPFamily <String[]>]
 [-LoadBalancerAllocatedOutboundPort <Int32>] [-LoadBalancerBackendPoolType <String>]
 [-EnableMultipleStandardLoadBalancer] [-LoadBalancerIdleTimeoutInMinute <Int32>]
 [-LoadBalancerManagedOutboundIpCount <Int32>] [-LoadBalancerManagedOutboundIpCountIPv6 <Int32>]
 [-LoadBalancerOutboundIpPrefix <String[]>] [-LoadBalancerOutboundIp <String[]>]
 [-NATGatewayIdleTimeoutInMinute <Int32>] [-NATGatewayManagedOutboundIpCount <Int32>]
 [-NetworkDataplane <String>] [-NetworkPluginMode <String>] [-EnabledStaticEgressGateway]
 [-NodeProvisioningMode <String>] [-NodeProvisioningDefaultPool <String>]
 [-NodeResourceGroupRestrictionLevel <String>] [-EnabledPodIdentity] [-EnablePodIdentityWithKubenet]
 [-EnablePublicNetworkAccess] [-EnableAzureKeyVaultKms] [-AzureKeyVaultKmsKeyId <String>]
 [-AzureKeyVaultKmsNetworkAccess <String>] [-AzureKeyVaultKmsResourceId <String>]
 [-CustomCaTrustCertificate <String[]>] [-DefenderLogAnalyticsWorkspaceResourceId <String>]
 [-EnableDefenderSecurityMonitoring] [-EnableImageCleaner] [-ImageCleanerIntervalHour <Int32>]
 [-EnableWorkloadIdentity] [-SupportPlan <String>] [-WindowsProfileAdminUserPassword <SecureString>]
 [-EnableAHUB] [-EnableKEDA] [-EnableVerticalPodAutoscaler] [-Tag <Hashtable>] [-AksCustomHeader <Hashtable>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-AcrNameToAttach <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
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

### -AdvancedNetworkingSecurityPolicy
The advanced network policies. This allows users to configure Layer 7 network policies (FQDN, HTTP, Kafka). Policies themselves must be configured via the Cilium Network Policy resources, see https://docs.cilium.io/en/latest/security/policy/index.html. This can be enabled only on cilium-based clusters. If not specified, the default value is FQDN if EnableAdvancedNetworkingSecurity is set to true.

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

### -ApiServerSubnetId
The subnet to be used when apiserver vnet integration is enabled. It is required when creating a new cluster with BYO Vnet, or when updating an existing cluster to enable apiserver vnet integration.

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

### -AssignKubeletIdentity
ResourceId of user assign managed identity used by the kubelet.

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

### -AzureKeyVaultKmsKeyId
The identifier of Azure Key Vault key. See [key identifier format](https://docs.microsoft.com/en-us/azure/key-vault/general/about-keys-secrets-certificates#vault-name-and-object-name) for more details. When EnableAzureKeyVaultKms is set, this field is required and must be a valid key identifier.

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

### -AzureKeyVaultKmsNetworkAccess
The network access of the key vault. Network access of key vault. The possible values are `Public` and `Private`. `Public` means the key vault allows public access from all networks. `Private` means the key vault disables public access and enables private link.

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

### -AzureKeyVaultKmsResourceId
The resource ID of key vault. When AzureKeyVaultKmsNetworkAccess is `Private`, this field is required and must be a valid resource ID. When AzureKeyVaultKmsNetworkAccess is `Public`, leave the field empty.

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

### -BootstrapArtifactSource
The artifact source. The source where the artifacts are downloaded from.

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

### -BootstrapContainerRegistryId
The resource Id of Azure Container Registry. The registry must have private network access, premium SKU and zone redundancy.

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

### -CustomCaTrustCertificate
The list of up to 10 base64 encoded CAs that will be added to the trust store on all nodes in the cluster. For more information see [Custom CA Trust Certificates](https://learn.microsoft.com/en-us/azure/aks/custom-certificate-authority).

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

### -DefenderLogAnalyticsWorkspaceResourceId
The resource ID of the Log Analytics workspace to be associated with Microsoft Defender. When Microsoft Defender is enabled, this field is required and must be a valid workspace resource ID. When Microsoft Defender is disabled, leave the field empty.

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

### -DisableApiServerRunCommand
Whether to disable run command for the cluster or not.

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

### -EnableAdvancedNetworking
Enable Advanced Networking functionalities of observability and security on AKS clusters. When this is set to true, all observability and security features will be set to enabled unless explicitly disabled. If not specified, the default is false.

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

### -EnableAdvancedNetworkingObservability
Enable Advanced Networking observability functionalities on clusters.

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

### -EnableAdvancedNetworkingSecurity
Whether to allow user to configure network policy based on DNS (FQDN) names. It can be enabled only on cilium based clusters. If not specified, the default is false.

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

### -EnableAIToolchainOperator
Whether to enable AI toolchain operator to the cluster. Indicates if AI toolchain operator enabled or not.

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

### -EnableApiServerVnetIntegration
Whether to enable apiserver vnet integration for the cluster or not. See aka.ms/AksVnetIntegration for more details.

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

### -EnableAzureKeyVaultKms
Whether to enable Azure Key Vault key management service.

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

### -EnableCostAnalysis
Whether to enable cost analysis. The Managed Cluster sku.tier must be set to &#39;Standard&#39; or &#39;Premium&#39; to enable this feature. Enabling this will add Kubernetes Namespace and Deployment details to the Cost Analysis views in the Azure portal. If not specified, the default is false. For more information see aka.ms/aks/docs/cost-analysis.

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

### -EnableDefenderSecurityMonitoring
Whether to enable Defender threat detection

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

### -EnabledMonitorMetric
Whether to enable or disable the Azure Managed Prometheus addon for Prometheus monitoring. See aka.ms/AzureManagedPrometheus-aks-enable for details on enabling and disabling.

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

### -EnabledPodIdentity
Whether the pod identity addon is enabled.

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

### -EnabledStaticEgressGateway
Whether to enable Static Egress Gateway addon.

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

### -EnableImageCleaner
Whether to enable Image Cleaner on AKS cluster.

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

### -EnableKEDA
Whether to enable KEDA.

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

### -EnableMultipleStandardLoadBalancer
Whether to enable multiple standard load balancers per AKS cluster.

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
Whether to enable OIDC issuer feature.

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

### -EnablePodIdentityWithKubenet
Whether pod identity is allowed to run on clusters with  Kubenet networking. Running in Kubenet is disabled by default due to the  security related nature of AAD Pod Identity and the risks of IP spoofing.  See [using Kubenet network plugin with AAD Pod  Identity](https://docs.microsoft.com/azure/aks/use-azure-ad-pod-identity#using-kubenet-network-plugin-with-azure-active-directory-pod-managed-identities)  for more information.

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

### -EnablePublicNetworkAccess
If enable publicNetworkAccess of the managedCluster

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

### -EnableVerticalPodAutoscaler
Whether to enable Vertical Pod Autoscaler.

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

### -EnableWorkloadIdentity
Whether to enable workload identity.

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

### -IfMatch
The request should only proceed if an entity matches this string.

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
The request should only proceed if no entity matches this string.

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

### -ImageCleanerIntervalHour
The image Cleaner scanning interval in hours.

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

### -IPFamily
the IP families used to specify IP versions available to the cluster. IP families are used to determine single-stack or dual-stack clusters. For single-stack, the expected value is IPv4. For dual-stack, the expected values are IPv4 and IPv6.

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

### -LoadBalancerBackendPoolType
The type of the managed inbound Load Balancer BackendPool.

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

### -LoadBalancerManagedOutboundIpCountIPv6
Desired number of IPv6 outbound IPs created/managed by Azure for the cluster load balancer.

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

### -NATGatewayIdleTimeoutInMinute
Desired outbound flow idle timeout in minutes for NAT Gateway.

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

### -NATGatewayManagedOutboundIpCount
The desired number of outbound IPs created/managed by Azure.

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

### -NetworkDataplane
The network dataplane used in the Kubernetes cluster.

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

### -NetworkPluginMode
The mode the network plugin should use.

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

### -NodeAutoUpgradeChannel
The upgrade channel for auto upgrade. For more information see https://learn.microsoft.com/azure/aks/upgrade-cluster#set-auto-upgrade-channel.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AutoUpgradeChannel

Required: False
Position: Named
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

### -NodeOSAutoUpgradeChannel
The node OS Upgrade Channel. Manner in which the OS on your nodes is updated.

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

### -NodeProvisioningDefaultPool
The set of default Karpenter NodePools (CRDs) configured for node provisioning. This field has no effect unless mode is &#39;Auto&#39;. Warning: Changing this from Auto to None on an existing cluster will cause the default Karpenter NodePools to be deleted, which will drain and delete the nodes associated with those pools. It is strongly recommended to not do this unless there are idle nodes ready to take the pods evicted by that action. If not specified, the default is Auto. For more information see aka.ms/aks/nap#node-pools.

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

### -NodeProvisioningMode
The node provisioning mode.

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

### -NodeResourceGroupRestrictionLevel
The restriction level applied to the cluster node resource group.

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

### -NodeTaint
The taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.

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

### -NodeWorkloadRuntime
The type of workload a node can run.

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

### -SupportPlan
The support plan for the Managed Cluster.

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
The administrator password to use for Windows VMs. Password requirement:At least one lower case, one upper case, one special character !@#$%^&*(), the minimum length is 12.

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
