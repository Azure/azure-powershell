---
external help file:
Module Name: Az.KubernetesConfiguration
online version: https://learn.microsoft.com/powershell/module/az.kubernetesconfiguration/new-azkubernetesconfiguration
schema: 2.0.0
---

# New-AzKubernetesConfiguration

## SYNOPSIS
Create a new Kubernetes Source Control Configuration.

## SYNTAX

```
New-AzKubernetesConfiguration -ClusterName <String> -ClusterType <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ClusterScoped]
 [-ConfigurationProtectedSetting <Hashtable>] [-EnableHelmOperator] [-HelmOperatorChartValue <String>]
 [-HelmOperatorChartVersion <String>] [-OperatorInstanceName <String>] [-OperatorNamespace <String>]
 [-OperatorParam <String>] [-OperatorScope <OperatorScopeType>] [-OperatorType <OperatorType>]
 [-RepositoryUrl <String>] [-SshKnownHost <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new Kubernetes Source Control Configuration.

## EXAMPLES

### Example 1: Create a configuration for Kubernetes Cluster
```powershell
New-AzConnectedKubernetes -ClusterName azpstest_cluster_arc -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01
New-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azpstest_cluster_arc -Name azpstestk8s -RepositoryUrl http://github.com/xxxx -ClusterType ConnectedClusters
```

```output
Name        RepositoryUrl          ResourceGroupName
----        -------------          -----------------
azpstestk8s http://github.com/xxxx azps_test_group
```

This command creates a configuration for Kubernetes Cluster.

### Example 2: Create a configuration for Kubernetes Cluster with specify paramter OperatorNamespace
```powershell
New-AzConnectedKubernetes -ClusterName azpstest_cluster_arc -ResourceGroupName azps_test_group -Location eastus -KubeConfig $HOME\.kube\config -KubeContext azps_aks_t01
New-AzKubernetesConfiguration -ResourceGroupName azps_test_group -ClusterName azpstest_cluster_arc -Name azpstestk8s-operator -RepositoryUrl http://github.com/xxxx -OperatorScope 'cluster' -ClusterType ConnectedClusters
```

```output
Name                 RepositoryUrl          ResourceGroupName
----                 -------------          -----------------
azpstestk8s-operator http://github.com/xxxx azps_test_group
```

This command creates a configuration in the new operator namespace for Kubernetes Cluster.
Note, Unable to create a configuration in an existing operator namespace.

## PARAMETERS

### -ClusterName
The name of the kubernetes cluster.

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

### -ClusterScoped
If passed set the scope of the Configuration to Cluster (default is nameSpace).

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

### -ClusterType
The Kubernetes cluster resource name - i.e.
managedClusters, connectedClusters, provisionedClusters.

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

### -ConfigurationProtectedSetting
Name-value pairs of protected configuration settings for the configuration

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

### -EnableHelmOperator
Option to enable Helm Operator for this git configuration.

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

### -HelmOperatorChartValue
Values override for the operator Helm chart.

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

### -HelmOperatorChartVersion
Version of the operator Helm chart.

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
Name of the Source Control Configuration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SourceControlConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperatorInstanceName
Instance name of the operator - identifying the specific configuration.

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

### -OperatorNamespace
The namespace to which this operator is installed to.
Maximum of 253 lower case alphanumeric characters, hyphen and period only.

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

### -OperatorParam
Any Parameters for the Operator instance in string format.

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

### -OperatorScope
Scope at which the operator will be installed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorScopeType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperatorType
Type of the operator

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.OperatorType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RepositoryUrl
Url of the SourceControl Repository.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshKnownHost
Base64-encoded known_hosts contents containing public SSH keys required to access private Git instances

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20221101.ISourceControlConfiguration

## NOTES

ALIASES

New-AzK8sConfiguration

## RELATED LINKS

