---
external help file: https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/get-azurermpolicyaliases
Module Name: AzureRm.Resources
online version:
schema: 2.0.0
---

# Get-AzureRmPolicyAliases

## SYNOPSIS
Get-AzureRmPolicyAliases retrieves and outputs Azure provider resource types that have aliases defined and match the
given parameter values. If no parameters are provided, all provider resource types that contain an alias will be output.
The -ListAvailable switch modifies this behavior by listing all matching resource types including those without aliases.

## SYNTAX

```
Get-AzureRmPolicyAliases [-NamespaceMatch <String>] [-ResourceTypeMatch <String>] [-AliasMatch <String>]
 [-PathMatch <String>] [-ApiVersionMatch <String>] [-LocationMatch <String>] [-ListAvailable]
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPolicyAliases** cmdlet gets a listing of policy aliases.
Policy aliases are used by Azure Policy to refer to resource type properties.
Parameters are provided that limit items in the listing by matching various properties of the resource type or its aliases.
A given match value matches if the target string contains it using case insensitive comparison.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmPolicyAliases
```

Lists all provider resource types that have an alias.

### Example 2
```powershell
PS C:\> Get-AzureRmPolicyAliases -ListAvailable
```

Lists all provider resource types, including those without aliases.

### Example 3
```powershell
PS C:\> Get-AzureRmPolicyAliases -NamespaceMatch 'compute'
```

Lists all provider resource types whose namespace matches 'compute' and contain an alias.

### Example 4
```powershell
PS C:\> Get-AzureRmPolicyAliases -ResourceTypeMatch 'virtual'
```

Lists all provider resource types whose resource type matches 'virtual' and contain an alias.

### Example 5
```powershell
PS C:\> Get-AzureRmPolicyAliases -ResourceTypeMatch 'virtual' -ListAvailable
```

Lists all provider resource types whose resource type matches 'virtual', including those without aliases.

### Example 6
```powershell
PS C:\> Get-AzureRmPolicyAliases -NamespaceMatch 'compute' -ResourceTypeMatch 'virtual'
```

Lists all provider resource types whose namespace matches 'compute' and resource type matches 'virtual' and contain an alias.
Note: -NamespaceMatch and -ResourceTypeMatch provide exclusive matches, whereas the others are inclusive.

### Example 7
```powershell
PS C:\> Get-AzureRmPolicyAliases -AliasMatch 'virtual'
```

Lists all provider resource types that contain an alias matching 'virtual'.

### Example 8
```powershell
PS C:\> Get-AzureRmPolicyAliases -AliasMatch 'virtual' -PathMatch 'network'
```

Lists all provider resource types that contain an alias matching 'virtual' or an alias with a path matching 'network'.

### Example 9
```powershell
PS C:\> Get-AzureRmPolicyAliases -ApiVersionMatch 'alpha'
```

Lists all provider resource types with alpha api version or containing an alias with an alpha api version.

## PARAMETERS

### -AliasMatch
Includes in the output items with aliases whose name matches this value.```yaml
Type: String
Parameter Sets: (All)
Aliases: Alias

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiVersion
When set, indicates the version of the resource provider API to use. If not specified, the API version is automatically determined as the latest available.```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiVersionMatch
Includes in the output items whose resource types or aliases have a matching api version.```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListAvailable
Includes in the output matching items with and without aliases.```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: ShowAll

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationMatch
Includes in the output items whose resource types have a matching location.```yaml
Type: String
Parameter Sets: (All)
Aliases: Location

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceMatch
Limits the output to items whose namespace matches this value.```yaml
Type: String
Parameter Sets: (All)
Aliases: Name, Namespace

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PathMatch
Includes in the output items with aliases containing a path that matches this value.```yaml
Type: String
Parameter Sets: (All)
Aliases: Path

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceTypeMatch
Limits the output to items whose resource type matches this value.```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceType, Resource

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.PsResourceProviderAlias

## NOTES

## RELATED LINKS
