[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification='Uses multiple parameters', Scope='Function', Target='Invoke-RestMethodWithUriParameters')]
param()

function Invoke-ConfigDPHealthCheck {
    param (
        [string]$configDPEndpoint
    )

    Write-Debug "Perform DP health check"
    # Setting uri
    $apiVersion = "2024-07-01-preview"
    $chartLocationUrlSegment = "azure-arc-k8sagents/healthCheck?api-version=$apiVersion"
    $chartLocationUrl = "$configDPEndpoint/$chartLocationUrlSegment"
    $uriParameters = @{}
    $headers = @{}
    # Check if key AZURE_ACCESS_TOKEN exists in environment variables
    if ($env:AZURE_ACCESS_TOKEN) {
        $headers = @{"Authorization"="Bearer $($env['AZURE_ACCESS_TOKEN'])"}
    }

    # Sending request with retries
    # $r = Invoke-RestMethodWithRetries -method 'post' -url $chartLocationUrl -headers $headers -faultType $consts.Get_HelmRegistery_Path_Fault_Type -summary 'Error while performing DP health check' -uriParameters $uriParameters -resource $resource
    Invoke-RestMethodWithUriParameters -Method 'post' -Uri $chartLocationUrl -Headers $headers -UriParameters $uriParameters -MaximumRetryCount 5 -RetryIntervalSec 3 -StatusCodeVariable statusCode
    if ($statusCode -eq 200) {
        Write-Output "Health check for DP is successful."
        return $true
    }
    else {
        throw "Error while performing DP health check, StatusCode: ${statusCode}"
    }
}


function Get-ConfigDPEndpoint {
    param (
        [Parameter(Mandatory=$true)]
        [string]$Location,
        [Parameter(Mandatory=$true)]
        [PSCustomObject]$cloudMetadata
    )
    . "$PSScriptRoot\AZCloudMetadataHelper.ps1"

    $ReleaseTrain = $null
    $ConfigDpEndpoint = $null

    # !!PDS: No dogfood!
    # # Read and validate the helm values file for Dogfood.
    # if ($Cmd.cli_ctx.cloud.endpoints.resource_manager -eq $consts.Dogfood_RMEndpoint) {
    #     # !!PDS Need to write this.
    #     $result = Validate-EnvFileDogfood -ValuesFile $ValuesFile
    #     $ConfigDpEndpoint = $result.ConfigDpEndpoint
    #     $ReleaseTrain = $result.ReleaseTrain
    # }

    # Get the values or endpoints required for retrieving the Helm registry URL.
    if ($cloudMetadata.dataplaneEndpoints -and $cloudMetadata.dataplaneEndpoints.arcConfigEndpoint) {
        $ConfigDpEndpoint = $armMetadata.dataplaneEndpoints.arcConfigEndpoint
    }
    else {
        Write-Debug "'arcConfigEndpoint' doesn't exist under 'dataplaneEndpoints' in the ARM metadata."
    }

    # Get the default config dataplane endpoint.
    if (-not $ConfigDpEndpoint) {
        $ConfigDpEndpoint = Get-ConfigDpDefaultEndpoint -Location $Location -CloudMetadata $cloudMetadata
    }
    $ADResourceId = Get-AZCloudMetadataResourceId -CloudMetadata $cloudMetadata

    return @{ ConfigDpEndpoint = $ConfigDpEndpoint; ReleaseTrain = $ReleaseTrain; ADResourceId = $ADResourceId }
}

function Get-ConfigDpDefaultEndpoint {
    param (
        [Parameter(Mandatory=$true)]
        [string]$location,
        [Parameter(Mandatory=$true)]
        [PSCustomObject]$cloudMetadata
    )

    # Search the $armMetadata hash for the entry where the "name" parameter matches
    # $cloud and then find the login endpoint, from which we can discern the
    # appropriate "cloud based domain ending".
    $cloudBasedDomain = ($cloudMetadata.authentication.loginEndpoint -split "\.")[2]
    $configDpEndpoint = "https://${location}.dp.kubernetesconfiguration.azure.${cloudBasedDomain}"
    return $configDpEndpoint
}

function Invoke-RestMethodWithUriParameters {
    param (
        [String]$method,
        [String]$uri,
        [Hashtable]$headers,
        [Hashtable]$uriParameters,
        [String]$requestBody,
        [Int]$maximumRetryCount,
        [Int]$retryIntervalSec,
        [String]$statusCodeVariable
    )

    # Add URI parameters to end of URL if there are any.
    $uriParametersArray = @()
    foreach ($Key in $hash.Keys) {
        $uriParametersArray.Add("$($Key)=$($UriParameters[$Key])")
        $uriParametersString = $uriParametersArray -join '&'
        $uri = "$url?$uriParametersString"
    }

    # if ($uriParameters.count -gt 0) {
    #     # Create an array by joining hash index and value using '=' and join them using '&'
    #     $uriParametersArray = $uriParameters.GetEnumerator() | ForEach-Object { "$($_.Key)=$($_.Value)" } | ForEach-Object { $_ -join '=' } | ForEach-Object { $_ -join '&' }
    # }
    Write-Debug "Issue REST request to ${uri} with method ${method} and headers ${headers} and body ${requestBody}"
    $rsp = Invoke-RestMethod -Method $method -Uri $uri -Headers $headers -Body $requestBody -ContentType "application/json"  -MaximumRetryCount $maximumRetryCount -RetryIntervalSec $retryintervalSec -StatusCodeVariable statusCode
    Set-Variable -Name "${statusCodeVariable}" -Value $statusCode -Scope script
    if ($statusCode -ne 200) {
        throw "health check failed, StatusCode: ${statusCode}."
    }
    return $rsp
}