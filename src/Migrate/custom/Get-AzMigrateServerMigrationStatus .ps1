
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
Retrieves the details of the replicating server.
.Description
The Get-AzMigrateServerReplicationStatus cmdlet retrieves the replication status for the replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/get-azmigrateserverreplication
#>
function Get-AzMigrateServerReplicationStatus {
    [CmdletBinding(DefaultParameterSetName = 'ListByName', PositionalBinding = $false)]
    param(

        [Parameter(ParameterSetName = 'GetBySRSID', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replicating server.
        ${TargetObjectID},

        [Parameter(ParameterSetName = 'ListByName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByApplianceName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'ListByName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByApplianceName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Azure Migrate project  in the current subscription.
        ${ProjectName},

        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the display name of the replicating machine.
        ${MachineName},

        [Parameter(ParameterSetName = 'GetByApplianceName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the appliance.
        ${ApplianceName},

        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Specifies whether the health issues to show for replicating server.
        ${Health},

        [Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
        [Parameter(ParameterSetName = 'GetBySRSID', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Specifies list of steps customers can take to prioritize the migration operation of the given server.
        ${Expedite},

        [Parameter(ParameterSetName = 'ListByName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Query')]
        [System.String]
        # OData filter options.
        ${Filter},
    
        [Parameter(ParameterSetName = 'ListByName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Query')]
        [System.String]
        # The pagination token.
        ${SkipToken},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Azure Subscription ID.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        Function MakeTable ($TableName, $ColumnArray) {
            foreach($Col in $ColumnArray) {
                $MCol = New-Object System.Data.DataColumn $Col;
                $TableName.Columns.Add($MCol)
            }
        }

        $appMap = @{}

        Function PopulateApplianceDetails ($projName, $rgName) {
            # Get vault name from SMS solution.
            $smsSolution = Get-AzMigrateSolution -MigrateProjectName $projName -ResourceGroupName $rgName -Name "Servers-Migration-ServerMigration"

            if (-not $smsSolution.DetailExtendedDetail.AdditionalProperties.vaultId) {
                throw 'Azure Migrate appliance not configured. Setup Azure Migrate appliance before proceeding.'
            }

            $VaultName = $smsSolution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]

            # Get all appliances and sites in the project from SDS solution.
            $sdsSolution = Get-AzMigrateSolution -MigrateProjectName $projName -ResourceGroupName $rgName -Name "Servers-Discovery-ServerDiscovery"

            if ($null -ne $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"]) {
                $appMapV2 = $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV2"] | ConvertFrom-Json
                # Fetch all appliances from V2 map first. Then these can be updated if found again in V3 map.
                foreach ($item in $appMapV2) {
                    $appMap[$item.SiteId.Split('/')[-1]] = $item.ApplianceName
                }
            }

            if ($null -ne $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"]) {
                $appMapV3 = $sdsSolution.DetailExtendedDetail["applianceNameToSiteIdMapV3"] | ConvertFrom-Json
                foreach ($item in $appMapV3) {
                    $t = $item.psobject.properties
                    $appMap[$t.Value.SiteId.Split('/')[-1]] = $t.Name
                }
            }
        }

        Function GetApplianceName ($site) {
            foreach ($SiteName in $appMap.Keys) {
                $apName = $appMap[$SiteName]
                if ($site -eq $SiteName) {
                    return $apName
                }
            }
            return "No appliance found for SiteId: $SiteId"
        }

        $parameterSet = $PSCmdlet.ParameterSetName
        $null = $PSBoundParameters.Remove('ResourceGroupName')
        $null = $PSBoundParameters.Remove('ProjectName')
        $HasFilter = $PSBoundParameters.ContainsKey('Filter')
        $HasSkipToken = $PSBoundParameters.ContainsKey('SkipToken')
        $null = $PSBoundParameters.Remove('Filter')
        $null = $PSBoundParameters.Remove('SkipToken')
        $null = $PSBoundParameters.Remove('MachineName')
        $null = $PSBoundParameters.Remove('ApplianceName')
        $null = $PSBoundParameters.Remove('TargetObjectID')
        $null = $PSBoundParameters.Remove('Health')
        $null = $PSBoundParameters.Remove('Expedite')

        $output = New-Object System.Collections.ArrayList  # Create a hashtable to store the output.

        if ($parameterSet -eq "GetBySRSID") {
            $ReplicationMigrationItem = Get-AzMigrateServerReplication -TargetObjectID $TargetObjectID

            if ($ReplicationMigrationItem  -eq $null) {
                Write-Host "No replicating machine found with ID $TargetObjectID" -ForegroundColor Red
                return;
            }

            $fabricName = $TargetObjectID.Split("/")[10]
            $ResourceGroupName = $TargetObjectID.Split("/")[4]
            $VaultName = $TargetObjectID.Split("/")[8]

            $fabric = Get-AzMigrateReplicationFabric -ResourceGroupName $ResourceGroupName -ResourceName $VaultName -FabricName $fabricName 
            $ProjectName = $fabric.Property.CustomDetail.MigrationSolutionId.Split("/")[8]
        }

        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("Name", "Servers-Migration-ServerMigration")
        $null = $PSBoundParameters.Add("MigrateProjectName", $ProjectName)

        $solution = Az.Migrate\Get-AzMigrateSolution @PSBoundParameters
        if ($solution -and ($solution.Count -ge 1)) {
            $VaultName = $solution.DetailExtendedDetail.AdditionalProperties.vaultId.Split("/")[8]
        }
        else {
            throw "Solution not found."
        }


        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("MigrateProjectName")
        $null = $PSBoundParameters.Add('ResourceName', $VaultName)

        if ($HasFilter) {
            $null = $PSBoundParameters.Add("Filter", $Filter)
        }
        if ($HasSkipToken) {
            $null = $PSBoundParameters.Add("SkipToken", $SkipToken)
        }

        PopulateApplianceDetails $ProjectName $ResourceGroupName

        if ($parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer") {
            $ReplicationMigrationItems = Get-AzMigrateServerReplication -ProjectName $ProjectName -ResourceGroupName $ResourceGroupName -MachineName $MachineName
        }
        elseif ($parameterSet -eq "GetBySRSID") {
            $ReplicationMigrationItems = Get-AzMigrateServerReplication -TargetObjectID $TargetObjectID
        }
        else {
            $ReplicationMigrationItems = Get-AzMigrateServerReplication -ProjectName $ProjectName -ResourceGroupName $ResourceGroupName
        }

        if ($ReplicationMigrationItems -eq $null) {
            Write-Host "No replicating machine found with name $MachineName" -ForegroundColor Red
            return;
        }

        $vmMigrationStatusTable = New-Object System.Data.DataTable("")
        $column = @("Appliance", "Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "Upload Speed", "ESXi Host", "Datastore")
        MakeTable $vmMigrationStatusTable $column

        foreach ($ReplicationMigrationItem in $ReplicationMigrationItems) {
            if ($parameterSet -eq "GetByMachineName") {
                if ($ReplicationMigrationItem.health -eq "Normal") {
                    Write-Host "Server $MachineName is currently healthy." -ForegroundColor Green
                }
                elseif ($ReplicationMigrationItem.health -eq "None") {
                    Write-Host "Server $MachineName is in $($ReplicationMigrationItems.ReplicationStatus) state." -ForegroundColor Green
                }
                else {
                    Write-Host "Server $MachineName is currently facing critical error/ warning. Please run the command given below to know about the errors and resolutions." -ForegroundColor Red
                    Write-Host "`e[3mGet-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -Appliance <String> -MachineName <String> -Health`e[0m" -ForegroundColor Gray
                }
            }

            if ($parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer" -or $parameterSet -eq "GetBySRSID") {
                $ReplicationMigrationItem = Get-AzMigrateServerReplication -TargetObjectID $ReplicationMigrationItem.Id
            }

            $site = $ReplicationMigrationItem.ProviderSpecificDetail.vmwareMachineId.Split('/')[-3]
            $appName = GetApplianceName $site
            if ($parameterSet -eq "GetByApplianceName" -and !$appMap.ContainsValue($ApplianceName))
            {
                throw "No appliance found with name $ApplianceName"
            }

            if ($parameterSet -eq "GetByApplianceName" -and $appName -ne $ApplianceName) {
                continue;
            }

            $row1 = $vmMigrationStatusTable.NewRow()
            $row1["Appliance"] = $appName
            $row1["Server"] = $ReplicationMigrationItem.MachineName
            $row1["State"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailState
            $row1["Progress"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailProgressPercentage
            $row1["TimeElapsed"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeElapsed
            $row1["TimeRemaining"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeRemaining
            $row1["Upload Speed"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailUploadSpeed
            $row1["ESXi Host"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
            $row1["Datastore"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore
            $vmMigrationStatusTable.Rows.Add($row1)

            if( $parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer" -or $parameterSet -eq "GetBySRSID") {
                if ($parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer" -or $parameterSet -eq "GetBySRSID") {
                    Write-Host "Server Information:" -ForegroundColor White
                }

                # $vmMigrationStatusTable = $vmMigrationStatusTable | Format-Table -AutoSize | Out-String
                $vmMigrationStatusTable | Format-Table -AutoSize

                $diskStatusTable = New-Object System.Data.DataTable("")
                $diskcolumn = @("Disk", "State", "Progress", "TimeElapsed", "TimeRemaining", "Upload Speed", "Datastore")

                MakeTable $diskStatusTable $diskcolumn

                foreach($disk in $ReplicationMigrationItem.ProviderSpecificDetail.ProtectedDisk) {
                    $row = $diskStatusTable.NewRow()
                    $row["Disk"] = $disk.DiskName
                    $row["State"] = $disk.GatewayOperationDetailState
                    $row["Progress"] = $disk.GatewayOperationDetailProgressPercentage
                    $row["TimeElapsed"] = $disk.GatewayOperationDetailTimeElapsed
                    $row["TimeRemaining"] = $disk.GatewayOperationDetailTimeRemaining
                    $row["Upload Speed"] = $disk.GatewayOperationDetailUploadSpeed
                    $row["Datastore"] = $disk.GatewayOperationDetailDataStore
                    $diskStatusTable.Rows.Add($row)
                }

                if ($parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer" -or $parameterSet -eq "GetBySRSID") {
                    Write-Host "Disk Level Operation Status:" -ForegroundColor White
                }

                $diskStatusTable = $diskStatusTable | Format-Table -AutoSize | Out-String
                Write-Host $diskStatusTable
            }

            if ($parameterSet -eq "GetHealthByMachineName") {
                Write-Host "List of warning or critical errors for this server with their resolutions:" -ForegroundColor White
                $healthError = $ReplicationMigrationItem.HealthError
                foreach ($error in $healthError) {
                    Write-Host "  Error Message: $($error.ErrorMessage)" 
                    Write-Host "  Possible Causes: $($error.PossibleCaus)"
                    Write-Host "  Recommended Actions: $($error.RecommendedAction)`n"
                }
            }

            if( $parameterSet -eq "GetByPrioritiseServer" -or $parameterSet -eq "GetBySRSID") {
                $vmMigrationTable = New-Object System.Data.DataTable("")
                $column = @("Appliance", "Server", "State", "TimeRemaining", "ESXi Host", "Datastore")
                MakeTable $vmMigrationTable $column

                foreach($MigrationItem in $ReplicationMigrationItems) {
                    $site = $MigrationItem.ProviderSpecificDetail.vmwareMachineId.Split('/')[-3]
                    $appName1 = GetApplianceName $site
                    if ($MigrationItem.MachineName -eq $ReplicationMigrationItem.MachineName -and $appName1 -eq $appName) {
                        continue;
                    }

                    if ($appName1 -ne $appName) {
                        continue;
                    }

                    $row1 = $vmMigrationTable.NewRow()
                    $row1["Appliance"] = $appName1
                    $row1["Server"] = $MigrationItem.MachineName
                    $row1["State"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailState
                    $row1["TimeRemaining"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeRemaining
                    $row1["ESXi Host"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
                    $row1["Datastore"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore
                    $vmMigrationTable.Rows.Add($row1)
                }
                Write-Host "Resource Sharing: `n`n VM $($ReplicationMigrationItem.MachineName) shares at least one resource with the following VM. These include ESXi host, Datastore or primary appliance." -ForegroundColor White
                $vmMigrationTable = $vmMigrationTable | Format-Table -AutoSize | Out-String
                Write-Host $vmMigrationTable

                $resourceUtilizationTable = New-Object System.Data.DataTable("")
                $column = @("Resource", "Capacity", "Utilization for server migrations", "Total utilization", "Status")
                MakeTable $resourceUtilizationTable $column
                $row1 = $resourceUtilizationTable.NewRow()
                #$row1["Resource"] = "Appliance RAM Sum : Primary and scale out appliances"
                $row1["Resource"] = "Appliance RAM Sum : Primary and scale out appliances"
                $row1["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailCapacity
                $row1["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailProcessUtilization
                $row1["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailTotalUtilization
                $row1["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailStatus
                $resourceUtilizationTable.Rows.Add($row1)

                $row2 = $resourceUtilizationTable.NewRow()
                $row2["Resource"] = "Appliance CPU Sum : Primary and scale out appliances"
                $row2["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailCapacity
                $row2["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailProcessUtilization
                $row2["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailTotalUtilization
                $row2["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailStatus
                $resourceUtilizationTable.Rows.Add($row2)

                $row3 = $resourceUtilizationTable.NewRow()
                $row3["Resource"] = "Network bandwidth Sum : Primary and scale out appliances"
                $row3["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthCapacity
                $row3["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthProcessUtilization
                $row3["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthTotalUtilization
                $row3["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthStatus
                $resourceUtilizationTable.Rows.Add($row3)

                $row4 = $resourceUtilizationTable.NewRow()
                $row4["Resource"] = "ESXi host NFC buffer"
                $row4["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.EsxiNfcBufferCapacity
                $row4["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.EsxiNfcBufferProcessUtilization
                $row4["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.EsxiNfcBufferTotalUtilization
                $row4["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.EsxiNfcBufferStatus
                $resourceUtilizationTable.Rows.Add($row4)

                $row5 = $resourceUtilizationTable.NewRow()
                $row5["Resource"] = "Parallel Disks Replicated Sum : Primary and scale out appliances"
                $row5["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DiskReplicationDetailCapacity
                $row5["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DiskReplicationDetailProcessUtilization
                $row5["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DiskReplicationDetailTotalUtilization
                $row5["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DiskReplicationDetailStatus
                $resourceUtilizationTable.Rows.Add($row5)

                $row6 = $resourceUtilizationTable.NewRow()
                $row6["Resource"] = "Datastore Snapshot Count (for each datastore corresponding to the server’s disks)"
                $row6["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotCapacity
                $row6["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotProcessUtilization
                $row6["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotTotalUtilization
                $row6["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotStatus
                $resourceUtilizationTable.Rows.Add($row6)

                Write-Host "Resource utilization information for migration operations:" -ForegroundColor White
                $resourceUtilizationTable | Format-Table -AutoSize

                Write-Host "Based on the resource utilization seen above following are suggestion you can take to expedite server $($ReplicationMigrationItem.MachineName) migration :" -ForegroundColor White
                Write-Host "1. Pause replication for servers S2, S3, in delta sync who are migrating under appliance A1."
                Write-Host "2. Stop replication for servers S4 in Initial replication migrating under appliance A1."
                Write-Host "3. Increase the Network bandwidth available for appliances so that upload speeds can increase."
                Write-Host "4. Increase the NFC buffer size to increase the upload speed."
                Write-Host "5. Perform storage Vmotion on server $($ReplicationMigrationItem.MachineName)."
            }
        }

        if ($parameterSet -eq "GetByApplianceName" -or $parameterSet -eq "ListByName") {
            $vmMigrationStatusTable = $vmMigrationStatusTable | Format-Table -AutoSize | Out-String
            Write-Host $vmMigrationStatusTable

            $diskStatusTable = $diskStatusTable | Format-Table -AutoSize | Out-String
            Write-Host $diskStatusTable
            Write-Host "To check expedite the operation of a server use the command" -Foregroundcolor White
            Write-Host "  `e[3mGet-AzMigrateServerMigrationStatus  -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Expedite`e[0m `n"
            Write-Host "To resolve the health issue use the command" -Foregroundcolor White
            Write-Host "  `e[3mGet-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health`e[0m `n"
        }
        
    return $true;
    }
}