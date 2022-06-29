---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/get-azvmssvmruncommand
schema: 2.0.0
---

# Get-AzVmssVMRunCommand

## SYNOPSIS
The operation to get the VMSS VM run command.

## SYNTAX

### List (Default)
```
Get-AzVmssVMRunCommand -InstanceId <String> -ResourceGroupName <String> -VMScaleSetName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVmssVMRunCommand -InstanceId <String> -ResourceGroupName <String> -RunCommandName <String>
 -VMScaleSetName <String> [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVmssVMRunCommand -InputObject <IComputeIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to get the VMSS VM run command.

## EXAMPLES

### Example 1: Get RunCommand by name
```powershell
Get-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname -RunCommandName "first" -VMScaleSetName $vmssname
```

```output
Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Get by runcommand name

### Example 2: Get RunCommand by Instance
```powershell
Get-AzVmssVMRunCommand -InstanceId 3 -ResourceGroupName $rgname  -VMScaleSetName $vmssname
```

```output
Location Name  Type
-------- ----  ----
eastus   first Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands
```

Get RunCommand by Instance

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

### -Expand
The expand expression to apply on the operation.

```yaml
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceId
The instance ID of the virtual machine.

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

### -ResourceGroupName
The name of the resource group.

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

### -RunCommandName
The name of the virtual machine run command.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -VMScaleSetName
The name of the VM scale set.

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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IVirtualMachineRunCommand

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IComputeIdentity>`: Identity Parameter
  - `[CommandId <String>]`: The command id.
  - `[GalleryApplicationName <String>]`: The name of the gallery Application Definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryApplicationVersionName <String>]`: The name of the gallery Application Version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryImageName <String>]`: The name of the gallery image definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryImageVersionName <String>]`: The name of the gallery image version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryName <String>]`: The name of the Shared Image Gallery. The allowed characters are alphabets and numbers with dots and periods allowed in the middle. The maximum length is 80 characters.
  - `[Id <String>]`: Resource identity path
  - `[InstanceId <String>]`: The instance ID of the virtual machine.
  - `[Location <String>]`: The location upon which run commands is queried.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[RunCommandName <String>]`: The name of the virtual machine run command.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VMName <String>]`: The name of the virtual machine where the run command should be created or updated.
  - `[VMScaleSetName <String>]`: The name of the VM scale set.

## RELATED LINKS

