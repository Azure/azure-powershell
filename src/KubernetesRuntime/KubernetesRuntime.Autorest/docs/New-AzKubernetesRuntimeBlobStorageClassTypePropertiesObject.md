---
external help file:
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/Az.KubernetesRuntime/new-azkubernetesruntimeblobstorageclasstypepropertiesobject
schema: 2.0.0
---

# New-AzKubernetesRuntimeBlobStorageClassTypePropertiesObject

## SYNOPSIS
Create an in-memory object for BlobStorageClassTypeProperties.

## SYNTAX

```
New-AzKubernetesRuntimeBlobStorageClassTypePropertiesObject -AzureStorageAccountKey <SecureString>
 -AzureStorageAccountName <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BlobStorageClassTypeProperties.

## EXAMPLES

### Example 1: Create a BlobStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeBlobStorageClassTypePropertiesObject `
    -AzureStorageAccountName accountName `
    -AzureStorageAccountKey $(ConvertTo-SecureString 'accountKey' -AsPlainText)
```

Create a `BlobStorageClassTypeProperties` object with account name and account key.

## PARAMETERS

### -AzureStorageAccountKey
Azure Storage Account Key.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureStorageAccountName
Azure Storage Account Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.BlobStorageClassTypeProperties

## NOTES

## RELATED LINKS

