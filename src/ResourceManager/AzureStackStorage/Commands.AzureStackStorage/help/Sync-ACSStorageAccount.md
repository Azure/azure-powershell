---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: F7DFC5F3-C42A-4430-88EE-86289B3A739C
---

# Sync-ACSStorageAccount

## SYNOPSIS
Synchronizes the account status of the ACS tenant storage accounts from backend to frontend cache.

## SYNTAX

```
Sync-ACSStorageAccount [-TenantAccountName] <String> [-TenantSubscriptionId] <String> [-Location] <String>
 [-TenantResourceGroup] <String> [[-StorageAccountApiVersion] <String>] [[-SubscriptionId] <String>]
 [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Sync-ACSStorageAccount** cmdlet synchronizes the account status of the Azure Consistent Storage (ACS) tenant storage accounts from back-end to front-end cache.
After a storage account has been undeleted, a service administrator needs to synchronize the account status change back to the frontend cache in order to ensure the front-end can serve the request for that undeleted storage account.

## EXAMPLES

### Example 1: Synchronize the account status of the ACS tenant storage accounts
```
PS C:\>$Global:AdminUri = "https://srp.yourdomainFQDN:30020"
PS C:\> $SubscriptId = "SubID"
PS C:\> $Token = "Token"
PS C:\> $ResourceGroup = "System" 
PS C:\> $Farm = Get-ACSFarm -SubscriptionId $SubscriptId -Token $Token -AdminUri $AdminUri -SkipCertificateValidation -ResourceGroupName $ResourceGroup
PS C:\> Sync-ACSStorageAccount -AccountName "Account001" -TenantSubscriptionId "c09471e3-f674-4a7b-ba32-e1b48eaf18e4" -Location "EastUS" -SubscriptionId $SubscriptId -Token $token -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -SkipCertificateValidation
```

The first command gets the specified ACS Farm and stores the result in the variable named $Farm.
The final command then synchronizes the storage account named Account001 at the location named EastUS.

## PARAMETERS

### -TenantAccountName
Specifies the name of the tenant account.

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

### -TenantSubscriptionId
Specifies the tenant's subscription ID.

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

### -Location
Specifies the location of the storage account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TenantResourceGroup
Specifies the resource group of the tenant storage account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountApiVersion
Specifies the storage account API version.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 8
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
Specifies the name of the resource group from which this cmdlet gets the storage account from.

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

### Microsoft.AzureStack.Commands.StorageAdmin.StorageAccountResponse
Output from Get-ACSStorageAccount can be piped to this cmdlet's input.

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-ACSStorageAccount](./Get-ACSStorageAccount.md)

[Undo-ACSStorageAccountDeletion](./Undo-ACSStorageAccountDeletion.md)


