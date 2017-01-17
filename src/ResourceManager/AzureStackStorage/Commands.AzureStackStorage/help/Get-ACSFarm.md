---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 4F48562C-457E-4EEE-847B-DE001A408BC2
---

# Get-ACSFarm

## SYNOPSIS
Gets the ACS Storage Farm, properties, and settings.

## SYNTAX

```
Get-ACSFarm [[-FarmName] <String>] [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>]
 [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSFarm** cmdlet gets the Azure Consistent Storage (ACS) Storage Farm, properties, and settings.

## EXAMPLES

### Example 1: Get an ACS farm
```
PS C:\>$Global:adminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID"
PS C:\> $Token = "Token01"
PS C:\> $ResourceGroup = "System"
PS C:\> Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup | fl
Properties : Microsoft.AzureStack.Management.StorageAdmin.Models.Farm
Id         : /subscriptions/565BBBB0-701E-4E54-B50A-1D7849D4843C/resourceGroups/System/providers/Microsoft.Storage.Admi
             n/farms/415adecd-1944-46d2-8f61-66d53cdc75d0
Location   : eastasia
Name       : 415adecd-1944-46d2-8f61-66d53cdc75d0
Tags       : {}
Type       : Microsoft.Storage.Admin/farms
```

This command gets an ACS Farm.

### Example 2: Get the properties of an ACS farm by subscription
```
PS C:\>Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup | Select-Object -ExpandProperty Properties | fl
HealthStatus  : Critical
SettingsStore : file://SOFS.PoC.local/share/ObjectStorageService/Settings
Settings      : Microsoft.AzureStack.Management.StorageAdmin.Models.FarmSettings
```

This command gets the properties of an ACS Farm by subscription ID.

## PARAMETERS

### -FarmName
Species the name of the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the service administrator subscription ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Token
Specifies the service administrator token.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdminUri
Specifies the location of the Resource Manager endpoint.
If you configured your environment by using the Set-AzureRMEnvironment cmdlet, you do not have to specify this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group in which this cmdlet gets the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipCertificateValidation
Indicates that this cmdlet skips certificate validation.

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

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse

## NOTES

## RELATED LINKS

[Add-ACSFarm](./Add-ACSFarm.md)

[Set-ACSFarm](./Set-ACSFarm.md)


