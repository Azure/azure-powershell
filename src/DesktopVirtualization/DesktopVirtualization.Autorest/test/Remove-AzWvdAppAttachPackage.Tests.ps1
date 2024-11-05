$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWvdAppAttachPackage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzWvdAppAttachPackage' {
    It 'Delete' {
        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

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
            -FailHealthCheckOnStagingFailure 'Unhealthy' `
            -ImageVersion '0.0.18838.722' 

        $packages = Get-AzWvdAppAttachPackage `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId  

        $packages.Length | Should -Be 1
        $packages[0].ImagePackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
        $packages[0].ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
        ($packages[0].ImagePackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
        ($packages[0].ImagePackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
        $packages[0].ImagePackageName | Should -Be 'MsixUnitTest_Name'
        $packages[0].ImagePackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot' 

        $package = Remove-AzWvdAppAttachPackage -Name 'TestPackage' `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 

        $packages = Get-AzWvdAppAttachPackage `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  

        $packages.Length | Should -Be 0

    }
}