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

# These are offline SDK-cmdlet tests; no HTTP recording or Azure sign-in is needed.
Describe 'Connect-AzContainerRegistry.Unit' {
    BeforeAll {
        $script:originalDocker = Get-Item Function:\docker -ErrorAction SilentlyContinue
        $script:dockerReplaced = $false

        if (-not (Get-Command Connect-AzContainerRegistry -CommandType Cmdlet -ErrorAction SilentlyContinue)) {
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
        # No subscription forces discovery fallback without making an ARM request.
        $script:profile.DefaultContext = $context
    }

    BeforeEach {
        # A function double captures the real nested PowerShell invocation without running Docker.
        function global:docker {
            [PSCustomObject]@{
                Arguments = @($args)
                Password = @($input)
            }
        }
        $script:dockerReplaced = $true
    }

    AfterAll {
        if ($script:dockerReplaced) {
            if ($script:originalDocker) {
                Set-Item Function:\global:docker -Value $script:originalDocker.ScriptBlock
            } else {
                Remove-Item Function:\global:docker -ErrorAction Stop
            }
        }
    }

    $invalidNames = @(
        @{ Label = 'null'; RegistryName = $null }
        @{ Label = 'empty'; RegistryName = '' }
        @{ Label = 'four characters'; RegistryName = 'abcd' }
        @{ Label = '51 characters'; RegistryName = ('a' * 51) }
        @{ Label = 'leading space'; RegistryName = ' abcde' }
        @{ Label = 'trailing space'; RegistryName = 'abcde ' }
        @{ Label = 'embedded space'; RegistryName = 'abc de' }
        @{ Label = 'short prefix'; RegistryName = 'abc-de' }
        @{ Label = 'four-character prefix'; RegistryName = ('abcd-' + ('a' * 16)) }
        @{ Label = '64-character label'; RegistryName = (('a' * 47) + '-' + ('b' * 16)) }
        @{ Label = 'long suffix'; RegistryName = ('abcde-' + ('a' * 58)) }
        @{ Label = 'missing suffix'; RegistryName = 'abcde-' }
        @{ Label = 'leading hyphen'; RegistryName = '-abcde' }
        @{ Label = 'double hyphen'; RegistryName = 'abcde--suffix' }
        @{ Label = 'trailing hyphen'; RegistryName = 'abcde-suffix-' }
        @{ Label = 'short legacy prefix'; RegistryName = 'abcd-microsoft' }
        @{ Label = 'long legacy prefix'; RegistryName = (('a' * 51) + '-microsoft') }
        @{ Label = 'repeated legacy suffix'; RegistryName = 'abcde-microsoft-microsoft' }
        @{ Label = 'legacy login server'; RegistryName = 'abcde-microsoft.azurecr.io' }
        @{ Label = 'legacy path'; RegistryName = 'abcde-microsoft/path' }
        @{ Label = 'legacy trailing newline'; RegistryName = "abcde-microsoft`n" }
        @{ Label = 'non-ASCII legacy suffix'; RegistryName = ('abcde-micro' + [char]0x017F + 'oft') }
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

    Context 'Registry name parameter validation' {
        It 'Rejects <Label> in Connect-AzContainerRegistry' -TestCases $invalidNames {
            param($Label, $RegistryName)

            {
                Connect-AzContainerRegistry -Name $RegistryName -UserName 'user' -Password 'password' `
                    -DefaultProfile $script:profile -ErrorAction Stop
            } | Should -Throw -ErrorId 'ParameterArgumentValidationError,Microsoft.Azure.Commands.ContainerRegistry.ConnectAzureContainerRegistry'
        }

        It 'Rejects <Label> in inherited data-plane parameters' -TestCases $invalidNames {
            param($Label, $RegistryName)

            {
                Get-AzContainerRegistryRepository -RegistryName $RegistryName `
                    -DefaultProfile $script:profile -ErrorAction Stop
            } | Should -Throw -ErrorId 'ParameterArgumentValidationError,Microsoft.Azure.Commands.ContainerRegistry.GetAzureContainerRegistryRepository'
        }

        It 'Accepts <Label> and supplies a lowercase login server' -TestCases @(
            @{ Label = 'five characters'; RegistryName = 'AbC12'; ExpectedServer = 'abc12.azurecr.io' }
            @{ Label = '50 characters'; RegistryName = ('A' * 50); ExpectedServer = (('a' * 50) + '.azurecr.io') }
            @{ Label = 'only digits'; RegistryName = '12345'; ExpectedServer = '12345.azurecr.io' }
            @{ Label = 'mixed case'; RegistryName = 'MyRegistry123'; ExpectedServer = 'myregistry123.azurecr.io' }
            @{ Label = 'DNL label'; RegistryName = 'MyRegistry-0123456789ABCDEF'; ExpectedServer = 'myregistry-0123456789abcdef.azurecr.io' }
            @{ Label = 'maximum DNL label'; RegistryName = (('A' * 46) + '-' + ('B' * 16)); ExpectedServer = (('a' * 46) + '-' + ('b' * 16) + '.azurecr.io') }
            @{ Label = 'legacy label'; RegistryName = 'MyRegistry-MiCrOsOfT'; ExpectedServer = 'myregistry-microsoft.azurecr.io' }
            @{ Label = 'minimum legacy prefix'; RegistryName = 'abcde-microsoft'; ExpectedServer = 'abcde-microsoft.azurecr.io' }
            @{ Label = 'maximum legacy prefix'; RegistryName = (('A' * 50) + '-microsoft'); ExpectedServer = (('a' * 50) + '-microsoft.azurecr.io') }
            @{ Label = 'short legacy suffix'; RegistryName = 'myregistry-on'; ExpectedServer = 'myregistry-on.azurecr.io' }
            @{ Label = 'custom suffix'; RegistryName = 'myregistry-Custom42'; ExpectedServer = 'myregistry-custom42.azurecr.io' }
            @{ Label = 'one-character suffix'; RegistryName = 'abcde-X'; ExpectedServer = 'abcde-x.azurecr.io' }
            @{ Label = '15-character suffix'; RegistryName = ('abcde-' + ('A' * 15)); ExpectedServer = ('abcde-' + ('a' * 15) + '.azurecr.io') }
            @{ Label = '17-character suffix'; RegistryName = ('abcde-' + ('A' * 17)); ExpectedServer = ('abcde-' + ('a' * 17) + '.azurecr.io') }
            @{ Label = 'maximum suffix'; RegistryName = ('abcde-' + ('A' * 57)); ExpectedServer = ('abcde-' + ('a' * 57) + '.azurecr.io') }
            @{ Label = '50-character prefix at label limit'; RegistryName = (('A' * 50) + '-' + ('B' * 12)); ExpectedServer = (('a' * 50) + '-' + ('b' * 12) + '.azurecr.io') }
        ) {
            param($Label, $RegistryName, $ExpectedServer)

            $result = Connect-AzContainerRegistry -Name $RegistryName -UserName 'user' -Password 'password' `
                -DefaultProfile $script:profile -ErrorAction Stop

            $result.Count | Should -Be 1
            $result[0].Arguments[1] | Should -BeExactly $ExpectedServer
        }
    }

    It 'Exposes the selected endpoint for <Label>' -TestCases @(
        @{ Label = 'DNL label'; Cloud = 'AzureCloud'; Name = 'myregistry-0123456789abcdef'; ExpectedServer = 'myregistry-0123456789abcdef.azurecr.io' }
        @{ Label = 'legacy label'; Cloud = 'AzureCloud'; Name = 'myregistry-microsoft'; ExpectedServer = 'myregistry-microsoft.azurecr.io' }
        @{ Label = 'custom label in sovereign cloud'; Cloud = 'AzureChinaCloud'; Name = 'myregistry-custom42'; ExpectedServer = 'myregistry-custom42.azurecr.cn' }
        @{ Label = 'sovereign cloud'; Cloud = 'AzureChinaCloud'; Name = 'myregistry'; ExpectedServer = 'myregistry.azurecr.cn' }
    ) {
        param($Label, $Cloud, $Name, $ExpectedServer)

        function global:docker { throw 'Docker must not run with ExposeToken.' }
        $originalEnvironment = $script:profile.DefaultContext.Environment
        try {
            $script:profile.DefaultContext.Environment =
                [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments[$Cloud]
            $result = Connect-AzContainerRegistry -Name $Name -UserName 'user' -Password 'password' `
                -ExposeToken -DefaultProfile $script:profile -ErrorAction Stop -WarningAction SilentlyContinue

            $result.loginServer | Should -BeExactly $ExpectedServer
            $result.accessToken | Should -BeOfType System.Security.SecureString
        } finally {
            $script:profile.DefaultContext.Environment = $originalEnvironment
        }
    }

    It 'Uses an explicit DNL label without discovery warnings' {
        $warnings = @()
        $result = Connect-AzContainerRegistry -Name 'MyRegistry-0123456789ABCDEF' `
            -UserName 'user' -Password 'password' -DefaultProfile $script:profile `
            -WarningVariable warnings -ErrorAction Stop

        $result[0].Arguments[1] | Should -BeExactly 'myregistry-0123456789abcdef.azurecr.io'
        $warnings.Count | Should -Be 0
    }

    Context 'Docker credentials are data, not PowerShell source' {
        It 'Passes <Label> unchanged as arguments and standard input' -TestCases @(
            @{ Label = 'plain credentials'; UserName = 'user'; Password = 'password' }
            @{ Label = 'spaces'; UserName = 'user name'; Password = 'password with spaces' }
            @{ Label = 'single quotes'; UserName = "user'name"; Password = "pass'word" }
            @{ Label = 'double quotes'; UserName = 'user"name'; Password = 'pass"word' }
            @{ Label = 'backticks'; UserName = 'user`name'; Password = 'pass`word' }
            @{ Label = 'metacharacters'; UserName = 'user&name|other'; Password = 'pass;&|<>word' }
            @{ Label = 'newlines'; UserName = "user`nname"; Password = "pass`r`nword" }
            @{ Label = 'subexpressions'; UserName = '$(throw "Username evaluated")'; Password = '$(throw "Password evaluated")' }
            @{ Label = 'username statement'; UserName = 'user; throw "Username evaluated"; #'; Password = 'password' }
            @{ Label = 'password quote breakout'; UserName = 'user'; Password = "'; throw 'Password evaluated'; #" }
        ) {
            param($Label, $UserName, $Password)

            $result = Connect-AzContainerRegistry -Name 'myregistry' -UserName $UserName -Password $Password `
                -DefaultProfile $script:profile -ErrorAction Stop

            $result.Count | Should -Be 1
            $result[0].Arguments.Count | Should -Be 5
            $result[0].Arguments[0] | Should -BeExactly 'login'
            $result[0].Arguments[1] | Should -BeExactly 'myregistry.azurecr.io'
            $result[0].Arguments[2] | Should -BeExactly '-u'
            $result[0].Arguments[3] | Should -BeExactly $UserName
            $result[0].Arguments[4] | Should -BeExactly '--password-stdin'
            $result[0].Password.Count | Should -Be 1
            $result[0].Password[0] | Should -BeExactly $Password
        }

        It 'Forwards Docker output, errors, verbose messages, and warnings' {
            # Capture streams at the host boundary, including those from the nested pipeline.
            $powershell = [System.Management.Automation.PowerShell]::Create()
            try {
                $modulePath = (Get-Command Connect-AzContainerRegistry).Module.Path
                $null = $powershell.AddScript({
                    param($ModulePath)
                    Import-Module $ModulePath -ErrorAction Stop
                    function global:docker {
                        Write-Error -Message 'Docker login failed' -ErrorId 'DockerLoginFailed' -ErrorAction Continue
                        Write-Verbose 'Docker verbose message' -Verbose
                        Write-Warning 'Docker warning'
                        'Docker output'
                    }
                }).AddArgument($modulePath)
                $null = $powershell.Invoke()
                $powershell.HadErrors | Should -BeFalse
                $powershell.Commands.Clear()

                $null = $powershell.AddCommand('Connect-AzContainerRegistry').
                    AddParameter('Name', 'myregistry').
                    AddParameter('UserName', 'user').
                    AddParameter('Password', 'password').
                    AddParameter('DefaultProfile', $script:profile).
                    AddParameter('ErrorAction', 'Continue').
                    AddParameter('Verbose', $true)
                $output = $powershell.Invoke()

                $powershell.Streams.Error.Count | Should -Be 1
                $powershell.Streams.Error[0].Exception.Message | Should -BeExactly 'Docker login failed'
                $powershell.Streams.Error[0].FullyQualifiedErrorId | Should -BeLike 'DockerLoginFailed*'
                $powershell.Streams.Verbose.Message | Should -Contain 'Docker verbose message'
                $powershell.Streams.Warning.Message | Should -Contain 'Docker warning'
                $output.Count | Should -Be 1
                $output[0].Count | Should -Be 1
                $output[0][0] | Should -BeExactly 'Docker output'
            } finally {
                $powershell.Dispose()
            }
        }
    }
}
