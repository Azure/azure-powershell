
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
Updates an access rule.
.Description
Updates an access rule.
#>
function Update-AzNetworkSecurityPerimeterAccessRule {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.INspAccessRule])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(

        #Runtime paramters    

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials},


        # Azure parameters
        
        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},


        #Path parameters

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(ParameterSetName = 'UpdateExpanded', HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the access rule.")]
        [Alias('AccessRuleName')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Path')]
        [System.String]
        # The name of the access rule.
        ${Name},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the network security perimeter")]
        [Alias('NetworkSecurityPerimeterName')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Path')]
        [System.String]
        # The name of the network security perimeter.
        ${SecurityPerimeterName},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory, HelpMessage = "The name of the profile")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Path')]
        [System.String]
        # The name of the profile.
        ${ProfileName},


        # Body paramters

        [Parameter(HelpMessage = "Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.IResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags.
        ${Tag},

        [Parameter(HelpMessage = "Location of the resource")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [System.String]
        # The Location of the resource
        ${Location},
        
        [Parameter(HelpMessage = "Address Prefix")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [System.Collections.ArrayList]
        # Address Prefix
        ${AddressPrefix},

        [Parameter(HelpMessage = "Fully qualified domain name")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [System.Collections.ArrayList]
        # Fully qualified domain name
        ${FullyQualifiedDomainName},

        [Parameter(HelpMessage = "Email Addresses")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [System.Collections.ArrayList]
        # Email Addresses
        ${EmailAddress},

        [Parameter(HelpMessage = "Phone Numbers")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [System.Collections.ArrayList]
        # Phone Numbers
        ${PhoneNumber},

        [Parameter(HelpMessage = "Inbound rule specified by the perimeter id")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.IPerimeterBasedAccessRule[]]
        # Inbound rule specified by the perimeter id
        ${Perimeter},

        [Parameter(HelpMessage = "Direction")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [System.String]
        # Direction
        ${Direction},

        [Parameter(HelpMessage = "Subscription ids")]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.ISubscriptionId[]]
        # Subscription ids
        ${Subscription}

        # Add only those paramters which can be updated

    )


 
    process {
        try {
            
            # 1. GET

            # body params and AsJob
            $bodyParams = 'Tag', 'Location', 'AddressPrefix', 'FullyQualifiedDomainName', 'Perimeter', 'Direction', 'Subscription', 'EmailAddress', 'PhoneNumber',  'AsJob'

            $bodyParamsMap = @{}

            ForEach($bodyParam in $bodyParams){
                $bodyParamsMap[$bodyParam] = $PSBoundParameters.Remove($bodyParam)
            }

            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')


            $GETObject = Get-AzNetworkSecurityPerimeterAccessRule @PSBoundParameters

            # 2. PUT

            $pathParams = 'InputObject', 'ResourceGroupName', 'Name', 'SubscriptionId', 'SecurityPerimeterName', 'ProfileName'

            ForEach($pathParam in $pathParams){        
                $null = $PSBoundParameters.Remove($pathParam)
            }

            foreach ($item in $bodyParamsMap.GetEnumerator() )
            {
                if ($item.Value){
                    $key = $item.Key

                    $variable = (Get-Variable $key -ValueOnly)

                    $GETObject.$key = $variable
                }
            }
            
            # Call PUT method
            New-AzNetworkSecurityPerimeterAccessRule_CreateViaIdentity -InputObject $GETObject -Parameter $GETObject @PSBoundParameters

        }

        catch {
            throw
        }
    }
}
