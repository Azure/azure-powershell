<#
.Synopsis
Disables a Traffic Manager endpoint.
.Description
The Disable-AzTrafficManagerEndpoint cmdlet disables an endpoint in an Azure Traffic Manager profile.
You can specify the endpoint by name, type, profile name, and resource group, or you can pass an endpoint object.
Use the Force parameter to suppress the confirmation prompt.
.Example
Disable-AzTrafficManagerEndpoint -Name MyEndpoint -Type AzureEndpoints -ProfileName MyProfile -ResourceGroupName MyRG
.Example
Disable-AzTrafficManagerEndpoint -Name MyEndpoint -Type AzureEndpoints -ProfileName MyProfile -ResourceGroupName MyRG -Force

.Inputs
Az.TrafficManager.Models.IEndpoint
.Outputs
System.Boolean
#>
function Disable-AzTrafficManagerEndpoint {
    [OutputType([bool])]
    [CmdletBinding(DefaultParameterSetName='Fields', SupportsShouldProcess, ConfirmImpact='High')]
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

        [Parameter(HelpMessage='Do not ask for confirmation.')]
        [System.Management.Automation.SwitchParameter]
        ${Force},

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
            if ($TrafficManagerEndpoint.Id -match '/resourceGroups/([^/]+)/.*trafficManagerProfiles/([^/]+)/([^/]+)/([^/]+)') {
                $rgName = $Matches[1]
                $profName = $Matches[2]
                $endpointType = $Matches[3]
                $endpointName = $Matches[4]
            }
        }

        # Normalize endpoint type from ARM camelCase to PascalCase
        $typeMap = @{ 'azureendpoints' = 'AzureEndpoints'; 'externalendpoints' = 'ExternalEndpoints'; 'nestedendpoints' = 'NestedEndpoints' }
        if ($typeMap.ContainsKey($endpointType.ToLower())) {
            $endpointType = $typeMap[$endpointType.ToLower()]
        }

        if ($Force) {
            $ConfirmPreference = 'None'
        }

        if ($PSCmdlet.ShouldProcess($endpointName, 'Disable Traffic Manager Endpoint')) {
            $params = @{
                EndpointName = $endpointName
                EndpointType = $endpointType
                ProfileName = $profName
                ResourceGroupName = $rgName
                EndpointStatus = 'Disabled'
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
