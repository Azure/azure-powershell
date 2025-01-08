---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudbaremetalmachinekeyset
schema: 2.0.0
---

# Get-AzNetworkCloudBareMetalMachineKeySet

## SYNOPSIS
Get bare metal machine key set of the provided cluster.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudBareMetalMachineKeySet -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudBareMetalMachineKeySet -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudBareMetalMachineKeySet -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get bare metal machine key set of the provided cluster.

## EXAMPLES

### Example 1: Get Cluster's bare metal machine key set
```powershell
Get-AzNetworkCloudBareMetalMachineKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -Name bareMetalMachineKeySetName -SubscriptionId subscriptionId
```

```output
Location Name                          SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                     AzureAsyncOperation
-------- ----                         ------------------- -------------------     ----------------------- ------------------------  ------------------------             ---------------------------- ----                                                     -------------------
EastUs   baremetalmachinekeysetname    05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
```

This command gets a bare metal machine key set of the provided cluster.

### Example 2: Get Cluster's bare metal machine key sets
```powershell
Get-AzNetworkCloudBareMetalMachineKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name                            SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type                                                     AzureAsyncOperation
-------- ----                            ------------------- -------------------     ----------------------- ------------------------  ------------------------             ---------------------------- ----                                                     -------------------
EastUs   baremetalmachinekeysetname      05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
EastUs   baremetalmachinekeysetname1     05/30/2023 16:31:47 user1                   User                    05/30/2023 16:53:31      user1                                User                         microsoft.networkcloud/clusters/baremetalmachinekeysets
```

This command lists all bare metal machine key sets of the provided cluster.

## PARAMETERS

### -ClusterName
The name of the cluster.

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
The name of the bare metal machine key set.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BareMetalMachineKeySetName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBareMetalMachineKeySet

## NOTES

## RELATED LINKS
