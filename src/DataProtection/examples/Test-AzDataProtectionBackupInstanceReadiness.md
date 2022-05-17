### Example 1: Test the backup instance 
```powershell
Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPostgreSQL -DatasourceLocation "westus" -PolicyId $polOss[0].Id -DatasourceId "subscriptions/xxxxxx-xxxxxx-xxxx/resourcegroups/Ossrg/providers/Microsoft.DBforPostgreSQL/servers/rishitserver3/databases/postgres" -SecretStoreURI "https://rishitkeyvault3.vault.azure.net/secrets/rishitnewsecre" -SecretStoreType AzureKeyVault

```


The command validates whether the backup instance is ready for configuring backup


