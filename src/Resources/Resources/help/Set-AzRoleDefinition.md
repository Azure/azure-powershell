---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 115A7612-4856-47AE-AEE4-918350CD7009
online version: https://docs.microsoft.com/powershell/module/az.resources/set-azroledefinition
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
Set-AzRoleDefinition -InputFile <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RoleDefinitionParameterSet
```
Set-AzRoleDefinition -Role <PSRoleDefinition> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzRoleDefinition cmdlet updates an existing custom role in Azure Role-Based Access Control.
Provide the updated role definition as an input to the command as a JSON file or a PSRoleDefinition object.
The role definition for the updated custom role MUST contain the Id and all other required properties of the role even if they are not updated: DisplayName, Description, Actions, AssignableScopes.
NotActions, DataActions, NotDataActions are optional.
Following is a sample updated role definition json for Set-AzRoleDefinition
{
        "Id": "52a6cc13-ff92-47a8-a39b-2a8205c3087e",
        "Name": "Updated Role",
        "Description": "Can monitor all resources and start and restart virtual machines",
        "Actions":
        \[
            "*/read",
            "Microsoft.ClassicCompute/virtualmachines/restart/action",
            "Microsoft.ClassicCompute/virtualmachines/start/action"
        \],
        "NotActions":
        \[
            "*/write"
        \],
        "DataActions":
        \[
            "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read"
        \],
        "NotDataActions":
        \[
            "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/write"
        \],
        "AssignableScopes": \["/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"\]
}

## EXAMPLES

### Example 1: Update using PSRoleDefinitionObject
```powershell
PS C:\> $roleDef = Get-AzRoleDefinition "Contoso On-Call"
PS C:\> $roleDef.Actions.Add("Microsoft.ClassicCompute/virtualmachines/start/action")
PS C:\> $roleDef.Description = "Can monitor all resources and start and restart virtual machines"
PS C:\> $roleDef.AssignableScopes = @("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx", "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx")
PS C:\> Set-AzRoleDefinition -Role $roleDef
```

### Example 2: Create using JSON file
```powershell
PS C:\> Set-AzRoleDefinition -InputFile C:\Temp\roleDefinition.json
```

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

