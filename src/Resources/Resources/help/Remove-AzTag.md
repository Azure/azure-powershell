---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Tags.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 66B25541-0FA5-46CF-90D8-FE9527BE11C6
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/remove-aztag
=======
online version: https://docs.microsoft.com/powershell/module/az.resources/remove-aztag
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Remove-AzTag

## SYNOPSIS
<<<<<<< HEAD
Deletes predefined Azure tags or values.

## SYNTAX

```
=======
Deletes predefined Azure tags or values | Deletes the entire set of tags on a resource or subscription.

## SYNTAX

### RemovePredefinedTagParameterSet

```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Remove-AzTag [-Name] <String> [[-Value] <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

<<<<<<< HEAD
## DESCRIPTION
The **Remove-AzTag** cmdlet deletes predefined Azure tags and values from your subscription.
=======
### RemoveByResourceIdParameterSet

```powershell
Remove-AzTag
   -ResourceId <String>
   [-PassThru]
   [-DefaultProfile <IAzureContextContainer>]
   [-WhatIf]
   [-Confirm]
   [<CommonParameters>]
```

## DESCRIPTION

**RemovePredefinedTagSet**: The **Remove-AzTag** cmdlet deletes predefined Azure tags and values from your subscription.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
To delete particular values from a predefined tag, use the *Value* parameter.
By default, **Remove-AzTag** deletes the specified tag and all of its values.You cannot delete a tag or value that is currently applied to a resource or resource group.
Before using **Remove-AzTag**, use the *Tag* parameter of the Set-AzResourceGroup cmdlet to delete the tag or values from the resource or resource group.
The Azure Tags module that **Remove-AzTag** is part of can help you manage your predefined Azure tags.
An Azure tag is a name-value pair that you can use to categorize your Azure resources and resource groups, such as by department or cost center, or to track notes or comments about the resources and groups.
You can define and apply tags in a single step, but predefined tags let you establish standard, consistent, predictable names and values for the tags in your subscription.

<<<<<<< HEAD
## EXAMPLES

### Example 1: Delete a predefined tag
```
PS C:\>Remove-AzTag -Name "Department"
```

This command deletes the predefined tag named Department and all of its resources.
If the tag has been applied to any resources or resource groups, the command fails.

### Example 2: Delete a value from a predefined tag
```
=======
**RemoveByResourceIdParameterSet**: The **Remove-AzTag** cmdlet with a **ResourceId** deletes the entire set of tags on a resource or subscription.

## EXAMPLES

### Example 1: Delete a predefined tag
```powershell
PS C:\>Remove-AzTag -Name "Department"
```

This command deletes the predefined tag named Department and all of its values.
If the tag has been applied to any resources or resource groups, the command fails.

### Example 2: Delete a value from a predefined tag
```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\>Remove-AzTag -Name "Department" -Value "HumanResources" -PassThru
Name:   Department
Count:  14
Values: 

        Name        Count
        =========   =====

        Finance        2
        IT            12
```

This command deletes the HumanResources value from the predefined Department tag.
It does not delete the tag.
If the value has been applied to any resources or resource groups, the command fails.

<<<<<<< HEAD
=======
### Example 3: Deletes the entire set of tags on a subscription

```powershell
PS C:\>Remove-AzTag -ResourceId /subscriptions/{subId}
```

This command deletes the entire set of tags on the subscription with {subId}. It will not return the object deleted if not passing in "-PassThru".

### Example 4: Deletes the entire set of tags on a resource

```powershell
PS C:\>Remove-AzTag -ResourceId /subscriptions/{subId}/resourcegroups/{rg}/providers/Microsoft.Sql/servers/Server1 -PassThru

Id         : {Id}
Name       : {Name}
Type       : {Type}
Properties :
             Name     Value
             =======  =========
             Dept     Finance
             Status   Normal
```

This command deletes the entire set of tags on the resource with {resourceId}. It returns the deleted oject when passing in "-PassThru".

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name
<<<<<<< HEAD
Specifies the name of the tag to be deleted.
=======
Specifies the Name of the predefined tag to remove.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
By default, **Remove-AzTag** removes the specified tag and all of its values.
To delete selected values, but not delete the tag, use the *Value* parameter.

```yaml
Type: System.String
<<<<<<< HEAD
Parameter Sets: (All)
=======
Parameter Sets: RemovePredefinedTagParameterSet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

<<<<<<< HEAD
### -PassThru
Returns an object that represents the deleted tag or the resulting tag with deleted valued.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
=======
### -Value
Deletes the specified values from the predefined tag, but does not delete the tag.

```yaml
Type: System.String[]
Parameter Sets: RemovePredefinedTagParameterSet
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource identifier for the tagged entity. A resource, a resource group or a subscription may be tagged.

```yaml
Type: System.String
Parameter Sets: RemoveByResourceIdParameterSet
Aliases:

Required: True
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

<<<<<<< HEAD
### -Value
Deletes the specified values from the predefined tag, but does not delete the tag.

```yaml
Type: System.String[]
=======
### -PassThru
Returns an object that represents the deleted tag or the resulting tag with deleted valued.

```yaml
Type: System.Management.Automation.SwitchParameter
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: False
<<<<<<< HEAD
Position: 1
=======
Position: Named
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### System.String

### System.String[]

### System.Management.Automation.SwitchParameter

## OUTPUTS

<<<<<<< HEAD
### Microsoft.Azure.Commands.ResourceManager.Common.Tags.PSTag
=======
### Microsoft.Azure.Commands.ResourceManager.Common.Tags.PSTag | Microsoft.Azure.Commands.Tags.Model.PSTagResource
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## NOTES

## RELATED LINKS

[Get-AzTag](./Get-AzTag.md)

[New-AzTag](./New-AzTag.md)

<<<<<<< HEAD

=======
[Update-AzTag](./Update-AzTag.md)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
