[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification = 'Uses multiple parameters', Scope = 'Function', Target = 'Invoke-RestMethodWithUriParameters')]
param()

function InvokeConfigDPHealthCheck {
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
        $headers = @{"Authorization" = "Bearer $($env['AZURE_ACCESS_TOKEN'])" }
    }

    # Sending request with retries
    Invoke-RestMethodWithUriParameters -Method 'post' -Uri $chartLocationUrl -Headers $headers -UriParameters $uriParameters -MaximumRetryCount 5 -RetryIntervalSec 3 -StatusCodeVariable statusCode
    if ($statusCode -ne 200) {
        throw "Error while performing DP health check, StatusCode: ${statusCode}"
    }
}


function GetConfigDPEndpoint {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$Location,
        [Parameter(Mandatory = $true)]
        [PSCustomObject]$cloudMetadata
    )
    . "$PSScriptRoot\AZCloudMetadataHelper.ps1"

    $ReleaseTrain = $null
    # Get the default config dataplane endpoint.  Note that there may be code
    $ConfigDpEndpoint = Get-ConfigDpDefaultEndpoint -Location $Location -CloudMetadata $cloudMetadata
    
    return @{ ConfigDpEndpoint = $ConfigDpEndpoint; ReleaseTrain = $ReleaseTrain }
}

function GetConfigDpDefaultEndpoint {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$location,
        [Parameter(Mandatory = $true)]
        [PSCustomObject]$cloudMetadata
    )

    # The DP endpoint uses the same final URL portion as the AAD authority.  But
    # we also need to trim the trailing "/".
    $cloudBasedDomain = ($cloudMetadata.ActiveDirectoryAuthority -split "\.")[2]

    # Remove optional trailing "/" from $cloudBasedDomain
    $cloudBasedDomain = $cloudBasedDomain.TrimEnd('/')

    $configDpEndpoint = "https://${location}.dp.kubernetesconfiguration.azure.${cloudBasedDomain}"
    return $configDpEndpoint
}

function InvokeRestMethodWithUriParameters {
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
    $rsp = InvokeRestMethod `
        -Method $method `
        -Uri $uri `
        -Headers $headers `
        -Body $requestBody `
        -ContentType "application/json" `
        -MaximumRetryCount $maximumRetryCount `
        -RetryIntervalSec $retryintervalSec `
        -StatusCodeVariable statusCode `
        -Verbose:($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent -eq $true) `
        -Debug:($PSCmdlet.MyInvocation.BoundParameters["Debug"].IsPresent -eq $true)

    Write-Debug "Response: $($rsp | ConvertTo-Json -Depth 10)"

    Set-Variable -Name "${statusCodeVariable}" -Value $statusCode -Scope script
    return $rsp
}