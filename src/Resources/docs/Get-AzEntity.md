---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azentity
schema: 2.0.0
---

# Get-AzEntity

## SYNOPSIS
List all entities (Management Groups, Subscriptions, etc.) for the authenticated user.

## SYNTAX

```
Get-AzEntity [-Filter <String>] [-GroupName <String>] [-Search <String>] [-Select <String>] [-Skip <Int32>]
 [-Skiptoken <String>] [-Top <Int32>] [-View <String>] [-CacheControl <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List all entities (Management Groups, Subscriptions, etc.) for the authenticated user.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -CacheControl
Indicates that the request shouldn't utilize any caches.

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter parameter allows you to filter on the name or display name fields.
You can check for equality on the name field (e.g.
name eq '{entityName}') and you can check for substrings on either the name or display name fields(e.g.
contains(name, '{substringToSearch}'), contains(displayName, '{substringToSearch')).
Note that the '{entityName}' and '{substringToSearch}' fields are checked case insensitively.

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

### -GroupName
A filter which allows the get entities call to focus on a particular group (i.e.
"$filter=name eq 'groupName'")

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

### -Search
The $search parameter is used in conjunction with the $filter parameter to return three different outputs depending on the parameter passed in.
With $search=AllowedParents the API will return the entity info of all groups that the requested entity will be able to reparent to as determined by the user's permissions.
With $search=AllowedChildren the API will return the entity info of all entities that can be added as children of the requested entity.
With $search=ParentAndFirstLevelChildren the API will return the parent and first level of children that the user has either direct access to or indirect access via one of their descendants.

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

### -Select
This parameter specifies the fields to include in the response.
Can include any combination of Name,DisplayName,Type,ParentDisplayNameChain,ParentChain, e.g.
'$select=Name,DisplayName,Type,ParentDisplayNameChain,ParentNameChain'.
When specified the $select parameter can override select in $skipToken.

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

### -Skiptoken
Page continuation token is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a token parameter that specifies a starting point to use for subsequent calls.

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

### -Top
Number of elements to return when retrieving results.
Passing this in will override $skipToken.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -View
The view parameter allows clients to filter the type of data that is returned by the getEntities call.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Number of entities to skip over when retrieving results.
Passing this in will override $skipToken.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180301Preview.IEntityInfo
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azentity](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azentity)

