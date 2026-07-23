<#
.Synopsis
Enables a Traffic Manager profile.
.Description
The Enable-AzTrafficManagerProfile cmdlet enables an Azure Traffic Manager profile.
You can specify the profile by name and resource group, or you can pass a profile object.
.Example
Enable-AzTrafficManagerProfile -Name MyProfile -ResourceGroupName MyResourceGroup
.Example
Get-AzTrafficManagerProfile -ProfileName MyProfile -ResourceGroupName MyResourceGroup | Enable-AzTrafficManagerProfile

.Inputs
Az.TrafficManager.Models.IProfile
.Outputs
System.Boolean
#>
function Enable-AzTrafficManagerProfile {
    [OutputType([bool])]
    [CmdletBinding(DefaultParameterSetName='Fields', SupportsShouldProcess, ConfirmImpact='Medium')]
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
            # Extract resource group from the profile Id
            if ($TrafficManagerProfile.Id -match '/resourceGroups/([^/]+)/') {
                $rgName = $Matches[1]
            }
        }

        if ($PSCmdlet.ShouldProcess($profileName, 'Enable Traffic Manager Profile')) {
            $params = @{
                ProfileName = $profileName
                ResourceGroupName = $rgName
                ProfileStatus = 'Enabled'
            }
            # Forward common parameters
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
