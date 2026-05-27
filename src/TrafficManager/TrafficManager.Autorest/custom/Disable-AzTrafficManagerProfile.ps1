<#
.Synopsis
Disables a Traffic Manager profile.
.Description
The Disable-AzTrafficManagerProfile cmdlet disables an Azure Traffic Manager profile.
You can specify the profile by name and resource group, or you can pass a profile object.
Use the Force parameter to suppress the confirmation prompt.
.Example
Disable-AzTrafficManagerProfile -Name MyProfile -ResourceGroupName MyResourceGroup
.Example
Disable-AzTrafficManagerProfile -Name MyProfile -ResourceGroupName MyResourceGroup -Force

.Inputs
Az.TrafficManager.Models.IProfile
.Outputs
System.Boolean
#>
function Disable-AzTrafficManagerProfile {
    [OutputType([bool])]
    [CmdletBinding(DefaultParameterSetName='Fields', SupportsShouldProcess, ConfirmImpact='High')]
    param(
        [Parameter(Mandatory, ParameterSetName='Fields', HelpMessage='The name of the Traffic Manager profile.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Name},

        [Parameter(Mandatory, ParameterSetName='Fields', HelpMessage='The name of the resource group.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${ResourceGroupName},

        [Parameter(Mandatory, ValueFromPipeline, ParameterSetName='Object', HelpMessage='The Traffic Manager profile object.')]
        [ValidateNotNullOrEmpty()]
        [Az.TrafficManager.Models.IProfile]
        ${TrafficManagerProfile},

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
        $profileName = $Name
        $rgName = $ResourceGroupName

        if ($PSCmdlet.ParameterSetName -eq 'Object') {
            $profileName = $TrafficManagerProfile.Name
            if ($TrafficManagerProfile.Id -match '/resourceGroups/([^/]+)/') {
                $rgName = $Matches[1]
            }
        }

        $confirmMessage = "Are you sure you want to disable the Traffic Manager profile '$profileName'?"
        if ($Force -or $PSCmdlet.ShouldContinue($confirmMessage, 'Disable Traffic Manager Profile')) {
            $params = @{
                ProfileName = $profileName
                ResourceGroupName = $rgName
                ProfileStatus = 'Disabled'
            }
            foreach ($key in @('SubscriptionId','DefaultProfile','Break','HttpPipelineAppend','HttpPipelinePrepend','Proxy','ProxyCredential','ProxyUseDefaultCredentials')) {
                if ($PSBoundParameters.ContainsKey($key)) {
                    $params[$key] = $PSBoundParameters[$key]
                }
            }

            $null = Update-AzTrafficManagerProfile @params
            Write-Output $true
        }
    }
}
