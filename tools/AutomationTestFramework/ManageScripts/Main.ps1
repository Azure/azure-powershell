
. "$PSScriptRoot\GenerateAndUploadTestHelperModule.ps1"
. "$PSScriptRoot\GenerateAndUploadTestModule.ps1"
. "$PSScriptRoot\RemoveModules.ps1"
. "$PSScriptRoot\UploadSignedModules.ps1"
. "$PSScriptRoot\GenerateRunbook.ps1"
. "$PSScriptRoot\AccountRunbook.ps1"

$i_want_to = @{
    'GenerateAndUploadTestHelperModule' = $true;
    'GenerateAndUploadTestModule' = $true;
    'UploadSignedModules' = $true;
    'GenerateRunbooks' = $true;
    'UploadPublishAndStartRunbooks' = $true;
}

<#
.SYNOPSIS
Complete Automation Account TEST Framework scenario  
.PARAMETER i_want_to
Set of switches to enable or disable certain functionality
.NOTES
Prerequisite: Ready to use Azure Automation Account and Azure Storage Account container
with settings provided in the AzureConfig.ps1 file
#>
function Main ($i_want_to) {
    try {

        $foregroundColor = "DarkMagenta"

        if ($i_want_to.GenerateAndUploadTestHelperModule) {
            Write-Host "=== GenerateAndUploadTestHelperModule ========================" -ForegroundColor  $foregroundColor
            GenerateAndUploadTestHelperModule
    
        }

        $srcPath = "$PSScriptRoot\..\..\..\src\"
        
        # Project is one of the azure-powershell\src\ResourceManager subfolders
        $projectList = @('Compute', 'Storage')
        
        if ($i_want_to.GenerateAndUploadTestModule) {
            Write-Host "=== GenerateAndUploadTestModule ========================" -ForegroundColor $foregroundColor
            
            GenerateAndUploadTestsModule `
                -srcPath $srcPath `
                -projectList $projectList
        }

        if ($i_want_to.UploadSignedModules) {
            Write-Host "=== UploadSignedModuless ========================" -ForegroundColor $foregroundColor
            
            RemoveAutomationAccountModules -like "*AzureRm.*"
            
            $signedModulesPath = "E:\OneDrive - Microsoft\Projects\PowerShell\AzureAutomation\pkgs"
            
            $moduleList =  @('AzureRM.Resources', 'AzureRM.Compute', 'AzureRM.Network', 'AzureRM.Storage', 'AzureRM.Websites',  'AzureRM.KeyVault', 'AzureRM.Sql')
            
            UploadSignedModules `
                -path $signedModulesPath `
                -moduleList $moduleList
        }

        if ($i_want_to.GenerateRunbooks) {
            Write-Host "=== GenerateRunbooks ========================" -ForegroundColor $foregroundColor
            GenerateRunbooksForProject  `
                -srcPath $srcPath `
                -connectionName "AzureRunAsConnection" `
                -projectList $projectList
        }
        
        if ($i_want_to.UploadPublishAndStartRunbooks) {
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

# $i_want_to.GenerateAndUploadTestHelperModule = $false
# $i_want_to.GenerateAndUploadTestModule = $false
# $i_want_to.UploadSignedModules = $false
# $i_want_to.GenerateRunbooks = $false
# $i_want_to.UploadPublishAndStartRunbooks = $false

$i_want_to

Main $i_want_to