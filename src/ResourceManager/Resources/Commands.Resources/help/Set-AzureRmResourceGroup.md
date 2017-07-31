---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
ms.assetid: 4E5C059B-36F3-41C8-9FDB-69F5318CF39B
online version:
schema: 2.0.0
---

# Set-AzureRmResourceGroup

## SYNOPSIS
Modifies a resource group.

## SYNTAX

### Lists the resource group based in the name. (Default)
```
Set-AzureRmResourceGroup [-Name] <String> [-Tag] <Hashtable> [-ApiVersion <String>] [-Pre] [<CommonParameters>]
```

### Lists the resource group based in the Id.
```
Set-AzureRmResourceGroup [-Tag] <Hashtable> [-Id] <String> [-ApiVersion <String>] [-Pre] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmResourceGroup** cmdlet modifies the properties of a resource group.
You can use this cmdlet to add, change, or delete the Azure tags applied to a resource group.
Specify the *Name* parameter to identify the resource group and the *Tag* parameter to modify the tags.

You cannot use this cmdlet to change the name of a resource group.

## EXAMPLES

### Example 1: Apply a tag to a resource group
```
PS C:\>Set-AzureRmResourceGroup -Name "ContosoRG" -Tag @{Department="IT"}
```

This command applies a Department tag with a value of IT to a resource group that has no existing tags.

### Example 2: Add tags to a resource group
```
PS C:\>$Tags = (Get-AzureRmResourceGroup -Name "ContosoRG").Tags
PS C:\> $Tags
PS C:\> $Tags += @{"Status"="Approved"; "FY2016"=$null}
PS C:\> Set-AzureRmResourceGroup -Name "ContosoRG" -Tag $Tags
PS C:> (Get-AzureRmResourceGroup -Name "ContosoRG").Tags
```

This example adds a Status tag with a value of Approved and an FY2016 tag to a resource group that
has existing tags. Because the tags you specify replace the existing tags, you must include the
existing tags in the new tag collection or you will lose them.

The first command gets the ContosoRG resource group and uses the dot method to get the value of its
Tags property. The command stores the tags in the $Tags variable.

The second command gets the tags in the $Tags variable.

The third command uses the += assignment operator to add the Status and FY2016 tags to the array of
tags in the $Tags variable.

The fourth command uses the *Tag* parameter of **Set-AzureRmResourceGroup** to apply the tags in
the $Tags variable to the ContosoRG resource group.

The fifth command gets all of the tags applied to the ContosoRG resource group. The output shows
that the resource group has the Department tag and the two new tags, Status and FY2015.

### Example 3: Delete all tags for a resource group
```
PS C:\>Set-AzureRmResourceGroup -Name "ContosoRG" -Tag @{}
```

This command specifies the *Tag* parameter with an empty hash table value to delete all tags from
the ContosoRG resource group.

## PARAMETERS

### -ApiVersion
Specifies the API version that is supported by the resource Provider.
You can specify a different version than the default version.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the ID of the resource group to modify.

```yaml
Type: String
Parameter Sets: Lists the resource group based in the Id.
Aliases: ResourceGroupId, ResourceId

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the resource group to modify.

```yaml
Type: String
Parameter Sets: Lists the resource group based in the name.
Aliases: ResourceGroupName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
Indicates that this cmdlet considers pre-release API versions when it automatically determines which version to use.

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

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

A tag is a name-value pair that you can create and apply to resources and resource groups. After
you assign tags to resources and groups, you can use the *Tag* parameter of Get-AzureRmResource and
Get-AzureRmResourceGroup to search for resources and groups by tag name or name and value. You can
use tags to categorize your resources, such as by department or cost center, or to track notes or
comments about the resources.

To add or change a tag, you must replace the collection of tags for the resource group. To delete a
tag, enter a hash table with all tags currently applied to the resource group, from
**Get-AzureRmResourceGroup**, except for the tag you want to delete. To delete all tags from a
resource group, specify an empty hash table: `@{}`.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

Microsoft.Azure.Commands.Resources.Models.PSResourceGroup

## NOTES

## RELATED LINKS

[Get-AzureRmResource](./Get-AzureRmResource.md)

[Get-AzureRmResourceGroup](./Get-AzureRmResourceGroup.md)

[New-AzureRmResourceGroup](./New-AzureRmResourceGroup.md)

[Remove-AzureRmResourceGroup](./Remove-AzureRmResourceGroup.md)
