---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
ms.assetid: EFBBFB60-D972-47B8-997E-B737F0CA007E
online version:
schema: 2.0.0
---

# Find-AzureRmResourceGroup

## SYNOPSIS
Searches for resource groups.

## SYNTAX

```
Find-AzureRmResourceGroup [-Tag <Hashtable>] [-ApiVersion <String>] [-Pre] [<CommonParameters>]
```

## DESCRIPTION
The **Find-AzureRmResourceGroup** cmdlet searches for resource groups using the specified parameters.

## EXAMPLES

### Example 1: Find all resource groups
```
PS C:\>Find-AzureRmResourceGroup
```

This command finds all resource groups.

### Example 2: Find resource groups by tag name
```
PS C:\>Find-AzureRmResourceGroup -Tag @{ "testtag" = $null }
```

This command finds all resource groups that have a tag named testtag.

### Example 3: Find resource groups by tag name and value
```
PS C:\>Find-AzureRmResourceGroup -Tag @{"testtag" = "testval" }
```

This command finds all resource groups that have a tag named testtag and the value testval.

## PARAMETERS

### -ApiVersion
Specifies the version of the resource provider API to use. If you do not specify a version, this
cmdlet uses the latest available version.

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
Specifies tag information, as a hash table, to filter your results. Use the following formats:

@{tagName=$null} or @{tagName = 'tagValue'}.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
