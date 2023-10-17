### Example 1: Create a Managed Certificate.
```powershell
New-AzContainerAppManagedCert -EnvName azps-env -Name azps-managedcert -ResourceGroupName azps_test_group_app -Location eastus -DomainControlValidation TXT -SubjectName "mycertweb.com"
```

```output
Name             SubjectName   Location ResourceGroupName   DomainControlValidation
----             -----------   -------- -----------------   -----------------------
azps-managedcert mycertweb.com East US  azps_test_group_app TXT
```

Create a Managed Certificate.
Users need to create new resources about "App Service Domain" and "DNS zone" in the same resource group.
Follow the steps in the help file to configure the resource "DNS zone" that you just created: https://learn.microsoft.com/en-us/azure/container-apps/custom-domains-managed-certificates?pivots=azure-portal