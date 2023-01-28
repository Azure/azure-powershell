---
external help file:
Module Name: Az.ElasticSan
online version: https://docs.microsoft.com/powershell/module/az.elasticsan/get-azelasticsanskulist
schema: 2.0.0
---

# Get-AzElasticSanSkuList

## SYNOPSIS
List all the available Skus in the region and information related to them

## SYNTAX

```
Get-AzElasticSanSkuList [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List all the available Skus in the region and information related to them

## EXAMPLES

### Example 1: Get all the available Skus 
```powershell
Get-AzElasticSanSkuList
```

```output
Location      Name           ResourceType Tier   
--------      ----           ------------ ----   
{eastus}      Premium_LRS    elasticSans  Premium
{eastus2}     Premium_LRS    elasticSans  Premium
```

This command gets all the available Skus.

## PARAMETERS

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
Specify $filter='location eq \<location\>' to filter on location.

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
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ISkuInformation

## NOTES

ALIASES

## RELATED LINKS

