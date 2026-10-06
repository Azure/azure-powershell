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
#Requires -Version 7.3

Describe 'Install-EdgeActionDevelopmentTools' {
    BeforeAll {
        $script:installer = Join-Path (Split-Path $PSScriptRoot -Parent) 'Install-EdgeActionDevelopmentTools.ps1'
    }

    BeforeEach {
        $script:savedExitCode = $global:LASTEXITCODE
        $script:savedEnvironment = @{}
        foreach ($name in @('PATH', 'PSModulePath', 'autorest_registry', 'AUTOREST_HOME', 'RestoreSources')) {
            $script:savedEnvironment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
        $caseDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = New-Item -ItemType Directory -Path $caseDirectory
        $script:toolsDirectory = Join-Path $caseDirectory 'tools'
        $script:nodeStub = Join-Path $caseDirectory 'node.ps1'
        $script:npmStub = Join-Path $caseDirectory 'npm.ps1'
        $script:dotnetStub = Join-Path $caseDirectory 'dotnet.ps1'
        Set-Content (Join-Path $caseDirectory 'node-version.txt') 'v20.20.2'
        Set-Content (Join-Path $caseDirectory 'sdk-version.txt') '10.0.401'
        Set-Content $script:nodeStub @'
$global:LASTEXITCODE = 0
Get-Content (Join-Path $PSScriptRoot 'node-version.txt')
'@
        Set-Content $script:dotnetStub @'
$global:LASTEXITCODE = 0
Get-Content (Join-Path $PSScriptRoot 'sdk-version.txt')
'@
        Set-Content $script:npmStub @'
$global:LASTEXITCODE = 0
if ($args[0] -eq 'config') {
    'https://registry.example.test/'
    return
}
if (Test-Path (Join-Path $PSScriptRoot 'npm-failure')) {
    $global:LASTEXITCODE = 17
    return
}
$args -join ' ' | Add-Content (Join-Path $PSScriptRoot 'npm-installs.txt')
$prefix = $args[[array]::IndexOf($args, '--prefix') + 1]
foreach ($package in @(@{ Name = 'autorest'; Version = '3.8.0' }, @{ Name = '@autorest/core'; Version = '3.10.9' })) {
    $directory = Join-Path $prefix 'node_modules' $package.Name
    $null = New-Item -ItemType Directory -Path $directory -Force
    @{ version = $package.Version } | ConvertTo-Json | Set-Content (Join-Path $directory 'package.json')
}
'@
        Mock Get-Command { [pscustomobject]@{ Source = (Join-Path $caseDirectory 'node.ps1') } } -ParameterFilter { $Name -eq 'node' }
        Mock Get-Command { [pscustomobject]@{ Source = (Join-Path $caseDirectory 'npm.ps1') } } -ParameterFilter { $Name -eq 'npm' }
        Mock Save-Module {
            param($Name, $RequiredVersion, $Path)
            $directory = Join-Path $Path $Name $RequiredVersion
            $null = New-Item -ItemType Directory -Path $directory -Force
            New-ModuleManifest -Path (Join-Path $directory "$Name.psd1") -ModuleVersion $RequiredVersion
        }
    }

    AfterEach {
        $global:LASTEXITCODE = $script:savedExitCode
        foreach ($name in $script:savedEnvironment.Keys) {
            [Environment]::SetEnvironmentVariable($name, $script:savedEnvironment[$name])
        }
    }

    It 'installs exact local package versions and activates the current process' {
        $result = & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub
        $result.AutoRest | Should -Be '3.8.0'
        $result.AutoRestCore | Should -Be '3.10.9'
        $result.Pester | Should -Be '4.10.1'
        $result.PlatyPS | Should -Be '0.14.2'
        $env:autorest_registry | Should -Be 'https://registry.example.test/'
        $env:AUTOREST_HOME | Should -Be $script:toolsDirectory
        ($env:PATH -split [IO.Path]::PathSeparator)[0] | Should -Be (Join-Path $script:toolsDirectory 'npm' 'node_modules' '.bin')
        ($env:PSModulePath -split [IO.Path]::PathSeparator)[0] | Should -Be (Join-Path $script:toolsDirectory 'modules')
        $install = Get-Content (Join-Path $caseDirectory 'npm-installs.txt') -Raw
        $install | Should -Match 'autorest@3.8.0 @autorest/core@3.10.9'
        $install | Should -Match '--no-save --package-lock=false'
        $install | Should -Not -Match '--global'
        Assert-MockCalled Save-Module -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq 'Pester' -and $RequiredVersion -eq '4.10.1' }
        Assert-MockCalled Save-Module -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq 'platyPS' -and $RequiredVersion -eq '0.14.2' }
    }

    It 'does not reinstall packages on repeated installation or activation' {
        & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub | Out-Null
        & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub | Out-Null
        & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub -ActivateOnly | Out-Null
        @(Get-Content (Join-Path $caseDirectory 'npm-installs.txt')).Count | Should -Be 1
        Assert-MockCalled Save-Module -Times 2 -Exactly -Scope It
        @($env:PATH -split [IO.Path]::PathSeparator | Where-Object { $_ -eq (Join-Path $script:toolsDirectory 'npm' 'node_modules' '.bin') }).Count | Should -Be 1
    }

    It 'does not install anything in activation-only mode when packages are missing' {
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub -ActivateOnly } |
            Should -Throw 'Pinned AutoRest packages are missing'
        Test-Path $script:toolsDirectory | Should -BeFalse
        Assert-MockCalled Save-Module -Times 0 -Exactly -Scope It
    }

    It 'rejects a mismatched local npm version during activation' {
        & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub | Out-Null
        '{"version":"0.0.0"}' | Set-Content (Join-Path $script:toolsDirectory 'npm' 'node_modules' 'autorest' 'package.json')
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub -ActivateOnly } |
            Should -Throw 'Pinned AutoRest packages are missing'
    }

    It 'applies approved proxy settings only when requested' {
        $env:RestoreSources = 'existing-feed'
        & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub | Out-Null
        $env:RestoreSources | Should -Be 'existing-feed'
        & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub -ActivateOnly -UseMicrosoftPackageFeedProxy | Out-Null
        $env:autorest_registry | Should -Be 'https://packagefeedproxy.microsoft.io/npm/'
        $env:RestoreSources | Should -Match 'tools[/\\]LocalFeed'
        $env:RestoreSources | Should -Match 'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
        $env:RestoreSources | Should -Match 'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
    }

    It 'rejects an insecure registry before installing' {
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub -NpmRegistry 'http://registry.example.test/' } |
            Should -Throw 'absolute HTTPS URL'
        Test-Path $script:toolsDirectory | Should -BeFalse
    }

    It 'rejects conflicting registry options' {
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub -UseMicrosoftPackageFeedProxy -NpmRegistry 'https://registry.example.test/' } |
            Should -Throw 'not both'
    }

    It 'rejects obsolete Node.js before installing' {
        Set-Content (Join-Path $caseDirectory 'node-version.txt') 'v18.0.0'
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub } |
            Should -Throw 'Node.js 20 or later is required'
        Test-Path $script:toolsDirectory | Should -BeFalse
    }

    It 'rejects the obsolete .NET SDK shim before installing' {
        Set-Content (Join-Path $caseDirectory 'sdk-version.txt') '2.1.504'
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub } |
            Should -Throw 'Do not use the npm dotnet shim'
        Test-Path $script:toolsDirectory | Should -BeFalse
    }

    It 'reports npm failures without activating a partial installation' {
        $previousHome = $env:AUTOREST_HOME
        Set-Content (Join-Path $caseDirectory 'npm-failure') ''
        { & $script:installer -ToolsDirectory $script:toolsDirectory -DotNetPath $script:dotnetStub } |
            Should -Throw 'exit code 17'
        $env:AUTOREST_HOME | Should -Be $previousHome
        Assert-MockCalled Save-Module -Times 0 -Exactly -Scope It
    }
}
