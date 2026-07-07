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

    It 'ParseMinorVersion does not throw and yields a null runtime name for a Go-like stack' {
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

            # A direct call is used so the returned object is captured in this scope.
            # If the fix regressed, ParseMinorVersion (or GetRuntimeName) would throw and fail the test.
            $runtime = ParseMinorVersion -RuntimeSettings $goSettings -RuntimeFullName 'Go 1.0' -PreferredOs 'linux' -StackIsLinux $true

            $runtime | Should -Not -BeNullOrEmpty
            [string]::IsNullOrWhiteSpace($runtime.Name) | Should -Be $true
        }
    }
}
