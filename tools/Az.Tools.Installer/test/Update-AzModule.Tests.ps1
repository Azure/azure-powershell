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

        $allmoduleInstalled = @('Az.Accounts', 'Az.Attestation', 'Az.Compute', 'Az.Resources', 'Az.Storage', 'Az.Network')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
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

        $allmoduleInstalled = @('Az.Accounts', 'Az.Attestation', 'Az.Compute', 'Az.Resources', 'Az.Storage', 'Az.Network')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
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

        foreach ($module in $output) {
            (Find-Module -Name $module.Name -Repository PSGallery).Version | Should -Be $module.VersionUpdate
        }

        $allmoduleInstalled = @('Az.Accounts', 'Az.Attestation', 'Az.Compute', 'Az.Resources', 'Az.Storage', 'Az.Network')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
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

        $allmoduleInstalled = @('Az.Accounts', 'Az.Attestation', 'Az.Compute', 'Az.Resources', 'Az.Storage', 'Az.Network')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
    }

    It 'UpdateWithoutAzAccounts' {
        $output = Update-AzModule -Name storage -Repository PSGallery -Scope 'CurrentUser'
        $output.Count | Should -Be 2
        $output = [Array] (Update-AzModule -Name compute -Repository PSGallery -Scope 'CurrentUser')
        $output.Count | Should -Be 1

        (Get-InstalledModule -Name Az.Storage).Repository | Should -Be 'PSGallery'
    }

    It 'UpdateWithoutRepository' {
        $repos = [Array](Get-PSRepository | Where-Object {$_.Name -ne 'PSGallery'})
        if ($repos -ne $null) {
            $repos | Unregister-PSRepository
        }
        try {
            $output = Update-AzModule -Name storage -Scope 'CurrentUser'
            $output.Count | Should -Be 2
            (Get-InstalledModule -Name Az.Storage).Repository | Should -Be 'PSGallery'
        }
        finally {
            foreach ($repo in $repos) {
                if ($repo.Name -ne 'PSGallery') {
                    $parameters = @{
                        Name = $repo.Name
                        SourceLocation = $repo.SourceLocation
                        InstallationPolicy = $repo.InstallationPolicy
                    }
                    Register-PSRepository @parameters
                }
            }
        }
    }

    AfterEach {
        Remove-AllAzModule
    }
}
