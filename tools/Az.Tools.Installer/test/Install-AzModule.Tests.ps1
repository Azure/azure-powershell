param(
  [Parameter()]
  [string] $Repository = "PSGallery"
)

$helper = Join-Path $PSScriptRoot 'Az.Tools.Installer.Tests.Helper'
. $helper

$ProgressPreference = 'SilentlyContinue'

Describe 'Install-AzModule' {
    BeforeAll {
        Get-PSRepository $Repository | Should -Not -Be $null
    }

    BeforeEach {
        Remove-AllAzModule
    }

    It 'InstallByName' {
        $output = Install-AzModule -Name storage,neTwork,compute,Az.keyvault -RequiredAzVersion 6.3 -Repository PSGallery -Scope 'CurrentUser'
        $output.Count | Should -Be 5
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 5
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Storage'
        $modules.Name | Should -Contain 'Az.Network'
        $modules.Name | Should -Contain 'Az.Compute'
        $modules.Name | Should -Contain 'Az.KeyVault'

        $allmoduleInstalled = @('Az.Accounts', 'Az.Storage', 'Az.Network', 'Az.Compute', 'Az.KeyVault')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
    }

    It 'InstallByNamePrerelease' {
        $output = Install-AzModule -Name storage,neTwork,maps,Az.keyvault -Repository PSGallery -AllowPrerelease
        $output.Count | Should -Be 5
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 5
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Storage'
        $modules.Name | Should -Contain 'Az.Network'
        $modules.Name | Should -Contain 'Az.Maps'
        $modules.Name | Should -Contain 'Az.KeyVault'

        $allmoduleInstalled = @('Az.Accounts', 'Az.Storage', 'Az.Network', 'Az.Maps', 'Az.KeyVault')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'

        $output = Install-AzModule -Repository PSGallery -Name keyvault,resources,storage -RemovePrevious
        $output.Count | Should -Be 4
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 6
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Storage'
        $modules.Name | Should -Contain 'Az.Network'
        $modules.Name | Should -Contain 'Az.Maps'
        $modules.Name | Should -Contain 'Az.KeyVault'
        $modules.Name | Should -Contain 'Az.Resources'

        $allmoduleInstalled = @('Az.Accounts', 'Az.Storage', 'Az.Network', 'Az.Maps', 'Az.KeyVault', 'Az.Resources')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
    }

    It 'InstallByNameLatest' {
        $output = Install-AzModule -Name storage,maps -Repository PSGallery
        $output.Count | Should -Be 2
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 2
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Storage'

        $allmoduleInstalled = @('Az.Accounts', 'Az.Storage')
        (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
    }

    It 'InstallAllGA' {
        $output = Install-AzModule -Repository PSGallery -UseExactAccountVersion -RequiredAzVersion 6.3
        $azModule = Find-Module -Name Az -Repository PSGallery -RequiredVersion 6.3
        $output.Count | Should -Be $azModule.Dependencies.Count
        $modules = Get-AzSubModule
        $modules.Count | Should -Be $azModule.Dependencies.Count
        $expectedVersion = [Version] ($azModule.Dependencies | Where-Object {$_.Name -eq 'Az.Accounts'})['MinimumVersion']
        ($modules | Where-Object {$_.Name -eq 'Az.Accounts'}).Version | Should -Be $expectedVersion

        (Get-InstalledModule -Name 'Az.Accounts').Repository | Should -Be 'PSGallery'
    }

    It 'InstallByUnexistingName' {
        $output = [Array] (Install-AzModule -Name fakeModule -Repository PSGallery)
        $output.Count | Should -Be 0
        $modules = Get-AzSubModule
        $modules.Count | Should -Be 0
    }

    It 'InstallAndRemoveAzureRm' {
        Install-Module -Name AzureRm -Repository PSGallery
        $output = [Array] (Install-AzModule -Name accounts -Repository PSGallery -RemoveAzureRm)
        $output.Count | Should -Be 1
        (Get-AzSubModule).Name | Should -Be 'Az.Accounts'
        Get-InstalledModule -Name Azure* -ErrorAction 'Continue' | Should -Be $null

        (Get-InstalledModule -Name 'Az.Accounts').Repository | Should -Be 'PSGallery'
    }

    It 'InstallByUnexistingVersion' {
        {Install-AzModule -AllowPrerelease -Repository PSGallery -RequiredAzVersion 5.9} | Should -Throw
    }

    It 'InstallByUri' {
        $output = [Array] (Install-AzModule -Path "https://azposhpreview.blob.core.windows.net/public/Az.Accounts.2.12.3.nupkg")
        $output.Count | Should -Be 1

        $package = Join-Path $PSScriptRoot "resources"
        $package = Join-Path $package "az.storage.5.4.2-preview.nupkg"
        $output = [Array] (Install-AzModule -Path $package)
        $output.Count | Should -Be 1

        $modules = Get-AzSubModule
        $modules.Count | Should -Be 2
        $modules.Name | Should -Contain 'Az.Accounts'
        $modules.Name | Should -Contain 'Az.Storage'
    }

    It 'InstallWithoutRepository' {
        $repos = [Array](Get-PSRepository | Where-Object {$_.Name -ne 'PSGallery'})
        if ($repos -ne $null) {
            $repos | Unregister-PSRepository
        }
        try {
            $output = Install-AzModule -Name storage,neTwork -RequiredAzVersion 6.3 -Scope 'CurrentUser'
            $output.Count | Should -Be 3
            $modules = Get-AzSubModule
            $modules.Count | Should -Be 3
            $modules.Name | Should -Contain 'Az.Accounts'
            $modules.Name | Should -Contain 'Az.Storage'
            $modules.Name | Should -Contain 'Az.Network'

            $allmoduleInstalled = @('Az.Accounts', 'Az.Storage', 'Az.Network')
            (Get-InstalledModule -Name $allmoduleInstalled).Repository | Sort-Object -Unique | Should -Be 'PSGallery'
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
