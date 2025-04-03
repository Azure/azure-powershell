---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudkubernetescluster
schema: 2.0.0
---

# Get-AzNetworkCloudKubernetesCluster

## SYNOPSIS
Get properties of the provided the Kubernetes cluster.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudKubernetesCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudKubernetesCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudKubernetesCluster -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudKubernetesCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided the Kubernetes cluster.

## EXAMPLES

### Example 1: List Kubernetes clusters by subscription
```powershell
Get-AzNetworkCloudKubernetesCluster -SubscriptionId subscriptionId
```

```output
Location Name                          SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----                          ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location kubernetesCluster1            06/30/2023 20:39:44 <Identity>                           User                    08/03/2023 20:26:35      <Identity>                           Application                  resourceGroupName
location kubernetesCluster2            07/11/2023 02:49:35 <Identity>                           User                    08/03/2023 20:26:32      <Identity>                           Application                  resourceGroupName
location kubernetesCluster3            07/15/2023 22:04:00 <Identity>                           Application             07/15/2023 22:18:48      <Identity>                           Application                  resourceGroupName
location kubernetesCluster4            07/25/2023 21:00:31 <Identity>                           User                    08/03/2023 20:26:37      <Identity>                           Application                  resourceGroupName

```

This command lists all Kubernetes clusters under a subscription.

### Example 2: Get Kubernetes cluster
```powershell
Get-AzNetworkCloudKubernetesCluster -KubernetesClusterName kubernetesClusterName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location default 08/09/2023 20:23:17 <Identity>             User                    08/09/2023 20:44:27      <Identity>                           Application                  resourceGroupName
```

This command gets a Kubernetes cluster by name.

### Example 3: List Kubernetes cluster by resource group
```powershell
Get-AzNetworkCloudKubernetesCluster -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
location default 08/09/2023 20:23:17 <Identity>             User                    08/09/2023 20:44:27      <Identity>                           Application                  resourceGroupName
```

This command lists all Kubernetes clusters in a resource group.

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

### -Name
The name of the Kubernetes cluster.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: KubernetesClusterName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IKubernetesCluster

## NOTES

## RELATED LINKS

