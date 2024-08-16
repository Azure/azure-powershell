---
external help file:
Module Name: Az.ConnectedKubernetes
online version: https://learn.microsoft.com/powershell/module/az.connectedkubernetes/new-azconnectedkubernetes
schema: 2.0.0
---

# New-AzConnectedKubernetes

## SYNOPSIS


## SYNTAX

```
New-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> -Location <String>
 [-ContainerLogPath <String>] [-DisableAutoUpgrade] [-HttpProxy <Uri>] [-HttpsProxy <Uri>] [-NoProxy <String>]
 [-OnboardingTimeout <Int32>] [-ProxyCert <String>] [-SubscriptionId <String>] [-AcceptEULA]
 [-AzureHybridBenefit <AzureHybridBenefit>] [-CustomLocationsOid <String>] [-Distribution <String>]
 [-DistributionVersion <String>] [-Infrastructure <String>] [-KubeConfig <String>] [-KubeContext <String>]
 [-PrivateLinkScopeResourceId <String>] [-PrivateLinkState <PrivateLinkState>]
 [-ProvisioningState <ProvisioningState>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ArcAgentryProtectedSettings <Hashtable>] [-ArcAgentrySettings <Hashtable>] [-AsJob]
 [-ConnectionType <String>] [-GatewayResourceId <String>] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Create a connected kubernetes.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command creates a connected kubernetes.

### Example 2: Create a connected kubernetes with parameters kubeConfig and kubeContext.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command creates a connected kubernetes with parameters kubeConfig and kubeContext.

### Example 3: Create a ConnectedKubernetes's AzureHybridBenefit.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01 -PrivateLinkState 'Enabled' -Distribution "AKS_Management" -DistributionVersion "1.0" -PrivateLinkScopeResourceId "/subscriptions/{subscriptionId}/resourceGroups/azps_test_group/providers/Microsoft.HybridCompute/privateLinkScopes/azps-privatelinkscope" -infrastructure "azure_stack_hci" -ProvisioningState 'Succeeded' -AzureHybridBenefit 'True'
```

```output
I confirm I have an eligible Windows Server license with Azure Hybrid Benefit to apply this benefit to AKS on Azure Stack HCI or Windows Server. Visit https://aka.ms/ahb-aks for details.
[Y] Yes  [N] No  (default is "N"): Y

Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

Create a ConnectedKubernetes's AzureHybridBenefit.

### Example 4: Using [-AcceptEULA] will default to your acceptance of the terms of our legal agreement and create a connected kubernetes.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01 -PrivateLinkState 'Enabled' -Distribution "AKS_Management" -DistributionVersion "1.0" -PrivateLinkScopeResourceId "/subscriptions/{subscriptionId}/resourceGroups/azps_test_group/providers/Microsoft.HybridCompute/privateLinkScopes/azps-privatelinkscope" -infrastructure "azure_stack_hci" -ProvisioningState 'Succeeded' -AzureHybridBenefit 'True' -AcceptEULA
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

Using [-AcceptEULA] will default to your acceptance of the terms of our legal agreement and create a connected kubernetes.

### Example 5: Create a connected kubernetes with parameters HttpProxy, HttpsProxy, NoProxy and Proxy.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01 -HttpProxy "http://proxy-user:proxy-password@proxy-ip:port" -HttpsProxy "http://proxy-user:proxy-password@proxy-ip:port" -NoProxy "localhost,127.0.0.0/8,192.168.0.0/16,172.17.0.0/16,10.96.0.0/12,10.244.0.0/16,10.43.0.0/24,.svc" -Proxy "http://proxy-user:proxy-password@proxy-ip:port" 
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

This command creates a connected kubernetes with parameters HttpProxy, HttpsProxy, NoProxy and Proxy.

### Example 6: Create a connected kubernetes with parameters HttpProxy, HttpsProxy, NoProxy, Proxy and ProxyCredential.
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$cred = New-Object System.Management.Automation.PSCredential ("proxy-user", $pwd)
New-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01 -HttpProxy "http://proxy-user:proxy-password@proxy-ip:port" -HttpsProxy "http://proxy-user:proxy-password@proxy-ip:port" -NoProxy "localhost,127.0.0.0/8,192.168.0.0/16,172.17.0.0/16,10.96.0.0/12,10.244.0.0/16,10.43.0.0/24,.svc" -Proxy "http://proxy-ip:port" -ProxyCredential $cred
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

This command creates a connected kubernetes with parameters HttpProxy, HttpsProxy, NoProxy, Proxy and ProxyCredential.

### Example 7: Create a connected kubernetes and disable auto upgrade of arc agents.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -DisableAutoUpgrade
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command creates a connected kubernetes and disable auto upgrade of arc agents.

### Example 8: Create a connected kubernetes with custom onboarding timeout.
```powershell
New-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Location eastus -OnboardingTimeout 600
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command creates a connected kubernetes with custom onboarding timeout.

## PARAMETERS

### -AcceptEULA


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

### -ArcAgentryProtectedSettings


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

### -ArcAgentrySettings


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

### -AsJob


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


```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionType


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

### -ContainerLogPath


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

### -Distribution


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

### -NoProxy


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

### -OnboardingTimeout


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

### -PrivateLinkScopeResourceId


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

### -SubscriptionId


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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240701Preview.IConnectedCluster

## NOTES

## RELATED LINKS

