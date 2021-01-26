
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
Creates a new database or updates an existing database.
.Description
Creates a new database or updates an existing database.
#>
function Update-AzMySqlFlexibleServerDatabase {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IDatabase])]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='Update', Mandatory)]
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Alias('DatabaseName')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
        [System.String]
        # The name of the database.
        ${Name},
    
        [Parameter(ParameterSetName='Update', Mandatory)]
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='Update', Mandatory)]
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
        [System.String]
        # The name of the server.
        ${ServerName},
    
        [Parameter(ParameterSetName='Update')]
        [Parameter(ParameterSetName='UpdateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.IMySqlIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IDatabase]
        # Represents a Database.
        # To construct, see NOTES section for PARAMETER properties and create a hash table.
        ${Parameter},
    
        [Parameter(ParameterSetName='UpdateExpanded')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
        [System.String]
        # The charset of the database.
        ${Charset},
    
        [Parameter(ParameterSetName='UpdateExpanded')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
        [System.String]
        # The collation of the database.
        ${Collation},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        try {
            
            if($PSBoundParameters.ContainsKey('InputObject')){
                $PSBoundParameters.InputObject.Id = $PSBoundParameters.InputObject.Id.Replace("DBforMySQL","DBForMySql")
            }   

            Az.MySql.internal\Update-AzMySqlFlexibleServerDatabase @PSBoundParameters
        } catch {
            throw
        }
    }
    }
    