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
# the hardline is calculated by the number of cmdlet, may adjust if one of two repos is out-of-memory
$hardlineForSplittingRepo = "Az.MobileNetwork"
$dotnetCsv1 = New-Item -Path "$PSScriptRoot\" -Name "az-ps-latest-1.csv" -ItemType "file" -Force
$dotnetCsv2 = New-Item -Path "$PSScriptRoot\" -Name "az-ps-latest-2.csv" -ItemType "file" -Force
$dotnetCsvContent1 = ""
$dotnetCsvContent2 = ""
$index1 = 0
$index2 = 1

foreach($module in $modules){
    $moduleName = $module.ModuleName
    $moduleVersion = [string]::IsNullOrEmpty($module.RequiredVersion) ? $module.ModuleVersion : $module.RequiredVersion
    # Az.Accounts should be included in repo2 as well
    if($moduleName -eq "Az.Accounts"){
        $dotnetCsvContent2 = "pac0,[ps=true;customSource=$CustomSource/$moduleName.$moduleVersion.zip;sourceType=$SourceType]$moduleName,$moduleVersion`n"
    }
    $index = ($moduleName -le $hardlineForSplittingRepo) ? $index1 : $index2
    switch ($SourceType) {
        "sa" { 
            $dotnetCsvLine = "pac$index,[ps=true;customSource=$CustomSource/$moduleName.$moduleVersion.zip;sourceType=$SourceType]$moduleName,$moduleVersion`n"
            break
        }
        Default {
            $dotnetCsvLine = "pac$index,[ps=true;customSource=$CustomSource]$moduleName,$moduleVersion`n"
        }
    }
    if($moduleName -le $hardlineForSplittingRepo){
        $dotnetCsvContent1 += $dotnetCsvLine
        $index1 =  $index1 + 1
    }else{
        $dotnetCsvContent2 += $dotnetCsvLine
        $index2 =  $index2 + 1
    }    
}

Set-Content -Path $dotnetCsv1.FullName -Value $dotnetCsvContent1 -Encoding UTF8
Set-Content -Path $dotnetCsv2.FullName -Value $dotnetCsvContent2 -Encoding UTF8