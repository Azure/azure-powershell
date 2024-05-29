### Example 1: Update certificate resource.
```powershell
$certObj = New-AzSpringKeyVaultCertificateObject -KeyVaultCertName  "mycert" -VaultUri "https://azps-kv.vault.azure.net" -CertVersion "xxxxxxxxxxxxxxxxxxxxxxxxx" -ExcludePrivateKey $false
Update-AzSpringCertificate -Name azps-cert -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -Property $certObj
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/certificates/azps-cert
Name                         : azps-cert
Property                     : {
                                 "type": "KeyVaultCertificate",
                                 "thumbprint": "841adf23c53e377c5f37f716740ea96a870da937",
                                 "issuer": "mydomain.com",
                                 "expirationDate": "2025-05-29T12:27:04.000+00:00",
                                 "activateDate": "2024-05-29T12:17:04.000+00:00",
                                 "subjectName": "mydomain.com",
                                 "dnsNames": [ ],
                                 "provisioningState": "Succeeded",
                                 "vaultUri": "https://azps-kv.vault.azure.net",
                                 "keyVaultCertName": "mycert",
                                 "certVersion": "xxxxxxxxxxxxxxxxxxxxxxxxx",
                                 "excludePrivateKey": false,
                                 "autoSync": "Disabled"
                               }
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-05-29 下午 12:28:24
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-05-29 下午 12:37:35
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/certificates
```

Update certificate resource.