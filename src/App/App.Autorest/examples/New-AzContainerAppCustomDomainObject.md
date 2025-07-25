### Example 1: Create an in-memory object for CustomDomain.
```powershell
$certificateId = (Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert).Id

New-AzContainerAppCustomDomainObject -Name "www.my-name.com" -BindingType "SniEnabled" -CertificateId $certificateId
```

```output
BindingType CertificateId                                                                                                                                 Name
----------- -------------                                                                                                                                 ----
SniEnabled  /subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/managedEnvironments/{manageEnvName}/certificates/{testcert} www.my-name.com
```

Create an in-memory object for CustomDomain.