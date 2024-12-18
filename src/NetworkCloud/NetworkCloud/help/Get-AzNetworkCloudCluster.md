---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudcluster
schema: 2.0.0
---

# Get-AzNetworkCloudCluster

## SYNOPSIS
Get properties of the provided cluster.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzNetworkCloudCluster -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudCluster -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided cluster.

## EXAMPLES

### Example 1: List clusters by subscription
```powershell
Get-AzNetworkCloudCluster -SubscriptionId subscriptionId
```

```output
Location    Name                   SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifi
                                                                                                                                                                                  edByType
--------    ----                   ------------------- -------------------                  ----------------------- ------------------------ ------------------------             --------------------
eastus      clusterNames              12/22/2022 19:28:28 user                                      User             05/31/2023 04:29:54         user 								User
```

This command lists all clusters under a subscription.

### Example 2: Get cluster
```powershell
Get-AzNetworkCloudCluster -Name clusterName -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGro
                                                                                                                                                                                           upName
-------- ----             ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------
eastus   clusterName        08/09/2023 18:33:54 user				            User              08/09/2023 20:05:43      user 		                            User			         RGName
```

This command gets a cluster by name.

### Example 3: List clusters by resource group
```powershell
Get-AzNetworkCloudCluster -ResourceGroupName resourceGroup -SubscriptionId subscriptionId
```

```output
Location Name             SystemDataCreatedAt SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
-------- ----             ------------------- -------------------                  ----------------------- ------------------------ ------------------------             ----------------------------
eastus   clusterNames        08/04/2023 22:38:51 user                                        User            08/07/2023 01:32:39             user                                   User
```

This command lists all clusters in a resource group.

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
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ClusterName

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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ICluster

## NOTES

## RELATED LINKS
