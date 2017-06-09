---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesAsrProtectionContainerMapping

## SYNOPSIS
Gets Azure Site Recovery Protection Container mappings.

## SYNTAX

### ByObject (Default)
```
Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer <ASRProtectionContainer>
 [<CommonParameters>]
```

### ByObjectWithName
```
Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -Name <String>
 -ProtectionContainer <ASRProtectionContainer> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmRecoveryServicesAsrProtectionContainerMapping** cmdlet gets information about the Protection Container to Policy mappings in the vault.

## EXAMPLES

### Example 1
```
PS C:\> $ProtectionContainerMappings = Get-AzureRmRecoveryServicesAsrProtectionContainerMapping -ProtectionContainer $Container
```

Gets all container mappings for a container.

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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectionContainer

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectionContainerMapping, Microsoft.Azure.Commands.RecoveryServices.SiteRecovery, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[New-AzureRmRecoveryServicesAsrProtectionContainerMapping](./New-AzureRmRecoveryServicesAsrProtectionContainerMapping.md)

[Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping](./Remove-AzureRmRecoveryServicesAsrProtectionContainerMapping.md)
