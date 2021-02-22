---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Tags.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 726E01DD-D73C-4D4B-8FC0-52767927367C
online version: https://docs.microsoft.com/powershell/module/az.resources/get-aztag
schema: 2.0.0
---

# Get-AzTag

## SYNOPSIS
Gets predefined Azure tags | Gets the entire set of tags on a resource or subscription.

## SYNTAX

### GetPredefinedTagParameterSet
```
Get-AzTag [[-Name] <String>] [-Detailed] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzTag -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

**GetPredefinedTagSet**: The **Get-AzTag** cmdlet gets predefined Azure tags in your subscription.
This cmdlet returns basic information about the tags or detailed information about tags and their values.
All output objects include a Count property that represents the number of resources and resource groups to which the tags and values have been applied.
The Azure Tags module that **Get-AzTag** is a part of can help you manage predefined Azure tags.
An Azure tag is a name-value pair that you can use to categorize your Azure resources and resource groups, such as by department or cost center, or to track notes or comments about the resources and groups.
You can define and apply tags in a single step, but predefined tags let you establish standard, consistent, predictable names and values for the tags in your subscription.
To create a predefined tag, use the New-AzTag cmdlet.
To apply a predefined tag to a resource group, use the *Tag* parameter of the New-AzTag cmdlet.
To search resource groups for a specific tag name or name and value, use the *Tag* parameter of the Get-AzResourceGroup cmdlet.

**GetByResourceIdParameterSet**: The **Get-AzTag** cmdlet with a **ResourceId** gets the entire set of tags on a resource or subscription.

## EXAMPLES

### Example 1: Get all predefined tags
```powershell
PS C:\>Get-AzTag

Name      Count
========  =====

Department    5
FY2015        2
CostCenter   20
```

This command gets all predefined tags in the subscription.
The Count property shows how many times the tag has been applied to resources and resource groups in the subscription.

### Example 2: Get a tag by name
```powershell
PS C:\>Get-AzTag -Name "Department"

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
```powershell
PS C:\>Get-AzTag -Detailed

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

### Example 4: Get the entire set of tags on a subscription

```powershell
PS C:\>Get-AzTag -ResourceId /subscriptions/{subId}

Id         : {Id}
Name       : {Name}
Type       : {Type}
Properties :
             Name     Value
             =======  =========
             tagKey1  tagValue1
             tagKey2  tagValue2
```

This command gets the entire set of tags on the subscription with {subId}.

### Example 5: Get the entire set of tags on a resource

```powershell
PS C:\>Get-AzTag -ResourceId /subscriptions/{subId}/resourcegroups/{rg}/providers/Microsoft.Sql/servers/Server1

Id         : {Id}
Name       : {Name}
Type       : {Type}
Properties :
             Name     Value
             =======  =========
             Dept     Finance
             Status   Normal
```

This command gets the entire set of tags on the resource with {resourceId}.

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

### -Detailed
Indicates that this operation adds information about tag values to the output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetPredefinedTagParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of the predefined tag.
By default, **Get-AzTag** gets basic information about all predefined tags in the subscription.
When you specify the *Name* parameter, the *Detailed* parameter has no effect.

```yaml
Type: System.String
Parameter Sets: GetPredefinedTagParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource identifier for the tagged entity. A resource, a resource group or a subscription may be tagged.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Common.Tags.PSTag | Microsoft.Azure.Commands.Tags.Model.PSTagResource

## NOTES

## RELATED LINKS

[New-AzTag](./New-AzTag.md)

[Remove-AzTag](./Remove-AzTag.md)

[Update-AzTag](./Update-AzTag.md)
