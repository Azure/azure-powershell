---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/get-azcognitiveservicesmodelcapacity
schema: 2.0.0
---

# Get-AzCognitiveServicesModelCapacity

## SYNOPSIS
Get Cognitive Services Model Capacity

## SYNTAX

```
Get-AzCognitiveServicesModelCapacity [-Format] <String> [-Name] <String> [-Version] <String>
 [[-Location] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get Cognitive Services Model Capacity in all the regions or single region

## EXAMPLES

### Example 1
```powershell
Get-AzCognitiveServicesModelCapacity -Format "OpenAI" -Name "gpt-4" -Version "0125-Preview"
Get-AzCognitiveServicesModelCapacity -Format "OpenAI" -Name "gpt-4" -Version "0125-Preview" -Location "West US"
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Format
Cognitive Services Model Format.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Cognitive Services Account Location.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Cognitive Services Model Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Cognitive Services Model Version.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.CognitiveServices.Models.ModelSkuCapacityProperties

## NOTES

## RELATED LINKS
