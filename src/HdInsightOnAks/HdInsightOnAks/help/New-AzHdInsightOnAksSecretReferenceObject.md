---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonakssecretreferenceobject
schema: 2.0.0
---

# New-AzHdInsightOnAksSecretReferenceObject

## SYNOPSIS
Create an in-memory object for SecretReference.

## SYNTAX

```
New-AzHdInsightOnAksSecretReferenceObject -ReferenceName <String> -SecretName <String> -Type <String>
 [-Version <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SecretReference.

## EXAMPLES

### Example 1: Create a reference to provide a secret to store the password for accessing the database.
```powershell
$keyVaultResourceId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{your resource group name}/providers/Microsoft.KeyVault/vaults/{your vault name}";
$secretName="{your secret name}"
$referenceName="{your secret reference name}";

$secretReference=New-AzHdInsightOnAksSecretReferenceObject -SecretName $secretName -ReferenceName $referenceName -Type Secret
```

```output
SecretName ReferenceName                Type   Version
------------------ -------------                ----   -------
{your secret name} {your secret reference name} Secret
```

Create a reference to provide a secret to store the password for accessing the database.

## PARAMETERS

### -ReferenceName
Reference name of the secret to be used in service configs.

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
Object identifier name of the secret in key vault.

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

### -Type
Type of key vault object: secret, key or certificate.

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
Version of the secret in key vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.SecretReference

## NOTES

## RELATED LINKS
