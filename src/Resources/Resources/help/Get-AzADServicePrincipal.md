---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadserviceprincipal
schema: 2.0.0
---

# Get-AzADServicePrincipal

## SYNOPSIS
Lists entities from service principals or get entity from service principals by key

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzADServicePrincipal [-Select <String[]>] [-Count] [-Filter <String>] [-Orderby <String[]>]
 [-Search <String>] [-ConsistencyLevel <String>] [-First <UInt64>] [-Skip <UInt64>] [-AppendSelected]
 [-DefaultProfile <PSObject>] [-CountVariable <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzADServicePrincipal -ObjectId <String> [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>]
 [-AppendSelected] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SearchStringParameterSet
```
Get-AzADServicePrincipal [-Select <String[]>] -DisplayNameBeginsWith <String> [-First <UInt64>]
 [-Skip <UInt64>] [-AppendSelected] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzADServicePrincipal [-Select <String[]>] -DisplayName <String> [-First <UInt64>] [-Skip <UInt64>]
 [-AppendSelected] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ApplicationIdParameterSet
```
Get-AzADServicePrincipal [-Select <String[]>] -ApplicationId <Guid> [-First <UInt64>] [-Skip <UInt64>]
 [-AppendSelected] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ApplicationObjectParameterSet
```
Get-AzADServicePrincipal [-Select <String[]>] -ApplicationObject <IMicrosoftGraphApplication> [-First <UInt64>]
 [-Skip <UInt64>] [-AppendSelected] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### SPNParameterSet
```
Get-AzADServicePrincipal [-Select <String[]>] -ServicePrincipalName <String> [-First <UInt64>] [-Skip <UInt64>]
 [-AppendSelected] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Lists entities from service principals or get entity from service principals by key

## EXAMPLES

### Example 1: Get service principal by display name
```powershell
Get-AzADServicePrincipal -DisplayName $name
```

Get service principal by display name

### Example 2: Search for service principal display name starts with
```powershell
Get-AzADServicePrincipal -DisplayNameStartsWith $prefix
```

Search for service principal display name starts with

### Example 3: List service principals
```powershell
Get-AzADServicePrincipal -First 10 -Select Tags -AppendSelected
```

List first 10 service principals and append property 'Tags' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'ServicePrincipalNames', 'AppId'

### Example 4: Get service principal by application Id
```powershell
Get-AzADServicePrincipal -ApplicationId $appId
```

Get service principal by application Id

### Example 5: Get service principal by pipeline input
```powershell
Get-AzADApplication -DisplayName $name | Get-AzADServicePrincipal
```

Get service principal by pipeline input

### Example 6: Get service principal with filter
```powershell
Get-AzADServicePrincipal -Filter "startsWith(DisplayName,'some-name')"
```

Get service principal with filter

### Example 7: Assign OdataCount to a variable
```powershell
Get-AzADServicePrincipal -First 10 -ConsistencyLevel eventual -Count -CountVariable 'result'
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
application id of serviceprincipal

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

### -ApplicationObject
The service principal object, could be used as pipeline input.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication
Parameter Sets: ApplicationObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
serviceprincipal display name

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

### -DisplayNameBeginsWith
serviceprincipal display name starts with

```yaml
Type: System.String
Parameter Sets: SearchStringParameterSet
Aliases: DisplayNameStartsWith, SearchString

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

### -ObjectId
key: id of servicePrincipal

```yaml
Type: System.String
Parameter Sets: ObjectIdParameterSet
Aliases: ServicePrincipalId, Id

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### -ServicePrincipalName
serviceprincipal name

```yaml
Type: System.String
Parameter Sets: SPNParameterSet
Aliases: SPN

Required: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphServicePrincipal

## NOTES

## RELATED LINKS
