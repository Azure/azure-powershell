---
external help file:
Module Name: Az.ConnectedKubernetes
online version: https://learn.microsoft.com/powershell/module/az.connectedkubernetes/set-azconnectedkubernetes
schema: 2.0.0
---

# Set-AzConnectedKubernetes

## SYNOPSIS
API to set properties of the connected cluster resource

## SYNTAX

### SetExpanded (Default)
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> -Location <String>
 [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>]
 [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-PrivateLinkScopeResourceId <String>]
 [-PrivateLinkState <PrivateLinkState>] [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>]
 [-WorkloadIdentityEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Set
```
Set-AzConnectedKubernetes -InputObject <IConnectedCluster> [-ContainerLogPath <String>] [-DisableAutoUpgrade]
 [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>] [-ProxyCert <String>] [-SubscriptionId <String>]
 [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>] [-ConfigurationProtectedSetting <Hashtable>]
 [-ConfigurationSetting <Hashtable>] [-CustomLocationsOid <String>] [-Distribution <String>]
 [-DistributionVersion <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-OidcIssuerProfileEnabled] [-OidcIssuerProfileSelfHostedIssuerUrl <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-WorkloadIdentityEnabled]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetDisableGateway
```
Set-AzConnectedKubernetes -DisableGateway -InputObject <IConnectedCluster> [-ContainerLogPath <String>]
 [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>] [-ProxyCert <String>]
 [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-PrivateLinkScopeResourceId <String>]
 [-PrivateLinkState <PrivateLinkState>] [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>]
 [-WorkloadIdentityEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetEnableGateway
```
Set-AzConnectedKubernetes -GatewayResourceId <String> -InputObject <IConnectedCluster>
 [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>]
 [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-PrivateLinkScopeResourceId <String>]
 [-PrivateLinkState <PrivateLinkState>] [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>]
 [-WorkloadIdentityEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetExpandedDisableGateway
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> -DisableGateway -Location <String>
 [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>]
 [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-PrivateLinkScopeResourceId <String>]
 [-PrivateLinkState <PrivateLinkState>] [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>]
 [-WorkloadIdentityEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetExpandedEnableGateway
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> -GatewayResourceId <String>
 -Location <String> [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>]
 [-NoProxy <String>] [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA]
 [-AzureHybridBenefit <AzureHybridBenefit>] [-ConfigurationProtectedSetting <Hashtable>]
 [-ConfigurationSetting <Hashtable>] [-CustomLocationsOid <String>] [-Distribution <String>]
 [-DistributionVersion <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-OidcIssuerProfileEnabled] [-OidcIssuerProfileSelfHostedIssuerUrl <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-WorkloadIdentityEnabled]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API to set properties of the connected cluster resource.
Replaces all configuration of an existing connected cluster; any properties not specified will be reset to their default values.

## EXAMPLES

### Example 1: Disable gateway for a connected Kubernetes cluster
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -DisableGateway
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernete cluster.

### Example 2: Enable gateway for a connected Kubernetes cluster
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -GatewayResourceId $gatewayResourceId

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command enables gateway feature of a connected kubernetes cluster.

### Example 3: Enable gateway for a connected Kubernetes cluster with InputObject
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
# Enable gateway and set gateway resource Id 
$inputObject.GatewayEnabled=$true
$inputObject.GatewayResourceId=$gatewayResourceId
Set-AzConnectedKubernetes -InputObject $inputObject     

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command enables gateway feature of a connected kubernetes cluster.

### Example 4: Enable workload identity of a connected kubernetes cluster with InputObject
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
# Enable workload identity and OIDC issuer profile
$inputObject.WorkloadIdentityEnabled=$true
$inputObject.OidcIssuerProfileEnabled=$true
Set-AzConnectedKubernetes -InputObject $inputObject 
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command enables workload identity and OIDC Issuer Profile for a connected Kubernetes cluster

### Example 5: Disable workload identity of a connected kubernetes cluster with InputOjbect
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
# Disable workload identity 
$inputObject.WorkloadIdentityEnabled=$falue
Set-AzConnectedKubernetes -InputObject $inputObject 
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disables workload identity of a connected kubernetes cluster

### Example 6: Disable workload identity of a connected kubernetes cluster
```powershell
Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId | Set-AzConnectedKubernetes -WorkloadIdentityEnabled:$false
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disables workload identity of a connected kubernetes cluster

## PARAMETERS

### -AcceptEULA
Accept EULA of ConnectedKubernetes, legal term will pop up without this parameter provided

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

### -AzureHybridBenefit
Indicates whether Azure Hybrid Benefit is opted in

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.AzureHybridBenefit
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Kubernetes cluster on which get is called.

```yaml
Type: System.String
Parameter Sets: SetExpanded, SetExpandedDisableGateway, SetExpandedEnableGateway
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationProtectedSetting
Arc Agentry System Protected Configuration

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

### -ConfigurationSetting
Arc Agentry System Configuration

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

### -ContainerLogPath
Override the default container log path to enable fluent-bit logging.

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

### -CustomLocationsOid
OID of 'custom-locations' app.

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

### -DisableAutoUpgrade
Flag to disable auto upgrade of arc agents.

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

### -DisableGateway


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetDisableGateway, SetExpandedDisableGateway
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Distribution
The Kubernetes distribution running on this connected cluster.

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

### -DistributionVersion
The Kubernetes distribution version on this connected cluster.

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

### -GatewayResourceId
Arc Gateway resource Id, providing this will enable the gateway

```yaml
Type: System.String
Parameter Sets: SetEnableGateway, SetExpandedEnableGateway
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpProxy
The http URI of the proxy server for the kubernetes cluster to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpsProxy
The https URI of the proxy server for the kubernetes cluster to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Infrastructure
The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster
Parameter Sets: Set, SetDisableGateway, SetEnableGateway
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KubeConfig
Path to the kube config file

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

### -KubeContext
Kubconfig context from current machine

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
Parameter Sets: SetExpanded, SetExpandedDisableGateway, SetExpandedEnableGateway
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoProxy
The comma-separated list of hostnames that should be excluded from the proxy server for the kubernetes cluster to use

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
Whether to enable oidc issuer for workload identity integration.

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

### -OidcIssuerProfileSelfHostedIssuerUrl
The issuer url for public cloud clusters - AKS, EKS, GKE - used for the workload identity feature.

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

### -PrivateLinkScopeResourceId
The resource id of the private link scope this connected cluster is assigned to, if any.

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

### -PrivateLinkState
Property which describes the state of private link on a connected cluster resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.PrivateLinkState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Provisioning state of the connected cluster resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCert
The path to the certificate file for proxy or custom Certificate Authority.

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
Parameter Sets: SetExpanded, SetExpandedDisableGateway, SetExpandedEnableGateway
Aliases:

Required: True
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

### -WorkloadIdentityEnabled
Enable the workload identity Webhook

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster

## NOTES

## RELATED LINKS

