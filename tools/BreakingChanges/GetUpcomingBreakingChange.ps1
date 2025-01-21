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

# To get upcoming breaking change info, you need to build az first
# ```powershell
# dotnet msbuild build.proj /t:build /p:configuration=Debug
# Import-Module ./tools/BreakingChanges/GetUpcomingBreakingChange.ps1
# Export-AllBreakingChangeMessageUnderArtifacts -ArtifactsPath ./artifacts/Debug/ -MarkdownPath ./documentation/breaking-changes/upcoming-breaking-changes.md
# ```

Import-Module (Join-Path $PSScriptRoot "Get-BreakingChangeMetadata.ps1") -Force

Function Export-BreakingChangeMessageOfModule
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [String]
        $ArtifactsPath,
        [Parameter()]
        [String]
        $ModuleName
    )
    $ModuleBreakingChangeInfo = Get-BreakingChangeMetadata -ArtifactsPath $ArtifactsPath -ModuleName $ModuleName
    If ($ModuleBreakingChangeInfo.Count -eq 0)
    {
        Return ""
    }
    $Result = "`n## $ModuleName`n"

    ForEach ($CmdletName In ($ModuleBreakingChangeInfo.Keys | Sort-Object))
    {
        $Result += "`n### ``$CmdletName```n"
        $Result += Export-BreakingChangeMessageOfCmdlet $ModuleBreakingChangeInfo[$CmdletName]
    }

    Return $Result
}

Function Export-AllBreakingChangeMessageUnderArtifacts
{
    [CmdletBinding()]
    Param (
        [Parameter()]
        [String]
        $ArtifactsPath,
        [Parameter()]
        [String]
        $MarkdownPath
    )
    $Result = "# Upcoming breaking changes in Azure PowerShell`n"
    $AllModuleList = Get-ChildItem -Path $ArtifactsPath -Filter Az.* | ForEach-Object { $_.Name }
    ForEach ($ModuleName In $AllModuleList)
    {
        if ($ModuleName -ne "Az.Monitor")
        {
            $Result += Export-BreakingChangeMessageOfModule -ArtifactsPath $ArtifactsPath -ModuleName $ModuleName
        }

    }
    $Result | Out-File -FilePath $MarkdownPath -Force
}