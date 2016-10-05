$taskScriptDir = [System.IO.Path]::GetDirectoryName($PSCommandPath)
$env:repoRoot = [System.IO.Path]::GetDirectoryName($taskScriptDir)

#$userPsFileEnvVariable = $env:psuserpreferences
$userPsFileDir = [string]::Empty

[string]$envVariableName="TEST_CSM_ORGID_AUTHENTICATION"

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

[CmdletBinding]
Function Set-TestEnvironment
{
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

        [parameter(Mandatory=$false, Position=4, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use')]
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

[CmdletBinding]
Function Get-BuildScopes
{
    Write-Host "Below are available scopes you can specify for building specific projects"
    Write-Host ""    
    Get-ChildItem -path "$env:repoRoot\src\ResourceManager" -dir | Format-Wide -Column 5 | Format-Table -Property Name    
    Get-ChildItem -path "$env:repoRoot\src\ServiceManagement" -dir | Format-Wide -Column 5 | Format-Table -Property Name
}

[CmdletBinding]
Function Start-RepoBuild
{
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
    Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /t:Test"
    msbuild.exe "$env:repoRoot\build.proj" /t:Test
}

[CmdletBinding]
Function Invoke-MockedScenarioTests
{
    Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /t:Test"
    msbuild.exe "$env:repoRoot\build.proj" /t:"Build;BeforeRunTests;MockedScenarioTests"
}

[cmdletBinding]
Function Install-VSProjectTemplates
{
    if($env:VisualStudioVersion -eq "14.0")
    {
        Write-Host "Installing VS templates for 'AutoRest as well as Test Project'"
        Copy-Item "$env:repoRoot\tools\ProjectTemplates\*.zip" "$env:USERPROFILE\Documents\Visual Studio 2015\Templates\ProjectTemplates\"
        Write-Host "Installed VS Test Project Templates for Powershell and DotNet SDK test projects"
        Write-Host "Restart VS (if already open), search for 'AutoRest-AzureDotNetSdk', 'AzureDotNetSDK-TestProject' or 'AzurePowerShell-TestProject'"
    }
    else
    {
        Write-Host "Unsupported VS Version detected. Visual Studio 2015 is the only supported version for current set of project templates"
    }
}

Function Create-ServicePrincipal-Help()
{
    #TODO: Find a way to get service principal secret key during SPN creation
    #TODO: Validate user input
    Write-Host "Visit https://azure.microsoft.com/en-us/documentation/articles/resource-group-create-service-principal-portal/ to know more about how to create service principal manually"

    #Add-AzureRmAccount

    #$appName = (Read-Host "Provide an app name (without spaces) for the new AD App that will be created").Trim()
    #$tenantName = (Read-Host "Provide your tenant name (e.g. if you are using Microsoft tenant, tenant Name will be microsoft.com").Trim()
    #$pwd = (Read-Host "Provide a password for the new AD app that will be created").Trim()

    #$appUri = [string]::Format("https://{0}/{1}", $tenantName, $appName)

    #$app = AzureRmADApplication -DisplayName $appName -HomePage $appUri -IdentifierUris $appUri -Password $pwd

    #New-AzureRmADServicePrincipal -ApplicationId $app.ApplicationId
    #New-AzureRmRoleAssignment -RoleDefinitionName Reader -ServicePrincipalName $app.ApplicationId.Guid
}

Function Print-ConnectionString([string]$subId, [string]$aadTenant, [string]$spn, [string]$spnSecret, [string]$recordMode, [string]$targetEnvironment, [string]$uris)
{
    Write-Host ""

    Write-Host $envVariableName"=" -ForegroundColor DarkYellow -NoNewline

    Write-Host "SubscriptionId=" -ForegroundColor Green -NoNewline
    Write-Host $subId";" -NoNewline 

    Write-Host "AADTenant=" -ForegroundColor Green -NoNewline
    Write-Host $aadTenant";" -NoNewline

    Write-Host "ServicePrincipal=" -ForegroundColor Green -NoNewline
    Write-Host $spn";" -NoNewline

    Write-Host "ServicePrincipalSecret=" -ForegroundColor Green -NoNewline
    Write-Host $spnSecret";" -NoNewline

    Write-Host "HttpRecorderMode=" -ForegroundColor Green -NoNewline
    Write-Host $recordMode";" -NoNewline

    Write-Host "Environment=" -ForegroundColor Green -NoNewline
    Write-Host $targetEnvironment";" -NoNewline

    Write-Host $uris
}

export-modulemember -function Set-TestEnvironment
export-modulemember -function Get-BuildScopes
export-modulemember -function Start-RepoBuild
export-modulemember -function Invoke-CheckinTests
export-modulemember -function Invoke-MockedScenarioTests
export-modulemember -function Install-VSProjectTemplates