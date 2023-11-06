---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhci/remove-azstackhcivmvirtualmachine
schema: 2.0.0
---

# Remove-AzStackHCIVmVirtualMachine

## SYNOPSIS
The operation to delete a virtual machine.

## SYNTAX

### ByResourceId (Default)
```
Remove-AzStackHCIVmVirtualMachine -ResourceId <String> [-InputObject <IStackHciVMIdentity>]
 [-SubscriptionId <String>] [-Force] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByName
```
Remove-AzStackHCIVmVirtualMachine -Name <String> -ResourceGroupName <String>
 [-InputObject <IStackHciVMIdentity>] [-SubscriptionId <String>] [-Force] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to delete a virtual machine.

## EXAMPLES

### Example 1: Remove a Virtual Machine 
```powershell
PS C:\> Remove-AzStackHCIVmVirtualMachine  -Name "testVm" -ResourceGroupName "test-rg"

```

This command removes the virtual machine from the specified resource group.

## PARAMETERS

### -Force
Forces the cmdlet to remove the virtual machine without prompting for confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the virtual machine

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: VirtualMachineName

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
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM Resource ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHCIVmIdentity

## OUTPUTS

### System.Boolean

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

