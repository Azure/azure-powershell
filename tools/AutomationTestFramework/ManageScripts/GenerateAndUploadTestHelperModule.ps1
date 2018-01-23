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

. "$PSScriptRoot\PackAndUploadModule.ps1"

<#
ZIPs specified files and upload to Automation Account as module 
.PARAMETER path
Path to the folder where test helpers are located. 
If not specified, uses ..\TestHelper folder
.PARAMETER files
Parameter description
List of files to be added to the module.
If not specified, adds all the files from the $path folder
#>
function GenerateAndUploadTestHelperModule([string]$path, [string[]]$files) {

    $moduleName = "TestHelpers"
    
    if(!$path) {
        $path = Join-Path $PSScriptRoot "..\TestHelpers"
    }

    if (!$files -or $files.Count -eq 0) {
        $files = Get-ChildItem $path -Filter "*.ps*"
    }

    PackAndUploadModule -path $path -files $files -moduleName $moduleName

    $statusMap = CheckModuleProvisionState -moduleList $moduleName

    $failed = $statusMap.GetEnumerator() | Where-Object {$_.Value -eq $false} | ForEach-Object { $_.Key }
    if ($failed.Count -gt 0) {
        throw "Modules $failed failed to upload"
    }
}