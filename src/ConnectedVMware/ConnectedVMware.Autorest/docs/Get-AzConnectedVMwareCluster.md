---
external help file:
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarecluster
schema: 2.0.0
---

# Get-AzConnectedVMwareCluster

## SYNOPSIS
Implements cluster GET method.

## SYNTAX

### List (Default)
```
Get-AzConnectedVMwareCluster [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedVMwareCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedVMwareCluster -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzConnectedVMwareCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements cluster GET method.

## EXAMPLES

### Example 1: List Clusters in current subscription
```powershell
Get-AzConnectedVMwareCluster -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
       eastus        test-cluster1                                                    test-rg1
       eastus        test-cluster2                                                    test-rg2
       eastus        test-cluster3                                                    test-rg3
       eastus        test-cluster4                                                    test-rg4
       eastus        test-cluster5                                                    test-rg5
       eastus        test-cluster6                                                    test-rg6
       eastus        test-cluster7                                                    test-rg7
       eastus        test-cluster8                                                    test-rg8
```

This command lists Clusters in current subscription.

### Example 2: List Clusters in a resource group
```powershell
Get-AzConnectedVMwareCluster -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name          ResourceGroupName
----   -------- ----          -----------------
       eastus   test-cluster1 test-rg
       eastus   test-cluster2 test-rg
```

This command lists Clusters in a resource group named `test-rg`.

### Example 3: Get a specific Cluster
```powershell
Get-AzConnectedVMwareCluster -Name "test-cluster" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CustomResourceName           : dd163232-210f-4f82-8b0c-9866a2eac862
DatastoreId                  :
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/clusters/test-cluster
InventoryItemId              :
Kind                         :
Location                     : eastus2euap
MoName                       : Cluster-1
MoRefId                      : domain-c7
Name                         : test-cluster
NetworkId                    :
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2021-08-25T09:48:12.9989085Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2021-08-25T09:48:12.9989085Z"
                               }}
SystemDataCreatedAt          : 8/25/2021 9:38:06 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/25/2021 9:48:13 AM
SystemDataLastModifiedBy     : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
TotalCpuMHz                  :
TotalMemoryGb                :
Type                         : microsoft.connectedvmwarevsphere/clusters
UsedCpuMHz                   :
UsedMemoryGb                 :
Uuid                         : dd163232-210f-4f82-8b0c-9866a2eac862
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
```

This command gets a Cluster named `test-cluster` in a resource group named `test-rg`.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the cluster.

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

### -ResourceGroupName
The Resource Group Name.

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
The Subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.ICluster

## NOTES

## RELATED LINKS

