$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdMsixPackage.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzWvdMsixPackage' {
    It 'Update' {
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
 
        $package = Get-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId  
 
        $package.PackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
        $package.DisplayName | Should -Be 'UnitTest-MSIXPackage'
        $package.ImagePath | Should -Be 'C:\msix\singlemsix.vhd'
        ($package.PackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
        ($package.PackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
        $package.PackageName | Should -Be 'MsixUnitTest_Name'
        $package.PackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'
 
        #update 

        $package = Update-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId  `
            -displayName 'Updated-display-Name' `
            -IsRegularRegistration:$false

        $package = Get-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 
        
        $package.DisplayName | Should -Be 'Updated-display-Name'
        $package.IsRegularRegistration | Should -Be $False     

        $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 
    }
}
