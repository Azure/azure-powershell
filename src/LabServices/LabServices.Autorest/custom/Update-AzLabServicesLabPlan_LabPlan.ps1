# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# This variant is duplicated with UpdateViaIdentityExpanded
function Update-AzLabServicesLabPlan_LabPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabPlan])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.LabPlan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    # The object of lab service lab plan.
    ${LabPlan},

    [Parameter()]
    [String[]]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # The allowed regions for the lab creator to use when creating labs using this lab plan.
    ${AllowedRegion},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # The amount of time a VM will stay running after a user disconnects if this behavior is enabled.
    ${DefaultAutoShutdownProfileDisconnectDelay},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # The amount of time a VM will idle before it is shutdown if this behavior is enabled.
    ${DefaultAutoShutdownProfileIdleDelay},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # The amount of time a VM will stay running before it is shutdown if no connection is made and this behavior is enabled.
    ${DefaultAutoShutdownProfileNoConnectDelay},
    
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [String]
    # Whether shutdown on disconnect is enabled
    ${DefaultAutoShutdownProfileShutdownOnDisconnect},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.PSArgumentCompleterAttribute("None", "UserAbsence", "LowUsage")]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [String]
    # Whether a VM will get shutdown when it has idled for a period of time.
    ${DefaultAutoShutdownProfileShutdownOnIdle},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [String]
    # Whether a VM will get shutdown when it hasn't been connected to after a period of time.
    ${DefaultAutoShutdownProfileShutdownWhenNotConnected},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.PSArgumentCompleterAttribute("Public", "Private", "None")]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [String]
    # The enabled access level for Client Access over RDP.
    ${DefaultConnectionProfileClientRdpAccessEnabled},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.PSArgumentCompleterAttribute("Public", "Private", "None")]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [String]
    # The enabled access level for Client Access over SSH.
    ${DefaultConnectionProfileClientSshAccessEnabled},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # The external subnet resource id
    ${DefaultNetworkProfileSubnetId},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Base Url of the lms instance this lab plan can link lab rosters against.
    ${LinkedLmsInstance},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Resource ID of the Shared Image Gallery attached to this lab plan.
    # When saving a lab template virtual machine image it will be persisted in this gallery.
    # Shared images from the gallery can be made available to use when creating new labs.
    ${SharedGalleryId},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Support contact email address.    
    ${SupportInfoEmail},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Support instructions.
    ${SupportInfoInstruction},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Support contact phone number.
    ${SupportInfoPhone},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Support web address.
    ${SupportInfoUrl},

    [Parameter()]
    [String[]]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},
    
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},
    
    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {    
    $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
    $PSBoundParameters.Remove("LabPlan") > $null
    return Az.LabServices\Update-AzLabServicesLabPlan @PSBoundParameters
}

}
