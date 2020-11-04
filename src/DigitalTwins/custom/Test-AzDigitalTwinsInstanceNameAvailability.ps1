
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

<#
.Synopsis
Check if a DigitalTwinsInstance name is available.
.Description
Check if a DigitalTwinsInstance name is available.
.Example
PS C:\> Test-AzDigitalTwinsInstanceNameAvailability -Location eastus -name YouriDigitalTwinsTest

Message                                                                                                                          NameAvailable Reason
-------                                                                                                                          ------------- ------
A DigitalTwins instance with the name 'YouriDigitalTwinsTest' already exists in region 'eastus'. Please choose a different name. False         AlreadyExists
.Example
PS C:\> $testDigitalTwinsName = New-AzDigitalTwinsCheckNameRequestObject -name youriNameTest
Test-AzDigitalTwinsInstanceNameAvailability -Location eastus -DigitalTwinsInstanceCheckName $testDigitalTwinsName

Message               NameAvailable Reason
-------               ------------- ------
'youriNameTest' is available. True
.Example
PS C:\>$get 
$testDigitalTwinsName = New-AzDigitalTwinsCheckNameRequestObject -name youriNameTest
Test-AzDigitalTwinsInstanceNameAvailability -Location eastus -DigitalTwinsInstanceCheckName $testDigitalTwinsName

Message               NameAvailable Reason
-------               ------------- ------
'youriNameTest' is available. True
.Example
PS C:\> $testDigitalTwinsName = New-AzDigitalTwinsCheckNameRequestObject -name youriNameTest
Test-AzDigitalTwinsInstanceNameAvailability -Location eastus -DigitalTwinsInstanceCheckName $testDigitalTwinsName

Message               NameAvailable Reason
-------               ------------- ------
'youriNameTest' is available. True

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ICheckNameRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ICheckNameResult
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DIGITALTWINSINSTANCECHECKNAME <ICheckNameRequest>: The result returned from a database check name availability request.
  Name <String>: Resource name.

INPUTOBJECT <IDigitalTwinsIdentity>: Identity Parameter
  [EndpointName <String>]: Name of Endpoint Resource.
  [Id <String>]: Resource identity path
  [Location <String>]: Location of DigitalTwinsInstance.
  [ResourceGroupName <String>]: The name of the resource group that contains the DigitalTwinsInstance.
  [ResourceName <String>]: The name of the DigitalTwinsInstance.
  [SubscriptionId <String>]: The subscription identifier.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.digitaltwins/test-azdigitaltwinsinstancenameavailability
#>
function Test-AzDigitalTwinsInstanceNameAvailability {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ICheckNameResult])]
[CmdletBinding(DefaultParameterSetName='CheckExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Check', Mandatory)]
    [Parameter(ParameterSetName='CheckExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [System.String]
    # Location of DigitalTwinsInstance.
    ${Location},

    [Parameter(ParameterSetName='Check')]
    [Parameter(ParameterSetName='CheckExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CheckViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Check', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CheckViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.ICheckNameRequest]
    # The result returned from a database check name availability request.
    # To construct, see NOTES section for DIGITALTWINSINSTANCECHECKNAME properties and create a hash table.
    ${DigitalTwinsInstanceCheckName},

    [Parameter(ParameterSetName='CheckExpanded', Mandatory)]
    [Parameter(ParameterSetName='CheckViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # Resource name.
    ${Name},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
    )
    process {
        try {
            if($PSBoundParameters['InputObject'] -ne $null)
            {
                $InputDigtalTwinsObject = $PSBoundParameters['InputObject']
                $Url = $InputDigtalTwinsObject.Id
                $UrlSplitList = $Url.Split('/')
                $ResourceReplaceString = -join ($UrlSplitList[3],'/',$UrlSplitList[4],'/')
                $GetUrl = $Url.Replace($ResourceReplaceString,'')
                $DigitalTwinsReplaceString = -join ($UrlSplitList[7],'/',$UrlSplitList[8])
                $AddLocationsString = -join('locations/',$InputDigtalTwinsObject.Location)
                $FinalUrl = $GetUrl.Replace($DigitalTwinsReplaceString,$AddLocationsString)
                $OutputDigitalTwinObject = New-AzDigitalTwinsDigitalTwinsIdentityObject -Id $FinalUrl -Location $InputDigtalTwinsObject.Location
                $null = $PSBoundParameters.Remove('InputObject')
                $null = $PSBoundParameters.Add("InputObject",$OutputDigitalTwinObject)    
            }
           Az.DigitalTwins.internal\Test-AzDigitalTwinsInstanceNameAvailability @PSBoundParameters
        } catch {
            throw
        }
    }
}
