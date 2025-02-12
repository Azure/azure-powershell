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
