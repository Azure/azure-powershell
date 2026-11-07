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

#Requires -Version 7.3

param(
    [Parameter(Mandatory)] [string] $ModuleArtifactsPath,
    [Parameter(Mandatory)] [string] $InputPath,
    [Parameter(Mandatory)] [string] $OutputPath
)

$ErrorActionPreference = 'Stop'
$env:PSModulePath = $ModuleArtifactsPath + [IO.Path]::PathSeparator + $env:PSModulePath
Import-Module (Join-Path $ModuleArtifactsPath 'Az.Accounts/Az.Accounts.psd1') -ErrorAction Stop
Import-Module (Join-Path $ModuleArtifactsPath 'Az.ContainerRegistry/Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.dll') -ErrorAction Stop

$env:PATH = $PSScriptRoot + [IO.Path]::PathSeparator + $env:PATH
$docker = Get-Command docker -CommandType Application -ErrorAction Stop
if ([IO.Path]::GetDirectoryName($docker.Path) -ne $PSScriptRoot) {
    throw 'The native Docker fixture was not selected.'
}

$profile = New-Object Microsoft.Azure.Commands.Common.Authentication.Models.AzureRmProfile
$context = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureContext
$context.Environment = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment]::PublicEnvironments['AzureCloud']
$context.Account = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureAccount
$context.Account.Id = 'native-test@example.invalid'
$context.Account.Type = 'User'
$context.Tenant = New-Object Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureTenant
$context.Tenant.Id = [guid]::NewGuid().ToString()
$profile.DefaultContext = $context

$credentials = [IO.File]::ReadAllText($InputPath) | ConvertFrom-Json
$result = Connect-AzContainerRegistry -Name 'myregistry-0123456789abcdef' `
    -UserName $credentials.UserName -Password $credentials.Password -DefaultProfile $profile
if ($LASTEXITCODE -ne 0 -or $result.Count -ne 1) {
    throw 'The native Docker fixture did not return one successful capture.'
}
[IO.File]::WriteAllText($OutputPath, [string]$result[0], [Text.UTF8Encoding]::new($false))
