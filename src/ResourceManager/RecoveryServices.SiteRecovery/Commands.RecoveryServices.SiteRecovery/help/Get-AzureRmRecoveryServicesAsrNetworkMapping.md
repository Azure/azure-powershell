---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: AzureRM.RecoveryServices.SiteRecovery
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.recoveryservices.siterecovery/get-azurermrecoveryservicesasrnetworkmapping
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesAsrNetworkMapping

## SYNOPSIS
Gets information about Site Recovery network mappings for the current vault.

## SYNTAX

### ByObject (Default)
```
Get-AzureRmRecoveryServicesAsrNetworkMapping [-Name <String>] -Network <ASRNetwork>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByFabricObject
```
Get-AzureRmRecoveryServicesAsrNetworkMapping [-Name <String>] -PrimaryFabric <ASRFabric>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmRecoveryServicesAsrNetworkMapping** cmdlet gets information about Azure Site Recovery network mappings for the Recovery Services vault.

## EXAMPLES

### Example 1
```
PS C:\> $Networkmappings = Get-AzureRmRecoveryServicesAsrNetworkMapping -Network $Network
```

Gets all networks mappings for the passed Network.

### Example 2
```
PS C:\> $primaryFabric = Get-AzureRmRecoveryServicesAsrFabric -Name xxxx
PS C:\> $Networkmappings = Get-AzureRmRecoveryServicesAsrNetworkMapping -Name $networkMappingName -PrimaryFabric $primaryFabric
```

Gets networks mapping with provided name in specified azure site recovery fabric.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.
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
The name of the ASR network mapping object to get.

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

### -Network
Get the ASR network mappings corresponding to the specified network ASR object.

```yaml
Type: ASRNetwork
Parameter Sets: ByObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrimaryFabric
Get the ASR network mappings corresponding to the specified primary fabric object.

```yaml
Type: ASRFabric
Parameter Sets: ByFabricObject
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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRFabric

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRNetworkMapping, Microsoft.Azure.Commands.RecoveryServices.SiteRecovery, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[New-AzureRmRecoveryServicesAsrNetworkMapping](./New-AzureRmRecoveryServicesAsrNetworkMapping.md)

[Remove-AzureRmRecoveryServicesAsrNetworkMapping](./Remove-AzureRmRecoveryServicesAsrNetworkMapping.md)
