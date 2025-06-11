---
external help file: Az.ConnectedKubernetes-help.xml
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
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-AadProfileAdminGroupObjectID <String[]>] [-AadProfileEnableAzureRbac]
 [-AadProfileTenantId <String>] [-ArcAgentProfileAgentAutoUpgrade <String>]
 [-ArcAgentProfileAgentError <IAgentError[]>] [-ArcAgentProfileDesiredAgentVersion <String>]
 [-ArcAgentProfileSystemComponent <ISystemComponent[]>]
 [-ArcAgentryConfiguration <IArcAgentryConfigurations[]>] [-AzureHybridBenefit <String>]
 [-Distribution <String>] [-DistributionVersion <String>] [-GatewayEnabled] [-Infrastructure <String>]
 [-Kind <String>] [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <String>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-CustomLocationsOid <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-WorkloadIdentityEnabled] [-AcceptEULA]
 [-ConfigurationSetting <Hashtable>] [-ConfigurationProtectedSetting <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetExpandedDisableGateway
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-AadProfileAdminGroupObjectID <String[]>] [-AadProfileEnableAzureRbac]
 [-AadProfileTenantId <String>] [-ArcAgentProfileAgentAutoUpgrade <String>]
 [-ArcAgentProfileAgentError <IAgentError[]>] [-ArcAgentProfileDesiredAgentVersion <String>]
 [-ArcAgentProfileSystemComponent <ISystemComponent[]>]
 [-ArcAgentryConfiguration <IArcAgentryConfigurations[]>] [-AzureHybridBenefit <String>]
 [-Distribution <String>] [-DistributionVersion <String>] [-GatewayEnabled] [-Infrastructure <String>]
 [-Kind <String>] [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <String>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-CustomLocationsOid <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-WorkloadIdentityEnabled] [-AcceptEULA]
 [-ConfigurationSetting <Hashtable>] [-ConfigurationProtectedSetting <Hashtable>] [-DisableGateway]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetExpandedEnableGateway
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-AadProfileAdminGroupObjectID <String[]>] [-AadProfileEnableAzureRbac]
 [-AadProfileTenantId <String>] [-ArcAgentProfileAgentAutoUpgrade <String>]
 [-ArcAgentProfileAgentError <IAgentError[]>] [-ArcAgentProfileDesiredAgentVersion <String>]
 [-ArcAgentProfileSystemComponent <ISystemComponent[]>]
 [-ArcAgentryConfiguration <IArcAgentryConfigurations[]>] [-AzureHybridBenefit <String>]
 [-Distribution <String>] [-DistributionVersion <String>] [-GatewayEnabled] [-Infrastructure <String>]
 [-Kind <String>] [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <String>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-CustomLocationsOid <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-WorkloadIdentityEnabled] [-AcceptEULA]
 [-ConfigurationSetting <Hashtable>] [-ConfigurationProtectedSetting <Hashtable>] -GatewayResourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetEnableGateway
