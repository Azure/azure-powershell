# ----------------------------------------------------------------------------------
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

param (
    [Parameter(Mandatory = $true)]
    [string] $spPassword,
    [string] $modulesDir = '',
    [bool] $createPackages = $true,
    [bool] $uploadPackages = $true,
    [bool] $processRunbooks = $true,
    [bool] $waitForResults = $true
)

. "$PSScriptRoot\Management\PackageGenerator.ps1"
. "$PSScriptRoot\Management\ModuleUploader.ps1"
. "$PSScriptRoot\Management\RunbookProcessor.ps1"

try {
    $srcPath = "$PSScriptRoot\..\..\src"
    $projectList = @('Profile', 'Compute', 'Resources', 'Storage', 'Websites', 'Network', 'Sql')
    $testResourcesDir = "$PSScriptRoot\TestResources"
    $packagingDir = "$PSScriptRoot\Package"
    $helperModuleName = 'Smoke.Helper'
    $testModuleName = 'Smoke.Tests'
    $runbooksPath = "$PSScriptRoot\Runbooks"
    $success = $false

    $automation = @{
        ResourceGroupName = 'azposjhautomation';
        AccountName = 'azposhautomation'
    }

    $storage = @{
        ResourceGroupName = 'transit2automation';
        AccountName = 'transit2automation';
        ContainerName = 'testsmodule'
    }

    $template = @{
        SubscriptionName = 'Azure SDK Powershell Test';
        AutomationConnectionName = 'AzureRunAsConnection';
        Path = "$testResourcesDir\RunbookTemplate.ps1"
    }

    $signedModuleList = @('AzureRM.Automation', 'AzureRM.Compute','AzureRM.Resources', 'AzureRM.Storage', 'AzureRM.Websites', 'AzureRM.Network', 'AzureRM.Sql')
    # Profile is required to be uploaded first. Storage is required second (for AzureRm.Storage). Then, the rest of the order doesn't matter.
    # Note: These are lists so that the addition operation is handled properly.
    $signedModules = @{
        Profile = @('AzureRM.Profile');
        Storage = @('Azure.Storage');
    }
    # https://stackoverflow.com/a/38685717/294804
    $signedModules.Other = $signedModuleList | Where-Object { ($signedModules.Profile + $signedModules.Storage) -inotcontains $_ }

    Import-Module AzureRm.Profile
    Import-Module AzureRm.Storage
    Import-Module AzureRm.Automation

    # TODO: Allow this to be provided. For now, use a hard-coded service principal.
    # Login as the service principal
    $password = ConvertTo-SecureString -String $spPassword -AsPlainText -Force
    $creds = New-Object -TypeName 'System.Management.Automation.PSCredential' -ArgumentList '512d9f44-dacc-4a72-8bab-3ff8362d14b7', $password
    Login-AzureRmAccount -Credential $creds -ServicePrincipal -TenantId 72f988bf-86f1-41af-91ab-2d7cd011db47 -Subscription 'Azure SDK Infrastructure'

    if($createPackages) {
        Write-Verbose '=== Create Packages ========================'
        Create-HelperModule `
            -moduleDir $testResourcesDir `
            -moduleName $helperModuleName `
            -archiveDir $packagingDir
        Create-SignedModules `
            -signedModules $signedModules `
            -modulesDir $modulesDir `
            -archiveDir $packagingDir
        Create-SmokeTestModule `
            -srcPath $srcPath `
            -archiveDir $packagingDir `
            -moduleName $testModuleName `
            -projectList $projectList
        Write-Verbose '============================================='
    }

    if($uploadPackages) {
        Write-Verbose '=== Upload Modules ========================'
        Upload-Modules `
            -automation $automation `
            -storage $storage `
            -signedModules $signedModules `
            -archiveDir $packagingDir
            Write-Verbose '============================================='
    }

    if($processRunbooks) {
        Write-Verbose '=== Process Runbooks ========================'
        Create-Runbooks `
            -template $template `
            -srcPath $srcPath `
            -projectList $projectList `
            -outputPath $runbooksPath
        $jobs = Start-Runbooks `
            -automation $automation `
            -runbooksPath $runbooksPath
        if ($waitForResults) {
            $success = Wait-RunbookResults `
                -automation $automation `
                -jobs $jobs
        }
        Write-Verbose '============================================='
    }

    Write-Verbose '=== All Done ========================'
    # If at least one suite failed, exit with failure
    if (-not $success) {
        exit 1
    }
} catch {
    Write-Host "Something went wrong: $_" -ForegroundColor Red
    $_.ScriptStackTrace.Split([Environment]::NewLine) | Where-Object { $_.Length -gt 0 } | ForEach-Object { Write-Verbose "`t$_" }
    exit 1
}

exit 0