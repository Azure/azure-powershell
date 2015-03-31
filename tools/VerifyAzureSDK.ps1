$scriptFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
. ($scriptFolder + '.\SetupEnv.ps1')

Import-Module "$env:AzurePSRoot\src\Package\Debug\ServiceManagement\azure\Azure.psd1"

Write-Host "***Please read. this script requires the following product***"  -ForegroundColor "Red"
Write-Host "**Node.js for Windows (32-bits) at http://nodejs.org/download/ and Azure Node.js for Windows at http://azure.microsoft.com/en-us/downloads/" -ForegroundColor "Red"
Write-Host "**Azure PHP for Windows at http://azure.microsoft.com/en-us/downloads/." -ForegroundColor "Yellow"
Write-Host "**It is recommended to reboot the machine after the setup, or at least relaunch the powershell." -ForegroundColor "Red"

# create testing folder
$testFolder = "$env:AzurePSRoot\src\Package\" + [System.IO.Path]::GetRandomFileName()
md $testFolder
cd $testFolder 

New-AzureServiceProject PHPTest
Add-AzurePHPWebRole
Add-AzurePHPWorkerRole
Start-AzureEmulator -v

Write-Host "You can do some testing by loading role url in the browser and make sure PHP default pages loads" -ForegroundColor "Yellow"
Write-Host "Press any key to continue to the next testing"
$keyPressed = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")