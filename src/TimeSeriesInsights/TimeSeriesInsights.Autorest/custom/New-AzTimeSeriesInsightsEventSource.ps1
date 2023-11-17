
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
Create an event source under the specified environment.
.Description
Create an event source under the specified environment.

.Link
https://learn.microsoft.com/powershell/module/az.timeseriesinsights/new-aztimeseriesinsightseventsource
#>
function New-AzTimeSeriesInsightsEventSource {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceResource])]
    [CmdletBinding(DefaultParameterSetName='eventhub', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
        [System.String]
        # The name of the Time Series Insights environment associated with the specified resource group.
        ${EnvironmentName},
    
        [Parameter(Mandatory)]
        [Alias('EventSourceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
        [System.String]
        # Name of the event source.
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
        [ArgumentCompleter({param ( $CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('Microsoft.EventHub', 'Microsoft.IoTHub')})]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind]
        # The kind of the event source.
        ${Kind},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The location of the resource.
        ${Location},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesTags]))]
        [System.Collections.Hashtable]
        # Key-value pairs of additional properties for the resource.
        ${Tag},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The name of the event/iot hub's consumer group that holds the partitions from which events will be read.
        ${ConsumerGroupName},

        [Parameter(ParameterSetName='eventhub', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The name of the event hub.
        ${EventHubName},

        [Parameter(ParameterSetName='iothub', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The name of the iot hub.
        ${IoTHubName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The name of the SAS key that grants the Time Series Insights service access to the event/iot hub.
        ${KeyName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The resource id of the event source in Azure Resource Manager.
        ${EventSourceResourceId},
        
        [Parameter(ParameterSetName='eventhub', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The name of the service bus that contains the event hub.
        ${ServiceBusNameSpace},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.Security.SecureString]
        # The value of the shared access key that grants the Time Series Insights service read access to the event/iot hub.
        ${SharedAccessKey},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
        [System.String]
        # The event property that will be used as the event source's timestamp.
        ${TimeStampPropertyName},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
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
            if ($PSBoundParameters['Kind'] -eq 'Microsoft.EventHub') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.EventHubEventSourceCreateOrUpdateParameters]::new()
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.EventHubEventSourceCreationProperties]::new()
                
                $Parameter.Property.EventHubName = $PSBoundParameters['EventHubName']
                $null = $PSBoundParameters.Remove('EventHubName')
                 
                $Parameter.Property.ServiceBusNameSpace = $PSBoundParameters['ServiceBusNameSpace']
                $null = $PSBoundParameters.Remove('ServiceBusNameSpace')
            } else {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IoTHubEventSourceCreateOrUpdateParameters]::new()
                $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IoTHubEventSourceCreationProperties]::new()
                
                $Parameter.Property.IoTHubName = $PSBoundParameters['IoTHubName']
                $null = $PSBoundParameters.Remove('IoTHubName')
            }
            $Parameter.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            $Parameter.Location = $PSBoundParameters['Location']
            $null = $PSBoundParameters.Remove('Location')
            
            $Parameter.Property.EventSourceResourceId = $PSBoundParameters['EventSourceResourceId']
            $null = $PSBoundParameters.Remove('EventSourceResourceId')

            $Parameter.Property.ConsumerGroupName = $PSBoundParameters['ConsumerGroupName']
            $null = $PSBoundParameters.Remove('ConsumerGroupName')

            $Parameter.Property.KeyName = $PSBoundParameters['KeyName']
            $null = $PSBoundParameters.Remove('KeyName')

            $Parameter.Property.SharedAccessKey = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($PSBoundParameters['SharedAccessKey']))
            $null = $PSBoundParameters.Remove('SharedAccessKey')

            if ($PSBoundParameters.ContainsKey('Tag')) {
                $Parameter.Tag = $PSBoundParameters['Tag']
                $null = $PSBoundParameters.Remove('Tag')
            }

            if ($PSBoundParameters.ContainsKey('TimeStampPropertyName')) {
                $Parameter.Property.TimeStampPropertyName = $PSBoundParameters['TimeStampPropertyName']
                $null = $PSBoundParameters.Remove('TimeStampPropertyName')
            }

            $null = $PSBoundParameters.Add('Parameter', $Parameter)

            Az.TimeSeriesInsights.internal\New-AzTimeSeriesInsightsEventSource @PSBoundParameters
        } catch {
            throw
        }
    }
    

}
    