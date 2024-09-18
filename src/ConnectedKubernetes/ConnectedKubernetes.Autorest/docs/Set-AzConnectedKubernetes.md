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
 [-GatewayResourceId <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Set
```
Set-AzConnectedKubernetes -InputObject <IConnectedCluster> [-ContainerLogPath <String>] [-DisableAutoUpgrade]
 [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>] [-ProxyCert <String>] [-SubscriptionId <String>]
 [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>] [-ConfigurationProtectedSetting <Hashtable>]
 [-ConfigurationSetting <Hashtable>] [-CustomLocationsOid <String>] [-Distribution <String>]
 [-DistributionVersion <String>] [-GatewayResourceId <String>] [-Infrastructure <String>]
 [-KubeConfig <String>] [-KubeContext <String>] [-PrivateLinkScopeResourceId <String>]
 [-PrivateLinkState <PrivateLinkState>] [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetDisableGateway
```
Set-AzConnectedKubernetes -DisableGateway -InputObject <IConnectedCluster> [-ContainerLogPath <String>]
 [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>] [-ProxyCert <String>]
 [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-GatewayResourceId <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetEnableGateway
```
Set-AzConnectedKubernetes -EnableGateway -InputObject <IConnectedCluster> [-ContainerLogPath <String>]
 [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>] [-ProxyCert <String>]
 [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-GatewayResourceId <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetExpandedDisableGateway
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> -DisableGateway -Location <String>
 [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>]
 [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-GatewayResourceId <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetExpandedEnableGateway
```
Set-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> -EnableGateway -Location <String>
 [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>]
 [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>]
 [-ConfigurationProtectedSetting <Hashtable>] [-ConfigurationSetting <Hashtable>]
 [-CustomLocationsOid <String>] [-Distribution <String>] [-DistributionVersion <String>]
 [-GatewayResourceId <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API to set properties of the connected cluster resource

## EXAMPLES

### Example 1: Disable gateway feature  of a connected kubernetes.
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -DisableGateway
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernetes.

### Example 2: Enable gateway feature of connected kubernetes.
```powershell
Set-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -EnableGateway -GatewayResourceId gatewayResourceId

```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command disable gateway feature of a connected kubernetes.

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

### -EnableGateway


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetEnableGateway, SetExpandedEnableGateway
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GatewayResourceId
Arc Gateway resource Id

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
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster

## NOTES

## RELATED LINKS

