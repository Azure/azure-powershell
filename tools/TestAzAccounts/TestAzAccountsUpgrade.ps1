[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string]
    $AzAccountsVersionFrom,

    [Parameter(Mandatory = $true)]
    [string]
    $AzAccountsVersionTo,

    [Parameter(Mandatory = $true)]
    [string]
    $Path,

    [Parameter(Mandatory = $true)]
    [string]
    $PfxFileName,

    [Parameter()]
    [string]
    $FederatedToken
)

$module = Get-Module -Name "CertificateUtility"
if ($null -eq $module)
{
    Import-Module "$PSScriptRoot/CertificateUtility.psm1"
}

#$accountsVersion = Set-TestEnvironment -AzVersion $AzVersionUpgradeFrom -NugetPath $NugetPath
#Install-AzModule -RequiredAzVersion 10.4.1 -Repository PSGallery
#Install-Module -Name Az.Accounts -Repository PSGallery -AllowPrerelease -Scope CurrentUser -Force

$importAzAccounts = "Import-Module Az.Accounts -RequiredVersion $AzAccountsVersionFrom`n"
$getToken = "Import-Module Az.Accounts`nGet-Module -Name Az.Accounts`nGet-AzAccessToken"

$baseCommand = @"
Get-Module -Name Az.Accounts
."$PSScriptRoot/ConnectAzAccountLiveTest.ps1" -ServicePrincipalName "AzAccountsTest" -CredentialPrefix "AzAccountsTest"
"@

$smokeTest = @"
Import-Module Az.Accounts
Get-Module -Name Az.Accounts
(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/main/tools/Test/SmokeTest/RmCoreSmokeTests.ps1").Content | Invoke-Expression
"@

function Test-AzAccountsUpgrade
{
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $SpecialParamString,

        [Parameter(Mandatory = $true)]
        [bool]
        $UseWindowsPowerShell
    )

    Write-Host 'Connect Using the previous Az.Accounts:'
    $connectCommand = $baseCommand + " $($specialParamString) -ClearContext`n"
    $command = $importAzAccounts + $connectCommand
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell
    
    Write-Host 'Accquire Token Using the Test Version:'
    Invoke-PowerShellCommand -ScriptBlock "`{$getToken`}" -UseWindowsPowerShell:$UseWindowsPowerShell
    
    Write-Host 'Connect AzAccounts Using the Test Version:'
    $command = $connectCommand
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell
}

$useWindowsPowerShell = $PSVersionTable.PSEdition -eq "Desktop"

Write-Host '--------------------Test ClientAssertion---------------------------------'
$specialParams = "-UseFederatedToke -FederatedToken $FederatedToken"
Test-AzAccountsUpgrade -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
Write-Host 'Press any key to continue'
$null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

Write-Host '--------------------Test ClientSecret------------------------------------'
Test-AzAccountsUpgrade -SpecialParamString '-UsePassword' -UseWindowsPowerShell $useWindowsPowerShell
Write-Host 'Press any key to continue'
$null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

Write-Host '--------------------Test ClientCertificateFile---------------------------'
$specialParams = "-UseCertificateFile -Path $Path -PfxFileName $PfxFileName"
Test-AzAccountsUpgrade -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
Write-Host 'Press any key to continue'
$null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

if ($useWindowsPowerShell -or $IsWindows)
{
    Write-Host '--------------------Test ClientCertificateThumbprint---------------------'
    $specialParams = "-UseThumbprint -Path $Path -PfxFileName $PfxFileName"
    Test-AzAccountsUpgrade -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    Write-Host 'Press any key to continue'
    $null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

Write-Host '--------------------Run Smoke Test----------------------------------------'
function Run-SmokeTest
{
    param (
        [Parameter(Mandatory = $true)]
        [bool]
        $UseWindowsPowerShell
    )
    Write-Host 'Run smoke test using the test version:'
    Invoke-PowerShellCommand -ScriptBlock $smokeTest -UseWindowsPowerShell:$useWindowsPowerShell
}
#Run-SmokeTest -UseWindowsPowerShell $false


