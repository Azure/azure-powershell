---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 4DC26C26-6162-4A15-BFCB-4D2B6B52DD81
online version: 
schema: 2.0.0
---

# Get-AzureRmADServicePrincipal

## SYNOPSIS
Filters active directory service principals.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzureRmADServicePrincipal [-ServicePrincipalName <String>] [<CommonParameters>]
```

### SearchStringParameterSet
```
Get-AzureRmADServicePrincipal -SearchString <String> [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzureRmADServicePrincipal -ObjectId <Guid> [<CommonParameters>]
```

### SPNParameterSet
```
Get-AzureRmADServicePrincipal -ServicePrincipalName <String> [<CommonParameters>]
```

## DESCRIPTION
Filters active directory service principals.

## EXAMPLES

### --------------------------  Filters service principals using SPN  --------------------------
```
PS C:\> Get-AzureRmADServicePrincipal -SPN 36f81fc3-b00f-48cd-8218-3879f51ff39f
```

Gets service principals with 36f81fc3-b00f-48cd-8218-3879f51ff39f SPN.

### --------------------------  Filters service principals using Search String  --------------------------
```
PS C:\> Get-AzureRmADServicePrincipal -SearchString "Web"
```

Filters all ad service principals that have display name starting with "Web".

### --------------------------  List AD service principals  --------------------------
```
PS C:\> Get-AzureRmADServicePrincipal
```

Gets all AD service principals.

## PARAMETERS

### -ObjectId
Object id of the service principal.

```yaml
Type: Guid
Parameter Sets: ObjectIdParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SearchString
Fetches all service principals that have the display name starting with this value.

```yaml
Type: String
Parameter Sets: SearchStringParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServicePrincipalName
SPN of the service.

```yaml
Type: String
Parameter Sets: EmptyParameterSet
Aliases: SPN

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: SPNParameterSet
Aliases: SPN

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[New-AzureRmADServicePrincipal]()

[Set-AzureRmADServicePrincipal]()

[Remove-AzureRmADServicePrincipal]()

[Get-AzureRmADApplication]()

[Get-AzureRmADSpCredential]()

