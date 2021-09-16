
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
Represents an Azure Active Directory object.
The directoryObject type is the base type for many other directory entity types.
.Description
Represents an Azure Active Directory object.
The directoryObject type is the base type for many other directory entity types.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication
.Link
https://docs.microsoft.com/powershell/module/az.resources/get-azmgapplication
#>
function Get-AzMgApplication {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication])]
[CmdletBinding(DefaultParameterSetName='EmptyParameterSet', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='ApplicationObjectIdParameterSet', Mandatory)]
    [Alias('Id')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Path')]
    [System.String]
    # key: id of application
    ${ObjectId},

    [Parameter(ParameterSetName='SearchStringParameterSet', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [Alias('DisplayNameStartsWith')]
    [System.String]
    # application display name starts with
    ${DisplayNameStartWith},

    [Parameter(ParameterSetName='DisplayNameParameterSet', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String]
    # application display name
    ${DisplayName},

    [Parameter(ParameterSetName='ApplicationIdParameterSet', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [Alias('AppId')]
    [System.String]
    # application id
    ${ApplicationId},

    [Parameter(ParameterSetName='ApplicationIdentifierUriParameterSet', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String]
    # application identifier uri
    ${IdentifierUri},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String[]]
    # Expand related entities
    ${Expand},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String[]]
    # Select properties to be returned
    ${Select},

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.Management.Automation.SwitchParameter]
    # Include count of items
    ${Count},

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String]
    # Filter items by property values
    ${Filter},

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String[]]
    # Order items by property values
    ${Orderby},

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String]
    # Search items by search phrases
    ${Search},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Header')]
    [System.String]
    # Indicates the requested consistency level.
    # Documentation URL: https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/
    ${ConsistencyLevel},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    switch ($PSCmdlet.ParameterSetName) {
        'ApplicationObjectIdParameterSet' {
            $PSBoundParameters['Id'] = $PSBoundParameters['ObjectId']
            $null = $PSBoundParameters.Remove('ObjectId')
            break
        }
        'SearchStringParameterSet' {
            $PSBoundParameters['ConsistencyLevel'] = 'eventual'
            $PSBoundParameters['Search'] = "DisplayName:$($PSBoundParameters['DisplayNameStartWith'])"
            $null = $PSBoundParameters.Remove('DisplayNameStartWith')
            break
        }
        'DisplayNameParameterSet' {
            $PSBoundParameters['ConsistencyLevel'] = 'eventual'
            $PSBoundParameters['Search'] = "DisplayName:$($PSBoundParameters['DisplayName'])"
            $null = $PSBoundParameters.Remove('DisplayName')
            break
        }
        'ApplicationIdentifierUriParameterSet' {
            $PSBoundParameters['ConsistencyLevel'] = 'eventual'
            $PSBoundParameters['Search'] = "IdentifierUri:$($PSBoundParameters['IdentifierUri'])"
            $null = $PSBoundParameters.Remove('IdentifierUri')
            break
        }
        'ApplicationIdParameterSet' {
            $PSBoundParameters['ConsistencyLevel'] = 'eventual'
            $PSBoundParameters['Search'] = "AppId:$($PSBoundParameters['ApplicationId'])"
            $null = $PSBoundParameters.Remove('ApplicationId')
            break
        }
        default {
            break
        }
    }
    MSGraph.internal\Get-AzMgApplication @PSBoundParameters
}
}
