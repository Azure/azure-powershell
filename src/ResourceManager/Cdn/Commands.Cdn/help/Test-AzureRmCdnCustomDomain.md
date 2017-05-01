---
external help file: Microsoft.Azure.Commands.Cdn.dll-Help.xml
ms.assetid: 8C4E824F-FB4A-4DE7-8FD9-3FDA3848F25C
online version: 
schema: 2.0.0
---

# Test-AzureRmCdnCustomDomain

## SYNOPSIS
Checks whether a custom domain can be added to an endpoint.

## SYNTAX

### Parameter Set for fields parameters (Default)
```
Test-AzureRmCdnCustomDomain -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 -CustomDomainHostName <String> [<CommonParameters>]
```

### Parameter Set for object parameters
```
Test-AzureRmCdnCustomDomain -CdnEndpoint <PSEndpoint> -CustomDomainHostName <String> [<CommonParameters>]
```

## DESCRIPTION
The **Test-AzureRmCdnCustomDomain** cmdlet checks whether a custom domain can be added to an endpoint by validating the CName mapping.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -CdnEndpoint
Specifies the endpoint to which you want to add the custom domain.

```yaml
Type: PSEndpoint
Parameter Sets: Parameter Set for object parameters
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CustomDomainHostName
Specifies the host name of the custom domain.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointName
Specifies the name of the endpoint to which you want to add the custom domain.

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

### -ProfileName
Specifies the name of the profile.

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
Specifies the name of the resource group.

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

## NOTES

## RELATED LINKS

[Get-AzureRmCdnCustomDomain](./Get-AzureRmCdnCustomDomain.md)

[New-AzureRmCdnCustomDomain](./New-AzureRmCdnCustomDomain.md)

[Remove-AzureRmCdnCustomDomain](./Remove-AzureRmCdnCustomDomain.md)


