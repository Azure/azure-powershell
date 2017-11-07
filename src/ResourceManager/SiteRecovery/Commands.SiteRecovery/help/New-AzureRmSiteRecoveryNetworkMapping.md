---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
Module Name: AzureRM
ms.assetid: 4BF1E20A-46EA-48E2-8C7A-F121AE6815AF
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.siterecovery/new-azurermsiterecoverynetworkmapping
schema: 2.0.0
---

# New-AzureRmSiteRecoveryNetworkMapping

## SYNOPSIS
Creates a mapping between virtual networks.

## SYNTAX

### EnterpriseToEnterprise
```
New-AzureRmSiteRecoveryNetworkMapping [-Name <String>] -PrimaryNetwork <ASRNetwork>
 -RecoveryNetwork <ASRNetwork> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### EnterpriseToAzure
```
New-AzureRmSiteRecoveryNetworkMapping [-Name <String>] -PrimaryNetwork <ASRNetwork> -AzureVMNetworkId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRMSiteRecoveryNetworkMapping** cmdlet creates a mapping between two virtual networks and returns an Azure Site Recovery job to track it.

## EXAMPLES

## PARAMETERS

### -AzureVMNetworkId
Specifies the Azure virtual network ID.

```yaml
Type: String
Parameter Sets: EnterpriseToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Name
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

### -PrimaryNetwork
Specifies the primary network object.

```yaml
Type: ASRNetwork
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecoveryNetwork
Specifies the recovery network object.

```yaml
Type: ASRNetwork
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

### ASRNetwork
Parameter 'PrimaryNetwork' accepts value of type 'ASRNetwork' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmSiteRecoveryNetworkMapping](./Get-AzureRmSiteRecoveryNetworkMapping.md)

[Remove-AzureRmSiteRecoveryNetworkMapping](./Remove-AzureRmSiteRecoveryNetworkMapping.md)
