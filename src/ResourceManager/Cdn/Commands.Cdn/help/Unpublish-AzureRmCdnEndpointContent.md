---
external help file: Microsoft.Azure.Commands.Cdn.dll-Help.xml
ms.assetid: 21E9F441-A00B-4F79-8FF1-968D92982471
online version: 
schema: 2.0.0
---

# Unpublish-AzureRmCdnEndpointContent

## SYNOPSIS
Purges a CDN endpoint.

## SYNTAX

### Parameter Set for fields parameters (Default)
```
Unpublish-AzureRmCdnEndpointContent -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 -PurgeContent <String[]> [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Parameter Set for object parameters
```
Unpublish-AzureRmCdnEndpointContent -CdnEndpoint <PSEndpoint> -PurgeContent <String[]> [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Unpublish-AzureRmCdnEndpointContent** cmdlet purges the content from an Azure Content Delivery Network (CDN) endpoint.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -CdnEndpoint
Specifies the endpoint that this cmdlet purges.

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
Specifies name of the endpoint that this cmdlet purges.

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

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -PurgeContent
Specifies an array of relative paths for the content on the origin server that this cmdlet purges.

```yaml
Type: String[]
Parameter Sets: (All)
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSEndpoint

Parameter 'CdnEndpoint' accepts value of type 'PSEndpoint' from the pipeline

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Publish-AzureRmCdnEndpointContent](./Publish-AzureRmCdnEndpointContent.md)


