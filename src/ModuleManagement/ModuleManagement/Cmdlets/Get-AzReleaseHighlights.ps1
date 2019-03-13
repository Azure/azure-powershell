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
Returns release highlights for the specified release.
#>
function Get-AzReleaseHighlights
{
    [CmdletBinding()]
    [OutputType([System.String])]
    param
    (
        [Parameter(ParameterSetName = 'Latest', Mandatory = $false)]
        [switch]$Latest,

        [Parameter(ParameterSetName = 'Version', Mandatory = $true)]
        [System.Version]$Version,

        [Parameter(Mandatory = $false)]
        [switch]$Online
    )

    $page = (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/master/ChangeLog.md" -TimeoutSec 5).Content -split '\n'

	$isVersionSection = $false
	$isHighlightsSection = $false
	$releaseVersionFound = $false
	$versionCount = 0

	if ($Version -eq $null) {
		$AzModule = $env:PSModulePath -split ';' | ForEach-Object { Get-ChildItem -Path $_ } | Where-Object { $_.Name -eq "Az"}
		$Versions = $AzModule | ForEach-Object { Get-ChildItem -Path $_.FullName } | ForEach-Object { [System.Version]::Parse($_.Name) } | Sort-Object
		if ($Versions -eq $null)
		{
			$Latest = $true
		}
		else
		{
			$Version = [System.Version]::Parse($Versions[-1])
		}
	}
	
	if ($Latest) {
		$isVersionSection = $true
		$first, $rest = $page
		$page = $rest
		$releaseVersionFound = $true
	}

	$page | ForEach-Object { 
		if ($_ -like "*## *$Version*" -and $Version -ne $null) {
			$isVersionSection = $true
			$releaseVersionFound = $true
		}
		elseif ($_ -like "## *") {
			$isVersionSection = $false
			if (!$releaseVersionFound)
			{
				$versionCount = $versionCount + 1
			}
		}
		elseif ($isVersionSection)
		{
			if ($_ -like "*### Highlights*" ) {
				$isHighlightsSection = $true
			}
			elseif ($_ -like "*### *")
			{
				$isHighlightsSection = $false
			}
			elseif ($isHighlightsSection) {
				Write-Output $_
			}
		}
	}

	if (!$releaseVersionFound) {
		Write-Warning "Version $Version was not found."
	}

	if ($Online -and $releaseVersionFound) {
		if ($versionCount -eq 0)
		{
			Start-Process "https://github.com/Azure/azure-powershell/blob/master/ChangeLog.md#highlights-since-the-last-major-release"
		}
		else
		{
			Start-Process "https://github.com/Azure/azure-powershell/blob/master/ChangeLog.md#highlights-since-the-last-major-release-$versionCount"
		}
	}
}