---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azresourcemanagementprivatelink
schema: 2.0.0
---

# Remove-AzResourceManagementPrivateLink

## SYNOPSIS
Deletes the Resource Manangement Private Link.

## SYNTAX

### DeleteOperation (Default)
```
Remove-AzResourceManagementPrivateLink [-ResourceGroupName] <String> [-Name] <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PrivateLinkObject
```
Remove-AzResourceManagementPrivateLink [-PassThru] [-Force] -InputObject <PSResourceManagementPrivateLink>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzResourceManagementPrivateLink cmdlet deletes a specific resource management private link.

## EXAMPLES

### Example 1
```powershell
Remove-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL
```

```output
True
```

Delete the specific Resource Management Private Link.

### Example 2
```powershell
Get-AzResourceManagementPrivateLink -ResourceGroupName PrivateLinkTestRG -Name NewPL | Remove-AzResourceManagementPrivateLink -Force
```

Delete the specific Resource Management Private Link.

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

### -Force
Do not ask for confirmation.

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
The private link association object.

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.PrivateLinks.PSResourceManagementPrivateLink
Parameter Sets: PrivateLinkObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the private link.

```yaml
Type: System.String
Parameter Sets: DeleteOperation
Aliases: PrivateLinkName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Do not ask for confirmation.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DeleteOperation
Aliases:

Required: True
Position: 0
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

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzResourceManagementPrivateLink](./Get-AzResourceManagementPrivateLink.md)
[New-AzResourceManagementPrivateLink](./New-AzResourceManagementPrivateLink.md)
