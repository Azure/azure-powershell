---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewadlsgen1datasourceobject
schema: 2.0.0
---

# New-AzPurviewAdlsGen1DataSourceObject

## SYNOPSIS
Create an in-memory object for AdlsGen1DataSource.

## SYNTAX

```
New-AzPurviewAdlsGen1DataSourceObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-Endpoint <String>] [-Location <String>] [-ResourceGroup <String>] [-ResourceName <String>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AdlsGen1DataSource.

## EXAMPLES

### Example 1: Create AdlsGen1 data source object
```powershell
New-AzPurviewAdlsGen1DataSourceObject -CollectionReferenceName parv-brs-2 -CollectionType 'CollectionReference' -Endpoint 'adl://adlsgen1datascan02ause.azuredatalakestore.net'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Endpoint                 : adl://adlsgen1datascan02ause.azuredatalakestore.net
Id                       :
Kind                     : AdlsGen1
LastModifiedAt           :
Location                 :
Name                     :
ResourceGroup            :
ResourceName             :
Scan                     :
SubscriptionId           :
```

Create AdlsGen1 data source object

## PARAMETERS

### -CollectionReferenceName


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

### -CollectionType


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

### -Endpoint


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

### -Location


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

### -ResourceGroup


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

### -ResourceName


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

### -SubscriptionId


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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AdlsGen1DataSource

## NOTES

## RELATED LINKS

