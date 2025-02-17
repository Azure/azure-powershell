---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudbmckeyset
schema: 2.0.0
---

# Get-AzNetworkCloudBmcKeySet

## SYNOPSIS
Get baseboard management controller key set of the provided cluster.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudBmcKeySet -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudBmcKeySet -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudBmcKeySet -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get baseboard management controller key set of the provided cluster.

## EXAMPLES

### Example 1: List Cluster's baseboard management controller key sets
```powershell
Get-AzNetworkCloudBmcKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -Name baseboardMgtControllerKeySetName -SubscriptionId subscriptionId
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                                      e
-------- ----        ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- ----------------
eastus   baseboardmgtcontrollerkeysetname  07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                  RG-name
```

This command gets a baseboard management controller key set of the provided cluster.

### Example 2: Get Cluster's baseboard management controller key set
```powershell
Get-AzNetworkCloudBmcKeySet -ClusterName clusterName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId
```

```output
Location Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                                      e
-------- ----        ------------------- -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- ----------------
eastus   baseboardmgtcontrollerkeysetname  07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                  RG-name
eastus   baseboardmgtcontrollerkeysetname  07/27/2023 20:19:43 user1 User                    07/27/2023 20:23:23      user1 User                  RG-name
```

This command lists all baseboard management controller key sets of the provided cluster.

## PARAMETERS

### -ClusterName
The name of the cluster.

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
The name of the baseboard management controller key set.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BmcKeySetName

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBmcKeySet

## NOTES

## RELATED LINKS