```
Set-AzConnectedKubernetes [-SubscriptionId <String>] [-AadProfileAdminGroupObjectID <String[]>]
 [-AadProfileEnableAzureRbac] [-AadProfileTenantId <String>] [-ArcAgentProfileAgentAutoUpgrade <String>]
 [-ArcAgentProfileAgentError <IAgentError[]>] [-ArcAgentProfileDesiredAgentVersion <String>]
 [-ArcAgentProfileSystemComponent <ISystemComponent[]>]
 [-ArcAgentryConfiguration <IArcAgentryConfigurations[]>] [-AzureHybridBenefit <String>]
 [-Distribution <String>] [-DistributionVersion <String>] [-GatewayEnabled] [-Infrastructure <String>]
 [-Kind <String>] [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <String>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-CustomLocationsOid <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-WorkloadIdentityEnabled] [-AcceptEULA]
 [-ConfigurationSetting <Hashtable>] [-ConfigurationProtectedSetting <Hashtable>] -GatewayResourceId <String>
 -InputObject <IConnectedCluster> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetDisableGateway
```
Set-AzConnectedKubernetes [-SubscriptionId <String>] [-AadProfileAdminGroupObjectID <String[]>]
 [-AadProfileEnableAzureRbac] [-AadProfileTenantId <String>] [-ArcAgentProfileAgentAutoUpgrade <String>]
 [-ArcAgentProfileAgentError <IAgentError[]>] [-ArcAgentProfileDesiredAgentVersion <String>]
 [-ArcAgentProfileSystemComponent <ISystemComponent[]>]
 [-ArcAgentryConfiguration <IArcAgentryConfigurations[]>] [-AzureHybridBenefit <String>]
 [-Distribution <String>] [-DistributionVersion <String>] [-GatewayEnabled] [-Infrastructure <String>]
 [-Kind <String>] [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <String>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-CustomLocationsOid <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-WorkloadIdentityEnabled] [-AcceptEULA]
 [-ConfigurationSetting <Hashtable>] [-ConfigurationProtectedSetting <Hashtable>] [-DisableGateway]
 -InputObject <IConnectedCluster> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Set
```
Set-AzConnectedKubernetes [-SubscriptionId <String>] [-AadProfileAdminGroupObjectID <String[]>]
 [-AadProfileEnableAzureRbac] [-AadProfileTenantId <String>] [-ArcAgentProfileAgentAutoUpgrade <String>]
 [-ArcAgentProfileAgentError <IAgentError[]>] [-ArcAgentProfileDesiredAgentVersion <String>]
 [-ArcAgentProfileSystemComponent <ISystemComponent[]>]
 [-ArcAgentryConfiguration <IArcAgentryConfigurations[]>] [-AzureHybridBenefit <String>]
 [-Distribution <String>] [-DistributionVersion <String>] [-GatewayEnabled] [-Infrastructure <String>]
 [-Kind <String>] [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <String>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-CustomLocationsOid <String>] [-OidcIssuerProfileEnabled]
 [-OidcIssuerProfileSelfHostedIssuerUrl <String>] [-WorkloadIdentityEnabled] [-AcceptEULA]
 [-ConfigurationSetting <Hashtable>] [-ConfigurationProtectedSetting <Hashtable>]
 -InputObject <IConnectedCluster> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
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

This command disables the gateway feature of a connected Kubernetes cluster.

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

### Example 5: Disable workload identity of a connected Kubernetes cluster with InputObject
```powershell
# Get an existing cluster first
$inputObject = Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SubscriptionId $subscriptionId
# Disable workload identity 
$inputObject.WorkloadIdentityEnabled=$false
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

### -ArcAgentProfileAgentAutoUpgrade
Indicates whether the Arc agents on the be upgraded automatically to the latest version.
Defaults to Enabled.

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

### -ArcAgentProfileAgentError
List of arc agentry and system components errors on the cluster resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IAgentError[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArcAgentProfileDesiredAgentVersion
Version of the Arc agents to be installed on the cluster resource

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

### -ArcAgentProfileSystemComponent
List of system extensions that are installed on the cluster resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.ISystemComponent[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArcAgentryConfiguration
Configuration settings for customizing the behavior of the connected cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IArcAgentryConfigurations[]
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
Type: System.String
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

### -DisableGateway

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpandedDisableGateway, SetDisableGateway
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

### -GatewayEnabled
Indicates whether the gateway for arc router connectivity is enabled.

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

### -GatewayResourceId
Arc Gateway resource Id, providing this will enable the gateway

```yaml
Type: System.String
Parameter Sets: SetExpandedEnableGateway, SetEnableGateway
Aliases:

Required: True
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedCluster
Parameter Sets: SetEnableGateway, SetDisableGateway, Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
The kind of connected cluster.

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
This is populated only if privateLinkState is enabled.
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
Type: System.String
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
Whether to enable or disable the workload identity Webhook

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedCluster

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedCluster

## NOTES

## RELATED LINKS
