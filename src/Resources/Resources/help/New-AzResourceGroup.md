---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
ms.assetid: 0632DAD6-F331-454F-9E7E-2164AB413E77
online version: https://docs.microsoft.com/powershell/module/az.resources/new-azresourcegroup
schema: 2.0.0
---

# New-AzResourceGroup

## SYNOPSIS
Creates an Azure resource group.

## SYNTAX

```
New-AzResourceGroup [-Name] <String> [-Location] <String> [-Tag <Hashtable>] [-Force] [-ApiVersion <String>]
 [-Pre] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzResourceGroup** cmdlet creates an Azure resource group.
You can create a resource group by using just a name and location, and then use the
New-AzResource cmdlet to create resources to add to the resource group.
To add a deployment to an existing resource group, use the New-AzResourceGroupDeployment
cmdlet. To add a resource to an existing resource group, use the **New-AzResource** cmdlet. An
Azure resource is a user-managed Azure entity, such as a database server, database, or website. An
Azure resource group is a collection of Azure resources that are deployed as a unit.

## EXAMPLES

### Example 1: Create an empty resource group
```
PS> New-AzResourceGroup -Name RG01 -Location "South Central US"
```

This command creates a resource group that has no resources. You can use the
**New-AzResource** or **New-AzResourceGroupDeployment** cmdlets to add resources and
deployments to this resource group.

### Example 2: Create an empty resource group using positional parameters
```
PS> New-AzResourceGroup RG01 "South Central US"
```

This command creates a resource group that has no resources.

### Example 3: Create a resource group with tags
```
PS> New-AzResourceGroup -Name RG01 -Location "South Central US" -Tag @{Empty=$null; Department="Marketing"}
```

This command creates an empty resource group. This command is the same as the command in Example 1,
except that it assigns tags to the resource group. The first tag, named Empty, can be used to
identify resource groups that have no resources. The second tag is named Department and has a value
of Marketing. You can use a tag such as this one to categorize resource groups for administration
or budgeting.

## PARAMETERS

### -ApiVersion
Specifies the API version that is supported by the resource Provider.
You can specify a different version than the default version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies the location of the resource group. Specify an Azure data center location, such as West
US or Southeast Asia. You can place a resource group in any location. The resource group does not
have to be in the same location your Azure subscription or in the same location as its resources.
To determine which location supports each resource type, use the Get-AzResourceProvider cmdlet
with the *ProviderNamespace* parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies a name for the resource group. The resource name must be unique in the subscription. If a
resource group that has that name already exists, the command prompts you for confirmation before
replacing the existing resource group.

```yaml
Type: System.String
Parameter Sets: (All)
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
Type: System.Management.Automation.SwitchParameter
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
To add or change a tag, you must replace the collection of tags for the resource group.
After you assign tags to resources and groups, you can use the *Tag* parameter of
Get-AzResource and Get-AzResourceGroup to search for resources and groups by tag name or
by name and value. You can use tags to categorize your resources, such as by department or cost
center, or to track notes or comments about the resources.
To get your predefined tags, use the Get-AzTag cmdlet.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroup

## NOTES

## RELATED LINKS

[Get-AzResourceProvider](./Get-AzResourceProvider.md)

[Get-AzResourceGroup](./Get-AzResourceGroup.md)

[New-AzResource](./New-AzResource.md)

[New-AzResourceGroupDeployment](./New-AzResourceGroupDeployment.md)

[Remove-AzResourceGroup](./Remove-AzResourceGroup.md)

[Set-AzResourceGroup](./Set-AzResourceGroup.md)
