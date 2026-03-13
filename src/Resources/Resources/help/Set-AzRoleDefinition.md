---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 115A7612-4856-47AE-AEE4-918350CD7009
online version: https://learn.microsoft.com/powershell/module/az.resources/set-azroledefinition
schema: 2.0.0
---

# Set-AzRoleDefinition

## SYNOPSIS
Modifies a custom role in Azure RBAC.
Provide the modified role definition either as a JSON file or as a PSRoleDefinition.
First, use the Get-AzRoleDefinition command to retrieve the custom role that you wish to modify.
Then, modify the properties that you wish to change.
Finally, save the role definition using this command.

## SYNTAX

### InputFileParameterSet
```
Set-AzRoleDefinition -InputFile <String> [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RoleDefinitionParameterSet
```
Set-AzRoleDefinition -Role <PSRoleDefinition> [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzRoleDefinition cmdlet updates an existing custom role in Azure Role-Based Access Control.
Provide the updated role definition as an input to the command as a JSON file or a PSRoleDefinition object.

The role definition for the updated custom role MUST contain:
- Id: the unique identifier of the role definition to update
- Name (or DisplayName): the name of the custom role
- Description: a short description of the role
- Permissions: an array of permission objects containing Actions and/or DataActions
- AssignableScopes: the scopes where the role can be assigned

Each permission object in the Permissions array can contain Actions, NotActions, DataActions, NotDataActions, and optionally Condition and ConditionVersion for Attribute-Based Access Control (ABAC) conditions.

> [!NOTE]
> The Azure RBAC API currently supports only a single element in the Permissions array when updating custom roles. While the data model supports multiple permission entries, update operations must use exactly one permission object.

## EXAMPLES

### Example 1: Update using PSRoleDefinitionObject
```powershell
$roleDef = Get-AzRoleDefinition "Contoso On-Call"
$roleDef.Permissions[0].Actions.Add("Microsoft.ClassicCompute/virtualmachines/start/action")
$roleDef.Description = "Can monitor all resources and start and restart virtual machines"
$roleDef.AssignableScopes = @("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx", "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")
Set-AzRoleDefinition -Role $roleDef
```

### Example 2: Update using JSON file
```powershell
Set-AzRoleDefinition -InputFile C:\Temp\roleDefinition.json
```

Updates a custom role definition from a JSON file. The JSON file must include the role's Id property.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -InputFile
File name containing a single json role definition to be updated.
Only include the properties that are to be updated in the JSON.
Id property is Required.

```yaml
Type: System.String
Parameter Sets: InputFileParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
Role definition object to be updated

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition
Parameter Sets: RoleDefinitionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SkipClientSideScopeValidation
If specified, skip client side scope validation.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[Get-AzProviderOperation](./Get-AzProviderOperation.md)

[Get-AzRoleDefinition](./Get-AzRoleDefinition.md)

[New-AzRoleDefinition](./New-AzRoleDefinition.md)

[Remove-AzRoleDefinition](./Remove-AzRoleDefinition.md)
