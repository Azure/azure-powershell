---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 8300B143-E322-419E-BC98-DBA56DD90A59
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azroledefinition
schema: 2.0.0
---

# New-AzRoleDefinition

## SYNOPSIS
Creates a custom role in Azure RBAC.
Provide either a JSON role definition file or a PSRoleDefinition object as input.
First, use the Get-AzRoleDefinition command to generate a baseline role definition object.
Then, modify its properties as required.
Finally, use this command to create a custom role using role definition.

## SYNTAX

### InputFileParameterSet
```
New-AzRoleDefinition [-InputFile] <String> [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RoleDefinitionParameterSet
```
New-AzRoleDefinition [-Role] <PSRoleDefinition> [-SkipClientSideScopeValidation]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzRoleDefinition cmdlet creates a custom role in Azure Role-Based Access Control.
Provide a role definition as an input to the command as a JSON file or a PSRoleDefinition object.

The input role definition MUST contain the following properties:
1) DisplayName: the name of the custom role
2) Description: a short description of the role that summarizes the access that the role grants.
3) Permissions: an array of permission objects, each containing Actions and/or DataActions.
   Use Get-AzProviderOperation to get the operation for Azure resource providers that can be secured using Azure RBAC.
   Following are some valid operation strings:
   - "*/read" grants access to read operations of all Azure resource providers.
   - "Microsoft.Network/*/read" grants access to read operations for all resource types in the Microsoft.Network resource provider of Azure.
   - "Microsoft.Compute/virtualMachines/*" grants access to all operations of virtual machines and its child resource types.
4) AssignableScopes: the set of scopes (Azure subscriptions or resource groups) in which the custom role will be available for assignment.
   Following are some valid assignable scopes:
   - "/subscriptions/c276fc76-9cd4-44c9-99a7-4fd71546436e", "/subscriptions/e91d47c4-76f3-4271-a796-21b4ecfe3624": makes the role available for assignment in two subscriptions.
   - "/subscriptions/c276fc76-9cd4-44c9-99a7-4fd71546436e": makes the role available for assignment in a single subscription.
   - "/subscriptions/c276fc76-9cd4-44c9-99a7-4fd71546436e/resourceGroups/Network": makes the role available for assignment only in the Network resource group.

Each permission object in the Permissions array MAY contain:
1) Actions: the set of control plane operations to which the custom role grants access.
2) NotActions: the set of operations that must be excluded from the Actions to determine the effective actions.
3) DataActions: the set of data plane operations to which the custom role grants access.
4) NotDataActions: the set of operations that must be excluded from the DataActions.
5) Condition: an Attribute-Based Access Control (ABAC) condition that restricts the permissions.
6) ConditionVersion: the version of the condition syntax, e.g., "2.0" (required if Condition is specified).

> [!NOTE]
> The Azure RBAC API currently supports only a single element in the Permissions array when creating custom roles. While the data model supports multiple permission entries, create operations must use exactly one permission object.

Following is a sample JSON role definition that can be provided as input:
{
    "Name": "Custom VM Operator",
    "Description": "Can monitor all resources and start and restart virtual machines",
    "Permissions": \[
        {
            "Actions": \[
                "*/read",
                "Microsoft.Compute/virtualMachines/restart/action",
                "Microsoft.Compute/virtualMachines/start/action"
            \],
            "NotActions": \[
                "*/write"
            \],
            "DataActions": \[
                "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read"
            \],
            "NotDataActions": \[
                "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write"
            \]
        }
    \],
    "AssignableScopes": \["/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"\]
}

## EXAMPLES

### Example 1: Create a custom role using PSRoleDefinition object
```powershell
$role = New-Object -TypeName Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition 
$role.Name = 'Virtual Machine Operator'
$role.Description = 'Can monitor, start, and restart virtual machines.'
$role.IsCustom = $true
$role.AssignableScopes = @("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")
$permission = New-Object -TypeName Microsoft.Azure.Commands.Resources.Models.Authorization.PSPermission
$permission.Actions = @(
    "Microsoft.Compute/*/read"
    "Microsoft.Compute/virtualMachines/start/action"
    "Microsoft.Compute/virtualMachines/restart/action"
    "Microsoft.Network/*/read"
    "Microsoft.Storage/*/read"
    "Microsoft.Authorization/*/read"
    "Microsoft.Resources/subscriptions/resourceGroups/read"
    "Microsoft.Resources/subscriptions/resourceGroups/resources/read"
    "Microsoft.Insights/alertRules/*"
    "Microsoft.Support/*"
)
$role.Permissions = @($permission)

New-AzRoleDefinition -Role $role
```

Creates a custom role named "Virtual Machine Operator" with the specified actions.

### Example 2: Create a custom role using JSON file
```powershell
New-AzRoleDefinition -InputFile C:\Temp\roleDefinition.json
```

Creates a custom role from a JSON definition file.

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
File name containing a single json role definition.

```yaml
Type: System.String
Parameter Sets: InputFileParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Role
Role definition object.

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition
Parameter Sets: RoleDefinitionParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[Get-AzProviderOperation](./Get-AzProviderOperation.md)

[Get-AzRoleDefinition](./Get-AzRoleDefinition.md)

[Set-AzRoleDefinition](./Set-AzRoleDefinition.md)

[Remove-AzRoleDefinition](./Remove-AzRoleDefinition.md)
