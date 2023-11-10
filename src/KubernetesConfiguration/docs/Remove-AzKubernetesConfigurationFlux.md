---
external help file:
Module Name: Az.KubernetesConfiguration
online version: https://learn.microsoft.com/powershell/module/az.kubernetesconfiguration/remove-azkubernetesconfigurationflux
schema: 2.0.0
---

# Remove-AzKubernetesConfigurationFlux

## SYNOPSIS
This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

## SYNTAX

### Delete (Default)
```
Remove-AzKubernetesConfigurationFlux -ClusterName <String> -ClusterType <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ForceDelete] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzKubernetesConfigurationFlux -InputObject <IKubernetesConfigurationIdentity> [-ForceDelete]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

## EXAMPLES

### Example 1: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
Remove-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group
```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

### Example 2: This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.
```powershell
Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azps_test_group | Remove-AzKubernetesConfigurationFlux
```

This will delete the YAML file used to set up the Flux Configuration, thus stopping future sync from the source repo.

## PARAMETERS

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

### -ClusterName
The name of the kubernetes cluster.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
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
Parameter Sets: Delete
Aliases:

Required: True
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

### -ForceDelete
Delete the extension resource in Azure - not the normal asynchronous delete.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Flux Configuration.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: FluxConfigurationName

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

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Delete
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
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

Remove-AzK8sConfigurationFlux

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IKubernetesConfigurationIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the kubernetes cluster.
  - `[ClusterResourceName <String>]`: The Kubernetes cluster resource name - i.e. managedClusters, connectedClusters, provisionedClusters.
  - `[ClusterRp <String>]`: The Kubernetes cluster RP - i.e. Microsoft.ContainerService, Microsoft.Kubernetes, Microsoft.HybridContainerService.
  - `[ExtensionName <String>]`: Name of the Extension.
  - `[FluxConfigurationName <String>]`: Name of the Flux Configuration.
  - `[Id <String>]`: Resource identity path
  - `[OperationId <String>]`: operation Id
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SourceControlConfigurationName <String>]`: Name of the Source Control Configuration.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

