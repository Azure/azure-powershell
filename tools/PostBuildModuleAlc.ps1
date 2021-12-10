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

<#
.SYNOPSIS
    Generate InitializeAssemblyLoadContext.ps1 and put it under output folder.

.PARAMETER ModuleFolder
    The output folder for module, e.g. C:\azure-powershell\artifacts\Debug\Az.Compute

.PARAMETER AlcEntryAssembly
    Entry assembly name of current module Assembly Load Context, e.g. "Azure."

.PARAMETER AlcRefAssembly
    Assembly referenced by module entry assemblies, separated by ';', e.g. "Azure.Storage.Blobs;Azure.Storage.Common"
#>

param (
    [Parameter(Mandatory = $true)]
    [string]
    $ModuleFolder,

    [Parameter(Mandatory = $true)]
    [string]
    $AlcEntryAssembly,

    [Parameter(Mandatory = $true)]
    [string]
    $AlcRefAssembly,

    [Parameter(Mandatory = $true)]
    [string]
    $Configuration
)

$alcTemplate = @'
if($PSVersionTable.PSEdition -eq 'Core')
{
    try {
        $assemblyLoadContextFolder = [System.IO.Path]::Combine($PSScriptRoot, "..", "ModuleAlcAssemblies")
        Write-Debug "Registering module AssemblyLoadContext for path: '$assemblyLoadContextFolder'."
        [Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext.AzAssemblyLoadContextInitializer]::RegisterModuleAssemblyLoadContext("%ASSEMBLY_LOAD_CONTEXT_ENTRY_ASSEMBLY%", $assemblyLoadContextFolder)
        Write-Debug "AssemblyLoadContext registered."
    } catch {
        Write-Warning $_
    }
}
'@

$alcTemplate = $alcTemplate.Replace("%ASSEMBLY_LOAD_CONTEXT_ENTRY_ASSEMBLY%", $AlcEntryAssembly)
$scriptPath = [System.IO.Path]::Combine($ModuleFolder, "PostImportScripts", "InitializeAssemblyLoadContext.ps1")
if (-not (Test-Path $scriptPath)) {
    New-Item -ItemType File -Path $scriptPath -Force
}
$alcTemplate | Out-File -FilePath $scriptPath -Encoding utf8 -Force

$isReleaseConfiguration = $Configuration -eq 'Release'

$alcDestinationDir = [System.IO.Path]::Combine($ModuleFolder, "ModuleAlcAssemblies")
$entryAssemblyPath = [System.IO.Path]::Combine($ModuleFolder, $AlcEntryAssembly + ".dll")
if (-not (Test-Path $alcDestinationDir)) {
    New-Item -ItemType Directory -Path $alcDestinationDir -Force
}

if ($isReleaseConfiguration) {
    Move-Item -Path $entryAssemblyPath -Destination $alcDestinationDir -Force
}
else {
    Copy-Item -Path $entryAssemblyPath -Destination $alcDestinationDir -Force #Move-Item cause test project build error: CS0006 metadata file AlcWrapper.dll could not be found
}

if (-not [System.String]::IsNullOrEmpty($AlcRefAssembly)) {
    $refAssemblies = $AlcRefAssembly.Split(';')
    $refAssemblies | ForEach-Object {
        $refAssemblyPath = [System.IO.Path]::Combine($ModuleFolder, $_ + ".dll")
        if ($isReleaseConfiguration) {
            Move-Item -Path $refAssemblyPath -Destination $alcDestinationDir -Force
        }
        else {
            Copy-Item -Path $refAssemblyPath -Destination $alcDestinationDir -Force
        }
    }
}
