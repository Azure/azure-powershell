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

function Test-IsAdmin() {
    try {
        $identity = [Security.Principal.WindowsIdentity]::GetCurrent()
        $principal = New-Object Security.Principal.WindowsPrincipal -ArgumentList $identity
        return $principal.IsInRole( [Security.Principal.WindowsBuiltInRole]::Administrator )
    } catch {
        throw "Failed to determine if the current user has elevated privileges. The error was: '{0}'." -f $_
    }
}

function Invoke-Environment()
{
    param
    (
        [Parameter(Mandatory=1)][string]$Command
    )

    foreach($_ in cmd /c "$Command  2>&1 & set") {
        if ($_ -match '^([^=]+)=(.*)') {
            [System.Environment]::SetEnvironmentVariable($matches[1], $matches[2])
        }
    }
}

if (Test-Path -Path env:\AzurePSRoot) {
    Write-Host -Object 'AzurePSRoot environment variable already exists. Exiting ...';
    exit;
}

Write-Host -Object 'Initializing Azure PowerShell environment...';

# PowerShell commands need elevation for dependencies installation and running tests
if (!(Test-IsAdmin)){
    Write-Host -Object 'Please launch command under administrator account. It is needed for environment setting up and unit test.' -ForegroundColor Red;
}

$env:AzurePSRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Path;
$env:AzurePSRoot = Split-Path -Parent -Path $env:AzurePSRoot;

if (Test-Path -Path ${env:\ProgramFiles(x86)} ) {
    $env:ADXSDKProgramFiles = ${env:ProgramFiles(x86)}
    $env:ADX64Platform = $true
} else {
    $env:ADXSDKProgramFiles = $env:ProgramFiles
    $env:ADX64Platform = $false
}


if (Test-Path -Path "$env:ADXSDKProgramFiles\Microsoft Visual Studio 12.0") {
    $vsVersion="12.0"
} else {
    $vsVersion="11.0"
}

$setVSEnv = '"{0}\Microsoft Visual Studio {1}\VC\vcvarsall.bat" x64' -f $env:ADXSDKProgramFiles, $vsVersion;

Invoke-Environment -Command $setVSEnv;
