---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azmanagementgrouphierarchysetting
schema: 2.0.0
---

# Update-AzManagementGroupHierarchySetting

## SYNOPSIS
Updates Hierarchy Settings under the current tenant

## SYNTAX

### GroupOperations (Default)
```
Update-AzManagementGroupHierarchySetting [-GroupName] <String> [-Authorization <Boolean>]
 [-DefaultManagementGroup <String>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ParentGroupObject
```
Update-AzManagementGroupHierarchySetting [-GroupName] <String> [-Authorization <Boolean>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Update-AzManagementGroupHierarchySetting cmdlet updates the hierarchy settings under the current tenant. Requiring **Authorization** and setting the **DefaultManagementGroup** that new groups get created under can be updated.

## EXAMPLES

### Example 1: Update the Hierarchy Setting for Authorization Requirement for Group Creation
```powershell
Update-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization True
```

```output
Id          : /providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default
Type        : Microsoft.Management/managementGroups/settings
Name        : default
TenantId    : 00001111-aaaa-2222-bbbb-3333cccc4444
RequireAuthorizationForGroupCreation : true
DefaultManagementGroup :
```

### Example 2: Update the Hierarchy Setting that the default Management Group new Groups get placed under
```powershell
Update-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -DefaultManagementGroup TestGroup
```

```output
Id          : /providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default
Type        : Microsoft.Management/managementGroups/settings
Name        : default
TenantId    : 00001111-aaaa-2222-bbbb-3333cccc4444
RequireAuthorizationForGroupCreation : false
DefaultManagementGroup : TestGroup
```

### Example 3: Create both Hierarchy Settings
```powershell
Update-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization True -DefaultManagementGroup TestGroup
```

```output
Id          : /providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default
Type        : Microsoft.Management/managementGroups/settings
Name        : default
TenantId    : 00001111-aaaa-2222-bbbb-3333cccc4444
RequireAuthorizationForGroupCreation : true
DefaultManagementGroup : TestGroup
```

## PARAMETERS

### -Authorization
Indicate whether RBAC access is required upon group creation under the root Management Group. True means user will require Microsoft.Management/managementGroups/write action on the root Management Group. Default setting is false.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases: RequireAuthorizationForGroupCreation

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
Parameter Sets: GroupOperations
Aliases: DefaultMG

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -GroupName
Management Group Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GroupId

Required: True
Position: 0
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

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSHierarchySettings

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSHierarchySettings

## NOTES

## RELATED LINKS
