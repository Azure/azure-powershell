$taskScriptDir = [System.IO.Path]::GetDirectoryName($PSCommandPath)
$env:repoRoot = [System.IO.Path]::GetDirectoryName($taskScriptDir)
$userPsFileDir = [string]::Empty

[string]$envVariableName="TEST_CSM_ORGID_AUTHENTICATION"


[CmdletBinding]
Function Set-TestEnvironment
{
<#
.SYNOPSIS
This cmdlet helps you to setup Test Environment for running tests
In order to successfully run a test, you will need SubscriptionId, TenantId
This cmdlet will only prompt you for Subscription and Tenant information, rest all other parameters are optional

#>
    param(
        [parameter(Mandatory=$true, Position=0, HelpMessage='SubscriptionId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [parameter(Mandatory=$true, Position=1, HelpMessage='AADTenant/TenantId you would like to use:')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

        [parameter(Mandatory=$false, Position=2, HelpMessage='UserId (OrgId) you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$UserId,

        [parameter(Mandatory=$false, Position=3, HelpMessage='ServicePrincipal/ClientId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipal,

        [parameter(Mandatory=$false, Position=4, HelpMessage='ServicePrincipal Secret/Client Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [parameter(Mandatory=$false, Position=5, HelpMessage='RecordMode you would like to set')]    
        [string]$RecordMode = "Playback",

        [parameter(Mandatory=$false, Position=6, HelpMessage='Target Environment to use {Prod (default) | Dogfood | Next | Current')]
        [string]$TargetEnvironment = "Prod"
    )

  [PSCredential] 

    [string]$uris="BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/"

    $formattedConnStr = [string]::Format("SubscriptionId={0};AADTenant={1};HttpRecorderMode={2};Environment={3}", $SubscriptionId, $TenantId, $RecordMode, $TargetEnvironment)

    if([string]::IsNullOrEmpty($UserId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";UserId={0}"), $UserId)
    }

    if([string]::IsNullOrEmpty($ServicePrincipal) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipal={0}"), $ServicePrincipal)
    }

    if([string]::IsNullOrEmpty($ServicePrincipalSecret) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipalSecret={0}"), $ServicePrincipalSecret)
    }

    $formattedConnStr = [string]::Concat($formattedConnStr, ";", $uris)

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    Write-Host ""

    # Retrieve the environment variable
    Write-Host "Setting up below connection string. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md"
}



<#

[CmdletBinding]
Function Set-TestEnvironment
{
<#
.SYNOPSIS
This cmdlet helps you to setup Test Environment for running tests
In order to successfully run a test, you will need SubscriptionId, TenantId
This cmdlet will only prompt you for Subscription and Tenant information, rest all other parameters are optional


    param(
        [parameter(Mandatory=$true, Position=0, HelpMessage='SubscriptionId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [parameter(Mandatory=$true, Position=1, HelpMessage='AADTenant/TenantId you would like to use:')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

        [parameter(Mandatory=$false, Position=2, HelpMessage='UserId (OrgId) you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$UserId,

        [parameter(Mandatory=$false, Position=3, HelpMessage='ServicePrincipal/ClientId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipal,

        [parameter(Mandatory=$false, Position=4, HelpMessage='ServicePrincipal Secret/Client Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [parameter(Mandatory=$false, Position=5, HelpMessage='RecordMode you would like to set')]    
        [string]$RecordMode = "Playback",

        [parameter(Mandatory=$false, Position=6, HelpMessage='Target Environment to use {Prod (default) | Dogfood | Next | Current')]
        [string]$TargetEnvironment = "Prod"
    )

    [string]$uris="BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/"

    $formattedConnStr = [string]::Format("SubscriptionId={0};AADTenant={1};HttpRecorderMode={2};Environment={3}", $SubscriptionId, $TenantId, $RecordMode, $TargetEnvironment)

    if([string]::IsNullOrEmpty($UserId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";UserId={0}"), $UserId)
    }

    if([string]::IsNullOrEmpty($ServicePrincipal) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipal={0}"), $ServicePrincipal)
    }

    if([string]::IsNullOrEmpty($ServicePrincipalSecret) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipalSecret={0}"), $ServicePrincipalSecret)
    }

    $formattedConnStr = [string]::Concat($formattedConnStr, ";", $uris)

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    Write-Host ""

    # Retrieve the environment variable
    Write-Host "Setting up below connection string. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md"
}
#>



[CmdletBinding]
Function Get-BuildScopes
{
<#
.SYNOPSIS
You can build a particular package rather than doing a full build by providing Build Scope.
This cmdlet will help to identify existing Scope available
This will enable to execute Start-RepoBuild <scope>

#>

    Write-Host "Below are available scopes you can specify for building specific projects"
    Write-Host ""    
    Get-ChildItem -path "$env:repoRoot\src\ResourceManager" -dir | Format-Wide -Column 5 | Format-Table -Property Name    
    Get-ChildItem -path "$env:repoRoot\src\ServiceManagement" -dir | Format-Wide -Column 5 | Format-Table -Property Name
}

[CmdletBinding]
Function Start-Build
{
<#
.SYNOPSIS
This cmdlet will help to do either with full build or targeted build for specific scopes.

.PARAMETER BuildScope
Use Get-BuildScope cmdLet to get list of existing scopes that can be used to build
#>
    param(
    [parameter(Mandatory=$false, Position=0, HelpMessage='BuildScope that you would like to use. For list of build scopes, run List-BuildScopes')]
    [string]$BuildScope
    )    
    
    if([string]::IsNullOrEmpty($BuildScope) -eq $true)
    {
       Write-Host "Starting Full build"
       msbuild.exe "$env:repoRoot\build.proj" /t:Build
    }
    else
    {
        Write-Host "Building $BuildScope"
        msbuild.exe "$env:repoRoot\build.proj" /t:Build /p:Scope=$BuildScope
    }
}

[CmdletBinding]
Function Invoke-CheckinTests
{
<#
.SYNOPSIS
Runs all the check in tests
#>
    Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /t:Test"
    msbuild.exe "$env:repoRoot\build.proj" /t:Test
}

Function Init()
{
    <#
    We allow users to include any helper powershell scripts they would like to include in the current session
    Currently we support two ways to include helper powershell scripts
    1) psuserspreferences environment variable
    2) $env:USERPROFILE\psFiles directory
    We will include all *.ps1 files from any of the above mentioned locations
    #>
    if([System.IO.Directory]::Exists($env:psuserpreferences))
    {
        $userPsFileDir = $env:psuserpreferences
    }
    elseif([System.IO.Directory]::Exists("$env:USERPROFILE\psFiles"))
    {
        $userPsFileDir = "$env:USERPROFILE\psFiles"
    }

    if([string]::IsNullOrEmpty($userPsFileDir) -eq $false)
    {
        Get-ChildItem $userPsFileDir | WHERE {$_.Name -like "*.ps1"} | ForEach {
        Write-Host "Including $_" -ForegroundColor Green
        . $userPsFileDir\$_
        }
    }
    else
    {
        Write-Host "Loading skipped. 'psuserpreferences' environment variable was not set to load user preferences." -ForegroundColor DarkYellow
    }
}


export-modulemember -Function Set-TestEnvironment
export-modulemember -Function Get-BuildScopes
export-modulemember -Function Start-Build
export-modulemember -Function Invoke-CheckinTests

#Initialize
Init