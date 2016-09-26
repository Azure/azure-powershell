$taskScriptDir = [System.IO.Path]::GetDirectoryName($PSCommandPath)
$env:repoRoot = [System.IO.Path]::GetDirectoryName($taskScriptDir)

#$userPreferenceDir = $env:psuserpreferences
$userPsFileEnvVariable = $env:psuserpreferences
$userPsFileDir = "$env:USERPROFILE\psFiles"

[string]$envVariableName="TEST_CSM_ORGID_AUTHENTICATION"

<#
We allow users to include any helper powershell scripts they would like to include in the current session
Currently we support two ways to include helper powershell scripts
1) psuserspreferences environment variable
2) $env:USERPROFILE\psFiles directory
We will include all *.ps1 files from any of the above mentioned locations
#>
if([System.IO.Directory]::Exists($userPsFileEnvVariable))
{
    Get-ChildItem $userPsFileEnvVariable | WHERE {$_.Name -like "*.ps1"} | ForEach {
    Write-Host "Including $_" -ForegroundColor Green
    . $userPsFileEnvVariable\$_
    }
}
elseif([System.IO.Directory]::Exists($userPsFileDir))
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

Function Get-TaskHelp
{
    $taskCount = 1
    #Add tasks and description in the tasks array
    [string[]] $tasks = "Setup-TestEnvironment ==> will allow you to setup Test Environment", `
                        "List-BuildScopes ==> List of available Scopes", `
                        "Build-Repo ==> will allow you to build the entire repo or build for specific Scope", `                        
                        "Run-CheckinTests ==> Run Tests prior to checkin", `
                        "Run-MockedScenarioTests ==> Run Mocked Scenario Tests", `
                        "Get-TaskHelp ==> Display supported tasks"
    
    #$tableFormat = @{Expression={$taskCount};width=50}, @{Expression={$_}};
    #$tasks | Format-Table $tableFormat
    $tasks |foreach { Write-Host ([string]::Format("{0}) {1}", $taskCount++, $_))}
    Write-Host ""
}

Function Setup-TestEnvironment()
{
    [string]$subId = [string]::Empty
    [string]$aadTenant = [string]::Empty
    [string]$spn = [string]::Empty
    [string]$spnSecret = [string]::Empty
    [string]$env = [string]::Empty
    [string]$uris="BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/"
    [string]$recordMode = [string]::Empty

    Write-Host "Executing Setup-TestEnvironment"
    Write-Host "Please specify values to setup your connection string"    
    $subId = (Read-Host "SubscriptionId you would like to use:").Trim()    
    $subNull = CheckEmptyNull $subId "SubscriptionId is empty, SubscriptionId is mandatory for running tests."
    
    $aadTenant = (Read-Host "AADTenant/TenantId you would like to use:").Trim()
    $tenantNull = CheckEmptyNull $aadTenant "TenantId is empty, TenantId is mandatory for running tests."

    $spn = (Read-Host "ServicePrincipal/ClientId you would like to use:").Trim()
    $spnNull = CheckEmptyNull $spn "ServicePrincipal is empty, ServicePrincipal is mandatory for running tests."

    $spnSecret = (Read-Host "ServicePrincipal Secret/ClientId Secret you would like to use:").Trim()
    $spnSecretNull = CheckEmptyNull $spnSecret "ServicePrincipal Secret is empty, ServicePrincipal Secret is mandatory for running tests."

    $recordMode = (Read-Host "Http Record Mode: Type Record for recording tests. Type Playback for running your recorded tests):").Trim()
    If([string]::IsNullOrEmpty($recordMode) -eq $true)
    {
        Write-Host "RecordMode is empty. Setting default mode to Playback"
        $recordMode="Playback"
    }

    if(($subNull -eq $true) -or ($tenantNull -eq $true) -or ($spnNull -eq $true) -or ($spnSecretNull -eq $true))
    {
        Write-Host "Mandatory fields were not set correctly. Exiting......" -ForegroundColor Red
        return
    }

    #Construct connection string
    $formattedConnStr = [string]::Format("SubscriptionId={0};AADTenant={1};ServicePrincipal={2};ServicePrincipalSecret={3};HttpRecorderMode={4};$uris", $subId, $aadTenant, $spn, $spnSecret, $recordMode)

    #Print Constructed connection string
    Print-ConnectionString $subId $aadTenant $spn $spnSecret $recordMode $uris

    #Set connection string to Environment variable
    [Environment]::SetEnvironmentVariable($envVariableName, $formattedConnStr)
    Write-Host ""

    # Retrieve the environment variable
    Write-Host "Setting up below connection string. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    #Write-Host "`$env:$envVariableName=SubscriptionId=<subid>;AADTenantId=<tenantId>"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md"
}

Function List-BuildScopes()
{
    Write-Host "Below are available scopes you can specify for building specific projects"
    Write-Host ""    
    Get-ChildItem -path "$env:repoRoot\src\ResourceManager" -dir | Format-Wide -Column 5 | Format-Table -Property Name    
    Get-ChildItem -path "$env:repoRoot\src\ServiceManagement" -dir | Format-Wide -Column 5 | Format-Table -Property Name
}

Function Build-Repo([string] $scope)
{
    Write-Host "Executing Build-Repo"    
    
    if([string]::IsNullOrEmpty($scope) -eq $true)
    {
       Write-Host "Starting Full build"
       msbuild.exe "$env:repoRoot\build.proj" /t:Build
    }
    else
    {
        Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /p:Scope=$scope"
        msbuild.exe "$env:repoRoot\build.proj" /t:Build /p:Scope=$scope
    }
}

Function Run-CheckinTests()
{
    Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /t:Test"
    msbuild.exe "$env:repoRoot\build.proj" /t:Test
}

Function Run-MockedScenarioTests()
{
    Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /t:Test"
    msbuild.exe "$env:repoRoot\build.proj" /t:"Build;BeforeRunTests;MockedScenarioTests"
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

Function Print-ConnectionString([string]$subId, [string]$aadTenant, [string]$spn, [string]$spnSecret, [string]$recordMode, [string]$uris)
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

    Write-Host $uris
}

Function CheckEmptyNull([string] $argsToCheck, [string]$emptyNullMessage)
{
    If([string]::IsNullOrEmpty($argsToCheck) -eq $true)
    {
        Write-Host $emptyNullMessage -ForegroundColor Red
        return [bool]$true
    }
}

cls
Get-TaskHelp