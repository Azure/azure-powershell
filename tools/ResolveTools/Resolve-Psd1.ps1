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

# This will resolve the issues in root module psd1 file of every Az module
# ```powershell
# ./tools/ResolveTools/Resolve-Psd1.ps1 -Module ManagedServiceIdentity -Psd1Folder src/ManagedServiceIdentity/ManagedServiceIdentity
# ```

Param(
    [Parameter(Mandatory = $true)]
    [string] $ModuleName,
    [Parameter(Mandatory = $true)]
    [string] $Psd1Folder
)
# Import-Module "$PSScriptRoot/../../artifacts/Debug/Az.$ModuleName/Az.$ModuleName.psd1" -Force
$HelpFolder = "$Psd1Folder/help"
$ModuleMatadata = Get-Module "Az.$ModuleName"

$ExportedCommands = $ModuleMatadata.ExportedCommands.Values | Where-Object {$_.CommandType -ne 'Alias'} | ForEach-Object { $_.Name}
$ExposedHelpFiles = Get-ChildItem $HelpFolder -Recurse -Filter "*-*.md"
foreach ($ExposedHelpFile in $ExposedHelpFiles)
{
    $CmdletName = $ExposedHelpFile.Name.Replace(".md", "")
    if ($ExportedCommands -notcontains $CmdletName)
    {
        Remove-Item $ExposedHelpFile.FullName
    }
}

# Remove the deprecated commands from the module manifest.
$Psd1Metadata = Import-LocalizedData -BaseDirectory $Psd1Folder -FileName "Az.$ModuleName.psd1"

$Psd1Metadata.FunctionsToExport = $ModuleMatadata.ExportedFunctions.Keys | Sort-Object
if ($Psd1Metadata.FunctionsToExport.Length -eq 0)
{
    $Psd1Metadata.FunctionsToExport = @()
}

$Psd1Metadata.CmdletsToExport = $ModuleMatadata.ExportedCmdlets.Keys | Sort-Object
if ($Psd1Metadata.CmdletsToExport.Length -eq 0)
{
    $Psd1Metadata.CmdletsToExport = @()
}

$Psd1Metadata.AliasesToExport = $ModuleMatadata.ExportedAliases.Keys | Sort-Object
if ($Psd1Metadata.AliasesToExport.Length -eq 0)
{
    $Psd1Metadata.AliasesToExport = @()
}

if ($null -ne $Psd1Metadata.PrivateData) {
    foreach ($pKey in $Psd1Metadata.PrivateData.PSData.Keys) {
        $Psd1Metadata.$pKey = $Psd1Metadata.PrivateData.PSData.$pKey
    }
    $Psd1Metadata.Remove("PrivateData")
}

New-ModuleManifest -Path "$Psd1Folder/Az.$ModuleName.psd1" @Psd1Metadata