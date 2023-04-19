---
external help file:
Module Name: Az.ContainerService
online version: https://learn.microsoft.com/powershell/module/az.containerservice/new-azcontainerservicemanagedcluster
schema: 2.0.0
---

# New-AzContainerServiceManagedCluster

## SYNOPSIS
Creates or updates a managed cluster.

## SYNTAX

```
New-AzContainerServiceManagedCluster -ResourceGroupName <String> -ResourceName <String> -Location <String>
 [-SubscriptionId <String>] [-AadProfileAdminGroupObjectID <String[]>] [-AadProfileClientAppId <String>]
 [-AadProfileEnableAzureRbac] [-AadProfileManaged] [-AadProfileServerAppId <String>]
 [-AadProfileServerAppSecret <String>] [-AadProfileTenantId <String>] [-AddonProfile <Hashtable>]
 [-AgentPoolProfile <IManagedClusterAgentPoolProfile[]>] [-ApiServerAccessProfileAuthorizedIPRange <String[]>]
 [-ApiServerAccessProfileDisableRunCommand] [-ApiServerAccessProfileEnablePrivateCluster]
 [-ApiServerAccessProfileEnablePrivateClusterPublicFqdn] [-ApiServerAccessProfilePrivateDnsZone <String>]
 [-AutoScalerProfileBalanceSimilarNodeGroup <String>] [-AutoScalerProfileExpander <Expander>]
 [-AutoScalerProfileMaxEmptyBulkDelete <String>] [-AutoScalerProfileMaxGracefulTerminationSec <String>]
 [-AutoScalerProfileMaxNodeProvisionTime <String>] [-AutoScalerProfileMaxTotalUnreadyPercentage <String>]
 [-AutoScalerProfileNewPodScaleUpDelay <String>] [-AutoScalerProfileOkTotalUnreadyCount <String>]
 [-AutoScalerProfileScaleDownDelayAfterAdd <String>] [-AutoScalerProfileScaleDownDelayAfterDelete <String>]
 [-AutoScalerProfileScaleDownDelayAfterFailure <String>] [-AutoScalerProfileScaleDownUnneededTime <String>]
 [-AutoScalerProfileScaleDownUnreadyTime <String>] [-AutoScalerProfileScaleDownUtilizationThreshold <String>]
 [-AutoScalerProfileScanInterval <String>] [-AutoScalerProfileSkipNodesWithLocalStorage <String>]
 [-AutoScalerProfileSkipNodesWithSystemPod <String>] [-AutoUpgradeProfileUpgradeChannel <UpgradeChannel>]
 [-AzureKeyVaultKmEnabled] [-AzureKeyVaultKmKeyId <String>]
 [-AzureKeyVaultKmKeyVaultNetworkAccess <KeyVaultNetworkAccessTypes>]
 [-AzureKeyVaultKmKeyVaultResourceId <String>] [-BlobCsiDriverEnabled]
 [-DefenderLogAnalyticsWorkspaceResourceId <String>] [-DisableLocalAccount] [-DiskCsiDriverEnabled]
 [-DiskEncryptionSetId <String>] [-DnsPrefix <String>] [-EnablePodSecurityPolicy] [-EnableRbac]
 [-ExtendedLocationName <String>] [-ExtendedLocationType <ExtendedLocationTypes>] [-FileCsiDriverEnabled]
 [-FqdnSubdomain <String>] [-GmsaProfileDnsServer <String>] [-GmsaProfileEnabled]
 [-GmsaProfileRootDomainName <String>] [-HttpProxyConfigHttpProxy <String>]
 [-HttpProxyConfigHttpsProxy <String>] [-HttpProxyConfigNoProxy <String[]>]
 [-HttpProxyConfigTrustedCa <String>] [-IdentityProfile <Hashtable>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ImageCleanerEnabled] [-ImageCleanerIntervalHour <Int32>]
 [-KedaEnabled] [-KubernetesVersion <String>] [-KubeStateMetricAnnotationsAllowList <String>]
 [-KubeStateMetricLabelsAllowlist <String>] [-LinuxProfileAdminUsername <String>] [-MetricEnabled]
 [-NetworkProfile <IContainerServiceNetworkProfile>] [-NodeResourceGroup <String>] [-OidcIssuerProfileEnabled]
 [-PodIdentityProfileAllowNetworkPluginKubenet] [-PodIdentityProfileEnabled]
 [-PodIdentityProfileUserAssignedIdentity <IManagedClusterPodIdentity[]>]
 [-PodIdentityProfileUserAssignedIdentityException <IManagedClusterPodIdentityException[]>]
 [-PrivateLinkResource <IPrivateLinkResource[]>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-SecurityMonitoringEnabled] [-ServicePrincipalProfileClientId <String>]
 [-ServicePrincipalProfileSecret <String>] [-SkuName <ManagedClusterSkuName>]
 [-SkuTier <ManagedClusterSkuTier>] [-SnapshotControllerEnabled]
 [-SshPublicKey <IContainerServiceSshPublicKey[]>] [-SupportPlan <KubernetesSupportPlan>] [-Tag <Hashtable>]
 [-WindowProfileAdminPassword <String>] [-WindowProfileAdminUsername <String>] [-WindowProfileEnableCsiProxy]
 [-WindowProfileLicenseType <LicenseType>] [-WorkloadIdentityEnabled] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a managed cluster.

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

### -AadProfileAdminGroupObjectID
The list of AAD group object IDs that will have admin role of the cluster.

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

### -AadProfileClientAppId
(DEPRECATED) The client AAD application ID.
Learn more at https://aka.ms/aks/aad-legacy.

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

### -AadProfileEnableAzureRbac
Whether to enable Azure RBAC for Kubernetes authorization.

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

### -AadProfileManaged
Whether to enable managed AAD.

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

### -AadProfileServerAppId
(DEPRECATED) The server AAD application ID.
Learn more at https://aka.ms/aks/aad-legacy.

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

### -AadProfileServerAppSecret
(DEPRECATED) The server AAD application secret.
Learn more at https://aka.ms/aks/aad-legacy.

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
```

