---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudkubernetesclusterfeature
schema: 2.0.0
---

# Get-AzNetworkCloudKubernetesClusterFeature

## SYNOPSIS
Get properties of the provided the Kubernetes cluster feature.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudKubernetesClusterFeature -KubernetesClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudKubernetesClusterFeature -FeatureName <String> -KubernetesClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudKubernetesClusterFeature -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided the Kubernetes cluster feature.

## EXAMPLES

### Example 1: List Kubernetes cluster's features
```powershell
Get-AzNetworkCloudKubernetesClusterFeature -KubernetesClusterName kubernetesClusterName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location Name                                  SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------- ----                                  ------------------- -------------------      ----------------------- ---------------------
uksouth  naks-1cac110b-csi-volume              11/14/2024 22:32:15 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-calico                  11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-node-local-dns          11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-csi-nfs                 11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-azure-arc-servers       11/14/2024 22:32:16 <identity>  				 Application             11/15/2024 07:04:25  
uksouth  naks-1cac110b-metrics-server          11/14/2024 22:32:16 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-cloud-provider-kubevirt 11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-multus                  11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-ipam-cni-plugin         11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:27  
uksouth  naks-1cac110b-metallb                 11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-azure-arc-k8sagents     11/14/2024 22:32:17 <identity>  				 Application             11/14/2024 22:46:28  
uksouth  naks-1cac110b-sriov-dp                11/14/2024 22:32:18 <identity>  				 Application             11/14/2024 22:46:28
```

This command lists all features of kubernetes cluster.

### Example 2: Get Kubernetes cluster's feature
```powershell
Get-AzNetworkCloudKubernetesClusterFeature -KubernetesClusterName kubernetesClusterName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -FeatureName featureName
```

```output
Location Name                                  SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------- ----                                  ------------------- -------------------      ----------------------- ---------------------
uksouth  naks-1cac110b-csi-volume              11/14/2024 22:32:15 <identity>  				 Application             11/14/2024 22:46:27
```

This command gets details of an Kubernetes cluster feature.

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

### -FeatureName
The name of the feature.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: List, Get
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IKubernetesClusterFeature

## NOTES

## RELATED LINKS
