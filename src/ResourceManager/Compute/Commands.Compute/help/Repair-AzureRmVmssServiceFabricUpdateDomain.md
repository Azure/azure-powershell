---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
Module Name: AzureRM.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.compute/repair-azurermvmssservicefabricupdatedomain
schema: 2.0.0
---

# Repair-AzureRmVmssServiceFabricUpdateDomain

## SYNOPSIS
Manual platform update domain walk to update virtual machines in a service fabric virtual machine scale set.

## SYNTAX

### DefaultParameter (Default)
```
Repair-AzureRmVmssServiceFabricUpdateDomain [-ResourceGroupName] <String> [-VMScaleSetName] <String>
 [-PlatformUpdateDomain] <Int32> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameter
```
Repair-AzureRmVmssServiceFabricUpdateDomain [-PlatformUpdateDomain] <Int32> -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ObjectParameter
```
Repair-AzureRmVmssServiceFabricUpdateDomain [-PlatformUpdateDomain] <Int32>
 -VirtualMachineScaleSet <PSVirtualMachineScaleSet> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Force manual platform update domain walk to update virtual machines in a service fabric virtual machine scale set.

## EXAMPLES

### Example 1
```
PS C:\> Repair-AzureRmVmssServiceFabricUpdateDomain -ResourceGroupName $rgname -VMScaleSetName $vmssName -PlatformUpdateDomain 0
```

This command forces service fabric update walk on UD 0 for the virtual machine scale set specified by resource group name and scale set name.

### Example 2
```
PS C:\> $vmss = Get-AzureRmVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName
PS C:\> Repair-AzureRmVmssServiceFabricUpdateDomain -VirtualMachineScaleSet $vmss -PlatformUpdateDomain 1
```

This command forces service fabric update walk on UD 1 for the virtual machine scale set specified by VM scale set object.

### Example 3
```
PS C:\> Repair-AzureRmVmssServiceFabricUpdateDomain -ResourceId $resoureId  -PlatformUpdateDomain 2;
```

This command forces service fabric update walk on UD 2 for the virtual machine scale set specified by resource id.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformUpdateDomain
The platform update domain for which a manual recovery walk is requested.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id for the virtual machine scale set.

```yaml
Type: String
Parameter Sets: ResourceIdParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSet
Local virtual machine scale set object

```yaml
Type: PSVirtualMachineScaleSet
Parameter Sets: ObjectParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VMScaleSetName
The name of the virtual machine scale set

```yaml
Type: String
Parameter Sets: DefaultParameter
Aliases: Name

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSRecoveryWalkResponse

## NOTES

## RELATED LINKS
