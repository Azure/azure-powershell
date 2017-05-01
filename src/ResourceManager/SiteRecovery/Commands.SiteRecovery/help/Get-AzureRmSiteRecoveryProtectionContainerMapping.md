---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: F3E1BEB5-B565-4618-9AEF-DB85A1AB2163
online version: 
schema: 2.0.0
---

# Get-AzureRmSiteRecoveryProtectionContainerMapping

## SYNOPSIS
Gets Azure Site Recovery Protection Container mappings.

## SYNTAX

### ByObject (Default)
```
Get-AzureRmSiteRecoveryProtectionContainerMapping -ProtectionContainer <ASRProtectionContainer>
 [<CommonParameters>]
```

### ByObjectWithName
```
Get-AzureRmSiteRecoveryProtectionContainerMapping -Name <String> -ProtectionContainer <ASRProtectionContainer>
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSiteRecoveryProtectionContainerMapping** cmdlet gets information about the Protection Container to Policy mappings in the vault.

## EXAMPLES

## PARAMETERS

### -Name
Specifies the name of the Protection Container mapping.

```yaml
Type: String
Parameter Sets: ByObjectWithName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionContainer
Specifies the Azure Site Recovery Protection Container object.

```yaml
Type: ASRProtectionContainer
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.SiteRecovery.ASRProtectionContainerMapping, Microsoft.Azure.Commands.SiteRecovery, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[New-AzureRmSiteRecoveryProtectionContainerMapping](./New-AzureRmSiteRecoveryProtectionContainerMapping.md)

[Remove-AzureRmSiteRecoveryProtectionContainerMapping](./Remove-AzureRmSiteRecoveryProtectionContainerMapping.md)
