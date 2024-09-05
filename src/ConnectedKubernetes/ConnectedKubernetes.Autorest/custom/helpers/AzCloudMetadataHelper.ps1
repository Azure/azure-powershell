[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseSingularNouns', '',
    Justification = 'MetaData is a recognised term', Scope = 'Function', Target = 'Get-AzCloudMetaData')]
param()

function Get-AZCloudMetadataResourceId {
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.DoNotExport()]
    param (
        [Parameter(Mandatory = $true)]
        [PSCustomObject]$cloudMetadata
    )

    # Search the $armMetadata hash for the entry where the "name" parameter matches
    # $cloud and then find the login endpoint, from which we can discern the
    # appropriate "cloud based domain ending".
    Write-Debug -Message "cloudMetaData in: $($cloudMetaData | ConvertTo-Json -Depth 10)."
    return $cloudMetadata.ResourceManagerUrl
}

Function Get-AzCloudMetadata {
    # The current cloud in use is set by the user so query it and then we can use
    # it to index into the ARM Metadata.
    $context = $null
    try {
        $context = Get-AzContext
    }
    catch {
        throw "Failed to get the current Azure context. Error: $_"
    }
    $cloudName = $context.Environment.Name

    try {
        # $Response = Invoke-RestMethod -Uri $MetadataEndpoint -Method Get -StatusCodeVariable StatusCode
        $cloud = Get-AzureEnvironment -Name $cloudName
    }
    catch {
        Write-Error "Failed to request ARM metadata. Error: $_"
    }
    Write-Debug -Message "cloudMetaData out: $($cloud | ConvertTo-Json -Depth 10)."

    return $cloud
}