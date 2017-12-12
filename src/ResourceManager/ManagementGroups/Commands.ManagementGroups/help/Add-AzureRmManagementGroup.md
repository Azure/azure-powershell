---
external help file: Microsoft.Azure.Commands.ManagementGroups.dll-Help.xml
Module Name: AzureRM.ManagementGroups
online version: 
schema: 2.0.0
---

# Add-AzureRmManagementGroup

## SYNOPSIS
Creates a Management Group

## SYNTAX

```
Add-AzureRmManagementGroup [-GroupName] <String> [[-DisplayName] <String>] [[-ParentId] <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Add-AzureRMManagementGroup** cmdlet creates a management group.

## EXAMPLES

### Example 1: Create a Management Group
```
PS C:\> Add-AzureRMManagementGroup -GroupName "TestGroup"


Id         : /providers/Microsoft.Management/managementGroups/TestGroup
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroup
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupProperties

```


### Example 2: Create a Management Group with a parent
```
PS C:\> Add-AzureRMManagementGroup -GroupName "TestGroupChild" -ParentId "/providers/Microsoft.Management/managementGroups/TestGroup"


Id         : /providers/Microsoft.Management/managementGroups/TestGroupChild
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroupChild
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupProperties

```


### Example 3: Create a Management Group with a parent and a display name
```
PS C:\> Add-AzureRMManagementGroup -GroupName "TestGroupSecondChild" -ParentId "/providers/Microsoft.Management/managementGroups/TestGroup" -DisplayName "Test Group Second Child"


Id         : /providers/Microsoft.Management/managementGroups/TestGroupSecondChild
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroupSecondChild
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupProperties

```


## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -DisplayName
Display Name for the Management Group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupName
Group Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentId
Parent Id

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### System.String


## NOTES

## RELATED LINKS

[Remove-AzureRMManagementGroup](./Remove-AzureRMManagementGroup.md)

[Update-AzureRmManagementGroup](./Update-AzureRmManagementGroup.md)

[Get-AzureRmManagementGroup](./Get-AzureRmManagementGroup.md)
