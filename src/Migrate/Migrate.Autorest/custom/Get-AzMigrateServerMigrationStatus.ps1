
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
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Specifies whether to expedite the operation of a replicating server.
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
            if ($ReplicationMigrationItem.MigrationState -eq "MigrationFailed") {
                return "Migration Failed"
            }
            elseif ($ReplicationMigrationItem.MigrationState -match "InitialSeedingFailed") {
                return "InitialReplication Failed"
            }

            if ([string]::IsNullOrEmpty($State)) {
                return $ReplicationMigrationItem.MigrationState
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

            if ($null -ne $Value) {
                return "$Value %"
            } else {
                return "-"
            }
        }

        function Add-MBps {
            param (
                [double]$Value
            )
            if ($null -ne $Value) {
                return "$Value MBps"
            } else {
                return "-"
            }
        }

        function Add-MB {
            param (
                [double]$Value
            )
            if ($null -ne $Value) {
                return "$Value MB"
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

        # Helper function to determine status
        function Get-ResourceStatus {
            param (
                [double]$Capacity,
                [double]$Utilization,
                [string]$ResourceType
            )
            if ($Capacity -eq 0 -or $null -eq $Capacity) {
                return "-"
            }
            if ($null -eq $Utilization) {
                return "-"
            }
            if ($ResourceType -match "CPU Sum" -and $Utilization -eq 0) {
                return "-"
            }

            $thresholds = @{
                "ApplianceRam"      = @{ AtCapacity = 95; Throttled = 85; Underutilized = 60 }
                "ApplianceCpu"      = @{ AtCapacity = 99; Throttled = 95; Underutilized = 60 }
                "NetworkBandwidth"  = @{ AtCapacity = 95; Throttled = 90; Underutilized = 50 }
                "EsxiNfcBuffer"     = @{ AtCapacity = 100; Throttled = 90; Underutilized = 70 }
                "ParallelDisks"     = @{ AtCapacity = 100; Throttled = 95; Underutilized = 70 }
                "Datastore"         = @{ AtCapacity = 100; Throttled = 95; Underutilized = 70 }
                "Default"           = @{ AtCapacity = 100; Throttled = 90; Underutilized = 70 }
            }

            # Map resource type to threshold set
            $typeKey = switch -Regex ($ResourceType) {
                "RAM"         { "ApplianceRam" }
                "CPU"         { "ApplianceCpu" }
                "Network"     { "NetworkBandwidth" }
                "NFC"         { "EsxiNfcBuffer" }
                "Disk"        { "ParallelDisks" }
                "Datastore"   { "Datastore" }
                default       { "Default" }
            }

            $t = $thresholds[$typeKey]
            $percent = ($Utilization / $Capacity) * 100

            if ($percent -ge $t.AtCapacity) {
                return "At capacity"
            } elseif ($percent -ge $t.Throttled) {
                return "Throttled"
            } elseif ($percent -le $t.Underutilized) {
                return "Underutilized"
            } else {
                return "Normal"
            }
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
        $null = $PSBoundParameters.Remove('Expedite')

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
            $column = @("Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "Health", "LastSync",  "ESXiHost", "Datastore")
        }
        elseif ($parameterSet -eq "ListByName") {
            $column = @("Appliance", "Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "Health", "LastSync", "ESXiHost", "Datastore")
        }
        else {
            $column = @("Appliance", "Server", "State", "Progress", "TimeElapsed", "TimeRemaining", "UploadSpeed", "LastSync", "ESXiHost", "Datastore")
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

            $row1["ESXiHost"] = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
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
        }

        if( $parameterSet -eq "GetByPrioritiseServer") {

            $replicationState = GetState -State $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailState -ReplicationMigrationItem $ReplicationMigrationItem
            if ($replicationState -match "Failed" -or $replicationState -match "Completed" -or ($replicationState -notmatch "InProgress" -and $replicationState -notmatch "Queued")) {
                $op = $output.Add("Replication for server '$($ReplicationMigrationItem.MachineName)' is in state '$replicationState'. Expedite recommendations are only applicable for servers in 'Queued' or 'InProgress' state.`n")
                return $output;
            }

            # Build a table of VMs sharing resources (appliance, datastore, ESXi host) with the reference VM.
            $vmMigrationTable = New-Object System.Data.DataTable("")
            $column = @("Appliance", "Server", "SharedResourceType", "State", "TimeRemaining", "ESXiHost", "Datastore")
            MakeTable $vmMigrationTable $column

            # Get reference VM's ESXi host and datastores
            $refESXiHost = $ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
            $refDatastores = @()
            if ($ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore) {
                $refDatastores = @($ReplicationMigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore)
            }

            $MigrationItems = Get-AzMigrateServerReplication -ProjectName $ProjectName -ResourceGroupName $ResourceGroupName
            $addedMachines = @{}  # Hashtable to track added machines
            foreach($MigrationItem in $MigrationItems) {
                # Skip the reference VM itself
                if ($MigrationItem.MachineName -eq $ReplicationMigrationItem.MachineName) {
                    continue
                }

                # Skip if this machine has already been added
                if ($addedMachines.ContainsKey($MigrationItem.MachineName)) {
                    continue
                }

                $site = $MigrationItem.ProviderSpecificDetail.vmwareMachineId.Split('/')[-3]
                $appName1 = GetApplianceName $site

                # Check for shared resources
                $sharedTypes = @()

                if ($appName1 -eq $appName) {
                    $sharedTypes += "Appliance"
                }

                $esxiHost = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
                if ($refESXiHost -and $esxiHost -and ($esxiHost -eq $refESXiHost)) {
                    $sharedTypes += "ESXiHost"
                }

                $datastores = @()
                if ($MigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore) {
                    $datastores = @($MigrationItem.ProviderSpecificDetail.GatewayOperationDetailDataStore)
                }
                $commonDatastores = $refDatastores | Where-Object { $datastores -contains $_ }
                foreach ($ds in $commonDatastores) {
                    $sharedTypes += "Datastore"
                }

                if ($sharedTypes.Count -gt 0) {
                    $row1 = $vmMigrationTable.NewRow()
                    $row1["Appliance"] = $appName1
                    $row1["Server"] = $MigrationItem.MachineName
                    $row1["SharedResourceType"] = $sharedTypes -join ', '
                    $row1["TimeRemaining"] = Convert-MillisecondsToTime -Milliseconds $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailTimeRemaining
                    $row1["State"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailState
                    $row1["ESXiHost"] = $MigrationItem.ProviderSpecificDetail.GatewayOperationDetailHostName
                    if ($datastores -and $datastores.Count -gt 0) {
                        $row1["Datastore"] = $datastores -join ', '
                    } else {
                        $row1["Datastore"] = "-"
                    }
                    $vmMigrationTable.Rows.Add($row1)
                    # Mark this machine as added to avoid duplicates
                    $addedMachines[$MigrationItem.MachineName] = $true
                }
            }

            if ($vmMigrationTable.Rows.Count -gt 0) {
                $op = $output.Add("Resource Sharing:`n`nThe following VMs share at least one resource (Appliance, ESXi Host, or Datastore) with VM " + `
                    "'$($ReplicationMigrationItem.MachineName)'. The 'SharedResourceType' and 'SharedResourceName' columns indicate which resource is shared.")
                
                $vmMigrationTable = $vmMigrationTable | Format-Table -AutoSize | Out-String
                $op = $output.Add($vmMigrationTable)
            } 
            else {
                $op = $output.Add("No other VMs found sharing Appliance, ESXi Host, or Datastore with VM '$($ReplicationMigrationItem.MachineName)'.")
            }
            $resourceUtilizationTable = New-Object System.Data.DataTable("")
            $column = @("Resource", "Capacity", "Utilization for server migrations", "Total utilization", "Status")
            MakeTable $resourceUtilizationTable $column
            
            # RAM
            $row1 = $resourceUtilizationTable.NewRow()
            $ramCapacity = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailCapacity
            $ramTotalUtil = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailTotalUtilization
            $row1["Resource"] = "Appliance RAM Sum : Primary and scale out appliances"
            $row1["Capacity"] = Add-MB -Value $ramCapacity
            $row1["Utilization for server migrations"] = Add-MB -Value ($ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.RamDetailProcessUtilization)
            $row1["Total utilization"] = Add-MB -Value $ramTotalUtil
            $row1["Status"] = Get-ResourceStatus -Capacity $ramCapacity -Utilization $ramTotalUtil -ResourceType $row1["Resource"]
            $resourceUtilizationTable.Rows.Add($row1)

            # CPU
            $row2 = $resourceUtilizationTable.NewRow()
            $cpuCapacity = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailCapacity
            $cpuProcessUtil = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailProcessUtilization
            $cpuTotalUtil = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.CpuDetailTotalUtilization
            $row2["Resource"] = "Appliance CPU Sum : Primary and scale out appliances"
            if ($null -ne $cpuCapacity -and $cpuCapacity -ne 0) {
                $row2["Capacity"] = "$($cpuCapacity) Cores"
            } else {
                $row2["Capacity"] = "-"
            }
            $row2["Utilization for server migrations"] = Add-Percent -Value $cpuProcessUtil
            $row2["Total utilization"] = Add-Percent -Value $cpuTotalUtil
            $row2["Status"] = Get-ResourceStatus -Capacity 100 -Utilization $cpuTotalUtil -ResourceType $row2["Resource"]
            $resourceUtilizationTable.Rows.Add($row2)

            # Network Bandwidth
            $row3 = $resourceUtilizationTable.NewRow()
            $netCapacity = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthCapacity
            $netTotalUtil = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthTotalUtilization
            $row3["Resource"] = "Network bandwidth Sum : Primary and scale out appliances"
            $row3["Capacity"] = Add-MBps -Value $netCapacity
            $row3["Utilization for server migrations"] = Add-MBps -Value $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.NetworkBandwidthProcessUtilization
            $row3["Total utilization"] = Add-MBps -Value $netTotalUtil
            $row3["Status"] = Get-ResourceStatus -Capacity $netCapacity -Utilization $netTotalUtil -ResourceType $row3["Resource"]
            $resourceUtilizationTable.Rows.Add($row3)

            # ESXi NFC Buffer
            $row4 = $resourceUtilizationTable.NewRow()
            $nfcCapacity = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.EsxiNfcBufferCapacity
            $nfcProcessUtil = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.EsxiNfcBufferProcessUtilization
            $row4["Resource"] = "ESXi host NFC buffer"
            $row4["Capacity"] = Add-MB -Value $nfcCapacity
            $row4["Utilization for server migrations"] = Add-MB -Value $nfcProcessUtil
            $row4["Total utilization"] = "-"
            $row4["Status"] = Get-ResourceStatus -Capacity $nfcCapacity -Utilization $nfcProcessUtil -ResourceType $row4["Resource"]
            $resourceUtilizationTable.Rows.Add($row4)

            # Parallel Disks Replicated
            $row5 = $resourceUtilizationTable.NewRow()
            $diskCapacity = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DiskReplicationDetailCapacity
            $diskProcessUtil = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.DiskReplicationDetailProcessUtilization
            $row5["Resource"] = "Parallel Disks Replicated Sum : Primary and scale out appliances"
            if ($null -ne $diskCapacity) {
                $row5["Capacity"] = $diskCapacity
            }
            else {
                $row5["Capacity"] = "-"
            }
            if ($null -ne $diskProcessUtil) {
                $row5["Utilization for server migrations"] = $diskProcessUtil
            }
            else {
                $row5["Utilization for server migrations"] = "-"
            }
            $row5["Total utilization"] = "-"
            $row5["Status"] = Get-ResourceStatus -Capacity $diskCapacity -Utilization $diskProcessUtil -ResourceType $row5["Resource"]
            $resourceUtilizationTable.Rows.Add($row5)

            # Datastore Snapshots (list)
            $datastoreList = $ReplicationMigrationItem.ProviderSpecificDetail.ApplianceMonitoringDetail.datastoreSnapshot
            if ($datastoreList) {
                foreach ($ds in $datastoreList) {
                    $row = $resourceUtilizationTable.NewRow()
                    if ($null -ne $ds.datastoreName) {
                        $datastoreName = $ds.datastoreName
                    }
                    else {
                        $datastoreName = "-"
                    }
                    $row["Resource"] = "Datastore '$datastoreName' Snapshot Count"
                    if ($null -ne $ds.totalSnapshotsSupported) {
                        $row["Capacity"] = $ds.totalSnapshotsSupported
                    }
                    else {
                        $row["Capacity"] = "-"
                    }
                    if ($null -ne $ds.totalSnapshotsCreated) {
                        $row["Utilization for server migrations"] = $ds.totalSnapshotsCreated
                    }
                    else {
                        $row["Utilization for server migrations"] = "-"
                    }
                    $row["Total utilization"] = "-"
                    $row["Status"] = Get-ResourceStatus -Capacity $ds.totalSnapshotsSupported -Utilization  $ds.totalSnapshotsCreated -ResourceType $row["Resource"]
                    $resourceUtilizationTable.Rows.Add($row)
                }
            }

            $op = $output.Add("Resource utilization information for migration operations:")
            $resourceUtilizationTableString = $resourceUtilizationTable | Format-Table -AutoSize | Out-String
            $op = $output.Add($resourceUtilizationTableString)

            # Recommendations
            $recommendations = @()
            foreach ($row in $resourceUtilizationTable.Rows) {
                $resource = $row["Resource"]

                # Normalize resource string for matching
                $resourceNorm = $resource.ToLower()
                $status = $row["Status"].ToLower()
                $isQueued = $replicationState -match "Queued"

                if ($status -eq "Throttled" -or $status -eq "At capacity") {
                    if ($resourceNorm -like "*ram*") {
                            $recommendations += "`nResource `"$resource`" is $status. Recommendations:"
                            $recommendations += "Stop other processes running on the appliance that are consuming RAM."
                            $recommendations += "Stop initial replication (IR) or pause delta replication (DR) for other low-priority VMs migrating under this appliance to free up RAM."
                            $recommendations += "Decrease the number of workers (parallel disk replications)."
                            $ramCapacityVal = 0
                            if ($row["Capacity"] -match "(\d+(\.\d+)?)") { $ramCapacityVal = [double]$matches[1] }
                            if ($ramCapacityVal -lt 32768 -and $ramCapacityVal -gt 0) {
                                $recommendations += "Consider increasing the appliance RAM to improve migration performance and support higher workloads."
                            }
                            $recommendations += "If only the primary appliance is present, consider adding or increasing the number of scale-out appliances.`n"
                    }
                    elseif ($resourceNorm -like "*cpu*") {
                            $recommendations += "`nResource `"$resource`" is $status. Recommendations:"
                            $recommendations += "Stop other processes running on the appliance that are consuming CPU."
                            $recommendations += "Stop initial replication (IR) or pause delta replication (DR) for other low-priority VMs migrating under this appliance to free up CPU."
                            $recommendations += "Decrease the number of workers (parallel disk replications)."
                            $recommendations += "If only the primary appliance is present, consider adding or increasing the number of scale-out appliances.`n"
                    }
                    elseif ($resourceNorm -like "*network bandwidth*") {
                            $recommendations += "`nResource `"$resource`" is $status. Recommendations:"
                            $recommendations += "Pause or stop other processes utilizing the network."
                            $recommendations += "Stop initial replication (IR) or pause delta replication (DR) for other low-priority VMs migrating under this appliance to free up network bandwidth."
                            $recommendations += "Decrease the number of workers (parallel disk replications)."
                            $recommendations += "Review and adjust Quality of Service (QoS) limits per process if applicable."
                            $recommendations += "Increase the network bandwidth available to the appliance.`n"
                    }
                    elseif ($resourceNorm -like "*nfc buffer*") {
                        if ($isQueued) {
                            $recommendations += "`nResource `"$resource`" is $status. Recommendations:"
                            $recommendations += "Stop initial replication (IR) or pause delta replication (DR) for other low-priority VMs migrating under this appliance to free up NFC buffer on the ESXi host."
                            $recommendations += "Perform vMotion for other low-priority virtual machines."
                            $recommendations += "Increase the size of the NFC buffer on the ESXi host."
                            $recommendations += "Stop or schedule blackout windows for other backup providers running on the ESXi host.`n"
                        }
                    }
                    elseif ($resourceNorm -like "*parallel disk replicated*") {
                            if ($isQueued) {
                                $recommendations += "`nResource `"$resource`" is $status. Recommendations:"
                                $recommendations += "Add a scale-out appliance to distribute the migration workload more effectively."
                                $recommendations += "Stop initial replication (IR) or pause delta replication (DR) for other low-priority VMs migrating under this appliance to free up parallel disk replication capacity."
                                $recommendations += "If this is the only bottleneck and all other resources are available, increase the number of workers (parallel disk replications)."
                            }
                    }
                    elseif ($resourceNorm -like "*datastore*" -and $resourceNorm -like "*snapshot*") {
                            if ($isQueued) {
                                $recommendations += "`nResource `"$resource`" is $status. Recommendations:"
                                $recommendations += "Pause or stop replications for other VMs migrating under this appliance to free up snapshot capacity."
                                $recommendations += "Increase the snapshot count supported by the datastore."
                                $recommendations += "Perform storage vMotion for other low-priority replicating VMs.`n"
                            }
                    }
                }
            }

            if ($recommendations.Count -gt 0) {
                $op = $output.Add("Based on the resource utilization seen above, here are suggestions to expedite server $($ReplicationMigrationItem.MachineName) migration:")
                foreach ($rec in $recommendations) {
                    $op = $output.Add("$rec")
                }
            }
        }

        if ($parameterSet -eq "GetByApplianceName" -or $parameterSet -eq "ListByName") {
            if ($parameterSet -eq "ListByName") {
                $desiredCols = @("Appliance","Server","State","Progress","TimeElapsed","TimeRemaining","UploadSpeed","Health","LastSync", "ESXiHost", "Datastore")
            }
            elseif ($parameterSet -eq "GetByApplianceName") {
                $desiredCols = @("Server","State","Progress","TimeElapsed","TimeRemaining","UploadSpeed","Health","LastSync","ESXiHost","Datastore")
            }
            else {
                $desiredCols = $vmMigrationStatusTable.Columns | ForEach-Object { $_.ColumnName }
            }

            $existingCols = $vmMigrationStatusTable.Columns | ForEach-Object { $_.ColumnName }
            $cols = $desiredCols | Where-Object { $existingCols -contains $_ }

            if (-not $cols -or $cols.Count -eq 0) { $cols = $existingCols }

            # Select columns explicitly and force Format-Table to render all of them (no truncation)
            $vmMigrationStatusTable = $vmMigrationStatusTable | Select-Object -Property $cols | Format-Table -Property $cols -AutoSize -Wrap -Force | Out-String -Width 4096
            $op = $output.Add($vmMigrationStatusTable)

            $op = $output.Add("To check expedite the operation of a server use the command")
            $op = $output.Add("Get-AzMigrateServerMigrationStatus  -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Expedite`n")
            $op = $output.Add("To resolve the health issue use the command")
            $op = $output.Add("Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health`n")
        }

        return $output;
    }
}