$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdMSIXPackage.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzWvdMsixPackage' {
    It 'Create' {
        # Create new Package 
        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   
        
        $package_created = New-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId  `
            -DisplayName 'UnitTest-MSIXPackage' `
            -ImagePath 'C:\msix\singlemsix.vhd' `
            -IsActive `
            -IsRegularRegistration `
            -LastUpdated '0001-01-01T00:00:00' `
            -PackageApplication $apps `
            -PackageDependency $deps `
            -PackageFamilyName 'MsixUnitTest_FamilyName' `
            -PackageName 'MsixUnitTest_Name' `
            -PackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
            -Version '0.0.18838.722' 

        $package_created.PackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
        $package_created.DisplayName | Should -Be 'UnitTest-MSIXPackage'
        $package_created.ImagePath | Should -Be 'C:\msix\SingleMsix.vhd'
        ($package_created.PackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
        ($package_created.PackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
        $package_created.PackageName | Should -Be 'MsixUnitTest_Name'
        $package_created.PackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'

        $package_created = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 
    }

    It 'PackageAlias' {

        $removePackage_IfExists = Remove-AzWvdMsixPackage -FullName 'MsixPackage_1.0.0.0_neutral__zf7zaz2wb1ayy' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 

        #image exists on specified hostpool
        $package_created = New-AzWvdMsixPackage -PackageAlias 'msixpackage' `
            -ImagePath 'C:\msix\singlemsix.vhd' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId  `
            -DisplayName 'package-Alias-test' `
            -IsActive 

        $package_created = Get-AzWvdMsixPackage -FullName 'MsixPackage_1.0.0.0_neutral__zf7zaz2wb1ayy' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId  

        $package_created.PackageFamilyName | Should -Be  'MsixPackage_zf7zaz2wb1ayy'
        $package_created.DisplayName | Should -Be 'package-Alias-test'
        $package_created.ImagePath | Should -Be 'C:\msix\singlemsix.vhd'
        $package_created.PackageName | Should -Be 'MsixPackage'
        $package_created.PackageRelativePath | Should -Be '\apps\MsixPackage_1.0.0.0_neutral__zf7zaz2wb1ayy'
        $package_created.IsActive | Should -Be $True
        
        $package_created = Remove-AzWvdMsixPackage -FullName 'MsixPackage_1.0.0.0_neutral__zf7zaz2wb1ayy' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 

    }
}
