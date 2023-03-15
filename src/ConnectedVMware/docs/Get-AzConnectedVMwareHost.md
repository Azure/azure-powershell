---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarehost
schema: 2.0.0
---

# Get-AzConnectedVMwareHost

## SYNOPSIS
Implements host GET method.

## SYNTAX

### List (Default)
```
Get-AzConnectedVMwareHost [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedVMwareHost -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedVMwareHost -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzConnectedVMwareHost -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements host GET method.

## EXAMPLES

### Example 1: List Hosts in current subscription
```powershell
Get-AzConnectedVMwareHost -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                             ResourceGroupName
----   --------      ----                                                             -----------------
       eastus        esx04-r03-p01-f71506e8bc3e432e9ec20-southcentralus-avs-azure-com demo-2021
       eastus        esx11-r16-p01-fe4e4b599359446380db42-southeastasia-avs-azure-com naprajap
       eastus        test-host                                                        service-sdk-test
       eastus        esx12-r14-p01-f71506e8bc3e432e9ec20-southcentralus-avs-azure-com ArcbenchVM
       eastus        10-150-101-34                                                    t-ahelc-arcResource
       eastus        esx17-r07-p01-fe4e4b599359446380db42-southeastasia-avs-azure-com dshiferaw
       eastus        ArcVMwareSyntheticsInventoryHost                                 ArcVMwareSynthetics-eastus-05082022-055514AM
```

This command lists Hosts in current subscription.

### Example 2: List Hosts in a resource group
```powershell
Get-AzConnectedVMwareHost -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-host    azcli-test-rg
VMware eastus   test-host2   azcli-test-rg
```

This command lists Hosts in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Host
```powershell
Get-AzConnectedVMwareHost -Name "test-host" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-host    azcli-test-rg
```

This command gets a Host named `test-host` in a resource group named `azcli-test-rg`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Name of the host.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: HostName

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IHost

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IConnectedVMwareIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: Name of the cluster.
  - `[DatastoreName <String>]`: Name of the datastore.
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[HostName <String>]`: Name of the host.
  - `[Id <String>]`: Resource identity path
  - `[InventoryItemName <String>]`: Name of the inventoryItem.
  - `[MetadataName <String>]`: Name of the hybridIdentityMetadata.
  - `[Name <String>]`: The name of the vSphere VMware machine.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourcePoolName <String>]`: Name of the resourcePool.
  - `[SubscriptionId <String>]`: The Subscription ID.
  - `[VcenterName <String>]`: Name of the vCenter.
  - `[VirtualMachineName <String>]`: Name of the virtual machine resource.
  - `[VirtualMachineTemplateName <String>]`: Name of the virtual machine template resource.
  - `[VirtualNetworkName <String>]`: Name of the virtual network resource.

## RELATED LINKS

