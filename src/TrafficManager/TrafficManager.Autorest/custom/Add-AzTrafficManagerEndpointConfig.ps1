<#
.Synopsis
Adds an endpoint to a local Traffic Manager profile object.
.Description
The Add-AzTrafficManagerEndpointConfig cmdlet adds an endpoint to a local Azure Traffic Manager profile object.
This cmdlet modifies the object in memory only. To update the profile in Azure, use Set-AzTrafficManagerProfile.
.Example
$profile = Get-AzTrafficManagerProfile -Name MyProfile -ResourceGroupName MyRG
Add-AzTrafficManagerEndpointConfig -TrafficManagerProfile $profile -EndpointName MyEndpoint -Type AzureEndpoints -TargetResourceId $webAppId -EndpointStatus Enabled
Set-AzTrafficManagerProfile -TrafficManagerProfile $profile

.Inputs
Az.TrafficManager.Models.IProfile
.Outputs
Az.TrafficManager.Models.IProfile
#>
function Add-AzTrafficManagerEndpointConfig {
    [OutputType([Az.TrafficManager.Models.IProfile])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the endpoint to add.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${EndpointName},

        [Parameter(Mandatory, ValueFromPipeline, HelpMessage='The Traffic Manager profile object to add the endpoint to.')]
        [ValidateNotNullOrEmpty()]
        [Az.TrafficManager.Models.IProfile]
        ${TrafficManagerProfile},

        [Parameter(Mandatory, HelpMessage='The type of the endpoint (AzureEndpoints, ExternalEndpoints, or NestedEndpoints).')]
        [ValidateSet('AzureEndpoints', 'ExternalEndpoints', 'NestedEndpoints', IgnoreCase=$true)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Type},

        [Parameter(HelpMessage='The Azure resource ID of the endpoint target.')]
        [string]
        ${TargetResourceId},

        [Parameter(HelpMessage='The target FQDN of the endpoint.')]
        [string]
        ${Target},

        [Parameter(Mandatory, HelpMessage='The status of the endpoint (Enabled or Disabled).')]
        [ValidateSet('Enabled', 'Disabled', IgnoreCase=$false)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${EndpointStatus},

        [Parameter(HelpMessage='The weight of the endpoint for weighted routing.')]
        [System.Nullable[System.Int64]]
        ${Weight},

        [Parameter(HelpMessage='The priority of the endpoint for priority routing.')]
        [System.Nullable[System.Int64]]
        ${Priority},

        [Parameter(HelpMessage='The endpoint location for performance routing.')]
        [string]
        ${EndpointLocation},

        [Parameter(HelpMessage='If Always Serve is enabled, probing for endpoint health will be disabled.')]
        [ValidateSet('Enabled', 'Disabled', IgnoreCase=$false)]
        [string]
        ${AlwaysServe},

        [Parameter(HelpMessage='The minimum number of endpoints that must be available in the child profile. Only applicable to NestedEndpoints.')]
        [System.Nullable[System.Int64]]
        ${MinChildEndpoints},

        [Parameter(HelpMessage='The minimum number of IPv4 endpoints that must be available in the child profile. Only applicable to NestedEndpoints.')]
        [System.Nullable[System.Int64]]
        ${MinChildEndpointsIPv4},

        [Parameter(HelpMessage='The minimum number of IPv6 endpoints that must be available in the child profile. Only applicable to NestedEndpoints.')]
        [System.Nullable[System.Int64]]
        ${MinChildEndpointsIPv6},

        [Parameter(HelpMessage='The list of regions mapped to this endpoint for Geographic routing.')]
        [string[]]
        ${GeoMapping},

        [Parameter(HelpMessage='The list of subnets mapped to this endpoint for Subnet routing.')]
        [Az.TrafficManager.Models.IEndpointPropertiesSubnetsItem[]]
        ${SubnetMapping},

        [Parameter(HelpMessage='List of custom header name and value pairs for probe requests.')]
        [Az.TrafficManager.Models.IEndpointPropertiesCustomHeadersItem[]]
        ${CustomHeader}
    )

    process {
        # Check for duplicate endpoint name
        if ($TrafficManagerProfile.Endpoints) {
            $existing = $TrafficManagerProfile.Endpoints | Where-Object { $_.Name -eq $EndpointName }
            if ($existing) {
                throw "An endpoint with name '$EndpointName' already exists in the profile."
            }
        } else {
            $TrafficManagerProfile.Endpoints = [System.Collections.Generic.List[Az.TrafficManager.Models.IEndpoint]]::new()
        }

        # Build the endpoint object
        $endpoint = @{
            Name = $EndpointName
            Type = "Microsoft.Network/trafficManagerProfiles/$Type"
            EndpointStatus = $EndpointStatus
        }

        if ($PSBoundParameters.ContainsKey('TargetResourceId')) { $endpoint['TargetResourceId'] = $TargetResourceId }
        if ($PSBoundParameters.ContainsKey('Target')) { $endpoint['Target'] = $Target }
        if ($PSBoundParameters.ContainsKey('Weight')) { $endpoint['Weight'] = $Weight }
        if ($PSBoundParameters.ContainsKey('Priority')) { $endpoint['Priority'] = $Priority }
        if ($PSBoundParameters.ContainsKey('EndpointLocation')) { $endpoint['EndpointLocation'] = $EndpointLocation }
        if ($PSBoundParameters.ContainsKey('AlwaysServe')) { $endpoint['AlwaysServe'] = $AlwaysServe }
        if ($PSBoundParameters.ContainsKey('MinChildEndpoints')) { $endpoint['MinChildEndpoints'] = $MinChildEndpoints }
        if ($PSBoundParameters.ContainsKey('MinChildEndpointsIPv4')) { $endpoint['MinChildEndpointsIPv4'] = $MinChildEndpointsIPv4 }
        if ($PSBoundParameters.ContainsKey('MinChildEndpointsIPv6')) { $endpoint['MinChildEndpointsIPv6'] = $MinChildEndpointsIPv6 }
        if ($PSBoundParameters.ContainsKey('GeoMapping')) { $endpoint['GeoMapping'] = [System.Collections.Generic.List[string]]$GeoMapping }
        if ($PSBoundParameters.ContainsKey('SubnetMapping')) { $endpoint['Subnets'] = [System.Collections.Generic.List[Az.TrafficManager.Models.IEndpointPropertiesSubnetsItem]]$SubnetMapping }
        if ($PSBoundParameters.ContainsKey('CustomHeader')) { $endpoint['CustomHeaders'] = [System.Collections.Generic.List[Az.TrafficManager.Models.IEndpointPropertiesCustomHeadersItem]]$CustomHeader }

        # Add to profile's endpoint list
        $TrafficManagerProfile.Endpoints.Add([Az.TrafficManager.Models.Endpoint]$endpoint)

        Write-Output $TrafficManagerProfile
    }
}
