
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
Retrieves the details of the replicating server status.
.Description
The Get-AzMigrateServerMigrationStatus cmdlet retrieves the replication status for the replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/get-azmigrateservermigrationstatus
#>
function Get-AzMigrateServerMigrationStatus {
    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'ListByName', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'ListByName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByApplianceName', Mandatory)]
        #[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Resource Group of the Azure Migrate Project in the current subscription.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'ListByName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetByApplianceName', Mandatory)]
        #[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Azure Migrate project  in the current subscription.
        ${ProjectName},

        [Parameter(ParameterSetName = 'GetByMachineName', Mandatory)]
        [Parameter(ParameterSetName = 'GetHealthByMachineName', Mandatory)]
        #[Parameter(ParameterSetName = 'GetByPrioritiseServer', Mandatory)]
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
            if (!$appMap.ContainsKey($site)) {
                return "No appliance found for site name: $site"
            }
            return $appMap[$site]
        }

        Function GetState {
            param(
                [string]$State,
                [object]$ReplicationMigrationItem
            )

            if ([string]::IsNullOrEmpty($State)) {
                if ($ReplicationMigrationItem.MigrationState -match "InitialSeedingInProgress" -or $ReplicationMigrationItem.MigrationState -match "EnableMigrationInProgress" -or $ReplicationMigrationItem.MigrationState -match "Replicating") {
                    return "InitialReplication Queued"
                }
                elseif ($ReplicationMigrationItem.MigrationState -match "InitialSeedingFailed") {
                    return "InitialReplication Failed"
                }
                return $ReplicationMigrationItem.MigrationState
            }

            if ($ReplicationMigrationItem.MigrationState -match "MigrationInProgress" -and $ReplicationMigrationItem.migrationProgressPercentage -eq $null) {
                return "FinalDeltaReplication Queued"
            }

            if ($ReplicationMigrationItem.MigrationState -eq "MigrationSucceeded") {
                return "Migration Completed"
            }

            $State = $State -replace "PlannedFailoverOverDeltaReplication", "FinalDeltaReplication"
            return $State
        }

        function Convert-MillisecondsToTime {
            param (
                [int]$Milliseconds
            )

            if ($Milliseconds -eq $null) {
                return $null
            }

            $TotalMinutes = [math]::Floor($Milliseconds / 60000)
            $Hours = [math]::Floor($TotalMinutes / 60)
            $Minutes = $TotalMinutes % 60

            if ($Hours -eq 0) {
                if ($Minutes -eq 0)
                {
                    return "-"
                }
                return "$Minutes min"
            } else {
                return "$Hours hr $Minutes min"
            }
        }

        function Convert-ToMbps {
            param (
                [double]$UploadSpeedInBytesPerSecond
            )

            if ($UploadSpeedInBytesPerSecond -eq $null -or $UploadSpeedInBytesPerSecond -eq 0) {
                return "-"
            }

            # Conversion factor: 1 byte = 8 bits
            $UploadSpeedInBitsPerSecond = $UploadSpeedInBytesPerSecond * 8

            # Conversion factor: 1 megabit = 1,000,000 bits
            $UploadSpeedInMbps = [math]::Round($UploadSpeedInBitsPerSecond / 1e6)

            return "$UploadSpeedInMbps Mbps"
        }

        function Add-Percent {
            param (
                [double]$Value
            )

            if ($Value -ne $null -and $Value -ne 0) {
                return "$Value%"
            } else {
                return "-"
            }
        }

        function ConvertToCustomTimeFormat {
            param (
                [string]$LocalTimeString
            )
            
            if ([string]::IsNullOrEmpty($LocalTimeString)) {
                return "-"
            }

            # Parse the input string
            $localTime = [datetime]::ParseExact($LocalTimeString, "MM/dd/yyyy HH:mm:ss", $null)

            # Format the local time as desired
            $formattedTime = Get-Date $localTime -Format "M/d/yyyy, h:mm:ss tt"

            return $formattedTime
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
        $null = $PSBoundParameters.Remove('Health')
        #$null = $PSBoundParameters.Remove('Expedite')

        $output = New-Object System.Collections.ArrayList  # Create a hashtable to store the output.

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

        if ($parameterSet -eq "GetByApplianceName" -and !$appMap.ContainsValue($ApplianceName))
        {
            throw "No appliance found with name $ApplianceName"
        }

        if ($parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer") {
            $ReplicationMigrationItems = Get-AzMigrateServerReplication -ProjectName $ProjectName -ResourceGroupName $ResourceGroupName -MachineName $MachineName
        }
        else {
            $ReplicationMigrationItems = Get-AzMigrateServerReplication -ProjectName $ProjectName -ResourceGroupName $ResourceGroupName
        }

        if ($ReplicationMigrationItems -eq $null) {
            if ($parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName") {
                Write-Host "No replicating machine found with name $MachineName."
            }
            else {
                Write-Host "No replicating machine found."
            }
            return;
        }

        $vmMigrationStatusTable = New-Object System.Data.DataTable("")

        if ($parameterSet -eq "GetByApplianceName") {
            $column = @("Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "Health", "LastSync", "Datastore")
        }
        elseif ($parameterSet -eq "ListByName") {
            $column = @("Appliance", "Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "Health", "LastSync", "Datastore")
        }
        else {
            $column = @("Appliance", "Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "LastSync", "Datastore")
        }

        MakeTable $vmMigrationStatusTable $column

        foreach ($ReplicationMigrationItem in $ReplicationMigrationItems) {
            if ($parameterSet -eq "GetByMachineName") {
                if ($ReplicationMigrationItem.health -eq "Normal") {
                    $op = $output.Add("`nServer $MachineName is currently healthy.")
                }
                elseif ($ReplicationMigrationItem.health -eq "None") {
                    $op = $output.Add("`nServer $MachineName is in $($ReplicationMigrationItems.ReplicationStatus) state.")
                }
                else {
                    $op = $output.Add("`nServer $MachineName is currently facing critical error/ warning. Please run the command given below to know about the errors and resolutions.`n`nGet-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -Appliance <String> -MachineName <String> -Health")
                }
            }

            if ($parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer") {
                $ReplicationMigrationItem = Get-AzMigrateServerReplication -TargetObjectID $ReplicationMigrationItem.Id
            }

            $site = $ReplicationMigrationItem.ProviderSpecificDetail.vmwareMachineId.Split('/')[-3]
            $appName = GetApplianceName $site
            $row1 = $vmMigrationStatusTable.NewRow()
            if ($parameterSet -eq "GetByApplianceName" -and $appName -ne $ApplianceName) {
                continue;
            }
            if ($parameterSet -ne "GetByApplianceName") {
                $row1["Appliance"] = $appName
            }

            $row1["Server"] = $ReplicationMigrationItem.MachineName
            $row1["State"] = GetState -State $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailState -ReplicationMigrationItem $ReplicationMigrationItem
            if ($ReplicationMigrationItem.ReplicationStatus -match "Pause" -and $ReplicationMigrationItem.MigrationState -notmatch "migration") {
                $row1["State"] = $ReplicationMigrationItem.ReplicationStatus
                $row1["TimeRemaining"] = "-"
                $row1["UploadSpeed"] = "-"
                $row1["Progress"] = "-"
                $row1["TimeElapsed"] = "-"
            }
            elseif ($ReplicationMigrationItem.ReplicationStatus -match "Resum") {
                $row1["State"] = $ReplicationMigrationItem.ReplicationStatus
                $row1["TimeRemaining"] = Convert-MillisecondsToTime -Milliseconds $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeRemaining
                $row1["UploadSpeed"] = Convert-ToMbps -UploadSpeedInBytesPerSecond $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailUploadSpeed
                $row1["Progress"] = Add-Percent -Value $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailProgressPercentage
                $row1["TimeElapsed"] = Convert-MillisecondsToTime -Milliseconds $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeElapsed
            }
            elseif ($ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailState -match "Completed") {
                $row1["TimeRemaining"] = "-"
                $row1["UploadSpeed"] = "-"
                $row1["Progress"] = "-"
                $row1["TimeElapsed"] = "-"
            }
            else {
                $row1["TimeRemaining"] = Convert-MillisecondsToTime -Milliseconds $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeRemaining
                $row1["UploadSpeed"] = Convert-ToMbps -UploadSpeedInBytesPerSecond $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailUploadSpeed
                $row1["Progress"] = Add-Percent -Value $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailProgressPercentage
                $row1["TimeElapsed"] = Convert-MillisecondsToTime -Milliseconds $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeElapsed
            }

            if ($parameterSet -eq "ListByName" -or $parameterSet -eq "GetByApplianceName") {
                if ([string]::IsNullOrEmpty($ReplicationMigrationItem.health) -or $ReplicationMigrationItem.health -eq "None") {
                    $row1["Health"] = "-"
                }
                else {
                    $row1["Health"] = $ReplicationMigrationItem.health
                }
            }
            $row1["LastSync"] = ConvertToCustomTimeFormat -LocalTimeString $ReplicationMigrationItem.ProviderSpecificDetail.lastRecoveryPointReceived

            #$row1["ESXiHost"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
            if (-not [string]::IsNullOrEmpty($ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore)) {
                $row1["Datastore"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore -join ', '
            }
            else {
                $row1["Datastore"] = "-"
            }

            $vmMigrationStatusTable.Rows.Add($row1)

            if( $parameterSet -eq "GetByMachineName" -or $parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer") {
                if ($parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer") {
                    $op = $output.Add("`nServer Information:")
                }

                $vmMigrationStatusTable = $vmMigrationStatusTable | Format-Table -AutoSize | Out-String
                $op = $output.Add($vmMigrationStatusTable)  # Store the table in the output hashtable

                $diskStatusTable = New-Object System.Data.DataTable("")
                $diskcolumn = @("Disk", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "Datastore")

                MakeTable $diskStatusTable $diskcolumn

                foreach($disk in $ReplicationMigrationItem.ProviderSpecificDetail.ProtectedDisk) {
                    $row = $diskStatusTable.NewRow()
                    $row["Disk"] = $disk.DiskName
                    $row["State"] = GetState -State $disk.GatewayOperationDetailState -ReplicationMigrationItem $ReplicationMigrationItem

                    if ($ReplicationMigrationItem.ReplicationStatus -match "Pause" -and $ReplicationMigrationItem.MigrationState -notmatch "migration") {
                        $row["State"] = $ReplicationMigrationItem.ReplicationStatus
                        $row["TimeRemaining"] = "-"
                        $row["UploadSpeed"] = "-"
                        $row["Progress"] = "-"
                        $row["TimeElapsed"] = "-"
                    }
                    elseif ($ReplicationMigrationItem.ReplicationStatus -match "Resum") {
                        $row["State"] = $ReplicationMigrationItem.ReplicationStatus
                        #$row["TimeRemaining"] = Convert-MillisecondsToTime -Milliseconds $disk.GatewayOperationDetailTimeRemaining
                        $row["TimeRemaining"] = "-"
                        $row["UploadSpeed"] = "-"
                        #$row["UploadSpeed"] = Convert-ToMbps -UploadSpeedInBytesPerSecond $disk.GatewayOperationDetailUploadSpeed
                        #$row["Progress"] = Add-Percent -Value $disk.GatewayOperationDetailProgressPercentage
                        $row["Progress"] = "-"
                        $row["TimeElapsed"] = "-"
                        #$row["TimeElapsed"] = Convert-MillisecondsToTime -Milliseconds $disk.GatewayOperationDetailTimeElapsed
                    }
                    elseif ($disk.GatewayOperationDetailState -match "Completed") {
                        $row["Progress"] = "-"
                        $row["TimeElapsed"] = "-"
                        $row["TimeRemaining"] = "-"
                        $row["UploadSpeed"] = "-"
                    }
                    else {
                        $row["TimeRemaining"] = Convert-MillisecondsToTime -Milliseconds $disk.GatewayOperationDetailTimeRemaining
                        $row["UploadSpeed"] = Convert-ToMbps -UploadSpeedInBytesPerSecond $disk.GatewayOperationDetailUploadSpeed
                        $row["Progress"] = Add-Percent -Value $disk.GatewayOperationDetailProgressPercentage
                        $row["TimeElapsed"] = Convert-MillisecondsToTime -Milliseconds $disk.GatewayOperationDetailTimeElapsed
                    }

                    if (-not [string]::IsNullOrEmpty($disk.GatewayOperationDetailDataStore)) {
                        $row["Datastore"] = $disk.GatewayOperationDetailDataStore -join ', '
                    }
                    else {
                        $row["Datastore"] = "-"
                    }
                    $diskStatusTable.Rows.Add($row)
                }

                if ($parameterSet -eq "GetHealthByMachineName" -or $parameterSet -eq "GetByPrioritiseServer") {
                    $op = $output.Add("`nDisk Level Operation Status:")
                }

                $diskStatusTable = $diskStatusTable | Format-Table -AutoSize | Out-String
                $op = $output.Add($diskStatusTable)  # Store the table in the output hashtable
            }

            if ($parameterSet -eq "GetHealthByMachineName") {
                if ($ReplicationMigrationItem.health -eq "Normal") {
                    $op = $output.Add("No warnings or critical errors for this server.")
                }
                else {
                    $op = $output.Add("List of warning or critical errors for this server with their resolutions: `n")
                    $healthError = $ReplicationMigrationItem.HealthError
                    foreach ($error in $healthError) {
                        $op = $output.Add("Error Message: $($error.ErrorMessage)`nPossible Causes: $($error.PossibleCaus)`nRecommended Actions: $($error.RecommendedAction)`n`n")
                    }
                }
            }

            <#if( $parameterSet -eq "GetByPrioritiseServer") {
                $vmMigrationTable = New-Object System.Data.DataTable("")
                $column = @("Appliance", "Server", "State", "TimeRemaining", "ESXiHost", "Datastore")
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
                    $row1["ESXiHost"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
                    $row1["Datastore"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore
                    $vmMigrationTable.Rows.Add($row1)
                }
                $op = $output.Add("Resource Sharing: `n`nVM $($ReplicationMigrationItem.MachineName) shares at least one resource with the following VM. These include ESXi host, Datastore or primary appliance.")
                $vmMigrationTable = $vmMigrationTable | Format-Table -AutoSize | Out-String
                $op = $output.Add($vmMigrationTable)

                $resourceUtilizationTable = New-Object System.Data.DataTable("")
                $column = @("Resource", "Capacity", "Utilization for server migrations", "Total utilization", "Status")
                MakeTable $resourceUtilizationTable $column
                $row1 = $resourceUtilizationTable.NewRow()
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
                $row6["Resource"] = "Datastore Snapshot Count (for each datastore corresponding to the server s disks)"
                $row6["Capacity"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotCapacity
                $row6["Utilization for server migrations"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotProcessUtilization
                $row6["Total utilization"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotTotalUtilization
                $row6["Status"] = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DatastoreSnapshotStatus
                $resourceUtilizationTable.Rows.Add($row6)

                $op = $output.Add("Resource utilization information for migration operations:")
                $resourceUtilizationTable = $resourceUtilizationTable | Format-Table -AutoSize | Out-String
                $op = $output.Add($resourceUtilizationTable)
                
                # <To-do> Add Recommendation actions logic for expedite.

                Write-Host "Based on the resource utilization seen above following are suggestion you can take to expedite server $($ReplicationMigrationItem.MachineName) migration :" -ForegroundColor White
                Write-Host "1. Pause replication for servers S2, S3, in delta sync who are migrating under appliance A1."
                Write-Host "2. Stop replication for servers S4 in Initial replication migrating under appliance A1."
                Write-Host "3. Increase the Network bandwidth available for appliances so that upload speeds can increase."
                Write-Host "4. Increase the NFC buffer size to increase the upload speed."
                Write-Host "5. Perform storage Vmotion on server $($ReplicationMigrationItem.MachineName)."
            }#>
        }

        if ($parameterSet -eq "GetByApplianceName" -or $parameterSet -eq "ListByName") {
            $vmMigrationStatusTable = $vmMigrationStatusTable | Format-Table -AutoSize | Out-String
            $op = $output.Add($vmMigrationStatusTable)

            $diskStatusTable = $diskStatusTable | Format-Table -AutoSize | Out-String
            $op = $output.Add($diskStatusTable)
#            $op = $output.Add("To check expedite the operation of a server use the command")
#            $op = $output.Add("Get-AzMigrateServerMigrationStatus  -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Expedite`n")
            $op = $output.Add("To resolve the health issue use the command")
            $op = $output.Add("Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health`n")
        }

        return $output;
    }
}