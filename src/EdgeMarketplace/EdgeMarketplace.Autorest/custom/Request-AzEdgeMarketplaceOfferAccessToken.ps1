<#
.SYNOPSIS
    Request Edge Marketplace Offer Access Token.

.DESCRIPTION
    The Request-AzEdgeMarketplaceOfferAccessToken cmdlet generates an access token for an Edge Marketplace offer
    by first creating a token request (using New-AzEdgeMarketplaceOfferAccessToken with -NoWait), polling the operation 
    status to extract the requestId, and then retrieving the completed token (using Get-AzEdgeMarketplaceOfferAccessToken). 
    This is a convenience cmdlet that combines both operations into a single synchronous command.

.PARAMETER OfferId
    Id of the offer.

.PARAMETER ResourceUri
    The fully qualified Azure Resource manager identifier of the resource.

.PARAMETER EdgeMarketplaceRegion
    The region where the disk will be created.

.PARAMETER DeviceSku
    The device sku.

.PARAMETER DeviceVersion
    The device sku version.

.PARAMETER EdgeMarketplaceResourceId
    The edge marketplace resource id.

.PARAMETER HypervGeneration
    The hyperv generation version.

.PARAMETER MarketplaceSku
    The marketplace sku.

.PARAMETER MarketplaceSkuVersion
    The marketplace sku version.

.PARAMETER PublisherName
    The name of the publisher.

.PARAMETER Timeout
    The maximum time in minutes to wait for the operation to complete. Default is 30 minutes.

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.EXAMPLE
    Request-AzEdgeMarketplaceOfferAccessToken -OfferId "microsoftwindowsserver:windowsserver" -ResourceUri "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation" -EdgeMarketplaceRegion "eastus" -HypervGeneration "1" -MarketplaceSku "2019-datacenter" -MarketplaceSkuVersion "17763.7314.250509"
    
    Generates an access token using the specified parameters.

.EXAMPLE
    Request-AzEdgeMarketplaceOfferAccessToken -OfferId "microsoftwindowsserver:windowsserver" -ResourceUri "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation" -EdgeMarketplaceRegion "eastus" -HypervGeneration "1" -MarketplaceSku "2019-datacenter" -MarketplaceSkuVersion "17763.7314.250509" -Timeout 45
    
    Generates an access token with a custom timeout of 45 minutes.

.EXAMPLE
    Request-AzEdgeMarketplaceOfferAccessToken -OfferId "microsoftwindowsserver:windowsserver" -ResourceUri "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation" -EdgeMarketplaceRegion "eastus" -DeviceSku "HCI" -DeviceVersion "23H2" -HypervGeneration "1" -MarketplaceSku "2019-datacenter" -MarketplaceSkuVersion "17763.7314.250509" -PublisherName "Microsoft"
    
    Generates an access token with all optional parameters specified.
