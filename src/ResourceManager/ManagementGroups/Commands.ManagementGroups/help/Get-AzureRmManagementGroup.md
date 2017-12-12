---
external help file: Microsoft.Azure.Commands.ManagementGroups.dll-Help.xml
Module Name: AzureRM.ManagementGroups
online version: 
schema: 2.0.0
---

# Get-AzureRmManagementGroup

## SYNOPSIS
Gets Management Group(s)

## SYNTAX

```
Get-AzureRmManagementGroup [[-GroupName] <String>] [-DefaultProfile <IAzureContextContainer>] [-Expand]
 [-Recurse]
```

## DESCRIPTION
The **Get-AzureRMManagementGroup** cmdlet Gets all or a specific Management Group.

## EXAMPLES

### Example 1 - Get all Management Groups
```
PS C:\> Get-AzureRMManagementGroup

Id         : /providers/Microsoft.Management/managementGroups/TestGroup
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroup
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupInfoProperties

Id         : /providers/Microsoft.Management/managementGroups/TestGroupChild
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroupChild
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupInfoProperties

```


### Example 2 - Get specific Management Group
```
PS C:\> Get-AzureRMManagementGroup -GroupName "TestGroup"


Id         : /providers/Microsoft.Management/managementGroups/TestGroup
Type       : /providers/Microsoft.Management/managementGroups
Name       : TestGroup
Properties : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupProperties

```


### Example 3 - Get specific Management Group and first level of hierarchy
```
PS C:\> $group = Get-AzureRMManagementGroup -GroupName "TestGroup" -Expand
PS C:\> $group | Select-Object -ExpandProperty Properties

TenantId    : 2c33d20c-ab29-45d2-8e17-0ac41fffd8e5
DisplayName : Test Group
Details     : Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroupDetails
Children    : {Test Group Second Child, Test Group Third Child, Test Group Fourth Child, Test Group First Child}

```


### Example 4 - Get specific Management Group and all levels of hiearchy
```
PS C:\> Get-AzureRMManagementGroup -GroupName "TestGroup" -Expand -Recurse

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

### -Expand
Specifies if the Management Group's first level of hierarchy should be retrieved.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupName
The Group Name of the Management Group to search for.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Recurse
Specifies if the Management Group's entire hierarchy should be retrieved. Note that **Expand** must be present in order to correctly retrieve the Management Group's hierarchy.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.ManagementGroups.Models.PSManagementGroup


## NOTES

## RELATED LINKS

[Add-AzureRmManagementGroup](./Add-AzureRmManagementGroup.md)

[Remove-AzureRMManagementGroup](./Remove-AzureRMManagementGroup.md)

[Update-AzureRmManagementGroup](./Update-AzureRmManagementGroup.md)

