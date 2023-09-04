---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarecluster
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
       eastus        Cluster-1                                                        demo-2021
       eastus        test-cluster                                                     service-sdk-test
       eastus        Cluster-1                                                        dshiferaw
       eastus        Cluster-1                                                        ArcbenchVM
       eastus        testCluster                                                      t-ahelc-arcResource
       eastus        Cluster-1                                                        daj-rg
       eastus        ArcVMwareSyntheticsInventoryCluster                              ArcVMwareSynthetics-eastus-05082022-055514AM
       eastus        Cluster-1                                                        snmuvva-pm-demos
```

This command lists Clusters in current subscription.

### Example 2: List Clusters in a resource group
```powershell
Get-AzConnectedVMwareCluster -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-cluster azcli-test-rg
VMware eastus   test-clr     azcli-test-rg
```

This command lists Clusters in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Cluster
```powershell
Get-AzConnectedVMwareCluster -Name "test-cluster" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-cluster azcli-test-rg
```

This command gets a Cluster named `test-cluster` in a resource group named `azcli-test-rg`.

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

