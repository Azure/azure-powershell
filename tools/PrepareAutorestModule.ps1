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
$ChangedFiles = Get-Content -Path "$PSScriptRoot\..\artifacts\FilesChanged.txt"

$ALL_MODULE = "ALL_MODULE"

$SKIP_MODULES = @()

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
    $ModuleList = (Get-ChildItem "$PSScriptRoot\..\src\" -Directory -Exclude helpers,lib).Name | Where-Object { $SKIP_MODULES -notcontains $_ -and (Get-Item env:SELECTEDMODULELIST).Value.Split(';') -contains $_ }
}
else
{
    $ModuleList = $ModuleSet | Where-Object { $SKIP_MODULES -notcontains $_ }
}
#EndRegion

Install-Module -Name platyPS -RequiredVersion 0.14.2 -Force

Import-Module "$PSScriptRoot\..\tools\Gen2Master\MoveFromGeneration2Master.ps1" -Force
$TmpFolder = "$PSScriptRoot\..\tmp"
New-Item -ItemType Directory -Force -Path $TmpFolder
Remove-Item -Path "$TmpFolder\*" -Recurse -Force

#Region Clone latest Az.Accounts code
Set-Location -Path $TmpFolder
git init
git remote add -f origin https://github.com/Azure/azure-powershell.git
git config core.sparseCheckout true
Add-Content -Path .git/info/sparse-checkout -Value "src/"
Add-Content -Path .git/info/sparse-checkout -Value "tools/"
Add-Content -Path .git/info/sparse-checkout -Value "Repo.props"
Add-Content -Path .git/info/sparse-checkout -Value "build.proj"
git pull origin main --depth=1
Copy-Item -Path "$TmpFolder\src\Accounts" -Destination "$TmpFolder\Accounts" -Force -Recurse
Copy-Item "$TmpFolder\Accounts" "$PSScriptRoot\..\src" -Recurse -Force
Copy-Item -Path "$TmpFolder\tools\Common*.targets" -Destination "$PSScriptRoot\..\tools" -Force
Install-Module Az.Accounts -Repository PSGallery -Force
Import-Module Az.Accounts
Copy-Item "$PSScriptRoot\..\src\*.props" $TmpFolder

If ($ModuleSet.Contains("Compute"))
{
    Copy-Item -Path "$TmpFolder\src\Resources\Resources.Test" -Destination "$PSScriptRoot\..\src\Resources\Resources.Test" -Force -Recurse
}
#EndRegion

#Region generate the code and make the struture same with main branch.
$AutorestOutputDir = "$PSScriptRoot\..\artifacts\autorest"
New-Item -ItemType Directory -Force -Path $AutorestOutputDir
foreach ($Module in $ModuleList)
{
    $RootModuleFolder = "$PSScriptRoot\..\src\$Module\"
    $ModuleFolders = (Get-ChildItem -path $RootModuleFolder -filter Az.*.psd1 -Recurse).Directory
    if ($Null -eq $ModuleFolders)
    {
        # Module is not found maybe it's deleted in this PR
        Write-Warning "Cannot find any psd1 files in $RootModuleFolder."
        continue
    }
    # Go through the module including nested modules.
    foreach ($ModuleFolder in $ModuleFolders) {
        Set-Location -Path $ModuleFolder
        # Msbuild will regard autorest's output stream who contains "xx error xx:" as an fault by mistake.
        # We need to redirect output stream to file to avoid the mistake.
        npx autorest --max-memory-size=8192 >> "$AutorestOutputDir\$Module.log"
        # Exit if generation fails
        if ($lastexitcode -ne 0)
        {
            exit $lastexitcode
        }

        ./build-module.ps1
    }
    $subModuleFolders =  Get-ChildItem -path $RootModuleFolder -Directory -Filter *.Autorest
    if ($null -eq $subModuleFolders) {
        write-host "autogen module"
        Move-Generation2Master -SourcePath "$PSScriptRoot\..\src\$Module\" -DestPath $TmpFolder\src
    } else {
        #New-Item -ItemType Directory -Path $TmpFolder\$Module -Force
        Write-Host "hybrid module"
        Move-Generation2MasterHybrid -SourcePath "$PSScriptRoot\..\src\$Module\" -DestPath $TmpFolder\src\$Module
    }
    Set-Location -Path $TmpFolder
    Remove-Item "$RootModuleFolder\*" -Recurse -Force
    Copy-Item -Path "$TmpFolder\src\$Module" "$TmpFolder\src\.."  -Recurse -Force
}
#EndRegion
Remove-Item -Path "$TmpFolder\src" -Recurse -Force
Remove-Item -Path "$TmpFolder\artifacts" -Recurse -Force
Remove-Item -Path "$TmpFolder\tools" -Recurse -Force
Copy-Item "$TmpFolder\*" "$PSScriptRoot\..\src" -Exclude src,.git,tools,build.proj -Recurse -Force
