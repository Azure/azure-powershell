### Example 1: {{ Add title here }}
```powershell
Get-AzSpringCertificate -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/certificates/azps-cert
Name                         : azps-cert
Property                     : {
                                 "type": "KeyVaultCertificate",
                                 "provisioningState": "Failed",
                                 "vaultUri": "https://myvault.vault.azure.net",
                                 "keyVaultCertName": "mycert",
                                 "certVersion": "ed6e8bqmi21pee3m94f520nvrm",
                                 "excludePrivateKey": false,
                                 "autoSync": "Disabled"
                               }
ResourceGroupName            : azps_test_group_spring
SystemDataCreatedAt          : 2024-04-27 下午 01:00:25
SystemDataCreatedBy          : v-jinpel@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-27 下午 01:02:02
SystemDataLastModifiedBy     : v-jinpel@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.AppPlatform/Spring/certificates
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

