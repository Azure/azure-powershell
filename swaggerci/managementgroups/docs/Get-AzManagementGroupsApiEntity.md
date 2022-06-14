---
external help file:
Module Name: Az.ManagementGroupsApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.managementgroupsapi/get-azmanagementgroupsapientity
schema: 2.0.0
---

# Get-AzManagementGroupsApiEntity

## SYNOPSIS
List all entities (Management Groups, Subscriptions, etc.) for the authenticated user.\n

## SYNTAX

```
Get-AzManagementGroupsApiEntity [-Filter <String>] [-GroupName <String>] [-Search <EntitySearchType>]
 [-Select <String>] [-Skip <Int32>] [-Skiptoken <String>] [-Top <Int32>] [-View <EntityViewParameterType>]
 [-CacheControl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List all entities (Management Groups, Subscriptions, etc.) for the authenticated user.\n

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CacheControl
Indicates whether the request should utilize any caches.
Populate the header with 'no-cache' value to bypass existing caches.

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
The filter parameter allows you to filter on the the name or display name fields.
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
With $search=ParentOnly the API will return only the group if the user has access to at least one of the descendants of the group.
With $search=ChildrenOnly the API will return only the first level of children of the group entity info specified in $filter.
The user must have direct access to the children entities or one of it's descendants for it to show up in the results.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Support.EntitySearchType
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

### -Skip
Number of entities to skip over when retrieving results.
Passing this in will override $skipToken.

```yaml
Type: System.Int32
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -View
The view parameter allows clients to filter the type of data that is returned by the getEntities call.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Support.EntityViewParameterType
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.Api20210401.IEntityInfo

## NOTES

ALIASES

## RELATED LINKS

