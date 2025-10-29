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
[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [string]$Configuration = 'Debug',
    [string]$PowerShellPlatform
)

# Install PowerShell dependencies
Write-Host -ForegroundColor Green "-------------------- Start installing PowerShell dependencies ... --------------------"
Install-Module "platyPS", "PSScriptAnalyzer" -Repository PSGallery -Force -Confirm:$false -Scope CurrentUser
Write-Host -ForegroundColor DarkGreen "-------------------- End installing PowerShell dependencies ... --------------------`n`n`n`n`n"

# Install latest Az modules
Write-Host -ForegroundColor Green "-------------------- Start installing latest Az modules ... --------------------"
New-Item -ItemType Directory -Path "Az-Cmdlets-latest"
Invoke-WebRequest -Uri "https://azpspackage.blob.core.windows.net/release/Az-Cmdlets-latest.tar.gz" -OutFile "Az-Cmdlets-latest/Az-Cmdlets-latest.tar.gz" -MaximumRetryCount 2 -RetryIntervalSec 1
tar -xvzf "Az-Cmdlets-latest/Az-Cmdlets-latest.tar.gz" -C "Az-Cmdlets-latest"
& Az-Cmdlets-latest/InstallModule.ps1
Write-Host -ForegroundColor DarkGreen "-------------------- End installing latest Az modules ... --------------------`n`n`n`n`n"

# Generate help
Write-Host -ForegroundColor Green "-------------------- Start generating help ... --------------------"
if ($PowerShellPlatform) {
    $Env:PowerShellPlatform = $PowerShellPlatform
}
$buildProjPath = Join-Path $RepoRoot 'build.proj'
dotnet msbuild $buildProjPath /t:GenerateHelp "/p:Configuration=$Configuration"
Write-Host -ForegroundColor DarkGreen "-------------------- End generating help ... --------------------`n`n`n`n`n"

# Static Analysis
Write-Host -ForegroundColor Green "-------------------- Start static analysis ... --------------------"
dotnet msbuild $buildProjPath /t:StaticAnalysis "/p:Configuration=$Configuration"
Write-Host -ForegroundColor DarkGreen "-------------------- End static analysis ... --------------------`n`n`n`n`n"