---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
ms.assetid: 6AB09621-488B-4A16-92D9-9C47EB87DA95
online version: 
schema: 2.0.0
---

# Get-AzureRmResourceProvider

## SYNOPSIS
Gets a resource provider.

## SYNTAX

### ListAvailable (Default)
```
Get-AzureRmResourceProvider [-Location <String>] [-ListAvailable] [-ApiVersion <String>] [-Pre]
 [<CommonParameters>]
```

### IndividualProvider
```
Get-AzureRmResourceProvider -ProviderNamespace <String> [-Location <String>] [-ApiVersion <String>] [-Pre]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmResourceProvider** cmdlet gets an Azure resource provider.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -ListAvailable
Indicates that this operation gets all available resource providers.

```yaml
Type: SwitchParameter
Parameter Sets: ListAvailable
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderNamespace
Specifies the namespace of the resource provider.

```yaml
Type: String
Parameter Sets: IndividualProvider
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ApiVersion
Specifies the API version that is supported by the resource Provider.
You can specify a different version than the default version.

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

### -Location
Specifies the location of the resource provider.

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

### -Pre
Indicates that this cmdlet considers pre-release API versions when it automatically determines which version to use.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
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

[Register-AzureRmResourceProvider](./Register-AzureRmResourceProvider.md)

[Unregister-AzureRmResourceProvider](./Unregister-AzureRmResourceProvider.md)


