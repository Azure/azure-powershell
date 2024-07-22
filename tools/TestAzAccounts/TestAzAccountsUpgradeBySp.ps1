[CmdletBinding()]
param (
    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [Switch]
    $UseCertificateFile,

    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [Switch]
    $UseThumbprint,

    [Parameter(ParameterSetName = 'Password', Mandatory = $true)]
    [Switch]
    $UsePassword,

    [Parameter(ParameterSetName = 'FederatedToken', Mandatory = $true)]
    [Switch]
    $UseFederatedToken,

    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [string]
    $Path,

    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [string]
    $PfxFileName,

    [Parameter(ParameterSetName = 'FederatedToken', Mandatory = $true)]
    [string]
    $FederatedToken,

    [Parameter()]
    [string]
    $AzAccountsVersionFrom,

    [Parameter(Mandatory = $true)]
    [string]
    $AzAccountsVersionTo,

    [Switch]
    $RunSmokeTest,

    [Switch]
    $RunInAutomation
)

if ($AzAccountsVersionFrom)
{
    try 
    {
        $accountsFrom = [Version]$AzAccountsVersionFrom      
    }
    catch 
    {
        $accountsFrom = $null
        Write-Warning "Invalid AzAccountsVersionFrom $AzAccountsVersionFrom"
    }
}

if ($AzAccountsVersionTo)
{
    $accountsTo = [Version]$AzAccountsVersionTo
}

$module = Get-Module -Name "CertificateUtility"
if ($null -eq $module)
{
    Import-Module "$PSScriptRoot/CertificateUtility.psm1"
}

$importAzAccountsFrom = "Import-Module Az.Accounts -RequiredVersion $accountsFrom`n"
$importAzAccountsTo = "Import-Module Az.Accounts -RequiredVersion $accountsTo`n"
$getToken = "Get-AzAccessToken`n"
$getAzAcountVersion = "Get-Module -Name Az.Accounts`n"

$baseCommand = @"
."$PSScriptRoot/ConnectAzAccountLiveTest.ps1" -ServicePrincipalName "AzAccountsTest" -CredentialPrefix "AzAccountsTest"
"@

$smokeTest = {
    try {
        (Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/main/tools/Test/SmokeTest/RmCoreSmokeTests.ps1").Content | Invoke-Expression
    }
    finally {
        Get-Module -ListAvailable | Select-Object Name, Version
    }
}
$smokeTest = $smokeTest | Out-String

$shortTest = {
    try {
        $storageAccount = Get-AzStorageAccount | Select-Object -First 1
        if ($storageAccount)
        {
          Get-AzStorageContainer -Context $storageAccount.Context
          Get-AzResource -ResourceId $storageAccount.Id
        }
    }
    finally {
        Get-Module -ListAvailable | Select-Object Name, Version
    }
}
$shortTest = $shortTest | Out-String

function Test-AzAccountsLogin
{
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $SpecialParamString,

        [Parameter(Mandatory = $true)]
        [bool]
        $UseWindowsPowerShell
    )
    $connectCommand = $baseCommand + " $($specialParamString) `n"

    Write-Host 'Accquire Token Using the Test Version:'
    $command = $importAzAccountsTo + $getToken
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell

    Write-Host 'Connect AzAccounts Using the Test Version:'
    $command = $importAzAccountsTo + $connectCommand + $getAzAcountVersion
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell
}

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

    $connectCommand = $baseCommand + " $($specialParamString) `n"

    Write-Host 'Connect Using the previous Az.Accounts:'
    $command = $importAzAccountsFrom + $connectCommand + $getAzAcountVersion
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell

    Write-Host 'Accquire Token Using the Test Version:'
    $command = $importAzAccountsTo + $getToken
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell

    Write-Host 'Connect AzAccounts Using the Test Version:'
    $command = $importAzAccountsTo + $connectCommand + $getAzAcountVersion
    Invoke-PowerShellCommand -ScriptBlock "`{$command`}" -UseWindowsPowerShell:$UseWindowsPowerShell
}

$useWindowsPowerShell = $PSVersionTable.PSEdition -eq "Desktop"

if ($PSCmdlet.ParameterSetName -eq 'FederatedToken')
{
    Write-Host '--------------------Test ClientAssertion---------------------------------'
    $specialParams = "-UseFederatedToke -FederatedToken $FederatedToken"
    if ($accountsFrom)
    {
        Test-AzAccountsUpgrade -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    }
    else
    {
        Test-AzAccountsLogin -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    }
}

if ($PSCmdlet.ParameterSetName -eq 'Password')
{
    Write-Host '--------------------Test ClientSecret------------------------------------'
    if ($accountsFrom)
    {
        Test-AzAccountsUpgrade -SpecialParamString '-UsePassword' -UseWindowsPowerShell $useWindowsPowerShell
    }
    else
    {
        Test-AzAccountsLogin -SpecialParamString '-UsePassword' -UseWindowsPowerShell $useWindowsPowerShell
    }
}

if ($PSCmdlet.ParameterSetName -eq 'CertificateFile')
{
    Write-Host '--------------------Test ClientCertificateFile---------------------------'
    $specialParams = "-UseCertificateFile -Path $Path -PfxFileName $PfxFileName"
    if ($accountsFrom)
    {
        Test-AzAccountsUpgrade -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    }
    else
    {
        Test-AzAccountsLogin -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    }
}

if ($PSCmdlet.ParameterSetName -eq 'Thumbprint')
{
    Write-Host '--------------------Test ClientCertificateThumbprint---------------------'
    $specialParams = "-UseThumbprint -Path $Path -PfxFileName $PfxFileName"
    if ($accountsFrom)
    {
        Test-AzAccountsUpgrade -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    }
    else 
    {
        Test-AzAccountsLogin -SpecialParamString $specialParams -UseWindowsPowerShell $useWindowsPowerShell
    }
}

if (-not $RunInAutomation)
{
    Write-Host 'Press any key to continue'
    $null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

if ($RunSmokeTest)
{
    Write-Host '--------------------Run Smoke Test----------------------------------------'
    Write-Host 'Run smoke test using the test version:'
    Invoke-PowerShellCommand -ScriptBlock "`{$importAzAccountsTo + $smokeTest`}" -UseWindowsPowerShell:$useWindowsPowerShell
}
else
{
    Write-Host '--------------------Run Short Test----------------------------------------'
    Write-Host 'Run the management plane and data plane cmdlets'
    Invoke-PowerShellCommand -ScriptBlock "`{$importAzAccountsTo + $shortTest`}" -UseWindowsPowerShell:$useWindowsPowerShell
}