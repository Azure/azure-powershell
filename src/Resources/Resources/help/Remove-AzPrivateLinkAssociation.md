---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/remove-azprivatelinkassociation
schema: 2.0.0
---

# Remove-AzPrivateLinkAssociation

## SYNOPSIS
Delete a specific azure private link association.

## SYNTAX

### DeletePLAOperation (Default)
```
Remove-AzPrivateLinkAssociation [-ManagementGroupId] <String> [-Name] <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PrivateLinkAssociationObject
```
Remove-AzPrivateLinkAssociation [-PassThru] [-Force] -InputObject <PSResourceManagementPrivateLinkAssociation>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzPrivateLinkAssociation cmdlet deletes a specific resource management private link association.

## EXAMPLES

### Example 1
```powershell
Remove-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a -Name 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4
```

```output
True
```

Delete a specific private link association.

### Example 2
```powershell
Get-AzPrivateLinkAssociation -ManagementGroupId 24f15700-370c-45bc-86a7-aee1b0c4eb8a -Name 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4 | Remove-AzPrivateLinkAssociation -Force
```

Delete a specific private link association.

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
Type: Microsoft.Azure.Commands.Resources.Models.PrivateLinks.PSResourceManagementPrivateLinkAssociation
Parameter Sets: PrivateLinkAssociationObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupId
The management group Id.

```yaml
Type: System.String
Parameter Sets: DeletePLAOperation
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The private link association Id.

```yaml
Type: System.String
Parameter Sets: DeletePLAOperation
Aliases: PrivateLinkAssociationId

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

[Get-AzPrivateLinkAssociation](./Get-AzPrivateLinkAssociation.md)
[New-AzPrivateLinkAssociation](./New-AzPrivateLinkAssociation.md)
