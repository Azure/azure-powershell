---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/move-azvirtualmachinetovmss
schema: 2.0.0
---

# Move-AzVirtualMachineToVmss

## SYNOPSIS
Migrates a virtual machine from an Availability Set to a Flexible Virtual Machine Scale Set.

## SYNTAX

### ResourceGroupNameParameterSetName (Default)
```
Move-AzVirtualMachineToVmss [-ResourceGroupName] <String> [-Name] <String> [-TargetZone <String>]
 [-TargetFaultDomain <Int32>] [-TargetVMSize <String>] [-NoWait] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### IdParameterSetName
```
Move-AzVirtualMachineToVmss [-Id] <String> [-TargetZone <String>] [-TargetFaultDomain <Int32>]
 [-TargetVMSize <String>] [-NoWait] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzVirtualMachineToVmss** cmdlet migrates a virtual machine from an Availability Set to a Flexible Virtual Machine Scale Set. This operation triggers a downtime on the virtual machine. Use this cmdlet after starting the migration with Start-AzAvailabilitySetMigration.

This feature requires the subscription to be enabled for the feature flag Microsoft.Compute/MigrateToVmssFlex.

## EXAMPLES

### Example 1: Migrate a virtual machine to a VMSS
```powershell
Move-AzVirtualMachineToVmss -ResourceGroupName "MyResourceGroup" -Name "VM1"
```

This command migrates the virtual machine named VM1 in the resource group MyResourceGroup to the Flexible Virtual Machine Scale Set that was specified when migration was started.

### Example 2: Migrate a virtual machine with specific target settings
```powershell
Move-AzVirtualMachineToVmss -ResourceGroupName "MyResourceGroup" -Name "VM1" -TargetZone "1" -TargetFaultDomain 0 -TargetVMSize "Standard_DS2_v2"
```

This command migrates the virtual machine with specific target zone, fault domain, and VM size settings.

### Example 3: Migrate a virtual machine using resource ID
```powershell
Move-AzVirtualMachineToVmss -Id "/subscriptions/{sub-id}/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/VM1" -TargetZone "1"
```

This command migrates the virtual machine specified by its resource ID to zone 1.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: IdParameterSetName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The virtual machine name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupNameParameterSetName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NoWait
Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.

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

### -ResourceGroupName
Specifies the name of the resource group.

```yaml
Type: System.String
Parameter Sets: ResourceGroupNameParameterSetName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetFaultDomain
The target compute fault domain for the virtual machine migration to Flexible Virtual Machine Scale Set.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetVMSize
The target Virtual Machine size for the migration to Flexible Virtual Machine Scale Set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetZone
The target zone for the virtual machine migration to Flexible Virtual Machine Scale Set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSComputeLongRunningOperation

### Microsoft.Azure.Commands.Compute.Models.PSAzureOperationResponse

## NOTES

## RELATED LINKS

[Start-AzAvailabilitySetMigration](./Start-AzAvailabilitySetMigration.md)

[Stop-AzAvailabilitySetMigration](./Stop-AzAvailabilitySetMigration.md)

[Test-AzAvailabilitySetMigration](./Test-AzAvailabilitySetMigration.md)

[Get-AzVM](./Get-AzVM.md)
