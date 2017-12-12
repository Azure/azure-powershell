---
external help file: Microsoft.Azure.Commands.ManagementGroups.dll-Help.xml
Module Name: AzureRM.ManagementGroups
online version: 
schema: 2.0.0
---

# Update-AzureRmManagementGroup

## SYNOPSIS
Updates a Management Group

## SYNTAX

```
Update-AzureRmManagementGroup [-GroupName] <String> [[-DisplayName] <String>] [[-ParentId] <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Update-AzureRMManagementGroup** cmdlet updates the **ParentId** or **DisplayName** for a Management Group.

## EXAMPLES

### Example 1 - Update Management Group DisplayName
```
PS C:\> Update-AzureRMManagementGroup -Group "TestGroup" -DisplayName "Adjusted Test Group Display Name"

Id         : /providers/Microsoft.Management/managementGroups/TestGroup
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroup
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupProperties
```

### Example 2 - Update Management Group ParentId
```
PS C:\> Update-AzureRMManagementGroup -Group "TestGroup" -ParentId "/providers/Microsoft.Management/managementGroups/TestGroupParent"

Id         : /providers/Microsoft.Management/managementGroups/TestGroup
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroup
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
The new DisplayName

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
The GroupName of the Management Group to update.

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
The new ParentId

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

[Get-AzureRmManagementGroup](./Get-AzureRmManagementGroup.md)

[Add-AzureRmManagementGroup](./Add-AzureRmManagementGroup.md)

[Remove-AzureRMManagementGroup](./Remove-AzureRMManagementGroup.md)

