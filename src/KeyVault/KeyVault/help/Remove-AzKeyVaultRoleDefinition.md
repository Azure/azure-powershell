---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/remove-azkeyvaultroledefinition
schema: 2.0.0
---

# Remove-AzKeyVaultRoleDefinition

## SYNOPSIS
Removes a custom role definition from an HSM.

## SYNTAX

### ByName (Default)
```
Remove-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] -RoleName <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObject
```
Remove-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] -InputObject <PSKeyVaultRoleDefinition>
 [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The `Remove-AzKeyVaultRoleDefinition` cmdlet deletes a custom role in Azure Role-Based Access Control of Azure KeyVault managed HSM.
Provide the `-RoleName` parameter of an existing custom role or a role object to delete that custom role.
By default, `Remove-AzKeyVaultRoleDefinition` prompts you for confirmation.
To suppress the prompt, use the `-Force` parameter.

## EXAMPLES

### Example 1

```powershell
Remove-AzKeyVaultRoleDefinition -HsmName myHsm -RoleName "my role"
```

This example removes a custom role named "my role".

### Example 2

```powershell
$role = Get-AzKeyVaultRoleDefinition -HsmName myHsm -RoleName "my role"
$role | Remove-AzKeyVaultRoleDefinition -HsmName myHsm -Force
```

This example removes a custom role named "my role" by piping the role object. It also suppress the prompt by `-Force`.

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
Do not ask for confirm.

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

### -HsmName
Name of the HSM.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The object representing the role definition to be removed.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultRoleDefinition
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
This cmdlet does not return an object by default.
If this switch is specified, it returns true if successful.

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

### -RoleName
Name of the role definition to get.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: RoleDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultRoleDefinition

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
