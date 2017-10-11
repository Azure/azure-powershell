---
external help file: Microsoft.Azure.Commands.Cdn.dll-Help.xml
ms.assetid: 93D5E2D9-FB89-4311-8E8E-44CBFAFC98A9
online version: 
schema: 2.0.0
---

# Get-AzureRmCdnProfileSsoUrl

## SYNOPSIS
Gets the single sign-on URL of a CDN profile.

## SYNTAX

### Parameter Set for fields parameters (Default)
```
Get-AzureRmCdnProfileSsoUrl -ProfileName <String> -ResourceGroupName <String> [<CommonParameters>]
```

### Parameter Set for object parameters
```
Get-AzureRmCdnProfileSsoUrl -CdnProfile <PSProfile> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmCdnProfileSsoUrl** cmdlet gets the single sign-on URL of the Azure Content Delivery Network (CDN) profile.
This URL lets users conntect to a supplementary portal and use additional features of  CDN.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -CdnProfile
Specifies the CDN profile.

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

### -ProfileName
Specifies the name of the CDN profile.

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
Specifies the name of the resource group name to which the profile belongs.

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

### PSProfile

Parameter 'CdnProfile' accepts value of type 'PSProfile' from the pipeline

## OUTPUTS

###  
This cmdlet returns a URL.

## NOTES

## RELATED LINKS

[Get-AzureRMCdnProfile](./Get-AzureRMCdnProfile.md)


