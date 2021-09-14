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

#This script will pack build artifacts under temporary folder "artifacts/tmp" and output Az.*.nupkg to "artifacts"


param(
)
$ChangedFiles = Get-Content -Path "$PSScriptRoot\..\FilesChanged.txt"

$ALL_MODULE = "ALL_MODULE"

$SKIP_MODULES = @("AppService", "Billing", "Compute", "ContainerInstance", "ConnectedMachine", "ContainerRegistry", "Dns", "KeyVault", "Media", "Monitor", "Network", "Resources", "ServiceBus", "Storage")

#Region Detect which module should be processed
$ModuleSet = New-Object System.Collections.Generic.HashSet[string]
foreach ($file in $ChangedFiles)
{
    $ParentFolder = Split-Path -Path $file -Parent
    if ($ParentFolder.StartsWith("src"))
    {
        if ($ParentFolder -eq "src")
        {
            $NUll = $ModuleSet.Add($ALL_MODULE)
        }
        else
        {
            $NUll = $ModuleSet.Add($ParentFolder.Replace("/", "\").Split('\')[1])
        }
    }
    else
    {
        $NUll = $ModuleSet.Add($ALL_MODULE)
    }
}
if ($ModuleSet.Contains($ALL_MODULE))
{
    $ModuleList = (Get-ChildItem "$PSScriptRoot\..\src\" -Directory -Exclude helpers,lib).Name | Where-Object { $SKIP_MODULES -notcontains $_ }
}
else
{
    $ModuleList = $ModuleSet | Where-Object { $SKIP_MODULES -notcontains $_ }
}
#EndRegion

Import-Module "$PSScriptRoot\..\tools\Gen2Master\MoveFromGeneration2Master.ps1" -Force
$TmpFolder = "$PSScriptRoot\..\tmp"
New-Item -ItemType Directory -Force -Path $TmpFolder
Remove-Item -Path "$TmpFolder\*" -Recurse -Force

#Region Clone latest Az.Accounts code
Set-Location -Path $TmpFolder
git init
git remote add -f origin https://github.com/Azure/azure-powershell.git
git config core.sparseCheckout true
Add-Content -Path .git/info/sparse-checkout -Value "src/Accounts/"
git pull origin main
Move-Item -Path "$TmpFolder\src\Accounts" -Destination "$TmpFolder\Accounts"
Copy-Item "$TmpFolder\Accounts" "$PSScriptRoot\..\src" -Recurse -Force
Remove-Item -Path "$TmpFolder\src" -Recurse -Force
Install-Module Az.Accounts -Repository PSGallery -Force
Import-Module Az.Accounts
Copy-Item "$PSScriptRoot\..\src\*.props" $TmpFolder
#EndRegion

#Region generate the code and make the struture same with main branch.
foreach ($Module in $ModuleList)
{
    $ModuleFolder = "$PSScriptRoot\..\src\$Module\"
    $ModuleFolder = (Get-ChildItem -path $ModuleFolder -filter Az.$Module.psd1 -Recurse).Directory
    if ($Null -eq $ModuleFolder)
    {
        # Module is not found maybe it's deleted in this PR
        Write-Warning "Cannot find Az.$Module.psd1 in $ModuleFolder."
        continue
    }
    Set-Location -Path $ModuleFolder
    try
    {
        npx autorest --max-memory-size=8192
    }
    catch
    {
        Write-Host "Generating $currentModule with m3"
        npx autorest --use:@autorest/powershell@2.1.401 --max-memory-size=8192
    }
    ./build-module.ps1
    Move-Generation2Master -SourcePath "$PSScriptRoot\..\src\$Module\" -DestPath $TmpFolder
    Remove-Item "$ModuleFolder\*" -Recurse -Force
}
#EndRegion
Copy-Item "$TmpFolder\*" "$PSScriptRoot\..\src" -Recurse -Force
