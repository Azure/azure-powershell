---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: 11CE6244-D287-4B99-9585-E3EA2D36A4F9
online version: 
schema: 2.0.0
---

# New-AzureRmSiteRecoveryProtectionContainerMapping

## SYNOPSIS
Creates an Azure Site Recovery Protection Container mapping by associating a policy to a Protection Container.

## SYNTAX

### EnterpriseToAzure (Default)
```
New-AzureRmSiteRecoveryProtectionContainerMapping -Name <String> -Policy <ASRPolicy>
 -PrimaryProtectionContainer <ASRProtectionContainer> [<CommonParameters>]
```

### EnterpriseToEnterprise
```
New-AzureRmSiteRecoveryProtectionContainerMapping -Name <String> -Policy <ASRPolicy>
 -PrimaryProtectionContainer <ASRProtectionContainer> -RecoveryProtectionContainer <ASRProtectionContainer>
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSiteRecoveryProtectionContainerMapping** cmdlet creates an Azure Site Recovery Protection Container mapping by associating a policy to a Protection Container.

## EXAMPLES

## PARAMETERS

### -Name
Specifies the name of the Protection Container mapping.

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

### -Policy
Specifies the Azure Site Recovery Policy object.

```yaml
Type: ASRPolicy
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrimaryProtectionContainer
Specifies the primary Protection Container object.

```yaml
Type: ASRProtectionContainer
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryProtectionContainer
Specifies the Recovery Protection Container object.

```yaml
Type: ASRProtectionContainer
Parameter Sets: EnterpriseToEnterprise
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

### Microsoft.Azure.Commands.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmSiteRecoveryProtectionContainerMapping](./Get-AzureRmSiteRecoveryProtectionContainerMapping.md)

[Remove-AzureRmSiteRecoveryProtectionContainerMapping](./Remove-AzureRmSiteRecoveryProtectionContainerMapping.md)
