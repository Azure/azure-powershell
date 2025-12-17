---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/new-aznetworkcloudagentpool
schema: 2.0.0
---

# New-AzNetworkCloudAgentPool

## SYNOPSIS
Create a new Kubernetes cluster agent pool or create the properties of the existing one.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkCloudAgentPool -KubernetesClusterName <String> -Name <String> -ResourceGroupName <String>
 -Count <Int64> -Location <String> -Mode <String> -VMSkuName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-AdministratorConfigurationAdminUsername <String>]
 [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-AgentOptionHugepagesCount <Int64>]
 [-AgentOptionHugepagesSize <String>]
 [-AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]>]
 [-AvailabilityZone <String[]>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-Label <IKubernetesLabel[]>] [-Tag <Hashtable>] [-Taint <IKubernetesLabel[]>]
 [-UpgradeSettingDrainTimeout <Int64>] [-UpgradeSettingMaxSurge <String>]
 [-UpgradeSettingMaxUnavailable <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityKubernetesClusterExpanded
```
New-AzNetworkCloudAgentPool -KubernetesClusterInputObject <INetworkCloudIdentity> -Name <String>
 -Count <Int64> -Location <String> -Mode <String> -VMSkuName <String> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-AdministratorConfigurationAdminUsername <String>]
 [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-AgentOptionHugepagesCount <Int64>]
 [-AgentOptionHugepagesSize <String>]
 [-AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]>]
 [-AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]>]
 [-AvailabilityZone <String[]>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-Label <IKubernetesLabel[]>] [-Tag <Hashtable>] [-Taint <IKubernetesLabel[]>]
 [-UpgradeSettingDrainTimeout <Int64>] [-UpgradeSettingMaxSurge <String>]
 [-UpgradeSettingMaxUnavailable <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkCloudAgentPool -KubernetesClusterName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkCloudAgentPool -KubernetesClusterName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new Kubernetes cluster agent pool or create the properties of the existing one.

## EXAMPLES

### Example 1: Create Kubernetes cluster's agent pool
```powershell
    $networkAttachment = @{
        AttachedNetworkId = "l3NetworkId"
    }
    $labels = @{
        Key = "key"
        Value = "value"
    }
    $taints = @{
        Key = "key"
        Value = "value"
    }
    $sshPublicKey = @{
        KeyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
    }

    New-AzNetworkCloudAgentPool -KubernetesClusterName clusterName -Name agentPoolName -ResourceGroupName resourceGroup -Count count -Location location -Mode agentPoolMode -VMSkuName vmSkuName -SubscriptionId subscriptionId -AdministratorConfigurationAdminUsername adminUsername -AdministratorConfigurationSshPublicKey $sshPublicKey -AgentOptionHugepagesCount hugepagesCount -AgentOptionHugepagesSize hugepagesSize -AttachedNetworkConfigurationL3Network $networkAttachment -AvailabilityZone availabilityZones -ExtendedLocationName clusterExtendedLocation -ExtendedLocationType "CustomLocation " -Tag @{tags = "tag"} -Label $labels -Taint $taints -UpgradeSettingMaxSurge maxSurge
```

```output
Location  Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                -------------------              -------------------                   -----------------------                    ------------------------                ------------
westus3  agentpool1 07/18/2023 17:44:02 <identity>                            User                                            07/18/2023 17:46:45         <identity>
```

This command creates an agent pool for the given Kubernetes cluster.

## PARAMETERS

### -AdministratorConfigurationAdminUsername
The user name for the administrator that will be applied to the operating systems that run Kubernetes nodes.
If not supplied, a user name will be chosen by the service.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ISshPublicKey[]
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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

### -AttachedNetworkConfigurationL2Network
The list of Layer 2 Networks and related configuration for attachment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IL2NetworkAttachmentConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationL3Network
The list of Layer 3 Networks and related configuration for attachment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IL3NetworkAttachmentConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttachedNetworkConfigurationTrunkedNetwork
The list of Trunked Networks and related configuration for attachment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ITrunkedNetworkAttachmentConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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

### -ExtendedLocationName
The resource ID of the extended location on which the resource will be created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type, for example, CustomLocation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The ETag of the transformation.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

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

### -IfNoneMatch
Set to '*' to allow a new record set to be created, but to prevent updating an existing resource.
Other values will result in error from server as they are not supported.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KubernetesClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KubernetesClusterName
The name of the Kubernetes cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
The labels applied to the nodes in this agent pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IKubernetesLabel[]
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: True
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Kubernetes cluster agent pool.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AgentPoolName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Taint
The taints applied to the nodes in this agent pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IKubernetesLabel[]
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityKubernetesClusterExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IAgentPool

## NOTES

## RELATED LINKS

