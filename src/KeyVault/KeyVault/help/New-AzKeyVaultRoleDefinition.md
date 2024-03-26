---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/new-azkeyvaultroledefinition
schema: 2.0.0
---

# New-AzKeyVaultRoleDefinition

## SYNOPSIS
Creates a custom role definition on an HSM.

## SYNTAX

### InputObject (Default)
```
New-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] [-Role] <PSKeyVaultRoleDefinition>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputFile
```
New-AzKeyVaultRoleDefinition [-HsmName] <String> [-Scope <String>] [-InputFile] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The `New-AzKeyVaultRoleDefinition` cmdlet creates a custom role in Azure Role-Based Access Control of an Azure KeyVault managed HSM.

Provide either a JSON role definition file or a `PSKeyVaultRoleDefinition` object as input.
First, use the `Get-AzKeyVaultRoleDefinition` command to generate a baseline role definition object.
Then, modify its properties as required.
Finally, use this command to create a custom role using role definition.

## EXAMPLES

### Example 1
```powershell
$role = Get-AzKeyVaultRoleDefinition -HsmName myHsm -RoleDefinitionName 'Managed HSM Crypto User'
$role.Name = $null
$role.RoleName = "my custom role"
$role.Description = "description for my role"
$role.Permissions[0].DataActions = @("Microsoft.KeyVault/managedHsm/roleAssignments/write/action", "Microsoft.KeyVault/managedHsm/roleAssignments/delete/action") # todo
New-AzKeyVaultRoleDefinition -HsmName myHsm -Role $role
```

This example uses the predefined "Managed HSM Crypto User" role as a template to create a custom role.

### Example 2
```powershell
Get-AzKeyVaultRoleDefinition -HsmName myHsm -RoleDefinitionName 'Managed HSM Crypto User' | ConvertTo-Json -Depth 9 > C:\Temp\roleDefinition.json
# Edit roleDefinition.json. Make sure to clear "Name" so as not to overwrite an existing role.
New-AzKeyVaultRoleDefinition -HsmName myHsm -InputFile C:\Temp\roleDefinition.json
```

This example uses a JSON file as the input of the custom role.

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

### -InputFile
File name containing a single role definition.

```yaml
Type: System.String
Parameter Sets: InputFile
Aliases:

Required: True
Position: 2
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

### -Role
A role definition object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultRoleDefinition
Parameter Sets: InputObject
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
Scope at which the role assignment or definition applies to, e.g., '/' or '/keys' or '/keys/{keyName}'.
'/' is used when omitted.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultRoleDefinition

## NOTES

## RELATED LINKS
