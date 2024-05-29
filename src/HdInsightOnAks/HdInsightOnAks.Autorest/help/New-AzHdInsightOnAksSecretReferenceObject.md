---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksSecretReferenceObject
schema: 2.0.0
---

# New-AzHdInsightOnAksSecretReferenceObject

## SYNOPSIS
Create a reference to provide a secret to store the password for accessing the database.

## SYNTAX

```
New-AzHdInsightOnAksSecretReferenceObject -ReferenceName <String> -SecretName <String> [-Version <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a reference to provide a secret to store the password for accessing the database.
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName
NA

## EXAMPLES

### Example 1: Create a reference to provide a secret to store the password for accessing the database.
```powershell
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName
```

```output
KeyVaultObjectName ReferenceName                Type   Version
------------------ -------------                ----   -------
{your secret name} {your secret reference name} Secret
```

Create a reference to provide a secret to store the password for accessing the database.

## PARAMETERS

### -ReferenceName
The reference name of the secret to be used in service configs.

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

### -SecretName
The secret name in the key vault.

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

### -Version
The version of the secret in key vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ISecretReference

## NOTES

## RELATED LINKS

