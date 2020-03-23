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
function Restore-AzMariaDbServer
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The dest server name to restore from.
        ${Name},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The source server name to restore from.
        ${ServerName},

        [Parameter(ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
        # The source server object to restore from.
        ${Server},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets the subscription Id which uniquely identifies the Microsoft Azure subscription.
        # The subscription ID is part of the URI for every service call.
        ${SubscriptionId},
    
        #region ServerForCreate
        [Parameter(HelpMessage='The location the resource resides in.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The location the resource resides in.
        ${Location},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},

        #region PointInTimeRestore
        [Parameter(ParameterSetName='PointInTimeRestore', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.DateTime]
        # The location the resource resides in.
        ${RestorePointInTime},

        [Parameter(ParameterSetName='PointInTimeRestore', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Switch]
        # Use PointInTimeRestore mode.
        ${UsePointInTimeRestore},
        #endregion PointInTimeRestore

        #region Geo
        [Parameter(ParameterSetName='GeoRestore', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Switch]
        # Use GeoRestore mode.
        ${UseGeoRetore},
        #endregion Geo

        #region DefaultParameters
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
        #endregion DefaultParameters
    )
    
    process {
        try {
            $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreate]::new()
            if ($PSBoundParameters.ContainsKey('UsePointInTimeRestore')) {
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForRestore]::new()
                $Parameter.Property.RestorePointInTime = $RestorePointInTime
                $Null = $PSBoundParameters.Remove('RestorePointInTime')
                $Null = $PSBoundParameters.Remove('UsePointInTimeRestore')
            } elseif ($PSBoundParameters.ContainsKey('UseGeoRetore')) {
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForGeoRestore]::new()
                $Null = $PSBoundParameters.Remove('UseGeoRetore')
            }

            if ($PSBoundParameters.ContainsKey('Server')) {
                $Null = $PSBoundParameters.Remove('Server')
            } else {
                $Server = Get-AzMariaDbServer -ResourceGroupName $ResourceGroupName -Name $ServerName
            }
            $Parameter.Property.SourceServerId = $Server.Id
            if (-ne $PSBoundParameters.ContainsKey('Location')) {
                $Location = $Server.Location
            }

            $PSBoundParameters.Add('Parameter', $Parameter)

            Az.MariaDb.internal\New-AzMariaDbServer @PSBoundParameters
          } catch {
              throw
          }
    }
}
