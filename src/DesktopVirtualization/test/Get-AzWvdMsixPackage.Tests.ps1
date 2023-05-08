$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdMsixPackage.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdMsixPackage' {
    It 'List' {
        try{
            # Create new Package 
            $enc = [system.Text.Encoding]::UTF8
            $string1 = "some image"
            $data1 = $enc.GetBytes($string1) 
    
            $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
            $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })

            $hostPool = New-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool `
                -Location $env.Location `
                -HostPoolType 'Shared' `
                -LoadBalancerType 'DepthFirst' `
                -RegistrationTokenOperation 'Update' `
                -ExpirationTime $((get-date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                -Description 'des' `
                -FriendlyName 'fri' `
                -MaxSessionLimit 5 `
                -VMTemplate $null `
                -CustomRdpProperty $null `
                -Ring $null `
                -ValidationEnvironment:$false `
                -PreferredAppGroupType 'Desktop'

            $package_created_1 = New-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -DisplayName 'UnitTest-MSIXPackage' `
                -ImagePath 'C:\\msix\SingleMsix.vhd' `
                -IsActive `
                -IsRegularRegistration `
                -LastUpdated '0001-01-01T00:00:00' `
                -PackageApplication $apps `
                -PackageDependency $deps `
                -PackageFamilyName 'MsixUnitTest_FamilyName' `
                -PackageName 'MsixUnitTest_Name' `
                -PackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
                -Version '0.0.18838.722' 

            $package_created_2 = New-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest2' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  `
                -DisplayName 'UnitTest-MSIXPackage2' `
                -ImagePath 'C:\\msix\SingleMsix.vhd' `
                -IsActive `
                -IsRegularRegistration `
                -LastUpdated '0001-01-01T00:00:00' `
                -PackageApplication $apps `
                -PackageDependency $deps `
                -PackageFamilyName 'MsixUnitTest_FamilyName2' `
                -PackageName 'MsixUnitTest_Name2' `
                -PackageRelativePath 'MsixUnitTest_RelativePackageRoot2' `
                -Version '0.0.18838.722' 
    
            $packages = Get-AzWvdMsixPackage -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  
    
            $packages[0].PackageFamilyName | Should -Be  'MsixUnitTest_FamilyName'
            $packages[0].ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
            ($packages[0].PackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
            ($packages[0].PackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
            $packages[0].PackageName | Should -Be 'MsixUnitTest_Name'
            $packages[0].PackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'

            $packages[1].PackageFamilyName | Should -Be  'MsixUnitTest_FamilyName2'
            $packages[1].ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
            ($packages[1].PackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
            ($packages[1].PackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
            $packages[1].PackageName | Should -Be 'MsixUnitTest_Name2'
            $packages[1].PackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot2'
        }
        finally{
            $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 

            $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest2' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 
        }
    }

    It 'Get' {
        try{
            # Create new Package 
            $enc = [system.Text.Encoding]::UTF8
            $string1 = "some image"
            $data1 = $enc.GetBytes($string1) 

            $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
            $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

            $package_created = New-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId `
                -DisplayName 'UnitTest-MSIXPackage' `
                -ImagePath 'C:\\msix\SingleMsix.vhd' `
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
            $package.ImagePath | Should -Be 'C:\\msix\SingleMsix.vhd'
            ($package.PackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
            ($package.PackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
            $package.PackageName | Should -Be 'MsixUnitTest_Name'
            $package.PackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'
        }
        finally{
            $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool  
        }
    }
}
