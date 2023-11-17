---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadapplication
schema: 2.0.0
---

# Get-AzADApplication

## SYNOPSIS
Lists entities from applications or get entity from applications by key

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzADApplication [-Count] [-Filter <String>] [-Orderby <String[]>] [-Search <String>] [-Select <String[]>]
 [-ConsistencyLevel <String>] [-AppendSelected] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [-CountVariable <String>] [<CommonParameters>]
```

### ApplicationIdentifierUriParameterSet
```
Get-AzADApplication -IdentifierUri <String> [-Select <String[]>] [-AppendSelected] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ApplicationIdParameterSet
```
Get-AzADApplication -ApplicationId <Guid> [-Select <String[]>] [-AppendSelected] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ApplicationObjectIdParameterSet
```
Get-AzADApplication -ObjectId <String> [-Select <String[]>] [-AppendSelected] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzADApplication -DisplayName <String> [-Select <String[]>] [-AppendSelected] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### OwnedApplicationParameterSet
```
Get-AzADApplication -OwnedApplication [-Orderby <String[]>] [-Select <String[]>] [-AppendSelected]
 [-First <UInt64>] [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SearchStringParameterSet
```
Get-AzADApplication -DisplayNameStartWith <String> [-Select <String[]>] [-AppendSelected] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists entities from applications or get entity from applications by key

## EXAMPLES

### Example 1: Get application by display name
```powershell
Get-AzADApplication -DisplayName $appname
```

Get application by display name

### Example 2: List applications
```powershell
Get-AzADApplication -First 10
```

List first 10 applications

### Example 3: Search for application display name starts with
```powershell
Get-AzADApplication -DisplayNameStartsWith $prefix
```

Search for application display name starts with

### Example 4: Get application by object Id
```powershell
Get-AzADApplication -ObjectId $id -Select Tags -AppendSelected
```

Get application by object Id and append property 'Tags' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'IdentifierUris', 'Web', 'AppId', 'SignInAudience'

### Example 5: Get applications owned by current user
```powershell
Get-AzADApplication -OwnedApplication
```

Get applications owned by current user

### Example 6: Get applications with filter
```powershell
Get-AzADApplication -Filter "startsWith(DisplayName,'some-name')"
```

Get applications with filter

### Example 7: Assign OdataCount to a variable
```powershell
Get-AzADApplication -First 10 -ConsistencyLevel eventual -Count -CountVariable 'result'
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

### -ApplicationId
application id

```yaml
Type: System.Guid
Parameter Sets: ApplicationIdParameterSet
Aliases: AppId

Required: True
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
Parameter Sets: EmptyParameterSet
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
application display name

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

### -DisplayNameStartWith
application display name starts with

```yaml
Type: System.String
Parameter Sets: SearchStringParameterSet
Aliases: DisplayNameStartsWith

Required: True
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentifierUri
application identifier uri

```yaml
Type: System.String
Parameter Sets: ApplicationIdentifierUriParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
key: id of application

```yaml
Type: System.String
Parameter Sets: ApplicationObjectIdParameterSet
Aliases: Id

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
Parameter Sets: EmptyParameterSet, OwnedApplicationParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnedApplication
get owned application

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: OwnedApplicationParameterSet
Aliases:

Required: True
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication

## NOTES

ALIASES

## RELATED LINKS

