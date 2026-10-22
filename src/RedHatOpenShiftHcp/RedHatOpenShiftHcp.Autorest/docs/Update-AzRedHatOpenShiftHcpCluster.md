---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/update-azredhatopenshifthcpcluster
schema: 2.0.0
---

# Update-AzRedHatOpenShiftHcpCluster

## SYNOPSIS
Update an ARO-HCP cluster, auto-wiring the identity list when operator identities change.

## SYNTAX

```
Update-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ActiveKeyVersion <String>] [-AutoscalingMaxNodeProvisionTimeSecond <Int32>]
 [-AutoscalingMaxNodesTotal <Int32>] [-AutoscalingMaxPodGracePeriodSecond <Int32>]
 [-AutoscalingPodPriorityThreshold <Int32>] [-EnableSystemAssignedIdentity <Boolean?>]
 [-ImageDigestMirror <IImageDigestMirror[]>] [-NodeDrainTimeoutMinute <Int32>] [-Tag <Hashtable>]
 [-UserAssignedIdentityControlPlaneOperator <Hashtable>] [-UserAssignedIdentityDataPlaneOperator <Hashtable>]
 [-UserAssignedIdentityServiceManagedIdentity <String>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Wraps the generated cluster-update cmdlet (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Update-AzRedHatOpenShiftHcpCluster, which also exposes the raw -InputObject
/ -Resource paths).
When you change operator identities, this cmdlet GET-merges them with the current
cluster so you can rotate a single operator without re-listing all of them:
  * fetches the current cluster and merges your -UserAssignedIdentity*Operator maps into its existing ones,
  * resolves bare identity names to full resource IDs (using the cluster's subnet), and
  * recomputes -UserAssignedIdentity = control-plane operators + service MI (data-plane excluded, matching
    create).
`-UserAssignedIdentity` is therefore not exposed here.
If no identity parameter is supplied, the request is
forwarded unchanged (no GET).

## EXAMPLES

### Example 1: Update cluster tags
```powershell
Update-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster `
  -Tag @{ env = 'dev'; owner = 'platform-team' }
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Patches a non-identity field (resource tags) on an existing cluster.
Because no operator-identity parameters are supplied, the request is forwarded unchanged with no GET-merge.

### Example 2: Rotate a single control-plane operator identity
```powershell
Update-AzRedHatOpenShiftHcpCluster -ResourceGroupName myResourceGroup -Name myCluster `
  -UserAssignedIdentityControlPlaneOperator @{ kms = 'myCluster-cp-kms-rotated' }
```

```output
Name      Location   ResourceGroupName  VersionId ProvisioningState ApiUrl
----      --------   -----------------  --------- ----------------- ------
myCluster westeurope myResourceGroup    4.22      Succeeded         https://api.mycluster.32z5.westeurope.aroapp-hcp.io:443
```

Rotates only the `kms` control-plane operator identity.
The cmdlet GETs the current cluster, merges this override into the existing operator maps so the other 8 control-plane operators and the service MI are preserved, resolves the bare identity name to a full resource ID via the cluster's subnet, and recomputes the flat identity list (control-plane operators plus the service MI).

## PARAMETERS

### -ActiveKeyVersion
version contains the version of the key to use.

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
Run the command as a job.

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

### -AutoscalingMaxNodeProvisionTimeSecond
maxNodeProvisionTimeSeconds.
Default 900s.

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

### -AutoscalingMaxNodesTotal
maxNodesTotal.

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

### -AutoscalingMaxPodGracePeriodSecond
maxPodGracePeriod.
Default 600s.

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

### -AutoscalingPodPriorityThreshold
podPriorityThreshold.
Default -10.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use SubscriptionId instead.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageDigestMirror
imageDigestMirrors rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IImageDigestMirror[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HcpOpenShiftCluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: HcpOpenShiftClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeDrainTimeoutMinute
nodeDrainTimeoutMinutes default for all NodePools.

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

### -NoWait
Run the command asynchronously.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -UserAssignedIdentityControlPlaneOperator
Control-plane operator identities to set/rotate: @{ '\<operator-name\>' = '\<resource-id-or-bare-name\>' }.

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

### -UserAssignedIdentityDataPlaneOperator
Data-plane operator identities to set/rotate: @{ '\<operator-name\>' = '\<resource-id-or-bare-name\>' }.

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

### -UserAssignedIdentityServiceManagedIdentity
The service managed identity (resource ID or bare name).

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

### -VersionChannelGroup
ChannelGroup (e.g.
stable / fast).

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

### -VersionId
ID is the desired X.Y version of the cluster control plane.

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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IHcpOpenShiftCluster

## NOTES

## RELATED LINKS

