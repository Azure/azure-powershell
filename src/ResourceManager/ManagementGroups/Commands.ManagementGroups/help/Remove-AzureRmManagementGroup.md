---
external help file: Microsoft.Azure.Commands.ManagementGroups.dll-Help.xml
Module Name: AzureRM.ManagementGroups
online version: 
schema: 2.0.0
---

# Remove-AzureRmManagementGroup

## SYNOPSIS
Removes a Management Group

## SYNTAX

```
Remove-AzureRmManagementGroup [-GroupName] <String> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Remove-AzureRMManagementGroup** cmdlet deletes a Management Group.

## EXAMPLES

### Example 1 - Remove a Management Group
``` 
PS C:\> Remove-AzureRMManagementGroup -GroupName "TestGroup"

"OK"

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

### -GroupName
The Group Name of the Management Group to delete.

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

[Update-AzureRmManagementGroup](./Update-AzureRmManagementGroup.md)

