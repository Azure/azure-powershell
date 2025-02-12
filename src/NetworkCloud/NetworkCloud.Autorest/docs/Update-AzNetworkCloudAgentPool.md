---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudagentpool
schema: 2.0.0
---

# Update-AzNetworkCloudAgentPool

## SYNOPSIS
Patch the properties of the provided Kubernetes cluster agent pool, or update the tags associated with the Kubernetes cluster agent pool.
Properties and tag updates can be done independently.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkCloudAgentPool -KubernetesClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-Count <Int64>]
 [-Tag <Hashtable>] [-UpgradeSettingDrainTimeout <Int64>] [-UpgradeSettingMaxSurge <String>]
 [-UpgradeSettingMaxUnavailable <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudAgentPool -InputObject <INetworkCloudIdentity>
 [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-Count <Int64>] [-Tag <Hashtable>]
 [-UpgradeSettingDrainTimeout <Int64>] [-UpgradeSettingMaxSurge <String>]
 [-UpgradeSettingMaxUnavailable <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Patch the properties of the provided Kubernetes cluster agent pool, or update the tags associated with the Kubernetes cluster agent pool.
Properties and tag updates can be done independently.

## EXAMPLES

### Example 1: Update Kubernetes cluster's agent pool
```powershell
Update-AzNetworkCloudAgentPool -Name agentPoolName -KubernetesClusterName clusterName -ResourceGroupName resourceGroup -Count updatedCount -Tag @{tags = "newTag"} -UpgradeSettingMaxSurge updatedMaxSurge
```

```output
Location Name           SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------      ----                -------------------               -------------------                  -----------------------                   ------------------------                  --
westus3  agentpool1 07/17/2023 18:14:59 <identity>                           Application                              07/18/2023 17:06:24           <identity>
```

This command updates a Kubernetes cluster agent pool's properties.

## PARAMETERS

### -AdministratorConfigurationSshPublicKey
SshPublicKey represents the public key used to authenticate with a resource through SSH.
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

### -Count
The number of virtual machines that use this configuration.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The Azure resource tags that will replace the existing ones.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IAgentPool

## NOTES

## RELATED LINKS

