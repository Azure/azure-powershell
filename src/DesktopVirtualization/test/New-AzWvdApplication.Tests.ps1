$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdApplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzWvdApplication' {
    It 'Create' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath $env.HostPoolArmPath `
                            -ApplicationGroupType 'RemoteApp'
        
        $application = New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint' `
                            -FilePath 'C:\windows\system32\mspaint.exe' `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -IconIndex 0 `
                            -IconPath 'C:\windows\system32\mspaint.exe' `
                            -CommandLineSetting 'Allow' `
                            -ShowInPortal:$true
            $application.Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $application.FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.FriendlyName | Should -Be 'fri'
            $application.Description | Should -Be 'des'
            $application.IconIndex | Should -Be 0
            $application.IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.CommandLineSetting | Should -Be 'Allow'
            $application.ShowInPortal | Should -Be $true

        $application = Get-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint'
            $application.Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $application.FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.FriendlyName | Should -Be 'fri'
            $application.Description | Should -Be 'des'
            $application.IconIndex | Should -Be 0
            $application.IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.CommandLineSetting | Should -Be 'Allow'
            $application.ShowInPortal | Should -Be $true

        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }

    It 'AppAlias' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath $env.HostPoolArmPath `
                            -ApplicationGroupType 'RemoteApp'
        
        New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint1' `
                            -AppAlias 'paint' `
                            -CommandLineSetting 'Allow'

        $application = Get-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint1'
            $application.Name | Should -Be 'ApplicationGroupPowershell1/Paint1'
            $application.FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.IconIndex | Should -Be 0
            $application.IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $application.CommandLineSetting | Should -Be 'Allow'
            $application.ShowInPortal | Should -Be $false

        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint1'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }
    It 'Create_MsixApplication_RAG' {
        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

        $package = New-AzWvdMsixPackage -FullName MsixTest_FullName_UnitTest `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -DisplayName 'UnitTest-MSIXPackage' -ImagePath 'C:\msix\SingleMsix.vhd' `
            -IsActive `
            -IsRegularRegistration `
            -LastUpdated '0001-01-01T00:00:00' `
            -PackageApplication $apps `
            -PackageDependency $deps `
            -PackageFamilyName 'MsixUnitTest_FamilyName' `
            -PackageName 'MsixUnitTest_Name' `
            -PackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
            -Version '0.0.18838.722' 

        # create MSIX App 

        $application = New-AzWvdApplication -GroupName $env.RemoteApplicationGroup `
            -Name 'UnitTest-MSIX-Application' `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -ApplicationType 1 `
            -MsixPackageApplicationId 'MsixTest_Application_Id' `
            -MsixPackageFamilyName 'MsixUnitTest_FamilyName'`
            -Description 'Unit Test MSIX Application' `
            -FriendlyName 'friendlyname'`
            -IconIndex 0  `
            -IconPath 'c:\unittest_img.png' `
            -CommandLineSetting 0

        $application = Get-AzWvdApplication -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -GroupName $env.RemoteApplicationGroup `
            -Name 'UnitTest-MSIX-Application'

        $application.Name | Should -Be 'datr-hp2-RAG/UnitTest-MSIX-Application'
        $application.FriendlyName | Should -Be 'friendlyname'
        $application.Description | Should -Be 'Unit Test MSIX Application'
        $application.IconIndex | Should -Be 0
        $application.IconPath | Should -Be 'c:\unittest_img.png'
        $application.ShowInPortal | Should -Be $true

        $application = Remove-AzWvdApplication -GroupName $env.RemoteApplicationGroup `
            -Name 'UnitTest-MSIX-Application' `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 

        $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 

    }

    It 'Create_MsixApplication_DAG' {
        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

        $package = New-AzWvdMsixPackage -FullName MsixTest_FullName_UnitTest `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -DisplayName 'UnitTest-MSIXPackage' -ImagePath 'C:\msix\SingleMsix.vhd' `
            -IsActive `
            -IsRegularRegistration `
            -LastUpdated '0001-01-01T00:00:00' `
            -PackageApplication $apps `
            -PackageDependency $deps `
            -PackageFamilyName 'MsixUnitTest_FamilyName' `
            -PackageName 'MsixUnitTest_Name' `
            -PackageRelativePath 'MsixUnitTest_RelativePackageRoot' `
            -Version '0.0.18838.722' 

        # create MSIX App 

        $application = New-AzWvdApplication -GroupName $env.DesktopApplicationGroup `
            -Name UnitTest-MSIX-Application `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -ApplicationType 1 `
            -MsixPackageFamilyName 'MsixUnitTest_FamilyName'`
            -Description 'Unit Test MSIX Application' `
            -FriendlyName 'friendlyname'`
            -IconIndex 0  `
            -CommandLineSetting 0

        $application = Get-AzWvdApplication -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -GroupName $env.DesktopApplicationGroup `
            -Name UnitTest-MSIX-Application

        $application.Name | Should -Be 'datr-hp2-DAG/UnitTest-MSIX-Application'
        $application.FriendlyName | Should -Be 'friendlyname'
        $application.Description | Should -Be 'Unit Test MSIX Application'
        $application.IconIndex | Should -Be 0
        $application.MsixPackageFamilyName | Should -Be 'MsixUnitTest_FamilyName'
        $application.ShowInPortal | Should -Be $false

        $application = Remove-AzWvdApplication -GroupName $env.DesktopApplicationGroup `
            -Name UnitTest-MSIX-Application `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 

        $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName $env.HostPool `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId 
    }
}


