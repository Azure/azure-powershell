# Regression coverage for https://github.com/Azure/azure-powershell/issues/29630: the Function App
# stacks API can return a runtime stack (for example, Go on Flex Consumption) whose appSettingsDictionary
# does not contain a FUNCTIONS_WORKER_RUNTIME app setting, which previously caused every Az.Functions
# cmdlet to throw while building the runtime tab completers.
if(($null -eq $TestName) -or ($TestName -contains 'SetLinuxandWindowsSupportedRuntimes'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
}

Describe 'SetLinuxandWindowsSupportedRuntimes' {

    It 'GetRuntimeName returns null when FUNCTIONS_WORKER_RUNTIME is absent' {
        InModuleScope Az.Functions {
            # A Go-style stack ships an empty appSettingsDictionary (no FUNCTIONS_WORKER_RUNTIME).
            $emptyAppSettings = [PSCustomObject]@{}

            $result = GetRuntimeName -AppSettingsDictionary $emptyAppSettings

            $result | Should -BeNullOrEmpty
        }
    }

    It 'GetRuntimeName still maps a known runtime that has FUNCTIONS_WORKER_RUNTIME' {
        InModuleScope Az.Functions {
            $nodeAppSettings = [PSCustomObject]@{ FUNCTIONS_WORKER_RUNTIME = 'node' }

            $result = GetRuntimeName -AppSettingsDictionary $nodeAppSettings

            $result | Should -Be 'Node'
        }
    }

    It 'ParseMinorVersion does not throw and yields a null runtime name for a stack with no mappable name' {
        InModuleScope Az.Functions {
            $goSettings = [PSCustomObject]@{
                runtimeVersion                      = 'Go|1.0'
                isPreview                           = $true
                isHidden                            = $false
                appSettingsDictionary               = [PSCustomObject]@{}
                siteConfigPropertiesDictionary      = [PSCustomObject]@{ use32BitWorkerProcess = $false; linuxFxVersion = 'Go|1.0' }
                appInsightsSettings                 = [PSCustomObject]@{ isSupported = $true }
                supportedFunctionsExtensionVersions = @('~4')
            }

            # This stack exposes neither a FUNCTIONS_WORKER_RUNTIME app setting nor a Flex
            # functionAppConfigProperties runtime name, so it cannot be mapped. The parser
            # must not throw and must yield a null runtime name so callers can skip it.
            $runtime = ParseMinorVersion -RuntimeSettings $goSettings -RuntimeFullName 'Go 1.0' -PreferredOs 'linux' -StackIsLinux $true

            $runtime | Should -Not -BeNullOrEmpty
            [string]::IsNullOrWhiteSpace($runtime.Name) | Should -Be $true
        }
    }

    It 'ParseMinorVersion resolves the Go runtime from functionAppConfigProperties when FUNCTIONS_WORKER_RUNTIME is absent' {
        InModuleScope Az.Functions {
            # A real Go on Flex Consumption stack ships an empty appSettingsDictionary but
            # carries the runtime identity under Sku[].functionAppConfigProperties.runtime.
            $goSettings = [PSCustomObject]@{
                runtimeVersion                      = 'Go|1.0'
                isPreview                           = $true
                isHidden                            = $false
                appSettingsDictionary               = [PSCustomObject]@{}
                siteConfigPropertiesDictionary      = [PSCustomObject]@{ use32BitWorkerProcess = $false; linuxFxVersion = 'Go|1.0' }
                appInsightsSettings                 = [PSCustomObject]@{ isSupported = $true }
                supportedFunctionsExtensionVersions = @('~4')
                Sku                                 = @(
                    [PSCustomObject]@{
                        skuCode                     = 'FC1'
                        functionAppConfigProperties = [PSCustomObject]@{
                            runtime = [PSCustomObject]@{ name = 'go'; version = '1.0' }
                        }
                    }
                )
            }

            $runtime = ParseMinorVersion -RuntimeSettings $goSettings -RuntimeFullName 'Go 1.0' -PreferredOs 'linux' -StackIsLinux $true

            $runtime | Should -Not -BeNullOrEmpty
            $runtime.Name | Should -Be 'Go'
            $runtime.Version | Should -Be '1.0'
        }
    }
}
