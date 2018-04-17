---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# Get-AzsBlobServiceMetricDefinition

## SYNOPSIS
Returns the list of metric definitions for blob service.

## SYNTAX

```
Get-AzsBlobServiceMetricDefinition [-FarmName] <String> [-ResourceGroupName <String>] [-Skip <Int32>]
 [-Top <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Returns the list of metric definitions for blob service.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsBlobServiceMetricDefinition -ResourceGroupName "system.local" -FarmName f9b8e2e2-e4b4-44e0-9d92-6a848b1a5376
```

PrimaryAggregationType                                       Unit
----------------------                                       ----
Average                                                      Count
Average                                                      Count
Average                                                      Count
Total                                                        Count
Total                                                        Count
Total                                                        Count
Total                                                        Count
Average                                                      CountPerSecond
Average                                                      Count
Average                                                      Count
Average                                                      Count
Average                                                      Count
Average                                                      Count
Average                                                      CountPerSecond
Average                                                      Count

Get a list of metric definitions for the blob service.

## PARAMETERS

### -FarmName
Farm Id.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Storage.Admin.Models.MetricDefinition

## NOTES

## RELATED LINKS

