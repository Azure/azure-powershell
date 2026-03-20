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
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzDdosCustomPolicy cmdlet removes a DDoS custom policy resource.

## EXAMPLES

### Example 1: Remove a DDoS custom policy
```powershell
Remove-AzDdosCustomPolicy -ResourceGroupName ResourceGroupName -Name DdosCustomPolicyName
```

In this case, we remove a DDoS custom policy as specified.

### Example 2: Remove a DDoS custom policy and display confirmation
```powershell
Remove-AzDdosCustomPolicy -ResourceGroupName ResourceGroupName -Name DdosCustomPolicyName -PassThru
```

```output
True
```

This command removes the specified DDoS custom policy and returns True to confirm the successful deletion.

### Example 3: Remove using pipeline
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName ResourceGroupName -Name DdosCustomPolicyName | Remove-AzDdosCustomPolicy
```

In this example, we get a DDoS custom policy and pipe it to Remove-AzDdosCustomPolicy to delete it.

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
Specifies the name of the DDoS custom policy.

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
Returns true if the operation succeeds.

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
Specifies the name of the resource group that contains the DDoS custom policy.

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

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)
