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

$ModuleName = "Azs.AzureBridge.Admin"

if (!(Get-Module -ListAvailable -Name AzureRM.Profile)) {
    Import-Module "..\..\..\Stack\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile"
}

if ($global:UsedInstalled) {
    Import-Module $ModuleName -Force
} else {
    Import-Module ..\Module\$ModuleName -Force
}

if (-not $global:RunRaw) {
    if (Test-Path bin\Debug) {
        Import-Module ".\bin\Debug\$ModuleName.Tests.dll" -Force
    } elseif (Test-Path bin\Release) {
        Import-Module ".\bin\Release\$ModuleName.Tests.dll" -Force
    } else {
        throw "Cannot load test dll: $ModuleName.Tests.dll"
    }
}
