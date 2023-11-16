### Example 1: Update an Azure Virtual Desktop app attach package by name
```powershell
$apps = "<PackagedApplication>"
$deps = "<PackageDependencies>"
Update-AzWvdAppAttachPackage -Name PackageArmObjectName `
                         -ResourceGroupName ResourceGroupName `
                         -SubscriptionId SubscriptionId `
                         -ImageDisplayName displayname `
                         -ImagePath imageURI `
                         -ImageIsActive:$false `
                         -ImageIsRegularRegistration:$false `
                         -ImageLastUpdated datelastupdated `
                         -ImagePackageApplication $apps `
                         -ImagePackageDependency $deps `
                         -ImagePackageFamilyName packagefamilyname `
                         -ImagePackageName packagename `
                         -ImagePackageFullName packagefullname `
                         -ImagePackageRelativePath packagerelativepath `
                         -ImageVersion packageversion `
                         -ImageCertificateExpiry certificateExpiry `
                         -ImageCertificateName certificateName `
                         -KeyVaultUrl keyvaultUrl `
                         -FailHealthCheckOnStagingFailure 'Unhealthy'
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     PackageArmObjectName Microsoft.DesktopVirtualization/appattachpackages
```

This command updates an Azure Virtual Desktop App attach package in a resource group


### Example 2: Create an Azure Virtual Desktop app attach package from an appAttachPackage object
```powershell
Update-AzWvdAppAttachPackage -Name PackageArmObjectName `
                         -ResourceGroupName ResourceGroupName `
                         -SubscriptionId SubscriptionId `
                         -DisplayName displayname `
                         -AppAttachPackage imageObject `
                         -IsActive:$false `
                         -IsLogonBlocking:$false `
                         -KeyVaultUrl keyvaultUrl `
                         -FailHealthCheckOnStagingFailure 'Unhealthy' `
                         -HostpoolReference hostpoolReference `
                         -PassThru
```

```output                         
Location   Name                 Type
--------   ----                 ----
eastus     PackageArmObjectName Microsoft.DesktopVirtualization/appattachpackages
```

This command updates an Azure Virtual Desktop App Attach Package in a resource group using the output of the Import-AzWvdAppAttachPackageInfo command