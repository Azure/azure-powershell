param(
  [Parameter()]
  [string] $Repository = "PSGallery"
)

$helper = Join-Path $PSScriptRoot 'Az.Tools.Installer.Tests.Helper'
. $helper

Describe 'Uninstall-AzModule' {
    BeforeAll {
        Get-PSRepository $Repository | Should -Not -Be $null
    }

    BeforeEach {
        Remove-AllAzModule
        Install-Module -Name Az.Accounts -RequiredVersion 2.5.2 -Repository PSGallery
        Install-Module -Name Az.Attestation -RequiredVersion 0.1.8 -Repository PSGallery
        Install-Module -Name Az.Compute  -RequiredVersion 4.16.0 -Repository PSGallery
        Install-Module -Name Az.Resources  -RequiredVersion 4.3.0 -Repository PSGallery
        Install-Module -Name Az.Network  -RequiredVersion 4.3.0 -Repository PSGallery
        Install-Module -Name Az.Storage -RequiredVersion 3.10.0 -Repository PSGallery
        Install-Module -Name Az.Storage -RequiredVersion 3.10.1-preview -Repository PSGallery -AllowPrerelease
        Install-Module -Name Az.Storage -RequiredVersion 3.12.1-preview -Repository PSGallery -AllowPrerelease
    }

    It 'UninstallByName' {
        Uninstall-AzModule -Name storage, reSources
        $modules = Get-Module -ListAvailable -Name Az.*
        $modules.Count | Should -Be 5
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Attestation'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Network'
    }

    It 'UninstallByExclude' {
        Uninstall-AzModule -ExcludeModule accounts,storage
        $modules = Get-Module -ListAvailable -Name Az.*
        $modules.Count | Should -Be 5
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Storage'              
    }

    It 'UninstallPrereleaseOnly' {
        Uninstall-AzModule -PrereleaseOnly
        $modules = Get-Module -ListAvailable -Name Az.*
        $modules.Count | Should -Be 6
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Network'
        $modules.Name | Should -Contain 'Az.Resources'
        $modules.Name | Should -Contain 'Az.Storage'
    }

    It 'UninstallByExcludePrereleaseCombined' {
        Uninstall-AzModule -PrereleaseOnly -ExcludeModule attestation
        $modules = Get-Module -ListAvailable -Name Az.*
        $modules.Count | Should -Be 7
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Attestation'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Network'
        $modules.Name | Should -Contain 'Az.Resources'
        $modules.Name | Should -Contain 'Az.Storage'
    }

    It 'UninstallAll' {
        Uninstall-AzModule
        $modules = Get-Module -ListAvailable -Name Az.* -Debug
        $modules | Should -Be $null 
    }

    It 'UninstallAzureRm' {
        Install-Module -Name AzureRm -Repository PSGallery -AllowClobber
        Uninstall-AzModule -RemoveAzureRm
        $modules = Get-Module -ListAvailable -Name Az.* -Debug
        $modules | Should -Be $null
        (Get-InstalledModule -Name Azure* -ErrorAction Stop).Name | Should -Be $null
    }

    It 'UninstallByUnexistingName' {
        Uninstall-AzModule -Name fakeModule
        $modules = Get-Module -ListAvailable -Name Az.*
        $modules.Count | Should -Be 9
        #should check output
    }

    It 'UninstallByExcludingUnexistingName' {
        {Uninstall-AzModule -ExcludeModule fakeModule} | Should -Throw
        $modules = Get-Module -ListAvailable -Name Az.*
        $modules.Count | Should -Be 9
        #should check output
    }

    AfterEach {
        Remove-AllAzModule       
    }
}

