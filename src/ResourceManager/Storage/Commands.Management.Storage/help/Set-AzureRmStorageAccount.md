---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
ms.assetid: 4D7EEDD7-89D4-4B1E-A9A1-B301E759CE72
online version: 
schema: 2.0.0
---

# Set-AzureRmStorageAccount

## SYNOPSIS
Modifies a Storage account.

## SYNTAX

```
Set-AzureRmStorageAccount [-ResourceGroupName] <String> [-Name] <String> [-Force] [[-SkuName] <String>]
 [[-AccessTier] <String>] [[-CustomDomainName] <String>] [[-UseSubDomain] <Boolean>]
 [[-EnableEncryptionService] <EncryptionSupportServiceEnum>]
 [[-DisableEncryptionService] <EncryptionSupportServiceEnum>] [[-Tag] <Hashtable>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmStorageAccount** cmdlet modifies an Azure Storage account.
You can use this cmdlet to modify the account type, update a customer domain, or set tags on a Storage account.

## EXAMPLES

### Example 1: Set the Storage account type
```
PS C:\>Set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount" -Type "Standard_RAGRS"
```

This command sets the Storage account type to Standard_RAGRS.

### Example 2: Set a custom domain for a Storage account
```
PS C:\>Set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount" -CustomDomainName "www.contoso.com" -UseSubDomain $True
```

This command sets a custom domain for a Storage account.

### Example 3: Enable encryption on Blob and File Services
```
PS C:\>Set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount" -EnableEncryptionService "Blob,File"
```

This command enables Storage Service encryption on Blob and File for a Storage account.


### Example 4: Set the access tier value
```
PS C:\>Set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount" -AccessTier Cool
```

The command sets the Access Tier value to be cool.

## PARAMETERS

### -ResourceGroupName
Specifies the name of the resource group in which to modify the Storage account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the Storage account to create.

```yaml
Type: String
Parameter Sets: (All)
Aliases: StorageAccountName, AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
If you change the access tier, it may result in additional charges.
For more information, see Azure Blob Storage: Hot and cool storage tiershttp://go.microsoft.com/fwlink/?LinkId=786482 (http://go.microsoft.com/fwlink/?LinkId=786482).
If the kind of Storage account is Storage, do not specify this parameter.

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

### -SkuName
Specifies the SKU name of the storage account.
The acceptable values for this parameter are:

- Standard_LRS.
Locally-redundant storage. 
- Standard_ZRS.
Zone-redundant storage.
- Standard_GRS.
Geo-redundant storage. 
- Standard_RAGRS.
Read access geo-redundant storage. 
- Premium_LRS.
Premium locally-redundant storage.

You cannot change Standard_ZRS and Premium_LRS types to other account types.
You cannot change other account types to Standard_ZRS or Premium_LRS.

```yaml
Type: String
Parameter Sets: (All)
Aliases: StorageAccountType, AccountType, Type

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AccessTier
Specifies the access tier of the Storage account that this cmdlet modifies.
The acceptable values for this parameter are: Hot and Cool.

If you change the access tier, it may result in additional charges.
For more information, see Azure Blob Storage: Hot and cool storage tiershttp://go.microsoft.com/fwlink/?LinkId=786482 (http://go.microsoft.com/fwlink/?LinkId=786482).
If the kind of Storage account is Storage, do not specify this parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomDomainName
Specifies the name of the custom domain.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSubDomain
Indicates whether to enable indirect CName validation.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableEncryptionService
Indicates whether this cmdlet enables Storage Service encryption on the Storage Service.
Azure Blob and Azure File Services are supported.

```yaml
Type: EncryptionSupportServiceEnum
Parameter Sets: (All)
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableEncryptionService
Indicates whether this cmdlet disables Storage Service encryption on the Storage Service.
Azure Blob and Azure File Services are supported.

```yaml
Type: EncryptionSupportServiceEnum
Parameter Sets: (All)
Aliases: 

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
If you specify a value of BlobStorage for the *Kind* parameter of the New-AzureRmStorageAccount cmdlet, you must specify a value for the *AccessTier* parameter.

If you specify a value of Storage for this *Kind* parameter, do not specify the *AccessTier* parameter.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: 8
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
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

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmStorageAccount](./Get-AzureRmStorageAccount.md)

[New-AzureRmStorageAccount](./New-AzureRmStorageAccount.md)

[Remove-AzureRmStorageAccount](./Remove-AzureRmStorageAccount.md)


