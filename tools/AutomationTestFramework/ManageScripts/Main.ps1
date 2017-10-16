
. "$PSScriptRoot\GenerateAndUploadTestHelperModule.ps1"
. "$PSScriptRoot\GenerateAndUploadTestModule.ps1"
. "$PSScriptRoot\RemoveModules.ps1"
. "$PSScriptRoot\UploadSignedModules.ps1"
. "$PSScriptRoot\GenerateRunbook.ps1"
. "$PSScriptRoot\AccountRunbook.ps1"

<#
.SYNOPSIS
Complete Automation Account TEST Framework scenario  
.PARAMETER i_want_to
Set of switches to enable or disable certain functionality
.NOTES
Prerequisite: Ready to use Azure Automation Account and Azure Storage Account container
with settings provided in the AzureConfig.ps1 file
#>
function Main (
     [bool]$generateAndUploadTestHelperModule = $true
    ,[bool]$generateAndUploadTestModule = $true
    ,[bool]$uploadSignedModules = $true
    ,[bool]$generateRunbooks = $true
    ,[bool]$uploadPublishAndStartRunbooks = $true) {

    try {

        $foregroundColor = "DarkMagenta"

        if ($generateAndUploadTestHelperModule) {
            Write-Host "=== GenerateAndUploadTestHelperModule ========================" -ForegroundColor  $foregroundColor
            GenerateAndUploadTestHelperModule
    
        }

        $srcPath = "$PSScriptRoot\..\..\..\src\"
        
        # Project is one of the azure-powershell\src\ResourceManager subfolders
        $projectList = @('Compute', 'Storage')
        
        if ($generateAndUploadTestModule) {
            Write-Host "=== GenerateAndUploadTestModule ========================" -ForegroundColor $foregroundColor
            
            GenerateAndUploadTestsModule `
                -srcPath $srcPath `
                -projectList $projectList
        }

        if ($uploadSignedModules) {
            Write-Host "=== UploadSignedModuless ========================" -ForegroundColor $foregroundColor
            
            RemoveAutomationAccountModules -like "*AzureRm.*"
            
            $signedModulesPath = "\\aaptfile01\ADXSDK\PowerShell\2017_10_12_PowerShell\pkgs"

            # AzureRM.Automation and AzureRM.Storage modules are required to store runbooks streams in Azure container. 
            $moduleList =  @('AzureRM.Resources', 'AzureRM.Compute', 'AzureRM.Automation', 'AzureRM.Network', 'AzureRM.Storage', 'AzureRM.Websites',  'AzureRM.KeyVault', 'AzureRM.Sql')
            
            UploadSignedModules `
                -path $signedModulesPath `
                -moduleList $moduleList
        }

        if ($generateRunbooks) {
            Write-Host "=== GenerateRunbooks ========================" -ForegroundColor $foregroundColor
            GenerateRunbooksForProject  `
                -srcPath $srcPath `
                -connectionName "AzureRunAsConnection" `
                -projectList $projectList
        }
        
        if ($uploadPublishAndStartRunbooks) {
            Write-Host "=== UploadPublishAndStartRunbooks ========================" -ForegroundColor $foregroundColor
            RemoveRunbookFromAutomationAccount -like "Live*Tests*"
            UploadPublishAndStartRunbooks
        }

        Write-Host "=== All done ========================" -ForegroundColor $foregroundColor

    } catch {
        Write-Host "Something went wrong: " $PSItem.ToString() -ForegroundColor Red
        ($PSItem.ScriptStackTrace).Split([Environment]::NewLine) | Where-Object {$_.Length -gt 0} | ForEach-Object { Write-Host "`t$_" -ForegroundColor Red }
    }
}