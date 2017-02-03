---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: 1A95673A-8903-4FFD-9C0F-ACE5BCCAC39C
---

# Export-ACSLog

## SYNOPSIS
Collects system-related information into a package.

## SYNTAX

```
Export-ACSLog -FarmName <String> -StartTime <DateTime> -EndTime <DateTime> -Credential <PSCredential>
 [-LogPrefix <String>] [-AzureStorageContainer <String>] [-AzureStorageAccountName <String>]
 [-AzureStorageAccountKey <String>] [-AzureSasToken <String>] [-TargetShareFolder <String>]
 [[-SubscriptionId] <String>] [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String>
 [-SkipCertificateValidation] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Export-ACSLog** cmdlet assembles Azure Consistent Storage (ACS) logs, metrics, settings, health, and other system-related information into a package.

## EXAMPLES

### Example 1: Export logs
```
PS C:\>$Credential = Get-Credential
PS C:\> $Farm = Get-ACSFarm -ResourceGroupName "ContosoResource03"
PS C:\> $End = Get-Date
PS C:\> $Start = $End.AddMinutes(-10)
PS C:\> Export-ACSLog -ResourceGroupName "ContosoResource03" -Credential $Credential -EndTime $End -FarmName $Farm.Name -StartTime $Start
```

The first command prompts you for credentials, and then stores them in the $Credential variable.

The second command gets the farm for the resource group named ContosoResource03 by using the Get-ACSFarm cmdlet.
The command stores the farm in the $Farm variable.

The third command creates a **DateTime** object for the current time, and then stores it in the $End variable.

The fourth command creates a **DateTime** object for a time 10 minutes before the time in $End, and then stores it in the $Start variable.

The final command exports log information for the period between $Start and $End.
The command uses the credentials stored in $Credential.
The command identifies the farm by using the **Name** property of $Farm.

## PARAMETERS

### -FarmName
Specifies the name of the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartTime
Specifies the start of the time range, as a **DateTime** object, for the events that this cmdlet exports.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
Specifies the end of the time range, as a **DateTime** object, for the events that this cmdlet exports.
For more information about **DateTime** objects, see the Get-Date cmdlet.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogPrefix
Specifies a prefix that this cmdlet uses to filter the log information.

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

### -AzureStorageContainer
Specifies your storage container.
Specify this parameter to upload the collected information directly into your storage account.

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

### -AzureStorageAccountName
Specifies the name of your storage account.
Specify this parameter to upload the collected information directly into your storage account.

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

### -AzureStorageAccountKey
Specifies the key for your storage account.
Specify this parameter to upload the collected information directly into your storage account.

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

### -AzureSasToken
Specifies a Shared Access Signature (SAS) token.

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

### -TargetShareFolder
Specifies the UNC path of the folder where this cmdlet stores the collected log information.

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
Specifies the subscription ID of the service administrator.

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
Specifies the token of the service administrator.

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
Specifies the name of the resource group that contains the storage stack.

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

### -Credential
Specifies a credential that this cmdlet uses to access each node.
To obtain a credential object, use the Get-Credential cmdlet.

```yaml
Type: PSCredential
Parameter Sets: (All)
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

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-ACSFarm](./Get-ACSFarm.md)


