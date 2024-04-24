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

# The generated excel will contains one sheet. The title is:
# ModuleName, CmdletName, Description, Before, After, TeamMember, PR

# .\tools\BreakingChanges\GenerateMigrationExcel.ps1 -ExcelPath (Join-Path $env:USERPROFILE "Documents" "2024-05-21-Az-12.0-Breaking-Change-Migration-Guide.xlsx")

#Requires -Modules PSExcel
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ExcelPath
)
If (Test-Path $ExcelPath) {
    Remove-Item $ExcelPath
}
$Path = [System.IO.Path]::Combine($PSScriptRoot, '..', '..')
Set-Location -Path $Path
# dotnet msbuild /t:Clean
# dotnet msbuild /t:Build
# dotnet msbuild /t:StaticAnalysis

Import-Module (Join-Path $PSScriptRoot "Get-BreakingChangeMetadata.ps1") -Force
$ArtifactsPath = [System.IO.Path]::Combine($Path, "artifacts", "Debug")

$AllModuleList = Get-ChildItem -Path $ArtifactsPath -Filter Az.* | ForEach-Object { $_.Name }
$Data = New-Object System.Collections.ArrayList
ForEach ($ModuleName In $AllModuleList)
{
    Write-Host "Processing Module: $ModuleName"
    $ModuleBreakingChangeInfo = Get-BreakingChangeMetadata -ArtifactsPath $ArtifactsPath -ModuleName $ModuleName
    If ($ModuleBreakingChangeInfo.Count -eq 0)
    {
        Continue
    }

    ForEach ($CmdletName In ($ModuleBreakingChangeInfo.Keys | Sort-Object))
    {
        Write-Host "Processing Cmdlet: $ModuleName - $CmdletName"
        $NewRow = New-Object -TypeName PSObject -Property @{
            ModuleName = $ModuleName
            CmdletName = $CmdletName
            Description = Export-BreakingChangeMessageOfCmdlet $ModuleBreakingChangeInfo[$CmdletName]
            Before = $Null
            After = $Null
            TeamMember = $Null
            PR = $Null
        } | Select-Object ModuleName, CmdletName, Description, Before, After, TeamMember, PR
        $Null = $Data.Add($NewRow)
    }
}

$Data | Export-XLSX -Path $ExcelPath
Write-Host "Excel is generated at $ExcelPath. Please goto edit it."