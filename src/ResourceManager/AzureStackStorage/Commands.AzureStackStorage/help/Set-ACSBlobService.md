---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 0839E9DA-DBAE-4857-A69D-0097709BACA5
---

# Set-ACSBlobService

## SYNOPSIS
Configures the settings of a blob service.

## SYNTAX

```
Set-ACSBlobService [-FarmName] <String> [-FrontEndCpuBasedKeepAliveThrottlingEnabled <Boolean>]
 [-FrontEndMemoryThrottlingEnabled <Boolean>] [-BlobSvcContainerGcInterval <Int32>]
 [-BlobSvcShallowGcInterval <Int32>] [-BlobSvcStreamMapMinContainerOccupancyPercent <Int32>]
 [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String>
 [-SkipCertificateValidation] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-ACSBlobService** cmdlet configure the settings of a blob service.

## EXAMPLES

### Example 1: Configure the settings of a blob service
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID"
PS C:\> $Token = "Token001"
PS C:\> $ResourceGroup = "System"

PS C:\> $Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup
PS C:\> Set-ACSBlobService -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -FarmName $Farm.Name -FrontEndCpuBasedKeepAliveThrottlingEnabled $true -SkipCertificateValidation
```

The first command gets the ACS farm from the specified URL and stores it in the variable named $Farm.
The final command configures the blob service settings from the farm name.

## PARAMETERS

### -FarmName
Specifies the name of the Azure Consistent Storage (ACS) farm.

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

### -FrontEndCpuBasedKeepAliveThrottlingEnabled
Indicates whether this cmdlet enables front end CPU based throttling.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontEndMemoryThrottlingEnabled
Indicates whether this cmdlet enables front end memory based throttling.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobSvcContainerGcInterval
Specifies the blob service container garbage collection interval.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobSvcShallowGcInterval
Specifies the blob service shallow garbage collection interval.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobSvcStreamMapMinContainerOccupancyPercent

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Specifies the name of the resource group that this cmdlet gets the ACS blob service information from.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,Microsoft.AzureStack.Commands.StorageAdmin.AccountContainerRoleInstanceResponse,
Output from Get-ACSFarm and Get-ACSBlobService can be piped to this cmdlet's input.

## OUTPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.BlobServiceResponse

## NOTES

## RELATED LINKS

[Get-ACSBlobService](./Get-ACSBlobService.md)

[Get-ACSFarm](./Get-ACSFarm.md)


