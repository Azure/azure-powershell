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
.SYNOPSIS Generates az-ps-latest.csv as the feed of online csharp reference publishing according to feed psd1.
#>
Param(
    [Parameter(Mandatory = $true)]
    [string]$FeedPsd1FullPath,
    [Parameter(Mandatory = $false)]
    [string]$CustomSource = "https://azpspackage.blob.core.windows.net/docs-release",
    [Parameter(Mandatory = $false)]
    [string]$SourceType = "sa"
)

$feedDir = (Get-Item $FeedPsd1FullPath).Directory
$feedName = (Get-Item $FeedPsd1FullPath).Name
Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $feedDir -FileName $feedName
$modules = $ModuleMetadata.RequiredModules

$dotnetCsv = New-Item -Path "$PSScriptRoot\" -Name "az-ps-latest.csv" -ItemType "file" -Force
$dotnetCsvContent = ""

for ($index = 0; $index -lt $modules.Count; $index++){
    $moduleName = $modules[$index].ModuleName
    $moduleVersion = [string]::IsNullOrEmpty($modules[$index].RequiredVersion) ? $modules[$index].ModuleVersion : $modules[$index].RequiredVersion
    $dotnetCsvLine = ""
    switch ($SourceType) {
        "sa" { 
            $dotnetCsvLine = "pac$index,[ps=true;customSource=$CustomSource/$moduleName.$moduleVersion.zip;sourceType=$SourceType]$moduleName,$moduleVersion`n"
            break
        }
        Default {
            $dotnetCsvLine = "pac$index,[ps=true;customSource=$CustomSource]$moduleName,$moduleVersion`n"
        }
    }
    $dotnetCsvContent += $dotnetCsvLine
}
Set-Content -Path $dotnetCsv.FullName -Value $dotnetCsvContent -Encoding UTF8




