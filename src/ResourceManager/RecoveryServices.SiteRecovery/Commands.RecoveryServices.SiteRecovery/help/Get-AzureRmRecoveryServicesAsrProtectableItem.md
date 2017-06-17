---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesAsrProtectableItem

## SYNOPSIS
Get the protectable items in a Protection Container.

## SYNTAX

### ByObject (Default)
```
Get-AzureRmRecoveryServicesAsrProtectableItem -ProtectionContainer <ASRProtectionContainer>
 [<CommonParameters>]
```

### ByObjectWithName
```
Get-AzureRmRecoveryServicesAsrProtectableItem -Name <String> -ProtectionContainer <ASRProtectionContainer>
 [<CommonParameters>]
```

### ByObjectWithFriendlyName
```
Get-AzureRmRecoveryServicesAsrProtectableItem -FriendlyName <String>
 -ProtectionContainer <ASRProtectionContainer> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmRecoveryServicesAsrProtectableItem** cmdlet gets the protectable items in an Azure Site Recovery Protection Container.

## EXAMPLES

### Example 1
```
PS C:\> $ProtectableItems = Get-AzureRmRecoveryServicesAsrProtectableItem -ProtectionContainer $Container
```

Gets all the protectable items in passed container.

## PARAMETERS

### -FriendlyName
Specifies the friendly name of the Azure Site Recovery protectable item.

```yaml
Type: String
Parameter Sets: ByObjectWithFriendlyName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the Azure Site Recovery protectable item.

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

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectableItem, Microsoft.Azure.Commands.RecoveryServices.SiteRecovery, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrProtectionEntity](./Get-AzureRmRecoveryServicesAsrProtectionEntity.md)

[Set-AzureRmRecoveryServicesAsrProtectionEntity](./Set-AzureRmRecoveryServicesAsrProtectionEntity.md)
