---
external help file: Microsoft.Azure.Commands.Cdn.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmCdnEndpointResourceUsage

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### Parameter Set for fields parameters (Default)
```
Get-AzureRmCdnEndpointResourceUsage [-EndpointName <String>] -ProfileName <String> -ResourceGroupName <String>
 [<CommonParameters>]
```

### Parameter Set for object parameters
```
Get-AzureRmCdnEndpointResourceUsage [-EndpointName <String>] -CdnEndpoint <PSEndpoint> [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -CdnEndpoint
The CDN endpoint object.

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

### -EndpointName
Azure CDN endpoint name.

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
Azure CDN profile name.

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
The resource group of the Azure CDN Profile.

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

### Microsoft.Azure.Commands.Cdn.Models.Endpoint.PSEndpoint

## OUTPUTS

### Microsoft.Azure.Commands.Cdn.Models.PSResourceUsage

## NOTES

## RELATED LINKS

