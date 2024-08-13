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
    $uriParameters = [ordered]@{}
    $headers = @{}
    # Check if key AZURE_ACCESS_TOKEN exists in environment variables
    if ($env:AZURE_ACCESS_TOKEN) {
        $headers = @{"Authorization"="Bearer $($env['AZURE_ACCESS_TOKEN'])"}
    }

    # Sending request with retries
    Invoke-RestMethodWithUriParameters -Method 'post' -Uri $chartLocationUrl -Headers $headers -UriParameters $uriParameters -MaximumRetryCount 5 -RetryIntervalSec 3 -StatusCodeVariable statusCode
    if ($statusCode -ne 200) {
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
        $ConfigDpEndpoint = $cloudMetadata.dataplaneEndpoints.arcConfigEndpoint
    }
    else {
        Write-Debug "'arcConfigEndpoint' doesn't exist under 'dataplaneEndpoints' in the ARM metadata."
    }

    # Get the default config dataplane endpoint.
    if ($ConfigDpEndpoint -eq $null) {
        $ConfigDpEndpoint = Get-ConfigDpDefaultEndpoint -Location $Location -CloudMetadata $cloudMetadata
    }
    $ADResourceId = Get-AZCloudMetadataResourceId -CloudMetadata $cloudMetadata

    return @{ ConfigDpEndpoint = $ConfigDpEndpoint; ReleaseTrain = $ReleaseTrain; ADResourceId = $ADResourceId }
}

# !!PDS: What? Looks like there is a function to do this?  Perhaps because we did not hide it?
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
    $cloudBasedDomain = ($cloudMetadata.authentication.loginEndpoint -split "\.", 3)[2]
    $configDpEndpoint = "https://${location}.dp.kubernetesconfiguration.azure.${cloudBasedDomain}"
    return $configDpEndpoint
}

function Invoke-RestMethodWithUriParameters {
    param (
        [String]$method,
        [String]$uri,
        [Hashtable]$headers,
        [System.Collections.Specialized.OrderedDictionary]$uriParameters,
        [String]$requestBody,
        [Int]$maximumRetryCount,
        [Int]$retryIntervalSec,
        [String]$statusCodeVariable
    )

    # Add URI parameters to end of URL if there are any.
    $uriParametersArray = @()
    if ($uriParameters.count -gt 0) {
        # Create an array by joining hash index and value using '='
        $uriParametersArray = $uriParameters.GetEnumerator() | ForEach-Object { "$($_.Key)=$($_.Value)" }
        $uriParametersString = $uriParametersArray -join "&"
        $uri = $uri + "?" + $uriParametersString
        # Write-Error "URI: >$uri<"
    }

    # if ($uriParameters.count -gt 0) {
    #     # Create an array by joining hash index and value using '=' and join them using '&'
    #     $uriParametersArray = $uriParameters.GetEnumerator() | ForEach-Object { "$($_.Key)=$($_.Value)" } | ForEach-Object { $_ -join '=' } | ForEach-Object { $_ -join '&' }
    # }
    Write-Debug "Issue REST request to ${uri} with method ${method} and headers ${headers} and body ${requestBody}"
    $rsp = Invoke-RestMethod -Method $method -Uri $uri -Headers $headers -Body $requestBody -ContentType "application/json"  -MaximumRetryCount $maximumRetryCount -RetryIntervalSec $retryintervalSec -StatusCodeVariable statusCode
    Set-Variable -Name "${statusCodeVariable}" -Value $statusCode -Scope script
    return $rsp
}