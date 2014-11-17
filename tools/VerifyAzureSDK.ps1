$scriptFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
. ($scriptFolder + '.\SetupEnv.ps1')

Import-Module "$env:AzurePSRoot\src\Package\Debug\ServiceManagement\azure\Azure.psd1"

Write-Host "***Please read. this script requires the following product***"  -ForegroundColor "Red"
Write-Host "**Node.js for Windows (32-bits) at http://nodejs.org/download/ and Azure Node.js for Windows at http://azure.microsoft.com/en-us/downloads/" -ForegroundColor "Red"
Write-Host "**Azure PHP for Windows at http://azure.microsoft.com/en-us/downloads/." -ForegroundColor "Yellow"
Write-Host "**It is recommended to reboot the machine after the setup, or at least relaunch the powershell." -ForegroundColor "Red"

Write-Host "Testing Caching role with MemCacheShim package, Node Web Role, and run under emulators" -ForegroundColor "Green"
#detect nodejs for x86 is installed, if not install it

# create testing folder
$testFolder = "$env:AzurePSRoot\src\Package\Debug\SDKTest" + [System.IO.Path]::GetRandomFileName()
md $testFolder
cd $testFolder 

New-AzureServiceProject MemCacheTestWithNode
# the 'ClientRole' is coupled with the client script, do not change it unless you update the script as well 
Add-AzureNodeWebRole ClientRole
Add-AzureCacheWorkerRole CacheRole
Enable-AzureMemcacheRole ClientRole CacheRole

md "temp"
Copy-Item "$env:AzurePSRoot\src\Common\Commands.ScenarioTest\Resources\CloudService\Cache\*.js" ".\ClientRole\"  -Force -Recurse
cd "$testFolder\MemCacheTestWithNode\ClientRole"
Start-Process "npm" "install $env:AzurePSRoot\src\Common\Commands.ScenarioTest\Resources\CloudService\Cache\mc.tgz $env:AzurePSRoot\src\Common\Commands.ScenarioTest\Resources\CloudService\Cache\connman.tgz" -Wait

cd "$testFolder\MemCacheTestWithNode"
Start-AzureEmulator -v

Write-Host "You can do some testing by loading role url in the browser and adding some key/value to mem cache emulators" -ForegroundColor "Yellow"
Write-Host "Press any key to continue to the next testing"
$keyPressed = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

# testing full emulator
Start-AzureEmulator -mode Full -v
Write-Host "You can do similar testing like you did just now. The only context difference is you are using a full emulator this time" -ForegroundColor "Yellow"
Write-Host "Press any key to continue to the next testing"
$keyPressed = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

Write-Host "Testing PHP web & worker roles with emulator" -ForegroundColor "Green" 
cd $testFolder
New-AzureServiceProject MyPHPTest
Add-AzurePHPWebRole
Add-AzurePHPWorkerRole
Start-AzureEmulator -v

Write-Host "You can do some testing by loading role url in the browser and make sure PHP default pages loads" -ForegroundColor "Yellow"
Write-Host "Press any key to continue to the next testing"
$keyPressed = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

Write-Host "Testing Django web roles" -ForegroundColor "Green"
cd $testFolder
New-AzureServiceProject MyDjangoTest
Add-AzureDjangoWebRole
Start-AzureEmulator -v 
Write-Host "You can do some testing by loading role url in the browser and make sure default django page loads fine " -ForegroundColor "Yellow"