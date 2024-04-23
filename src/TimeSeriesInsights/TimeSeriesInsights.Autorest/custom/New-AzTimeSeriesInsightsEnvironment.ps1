
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
Create an environment in the specified subscription and resource group.
.Description
Create an environment in the specified subscription and resource group.

.Link
https://learn.microsoft.com/powershell/module/az.timeseriesinsights/new-aztimeseriesinsightsenvironment
#>
function New-AzTimeSeriesInsightsEnvironment {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEnvironmentResource])]
    [CmdletBinding(DefaultParameterSetName='Gen1', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('EnvironmentName')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
        [System.String]
        # Name of the environment
        ${Name},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
        [System.String]
        # Name of an Azure Resource group.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter({param ( $CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('Gen1', 'Gen2')})]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind]
        # The kind of the environment.
        ${Kind},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The location of the resource.
        ${Location},
    
        [Parameter(ParameterSetName='Gen1', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.Int32]
        # The capacity of the sku.
        # For Gen1 environments, this value can be changed to support scale out of environments after they have been created.
        ${Capacity},
    
        [Parameter(ParameterSetName='Gen1', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.TimeSpan]
        # The data retention time.
        ${DataRetentionTime},

        [Parameter(ParameterSetName='Gen1')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty[]]
        # The list of event properties which will be used to partition data in the environment.
        ${PartitionKeyProperty},

        [Parameter(ParameterSetName='Gen1')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The behavior the Time Series Insights service should take when the environment's capacity has been exceeded
        ${StorageLimitExceededBehavior},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName]
        # The name of this SKU.
        ${Sku},
    
        [Parameter(ParameterSetName='Gen2', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty[]]
        # The list of event properties which will be used to define the environment's time series id.
        ${TimeSeriesIdProperty},

        [Parameter(ParameterSetName='Gen2', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The name of the storage account that will hold the environment's long term data.
        ${StorageAccountName},

        [Parameter(ParameterSetName='Gen2', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.Security.SecureString]
        # The value of the management key that grants the Time Series Insights service write access to the storage account.
        ${StorageAccountKey},

        [Parameter(ParameterSetName='Gen2')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.TimeSpan]
        # ISO8601 timespan specifying the number of days the environment's events will be available for query from the warm store.
        ${WarmStoreDataRetentionTime},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesTags]))]
        [System.Collections.Hashtable]
        # Key-value pairs of additional properties for the resource.
        ${Tag},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    

    
    process {
        try {
            if ($PSBoundParameters['Kind'] -eq 'Gen1') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.Gen1EnvironmentCreateOrUpdateParameters]::new()
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.Gen1EnvironmentCreationProperties]::new()
                
                $Parameter.SkuCapacity = $PSBoundParameters['Capacity']
                $null = $PSBoundParameters.Remove('Capacity')

                $Parameter.Property.DataRetentionTime = $PSBoundParameters['DataRetentionTime']
                $null = $PSBoundParameters.Remove('DataRetentionTime')
                
                if ($PSBoundParameters.ContainsKey('PartitionKeyProperty')) { 
                    $Parameter.Property.PartitionKeyProperty = $PSBoundParameters['PartitionKeyProperty']
                    $null = $PSBoundParameters.Remove('PartitionKeyProperty')
                }

                if ($PSBoundParameters.ContainsKey('StorageLimitExceededBehavior')) {
                    $Parameter.Property.StorageLimitExceededBehavior = $PSBoundParameters['StorageLimitExceededBehavior']
                    $null = $PSBoundParameters.Remove('StorageLimitExceededBehavior')
                }
            } else {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.Gen2EnvironmentCreateOrUpdateParameters]::new()
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.Gen2EnvironmentCreationProperties]::new()
                
                $Parameter.Property.StorageConfigurationAccountName = $PSBoundParameters['StorageAccountName']
                $null = $PSBoundParameters.Remove('StorageAccountName')

                $Parameter.Property.StorageConfigurationManagementKey = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($PSBoundParameters['StorageAccountKey']))
                $null = $PSBoundParameters.Remove('StorageAccountKey')

                $Parameter.Property.TimeSeriesIdProperty = $PSBoundParameters['TimeSeriesIdProperty']
                $null = $PSBoundParameters.Remove('TimeSeriesIdProperty')
                
                # For L1, SkuCapacity is 1, which is a service side behavior
                $Parameter.SkuCapacity = 1

                if ($PSBoundParameters.ContainsKey('WarmStoreDataRetentionTime')) {
                    $Parameter.Property.WarmStoreConfigurationDataRetention = $PSBoundParameters['WarmStoreDataRetentionTime']
                    $null = $PSBoundParameters.Remove('WarmStoreDataRetentionTime')
                }
            }
            $Parameter.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            $Parameter.Location = $PSBoundParameters['Location']
            $null = $PSBoundParameters.Remove('Location')

            $Parameter.SkuName = $PSBoundParameters['Sku']
            $null = $PSBoundParameters.Remove('Sku')

            if ($PSBoundParameters.ContainsKey('Tag')) {
                $Parameter.Tag = $PSBoundParameters['Tag']
                $null = $PSBoundParameters.Remove('Tag')
            }

            $null = $PSBoundParameters.Add('Parameter', $Parameter)

            Az.TimeSeriesInsights.internal\New-AzTimeSeriesInsightsEnvironment @PSBoundParameters
        } catch {
            throw
        }
    }
}
    