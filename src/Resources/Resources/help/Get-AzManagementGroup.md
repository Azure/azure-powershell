---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azmanagementgroup/
schema: 2.0.0
---

# Get-AzManagementGroup

## SYNOPSIS
Gets Management Group(s)

## SYNTAX

### ListOperation (Default)
```
Get-AzManagementGroup [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### GetOperation
```
Get-AzManagementGroup [-GroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-Expand] [-Recurse]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagementGroup** cmdlet Gets all or a specific Management Group by its **GroupName**.

## EXAMPLES

### Example 1: Get all Management Groups
```powershell
Get-AzManagementGroup
```

```output
Id          : /providers/Microsoft.Management/managementGroups/TestGroup
Type        : /providers/Microsoft.Management/managementGroups
Name        : TestGroup
TenantId    : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName : TestGroupDisplayName

Id          : /providers/Microsoft.Management/managementGroups/TestGroupChild
Type        : /providers/Microsoft.Management/managementGroups
Name        : TestGroupChild
TenantId    : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName : TestGroupChildDisplayName
```

Get all Management Groups

### Example 2: Get specific Management Group
```powershell
Get-AzManagementGroup -GroupName TestGroup
```

```output
Id                : /providers/Microsoft.Management/managementGroups/TestGroup
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroup
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroupDisplayName
UpdatedTime       : 2/1/2018 11:16:12 AM
UpdatedBy         : 64360beb-ffb4-43a8-9314-01aa34db95a9
ParentId          : /providers/Microsoft.Management/managementGroups/TestGroupParent
ParentName        : TestGroupParent
ParentDisplayName : TestGroupParent
```

Get specific Management Group

### Example 3: Get specific Management Group and first level of hierarchy
<!-- Skip: Output cannot be splitted from code -->


```powershell
$reponse = Get-AzManagementGroup -GroupName TestGroupParent -Expand
$response

Id                : /providers/Microsoft.Management/managementGroups/TestGroupParent
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroupParent
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroupParent
UpdatedTime       : 2/1/2018 11:15:46 AM
UpdatedBy         : 64360beb-ffb4-43a8-9314-01aa34db95a9
ParentId          : /providers/Microsoft.Management/managementGroups/00001111-aaaa-2222-bbbb-3333cccc4444
ParentName        : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentDisplayName : 00001111-aaaa-2222-bbbb-3333cccc4444
Children          : {TestGroup1DisplayName, TestGroup2DisplayName}

$response.Children[0]

Type        : /managementGroup
Id          : /providers/Microsoft.Management/managementGroups/TestGroup1
Name        : TestGroup1
DisplayName : TestGroup1DisplayName
Children    :
```

With the `Expand` flag, one can navigate through the `Children` array and get details for each child. For example, `Children[0]` will give details for the group with display name `TestGroup1DisplayName`.

### Example 4: Get specific Management Group and all levels of hierarchy
<!-- Skip: Output cannot be splitted from code -->


```powershell
$response = Get-AzManagementGroup -GroupName TestGroupParent -Expand -Recurse
$response

Id                : /providers/Microsoft.Management/managementGroups/TestGroupParent
Type              : /providers/Microsoft.Management/managementGroups
Name              : TestGroupParent
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
DisplayName       : TestGroupParent
UpdatedTime       : 2/1/2018 11:15:46 AM
UpdatedBy         : 64360beb-ffb4-43a8-9314-01aa34db95a9
ParentId          : /providers/Microsoft.Management/managementGroups/00001111-aaaa-2222-bbbb-3333cccc4444
ParentName        : 00001111-aaaa-2222-bbbb-3333cccc4444
ParentDisplayName : 00001111-aaaa-2222-bbbb-3333cccc4444
Children          : {TestGroup1DisplayName, TestGroup2DisplayName}

$response.Children[0]

Type        : /managementGroup
Id          : /providers/Microsoft.Management/managementGroups/TestGroup1
Name        : TestGroup1
DisplayName : TestGroup1DisplayName
Children    : {TestRecurseChild}

$response.Children[0].Children[0]

Type        : /managementGroup
Id          : /providers/Microsoft.Management/managementGroups/TestRecurseChild
Name        : TestRecurseChild
DisplayName : TestRecurseChild
Children    :
```

Get specific Management Group and all levels of hierarchy

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

### -Expand
Expand the output to list the children of the management group

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetOperation
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
Parameter Sets: GetOperation
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

### -Recurse
Recursively list the children of the management group

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetOperation
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroupInfo

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroup

## NOTES

## RELATED LINKS
