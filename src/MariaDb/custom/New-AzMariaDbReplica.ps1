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
Creates a replica of a MariaDB server.
.Description
Creates a replica of a MariaDB server.
#>
function New-AzMariaDbReplica {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(DefaultParameterSetName='ServerName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Replica name.')]
        [Alias('ReplicaServerName', 'Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # Replica name
        ${ReplicaName},

        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline, HelpMessage='The source server object to restore from.')]
        [Alias('InputObject')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer]
        # The source server object to restore from.
        ${Master},
    
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='MariaDB server name.')]
        [Alias('ServerName')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDB server name.
        ${MasterName},
    
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='You can obtain this value from the Azure Resource Manager API or the portal.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
        [Parameter(HelpMessage='The subscription ID is part of the URI for every service call.')]
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

        [Parameter(HelpMessage='The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        ${Sku},

        [Parameter(HelpMessage='Application-specific metadata in the form of key-value pairs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},
        #endregion ServerForCreate
    
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
            $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForReplica]::new()

            if($PSBoundParameters.ContainsKey('ReplicaName')) {
                $PSBoundParameters['Name'] = $PSBoundParameters['ReplicaName']
                $Null = $PSBoundParameters.Remove('ReplicaName')
            }
    
            #region ServerForCreate
            $ServerObject = $Master
            if (-not $PSBoundParameters.ContainsKey('Master')) {
                $GetMariadbDbPSBoundParameters = @{}
                if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
                    $GetMariadbDbPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
                }
                if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
                    $GetMariadbDbPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
                }
                $ServerObject = Get-AzMariaDbServer -ResourceGroupName $ResourceGroupName -Name $MasterName -SubscriptionId $SubscriptionId @GetMariadbDbPSBoundParameters
                
                # if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
                #     $ServerObject = Get-AzMariaDbServer -ResourceGroupName $ResourceGroupName -Name $MasterName -SubscriptionId $SubscriptionId -HttpPipelineAppend $HttpPipelineAppend
                # } else {
                #     $ServerObject = Get-AzMariaDbServer -ResourceGroupName $ResourceGroupName -Name $MasterName -SubscriptionId $SubscriptionId
                # }
                $Null = $PSBoundParameters.Remove('MasterName')
            } else {
                $Fields = $Master.Id.Split('/')
                $PSBoundParameters['SubscriptionId'] = $Fields[2]
                $PSBoundParameters['ResourceGroupName'] = $Fields[4]
                $Null = $PSBoundParameters.Remove('Master')
            }
            $Parameter.Property.SourceServerId = $ServerObject.Id
            
            if ($PSBoundParameters.ContainsKey('Location')) {
                $Parameter.Location = $PSBoundParameters['Location']
                $Null = $PSBoundParameters.Remove('Location')
            } else {
                $Parameter.Location = $ServerObject.Location
            }

            if ($PSBoundParameters.ContainsKey('Sku')) {
                $Parameter.SkuName = $PSBoundParameters['Sku']
                $Null = $PSBoundParameters.Remove('Sku')
            }

            if ($PSBoundParameters.ContainsKey('Tag')) {
                $PSBoundParameters.Tag = $PSBoundParameters['Tag']
                $Null = $PSBoundParameters.Remove('Tag')
            }
            #endregion ServerForCreate

            $Parameter.CreateMode = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode]::Replica


            $PSBoundParameters.Add('Parameter', $Parameter)

            Az.MariaDb.internal\New-AzMariaDbServer @PSBoundParameters
          } catch {
              throw
          }
    }
}
