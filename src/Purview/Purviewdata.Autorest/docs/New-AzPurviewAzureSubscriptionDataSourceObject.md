---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewazuresubscriptiondatasourceobject
schema: 2.0.0
---

# New-AzPurviewAzureSubscriptionDataSourceObject

## SYNOPSIS
Create an in-memory object for AzureSubscriptionDataSource.

## SYNTAX

```
New-AzPurviewAzureSubscriptionDataSourceObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSubscriptionDataSource.

## EXAMPLES

### Example 1: Create Azure Subscription data source object
```powershell
New-AzPurviewAzureSubscriptionDataSourceObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -SubscriptionId '6810b9ce-82d3-4562-9658-xxxxxxxxxx'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzureSubscription
LastModifiedAt           :
Name                     :
Scan                     :
SubscriptionId           : 6810b9ce-82d3-4562-9658-xxxxxxxxxx
```

Create Azure Subscription data source object

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AzureSubscriptionDataSource

## NOTES

## RELATED LINKS

