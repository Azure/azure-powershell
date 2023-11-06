---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmstoragepath
schema: 2.0.0
---

# Update-AzStackHCIVmStoragePath

## SYNOPSIS
The operation to update a storage container.

## SYNTAX

### ByResourceId (Default)
```
Update-AzStackHCIVmStoragePath [-ResourceId <String>] [-Tags <Hashtable>] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzStackHCIVmStoragePath -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tags <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStackHCIVmStoragePath -InputObject <IStackHciVMIdentity> [-Tags <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to update a storage container.

## EXAMPLES

### Example 1: Update a Storage Path.
```powershell
PS C:\> Update-AzStackHCIVmStoragePath  -Name "testVhd" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command updates an exisiting storage path in the specified resource group.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the storage container

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: StorageContainerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Resource ID of the storage path.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IStorageContainers

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStackHciVMIdentity>: Identity Parameter
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[ExtensionType <String>]`: The extensionType of the Extension being received.
  - `[GalleryImageName <String>]`: Name of the gallery image
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the Extension being received.
  - `[LogicalNetworkName <String>]`: Name of the logical network
  - `[MachineName <String>]`: The name of the hybrid machine.
  - `[MarketplaceGalleryImageName <String>]`: Name of the marketplace gallery image
  - `[MetadataName <String>]`: Name of the HybridIdentityMetadata.
  - `[NetworkInterfaceName <String>]`: Name of the network interface
  - `[OSType <String>]`: Defines the os type.
  - `[Publisher <String>]`: The publisher of the Extension being received.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.
  - `[StorageContainerName <String>]`: Name of the storage container
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[Version <String>]`: The version of the Extension being received.
  - `[VirtualHardDiskName <String>]`: Name of the virtual hard disk

## RELATED LINKS

