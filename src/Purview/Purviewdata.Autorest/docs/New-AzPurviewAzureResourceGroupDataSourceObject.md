---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewAzureResourceGroupDataSourceObject
schema: 2.0.0
---

# New-AzPurviewAzureResourceGroupDataSourceObject

## SYNOPSIS
Create an in-memory object for AzureResourceGroupDataSource.

## SYNTAX

```
New-AzPurviewAzureResourceGroupDataSourceObject -Kind <DataSourceType> [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-ResourceGroup <String>] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureResourceGroupDataSource.

## EXAMPLES

### Example 1: Create Azure resource group data source object
```powershell
New-AzPurviewAzureResourceGroupDataSourceObject -Kind 'AzureResourceGroup' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ResourceGroup 'rg' -SubscriptionId '6810b9ce-82d3-4562-9658-xxxxxxxxxx'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzureResourceGroup
LastModifiedAt           :
Name                     :
ResourceGroup            : rg
Scan                     :
SubscriptionId           : 6810b9ce-82d3-4562-9658-xxxxxxxxxx
```

Create Azure resource group data source object

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

### -Kind


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.DataSourceType
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AzureResourceGroupDataSource

## NOTES

## RELATED LINKS

