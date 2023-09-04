---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwareinventoryitem
schema: 2.0.0
---

# Get-AzConnectedVMwareInventoryItem

## SYNOPSIS
Implements InventoryItem GET method.

## SYNTAX

### List (Default)
```
Get-AzConnectedVMwareInventoryItem -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedVMwareInventoryItem -Name <String> -ResourceGroupName <String> -VcenterName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedVMwareInventoryItem -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityVcenter
```
Get-AzConnectedVMwareInventoryItem -Name <String> -VcenterInputObject <IConnectedVMwareIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements InventoryItem GET method.

## EXAMPLES

### Example 1: List Inventory Items in a resource group
```powershell
Get-AzConnectedVMwareInventoryItem -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Name                Kind                   ResourceGroupName
----                ----                   -----------------
resgroup-713957     ResourcePool           azcli-test-rg
resgroup-754929     ResourcePool           azcli-test-rg
resgroup-713962     ResourcePool           azcli-test-rg
dvportgroup-1153526 VirtualNetwork         azcli-test-rg
host-713958         Host                   azcli-test-rg
vmtpl-vm-1085854    VirtualMachineTemplate azcli-test-rg
datastore-563660    Datastore              azcli-test-rg
domain-c721505      Cluster                azcli-test-rg
```

This command lists Clusters in a resource group named `azcli-test-rg`.

### Example 2: Get a specific Inventory Item
```powershell
Get-AzConnectedVMwareInventoryItem -Name "domain-c649660" -VcenterName "azcli-test-vc" -ResourceGroupName "azcli-test-rg"
-SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Name           Kind    ResourceGroupName
----           ----    -----------------
domain-c649660 Cluster azcli-test-rg
```

This command gets a Inventory Item named `test-cluster` in a resource group named `azcli-test-rg`.

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
Name of the inventoryItem.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityVcenter
Aliases: InventoryItemName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VcenterInputObject
Identity Parameter
To construct, see NOTES section for VCENTERINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
Parameter Sets: GetViaIdentityVcenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VcenterName
Name of the vCenter.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IInventoryItem

## NOTES

## RELATED LINKS

