[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification='MetaData is a recognised term', Scope='Function', Target='Get-AzCloudMetaData')]
param()

function Get-AZCloudMetadataResourceId {
    param (
        [Parameter(Mandatory=$true)]
        [PSCustomObject]$cloudMetadata
    )

    # Search the $armMetadata hash for the entry where the "name" parameter matches
    # $cloud and then find the login endpoint, from which we can discern the
    # appropriate "cloud based domain ending".
    return $cloudMetadata.authentication.audiences[0]
}

Function Get-AzCloudMetadata {
    param (
        [string]$ApiVersion = "2022-09-01"
    )

    # This is a known endpoint.
    $MetadataEndpoint = "https://management.azure.com/metadata/endpoints?api-version=$ApiVersion"

    try {
        $Response = Invoke-RestMethod -Uri $MetadataEndpoint -Method Get -StatusCodeVariable StatusCode
    }
    catch {
        $StatusCode = 500
        $Msg = "Failed to request ARM metadata $MetadataEndpoint."
        Write-Error "$Msg Please ensure you have network connection. Error: $_"
    }

    if ($StatusCode -ne 200) {
        $Msg = "ARM metadata endpoint '$MetadataEndpoint' failed: $($StatusCode)."
        throw $Msg
    }

    # The current cloud in use is set by the user so query it and then we can use
    # it to index into the ARM Metadata.
    $context = $null
    try {
        $context = Get-AzContext
    }
    catch
    {
        throw "Failed to get the current Azure context. Error: $_"
    }
    $cloudName = $context.Environment.Name

    # !!PDS: Seem to only be seeing a single entry now.  Why is that?
    # Search the $armMetadata hash for the entry where the "name" parameter matches
    # $cloud.
    $cloud = $Response | Where-Object { $_.name -eq $cloudName }
    return $cloud
}