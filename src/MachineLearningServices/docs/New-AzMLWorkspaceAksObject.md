---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceAksObject
schema: 2.0.0
---

# New-AzMLWorkspaceAksObject

## SYNOPSIS
Create an in-memory object for Aks.

## SYNTAX

```
New-AzMLWorkspaceAksObject [-AgentCount <Int32>] [-AgentVMSize <String>] [-AkNetworkingDnsServiceIP <String>]
 [-AkNetworkingDockerBridgeCidr <String>] [-AkNetworkingServiceCidr <String>] [-AkNetworkingSubnetId <String>]
 [-ClusterFqdn <String>] [-ClusterPurpose <ClusterPurpose>] [-Description <String>]
 [-DisableLocalAuth <Boolean>] [-LoadBalancerSubnet <String>] [-LoadBalancerType <LoadBalancerType>]
 [-ResourceId <String>] [-SslCert <String>] [-SslCname <String>] [-SslKey <String>]
 [-SslLeafDomainLabel <String>] [-SslOverwriteExistingDomain <Boolean>] [-SslStatus <SslConfigStatus>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Aks.

## EXAMPLES

### Example 1: Create an in-memory object for Aks
```powershell
New-AzMLWorkspaceAksObject -Description "aks compute"
```

Create an in-memory object for Aks

## PARAMETERS

### -AgentCount
Number of agents.

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

### -AgentVMSize
Agent virtual machine size.

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

### -AkNetworkingDnsServiceIP
An IP address assigned to the Kubernetes DNS service.
It must be within the Kubernetes service address range specified in serviceCidr.

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

### -AkNetworkingDockerBridgeCidr
A CIDR notation IP range assigned to the Docker bridge network.
It must not overlap with any Subnet IP ranges or the Kubernetes service address range.

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

### -AkNetworkingServiceCidr
A CIDR notation IP range from which to assign service cluster IPs.
It must not overlap with any Subnet IP ranges.

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

### -AkNetworkingSubnetId
Virtual network subnet resource ID the compute nodes belong to.

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

### -ClusterFqdn
Cluster full qualified domain name.

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

### -ClusterPurpose
Intended usage of the cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ClusterPurpose
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description of the Machine Learning compute.

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

### -DisableLocalAuth
Opt-out of local authentication and ensure customers can use only MSI and AAD exclusively for authentication.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancerSubnet
Load Balancer Subnet.

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

### -LoadBalancerType
Load Balancer Type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.LoadBalancerType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ARM resource id of the underlying compute.

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

### -SslCert
Cert data.

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

### -SslCname
CNAME of the cert.

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

### -SslKey
Key data.

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

### -SslLeafDomainLabel
Leaf domain label of public endpoint.

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

### -SslOverwriteExistingDomain
Indicates whether to overwrite existing domain label.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SslStatus
Enable or disable ssl for scoring.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SslConfigStatus
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.Aks

## NOTES

ALIASES

## RELATED LINKS

