param(
  [Parameter()]
  [string] $Repository = "PSGallery"
)

$helper = Join-Path $PSScriptRoot 'Az.Tools.Installer.Tests.Helper'
. ($helper)

Describe 'Update-AzModule' {
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
    }

    It 'UpdateByName' {
        $output = Update-AzModule -Name storage,neTwork -Repository PSGallery -Scope 'CurrentUser'
        $output.Count | Should -Be 3
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 6
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Attestation'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Resources'
        $modules.Name | Should -Contain 'Az.Network'  
        $modules.Name | Should -Contain 'Az.Storage'         
    }

    It 'UpdateAllKeepPrevious' {
        $output = Update-AzModule -KeepPrevious -Repository PSGallery
        $output.Count | Should -Be 6
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 13
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Attestation'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Resources'
        $modules.Name | Should -Contain 'Az.Network'  
        $modules.Name | Should -Contain 'Az.Storage'              
    }

    It 'UpdateAllReplacePrevious' {
        $output = Update-AzModule -Repository PSGallery
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 6
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Attestation'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Resources'
        $modules.Name | Should -Contain 'Az.Network'  
        $modules.Name | Should -Contain 'Az.Storage'  
        
        foreach($module in $output) {
            (Find-Module -Name $module.Name -Repository PSGallery).Version | Should -Be $module.VersionUpdate
        }
    }

    It 'UpdateByUnexistingName' {
        $output = Update-AzModule -Name storage,fakemodule -Repository PSGallery -Scope 'CurrentUser'
        $output.Count | Should -Be 2
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 6
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Attestation'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.Resources'
        $modules.Name | Should -Contain 'Az.Network'  
        $modules.Name | Should -Contain 'Az.Storage'
    }

    It 'UpdateWithoutAzAccounts' {
        $output = Update-AzModule -Name storage -Repository PSGallery -Scope 'CurrentUser'
        $output.Count | Should -Be 2
        $output = [Array] (Update-AzModule -Name compute -Repository PSGallery -Scope 'CurrentUser')
        $output.Count | Should -Be 1
    }

    AfterEach {
        Remove-AllAzModule       
    }
}

