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
    [Parameter(Mandatory = $false, Position = 1)]
    [string]$Artifacts,

    [Parameter(Mandatory = $false, Position = 5)]
    [string]$NugetExe
)

<#################################################
#
#               Helper functions
#
#################################################>

<#
.SYNOPSIS Write out to a file using UTF-8 without BOM.
.PARAMETER File
The file to write the contents too.
.PARAMETER Text
The new file contents.
#>
function Out-FileNoBom {
    param(
        [System.string]$File,
        [System.string]$Text
    )
    $encoding = New-Object System.Text.UTF8Encoding $False
    [System.IO.File]::WriteAllLines($File, $Text, $encoding)
}

<#
.SYNOPSIS Update license acceptance to be required.
.PARAMETER TempRepoPath
Path to the local temporary repository.
.PARAMETER ModuleName
Name of the module to update.
.PARAMETER DirPath
Path to the directory holding the modules to update.
.PARAMETER NugetExe
Path to the Nuget executable.
#>
function Update-NugetPackage {
    [CmdletBinding()]
    param(
        [string]$TempRepoPath,
        [string]$ModuleName,
        [string]$DirPath,
        [string]$NugetExe
    )

    PROCESS {
        $regex2 = "<requireLicenseAcceptance>false</requireLicenseAcceptance>"

        $relDir = Join-Path $DirPath -ChildPath "_rels"
        $contentPath = Join-Path $DirPath -ChildPath '`[Content_Types`].xml'
        $packPath = Join-Path $DirPath -ChildPath "package"
        $modulePath = Join-Path $DirPath -ChildPath ($ModuleName + ".nuspec")

        # Cleanup
        Remove-Item -Recurse -Path $relDir -Force
        Remove-Item -Recurse -Path $packPath -Force
        Remove-Item -Path $contentPath -Force

        # Create new output
        $content = (Get-Content -Path $modulePath) -join "`r`n"
        $content = $content -replace $regex2, ("<requireLicenseAcceptance>true</requireLicenseAcceptance>")
        Out-FileNoBom -File $modulePath -Text $content

        # https://stackoverflow.com/a/36369540/294804
        &$NugetExe pack $modulePath -OutputDirectory $TempRepoPath -NoPackageAnalysis
    }
}

<###################################
#
#           Setup/Execute
#
###################################>

if ([string]::IsNullOrEmpty($Artifacts)) {
    Write-Verbose "Artifacts was not provided, use default $PSScriptRoot\..\artifacts"
    $Artifacts = Join-Path $PSScriptRoot -ChildPath ".." | Join-Path -ChildPath "artifacts"
}

if ([string]::IsNullOrEmpty($NugetExe)) {
    Write-Verbose "NugetExe was not provided, use default $PSScriptRoot\NuGet.exe"
    $NugetExe = Join-Path $PSScriptRoot -ChildPath "NuGet.exe"
}

$tmp = Join-Path -Path (Get-Item $Artifacts).FullName -ChildPath "tmp"

# Validate tmp folder
if (!(Test-Path -Path $tmp)) {
    throw "tmp folder doesn't exist"
}

try {
    foreach ($artifact in Get-ChildItem $tmp -Directory) {
        $artifactDir = ($artifact).Name
        $tokens = $artifactDir.split(".")
        if($tokens.length -gt 1) {
            # Az.n.n.n.nuget or Az.module.n.n.n.nuget
            if($tokens.length -gt 5) {
                $module_name = $tokens[0]+"."+$tokens[1]
            } else {
                $module_name = $tokens[0]
            }
        } else {
            $module_name = $artifactDir
        }
        Write-Output "Repackaging $module_name under $artifactDir"
        Update-NugetPackage -TempRepoPath (Get-Item $Artifacts).FullName -ModuleName $module_name -DirPath $tmp"\"$artifactDir -NugetExe $NugetExe
    } 
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
} finally {
    Write-Output "Removing temporary folder $tmp"
    Remove-Item -Recurse $tmp -Force -ErrorAction Stop
}
