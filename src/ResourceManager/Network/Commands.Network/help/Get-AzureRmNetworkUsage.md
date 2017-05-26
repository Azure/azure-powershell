---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmNetworkUsage

## SYNOPSIS
Lists network usages for a subscription

## SYNTAX

```
Get-AzureRmNetworkUsage -Location <String> [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmNetworkUsage cmdlet gets limits and current usage for Network resources.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmNetworkUsage -Location westcentralus
```

Gets resources usage data in westcentralus region

## PARAMETERS

### -Location
The location where resource usage is queried.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSUsage

## NOTES

## RELATED LINKS

