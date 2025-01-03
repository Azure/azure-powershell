---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
ms.assetid: A57A9EFA-47AC-44D8-BFA7-CDE0E2A612B3
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstorageaccountkey
schema: 2.0.0
---

# Get-AzStorageAccountKey

## SYNOPSIS
Gets the access keys for an Azure Storage account.

## SYNTAX

```
Get-AzStorageAccountKey [-ResourceGroupName] <String> [-Name] <String> [-ListKerbKey]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageAccountKey** cmdlet gets the access keys for an Azure Storage account.

## EXAMPLES

### Example 1: Get the access keys for a Storage account
```powershell
Get-AzStorageAccountKey -ResourceGroupName "RG01" -Name "mystorageaccount"
```

This command gets the keys for the specified Azure Storage account.

### Example 2: Get a specific access key for a Storage account
<!-- Skip: Output cannot be splitted from code -->


```
This command gets a specific key for a Storage account.
(Get-AzStorageAccountKey -ResourceGroupName "RG01" -Name "mystorageaccount")| Where-Object {$_.KeyName -eq "key1"}

KeyName Value             Permissions CreationTime
------- -----             ----------- ------------
key1    <KeyValue>        Full             

This command gets a specific key value for a Storage account. 
(Get-AzStorageAccountKey -ResourceGroupName "RG01" -Name "mystorageaccount")[0].Value

<KeyValue>
```

### Example 3: Lists the access keys for a Storage account, include the Kerberos keys (if active directory enabled)
```powershell
Get-AzStorageAccountKey -ResourceGroupName "RG01" -Name "mystorageaccount" -ListKerbKey
```

This command gets the keys for the specified Azure Storage account.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListKerbKey
Lists the Kerberos keys (if active directory enabled) for the specified storage account.

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

### -Name
Storage Account Name.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccountKey

## NOTES

## RELATED LINKS
