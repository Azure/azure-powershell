---
external help file:
Module Name: Az.KubernetesConfiguration
online version: https://docs.microsoft.com/powershell/module/az.kubernetesconfiguration/new-azkubernetesextension
schema: 2.0.0
---

# New-AzKubernetesExtension

## SYNOPSIS
Create a new Kubernetes Cluster Extension.

## SYNTAX

```
New-AzKubernetesExtension -ClusterName <String> -ClusterType <String> -Name <String>
 -ResourceGroupName <String> -ExtensionType <String> [-SubscriptionId <String>]
 [-AkAssignedIdentityType <ResourceIdentityType>] [-AutoUpgradeMinorVersion]
 [-ClusterReleaseNamespace <String>] [-ConfigurationProtectedSetting <Hashtable>]
 [-ConfigurationSetting <Hashtable>] [-IdentityType <ResourceIdentityType>]
 [-NamespaceTargetNamespace <String>] [-ReleaseTrain <String>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new Kubernetes Cluster Extension.

## EXAMPLES

### Example 1: Create a new Kubernetes Cluster Extension.
```powershell
New-AzKubernetesExtension -ClusterName azps_test_cluster -ClusterType ConnectedClusters -Name azps_test_extension -ResourceGroupName azps_test_group -ExtensionType Microsoft.Arcdataservices
```

```output
Name                ExtensionType             Version      ProvisioningState AutoUpgradeMinorVersion ReleaseTrain ResourceGroupName
----                -------------             -------      ----------------- ----------------------- ------------ -----------------
azps_test_extension microsoft.arcdataservices 1.0.16701001 Succeeded         True                    Stable       azps_test_group
```

Create a new Kubernetes Cluster Extension.

## PARAMETERS

### -AkAssignedIdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ResourceIdentityType
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

### -AutoUpgradeMinorVersion
Flag to note if this extension participates in auto upgrade of minor version, or not.

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

### -ClusterReleaseNamespace
Namespace where the extension Release must be placed, for a Cluster scoped extension.
If this namespace does not exist, it will be created

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

### -ClusterType
The Kubernetes cluster resource name - either managedClusters (for AKS clusters) or connectedClusters (for OnPrem K8S clusters).

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
Configuration settings that are sensitive, as name-value pairs for configuring this extension.

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
Configuration settings, as name-value pairs for configuring this extension.

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

### -ExtensionType
Type of the Extension, of which this resource is an instance of.
It must be one of the Extension Types registered with Microsoft.KubernetesConfiguration by the Extension publisher.

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

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Extension.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ExtensionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceTargetNamespace
Namespace where the extension will be created for an Namespace scoped extension.
If this namespace does not exist, it will be created

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

### -ReleaseTrain
ReleaseTrain this extension participates in for auto-upgrade (e.g.
Stable, Preview, etc.) - only if autoUpgradeMinorVersion is 'true'.

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

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

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

### -Version
Version of the extension for this extension, if it is 'pinned' to a specific version.
autoUpgradeMinorVersion must be 'false'.

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210901.IExtension

## NOTES

ALIASES

New-AzK8sExtension

## RELATED LINKS

