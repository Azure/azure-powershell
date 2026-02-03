<#
.SYNOPSIS
    Invoke Edge Marketplace Offer Access Token Generation.

.DESCRIPTION
    The Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration cmdlet generates an access token for an Edge Marketplace offer
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

.PARAMETER DefaultProfile
    The credentials, account, tenant, and subscription used for communication with Azure.

.EXAMPLE
    Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration -OfferId "microsoftwindowsserver:windowsserver" -ResourceUri "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation" -EdgeMarketplaceRegion "eastus" -HypervGeneration "1" -MarketplaceSku "2019-datacenter" -MarketplaceSkuVersion "17763.7314.250509"
    
    Generates an access token for the specified Windows Server offer.

.EXAMPLE
    Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration -OfferId "publisher:offer" -ResourceUri "/subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/rg1/providers/Microsoft.Edge/disconnectedOperations/op1" -EdgeMarketplaceRegion "westus" -MarketplaceSku "sku1" -MarketplaceSkuVersion "1.0.0"
    
    Generates an access token for a custom marketplace offer.
#>
function Invoke-AzEdgeMarketplaceOfferAccessTokenGeneration {
    [CmdletBinding(PositionalBinding=$false)]
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
        
        [Parameter(HelpMessage="The credentials, account, tenant, and subscription used for communication with Azure")]
        [PSObject]$DefaultProfile
    )
    
    begin {
        Write-Verbose "Starting access token generation for offer: $OfferId"
    }
    
    process {
        try {
            # Step 1: Initiate the access token request with -NoWait
            Write-Verbose "Step 1: Initiating access token request with -NoWait..."
            
            $tokenParams = @{
                OfferId = $OfferId
                ResourceUri = $ResourceUri
                EdgeMarketplaceRegion = $EdgeMarketplaceRegion
            }
            
            # Add optional parameters if provided
            if ($DeviceSku) { $newTokenParams.DeviceSku = $DeviceSku }
            if ($DeviceVersion) { $newTokenParams.DeviceVersion = $DeviceVersion }
            if ($EdgeMarketplaceResourceId) { $newTokenParams.EdgeMarketplaceResourceId = $EdgeMarketplaceResourceId }
            if ($HypervGeneration) { $newTokenParams.HypervGeneration = $HypervGeneration }
            if ($MarketplaceSku) { $newTokenParams.MarketplaceSku = $MarketplaceSku }
            if ($MarketplaceSkuVersion) { $newTokenParams.MarketplaceSkuVersion = $MarketplaceSkuVersion }
            if ($PublisherName) { $newTokenParams.PublisherName = $PublisherName }
            if ($DefaultProfile) { $newTokenParams.DefaultProfile = $DefaultProfile }
            if ($NoWait) { $newTokenParams.NoWait = $true }
            
            # Call New-AzEdgeMarketplaceOfferAccessToken with -NoWait
            # This should return immediately with the operation details
            #$tokenRequest = New-AzEdgeMarketplaceOfferAccessToken @newTokenParams
            
            # Step 2: Poll the operation status to get the requestId
            Write-Verbose "Step 2: Polling operation status to extract requestId..."
            
            $maxAttempts = 30
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
                        Write-Verbose "Operation completed successfully. RequestId: $requestId"
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
                # Continue polling if status is InProgress or other intermediate state
            }
            
            if (-not $requestId) {
                throw "Operation did not complete within the expected time ($maxAttempts attempts over $($maxAttempts * $pollingIntervalSeconds) seconds)"
            }
            
            # Step 3: Retrieve the access token using the extracted requestId
            Write-Verbose "Step 3: Retrieving access token with requestId: $requestId"
            
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
                throw "Failed to retrieve access token for requestId: $requestId"
            }
            
            Write-Verbose "Access token retrieved successfully"
            
            return $accessToken
        }
        catch {
            $PSCmdlet.ThrowTerminatingError($_)
        }
    }
}