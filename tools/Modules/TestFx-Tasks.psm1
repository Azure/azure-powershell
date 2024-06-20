$script:TestFxEnvDirectory = Join-Path -Path $env:USERPROFILE -ChildPath ".Azure"
$script:TestFxEnvFileName = "testcredentials.json"
$script:TestFxEnvConnectionStringKey = "TEST_CSM_ORGID_AUTHENTICATION"
$script:TestFxEnvTestModeKey = "AZURE_TEST_MODE"
$script:TestFxEnvExtraPropKeys = @(
    "AADAuthUri",
    "AADTokenAudienceUri",
    "DataLakeAnalyticsJobAndCatalogServiceUri",
    "DataLakeStoreServiceUri",
    "GalleryUri",
    "GraphTokenAudienceUri",
    "GraphUri",
    "IbizaPortalUri",
    "RdfePortalUri",
    "ResourceManagementUri",
    "ServiceManagementUri"
)

function Set-TestFxEnvironment {
    [CmdletBinding(DefaultParameterSetName = "UserAccount")]
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [guid] $SubscriptionId,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [guid] $TenantId,

        [Parameter(Mandatory, ParameterSetName = "UserAccount")]
        [ValidateNotNullOrEmpty()]
        [guid] $UserId,

        [Parameter(Mandatory, ParameterSetName = "NewServicePrincipal")]
        [ValidateNotNullOrEmpty()]
        [string] $ServicePrincipalDisplayName,

        [Parameter(Mandatory, ParameterSetName = "ExistingServicePrincipal")]
        [ValidateNotNullOrEmpty()]
        [guid] $ServicePrincipalId,

        [Parameter(Mandatory, ParameterSetName = "ExistingServicePrincipal")]
        [ValidateNotNullOrEmpty()]
        [string] $ServicePrincipalSecret,

        [Parameter(Mandatory)]
        [ValidateSet("Playback", "Record")]
        [string] $RecorderMode,

        [Parameter()]
        [ValidateSet("Prod", "Dogfood", "Current", "Next", "Custom")]
        [string] $TargetEnvironment = "Prod",

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $AADAuthUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $AADTokenAudienceUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $DataLakeAnalyticsJobAndCatalogServiceUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $DataLakeStoreServiceUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $GalleryUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $GraphTokenAudienceUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $GraphUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $IbizaPortalUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $RdfePortalUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $ResourceManagementUri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string] $ServiceManagementUri,

        [Parameter()]
        [switch] $Force
    )

    $azContext = Get-AzContext
    $currentSubscriptionId = $azContext.Subscription.Id
    $currentTenantId = $azContext.Tenant.Id

    if (!$Force.IsPresent) {
        if ($SubscriptionId -ne $currentSubscriptionId) {
            Write-Warning "The passed in argument SubscriptionId does not match with the current Azure context."
        }
        if ($TenantId -ne $currentTenantId) {
            Write-Warning "The passed in argument TenantId does not match with the current Azure context."
        }
    }

    $testFxEnvProps = [PSCustomObject]@{
        Environment            = $TargetEnvironment
        SubscriptionId         = $SubscriptionId
        TenantId               = $TenantId
        HttpRecorderMode       = $RecorderMode
    }

    switch ($PSCmdlet.ParameterSetName) {
        "UserAccount" {
            $testFxEnvProps | Add-Member -NotePropertyName UserId -NotePropertyValue $UserId
        }
        "NewServicePrincipal" {
            $sp = New-TestFxServicePrincipal -SubscriptionId $SubscriptionId -ServicePrincipalDisplayName $ServicePrincipalDisplayName -Force:$Force
            $spAppId = $sp.AppId
            $spSecret = $sp.PasswordCredentials.SecretText
            $testFxEnvProps | Add-Member -NotePropertyName ServicePrincipal -NotePropertyValue $spAppId
            $testFxEnvProps | Add-Member -NotePropertyName ServicePrincipalSecret -NotePropertyValue $spSecret
        }
        "ExistingServicePrincipal" {
            $sp = Get-AzADServicePrincipal -ApplicationId $ServicePrincipalId
            if ($null -eq $sp) {
                throw "The service principal `"$ServicePrincipalId`" does not exist. Please verify or create a new one."
            }

            $spAppId = $ServicePrincipalId
            $spSecret = $ServicePrincipalSecret
            $testFxEnvProps | Add-Member -NotePropertyName ServicePrincipal -NotePropertyValue $spAppId
            $testFxEnvProps | Add-Member -NotePropertyName ServicePrincipalSecret -NotePropertyValue $spSecret
        }
    }

    $script:testFxEnvExtraPropKeys | ForEach-Object {
        if ($PSBoundParameters.ContainsKey($_)) {
            $testFxEnvProps | Add-Member -NotePropertyName $_ -NotePropertyValue $PSBoundParameters[$_]
        }
    }

    if (!(Test-Path -LiteralPath $script:TestFxEnvDirectory -PathType Container)) {
        New-Item -Path $script:TestFxEnvDirectory -ItemType Directory -Force
    }

    $testFxEnvProps
    $testFxEnvFile = Join-Path -Path $script:TestFxEnvDirectory -ChildPath $script:TestFxEnvFileName
    $testFxEnvProps | ConvertTo-Json | Out-File -LiteralPath $testFxEnvFile -Force
}

function New-TestFxServicePrincipal {
    [CmdletBinding(SupportsShouldProcess)]
    param(
        [ValidateNotNullOrEmpty()]
        [string] $ServicePrincipalDisplayName,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [guid] $SubscriptionId,

        [Parameter()]
        [switch] $Force
    )

    $sp = Get-AzADServicePrincipal -DisplayName $ServicePrincipalDisplayName

    if (($null -ne $sp) -and !$Force.IsPresent) {
        $continue = $PSCmdlet.ShouldContinue("The service principal `"$ServicePrincipalDisplayName`" already exists. Would you like to create a new service principal with the same name?", "Create Service Principal?")
        if (!$continue) {
            throw "The service principal `"$ServicePrincipalDisplayName`" already exists. Pass in the Client Id and Client Secret to re-use it."
        }
    }

    $sp = Invoke-TestFxCommand -Command "New-AzADServicePrincipal -DisplayName $ServicePrincipalDisplayName"
    Start-Sleep -Seconds 10
    Set-TestFxServicePrincipalPermission -SubscriptionId $SubscriptionId -ServicePrincipalObjectId $sp.Id

    return $sp
}

function Set-TestFxServicePrincipalPermission {
    param(
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [guid] $SubscriptionId,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [guid] $ServicePrincipalObjectId
    )

    $scope = "/subscriptions/$SubscriptionId"
    $roleName = "Contributor"
    try {
        $spRoleAssg = Get-AzRoleAssignment -ObjectId $ServicePrincipalObjectId -Scope $scope -RoleDefinitionName $roleName -ErrorAction Stop
        if ($null -eq $spRoleAssg) {
            Invoke-TestFxCommand -Command "New-AzRoleAssignment -ObjectId $ServicePrincipalObjectId -RoleDefinitionName $roleName -Scope $scope | Out-Null"
        }
    }
    catch {
        throw "Exception occurred when retrieving the role assignment for service principal with error message $($_.Exception.Message)."
    }
}

function Get-TestFxEnvironment {
    [CmdletBinding()]
    param ()

    $testFxEnvFile = Join-Path -Path $script:TestFxEnvDirectory -ChildPath $script:TestFxEnvFileName
    if (Test-Path -LiteralPath $testFxEnvFile -PathType Leaf) {
        Write-Verbose "Config file was found for TestFx environment."
        try {
            $testFxEnvProps = Get-Content -LiteralPath $testFxEnvFile | Out-String | ConvertFrom-Json
        }
        catch {
            Write-Error "Exception occurred when trying to parse the JSON file with error message `"$($_.Exception.Message)`"."
        }

        $testFxEnvProps
        return
    }

    $testFxEnvConnStr = [Environment]::GetEnvironmentVariable($script:TestFxEnvConnectionStringKey)
    if ($null -ne $testFxEnvConnStr) {
        Write-Verbose "Environment variable was found for TestFx environment."
        $testFxEnvProps = [PSCustomObject]@{}
        $testFxEnvVars = $testFxEnvConnStr -split ";"
        $testFxEnvVars | ForEach-Object {
            if (![string]::IsNullOrWhiteSpace($_)) {
                $testFxEnvProp = $_ -split "="
                $testFxEnvPropKey = $testFxEnvProp[0]
                $testFxEnvPropValue = $testFxEnvProp[1]
                $testFxEnvProps | Add-Member -NotePropertyName $testFxEnvPropKey -NotePropertyValue $testFxEnvPropValue
            }
        }

        $testFxEnvTestMode = [Environment]::GetEnvironmentVariable($script:TestFxEnvTestModeKey)
        if ($null -ne $testFxEnvTestMode) {
            if ($null -eq $testFxEnvProps.HttpRecorderMode) {
                $testFxEnvProps | Add-Member -NotePropertyName HttpRecorderMode -NotePropertyValue $testFxEnvTestMode
            }
            else {
                $testFxEnvProps.HttpRecorderMode = $testFxEnvTestMode
            }
        }

        $testFxEnvProps
        return
    }

    Write-Warning "TestFx environment has not been setup. Please run command Set-TestFxEnvironment."
}

function Invoke-TestFxCommand {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        [ValidateNotNullOrEmpty()]
        [string] $Command
    )

    $cmdRetryCount = 0

    do {
        try {
            Write-Verbose "Start to execute the command `"$Command`"."
            $cmdResult = Invoke-Expression -Command $Command -ErrorAction Stop
            Write-Verbose "Successfully executed the command `"$Command`"."
            $cmdResult
            break
        }
        catch {
            $cmdErrorMessage = $_.Exception.Message
            if ($cmdRetryCount -le 3) {
                Write-Warning "Error occurred when executing the command `"$Command`" with error message `"$cmdErrorMessage`"."
                Write-Warning "Will retry automatically in 5 seconds."
                Write-Host

                Start-Sleep -Seconds 5
                $cmdRetryCount++
                Write-Warning "Retrying #$cmdRetryCount to execute the command `"$Command`"."
            }
            else {
                throw "Failed to execute the command `"$Command`" after retrying for 3 times with error message `"$cmdErrorMessage`"."
            }
        }
    }
    while ($true)
}
