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

param(
    [Parameter(Mandatory = $false, Position = 0)]
    [bool]$generateAndUploadTestHelperModule = $true,
    [Parameter(Mandatory = $false, Position = 1)]
    [bool]$generateAndUploadTestModule = $true,
    [Parameter(Mandatory = $false, Position = 2)]
    [bool]$uploadSignedModules = $true,
    [Parameter(Mandatory = $false, Position = 3)]
    [bool]$generateRunbooks = $true,
    [Parameter(Mandatory = $false, Position = 4)]
    [bool]$uploadPublishAndStartRunbooks = $true,
    [Parameter(Mandatory = $false, Position = 5)]
    [string]$signedModulesPath
)

. "$PSScriptRoot\GenerateAndUploadTestHelperModule.ps1"
. "$PSScriptRoot\GenerateAndUploadTestModule.ps1"
. "$PSScriptRoot\RemoveModules.ps1"
. "$PSScriptRoot\UploadSignedModules.ps1"
. "$PSScriptRoot\GenerateRunbook.ps1"
. "$PSScriptRoot\AccountRunbook.ps1"

try {

    if ($generateAndUploadTestHelperModule) {
        Write-Verbose "=== GenerateAndUploadTestHelperModule ========================"
        GenerateAndUploadTestHelperModule
    }

    $srcPath = "$PSScriptRoot\..\..\..\src\"
    
    # Project is one of the azure-powershell\src\ResourceManager subfolders
    $projectList = @('Compute', 'Storage')
    
    if ($generateAndUploadTestModule) {
        Write-Verbose "=== GenerateAndUploadTestModule ========================"
        
        GenerateAndUploadTestsModule `
            -srcPath $srcPath `
            -projectList $projectList
    }

    if ($uploadSignedModules) {
        Write-Verbose "=== UploadSignedModuless ========================"
        
        RemoveAutomationAccountModules -like "*AzureRm.*"
        
        #$signedModulesPath = "\\aaptfile01\ADXSDK\PowerShell\2017_10_12_PowerShell\pkgs"
        if ([string]::IsNullOrEmpty($signedModulesPath)) {
            #get the latest drop by searching on 20\d\d_\d\d_PowerShell and getting the pkgs child item from that directory
            $latestBitsPath = GetLatestBitsPath -searchPath '\\aaptfile01\ADXSDK\PowerShell'
            Write-Verbose "Latest drop path found:  $latestBitsPath"
            $signedModulesPath = Join-Path $latestBitsPath 'pkgs'
        }

        # AzureRM.Automation and AzureRM.Storage modules are required to store runbooks streams in Azure container. 
        $moduleList =  @('AzureRM.Resources', 'AzureRM.Compute', 'AzureRM.Automation', 'AzureRM.Network', 'AzureRM.Storage', 'AzureRM.Websites',  'AzureRM.KeyVault', 'AzureRM.Sql')
        
        UploadSignedModules `
            -path $signedModulesPath `
            -moduleList $moduleList
    }

    if ($generateRunbooks) {
        Write-Verbose "=== GenerateRunbooks ========================"
        GenerateRunbooksForProject  `
            -srcPath $srcPath `
            -connectionName "AzureRunAsConnection" `
            -projectList $projectList
    }
    
    if ($uploadPublishAndStartRunbooks) {
        Write-Verbose "=== UploadPublishAndStartRunbooks ========================"
        RemoveRunbookFromAutomationAccount -like "Live*Tests*"
        UploadPublishAndStartRunbooks
    }

    Write-Verbose "=== All done ========================"

} catch {
    Write-Host "Something went wrong: $PSItem" -ForegroundColor Red
    ($PSItem.ScriptStackTrace).Split([Environment]::NewLine) | Where-Object {$_.Length -gt 0} | ForEach-Object { Write-Verbose "`t$_" }
}
