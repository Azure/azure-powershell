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

[CmdletBinding(
    SupportsShouldProcess=$true
)]
param(
    [Parameter(Mandatory = $false)]
    [string] $Version,
    [Parameter(Mandatory = $false)]
    [ValidateSet("Latest", "Stack")]
    [string] $Target = "Latest",
    [Parameter(Mandatory = $false)]
    [string] $SourceBaseUri,
    [Parameter(Mandatory = $false)]
    [string] $EditBaseUri,
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Debug",
    [Parameter(Mandatory = $false)]
    [string] $OutputFile = "$PSScriptRoot/index.json"
)

Import-LocalizedData -BindingVariable "Azpsd1" -BaseDirectory $PSScriptRoot/Az -FileName "Az.psd1"

if ([string]::isNullOrEmpty($Version))
{
    $Version = $Azpsd1.ModuleVersion
    Write-Host "Using version obtained from Az.psd1: $Version." -ForegroundColor Green;
}

if ([string]::isNullOrEmpty($SourceBaseUri))
{
    $tag = $Azpsd1.PrivateData.PSData.ReleaseNotes.Split("`n")[0].Replace(" ", "").Trim("`r")
    $SourceBaseUri = "https://github.com/Azure/azure-powershell/tree/v$tag"
    Write-Host "Using default SourceBaseUri: $SourceBaseUri." -ForegroundColor Green;
}

if ([string]::isNullOrEmpty($EditBaseUri))
{
    $EditBaseUri = "https://github.com/Azure/azure-powershell/blob/main"
    Write-Host "Using default EditBaseUri: $EditBaseUri." -ForegroundColor Green;
}

$output = @{}
$output.Add("name", "Az")
$output.Add("target", "$Target")
$output.Add("version", "$Version")

$outputModules = @{}

#Create mappings file
& "$PSScriptRoot/CreateMappings.ps1" -OutputFile $OutputFile/../groupMapping.json -WarningFile $OutputFile/../groupMappingWarnings.json
$labelMapping = Get-Content -Raw $OutputFile/../groupMapping.json | ConvertFrom-Json

$RMpsd1s = @()
$HelpFolders = @()

$resourceManagerPath = "$PSScriptRoot/../artifacts/$BuildConfig/"

$RMpsd1s += Get-ChildItem -Path $resourceManagerPath -Depth 1 | Where-Object { 
    $_.Name -like "*.psd1" -and $_.FullName -notlike "*dll-Help*"
}

.($PSScriptRoot + "\PreloadToolDll.ps1")
$HelpFolders += Get-ChildItem -Path "$PSScriptRoot/../src" -Recurse -Directory | where { $_.Name -eq "help" -and (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) -and $_.FullName -notlike "*\bin\*"}


# Map the name of the cmdlet to the location of the help file
$HelpFileMapping = @{}
$HelpFolders | ForEach-Object {
    $helpFiles = Get-ChildItem -Path $_.FullName
    $helpFiles | ForEach-Object {
        if ($HelpFileMapping.Contains($_.Name)) {
            throw "Two files exist with the name $_ in $($_.FullName)"
        }
        else {
            $HelpFileMapping.Add("$($_.Name)", $_.FullName)
        }
    }
}

$outputModules = @{}

$RMpsd1s | ForEach-Object {
    Import-LocalizedData -BindingVariable "parsedPsd1" -BaseDirectory $_.DirectoryName -FileName $_.Name

    $outputCmdlets = @{}

    $cmdletsToExport = $parsedPsd1.CmdletsToExport | Where-Object { $_ }
    $functionsToExport = $parsedPsd1.FunctionsToExport | Where-Object { $_ }
    $cmdletsToExport = @() + $cmdletsToExport + $functionsToExport

    $cmdletsToExport | ForEach-Object {
        $cmdletHelpFile = $HelpFileMapping["$_.md"]
        if ($cmdletHelpFile -eq $null -and $Target -eq "Latest")
        {
            throw "No help file found for cmdlet $_" 
        }

        $cmdletLabel = $labelMapping.$_
        if ($cmdletLabel -eq $null -and $Target -eq "Latest")
        {
            throw "No label found for cmdlet $_"
        }

        $helpSourceUrl = "$SourceBaseUri\src\$(($cmdletHelpFile -split "\\src\\*")[1])".Replace("\", "/")
        $helpEditUrl = "$EditBaseUri\src\$(($cmdletHelpFile -split "\\src\\*")[1])".Replace("\", "/")
        $outputCmdlets.Add("$_", @{"service" = $cmdletLabel; "sourceUrl" = $helpSourceUrl; "editUrl" = $helpEditUrl})
    }

    $moduleHelpFile = $HelpFileMapping["$($_.BaseName).md"]
    if ($moduleHelpFile -eq $null -and $Target -eq "Latest")
    {
        throw "No module help file found for module $($_.BaseName)"
    }

    $moduleSourceUrl = "$SourceBaseUri\src\$(($moduleHelpFile -split "\\src\\*")[1])".Replace("\", "/")
    $moduleEditUrl = "$EditBaseUri\src\$(($moduleHelpFile -split "\\src\\*")[1])".Replace("\", "/")

    if ($moduleHelpFile -ne $null)
    {
        $outputModules.Add("$($_.BaseName)", @{"module" = @{"sourceUrl" = $moduleSourceUrl; "editUrl" = $moduleEditUrl}; "cmdlets" = $outputCmdlets})
    }
}

$output.Add("modules", $outputModules)
$json = ConvertTo-Json $output -Depth 4
Write-Host "Index file successfully created: $OutputFile." -ForegroundColor Green;
$json | Out-File $OutputFile