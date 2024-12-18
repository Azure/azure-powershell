---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudInitialAgentPoolConfigurationObject
schema: 2.0.0
---

# New-AzNetworkCloudInitialAgentPoolConfigurationObject

## SYNOPSIS
Create an in-memory object for InitialAgentPoolConfiguration.

## SYNTAX

```
New-AzNetworkCloudInitialAgentPoolConfigurationObject -Count <Int64> -Mode <AgentPoolMode> -Name <String>
 -VMSkuName <String> [-AdministratorConfigurationAdminUsername <String>]
 [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-AgentOptionHugepagesCount <Int64>]
 [-AgentOptionHugepagesSize <HugepagesSize>]
 [-AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]>]
 [-AvailabilityZone <String[]>] [-Label <IKubernetesLabel[]>] [-Taint <IKubernetesLabel[]>]
 [-UpgradeSettingDrainTimeout <Int64>] [-UpgradeSettingMaxSurge <String>]
 [-UpgradeSettingMaxUnavailable <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for InitialAgentPoolConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for InitialAgentPoolConfiguration.
```powershell
New-AzNetworkCloudInitialAgentPoolConfigurationObject -Count <Int64> -Mode <AgentPoolMode> -Name <String> -VMSkuName <String> -AdministratorConfigurationAdminUsername <String> -AdministratorConfigurationSshPublicKey <ISshPublicKey[]>  -AgentOptionHugepagesCount <Int64> -AgentOptionHugepagesSize <HugepagesSize> -AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]> -AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]> -AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]> -AvailabilityZone <String[]> -Label <IKubernetesLabel[]> -Taint <IKubernetesLabel[]> -UpgradeSettingMaxSurge <String>
```

Create an in-memory object for InitialAgentPoolConfiguration.

## PARAMETERS

### -AdministratorConfigurationAdminUsername
The user name for the administrator that will be applied to the operating systems that run Kubernetes nodes.
If not supplied, a user name will be chosen by the service.

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

### -AdministratorConfigurationSshPublicKey
The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster.
In some cases, specification of public keys may be required to produce a working environment.
To construct, see NOTES section for ADMINISTRATORCONFIGURATIONSSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ISshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentOptionHugepagesCount
The number of hugepages to allocate.

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

### -AgentOptionHugepagesSize
The size of the hugepages to allocate.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.HugepagesSize
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationL2Network
The list of Layer 2 Networks and related configuration for attachment.
To construct, see NOTES section for ATTACHEDNETWORKCONFIGURATIONL2NETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL2NetworkAttachmentConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationL3Network
The list of Layer 3 Networks and related configuration for attachment.
To construct, see NOTES section for ATTACHEDNETWORKCONFIGURATIONL3NETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IL3NetworkAttachmentConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationTrunkedNetwork
The list of Trunked Networks and related configuration for attachment.
To construct, see NOTES section for ATTACHEDNETWORKCONFIGURATIONTRUNKEDNETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ITrunkedNetworkAttachmentConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
The list of availability zones of the Network Cloud cluster used for the provisioning of nodes in this agent pool.
If not specified, all availability zones will be used.

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

### -Count
The number of virtual machines that use this configuration.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
The labels applied to the nodes in this agent pool.
To construct, see NOTES section for LABEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IKubernetesLabel[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
The selection of how this agent pool is utilized, either as a system pool or a user pool.
System pools run the features and critical services for the Kubernetes Cluster, while user pools are dedicated to user workloads.
Every Kubernetes cluster must contain at least one system node pool with at least one node.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.AgentPoolMode
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name that will be used for the agent pool resource representing this agent pool.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Taint
The taints applied to the nodes in this agent pool.
To construct, see NOTES section for TAINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IKubernetesLabel[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeSettingDrainTimeout
The maximum time in seconds that is allowed for a node drain to complete before proceeding with the upgrade of the agent pool.
If not specified during creation, a value of 1800 seconds is used.

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

### -UpgradeSettingMaxSurge
The maximum number or percentage of nodes that are surged during upgrade.
This can either be set to an integer (e.g.
'5') or a percentage (e.g.
'50%').
If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade.
For percentages, fractional nodes are rounded up.
If not specified during creation, a value of 1 is used.
One of MaxSurge and MaxUnavailable must be greater than 0.

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

### -UpgradeSettingMaxUnavailable
The maximum number or percentage of nodes that can be unavailable during upgrade.
This can either be set to an integer (e.g.
'5') or a percentage (e.g.
'50%').
If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade.
For percentages, fractional nodes are rounded up.
If not specified during creation, a value of 0 is used.
One of MaxSurge and MaxUnavailable must be greater than 0.

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

### -VMSkuName
The name of the VM SKU that determines the size of resources allocated for node VMs.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.InitialAgentPoolConfiguration

## NOTES

## RELATED LINKS
