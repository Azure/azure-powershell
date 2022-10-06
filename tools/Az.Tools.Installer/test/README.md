## Test Scenario

### Automation Tests
- Install-AzModule.Tests.ps1
- Update-AzModule.Tests.ps1
- Uninstall-AzModule.Tests.ps1
- Az.Tools.Installer.Tests.Helper.ps1 helper functions used in tests

### Common cases
Test platform: PowerShell 7.0, Windows PowerShell
|Scenario\Installer Method|Install-AzModule|Update-AzModule|Uninstall-AzModule|
|----|----|----|----|
|RunByWhatIf|Y|Y|Y|
|RunByDebug|Y|Y|Y||
|RunByInteractivelyComfirm|Y|Y|Y|
|RunByAllUserScopeUsingAdmin|Y|Y|N|
|RunByAllUserScopeUsingNonAdmin|Y|Y|N|

### Uninstall modules when module installed in Admin Path and User Path
- `Install-Module -Repository PSGallery -Name Az.Storge -RequiredVersion 3.10.0`
- `Install-Module -Repository PSGallery -Name Az.Storge -Scope AllUsers (Run as Admin)`
- Uninstall-AzModule -Name storage as common user
  -Expected behaviour: no module uninstalled
- Uninstall-AzModule -Name storage as admin
  -Expected behaviour: Az.Storage is uninstalled

### Uninstall modules when modules are in use
- Expected behvaiour: powershell get will thrown an exception

### RunWithErrorPreferenceAsStop
- Run with `$ErrorActionPreference = 'Stop'`
- Run with `$ErrorActionPreference = 'Continue'`

### RunWithNoProgressBar
- Run with `$ProgressPreference = "SilentlyContinue"`
- Check the progress bar of Install-AzModule, Update-AzModule, Uninstall-AzModule

### RunWithPartiallyInstallationException
- `Install-AzModule -Repository PSGallery -Debug`
- input Y when the cmdlet for the comfirmation before install Az.Accounts
- Refer to the path of nuget packages downloaded in the debug message and removed few packages before install packages from local
- You can input A after the previous step
- check the subsequent output of the cmdlet and the output table

### Run with single registered PowerShell repository
- Save your current registered repo
- Remove all the repos except PSGallery
- Run `Install-AzModule -Name storage -RequiredAzVersion 6.3` and `Update-AzModule storage`

### RunWhenJobResourcesOccupied(Only for Windows PowerShell)
- Step
```
$jobs = @()
foreach ($i in 1..5) {
    $jobs += Start-Job {Start-Sleep -Seconds 10000}
}

Install-AzModule -Repository PSGallery -Name storage,compute,network,resources,keyvault

$jobs | Stop-Job
$jobs | Remove-Job
```
- Expected result
```
[Install-AzModule] You have enough background jobs currently. Please use 'Get-Job -State Running' to check them.
At D:\workspace\azure-powershell\tools\Az.Tools.Installer\internal\Install-AzModuleInternal.ps1:230 char:33
+ ...             Throw "[$Invoker] Some background jobs are blocked. Pleas ...
+                 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : OperationStopped: ([Install-AzModu... to check them.:String) [], RuntimeException
    + FullyQualifiedErrorId : [Install-AzModule] Some background jobs are blocked. Please use 'Get-Job -State Running' to check them.
```

### ImportModuleWithPowerShellGet3.+Installed
- Step
```
Install-Module -Name PowerShellGet -Repository PSGallery
Install-Module -Name PowerShellGet -Repository PSGallery -RequiredVersion 3.0.11-beta -AllowPrerelease
Import-Module Az.Tools.Installer
Get-Module -Name PowerShellGet
```
- Expected result
  - PowerShellGet 2.+ (no earlier than 2.1.3) is imported
