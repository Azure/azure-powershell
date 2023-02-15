### Example 1: Create a CustomDomain object for ContainerApp.
```powershell
$certificateId = (Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert).Id

$customDomain = New-AzContainerAppCustomDomainObject -CertificateId $certificateId -Name www.fabrikam.com -BindingType SniEnabled
```

```output
BindingType CertificateId                                                                                                                                                Name
----------- -------------                                                                                                                                                ----
SniEnabled  /subscriptions/{subscriptionid}/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube/certificates/my-certificate-for-my-other-name-dot-com www.my-name.com
```

Create a CustomDomain object for ContainerApp.