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

$global:ModuleName = "Azs.Compute.Admin"

if ($global:UseInstalled) {
    Import-Module $global:ModuleName -Force
} else {
    Import-Module ..\Module\$global:ModuleName -Force
}

if (-not $global:RunRaw) {
    if (Test-Path bin\Debug) {
        Import-Module ".\bin\Debug\$global:ModuleName.Tests.dll" -Force
    } elseif (Test-Path bin\Release) {
        Import-Module ".\bin\Release\$global:ModuleName.Tests.dll" -Force
    } else {
        throw "Cannot load test dll: $global:ModuleName.Tests.dll"
    }
}
