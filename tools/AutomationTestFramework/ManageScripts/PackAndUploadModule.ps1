
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

. "$PSScriptRoot\DeliverModuleToAutomationAccount.ps1"

<#
.SYNOPSIS
Zips files and uplod as module to Azure Automation Account
.PARAMETER path
Path to directory with files to pack
.PARAMETER files
List of files to pack
.PARAMETER moduleName
Resulting ZIP archive name and the name of uploaded module on Automation Account
.EXAMPLE
PackAndUploadModule -path "d:\tmp -files @(mymodule.psm1, myscript.ps1)" -moduleName 'mymodule'
#>
function PackAndUploadModule ([string] $path, [string[]] $files, [string] $moduleName) {

    #$files
    $src = $files | ForEach-Object { Join-Path $path $_}
    $dst =  Join-Path $path "$moduleName.zip"
    if (Test-Path $dst) {
            Remove-Item $dst -ErrorAction Stop
    }
    Write-Verbose "Creating ZIP..."
    Compress-Archive -LiteralPath $src -DestinationPath $dst -ErrorAction Stop

    DeliverModuleToAutomationAccount `
        -modulePath $path `
        -moduleName $moduleName
}