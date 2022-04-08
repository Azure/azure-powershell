---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azmanagementgroup/
schema: 2.0.0
---

# Update-AzHierarchySettings

## SYNOPSIS
Creates Hierarchy Settings under the current tenant

## SYNTAX

### GetOperation
```
Update-AzHierarchySettings  [-GroupName] <String> [-DefaultProfile <IAzureContextContainer>] 
[-RequireAuthorizationForGroupCreation] <String> 
[-DefaultManagementGroup] <String> 
```

## DESCRIPTION
The Update-AzHierarchySettings cmdlet updates the hierarchy settings under the current tenant.

## EXAMPLES

### Example 1: Update the Hierarchy Setting for Authorization Requirement for Group Creation
```powershell
Update-AzHierarchySettings -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -RequireAuthorizationForGroupCreation True
```

```output
Id          : /providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default
Type        : Microsoft.Management/managementGroups/settings
Name        : default
TenantId    : 6b2064b9-34bd-46e6-9092-52f2dd5f7fc0
RequireAuthorizationForGroupCreation : true
DefaultManagementGroup : 
```

### Example 2: Update the Hierarchy Setting that the default Management Group new Groups get placed under
```powershell
Update-AzHierarchySettings -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -DefaultManagementGroup TestGroup
```

```output
Id          : /providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default
Type        : Microsoft.Management/managementGroups/settings
Name        : default
TenantId    : 6b2064b9-34bd-46e6-9092-52f2dd5f7fc0
RequireAuthorizationForGroupCreation : false
DefaultManagementGroup : TestGroup
```

### Example 3: Create both Hierarchy Settings
```powershell
Update-AzHierarchySettings -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -RequireAuthorizationForGroupCreation True -DefaultManagementGroup TestGroup
```

```output
Id          : /providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default
Type        : Microsoft.Management/managementGroups/settings
Name        : default
TenantId    : 6b2064b9-34bd-46e6-9092-52f2dd5f7fc0
RequireAuthorizationForGroupCreation : true
DefaultManagementGroup : TestGroup
```



## PARAMETERS

### -GroupName
Management Group Id

```yaml
Type: System.String
Parameter Sets: GetOperation
Aliases: GroupId

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireAuthorizationForGroupCreation
Indicate whether RBAC access is required upon group creation under the root Management Group. True means user will require Microsoft.Management/managementGroups/write action on the root Management Group. Default setting is false.

```yaml
Type: System.String
Parameter Sets: NewOperation and UpdateOperation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultManagementGroup
Expand the output to list the children of the management group

```yaml
Type: System.String
Parameter Sets: NewOperation and UpdateOperation
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

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSHierarchySettings

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSHierarchySettings

## NOTES

## RELATED LINKS