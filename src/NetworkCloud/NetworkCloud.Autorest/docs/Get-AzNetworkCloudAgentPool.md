---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudagentpool
schema: 2.0.0
---

# Get-AzNetworkCloudAgentPool

## SYNOPSIS
Get properties of the provided Kubernetes cluster agent pool.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudAgentPool -KubernetesClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudAgentPool -KubernetesClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudAgentPool -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided Kubernetes cluster agent pool.

## EXAMPLES

### Example 1: List Kubernetes cluster's agent pools
```powershell
Get-AzNetworkCloudAgentPool -KubernetesClusterName clusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location  Name               SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                     -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  agentpool1       07/11/2023 18:14:59   <identity>                          User                                          07/18/2023 17:46:45           <identity>
westus3  testagentpool1 07/18/2023 17:44:02   <identity>                         User                                          07/18/2023 17:46:45           <identity>
```

This command lists all agent pools of kubernetes cluster.

### Example 2: Get Kubernetes cluster's agent pool
```powershell
Get-AzNetworkCloudAgentPool -Name agentPoolName -KubernetesClusterName clusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location  Name               SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                     -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  testagentpool1 07/18/2023 17:44:02   <identity>                         User                                          07/18/2023 17:46:45           <identity>
```

This command gets details of an agent pool.

## PARAMETERS

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
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, List
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
Parameter Sets: Get
Aliases: AgentPoolName

Required: True
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

