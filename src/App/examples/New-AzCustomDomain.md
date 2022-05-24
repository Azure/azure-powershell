### Example 1: Create a CustomDomain object for ContainerApp.
```powershell
$CertificateId = "/subscriptions/{subscriptionid}/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube/certificates/my-certificate-for-my-other-name-dot-com"

New-AzCustomDomain -CertificateId $CertificateId -Name www.my-name.com -BindingType SniEnabled
```

```output
BindingType CertificateId                                                                                                                                                Name
----------- -------------                                                                                                                                                ----
SniEnabled  /subscriptions/{subscriptionid}/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube/certificates/my-certificate-for-my-other-name-dot-com www.my-name.com
```

Create a CustomDomain object for ContainerApp.