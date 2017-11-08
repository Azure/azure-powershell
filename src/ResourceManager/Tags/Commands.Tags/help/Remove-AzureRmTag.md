---
external help file: Microsoft.Azure.Commands.Tags.dll-Help.xml
Module Name: AzureRM
ms.assetid: 66B25541-0FA5-46CF-90D8-FE9527BE11C6
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.tags/remove-azurermtag
schema: 2.0.0
---

# Remove-AzureRmTag

## SYNOPSIS
Deletes predefined Azure tags or values.

## SYNTAX

```
Remove-AzureRmTag [-Name] <String> [[-Value] <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmTag** cmdlet deletes predefined Azure tags and values from your subscription.
To delete particular values from a predefined tag, use the *Value* parameter.
By default, **Remove-AzureRmTag** deletes the specified tag and all of its values.You cannot delete a tag or value that is currently applied to a resource or resource group.

Before using **Remove-AzureRmTag**, use the *Tag* parameter of the Set-AzureRMResourceGroup cmdlet to delete the tag or values from the resource or resource group.

The Azure Tags module that **Remove-AzureRmTag** is part of can help you manage your predefined Azure tags.
An Azure tag is a name-value pair that you can use to categorize your Azure resources and resource groups, such as by department or cost center, or to track notes or comments about the resources and groups.

You can define and apply tags in a single step, but predefined tags let you establish standard, consistent, predictable names and values for the tags in your subscription.
If the subscription includes any predefined tags, you cannot apply undefined tags or values to any resource or resource group in the subscription.

## EXAMPLES

### Example 1: Delete a predefined tag
```
PS C:\>Remove-AzureRmTag -Name "Department"
```

This command deletes the predefined tag named Department and all of its resources.
If the tag has been applied to any resources or resource groups, the command fails.

### Example 2: Delete a value from a predefined tag
```
PS C:\>Remove-AzureRmTag -Name "Department" -Value "HumanResources" -PassThru
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

### -Name
Specifies the name of the tag to be deleted.
By default, **Remove-AzureRmTag** removes the specified tag and all of its values.
To delete selected values, but not delete the tag, use the *Value* parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object that represents the deleted tag or the resulting tag with deleted valued.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Value
Deletes the specified values from the predefined tag, but does not delete the tag.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None or Microsoft.Azure.Commands.Tags.Model.PSTag

## NOTES

## RELATED LINKS

[Get-AzureRmTag](./Get-AzureRmTag.md)

[New-AzureRmTag](./New-AzureRmTag.md)


