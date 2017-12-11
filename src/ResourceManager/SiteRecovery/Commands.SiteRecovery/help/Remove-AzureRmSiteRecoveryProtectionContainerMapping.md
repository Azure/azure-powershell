---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
Module Name: AzureRM
ms.assetid: B1D914F8-4181-4BF1-B1D3-A5857DA8254C
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.siterecovery/remove-azurermsiterecoveryprotectioncontainermapping
schema: 2.0.0
---

# Remove-AzureRmSiteRecoveryProtectionContainerMapping

## SYNOPSIS
Removes an Azure Site Recovery Protection Container mapping.

## SYNTAX

```
Remove-AzureRmSiteRecoveryProtectionContainerMapping
 -ProtectionContainerMapping <ASRProtectionContainerMapping> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmSiteRecoveryProtectionContainerMapping** cmdlet removes an Azure Site Recovery Protection Container mapping.

## EXAMPLES

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

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

### -ProtectionContainerMapping
Specifies the Azure Site Recovery Protection Container mapping object.

```yaml
Type: ASRProtectionContainerMapping
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### ASRProtectionContainerMapping
Parameter 'ProtectionContainerMapping' accepts value of type 'ASRProtectionContainerMapping' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmSiteRecoveryProtectionContainerMapping](./Get-AzureRmSiteRecoveryProtectionContainerMapping.md)

[New-AzureRmSiteRecoveryProtectionContainerMapping](./New-AzureRmSiteRecoveryProtectionContainerMapping.md)
