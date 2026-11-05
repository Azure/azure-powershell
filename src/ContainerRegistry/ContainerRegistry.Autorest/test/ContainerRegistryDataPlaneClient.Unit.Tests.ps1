# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# These are offline SDK tests; no HTTP recording or Azure sign-in is needed.
Describe 'ContainerRegistryDataPlaneClient.Unit' {
    BeforeAll {
        if (-not (Get-Command Get-AzContainerRegistryRepository -CommandType Cmdlet -ErrorAction SilentlyContinue)) {
            $autorestModule = Get-Module Az.ContainerRegistry |
                Where-Object { Test-Path (Join-Path $_.ModuleBase 'bin') } |
                Select-Object -First 1
            if (-not $autorestModule) {
                throw 'Import the built Az.ContainerRegistry module before running these tests.'
            }
            $modulePath = Join-Path (Split-Path $autorestModule.ModuleBase -Parent) 'Az.ContainerRegistry.psd1'
            if (-not (Test-Path $modulePath)) {
                throw 'Build the SDK ContainerRegistry project as well as the AutoRest project before running these tests.'
            }
            Import-Module $modulePath -ErrorAction Stop
        }

        $script:profile = New-Object Microsoft.Azure.Commands.Common.Authentication.Models.AzureRmProfile
        $context = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureContext
        $context.Environment = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments['AzureCloud']
        $context.Account = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureAccount
        $context.Account.Id = 'containerregistry-test@example.invalid'
        $context.Account.Type = 'User'
        $context.Tenant = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureTenant
        $context.Tenant.Id = '11111111-1111-1111-1111-111111111111'
        $context.Subscription = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureSubscription
        $context.Subscription.Id = '22222222-2222-2222-2222-222222222222'
        $script:profile.DefaultContext = $context
    }

    BeforeEach {
        $script:client = New-Object Microsoft.Azure.Commands.ContainerRegistry.ContainerRegistryDataPlaneClient `
            -ArgumentList $script:profile.DefaultContext, 'ContainerRegistryInputHandlingTests'
    }

    $invalidNames = @(
        @{ Label = 'null'; RegistryName = $null }
        @{ Label = 'empty'; RegistryName = '' }
        @{ Label = 'four characters'; RegistryName = 'abcd' }
        @{ Label = '51 characters'; RegistryName = ('a' * 51) }
        @{ Label = 'leading space'; RegistryName = ' abcde' }
        @{ Label = 'trailing space'; RegistryName = 'abcde ' }
        @{ Label = 'embedded space'; RegistryName = 'abc de' }
        @{ Label = 'hyphen'; RegistryName = 'abc-de' }
        @{ Label = 'underscore'; RegistryName = 'abc_de' }
        @{ Label = 'login server'; RegistryName = 'abcde.azurecr.io' }
        @{ Label = 'URL'; RegistryName = 'https://abcde.azurecr.io' }
        @{ Label = 'path'; RegistryName = 'abcde/path' }
        @{ Label = 'port'; RegistryName = 'abcde:443' }
        @{ Label = 'trailing newline'; RegistryName = "abcde`n" }
        @{ Label = 'non-ASCII letter'; RegistryName = ('abcd' + [char]0x00E9) }
        @{ Label = 'non-ASCII digit'; RegistryName = ('abcd' + [char]0x0661) }
        @{ Label = 'PowerShell expression'; RegistryName = 'abcde; throw "Registry name evaluated"' }
    )

    It 'Rejects <Label> in inherited data-plane parameters' -TestCases $invalidNames {
        param($Label, $RegistryName)

        {
            Get-AzContainerRegistryRepository -RegistryName $RegistryName `
                -DefaultProfile $script:profile -ErrorAction Stop
        } | Should -Throw -ErrorId 'ParameterArgumentValidationError,Microsoft.Azure.Commands.ContainerRegistry.GetAzureContainerRegistryRepository'
    }

    It 'Rejects <Label> when parameter binding is bypassed' -TestCases $invalidNames {
        param($Label, $RegistryName)

        $script:client.SetEndPoint('validregistry')
        $originalEndpoint = $script:client.GetEndPoint()
        $originalLoginUri = $script:client.GetClient().LoginUri
        $caught = $null
        try {
            $script:client.SetEndPoint($RegistryName)
        } catch {
            $caught = $_
        }

        $caught | Should -Not -BeNullOrEmpty
        $caught.Exception.InnerException |
            Should -BeOfType Microsoft.Azure.Commands.Common.Exceptions.AzPSArgumentException
        $caught.Exception.InnerException.ParamName | Should -BeExactly 'RegistryName'
        $script:client.GetEndPoint() | Should -BeExactly $originalEndpoint
        $script:client.GetClient().LoginUri | Should -BeExactly $originalLoginUri
    }

    It 'Normalizes registry names independently of the current culture' {
        $originalCulture = [System.Threading.Thread]::CurrentThread.CurrentCulture
        try {
            [System.Threading.Thread]::CurrentThread.CurrentCulture = [System.Globalization.CultureInfo]::GetCultureInfo('tr-TR')
            $script:client.SetEndPoint('IMAGE123')

            $script:client.GetEndPoint() | Should -BeExactly 'image123.azurecr.io'
            $script:client.GetClient().LoginUri | Should -BeExactly 'https://image123.azurecr.io'
        } finally {
            [System.Threading.Thread]::CurrentThread.CurrentCulture = $originalCulture
        }
    }
}
