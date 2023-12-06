### Example 1: List Inventory Items in a resource group of a vcenter
```powershell
Get-AzConnectedVMwareInventoryItem -ResourceGroupName "test-rg" -VcenterName "test-vc"
```

```output
Name                SystemDataCreatedAt   SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Kind                   ResourceGroupName
----                -------------------   -------------------                  ----------------------- ------------------------ ------------------------             ---------------------------- ----                   -----------------
resgroup-713957     2/16/2023 3:54:14 PM  ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application             8/1/2023 5:27:42 AM      ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application                  ResourcePool           test-rg
resgroup-754929     2/16/2023 3:54:14 PM  ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application             8/1/2023 5:27:44 AM      ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application                  ResourcePool           test-rg
dvportgroup-1153526 2/16/2023 3:54:17 PM  ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application             8/1/2023 5:26:11 AM      ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application                  VirtualNetwork         test-rg
host-713958         2/16/2023 3:54:17 PM  ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application             8/1/2023 5:26:32 AM      ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application                  Host                   test-rg
vmtpl-vm-1085854    2/16/2023 3:54:17 PM  ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application             8/1/2023 5:29:46 AM      ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application                  VirtualMachineTemplate test-rg
datastore-563660    2/16/2023 3:54:17 PM  ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application             10/5/2023 5:15:03 PM     ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7 Application                  Datastore              test-rg
```

This command list all the inventory items of vcenter `test-vc` in a resource group named `test-rg`.

### Example 2: Get a specific Inventory Item
```powershell
Get-AzConnectedVMwareInventoryItem -Name "vm-1528708" -VcenterName "test-vc" -ResourceGroupName "test-rg"
```

```output
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vm-1528708
InventoryType                : VirtualMachine
Kind                         : VirtualMachine
ManagedResourceId            :
MoName                       : ArcVMwareTest-VM-e976dc7c
MoRefId                      : vm-1528708
Name                         : vm-1528708
Property                     : {
                                 "inventoryType": "VirtualMachine",
                                 "managedResourceId": "",
                                 "moRefId": "vm-1528708",
                                 "moName": "ArcVMwareTest-VM-e976dc7c",
                                 "provisioningState": "Succeeded",
                                 "osType": "Other",
                                 "ipAddresses": [ ],
                                 "folderPath": "ArcPrivateClouds-67",
                                 "powerState": "poweredOff"
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
SystemDataCreatedAt          : 10/5/2023 7:16:13 PM
SystemDataCreatedBy          : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 10/5/2023 7:16:13 PM
SystemDataLastModifiedBy     : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType : Application
Type                         : microsoft.connectedvmwarevsphere/vcenters/inventoryitems
```

This command gets a Inventory Item named `vm-1528708` in a resource group named `test-rg`.