---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/remove-azinterconnectblock
schema: 2.0.0
---

# Remove-AzInterconnectBlock

## SYNOPSIS
Deletes an Interconnect Block.

## SYNTAX

### DefaultParameterSet (Default)
```
Remove-AzInterconnectBlock -ResourceGroupName <String> -Name <String> [-AsJob] [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzInterconnectBlock -InputObject <PSInterconnectBlock> [-AsJob] [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzInterconnectBlock** cmdlet deletes an Interconnect Block. The operation fails if any virtual machines or VMSS VM instances are still associated with the Interconnect Block. All associated VMs must be removed before deleting the block.

## EXAMPLES

### Example 1: Delete an Interconnect Block
```powershell
Remove-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB" -Force
```

This command deletes the Interconnect Block named "myICB" without prompting for confirmation.

### Example 2: Delete using an input object
```powershell
$icb = Get-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB"
Remove-AzInterconnectBlock -InputObject $icb -Force
```

This command deletes the Interconnect Block using a PSInterconnectBlock input object.

### Example 3: Delete with PassThru output
```powershell
Remove-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB" -Force -PassThru
```

This command deletes the Interconnect Block and returns an operation status response.

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

### -Force
Skip confirmation prompt.

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
PSInterconnectBlock object to delete.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSInterconnectBlock
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the Interconnect Block resource.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns a PSOperationStatusResponse containing details about the delete operation. By default, this cmdlet does not generate any output.
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
Specifies the name of a resource group.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
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

### System.String

### Microsoft.Azure.Commands.Compute.Automation.Models.PSInterconnectBlock

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSOperationStatusResponse

## NOTES

## RELATED LINKS
