$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdAppAttachPackage.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdAppAttachPackage' {
    It 'UpdateExpanded' {
        try {
            $enc = [system.Text.Encoding]::UTF8
            $string1 = "some image"
            $data1 = $enc.GetBytes($string1) 

            $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
            $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

            $hostpool = Get-AzWvdHostPool -ResourceGroupName $env.ResourceGroup `
                -HostPoolName $env.HostPoolPersistent2 `
                -SubscriptionId $env.SubscriptionId `

            $package_created_1 = New-AzWvdAppAttachPackage -Name "TestPackage" `
                -ImagePackageFullName 'AATest_FullName_UnitTest' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ImageDisplayName 'UnitTest-MSIXPackage' `
                -ImagePath 'C:\\msix\SingleMsix.vhd' `
                -ImageIsActive `
                -ImageIsRegularRegistration `
                -ImageLastUpdated '0001-01-01T00:00:00' `
                -ImagePackageApplication $apps `
                -ImagePackageDependency $deps `
                -ImagePackageFamilyName 'MsixUnitTest_FamilyName' `
                -ImagePackageName 'MsixUnitTest_Name' `
                -ImagePackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
                -FailHealthCheckOnStagingFailure Unhealthy `
                -HostPoolReference $hostpool.Id `
                -ImageCertificateExpiry '0001-01-21T00:00:00' `
                -ImageCertificateName 'UnitTestCertificate' `
                -KeyVaultUrl 'keyvault' `
                -ImageVersion '0.0.18838.722' 

            $package = Get-AzWvdAppAttachPackage -Name "TestPackage"`
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

            $package.ImagePackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
            $package.ImagePackageFullName | Should -Be 'AATest_FullName_UnitTest'
            $package.ImageDisplayName | Should -Be 'UnitTest-MSIXPackage'
            $package.ImageIsActive | Should -Be $True
            $package.ImageIsRegularRegistration | Should -Be $True
            $package.ImageLastUpdated | Should -Be '01/01/0001 00:00:00'
            $package.ImageCertificateExpiry | Should -Be '01/21/0001 00:00:00'
            $package.ImageCertificateName | Should -Be 'UnitTestCertificate'
            $package.ImagePackageFamilyName | Should -Be 'MsixUnitTest_FamilyName'
            $package.ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
            $package.ImagePackageName | Should -Be 'MsixUnitTest_Name'
            $package.ImagePackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'
            ($package.ImagePackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
            ($package.ImagePackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
            $package.ImageVersion | Should -Be '0.0.18838.722'
            $package.FailHealthCheckOnStagingFailure | Should -Be 'Unhealthy'
            $package.HostPoolReference | Should -Be $hostpool.Id
            $package.KeyVaultUrl | Should -Be 'keyvault'

            $apps2 = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id2'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
            $deps2 = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name2'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

            Update-AzWvdAppAttachPackage -Name "TestPackage" `
                -ImagePackageFullName 'AATest_FullName_UnitTest2' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -ImageDisplayName 'UnitTest-MSIXPackage2' `
                -ImagePath 'C:\\msix\SingleMsix2.vhd' `
                -ImageIsActive:$false `
                -ImageIsRegularRegistration:$false `
                -ImageLastUpdated '0001-01-01T00:00:01' `
                -ImagePackageApplication $apps2 `
                -ImagePackageDependency $deps2 `
                -ImagePackageFamilyName 'MsixUnitTest_FamilyName2' `
                -ImagePackageName 'MsixUnitTest_Name2' `
                -ImagePackageRelativePath 'MsixUnitTest_RelativePackageRoot2' `
                -FailHealthCheckOnStagingFailure NeedsAssistance `
                -HostPoolReference @() `
                -ImageCertificateExpiry '0001-01-21T00:00:01' `
                -ImageCertificateName 'UnitTestCertificate2' `
                -KeyVaultUrl 'keyvault2' `
                -ImageVersion '0.0.18838.723' 

            $package = Get-AzWvdAppAttachPackage -Name "TestPackage"`
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

                $package.ImagePackageFamilyName | Should -Be  'MsixUnitTest_FamilyName2'
                $package.ImagePackageFullName | Should -Be 'AATest_FullName_UnitTest2'
                $package.ImageDisplayName | Should -Be 'UnitTest-MSIXPackage2'
                $package.ImageIsActive | Should -Be $False
                $package.ImageIsRegularRegistration | Should -Be $False
                $package.ImageLastUpdated | Should -Be '01/01/0001 00:00:01'
                $package.ImageCertificateExpiry | Should -Be '01/21/0001 00:00:01'
                $package.ImageCertificateName | Should -Be 'UnitTestCertificate2'
                $package.ImagePackageFamilyName | Should -Be 'MsixUnitTest_FamilyName2'
                $package.ImagePath | Should -Be 'C:\\msix\SingleMsix2.vhd'
                $package.ImagePackageName | Should -Be 'MsixUnitTest_Name2'
                $package.ImagePackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot2'
                ($package.ImagePackageApplication | ConvertTo-Json) | Should -Be ($apps2 | ConvertTo-Json)
                ($package.ImagePackageDependency | ConvertTo-Json) | Should -Be ($deps2 | ConvertTo-Json)
                $package.ImageVersion | Should -Be '0.0.18838.723'
                $package.FailHealthCheckOnStagingFailure | Should -Be 'NeedsAssistance'
                $package.HostPoolReference | Should -Be @()
                $package.KeyVaultUrl | Should -Be 'keyvault2'
        } 
        finally {
            $package = Remove-AzWvdAppAttachPackage -Name 'TestPackage' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 
        }
    }

    It 'ImageObject' {
        try {
            $enc = [system.Text.Encoding]::UTF8
            $string1 = "some image"
            $data1 = $enc.GetBytes($string1) 

            $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
            $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

            $package_created_1 = New-AzWvdAppAttachPackage -Name "TestPackage" `
                -ImagePackageFullName 'AATest_FullName_UnitTest' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ImageDisplayName 'UnitTest-MSIXPackage' `
                -ImagePath 'C:\\msix\SingleMsix.vhd' `
                -ImageIsActive `
                -ImageIsRegularRegistration `
                -ImageLastUpdated '0001-01-01T00:00:00' `
                -ImagePackageApplication $apps `
                -ImagePackageDependency $deps `
                -ImagePackageFamilyName 'MsixUnitTest_FamilyName' `
                -ImagePackageName 'MsixUnitTest_Name' `
                -ImagePackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
                -ImageVersion '0.0.18838.722' 


            $packages = Get-AzWvdAppAttachPackage -Name "TestPackage"`
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

            $packages[0].ImagePackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
            $packages[0].ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
            $packages[0].ImagePackageName | Should -Be 'MsixUnitTest_Name'
            $packages[0].ImagePackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'
            ($packages[0].ImagePackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
        
            $image = Import-AzWvdAppAttachPackageInfo -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId `
                -Path $env.MSIXImagePath

            $image.ImagePackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $image.ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $image.ImagePackageName | Should -Be 'Mozilla.MozillaFirefox'
            $image.ImagePackageAlias | Should -Be 'mozillamozillafirefox'
            $image.ImageIsActive | Should -Be $False
            $image.ImageIsRegularRegistration | Should -Be $False
            $image.ImagePackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'

            Update-AzWvdAppAttachPackage -Name "TestPackage" `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -AppAttachPackage $image
                

            $packages = Get-AzWvdAppAttachPackage -Name "TestPackage"`
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

            $packages[0].ImagePackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $packages[0].ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $packages[0].ImagePackageName | Should -Be 'Mozilla.MozillaFirefox'
            $packages[0].ImagePackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'
            ($packages[0].ImagePackageApplication | ConvertTo-Json) | Should -Be ($image.ImagePackageApplication | ConvertTo-Json)
        }
        finally {
            Remove-AzWvdAppAttachPackage -Name 'TestPackage' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 
        }
    }

    It 'ImageObjectByPipeline' {
        try {
            $enc = [system.Text.Encoding]::UTF8
            $string1 = "some image"
            $data1 = $enc.GetBytes($string1) 

            $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
            $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

            $package_created_1 = New-AzWvdAppAttachPackage -Name "TestPackage" `
                -ImagePackageFullName 'AATest_FullName_UnitTest' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -Location $env.Location `
                -ImageDisplayName 'UnitTest-MSIXPackage' `
                -ImagePath 'C:\\msix\SingleMsix.vhd' `
                -ImageIsActive `
                -ImageIsRegularRegistration `
                -ImageLastUpdated '0001-01-01T00:00:00' `
                -ImagePackageApplication $apps `
                -ImagePackageDependency $deps `
                -ImagePackageFamilyName 'MsixUnitTest_FamilyName' `
                -ImagePackageName 'MsixUnitTest_Name' `
                -ImagePackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
                -ImageVersion '0.0.18838.722' 


            $packages = Get-AzWvdAppAttachPackage -Name "TestPackage"`
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

            $packages[0].ImagePackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
            $packages[0].ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
            $packages[0].ImagePackageName | Should -Be 'MsixUnitTest_Name'
            $packages[0].ImagePackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'
            ($packages[0].ImagePackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
            
            $image = Import-AzWvdAppAttachPackageInfo -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId `
                -Path $env.MSIXImagePath

            $image.ImagePackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $image.ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $image.ImagePackageName | Should -Be 'Mozilla.MozillaFirefox'
            $image.ImagePackageAlias | Should -Be 'mozillamozillafirefox'
            $image.ImageIsActive | Should -Be $False
            $image.ImageIsRegularRegistration | Should -Be $False
            $image.ImagePackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'

            $image | Update-AzWvdAppAttachPackage -Name "TestPackage" `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 

            $packages = Get-AzWvdAppAttachPackage -Name "TestPackage"`
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

            $packages[0].ImagePackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $packages[0].ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $packages[0].ImagePackageName | Should -Be 'Mozilla.MozillaFirefox'
            $packages[0].ImagePackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'
            ($packages[0].ImagePackageApplication | ConvertTo-Json) | Should -Be ($image.ImagePackageApplication | ConvertTo-Json)
        }
        finally {
            Remove-AzWvdAppAttachPackage -Name 'TestPackage' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 
        }
    }
}