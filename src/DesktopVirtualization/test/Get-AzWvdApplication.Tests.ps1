$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdApplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzWvdApplication' {
    It 'Get' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
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

    It 'List' {
        $applicationGroup = New-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1' `
                            -Location $env.Location `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -HostPoolArmPath '/subscriptions/292d7caa-a878-4de8-b774-689097666272/resourcegroups/datr-canadaeast/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolPowershell1' `
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

        $application = New-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint2' `
                            -FilePath 'C:\windows\system32\mspaint.exe' `
                            -FriendlyName 'fri' `
                            -Description 'des' `
                            -IconIndex 0 `
                            -IconPath 'C:\windows\system32\mspaint.exe' `
                            -CommandLineSetting 'Allow' `
                            -ShowInPortal:$true

        $applications = Get-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1'
            $applications[0].Name | Should -Be 'ApplicationGroupPowershell1/Paint'
            $applications[0].FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[0].FriendlyName | Should -Be 'fri'
            $applications[0].Description | Should -Be 'des'
            $applications[0].IconIndex | Should -Be 0
            $applications[0].IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[0].CommandLineSetting | Should -Be 'Allow'
            $applications[0].ShowInPortal | Should -Be $true

            $applications[1].Name | Should -Be 'ApplicationGroupPowershell1/Paint2'
            $applications[1].FilePath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[1].FriendlyName | Should -Be 'fri'
            $applications[1].Description | Should -Be 'des'
            $applications[1].IconIndex | Should -Be 0
            $applications[1].IconPath | Should -Be 'C:\windows\system32\mspaint.exe'
            $applications[1].CommandLineSetting | Should -Be 'Allow'
            $applications[1].ShowInPortal | Should -Be $true

        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint'
        
        $application = Remove-AzWvdApplication -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -GroupName 'ApplicationGroupPowershell1' `
                            -Name 'Paint2'

        $applicationGroup = Remove-AzWvdApplicationGroup -SubscriptionId $env.SubscriptionId `
                            -ResourceGroupName $env.ResourceGroup `
                            -Name 'ApplicationGroupPowershell1'
    }

It 'GetMsixApplication_RAG' {

        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

        $package = New-AzWvdMsixPackage -FullName MsixTest_FullName_UnitTest `
            -HostPoolName shhirji-ps-test `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -DisplayName 'UnitTest-MSIXPackage' -ImagePath 'C:\\MsixUnitTest.vhd' `
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

        $application = New-AzWvdApplication -GroupName 'ps-test-RAG' `
            -Name 'UnitTest-MSIX-Application' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -ApplicationType 1 `
            -MsixPackageApplicationId 'MsixTest_Application_Id' `
            -MsixPackageFamilyName 'MsixUnitTest_FamilyName'`
            -Description 'Unit Test MSIX Application' `
            -FriendlyName 'friendlyname'`
            -IconIndex 0  `
            -IconPath 'c:\unittest_img.png' `
            -CommandLineSetting 0

        $application = Get-AzWvdApplication -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -GroupName 'ps-test-RAG' `
            -Name 'UnitTest-MSIX-Application'

        $application.Name | Should -Be 'ps-test-RAG/UnitTest-MSIX-Application'
        $application.FriendlyName | Should -Be 'friendlyname'
        $application.Description | Should -Be 'Unit Test MSIX Application'
        $application.IconIndex | Should -Be 0
        $application.IconPath | Should -Be 'c:\unittest_img.png'
        $application.ShowInPortal | Should -Be $true

        $application = Remove-AzWvdApplication -GroupName 'ps-test-RAG' `
            -Name 'UnitTest-MSIX-Application' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

        $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName shhirji-ps-test `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

    }

    It 'GetMsixApplication_RAG_List' {

        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

        $package = New-AzWvdMsixPackage -FullName MsixTest_FullName_UnitTest `
            -HostPoolName shhirji-ps-test `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -DisplayName 'UnitTest-MSIXPackage' -ImagePath 'C:\\MsixUnitTest.vhd' `
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

        $application = New-AzWvdApplication -GroupName 'ps-test-RAG' `
            -Name 'UnitTest-MSIX-Application' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -ApplicationType 1 `
            -MsixPackageApplicationId 'MsixTest_Application_Id' `
            -MsixPackageFamilyName 'MsixUnitTest_FamilyName'`
            -Description 'Unit Test MSIX Application' `
            -FriendlyName 'friendlyname'`
            -IconIndex 0  `
            -IconPath 'c:\unittest_img.png' `
            -CommandLineSetting 0

        $application = Get-AzWvdApplication -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -GroupName 'ps-test-RAG' `
            -Name 'UnitTest-MSIX-Application'

        $application.Name | Should -Be 'ps-test-RAG/UnitTest-MSIX-Application'
        $application.FriendlyName | Should -Be 'friendlyname'
        $application.Description | Should -Be 'Unit Test MSIX Application'
        $application.IconIndex | Should -Be 0
        $application.IconPath | Should -Be 'c:\unittest_img.png'
        $application.ShowInPortal | Should -Be $true

        # create InBuilt Applications 

        $application = New-AzWvdApplication -GroupName 'ps-test-RAG' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId '292d7caa-a878-4de8-b774-689097666272' `
            -ApplicationType 0 `
            -Name 'Reg-App' `
            -FilePath 'C:\windows\system32\regApp.exe' `
            -FriendlyName 'fri' `
            -Description 'des' `
            -IconIndex 0 `
            -IconPath 'C:\windows\system32\regApp.png' `
            -ShowInPortal:$True `
            -CommandLineSetting 0

        $application = New-AzWvdApplication -GroupName 'ps-test-RAG' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -Name 'Paint2' `
            -FilePath 'C:\windows\system32\mspaint2.exe' `
            -FriendlyName 'fri' `
            -Description 'des' `
            -IconIndex 0 `
            -IconPath 'C:\windows\system32\mspaint2.exe' `
            -CommandLineSetting 'Allow' `
            -ShowInPortal:$true

        #Get list of applications, all applications returned 
        $applications = Get-AzWvdApplication -GroupName 'ps-test-RAG' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -Filter "applicationType eq 'MsixApplication'" 

        $applications[0].applicationType | Should -Be 'MsixApplication' #atleast one msix application is returned 

        $application = Remove-AzWvdApplication -GroupName 'ps-test-RAG' `
            -Name 'UnitTest-MSIX-Application' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

        $application = Remove-AzWvdApplication -GroupName 'ps-test-RAG' `
            -Name 'Reg-App' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

        $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName shhirji-ps-test `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

    }

    It 'GetMsixApplication_DAG' {

        $enc = [system.Text.Encoding]::UTF8
        $string1 = "some image"
        $data1 = $enc.GetBytes($string1) 

        $apps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IMsixPackageApplications]@{appId = 'MsixTest_Application_Id'; description = 'testing from ps'; appUserModelID = 'MsixTest_Application_ModelID'; friendlyName = 'some name'; iconImageName = 'Apptile'; rawIcon = $data1; rawPng = $data1 })
        $deps = @( [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20191210Preview.IMsixPackageDependencies]@{dependencyName = 'MsixTest_Dependency_Name'; publisher = 'MsixTest_Dependency_Publisher'; minVersion = '0.0.0.42' })   

        $package = New-AzWvdMsixPackage -FullName MsixTest_FullName_UnitTest `
            -HostPoolName shhirji-ps-test `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -DisplayName 'UnitTest-MSIXPackage' -ImagePath 'C:\\MsixUnitTest.vhd' `
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

        $application = New-AzWvdApplication -GroupName 'shhirji-ps-test-DAG' `
            -Name 'UnitTest-MSIX-Application-DAG' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -ApplicationType 1 `
            -MsixPackageFamilyName 'MsixUnitTest_FamilyName'`
            -Description 'Unit Test MSIX Application' `
            -FriendlyName 'friendlyname'`
            -IconIndex 0  `
            -CommandLineSetting 0

        $application = Get-AzWvdApplication -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 `
            -GroupName 'shhirji-ps-test-DAG' `
            -Name 'UnitTest-MSIX-Application-DAG'

        $application.Name | Should -Be 'shhirji-ps-test-DAG/UnitTest-MSIX-Application-DAG'
        $application.FriendlyName | Should -Be 'friendlyname'
        $application.Description | Should -Be 'Unit Test MSIX Application'
        $application.IconIndex | Should -Be 0
        $application.MsixPackageFamilyName | Should -Be 'MsixUnitTest_FamilyName'
        $application.ShowInPortal | Should -Be $False

        $application = Remove-AzWvdApplication -GroupName 'shhirji-ps-test-DAG' `
            -Name 'UnitTest-MSIX-Application-DAG' `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

        $package = Remove-AzWvdMsixPackage -FullName 'MsixTest_FullName_UnitTest' `
            -HostPoolName shhirji-ps-test `
            -ResourceGroupName ryannis-ukwest `
            -SubscriptionId 292d7caa-a878-4de8-b774-689097666272 

    }

}
