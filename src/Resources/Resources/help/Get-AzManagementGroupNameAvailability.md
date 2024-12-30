---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azmanagementgroupnameavailability
schema: 2.0.0
---

# Get-AzManagementGroupNameAvailability

## SYNOPSIS
Checks if the Management Group name is available in the Tenant and a valid name.

## SYNTAX

```
Get-AzManagementGroupNameAvailability [-GroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzManagementGroupNameAvailability** checks if a Management Group Name is Available and Valid

## EXAMPLES

### Example 1: Get the Name Availability for a Valid Name
```powershell
Get-AzManagementGroupNameAvailability -GroupName "testMG"
```

```output
Message              : 
NameAvailable        : True
Reason               :
```

### Example 2: Get the Name Availability for a name that is already taken
```powershell
Get-AzManagementGroupNameAvailability -GroupName "testMG3"
```

```output
Message              : The group with the specified name already exists
NameAvailable        : False
Reason               : AlreadyExists
```

### Example 3: Get the Name Availability for a name that contains invalid characters
```powershell
Get-AzManagementGroupNameAvailability -GroupName "testMG!"
```

```output
Message              : The provided management group name has invalid characters
NameAvailable        : False
Reason               : Invalid
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

### -GroupName
Management Group Name

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

### Microsoft.Azure.Commands.Resources.Models.ManagementGroups.PSManagementGroupNameAvailabilityResult

## NOTES

## RELATED LINKS
