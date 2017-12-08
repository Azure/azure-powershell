---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
Module Name: AzureRM.Resources
ms.assetid: 115A7612-4856-47AE-AEE4-918350CD7009
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/set-azurermroleassignment
schema: 2.0.0
---

# Set-AzureRmRoleAssignment

## SYNOPSIS
Modifies a roleAssignment in Azure RBAC.
Provide the modified roleAssignment either as a JSON file or as a PSRoleAssignment.
First, use the Get-AzureRmRoleAssignment command to retrieve the roleAssignment that you wish to modify.
Then, modify the properties that you wish to change.
Finally, save the role assignment using this command.

## SYNTAX

### InputFileParameterSet
```
Set-AzureRmRoleAssignment -InputFile <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RoleAssignmentUpdateParameterSet
```
Set-AzureRmRoleAssignment -RoleAssignment <PSRoleAssignment> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Set-AzureRmRoleAssignment cmdlet updates an existing roleassignment in Azure Role-Based Access Control.
Provide the updated role assignment as an input to the command as a JSON file or a PSRoleAssignment object.
The role assignment for the updated roleassignment MUST contain all required properties of the role assignment even if they are not updated,However currenlty only update to the Allowdelegation field is allowed

Following is a sample updated role definition json for Set-AzureRmRoleDefinition

{
  {
    "roleDefinitionId": "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec92749f/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7",
    "principalId": "6f58a770-c06e-4012-b9f9-e5479c03d43f",
    "principalType": "User",
    "scope": "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec92749f/resourceGroups/abarg17186",
    "createdOn": "2017-12-08T00:34:50.7186926Z",
    "updatedOn": "2017-12-08T00:34:50.7186926Z",
    "createdBy": null,
    "updatedBy": "f8d526a0-54eb-4941-ae69-ebf4a334d0f0",
    "AllowDelegation": false
  },
  "id": "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec92749f/resourceGroups/abarg17186/providers/Microsoft.Authorization/roleAssignments/ea551700-e122-4ea1-909d-49f44db494ec",
  "type": "Microsoft.Authorization/roleAssignments",
  "name": "ea551700-e122-4ea1-909d-49f44db494ec"
}

## EXAMPLES

### --------------------------  Update using PSRoleDefinitionObject  --------------------------
```
PS C:\> $roleAssignment = Get-AzureRmRoleDefinition -ObjectId "6f58a770-c06e-4012-b9f9-e5479c03d43f" -Scope "/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec92749f/resourceGroups/abarg17186" -RoledefinitionName "Reader"
PS C:\> $roleAssignment.AllowDelegation = $true
PS C:\> Set-AzureRmRoleAssignment -RoleAssignment $roleAssignment
```

### --------------------------  Create using JSON file  --------------------------
```
PS C:\> Set-AzureRmRoleAssignment -InputFile C:\Temp\roleAssigment.json
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputFile
File name containing a single json role assignment to be updated.

```yaml
Type: String
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
Type: PSRoleAssignment
Parameter Sets: RoleAssignmentUpdateParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSRoleAssignment
Parameter 'RoleAssignment' accepts value of type 'PSRoleAssignment' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleAssignment

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, resource, group, template, deployment

## RELATED LINKS

[Get-AzureRmProviderOperation](./Get-AzureRmProviderOperation.md)

[Get-AzureRmRoleDefinition](./Get-AzureRmRoleAssignment.md)

[New-AzureRmRoleDefinition](./New-AzureRmRoleAssignment.md)

[Remove-AzureRmRoleDefinition](./Remove-AzureRmRoleAssignment.md)

