---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azmanagementgroup/
schema: 2.0.0
---

# New-AzManagementGroup

## SYNOPSIS
Creates a Management Group

## SYNTAX

### GroupOperations (Default)
```
New-AzManagementGroup [-GroupName] <String> [-DisplayName <String>] [-ParentId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ParentGroupObject
```
New-AzManagementGroup [-GroupName] <String> [-DisplayName <String>] [-DefaultProfile <IAzureContextContainer>]
 -ParentObject <PSManagementGroup> [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagementGroup** cmdlet creates a management group with name **GroupName**. The **DisplayName** and **ParentId** can also be set when creating a new Management Group.

## EXAMPLES

### Example 1: Create a Management Group
```powershell
New-AzManagementGroup -GroupName "TestGroup"
```

```output
Id                : /providers/Microsoft.Management/managementGroups/TestGroup
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroup
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroup
UpdatedTime       : 2/1/2018 11:06:27 AM
UpdatedBy         : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentId          : /providers/Microsoft.Management/managementGroups/00001111-aaaa-2222-bbbb-3333cccc4444
ParentName        : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentDisplayName : 00001111-aaaa-2222-bbbb-3333cccc4444
```

Creation of a new group with `DisplayName` and `ParentId` set to `null`. The `DisplayName` will be same as the `GroupName` and the parent of the group will be the tenant.  

### Example 2: Create a Management Group with a display name
```powershell
New-AzManagementGroup -GroupName "TestGroup" -DisplayName "TestGroupDisplayName"
```

```output
Id                : /providers/Microsoft.Management/managementGroups/TestGroup
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroup
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroup
UpdatedTime       : 2/1/2018 11:06:27 AM
UpdatedBy         : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentId          : /providers/Microsoft.Management/managementGroups/00001111-aaaa-2222-bbbb-3333cccc4444
ParentName        : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentDisplayName : 00001111-aaaa-2222-bbbb-3333cccc4444
```

In this case, the parent of the group will be the tenant and the `DisplayName` will be set to the value given.

### Example 3: Create a Management Group with a parent and a display name
```powershell
New-AzManagementGroup -GroupName "TestGroup" -DisplayName "TestGroupDisplayName" -ParentId "/providers/Microsoft.Management/managementGroups/TestGroupParent"
```

```output
Id                : /providers/Microsoft.Management/managementGroups/TestGroup
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroup
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroupDisplayName
UpdatedTime       : 2/1/2018 11:16:12 AM
UpdatedBy         : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentId          : /providers/Microsoft.Management/managementGroups/TestGroupParent
ParentName        : TestGroupParent
ParentDisplayName : TestGroupParent
```

### Example 4: Create a Management Group with a parent (using a parent object)
```powershell
$parentObject = Get-AzManagementGroup -GroupName "TestGroupParent"
New-AzManagementGroup -GroupName "TestGroup" -ParentObject $parentObject
```

```output
Id                : /providers/Microsoft.Management/managementGroups/TestGroup
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroup
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroupDisplayName
UpdatedTime       : 2/1/2018 11:16:12 AM
UpdatedBy         : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentId          : /providers/Microsoft.Management/managementGroups/TestGroupParent
ParentName        : TestGroupParent
ParentDisplayName : TestGroupParent
```

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

### -DisplayName
Display Name of the management group

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

### -ParentId
Parent Id of the management group

```yaml
Type: System.String
Parameter Sets: GroupOperations
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
Parent Object

```yaml
Type: Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroup
Parameter Sets: ParentGroupObject
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroup

## NOTES

## RELATED LINKS

[Remove-AzManagementGroup](./Remove-AzManagementGroup.md)

[Update-AzManagementGroup](./Update-AzManagementGroup.md)

[Get-AzManagementGroup](./Get-AzManagementGroup.md)
