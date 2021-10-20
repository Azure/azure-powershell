# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# https://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

function Add-AzAdAppPermission {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='ObjectIdParameterSet', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='ObjectIdParameterSet', Mandatory, HelpMessage = "The unique identifier in Azure AD.")]
        [System.Guid]
        # key: id of group
        ${ObjectId},

        [Parameter(ParameterSetName='AppIdParameterSet', Mandatory, HelpMessage = "The unique identifier for the application that is assigned by Azure AD.")]
        [System.Guid]
        # The unique identifier for the application that is assigned by Azure AD.
        ${ApplicationId},

        [Parameter(Mandatory, HelpMessage = "The unique identifier for the resource that the application requires access to.  This should be equal to the appId declared on the target resource application.")]
        [ValidateNotNull()]
        [System.Guid]
        ${ApiId},

        [Parameter(Mandatory, HelpMessage = "The unique identifier for one of the oauth2PermissionScopes or appRole instances that the resource application exposes.")]
        [ValidateNotNull()]
        [System.String]
        ${PermissionId},

        [Parameter(HelpMessage = "Specifies whether the id property references an oauth2PermissionScopes or an appRole.")]
        [ValidateNotNull()]
        [System.String]
        ${Type},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        switch ($PSCmdlet.ParameterSetName) {
            'ObjectIdParameterSet' {
                $app = MSGraph.internal\Get-AzAdApplication -Id $PSBoundParameters['ObjectId']
                if($null -eq $app) {
                    Write-Error "Cannot find application by ObjectId $($PSBoundParameters['ObjectId'])"
                }
                break
            }
            'AppIdParameterSet' {
                $app = Get-AzAdApplication -ApplicationId $PSBoundParameters['ApplicationId']
                if($null -eq $app) {
                    Write-Error "Cannot find application by ApplicationId $($PSBoundParameters['ApplicationId'])"
                }
                break
            }
            default {
                break
            }
        }

        $newRequiredResourceAccess = @()
        $foundRequiredResourceAccessItem = $null
        $newRequiredResourceAccessItem = $null
        foreach ($item in $app.RequiredResourceAccess) {
            if($item.resourceAppId -eq $ApiId) {
                $foundRequiredResourceAccessItem = $item
            } else {
                $newRequiredResourceAccess += $item
            }
        }

        $newRequiredResourceAccessItem = New-Object Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphRequiredResourceAccess
        $newRequiredResourceAccessItem.resourceAppId = $ApiId
        $newRequiredResourceAccessItem.resourceAccess = @()

        foreach ($item in $foundRequiredResourceAccessItem.ResourceAccess) {
            if($item.Id -eq $PermissionId) {
                Write-Error "API permission with id '$($PSBoundParameters['PermissionId'])' already exists."
                return
            }
            $newRequiredResourceAccessItem.resourceAccess += $item
        }

        $newResourceAccess = New-Object Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphResourceAccess
        $newResourceAccess.Id = $PermissionId
        $newResourceAccess.Type = $Type
        
        $newRequiredResourceAccessItem.resourceAccess += $newResourceAccess
        $newRequiredResourceAccess += $newRequiredResourceAccessItem
        $null = Update-AzAdApplication -InputObject $app -RequiredResourceAccess $newRequiredResourceAccess
    }
}
