---
external help file: Az.ConnectedVMware-help.xml
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarevmtemplate
schema: 2.0.0
---

# Get-AzConnectedVMwareVMTemplate

## SYNOPSIS
Implements virtual machine template GET method.

## SYNTAX

### List (Default)
```
Get-AzConnectedVMwareVMTemplate [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedVMwareVMTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzConnectedVMwareVMTemplate -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedVMwareVMTemplate -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Implements virtual machine template GET method.

## EXAMPLES

### Example 1: List VM Templates in current subscription
```powershell
Get-AzConnectedVMwareVMTemplate -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                             ResourceGroupName
----   --------      ----                                             -----------------
       eastus        test-vmtmpl1                                     test-rg1
       eastus        test-vmtmpl2                                     test-rg2
       eastus        test-vmtmpl3                                     test-rg3
       eastus        test-vmtmpl4                                     test-rg4
       eastus        test-vmtmpl5                                     test-rg5
       eastus        test-vmtmpl6                                     test-rg6
       eastus        test-vmtmpl7                                     test-rg7
       eastus        test-vmtmpl8                                     test-rg8
```

This command lists VM Templates in current subscription.

### Example 2: List VM Templates in a resource group
```powershell
Get-AzConnectedVMwareVMTemplate -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
       eastus   test-vmtmpl1 test-rg
       eastus   test-vmtmpl2 test-rg
```

This command lists VM Templates in a resource group named `test-rg`.

### Example 3: Get a specific VM Template
```powershell
Get-AzConnectedVMwareVMTemplate -Name "test-vmtmpl" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CustomResourceName           : 6da8abd3-8857-4599-bd6f-831846bbdd0d
Disk                         : {{
                                 "name": "disk_1",
                                 "label": "Hard disk 1",
                                 "diskObjectId": "3-2000",
                                 "diskSizeGB": 32,
                                 "deviceKey": 2000,
                                 "diskMode": "persistent",
                                 "controllerKey": 1000,
                                 "unitNumber": 0,
                                 "diskType": "flat"
                               }}
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
FirmwareType                 :
FolderPath                   : ArcPrivateClouds-67/Templates
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualMachineTemplates/azurearcvmwareubuntu20template
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vmtpl-vm-651995
Kind                         :
Location                     : westus3
MemorySizeMb                 : 8192
MoName                       : azurearcvmwareubuntu20template
MoRefId                      : vm-651995
Name                         : azurearcvmwareubuntu20template
NetworkInterface             : {{
                                 "ipSettings": {
                                   "allocationMethod": "unset"
                                 },
                                 "name": "nic_1",
                                 "label": "Network adapter 1",
                                 "macAddress": "00:50:56:95:a2:c6",
                                 "nicType": "vmxnet3",
                                 "powerOnBoot": "enabled",
                                 "networkMoRefId": "network-563661",
                                 "networkMoName": "VM Network",
                                 "deviceKey": 4000
                               }}
NumCoresPerSocket            : 1
NumCpUs                      : 4
OSName                       : Ubuntu Linux (64-bit)
OSType                       : Linux
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-08-16T06:43:49.8483078Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-08-16T06:43:49.8483078Z"
                               }}
SystemDataCreatedAt          : 8/16/2023 6:43:21 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/16/2023 6:43:21 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
ToolsVersion                 : 11333
ToolsVersionStatus           : guestToolsSupportedNew
Type                         : microsoft.connectedvmwarevsphere/virtualmachinetemplates
Uuid                         : 6da8abd3-8857-4599-bd6f-831846bbdd0d
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command gets a VM Template named `test-vmtmpl` in a resource group named `test-rg`.

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
Name of the virtual machine template resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VirtualMachineTemplateName

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IVirtualMachineTemplate

## NOTES

## RELATED LINKS