### -AddonProfile
The profile of managed cluster add-on.

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

### -AgentPoolProfile
The agent pool properties.
To construct, see NOTES section for AGENTPOOLPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IManagedClusterAgentPoolProfile[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiServerAccessProfileAuthorizedIPRange
IP ranges are specified in CIDR format, e.g.
137.117.106.88/29.
This feature is not compatible with clusters that use Public IP Per Node, or clusters that are using a Basic Load Balancer.
For more information see [API server authorized IP ranges](https://docs.microsoft.com/azure/aks/api-server-authorized-ip-ranges).

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

### -ApiServerAccessProfileDisableRunCommand
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

### -ApiServerAccessProfileEnablePrivateCluster
For more details, see [Creating a private AKS cluster](https://docs.microsoft.com/azure/aks/private-clusters).

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

### -ApiServerAccessProfileEnablePrivateClusterPublicFqdn
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

### -ApiServerAccessProfilePrivateDnsZone
The default is System.
For more details see [configure private DNS zone](https://docs.microsoft.com/azure/aks/private-clusters#configure-private-dns-zone).
Allowed values are 'system' and 'none'.

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

### -AutoScalerProfileBalanceSimilarNodeGroup
Valid values are 'true' and 'false'

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

### -AutoScalerProfileExpander
If not specified, the default is 'random'.
See [expanders](https://github.com/kubernetes/autoscaler/blob/master/cluster-autoscaler/FAQ.md#what-are-expanders) for more information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.Expander
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileMaxEmptyBulkDelete
The default is 10.

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

### -AutoScalerProfileMaxGracefulTerminationSec
The default is 600.

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

### -AutoScalerProfileMaxNodeProvisionTime
The default is '15m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

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

### -AutoScalerProfileMaxTotalUnreadyPercentage
The default is 45.
The maximum is 100 and the minimum is 0.

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

### -AutoScalerProfileNewPodScaleUpDelay
For scenarios like burst/batch scale where you don't want CA to act before the kubernetes scheduler could schedule all the pods, you can tell CA to ignore unscheduled pods before they're a certain age.
The default is '0s'.
Values must be an integer followed by a unit ('s' for seconds, 'm' for minutes, 'h' for hours, etc).

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

### -AutoScalerProfileOkTotalUnreadyCount
This must be an integer.
The default is 3.

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

### -AutoScalerProfileScaleDownDelayAfterAdd
The default is '10m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

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

### -AutoScalerProfileScaleDownDelayAfterDelete
The default is the scan-interval.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

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

### -AutoScalerProfileScaleDownDelayAfterFailure
The default is '3m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

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

### -AutoScalerProfileScaleDownUnneededTime
The default is '10m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

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

### -AutoScalerProfileScaleDownUnreadyTime
The default is '20m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

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

### -AutoScalerProfileScaleDownUtilizationThreshold
The default is '0.5'.

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

### -AutoScalerProfileScanInterval
The default is '10'.
Values must be an integer number of seconds.

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

### -AutoScalerProfileSkipNodesWithLocalStorage
The default is true.

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

### -AutoScalerProfileSkipNodesWithSystemPod
The default is true.

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

### -AutoUpgradeProfileUpgradeChannel
For more information see [setting the AKS cluster auto-upgrade channel](https://docs.microsoft.com/azure/aks/upgrade-cluster#set-auto-upgrade-channel).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.UpgradeChannel
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureKeyVaultKmEnabled
Whether to enable Azure Key Vault key management service.
The default is false.

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

### -AzureKeyVaultKmKeyId
Identifier of Azure Key Vault key.
See [key identifier format](https://docs.microsoft.com/en-us/azure/key-vault/general/about-keys-secrets-certificates#vault-name-and-object-name) for more details.
When Azure Key Vault key management service is enabled, this field is required and must be a valid key identifier.
When Azure Key Vault key management service is disabled, leave the field empty.

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

### -AzureKeyVaultKmKeyVaultNetworkAccess
Network access of key vault.
The possible values are `Public` and `Private`.
`Public` means the key vault allows public access from all networks.
`Private` means the key vault disables public access and enables private link.
The default value is `Public`.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.KeyVaultNetworkAccessTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureKeyVaultKmKeyVaultResourceId
Resource ID of key vault.
When keyVaultNetworkAccess is `Private`, this field is required and must be a valid resource ID.
When keyVaultNetworkAccess is `Public`, leave the field empty.

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

### -BlobCsiDriverEnabled
Whether to enable AzureBlob CSI Driver.
The default value is false.

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

### -DefenderLogAnalyticsWorkspaceResourceId
Resource ID of the Log Analytics workspace to be associated with Microsoft Defender.
When Microsoft Defender is enabled, this field is required and must be a valid workspace resource ID.
When Microsoft Defender is disabled, leave the field empty.

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

### -DisableLocalAccount
If set to true, getting static credentials will be disabled for this cluster.
This must only be used on Managed Clusters that are AAD enabled.
For more details see [disable local accounts](https://docs.microsoft.com/azure/aks/managed-aad#disable-local-accounts-preview).

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

### -DiskCsiDriverEnabled
Whether to enable AzureDisk CSI Driver.
The default value is true.

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

### -DiskEncryptionSetId
This is of the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskEncryptionSets/{encryptionSetName}'

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

### -DnsPrefix
This cannot be updated once the Managed Cluster has been created.

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

### -EnablePodSecurityPolicy
(DEPRECATED) Whether to enable Kubernetes pod security policy (preview).
PodSecurityPolicy was deprecated in Kubernetes v1.21, and removed from Kubernetes in v1.25.
Learn more at https://aka.ms/k8s/psp and https://aka.ms/aks/psp.

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
```

### -ExtendedLocationName
The name of the extended location.

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

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ExtendedLocationTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileCsiDriverEnabled
Whether to enable AzureFile CSI Driver.
The default value is true.

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
This cannot be updated once the Managed Cluster has been created.

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

### -GmsaProfileDnsServer
Specifies the DNS server for Windows gMSA.


 Set it to empty if you have configured the DNS server in the vnet which is used to create the managed cluster.

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

### -GmsaProfileEnabled
Specifies whether to enable Windows gMSA in the managed cluster.

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

### -GmsaProfileRootDomainName
Specifies the root domain name for Windows gMSA.


 Set it to empty if you have configured the DNS server in the vnet which is used to create the managed cluster.

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

### -HttpProxyConfigHttpProxy
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

### -HttpProxyConfigHttpsProxy
The HTTPS proxy server endpoint to use.

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

### -HttpProxyConfigNoProxy
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

### -IdentityProfile
Identities associated with the cluster.

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

### -IdentityType
For more information see [use managed identities in AKS](https://docs.microsoft.com/azure/aks/use-managed-identity).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The keys must be ARM resource IDs in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

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

### -ImageCleanerEnabled
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

### -ImageCleanerIntervalHour
Image Cleaner scanning interval in hours.

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

### -KedaEnabled
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

### -KubernetesVersion
Both patch version \<major.minor.patch\> (e.g.
1.20.13) and \<major.minor\> (e.g.
1.20) are supported.
When \<major.minor\> is specified, the latest supported GA patch version is chosen automatically.
Updating the cluster with the same \<major.minor\> once it has been created (e.g.
1.14.x -\> 1.14) will not trigger an upgrade, even if a newer patch version is available.
When you upgrade a supported AKS cluster, Kubernetes minor versions cannot be skipped.
All upgrades must be performed sequentially by major version number.
For example, upgrades between 1.14.x -\> 1.15.x or 1.15.x -\> 1.16.x are allowed, however 1.14.x -\> 1.16.x is not allowed.
See [upgrading an AKS cluster](https://docs.microsoft.com/azure/aks/upgrade-cluster) for more details.

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

### -KubeStateMetricAnnotationsAllowList
Comma-separated list of Kubernetes annotation keys that will be used in the resource's labels metric (Example: 'namespaces=[kubernetes.io/team,...],pods=[kubernetes.io/team],...').
By default the metric contains only resource name and namespace labels.

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

### -KubeStateMetricLabelsAllowlist
Comma-separated list of additional Kubernetes label keys that will be used in the resource's labels metric (Example: 'namespaces=[k8s-label-1,k8s-label-n,...],pods=[app],...').
By default the metric contains only resource name and namespace labels.

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
```

### -Location
The geo-location where the resource lives

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

### -MetricEnabled
Whether to enable or disable the Azure Managed Prometheus addon for Prometheus monitoring.
See aka.ms/AzureManagedPrometheus-aks-enable for details on enabling and disabling.

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

### -NetworkProfile
The network configuration profile.
To construct, see NOTES section for NETWORKPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IContainerServiceNetworkProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeResourceGroup
The name of the resource group containing agent pool nodes.

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

### -OidcIssuerProfileEnabled
Whether the OIDC issuer is enabled.

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

### -PodIdentityProfileAllowNetworkPluginKubenet
Running in Kubenet is disabled by default due to the security related nature of AAD Pod Identity and the risks of IP spoofing.
See [using Kubenet network plugin with AAD Pod Identity](https://docs.microsoft.com/azure/aks/use-azure-ad-pod-identity#using-kubenet-network-plugin-with-azure-active-directory-pod-managed-identities) for more information.

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

### -PodIdentityProfileEnabled
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

### -PodIdentityProfileUserAssignedIdentity
The pod identities to use in the cluster.
To construct, see NOTES section for PODIDENTITYPROFILEUSERASSIGNEDIDENTITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IManagedClusterPodIdentity[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PodIdentityProfileUserAssignedIdentityException
The pod identity exceptions to allow.
To construct, see NOTES section for PODIDENTITYPROFILEUSERASSIGNEDIDENTITYEXCEPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IManagedClusterPodIdentityException[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkResource
Private link resources associated with the cluster.
To construct, see NOTES section for PRIVATELINKRESOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IPrivateLinkResource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Allow or deny public network access for AKS

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.PublicNetworkAccess
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the managed cluster resource.

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

### -SecurityMonitoringEnabled
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
```

### -SkuName
The name of a managed cluster SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ManagedClusterSkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
If not specified, the default is 'Free'.
See [AKS Pricing Tier](https://learn.microsoft.com/azure/aks/free-standard-pricing-tiers) for more details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ManagedClusterSkuTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SnapshotControllerEnabled
Whether to enable Snapshot Controller.
The default value is true.

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

### -SshPublicKey
The list of SSH public keys used to authenticate with Linux-based VMs.
A maximum of 1 key may be specified.
To construct, see NOTES section for SSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IContainerServiceSshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -SupportPlan
The support plan for the Managed Cluster.
If unspecified, the default is 'KubernetesOfficial'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.KubernetesSupportPlan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### -WindowProfileAdminPassword
Specifies the password of the administrator account.


 **Minimum-length:** 8 characters 

 **Max-length:** 123 characters 

 **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled 
 Has lower characters 
Has upper characters 
 Has a digit 
 Has a special character (Regex match [\W_]) 

 **Disallowed values:** "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"

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

### -WindowProfileAdminUsername
Specifies the name of the administrator account.


 **Restriction:** Cannot end in "." 

 **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5".


 **Minimum-length:** 1 character 

 **Max-length:** 20 characters

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

### -WindowProfileEnableCsiProxy
For more details on CSI proxy, see the [CSI proxy GitHub repo](https://github.com/kubernetes-csi/csi-proxy).

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

### -WindowProfileLicenseType
The license type to use for Windows VMs.
See [Azure Hybrid User Benefits](https://azure.microsoft.com/pricing/hybrid-benefit/faq/) for more details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.LicenseType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadIdentityEnabled
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20230301.IManagedCluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`AGENTPOOLPROFILE <IManagedClusterAgentPoolProfile[]>`: The agent pool properties.
  - `Name <String>`: Windows agent pool names must be 6 characters or less.
  - `[AvailabilityZone <String[]>]`: The list of Availability zones to use for nodes. This can only be specified if the AgentPoolType property is 'VirtualMachineScaleSets'.
  - `[Count <Int32?>]`: Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 1000 (inclusive) for user pools and in the range of 1 to 1000 (inclusive) for system pools. The default value is 1.
  - `[CreationDataSourceResourceId <String>]`: This is the ARM ID of the source object to be used to create the target object.
  - `[EnableAutoScaling <Boolean?>]`: Whether to enable auto-scaler
  - `[EnableEncryptionAtHost <Boolean?>]`: This is only supported on certain VM sizes and in certain Azure regions. For more information, see: https://docs.microsoft.com/azure/aks/enable-host-encryption
  - `[EnableFips <Boolean?>]`: See [Add a FIPS-enabled node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#add-a-fips-enabled-node-pool-preview) for more details.
  - `[EnableNodePublicIP <Boolean?>]`: Some scenarios may require nodes in a node pool to receive their own dedicated public IP addresses. A common scenario is for gaming workloads, where a console needs to make a direct connection to a cloud virtual machine to minimize hops. For more information see [assigning a public IP per node](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#assign-a-public-ip-per-node-for-your-node-pools). The default is false.
  - `[EnableUltraSsd <Boolean?>]`: Whether to enable UltraSSD
  - `[GpuInstanceProfile <GpuInstanceProfile?>]`: GPUInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU.
  - `[HostGroupId <String>]`: This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}. For more information see [Azure dedicated hosts](https://docs.microsoft.com/azure/virtual-machines/dedicated-hosts).
  - `[KubeletConfigAllowedUnsafeSysctl <String[]>]`: Allowed list of unsafe sysctls or unsafe sysctl patterns (ending in `*`).
  - `[KubeletConfigContainerLogMaxFile <Int32?>]`: The maximum number of container log files that can be present for a container. The number must be ≥ 2.
  - `[KubeletConfigContainerLogMaxSizeMb <Int32?>]`: The maximum size (e.g. 10Mi) of container log file before it is rotated.
  - `[KubeletConfigCpuCfsQuota <Boolean?>]`: The default is true.
  - `[KubeletConfigCpuCfsQuotaPeriod <String>]`: The default is '100ms.' Valid values are a sequence of decimal numbers with an optional fraction and a unit suffix. For example: '300ms', '2h45m'. Supported units are 'ns', 'us', 'ms', 's', 'm', and 'h'.
  - `[KubeletConfigCpuManagerPolicy <String>]`: The default is 'none'. See [Kubernetes CPU management policies](https://kubernetes.io/docs/tasks/administer-cluster/cpu-management-policies/#cpu-management-policies) for more information. Allowed values are 'none' and 'static'.
  - `[KubeletConfigFailSwapOn <Boolean?>]`: If set to true it will make the Kubelet fail to start if swap is enabled on the node.
  - `[KubeletConfigImageGcHighThreshold <Int32?>]`: To disable image garbage collection, set to 100. The default is 85%
  - `[KubeletConfigImageGcLowThreshold <Int32?>]`: This cannot be set higher than imageGcHighThreshold. The default is 80%
  - `[KubeletConfigPodMaxPid <Int32?>]`: The maximum number of processes per pod.
  - `[KubeletConfigTopologyManagerPolicy <String>]`: For more information see [Kubernetes Topology Manager](https://kubernetes.io/docs/tasks/administer-cluster/topology-manager). The default is 'none'. Allowed values are 'none', 'best-effort', 'restricted', and 'single-numa-node'.
  - `[KubeletDiskType <KubeletDiskType?>]`: Determines the placement of emptyDir volumes, container runtime data root, and Kubelet ephemeral storage.
  - `[LinuxOSConfigSwapFileSizeMb <Int32?>]`: The size in MB of a swap file that will be created on each node.
  - `[LinuxOSConfigSysctl <ISysctlConfig>]`: Sysctl settings for Linux agent nodes.
    - `[FsAioMaxNr <Int32?>]`: Sysctl setting fs.aio-max-nr.
    - `[FsFileMax <Int32?>]`: Sysctl setting fs.file-max.
    - `[FsInotifyMaxUserWatch <Int32?>]`: Sysctl setting fs.inotify.max_user_watches.
    - `[FsNrOpen <Int32?>]`: Sysctl setting fs.nr_open.
    - `[KernelThreadsMax <Int32?>]`: Sysctl setting kernel.threads-max.
    - `[NetCoreNetdevMaxBacklog <Int32?>]`: Sysctl setting net.core.netdev_max_backlog.
    - `[NetCoreOptmemMax <Int32?>]`: Sysctl setting net.core.optmem_max.
    - `[NetCoreRmemDefault <Int32?>]`: Sysctl setting net.core.rmem_default.
    - `[NetCoreRmemMax <Int32?>]`: Sysctl setting net.core.rmem_max.
    - `[NetCoreSomaxconn <Int32?>]`: Sysctl setting net.core.somaxconn.
    - `[NetCoreWmemDefault <Int32?>]`: Sysctl setting net.core.wmem_default.
    - `[NetCoreWmemMax <Int32?>]`: Sysctl setting net.core.wmem_max.
    - `[NetIpv4IPLocalPortRange <String>]`: Sysctl setting net.ipv4.ip_local_port_range.
    - `[NetIpv4NeighDefaultGcThresh1 <Int32?>]`: Sysctl setting net.ipv4.neigh.default.gc_thresh1.
    - `[NetIpv4NeighDefaultGcThresh2 <Int32?>]`: Sysctl setting net.ipv4.neigh.default.gc_thresh2.
    - `[NetIpv4NeighDefaultGcThresh3 <Int32?>]`: Sysctl setting net.ipv4.neigh.default.gc_thresh3.
    - `[NetIpv4TcpFinTimeout <Int32?>]`: Sysctl setting net.ipv4.tcp_fin_timeout.
    - `[NetIpv4TcpKeepaliveProbe <Int32?>]`: Sysctl setting net.ipv4.tcp_keepalive_probes.
    - `[NetIpv4TcpKeepaliveTime <Int32?>]`: Sysctl setting net.ipv4.tcp_keepalive_time.
    - `[NetIpv4TcpMaxSynBacklog <Int32?>]`: Sysctl setting net.ipv4.tcp_max_syn_backlog.
    - `[NetIpv4TcpMaxTwBucket <Int32?>]`: Sysctl setting net.ipv4.tcp_max_tw_buckets.
    - `[NetIpv4TcpTwReuse <Boolean?>]`: Sysctl setting net.ipv4.tcp_tw_reuse.
    - `[NetIpv4TcpkeepaliveIntvl <Int32?>]`: Sysctl setting net.ipv4.tcp_keepalive_intvl.
    - `[NetNetfilterNfConntrackBucket <Int32?>]`: Sysctl setting net.netfilter.nf_conntrack_buckets.
    - `[NetNetfilterNfConntrackMax <Int32?>]`: Sysctl setting net.netfilter.nf_conntrack_max.
    - `[VMMaxMapCount <Int32?>]`: Sysctl setting vm.max_map_count.
    - `[VMSwappiness <Int32?>]`: Sysctl setting vm.swappiness.
    - `[VMVfsCachePressure <Int32?>]`: Sysctl setting vm.vfs_cache_pressure.
  - `[LinuxOSConfigTransparentHugePageDefrag <String>]`: Valid values are 'always', 'defer', 'defer+madvise', 'madvise' and 'never'. The default is 'madvise'. For more information see [Transparent Hugepages](https://www.kernel.org/doc/html/latest/admin-guide/mm/transhuge.html#admin-guide-transhuge).
  - `[LinuxOSConfigTransparentHugePageEnabled <String>]`: Valid values are 'always', 'madvise', and 'never'. The default is 'always'. For more information see [Transparent Hugepages](https://www.kernel.org/doc/html/latest/admin-guide/mm/transhuge.html#admin-guide-transhuge).
  - `[MaxCount <Int32?>]`: The maximum number of nodes for auto-scaling
  - `[MaxPod <Int32?>]`: The maximum number of pods that can run on a node.
  - `[MinCount <Int32?>]`: The minimum number of nodes for auto-scaling
  - `[Mode <AgentPoolMode?>]`: A cluster must have at least one 'System' Agent Pool at all times. For additional information on agent pool restrictions and best practices, see: https://docs.microsoft.com/azure/aks/use-system-pools
  - `[NodeLabel <IManagedClusterAgentPoolProfilePropertiesNodeLabels>]`: The node labels to be persisted across all nodes in agent pool.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[NodePublicIPPrefixId <String>]`: This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIPPrefixName}
  - `[NodeTaint <String[]>]`: The taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
  - `[OSDiskSizeGb <Int32?>]`: OS Disk Size in GB to be used to specify the disk size for every machine in the master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.
  - `[OSDiskType <OSDiskType?>]`: The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB. Otherwise, defaults to 'Managed'. May not be changed after creation. For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os).
  - `[OSSku <Ossku?>]`: Specifies the OS SKU used by the agent pool. The default is Ubuntu if OSType is Linux. The default is Windows2019 when Kubernetes <= 1.24 or Windows2022 when Kubernetes >= 1.25 if OSType is Windows.
  - `[OSType <OSType?>]`: The operating system type. The default is Linux.
  - `[OrchestratorVersion <String>]`: Both patch version <major.minor.patch> (e.g. 1.20.13) and <major.minor> (e.g. 1.20) are supported. When <major.minor> is specified, the latest supported GA patch version is chosen automatically. Updating the cluster with the same <major.minor> once it has been created (e.g. 1.14.x -> 1.14) will not trigger an upgrade, even if a newer patch version is available. As a best practice, you should upgrade all node pools in an AKS cluster to the same Kubernetes version. The node pool version must have the same major version as the control plane. The node pool minor version must be within two minor versions of the control plane version. The node pool version cannot be greater than the control plane version. For more information see [upgrading a node pool](https://docs.microsoft.com/azure/aks/use-multiple-node-pools#upgrade-a-node-pool).
  - `[PodSubnetId <String>]`: If omitted, pod IPs are statically assigned on the node subnet (see vnetSubnetID for more details). This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
  - `[PowerStateCode <Code?>]`: Tells whether the cluster is Running or Stopped
  - `[ProximityPlacementGroupId <String>]`: The ID for Proximity Placement Group.
  - `[ScaleDownMode <ScaleDownMode?>]`: This also effects the cluster autoscaler behavior. If not specified, it defaults to Delete.
  - `[ScaleSetEvictionPolicy <ScaleSetEvictionPolicy?>]`: This cannot be specified unless the scaleSetPriority is 'Spot'. If not specified, the default is 'Delete'.
  - `[ScaleSetPriority <ScaleSetPriority?>]`: The Virtual Machine Scale Set priority. If not specified, the default is 'Regular'.
  - `[SpotMaxPrice <Single?>]`: Possible values are any decimal value greater than zero or -1 which indicates the willingness to pay any on-demand price. For more details on spot pricing, see [spot VMs pricing](https://docs.microsoft.com/azure/virtual-machines/spot-vms#pricing)
  - `[Tag <IManagedClusterAgentPoolProfilePropertiesTags>]`: The tags to be persisted on the agent pool virtual machine scale set.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <AgentPoolType?>]`: The type of Agent Pool.
  - `[UpgradeSettingMaxSurge <String>]`: This can either be set to an integer (e.g. '5') or a percentage (e.g. '50%'). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 1. For more information, including best practices, see: https://docs.microsoft.com/azure/aks/upgrade-cluster#customize-node-surge-upgrade
  - `[VMSize <String>]`: VM size availability varies by region. If a node contains insufficient compute resources (memory, cpu, etc) pods might fail to run correctly. For more details on restricted VM sizes, see: https://docs.microsoft.com/azure/aks/quotas-skus-regions
  - `[VnetSubnetId <String>]`: If this is not specified, a VNET and subnet will be generated and used. If no podSubnetID is specified, this applies to nodes and pods, otherwise it applies to just nodes. This is of the form: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}
  - `[WorkloadRuntime <WorkloadRuntime?>]`: Determines the type of workload a node can run.

`NETWORKPROFILE <IContainerServiceNetworkProfile>`: The network configuration profile.
  - `[DnsServiceIP <String>]`: An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified in serviceCidr.
  - `[DockerBridgeCidr <String>]`: A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range.
  - `[IPFamily <IPFamily[]>]`: IP families are used to determine single-stack or dual-stack clusters. For single-stack, the expected value is IPv4. For dual-stack, the expected values are IPv4 and IPv6.
  - `[LoadBalancerProfileAllocatedOutboundPort <Int32?>]`: The desired number of allocated SNAT ports per VM. Allowed values are in the range of 0 to 64000 (inclusive). The default value is 0 which results in Azure dynamically allocating ports.
  - `[LoadBalancerProfileEffectiveOutboundIP <IResourceReference[]>]`: The effective outbound IP resources of the cluster load balancer.
    - `[Id <String>]`: The fully qualified Azure resource id.
  - `[LoadBalancerProfileEnableMultipleStandardLoadBalancer <Boolean?>]`: Enable multiple standard load balancers per AKS cluster or not.
  - `[LoadBalancerProfileIdleTimeoutInMinute <Int32?>]`: Desired outbound flow idle timeout in minutes. Allowed values are in the range of 4 to 120 (inclusive). The default value is 30 minutes.
  - `[LoadBalancerSku <LoadBalancerSku?>]`: The default is 'standard'. See [Azure Load Balancer SKUs](https://docs.microsoft.com/azure/load-balancer/skus) for more information about the differences between load balancer SKUs.
  - `[ManagedOutboundIPCount <Int32?>]`: The desired number of IPv4 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. 
  - `[ManagedOutboundIPCountIpv6 <Int32?>]`: The desired number of IPv6 outbound IPs created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 0 for single-stack and 1 for dual-stack. 
  - `[ManagedOutboundIPProfileCount <Int32?>]`: The desired number of outbound IPs created/managed by Azure. Allowed values must be in the range of 1 to 16 (inclusive). The default value is 1. 
  - `[NatGatewayProfileEffectiveOutboundIP <IResourceReference[]>]`: The effective outbound IP resources of the cluster NAT gateway.
  - `[NatGatewayProfileIdleTimeoutInMinute <Int32?>]`: Desired outbound flow idle timeout in minutes. Allowed values are in the range of 4 to 120 (inclusive). The default value is 4 minutes.
  - `[NetworkDataplane <NetworkDataplane?>]`: Network dataplane used in the Kubernetes cluster.
  - `[NetworkMode <NetworkMode?>]`: This cannot be specified if networkPlugin is anything other than 'azure'.
  - `[NetworkPlugin <NetworkPlugin?>]`: Network plugin used for building the Kubernetes network.
  - `[NetworkPluginMode <NetworkPluginMode?>]`: The mode the network plugin should use.
  - `[NetworkPolicy <NetworkPolicy?>]`: Network policy used for building the Kubernetes network.
  - `[OutboundIPPrefixPublicIpprefix <IResourceReference[]>]`: A list of public IP prefix resources.
  - `[OutboundIPPublicIP <IResourceReference[]>]`: A list of public IP resources.
  - `[OutboundType <OutboundType?>]`: This can only be set at cluster creation time and cannot be changed later. For more information see [egress outbound type](https://docs.microsoft.com/azure/aks/egress-outboundtype).
  - `[PodCidr <String>]`: A CIDR notation IP range from which to assign pod IPs when kubenet is used.
  - `[PodCidrs <String[]>]`: One IPv4 CIDR is expected for single-stack networking. Two CIDRs, one for each IP family (IPv4/IPv6), is expected for dual-stack networking.
  - `[ServiceCidr <String>]`: A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
  - `[ServiceCidrs <String[]>]`: One IPv4 CIDR is expected for single-stack networking. Two CIDRs, one for each IP family (IPv4/IPv6), is expected for dual-stack networking. They must not overlap with any Subnet IP ranges.

`PODIDENTITYPROFILEUSERASSIGNEDIDENTITY <IManagedClusterPodIdentity[]>`: The pod identities to use in the cluster.
  - `Name <String>`: The name of the pod identity.
  - `Namespace <String>`: The namespace of the pod identity.
  - `[BindingSelector <String>]`: The binding selector to use for the AzureIdentityBinding resource.
  - `[Code <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  - `[Detail <IManagedClusterPodIdentityProvisioningErrorBody[]>]`: A list of additional details about the error.
    - `[Code <String>]`: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
    - `[Detail <IManagedClusterPodIdentityProvisioningErrorBody[]>]`: A list of additional details about the error.
    - `[Message <String>]`: A message describing the error, intended to be suitable for display in a user interface.
    - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.
  - `[IdentityClientId <String>]`: The client ID of the user assigned identity.
  - `[IdentityObjectId <String>]`: The object ID of the user assigned identity.
  - `[IdentityResourceId <String>]`: The resource ID of the user assigned identity.
  - `[Message <String>]`: A message describing the error, intended to be suitable for display in a user interface.
  - `[Target <String>]`: The target of the particular error. For example, the name of the property in error.

`PODIDENTITYPROFILEUSERASSIGNEDIDENTITYEXCEPTION <IManagedClusterPodIdentityException[]>`: The pod identity exceptions to allow.
  - `Name <String>`: The name of the pod identity exception.
  - `Namespace <String>`: The namespace of the pod identity exception.
  - `PodLabel <IManagedClusterPodIdentityExceptionPodLabels>`: The pod labels to match.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`PRIVATELINKRESOURCE <IPrivateLinkResource[]>`: Private link resources associated with the cluster.
  - `[GroupId <String>]`: The group ID of the resource.
  - `[Id <String>]`: The ID of the private link resource.
  - `[Name <String>]`: The name of the private link resource.
  - `[RequiredMember <String[]>]`: The RequiredMembers of the resource
  - `[Type <String>]`: The resource type.

`SSHPUBLICKEY <IContainerServiceSshPublicKey[]>`: The list of SSH public keys used to authenticate with Linux-based VMs. A maximum of 1 key may be specified.
  - `KeyData <String>`: Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without headers.

## RELATED LINKS

