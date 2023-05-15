
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
Lists entities from applications or get entity from applications by key
.Description
Lists entities from applications or get entity from applications by key
.Link
https://learn.microsoft.com/powershell/module/az.resources/get-azadapplication
#>
function Get-AzADApplication {
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
    [System.Guid]
    # application id
    ${ApplicationId},

    [Parameter(ParameterSetName='ApplicationIdentifierUriParameterSet', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Query')]
    [System.String]
    # application identifier uri
    ${IdentifierUri},

    [Parameter(ParameterSetName='OwnedApplicationParameterSet', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # get owned application
    ${OwnedApplication},

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
    # Filter items by property values, for more detail about filter query please see: https://learn.microsoft.com/en-us/graph/filter-query-parameter
    ${Filter},

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [Parameter(ParameterSetName='OwnedApplicationParameterSet')]
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

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Header')]
    [System.String]
    # Indicates the requested consistency level.
    # Documentation URL: https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/
    ${ConsistencyLevel},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
    [System.UInt64]
    # Gets only the first 'n' objects.
    ${First},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
    [System.UInt64]
    # Ignores the first 'n' objects and then gets the remaining objects.
    ${Skip},

    [Parameter(HelpMessage = "Append properties selected with default properties when this switch is on, only works with parameter '-Select'.")]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${AppendSelected},

    [Parameter(ParameterSetName='EmptyParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.String]
    # Specifies a count of the total number of items in a collection.
    # By default, this variable will be set in the global scope.
    ${CountVariable},

    [Parameter()]
    [Alias("AzContext", "AzureRmContext", "AzureCredential")]
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
    if ($PSBoundParameters['AppendSelected'] -and $PSBoundParameters['Select']) {
        $PSBoundParameters['Select'] += @('DisplayName', 'Id', 'DeletedDateTime', 'IdentifierUris', 'Web', 'AppId', 'SignInAudience')
        $null = $PSBoundParameters.Remove('AppendSelected')
    }

    switch ($PSCmdlet.ParameterSetName) {
        'ApplicationObjectIdParameterSet' {
            $PSBoundParameters['Id'] = $PSBoundParameters['ObjectId']
            $null = $PSBoundParameters.Remove('ObjectId')
            break
        }
        'SearchStringParameterSet' {
            $PSBoundParameters['Filter'] = "startsWith(DisplayName, '$($PSBoundParameters['DisplayNameStartWith'])')"
            $null = $PSBoundParameters.Remove('DisplayNameStartWith')
            break
        }
        'DisplayNameParameterSet' {
            $PSBOundParameters['Filter'] = "displayName eq '$($PSBoundParameters['DisplayName'])'"
            $null = $PSBoundParameters.Remove('DisplayName')
            break
        }
        'ApplicationIdentifierUriParameterSet' {
            $PSBOundParameters['Filter'] = "identifierUris/any(s:s eq '$($PSBoundParameters['IdentifierUri'])')"
            $null = $PSBoundParameters.Remove('IdentifierUri')
            break
        }
        'ApplicationIdParameterSet' {
            $PSBOundParameters['Filter'] = "appId eq '$($PSBoundParameters['ApplicationId'])'"
            $null = $PSBoundParameters.Remove('ApplicationId')
            break
        }
        'OwnedApplicationParameterSet' {
            $null = $PSBoundParameters.Remove("OwnedApplication")
            [System.Array]$apps = . Az.MSGraph.internal\Get-AzADUserOwnedApplication @PSBoundParameters
            $PSCmdlet.WriteObject($apps)
            return
        }
        default {
            break
        }
    }
    Az.MSGraph.internal\Get-AzADApplication @PSBoundParameters
}
}
