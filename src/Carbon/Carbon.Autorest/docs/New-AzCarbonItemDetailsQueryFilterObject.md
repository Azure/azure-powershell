---
external help file:
Module Name: Az.Carbon
online version: https://learn.microsoft.com/powershell/module/Az.Carbon/new-azcarbonitemdetailsqueryfilterobject
schema: 2.0.0
---

# New-AzCarbonItemDetailsQueryFilterObject

## SYNOPSIS
Create an in-memory object for ItemDetailsQueryFilter.

## SYNTAX

```
New-AzCarbonItemDetailsQueryFilterObject -CarbonScopeList <String[]> -CategoryType <String>
 -DateRangeEnd <DateTime> -DateRangeStart <DateTime> -OrderBy <String> -PageSize <Int32>
 -SortDirection <String> -SubscriptionList <String[]> [-LocationList <String[]>]
 [-ResourceGroupUrlList <String[]>] [-ResourceTypeList <String[]>] [-SkipToken <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ItemDetailsQueryFilter.

## EXAMPLES

### Example 1: Create new ItemDetailsQueryFilterObject object
```powershell
New-AzCarbonItemDetailsQueryFilterObject -CarbonScopeList ('Scope1', 'Scope2', 'Scope3') -CategoryType 'Resource' -DateRangeEnd 2025-03-01 -DateRangeStart 2025-03-01 -OrderBy 'ItemName' -PageSize 100 -SortDirection 'Desc' -SubscriptionList ('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001')
```

```output
CarbonScopeList      : {Scope1, Scope2, Scope3}
CategoryType         : Resource
DateRangeEnd         : 3/1/2025 12:00:00 AM
DateRangeStart       : 3/1/2025 12:00:00 AM
LocationList         :
OrderBy              : ItemName
PageSize             : 100
ReportType           : ItemDetailsReport
ResourceGroupUrlList :
ResourceTypeList     :
SkipToken            :
SortDirection        : Desc
SubscriptionList     : {00000000-0000-0000-0000-000000000000, 00000000-0000-0000-0000-000000000001}
```



## PARAMETERS

### -CarbonScopeList
List of carbon emission scopes.
Required.
Accepts one or more values from EmissionScopeEnum (e.g., Scope1, Scope2, Scope3) in list form.
The output will include the total emissions for the specified scopes.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CategoryType
Specifies the category type for detailed emissions data, such as Resource, ResourceGroup, ResourceType, Location, or Subscription.
See supported types in CategoryTypeEnum.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DateRangeEnd
End date parameter in yyyy-MM-01 format.
Only the first day of each month is accepted.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DateRangeStart
Start date parameter in yyyy-MM-01 format.
Only the first day of each month is accepted.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationList
List of locations(Azure Region Display Name) for carbon emissions data, with each location specified in lowercase (e.g., 'east us').
Optional.
You can use the command 'az account list-locations -o table' to find Azure Region Display Names.

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

### -OrderBy
The column name to order the results by.
See supported values in OrderByColumnEnum.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageSize
Number of items to return in one request, max value is 5000.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupUrlList
List of resource group URLs for carbon emissions data.
Optional.
Each URL must follow the format '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}', and should be in all lowercase.

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

### -ResourceTypeList
List of resource types for carbon emissions data.
Optional.
Each resource type should be specified in lowercase, following the format 'microsoft.{service}/{resourceType}', e.g., 'microsoft.storage/storageaccounts'.

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

### -SkipToken
Pagination token for fetching the next page of data.
This token is nullable and will be returned in the previous response if additional data pages are available.

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

### -SortDirection
Direction for sorting results.
See supported values in SortDirectionEnum.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionList
List of subscription IDs for which carbon emissions data is requested.
Required.
Each subscription ID should be in lowercase format.
The max length of list is 100.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Carbon.Models.ItemDetailsQueryFilter

## NOTES

## RELATED LINKS