#>
function Request-AzEdgeMarketplaceOfferAccessToken {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IDiskAccessToken])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory=$true, HelpMessage="Id of the offer")]
        [ValidateNotNullOrEmpty()]
        [string]$OfferId,
        
        [Parameter(Mandatory=$true, HelpMessage="The fully qualified Azure Resource manager identifier of the resource")]
        [ValidateNotNullOrEmpty()]
        [string]$ResourceUri,
        
        [Parameter(Mandatory=$true, HelpMessage="The region where the disk will be created")]
        [ValidateNotNullOrEmpty()]
        [string]$EdgeMarketplaceRegion,
        
        [Parameter(HelpMessage="The device sku")]
        [string]$DeviceSku,
        
        [Parameter(HelpMessage="The device sku version")]
        [string]$DeviceVersion,
        
        [Parameter(HelpMessage="The edge marketplace resource id")]
        [string]$EdgeMarketplaceResourceId,
        
        [Parameter(HelpMessage="The hyperv generation version")]
        [string]$HypervGeneration,
        
        [Parameter(HelpMessage="The marketplace sku")]
        [string]$MarketplaceSku,
        
        [Parameter(HelpMessage="The marketplace sku version")]
        [string]$MarketplaceSkuVersion,
        
        [Parameter(HelpMessage="The name of the publisher")]
        [string]$PublisherName,

        [Parameter(HelpMessage="The maximum time in minutes to wait for the operation to complete. Default is 30 minutes.")]
        [int]$Timeout = 30,
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile
    )
    
    begin {
        Write-Verbose "Starting access token generation for offer: $OfferId"
    }
    
    process {
        if ($PSCmdlet.ShouldProcess($OfferId, "Request Edge Marketplace Offer Access Token")) {
            try {
                # Step 1: Initiate the access token request with -NoWait
                Write-Verbose "Step 1: Initiating access token request with -NoWait..."
                
                $tokenParams = @{
                    OfferId = $OfferId
                    ResourceUri = $ResourceUri
                    EdgeMarketplaceRegion = $EdgeMarketplaceRegion
                }
                
                # Add optional parameters if provided
                if ($DeviceSku) { $tokenParams.DeviceSku = $DeviceSku }
                if ($DeviceVersion) { $tokenParams.DeviceVersion = $DeviceVersion }
                if ($EdgeMarketplaceResourceId) { $tokenParams.EdgeMarketplaceResourceId = $EdgeMarketplaceResourceId }
                if ($HypervGeneration) { $tokenParams.HypervGeneration = $HypervGeneration }
                if ($MarketplaceSku) { $tokenParams.MarketplaceSku = $MarketplaceSku }
                if ($MarketplaceSkuVersion) { $tokenParams.MarketplaceSkuVersion = $MarketplaceSkuVersion }
                if ($PublisherName) { $tokenParams.PublisherName = $PublisherName }
                if ($DefaultProfile) { $tokenParams.DefaultProfile = $DefaultProfile }
                
                # Call New-AzEdgeMarketplaceOfferAccessToken with -NoWait
                $tokenRequest = New-AzEdgeMarketplaceOfferAccessToken @tokenParams -NoWait

                # Derive the operation-status path/URL from the response for polling
                $operationStatusPath = $tokenRequest.Target
                
                # Remove everything before /subscriptions to get the resource path
                if ($operationStatusPath -match '(/subscriptions/.*)$') {
                    $operationStatusPath = $matches[1]
                }
                
                # Step 2: Poll the operation status to get the requestId
                Write-Verbose "Step 2: Polling operation status to extract requestId..."
                
                $maxAttempts = $Timeout
                $pollingIntervalSeconds = 60
                $attempt = 0
                $requestId = $null
                
                while ($attempt -lt $maxAttempts) {
                    $attempt++
                    Start-Sleep -Seconds $pollingIntervalSeconds
                    
                    Write-Verbose "Polling attempt $attempt of $maxAttempts..."
                    
                    $pollParams = @{
                        Path = $operationStatusPath
                        Method = 'GET'
                    }
                    
                    if ($DefaultProfile) {
                        $pollParams.DefaultProfile = $DefaultProfile
                    }
                    
                    $statusResponse = Invoke-AzRestMethod @pollParams
                    
                    if ($statusResponse.StatusCode -ne 200 -and $statusResponse.StatusCode -ne 202) {
                        throw "Failed to poll operation status. Status: $($statusResponse.StatusCode), Content: $($statusResponse.Content)"
                    }
                    
                    $operationStatus = $statusResponse.Content | ConvertFrom-Json
                    
                    Write-Verbose "Operation status: $($operationStatus.status), Progress: $($operationStatus.percentComplete)%"
                    
                    if ($operationStatus.status -eq 'Succeeded') {
                        # Extract requestId from the properties field
                        if ($operationStatus.properties -and $operationStatus.properties.requestId) {
                            $requestId = $operationStatus.properties.requestId
                            break
                        } else {
                            throw "Operation succeeded but requestId not found in response properties. Response: $($statusResponse.Content)"
                        }
                    }
                    elseif ($operationStatus.status -eq 'Failed') {
                        $errorDetails = if ($operationStatus.error) { $operationStatus.error | ConvertTo-Json -Depth 3 } else { "No error details available" }
                        throw "Operation failed. Error: $errorDetails"
                    }
                    elseif ($operationStatus.status -eq 'Canceled') {
                        throw "Operation was canceled."
                    }
                }
                
                if (-not $requestId) {
                    throw "Operation did not complete within the expected time ($maxAttempts attempts over $($maxAttempts * $pollingIntervalSeconds) seconds)"
                }
                
                # Step 3: Retrieve the access token using the extracted requestId
                Write-Verbose "Step 3: Retrieving access token using requestId"
                
                $getTokenParams = @{
                    OfferId = $OfferId
                    ResourceUri = $ResourceUri
                    RequestId = $requestId
                }
                
                if ($DefaultProfile) {
                    $getTokenParams.DefaultProfile = $DefaultProfile
                }
                
                $accessToken = Get-AzEdgeMarketplaceOfferAccessToken @getTokenParams
                
                if ($null -eq $accessToken) {
                    throw "Failed to retrieve access token"
                }
                
                Write-Verbose "Access token retrieved successfully"
                
                return $accessToken
            }
            catch {
                $PSCmdlet.ThrowTerminatingError($_)
            }
        }
    }
}