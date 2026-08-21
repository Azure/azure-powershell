---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/start-azavailabilitysetmigration
schema: 2.0.0
---

# Start-AzAvailabilitySetMigration

## SYNOPSIS
Starts the migration operation on an Availability Set to a Flexible Virtual Machine Scale Set.

## SYNTAX

```
Start-AzAvailabilitySetMigration [-ResourceGroupName] <String> [-Name] <String>
 [-VirtualMachineScaleSetFlexibleId] <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzAvailabilitySetMigration** cmdlet starts the migration operation on an Availability Set to move its Virtual Machines to a Flexible Virtual Machine Scale Set. This should be followed by a migrate operation on each Virtual Machine using Move-AzVirtualMachineToVmss that triggers a downtime on the Virtual Machine.

This feature requires the subscription to be enabled for the feature flag Microsoft.Compute/MigrateToVmssFlex.

## EXAMPLES

### Example 1: Start migration of an Availability Set to a VMSS Flex
```powershell
Start-AzAvailabilitySetMigration -ResourceGroupName "MyResourceGroup" -Name "MyAvailabilitySet" -VirtualMachineScaleSetFlexibleId "/subscriptions/{sub-id}/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachineScaleSets/MyFlexibleVMSS"
```

This command starts the migration of the availability set named MyAvailabilitySet to the specified Flexible Virtual Machine Scale Set.

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

### -Name
The availability set name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AvailabilitySetName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSetFlexibleId
The resource ID of the Flexible Virtual Machine Scale Set to migrate to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
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

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSComputeLongRunningOperation

### Microsoft.Azure.Commands.Compute.Models.PSAzureOperationResponse

## NOTES

## RELATED LINKS

[Test-AzAvailabilitySetMigration](./Test-AzAvailabilitySetMigration.md)

[Stop-AzAvailabilitySetMigration](./Stop-AzAvailabilitySetMigration.md)

[Move-AzVirtualMachineToVmss](./Move-AzVirtualMachineToVmss.md)

[Convert-AzAvailabilitySet](./Convert-AzAvailabilitySet.md)
