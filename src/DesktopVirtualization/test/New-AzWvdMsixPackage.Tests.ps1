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

            $package_created = New-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId  `
                -DisplayName 'UnitTest-MSIXPackage' `
                -ImagePath 'C:\msix\putty.vhdx' `
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
            $package_created.ImagePath | Should -Be 'C:\msix\putty.vhdx'
            ($package_created.PackageApplication | ConvertTo-Json) | Should -Be ($apps | ConvertTo-Json)
            ($package_created.PackageDependency | ConvertTo-Json) | Should -Be ($deps | ConvertTo-Json)
            $package_created.PackageName | Should -Be 'MsixUnitTest_Name'
            $package_created.PackageRelativePath | Should -Be 'MsixUnitTest_RelativePackageRoot'
        }
        finally{
            $package_created = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
                -HostPoolName $env.HostPool `
                -ResourceGroupName $env.ResourceGroup `
                -SubscriptionId $env.SubscriptionId 

            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -Name $env.HostPool
        }
    }

    It 'PackageAlias' {
        try{
            $removePackage_IfExists = Remove-AzWvdMsixPackage -FullName 'Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608' `
                -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId 

            #image exists on specified hostpool
            $package_created = New-AzWvdMsixPackage -PackageAlias 'mozillamozillafirefox' `
                -ImagePath 'C:\AppAttach\Firefox20110.0.1.vhdx' `
                -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId  `
                -DisplayName 'package-Alias-test' `
                -IsActive 

            $package_created = Get-AzWvdMsixPackage -FullName 'Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608' `
                -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId  

            $package_created.PackageFamilyName | Should -Be  'Mozilla.MozillaFirefox_gmpnhwe7bv608'
            $package_created.DisplayName | Should -Be 'package-Alias-test'
            $package_created.ImagePath | Should -Be 'C:\AppAttach\Firefox20110.0.1.vhdx'
            $package_created.PackageName | Should -Be 'Mozilla.MozillaFirefox'
            $package_created.PackageRelativePath | Should -Be '\apps\Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608'
            $package_created.IsActive | Should -Be $True
        }
        finally{
            $package_created = Remove-AzWvdMsixPackage -FullName 'Mozilla.MozillaFirefox_110.0.1.0_x64__gmpnhwe7bv608' `
                -HostPoolName $env.HostPoolPersistent2 `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -SubscriptionId $env.SubscriptionId 
        }
    }
}
