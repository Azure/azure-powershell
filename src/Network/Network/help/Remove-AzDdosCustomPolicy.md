---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azddoscustompolicy
schema: 2.0.0
---

# Remove-AzDdosCustomPolicy

## SYNOPSIS
Removes a DDoS custom policy.

## SYNTAX

```
Remove-AzDdosCustomPolicy -ResourceGroupName <String> -Name <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzDdosCustomPolicy** cmdlet removes a DDoS custom policy from a resource group.

## EXAMPLES

### Example 1: Remove a DDoS custom policy
```powershell
Remove-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
```

This example removes the DDoS custom policy named "myPolicy" from the resource group "myRG".

### Example 2: Remove a DDoS custom policy and display confirmation
```powershell
Remove-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" -PassThru
```

This example removes the DDoS custom policy and displays a confirmation message.

### Example 3: Remove a DDoS custom policy with confirmation prompt
```powershell
Remove-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" -Confirm
```

This example removes the DDoS custom policy after showing a confirmation prompt.

## PARAMETERS

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
Specifies the name of the DDoS custom policy to be removed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item with which you are working. By default, this cmdlet does not generate any output.

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
Specifies the resource group of the DDoS custom policy to be removed.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[New-AzDdosCustomPolicyDetectionRule](./New-AzDdosCustomPolicyDetectionRule.md)
