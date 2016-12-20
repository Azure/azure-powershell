---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 6D098FBA-8E89-4A51-88DB-EA20B037830F
---

# Get-ACSBlobService

## SYNOPSIS
Gets the status and settings of the ACS blob service.

## SYNTAX

```
Get-ACSBlobService [-FarmName] <String> [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>]
 [-ResourceGroupName] <String> [-SkipCertificateValidation] [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSBlobService** cmdlet gets the status and settings of the Azure Consistent Storage (ACS) blob service.

## EXAMPLES

### Example 1: Get the properties of an ACS blob service
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID"
PS C:\> $Token = "Token"
PS C:\> $ResourceGroup = "System"

PS C:\> $Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup

PS C:\> Get-ACSBlobService -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $resourceGroup -SkipCertificateValidation -FarmName $Farm.Name | fl
Resource   : Microsoft.AzureStack.Management.StorageAdmin.Models.BlobServiceResponseResource
RequestId  : af9ec01d-8e52-402f-98eb-3245be0bbcc9
StatusCode : OK
```

The first command gets an ACS farm and stores it in the $Farm variable.
The final command then gets the properties of the ACS blob service from the farm.

## PARAMETERS

### -FarmName
Specifies the name of the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the service administrator subscription ID

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
Specifies the name of the resource group for the blob service.

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
Indicates that this cmdlet skip certificate validation.

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

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,
Output from cmdlet Get-ACSFarm can be piped to the input for this cmdlet.

## OUTPUTS

### Type: Microsoft.AzureStack.Commands.StorageAdmin.BlobServiceResponse

## NOTES

## RELATED LINKS

[Set-ACSBlobService](./Set-ACSBlobService.md)

[Get-ACSFarm](./Get-ACSFarm.md)


