<#
.Synopsis
Enables a Traffic Manager endpoint.
.Description
The Enable-AzTrafficManagerEndpoint cmdlet enables an endpoint in an Azure Traffic Manager profile.
You can specify the endpoint by name, type, profile name, and resource group, or you can pass an endpoint object.
.Example
Enable-AzTrafficManagerEndpoint -Name MyEndpoint -Type AzureEndpoints -ProfileName MyProfile -ResourceGroupName MyRG
.Example
Get-AzTrafficManagerEndpoint -Name MyEndpoint -Type AzureEndpoints -ProfileName MyProfile -ResourceGroupName MyRG | Enable-AzTrafficManagerEndpoint

.Inputs
Az.TrafficManager.Models.IEndpoint
.Outputs
System.Boolean
#>
function Enable-AzTrafficManagerEndpoint {
    [OutputType([bool])]
    [CmdletBinding(DefaultParameterSetName='Fields', SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, ParameterSetName='Fields', HelpMessage='The name of the Traffic Manager endpoint.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Name},

        [Parameter(Mandatory, ParameterSetName='Fields', HelpMessage='The type of the Traffic Manager endpoint.')]
        [ValidateSet('AzureEndpoints', 'ExternalEndpoints', 'NestedEndpoints', IgnoreCase=$true)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Type},

        [Parameter(Mandatory, ParameterSetName='Fields', HelpMessage='The name of the Traffic Manager profile.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${ProfileName},

        [Parameter(Mandatory, ParameterSetName='Fields', HelpMessage='The name of the resource group.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${ResourceGroupName},

        [Parameter(Mandatory, ValueFromPipeline, ParameterSetName='Object', HelpMessage='The Traffic Manager endpoint object.')]
        [ValidateNotNullOrEmpty()]
        [Az.TrafficManager.Models.IEndpoint]
        ${TrafficManagerEndpoint},

        [Parameter()]
        [string[]]
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Az.TrafficManager.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Az.TrafficManager.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $endpointName = $Name
        $endpointType = $Type
        $profName = $ProfileName
        $rgName = $ResourceGroupName

        if ($PSCmdlet.ParameterSetName -eq 'Object') {
            $endpointName = $TrafficManagerEndpoint.Name
            # Extract type, profile, and resource group from the endpoint Id
            if ($TrafficManagerEndpoint.Id -match '/resourceGroups/([^/]+)/.*trafficManagerProfiles/([^/]+)/([^/]+)/([^/]+)') {
                $rgName = $Matches[1]
                $profName = $Matches[2]
                $endpointType = $Matches[3]
                $endpointName = $Matches[4]
            }
        }

        if ($PSCmdlet.ShouldProcess($endpointName, 'Enable Traffic Manager Endpoint')) {
            $params = @{
                EndpointName = $endpointName
                EndpointType = $endpointType
                ProfileName = $profName
                ResourceGroupName = $rgName
                EndpointStatus = 'Enabled'
            }
            foreach ($key in @('SubscriptionId','DefaultProfile','Break','HttpPipelineAppend','HttpPipelinePrepend','Proxy','ProxyCredential','ProxyUseDefaultCredentials')) {
                if ($PSBoundParameters.ContainsKey($key)) {
                    $params[$key] = $PSBoundParameters[$key]
                }
            }

            $null = Update-AzTrafficManagerEndpoint @params
            Write-Output $true
        }
    }
}
