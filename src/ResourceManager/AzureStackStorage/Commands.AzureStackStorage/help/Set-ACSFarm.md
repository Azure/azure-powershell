---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 363D9311-EA3D-409F-ADD0-75FB49597EB4
---

# Set-ACSFarm

## SYNOPSIS
Changes the settings of the service configuration on an ACS Farm.

## SYNTAX

```
Set-ACSFarm [-FarmName] <String> [-SettingsPollingIntervalInSecond <Int32>] [-HostStyleHttpPort <Int32>]
 [-HostStyleHttpsPort <Int32>] [-CorsAllowedOriginsList <String>] [-DataCenterUriHostSuffixes <String>]
 [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String>
 [-SkipCertificateValidation] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-ACSFarm** cmdlet changes the settings of the service configuration on an Azure Consistent Storage (ACS) Farm.

## EXAMPLES

### Example 1: Change the settings of the service configuration on an ACS Farm
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID"
PS C:\> $Token = "Token"
PS C:\> $ResourceGroup = "System" 
PS C:\> $Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup
PS C:\> Set-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation -FarmName $Farm.Name -SettingPollingIntervalInSeconds 45

HealthStatus SettingsStore                                             Settings
------------ -------------                                             --------
    Critical file://SOFS.PoC.local/share/ObjectStorageService/Settings Microsoft.AzureStack.Management.StorageAdmin....
```

The first command gets the specified ACS farm and stores the result in the $Farm variable.
The final command sets the ACS farm's setting polling interval to 45 seconds.

## PARAMETERS

### -FarmName
Specifies the name of the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SettingsPollingIntervalInSecond
Specifies the polling interval, in seconds.

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

### -HostStyleHttpPort
Specifies the host HTTP port number.

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

### -HostStyleHttpsPort
Specifies the host HTTPS port number.

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

### -CorsAllowedOriginsList
Specifies the cross-origin resource sharing (CORS) allowed origins list.

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

### -DataCenterUriHostSuffixes
Specifes the data center host's URL Suffixes.

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
Specifies the name of the resource group from which this cmdlet sets the ACS farm.

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

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,
Output from Get-ACSFarm can be piped to this cmdlet's input.

## OUTPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse

## NOTES

## RELATED LINKS

[Add-ACSFarm](./Add-ACSFarm.md)

[Get-ACSFarm](./Get-ACSFarm.md)


