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
# Import-Module ./tools/BreakingChanges/GetUpcomingBreakingChange.psm1
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
        $MarkdownPath,
        [Parameter(Mandatory = $false)]
        [String[]]
        $Module
    )
    Write-Host "Gathering breaking change info from $ArtifactsPath"
    @"
# Upcoming breaking changes in Azure PowerShell

The breaking changes listed in this article are planned for the next major release of the Az
PowerShell module unless otherwise noted. Per our
[Support lifecycle](azureps-support-lifecycle.md), breaking changes in Azure PowerShell occur twice
a year with major versions of the Az PowerShell module.

Preview modules are not included in this list. Read more about [module version types](azureps-support-lifecycle.md#module-version-types).
"@ | Out-File -FilePath $MarkdownPath -Force

    if (-not $Module)
    {
        # If no specific modules are provided, gather all Az.* modules
        $Module = Get-ChildItem -Path $ArtifactsPath -Filter Az.* | ForEach-Object { $_.Name }
        Write-Host "GA modules only: false. All $($Module.Count) modules will be processed."
    }
    else
    {
        Write-Host "$($Module.Count) GA modules will be processed."
    }

    $i = 0
    $total = $Module.Count
    $Module | ForEach-Object {
        $i = $i + 1
        Write-Progress -Activity "Gathering breaking change info" -Status "Processing $_" -PercentComplete (100 * $i / $total)
        Export-BreakingChangeMessageOfModule -ArtifactsPath $ArtifactsPath -ModuleName $_ | Out-File -FilePath $MarkdownPath -Append -NoNewline
    }
}
