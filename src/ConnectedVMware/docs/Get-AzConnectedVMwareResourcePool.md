---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwareresourcepool
schema: 2.0.0
---

# Get-AzConnectedVMwareResourcePool

## SYNOPSIS
Implements resourcePool GET method.

## SYNTAX

### List (Default)
```
Get-AzConnectedVMwareResourcePool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzConnectedVMwareResourcePool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedVMwareResourcePool -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzConnectedVMwareResourcePool -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements resourcePool GET method.

## EXAMPLES

### Example 1: List Resource Pools in current subscription
```powershell
Get-AzConnectedVMwareResourcePool -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                          ResourceGroupName
----   --------      ----                                          -----------------
       eastus        vmurthy-rp                                    vmurthy-rg
       eastus        demorp                                        partnertest
       eastus        uxvmwarerp                                    uxsetups
       eastus        uxavsrp                                       uxsetups
       eastus        tulip-rp                                      shujRG
       eastus        niaro-respool                                 partner-test-appliance-eus
       eastus        shubhamRP                                     shujRG
       eastus        avs-rp                                        support-arc-rg
```

This command lists Resource Pools in current subscription.

### Example 2: List Resource Pools in a resource group
```powershell
Get-AzConnectedVMwareResourcePool -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-rp      azcli-test-rg
VMware eastus   test-rp2     azcli-test-rg
```

This command lists Resource Pools in a resource group named `azcli-test-rg`.

### Example 3: Get a specific Resource Pool
```powershell
Get-AzConnectedVMwareResourcePool -Name "test-rp" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
VMware eastus   test-rp      azcli-test-rg
```

This command gets a Resource Pool named `test-rp` in a resource group named `azcli-test-rg`.

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
Name of the resourcePool.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ResourcePoolName

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.Api20220110Preview.IResourcePool

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

