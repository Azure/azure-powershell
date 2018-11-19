---
external help file: Microsoft.Azure.Commands.Tags.dll-Help.xml
Module Name: AzureRM.Tags
ms.assetid: 726E01DD-D73C-4D4B-8FC0-52767927367C
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.tags/get-azurermtag
schema: 2.0.0
---

# Get-AzureRmTag

## SYNOPSIS
Gets predefined Azure tags.

## SYNTAX

```
Get-AzureRmTag [[-Name] <String>] [-Detailed] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmTag** cmdlet gets predefined Azure tags in your subscription.
This cmdlet returns basic information about the tags or detailed information about tags and their values.
All output objects include a Count property that represents the number of resources and resource groups to which the tags and values have been applied.
The Azure Tags module that **Get-AzureRMTag** is a part of can help you manage predefined Azure tags.
An Azure tag is a name-value pair that you can use to categorize your Azure resources and resource groups, such as by department or cost center, or to track notes or comments about the resources and groups.
You can define and apply tags in a single step, but predefined tags let you establish standard, consistent, predictable names and values for the tags in your subscription.
To create a predefined tag, use the New-AzureRmTag cmdlet.
To apply a predefined tag to a resource group, use the *Tag* parameter of the New-AzureRmTag cmdlet.
To search resource groups for a specific tag name or name and value, use the *Tag* parameter of the Get-AzureRMResourceGroup cmdlet.

## EXAMPLES

### Example 1: Get all predefined tags
```
PS C:\>Get-AzureRmTag

Name      Count
========  =====

Department    5
FY2015        2
CostCenter   20
```

This command gets all predefined tags in the subscription.
The Count property shows how many times the tag has been applied to resources and resource groups in the subscription.

### Example 2: Get a tag by name
```
PS C:\>Get-AzureRmTag -Name "Department"

Name:   Department
Count:  5
Values: 

        Name        Count
        ==========  =====

        Finance       2
        IT            3
```

This command gets detailed information about the Department tag and its values.
The Count property shows how many times the tag and each of its values has been applied to resources and resource groups in the subscription.

### Example 3: Get values of all tags
```
PS C:\>Get-AzureRmTag -Detailed

Name:   Department
Count:  5
Values: 

        Name        Count
        ==========  =====

        Finance       2
        IT            3


Name:   FY2015
Count:  2


Name:   CostCenter
Count:  20
Values: 

        Name        Count
        ==========  =====

        0001          5
        0002         10
        0003          5
```

This command uses the *Detailed* parameter to get detailed information about all predefined tags in the subscription.
Using the *Detailed* parameter is the equivalent of using the *Name* parameter for every tag.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Detailed
Indicates that this operation adds information about tag values to the output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the tag to get.
By default, **Get-AzureRmTag** gets basic information about all predefined tags in the subscription.
When you specify the *Name* parameter, the *Detailed* parameter has no effect.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Common.Tags.PSTag

## NOTES

## RELATED LINKS

[New-AzureRmTag](./New-AzureRmTag.md)

[Remove-AzureRmTag](./Remove-AzureRmTag.md)


