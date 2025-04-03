
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
Updates a data connection.
.Description
Updates a data connection.
.Example
$dataConnectionProperties = New-Object -Type Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.EventHubDataConnection -Property @{Location="East US"; Kind="EventHub"; EventHubResourceId="/subscriptions/$subscriptionId/resourcegroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub"; DataFormat="JSON"; ConsumerGroup='Default'; Compression= "None"; TableName = "Events"; MappingRuleName = "EventsMapping1"}
Update-AzKustoDataConnection -ResourceGroupName $resourceGroupName -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "mykustodataconnection" -Parameter $dataConnectionProperties

Kind     Location Name                                               Type
----     -------- ----                                               ----
EventHub East US  testnewkustocluster/mykustodatabase/mykustodataconnection Microsoft.Kusto/Clusters/Databases/DataConnections

.Link
https://learn.microsoft.com/powershell/module/az.kusto/update-azkustodataconnection
#>
function Update-AzKustoDataConnection {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDataConnection])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpandedEventHub', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the Kusto cluster.
        ${ClusterName},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the database in the Kusto cluster.
        ${DatabaseName},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Alias('DataConnectionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the data connection.
        ${Name},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the resource group containing the Kusto cluster.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(Mandatory)]
        [ArgumentCompleter( { param ( $CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('EventHub', 'EventGrid', 'IotHub', 'CosmosDb') })]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind]
        # Kind of the endpoint for the data connection
        ${Kind},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The resource ID of the event hub to be used to create a data connection / event grid is configured to send events.
        ${EventHubResourceId},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The event/iot hub consumer group.
        ${ConsumerGroup},

        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType]
        # The name of blob storage event type to process.
        ${BlobStorageEventType},

        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # If set to true, indicates that ingestion should ignore the first record of every file.
        ${IgnoreFirstRecord},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        [ValidateSet( "MULTIJSON", "JSON", "CSV", "TSV", "SCSV", "SOHSV", "PSV", "TXT", "RAW", "SINGLEJSON", "AVRO", "TSVE", "PARQUET", "ORC", "APACHEAVRO", "W3CLOGFILE")]
        # The data format of the message. Optionally the data format can be added to each message.
        ${DataFormat},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String[]]
        # System properties of the event/iot hub.
        ${EventSystemProperty},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        ${MappingRuleName},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The table where the data should be ingested. Optionally the table information can be added to each message.
        ${TableName},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression]
        # The event hub messages compression type.
        ${Compression},

        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The resource ID of the storage account where the data resides.
        ${StorageAccountResourceId},

        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The resource ID of the Iot hub to be used to create a data connection.
        ${IotHubResourceId},

        [Parameter(ParameterSetName = 'UpdateExpandedIotHub', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The name of the share access policy.
        ${SharedAccessPolicyName},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The resource ID of a managed identity (system or user assigned) to be used to authenticate with external resources.
        ${ManagedIdentityResourceId},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabaseRouting]
        # Indication for database routing information from the data connection, by default only database routing information is allowed.
        ${DatabaseRouting},

        [Parameter(ParameterSetName = 'UpdateExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedIotHub')]
        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.DateTime]
        # When defined, the data connection retrieves existing Event hub events created since the Retrieval start date. It can only retrieve events retained by the Event hub, based on its retention period.
        ${RetrievalStartDate},

        [Parameter(ParameterSetName = 'UpdateExpandedEventGrid')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEventGrid')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The resource ID of the event grid that is subscribed to the storage account events.
        ${EventGridResourceId},

        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The resource ID of the Cosmos DB account used to create the data connection.
        ${CosmosDbAccountResourceId},

        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The name of an existing database in the Cosmos DB account.
        ${CosmosDbDatabase},

        [Parameter(ParameterSetName = 'UpdateExpandedCosmosDb', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedCosmosDb', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # The name of an existing container in the Cosmos DB database.
        ${CosmosDbContainer},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # Resource location.
        ${Location},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            if ($PSBoundParameters['Kind'] -eq 'EventHub') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.EventHubDataConnection]::new()
                
                $Parameter.EventHubResourceId = $PSBoundParameters['EventHubResourceId']            
                $null = $PSBoundParameters.Remove('EventHubResourceId')

                if ($PSBoundParameters.ContainsKey('DataFormat')) {
                    $Parameter.DataFormat = $PSBoundParameters['DataFormat']
                    $null = $PSBoundParameters.Remove('DataFormat')
                }

                if ($PSBoundParameters.ContainsKey('ConsumerGroup')) {
                    $Parameter.ConsumerGroup = $PSBoundParameters['ConsumerGroup']
                    $null = $PSBoundParameters.Remove('ConsumerGroup')
                }
                
                if ($PSBoundParameters.ContainsKey('EventSystemProperty')) {
                    $Parameter.EventSystemProperty = $PSBoundParameters['EventSystemProperty']
                    $null = $PSBoundParameters.Remove('EventSystemProperty')
                }

                if ($PSBoundParameters.ContainsKey('Compression')) {
                    $Parameter.Compression = $PSBoundParameters['Compression']
                    $null = $PSBoundParameters.Remove('Compression')
                }

                if ($PSBoundParameters.ContainsKey('ManagedIdentityResourceId')) {
                    $Parameter.ManagedIdentityResourceId = $PSBoundParameters['ManagedIdentityResourceId']
                    $null = $PSBoundParameters.Remove('ManagedIdentityResourceId')
                }

                if ($PSBoundParameters.ContainsKey('DatabaseRouting')) {
                    $Parameter.DatabaseRouting = $PSBoundParameters['DatabaseRouting']
                    $null = $PSBoundParameters.Remove('DatabaseRouting')
                }

                if ($PSBoundParameters.ContainsKey('RetrievalStartDate')) {
                    $Parameter.RetrievalStartDate = $PSBoundParameters['RetrievalStartDate']
                    $null = $PSBoundParameters.Remove('RetrievalStartDate')
                }
            }
            elseif ($PSBoundParameters['Kind'] -eq 'EventGrid') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.EventGridDataConnection]::new()
            
                $Parameter.EventHubResourceId = $PSBoundParameters['EventHubResourceId']
                $null = $PSBoundParameters.Remove('EventHubResourceId')

                $Parameter.StorageAccountResourceId = $PSBoundParameters['StorageAccountResourceId']
                $null = $PSBoundParameters.Remove('StorageAccountResourceId')

                if ($PSBoundParameters.ContainsKey('DataFormat')) {
                    $Parameter.DataFormat = $PSBoundParameters['DataFormat']
                    $null = $PSBoundParameters.Remove('DataFormat')
                }

                if ($PSBoundParameters.ContainsKey('ConsumerGroup')) {
                    $Parameter.ConsumerGroup = $PSBoundParameters['ConsumerGroup']
                    $null = $PSBoundParameters.Remove('ConsumerGroup')
                }
                
                if ($PSBoundParameters.ContainsKey('BlobStorageEventType')) {
                    $Parameter.BlobStorageEventType = $PSBoundParameters['BlobStorageEventType']
                    $null = $PSBoundParameters.Remove('BlobStorageEventType')
                }

                if ($PSBoundParameters.ContainsKey('IgnoreFirstRecord')) {
                    $Parameter.IgnoreFirstRecord = $PSBoundParameters['IgnoreFirstRecord']
                    $null = $PSBoundParameters.Remove('IgnoreFirstRecord')
                }

                if ($PSBoundParameters.ContainsKey('EventGridResourceId')) {
                    $Parameter.EventGridResourceId = $PSBoundParameters['EventGridResourceId']
                    $null = $PSBoundParameters.Remove('EventGridResourceId')
                }

                if ($PSBoundParameters.ContainsKey('ManagedIdentityResourceId')) {
                    $Parameter.ManagedIdentityResourceId = $PSBoundParameters['ManagedIdentityResourceId']
                    $null = $PSBoundParameters.Remove('ManagedIdentityResourceId')
                }

                if ($PSBoundParameters.ContainsKey('DatabaseRouting')) {
                    $Parameter.DatabaseRouting = $PSBoundParameters['DatabaseRouting']
                    $null = $PSBoundParameters.Remove('DatabaseRouting')
                }
            }
            elseif ($PSBoundParameters['Kind'] -eq 'IotHub') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IotHubDataConnection]::new()

                $Parameter.IotHubResourceId = $PSBoundParameters['IotHubResourceId']
                $null = $PSBoundParameters.Remove('IotHubResourceId')

                $Parameter.SharedAccessPolicyName = $PSBoundParameters['SharedAccessPolicyName']
                $null = $PSBoundParameters.Remove('SharedAccessPolicyName')

                if ($PSBoundParameters.ContainsKey('DataFormat')) {
                    $Parameter.DataFormat = $PSBoundParameters['DataFormat']
                    $null = $PSBoundParameters.Remove('DataFormat')
                }

                if ($PSBoundParameters.ContainsKey('ConsumerGroup')) {
                    $Parameter.ConsumerGroup = $PSBoundParameters['ConsumerGroup']
                    $null = $PSBoundParameters.Remove('ConsumerGroup')
                }
                
                if ($PSBoundParameters.ContainsKey('EventSystemProperty')) {
                    $Parameter.EventSystemProperty = $PSBoundParameters['EventSystemProperty']
                    $null = $PSBoundParameters.Remove('EventSystemProperty')
                }

                if ($PSBoundParameters.ContainsKey('DatabaseRouting')) {
                    $Parameter.DatabaseRouting = $PSBoundParameters['DatabaseRouting']
                    $null = $PSBoundParameters.Remove('DatabaseRouting')
                }

                if ($PSBoundParameters.ContainsKey('RetrievalStartDate')) {
                    $Parameter.RetrievalStartDate = $PSBoundParameters['RetrievalStartDate']
                    $null = $PSBoundParameters.Remove('RetrievalStartDate')
                }
            }
            elseif ($PSBoundParameters['Kind'] -eq 'CosmosDb') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.CosmosDbDataConnection]::new()

                $Parameter.TableName = $PSBoundParameters['TableName']
                $null = $PSBoundParameters.Remove('TableName')

                $Parameter.ManagedIdentityResourceId = $PSBoundParameters['ManagedIdentityResourceId']
                $null = $PSBoundParameters.Remove('ManagedIdentityResourceId')

                $Parameter.CosmosDbAccountResourceId = $PSBoundParameters['CosmosDbAccountResourceId']
                $null = $PSBoundParameters.Remove('CosmosDbAccountResourceId')

                $Parameter.CosmosDbDatabase = $PSBoundParameters['CosmosDbDatabase']
                $null = $PSBoundParameters.Remove('CosmosDbDatabase')

                $Parameter.CosmosDbContainer = $PSBoundParameters['CosmosDbContainer']
                $null = $PSBoundParameters.Remove('CosmosDbContainer')

                if ($PSBoundParameters.ContainsKey('RetrievalStartDate')) {
                    $Parameter.RetrievalStartDate = $PSBoundParameters['RetrievalStartDate']
                    $null = $PSBoundParameters.Remove('RetrievalStartDate')
                }
            }

            $Parameter.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            $Parameter.Location = $PSBoundParameters['Location']
            $null = $PSBoundParameters.Remove('Location')
            
            if ($PSBoundParameters.ContainsKey('MappingRuleName')) {
                $Parameter.MappingRuleName = $PSBoundParameters['MappingRuleName']
                $null = $PSBoundParameters.Remove('MappingRuleName')
            }

            if ($PSBoundParameters.ContainsKey('TableName')) {
                $Parameter.TableName = $PSBoundParameters['TableName']
                $null = $PSBoundParameters.Remove('TableName')
            }            

            $null = $PSBoundParameters.Add('Parameter', $Parameter)

            Az.Kusto.internal\Update-AzKustoDataConnection @PSBoundParameters
        }
        catch {
            throw
        }
    }
}
