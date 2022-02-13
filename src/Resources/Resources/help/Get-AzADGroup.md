---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azadgroup
schema: 2.0.0
---

# Get-AzADGroup

## SYNOPSIS
Lists entities from groups or get entity from groups by key

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzADGroup [-Expand <String[]>] [-Select <String[]>] [-Filter <String>] [-Orderby <String[]>]
 [-Search <String>] [-ConsistencyLevel <String>] [-First <UInt64>] [-Skip <UInt64>] [-AppendSelected]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzADGroup [-Expand <String[]>] [-Select <String[]>] [-ConsistencyLevel <String>] [-First <UInt64>]
 [-Skip <UInt64>] [-AppendSelected] -DisplayName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SearchStringParameterSet
```
Get-AzADGroup [-Expand <String[]>] [-Select <String[]>] [-ConsistencyLevel <String>] [-First <UInt64>]
 [-Skip <UInt64>] [-AppendSelected] -DisplayNameStartsWith <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzADGroup [-Expand <String[]>] [-Select <String[]>] [-ConsistencyLevel <String>] [-AppendSelected]
 -ObjectId <Guid> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists entities from groups or get entity from groups by key

## EXAMPLES

### Example 1: Get group by display name
```powershell
PS C:\> Get-AzADGroup -DisplayName $gname
```

Get group by display name

### Example 2: List groups
```powershell
PS C:\> Get-AzADGroup -First 10
```

List first 10 groups

### Example 3: Get group by object id
```powershell
PS C:\> Get-AzADGroup -ObjectId $id -Select groupTypes -AppendSelected
```

Get group by object id and append property 'groupTypes' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'SecurityEnabled', 'MailEnabled', 'MailNickname', 'Description'

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
Filter items by property values

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
Parameter Sets: EmptyParameterSet, DisplayNameParameterSet, SearchStringParameterSet
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
Parameter Sets: EmptyParameterSet, DisplayNameParameterSet, SearchStringParameterSet
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
