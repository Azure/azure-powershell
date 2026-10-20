---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/new-azredhatopenshifthcpcluster
schema: 2.0.0
---

# New-AzRedHatOpenShiftHcpCluster

## SYNOPSIS
Create an ARO-HCP cluster, auto-wiring the identity list and etcd KMS encryption type.

## SYNTAX

```
New-AzRedHatOpenShiftHcpCluster -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ActiveKeyName <String>] [-ActiveKeyVersion <String>]
 [-ApiAuthorizedCidR <String[]>] [-ApiVisibility <String>] [-AutoscalingMaxNodeProvisionTimeSecond <Int32>]
 [-AutoscalingMaxNodesTotal <Int32>] [-AutoscalingMaxPodGracePeriodSecond <Int32>]
 [-AutoscalingPodPriorityThreshold <Int32>] [-ClusterImageRegistryState <String>]
 [-CryptoRestriction <String>] [-DnsBaseDomainPrefix <String>] [-EnableSystemAssignedIdentity]
 [-ImageDigestMirror <IImageDigestMirror[]>] [-IngressType <String>] [-KmVaultName <String>]
 [-KmVisibility <String>] [-NetworkHostPrefix <Int32>] [-NetworkMachineCidr <String>]
 [-NetworkPodCidr <String>] [-NetworkServiceCidr <String>] [-NetworkType <String>]
 [-NodeDrainTimeoutMinute <Int32>] [-PlatformManagedResourceGroup <String>]
 [-PlatformNetworkSecurityGroupId <String>] [-PlatformOutboundType <String>] [-PlatformSubnetId <String>]
 [-PlatformVnetIntegrationSubnetId <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentityControlPlaneOperator <Hashtable>] [-UserAssignedIdentityDataPlaneOperator <Hashtable>]
 [-UserAssignedIdentityServiceManagedIdentity <String>] [-VersionChannelGroup <String>] [-VersionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Wraps the generated cluster-create cmdlet (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\New-AzRedHatOpenShiftHcpCluster, which also exposes the raw -Resource /
-JsonFilePath / -JsonString creation paths).
You pass only the operator-identity maps + KMS vault/key;
this cmdlet:
  * resolves bare identity names to full resource IDs (via the subscription/RG from -PlatformSubnetId),
  * derives -UserAssignedIdentity = control-plane operators + service MI (so you don't build it), and
  * hardcodes the etcd customer-managed encryption type to KMS.
`-UserAssignedIdentity` and `-CustomerManagedEncryptionType` are therefore not exposed here.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ActiveKeyName
name is the name of the keyvault key used for encryption/decryption.

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

### -ApiAuthorizedCidR
The list of authorized IPv4 CIDR blocks allowed to access the API server.
Maximum 500 entries.

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

### -ApiVisibility
The internet visibility of the OpenShift API server.

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
maxNodeProvisionTimeSeconds: max time to wait for node provisioning.
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
maxNodesTotal: maximum allowable number of nodes for scale-out.

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
maxPodGracePeriod: max seconds to wait for graceful pod termination before scaling down.
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

### -ClusterImageRegistryState
Cluster image registry state.
Default Enabled.

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

### -CryptoRestriction
Cryptographic restrictions for kernel and userspace libraries.

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

### -DnsBaseDomainPrefix
BaseDomainPrefix for the cluster DNS.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

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

### -IngressType
The type of the default cluster ingress.

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

### -KmVaultName
vaultName is the name of the keyvault that contains the secret.

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

### -KmVisibility
visibility of the keyvault that contains the secret.

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
The geo-location where the resource lives.

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

### -NetworkHostPrefix
Network host prefix.

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

### -NetworkMachineCidr
The CIDR block from which to assign machine IP addresses.

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

### -NetworkPodCidr
The CIDR of the pod IP addresses.

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

### -NetworkServiceCidr
The CIDR block for assigned service IPs.

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

### -NetworkType
The main controller responsible for rendering the core networking components.

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

### -PlatformManagedResourceGroup
Resource group name to put cluster resources (managed RG).

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

### -PlatformNetworkSecurityGroupId
ResourceId for the NSG attached to the cluster subnet.

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

### -PlatformOutboundType
The core outgoing configuration.

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

### -PlatformSubnetId
The Azure resource ID of the worker subnet.

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

### -PlatformVnetIntegrationSubnetId
The Azure resource ID of the VNet-integration subnet.

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
Control-plane operator identities: @{ '\<operator-name\>' = '\<resource-id-or-bare-name\>' }.

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
Data-plane operator identities: @{ '\<operator-name\>' = '\<resource-id-or-bare-name\>' }.

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

