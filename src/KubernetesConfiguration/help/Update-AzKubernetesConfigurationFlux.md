---
external help file:
Module Name: Az.KubernetesConfiguration
online version: https://docs.microsoft.com/powershell/module/az.kubernetesconfiguration/update-azkubernetesconfigurationflux
schema: 2.0.0
---

# Update-AzKubernetesConfigurationFlux

## SYNOPSIS
Update an existing Kubernetes Flux Configuration.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzKubernetesConfigurationFlux -ClusterName <String> -ClusterType <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-BucketAccessKey <SecureString>] [-BucketInsecure]
 [-BucketLocalAuthRef <String>] [-BucketName <String>] [-BucketSyncIntervalInSecond <Int64>]
 [-BucketTimeoutInSecond <Int64>] [-BucketUrl <String>] [-ConfigurationProtectedSetting <Hashtable>]
 [-GitRepositoryHttpsCaCert <String>] [-GitRepositoryHttpsUser <String>] [-GitRepositoryLocalAuthRef <String>]
 [-GitRepositorySshKnownHost <String>] [-GitRepositorySyncIntervalInSecond <Int64>]
 [-GitRepositoryTimeoutInSecond <Int64>] [-GitRepositoryUrl <String>] [-Kustomization <Hashtable>]
 [-RepositoryRefBranch <String>] [-RepositoryRefCommit <String>] [-RepositoryRefSemver <String>]
 [-RepositoryRefTag <String>] [-SourceKind <SourceKindType>] [-Suspend] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzKubernetesConfigurationFlux -InputObject <IKubernetesConfigurationIdentity>
 [-BucketAccessKey <SecureString>] [-BucketInsecure] [-BucketLocalAuthRef <String>] [-BucketName <String>]
 [-BucketSyncIntervalInSecond <Int64>] [-BucketTimeoutInSecond <Int64>] [-BucketUrl <String>]
 [-ConfigurationProtectedSetting <Hashtable>] [-GitRepositoryHttpsCaCert <String>]
 [-GitRepositoryHttpsUser <String>] [-GitRepositoryLocalAuthRef <String>]
 [-GitRepositorySshKnownHost <String>] [-GitRepositorySyncIntervalInSecond <Int64>]
 [-GitRepositoryTimeoutInSecond <Int64>] [-GitRepositoryUrl <String>] [-Kustomization <Hashtable>]
 [-RepositoryRefBranch <String>] [-RepositoryRefCommit <String>] [-RepositoryRefSemver <String>]
 [-RepositoryRefTag <String>] [-SourceKind <SourceKindType>] [-Suspend] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an existing Kubernetes Flux Configuration.

## EXAMPLES

### Example 1: Update an existing Kubernetes Flux Configuration.
```powershell
PS C:\> Update-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Update an existing Kubernetes Flux Configuration.

### Example 2: Update an existing Kubernetes Flux Configuration.
```powershell
PS C:\> Get-AzKubernetesConfigurationFlux -ClusterName azpstest_cluster_arc -ClusterType ConnectedClusters -Name azpstestflux-k8s -ResourceGroupName azpstest_gp | Update-AzKubernetesConfigurationFlux -GitRepositoryUrl https://github.com/fluxcd/flux2-kustomize-helm-example -RepositoryRefBranch main -SourceKind 'GitRepository' -GitRepositorySyncIntervalInSecond 600 -GitRepositoryTimeoutInSecond 600 -Suspend:$false

Name             ResourceGroupName
----             -----------------
azpstestflux-k8s azpstest_gp
```

Update an existing Kubernetes Flux Configuration.

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

### -BucketAccessKey
Plaintext access key used to securely access the S3 bucket

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

### -BucketInsecure
Specify whether to use insecure communication when puling data from the S3 bucket.

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

### -BucketLocalAuthRef
Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided configuration secrets.

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

### -BucketName
The bucket name to sync from the url endpoint for the flux configuration.

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

### -BucketSyncIntervalInSecond
The interval at which to re-reconcile the cluster git repository source with the remote.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BucketTimeoutInSecond
The maximum time to attempt to reconcile the cluster git repository source with the remote.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BucketUrl
The URL to sync for the flux configuration S3 bucket.

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
The name of the kubernetes cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationProtectedSetting
Key-value pairs of protected configuration settings for the configuration

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

### -GitRepositoryHttpsCaCert
Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS

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

### -GitRepositoryHttpsUser
Plaintext HTTPS username used to access private git repositories over HTTPS

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

### -GitRepositoryLocalAuthRef
Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided configuration secrets.

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

### -GitRepositorySshKnownHost
Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH

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

### -GitRepositorySyncIntervalInSecond
The interval at which to re-reconcile the cluster git repository source with the remote.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryTimeoutInSecond
The maximum time to attempt to reconcile the cluster git repository source with the remote.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryUrl
The URL to sync for the flux configuration git repository.

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kustomization
Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster.

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

### -Name
Name of the Flux Configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -RepositoryRefBranch
The git repository branch name to checkout.

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

### -RepositoryRefCommit
The commit SHA to checkout.
This value must be combined with the branch name to be valid.
This takes precedence over semver.

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

### -RepositoryRefSemver
The semver range used to match against git repository tags.
This takes precedence over tag.

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

### -RepositoryRefTag
The git repository tag name to checkout.
This takes precedence over branch.

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceKind
Source Kind to pull the configuration data from.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.SourceKindType
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Suspend
Whether this configuration should suspend its reconciliation of its kustomizations and sources.

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.IKubernetesConfigurationIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

Update-AzK8sConfigurationFlux

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IKubernetesConfigurationIdentity>: Identity Parameter
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

