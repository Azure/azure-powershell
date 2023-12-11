---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadgroup
schema: 2.0.0
---

# Get-AzADGroup

## SYNOPSIS
Lists entities from groups or get entity from groups by key

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzADGroup [-Count] [-AppendSelected] [-ConsistencyLevel <String>] [-Expand <String[]>] [-Filter <String>]
 [-First <UInt64>] [-Orderby <String[]>] [-Search <String>] [-Select <String[]>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [-CountVariable <String>] [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzADGroup -DisplayName <String> [-AppendSelected] [-ConsistencyLevel <String>] [-Expand <String[]>]
 [-First <UInt64>] [-Select <String[]>] [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzADGroup -ObjectId <Guid> [-AppendSelected] [-ConsistencyLevel <String>] [-Expand <String[]>]
 [-Select <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SearchStringParameterSet
```
Get-AzADGroup -DisplayNameStartsWith <String> [-AppendSelected] [-ConsistencyLevel <String>]
 [-Expand <String[]>] [-First <UInt64>] [-Select <String[]>] [-Skip <UInt64>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists entities from groups or get entity from groups by key

## EXAMPLES

### Example 1: Get group by display name
```powershell
Get-AzADGroup -DisplayName $gname
```

Get group by display name

### Example 2: List groups
```powershell
Get-AzADGroup -First 10
```

List first 10 groups

### Example 3: Get group by object id
```powershell
Get-AzADGroup -ObjectId $id -Select groupTypes -AppendSelected
```

Get group by object id and append property 'groupTypes' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'SecurityEnabled', 'MailEnabled', 'MailNickname', 'Description'

### Example 4: Get group with filter
```powershell
Get-AzADGroup -Filter "startsWith(DisplayName,'some-name')"
```

Get group with filter

### Example 5: Assign OdataCount to a variable
```powershell
Get-AzADGroup -First 10 -ConsistencyLevel eventual -Count -CountVariable 'result'
$result
```

Assign OdataCount to a variable

## PARAMETERS

### -AppendSelected
Append properties selected with default properties when this switch is on, only works with parameter '-Select'.

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

### -ConsistencyLevel
Indicates the requested consistency level.
Documentation URL: https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/

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

### -Count
Include count of items

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CountVariable
Specifies a count of the total number of items in a collection.
By default, this variable will be set in the global scope.

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet
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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name of the group.

```yaml
Type: System.String
Parameter Sets: DisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNameStartsWith
Used to find groups that begin with the provided string.

```yaml
Type: System.String
Parameter Sets: SearchStringParameterSet
Aliases: SearchString

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expand
Expand related entities

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter items by property values, for more detail about filter query please see: https://learn.microsoft.com/en-us/graph/filter-query-parameter

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
Parameter Sets: DisplayNameParameterSet, EmptyParameterSet, SearchStringParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
key: id of group

```yaml
Type: System.Guid
Parameter Sets: ObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Orderby
Order items by property values

```yaml
Type: System.String[]
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Search
Search items by search phrases

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Select
Select properties to be returned

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: DisplayNameParameterSet, EmptyParameterSet, SearchStringParameterSet
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphGroup

## NOTES

ALIASES

## RELATED LINKS

