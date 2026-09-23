### Example 1: Create a certificate for a NGINX deployment
```powershell
Update-AzNginxCertificate -DeploymentName nginx-test -Name cert-test -ResourceGroupName nginx-test-rg -CertificateVirtualPath /etc/nginx/test.cert -KeyVirtualPath /etc/nginx/test.key -KeyVaultSecretId https://tests-kv.vault.azure.net/secrets/newcert
```

```output
Location Name
-------- ----
         cert-test
```

This command creates a certificate for a NGINX deployment.
