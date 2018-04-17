---
external help file: Azs.Azurebridge.Admin-help.xml
Module Name: Azs.AzureBridge.Admin
online version: 
schema: 2.0.0
---

# Invoke-AzsAzureBridgeProductDownload

## SYNOPSIS
Downloads a product from azure marketplace.

## SYNTAX

### Products_Download (Default)
```
Invoke-AzsAzureBridgeProductDownload -ActivationName <String> -ProductName <String> -ResourceGroupName <String>
 [-Wait] [<CommonParameters>]
```

### ResourceId
```
Invoke-AzsAzureBridgeProductDownload -ResourceId <String> [-Wait] [<CommonParameters>]
```

## DESCRIPTION
Downloads a product from azure marketplace.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Invoke-AzsAzureBridgeProductDownload -ActivationName 'myActivation' -ProductName 'microsoft.docker-arm.1.1.0' -ResourceGroupName 'activationRG'
```

Download a product from Azure Marketplace

## PARAMETERS

### -ActivationName
Name of the activation.

```yaml
Type: String
Parameter Sets: Products_Download
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductName
Name of the product.

```yaml
Type: String
Parameter Sets: Products_Download
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group the resource is located under.

```yaml
Type: String
Parameter Sets: Products_Download
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource identifier for azure bridge product.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

