---
external help file: Microsoft.Azure.Commands.Cdn.dll-Help.xml
ms.assetid: F93D9D7C-AC2A-4D83-87EC-4A54CD45272B
online version: 
schema: 2.0.0
---

# Get-AzureRmCdnEndpoint

## SYNOPSIS
Gets a CDN endpoint.

## SYNTAX

### Parameter Set for fields parameters (Default)
```
Get-AzureRmCdnEndpoint [-EndpointName <String>] -ProfileName <String> -ResourceGroupName <String>
 [<CommonParameters>]
```

### Parameter Set for object parameters
```
Get-AzureRmCdnEndpoint [-EndpointName <String>] -CdnProfile <PSProfile> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRMCdnEndpoint** cmdlet gets an Azure Content Delivery Network (CDN) endpoint and its associated configuration data.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -CdnProfile
Specifies the CDN profile object to which the endpoint belongs.

```yaml
Type: PSProfile
Parameter Sets: Parameter Set for object parameters
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EndpointName
Specifies the name of the endpoint.
The name of the endpoint is not the host name of the endpoint.

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

### -ProfileName
Specifies the name of the profile to which the endpoint belongs.

```yaml
Type: String
Parameter Sets: Parameter Set for fields parameters
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group to which the endpoint belongs.

```yaml
Type: String
Parameter Sets: Parameter Set for fields parameters
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

###  
This cmdlet returns an endpoint object.

## NOTES

## RELATED LINKS

[New-AzureRmCdnEndpoint](./New-AzureRmCdnEndpoint.md)

[Remove-AzureRmCdnEndpoint](./Remove-AzureRmCdnEndpoint.md)

[Set-AzureRmCdnEndpoint](./Set-AzureRmCdnEndpoint.md)

[Start-AzureRmCdnEndpoint](./Start-AzureRmCdnEndpoint.md)

[Stop-AzureRmCdnEndpoint](./Stop-AzureRmCdnEndpoint.md)


