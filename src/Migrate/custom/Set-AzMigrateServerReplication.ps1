
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
Updates the target properties for the replicating server.
.Description
The Set-AzMigrateServerReplication cmdlet updates the target properties for the replicating server.
.Link
https://docs.microsoft.com/powershell/module/az.migrate/set-azmigrateserverreplication
#>
function Set-AzMigrateServerReplication {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IJob])]
    [CmdletBinding(DefaultParameterSetName = 'ByIDVMwareCbt', PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName = 'ByIDVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetObjectID},

        [Parameter(ParameterSetName = 'ByInputObjectVMwareCbt', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IMigrationItem]
        # Specifies the replicating server for which the properties need to be updated. The server object can be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the replcating server for which the properties need to be updated. The ID should be retrieved using the Get-AzMigrateServerReplication cmdlet.
        ${TargetVMName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Updates the SKU of the Azure VM to be created.
        ${TargetVMSize},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Updates the Virtual Network id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetNetworkId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Updates the Resource Group id within the destination Azure subscription to which the server needs to be migrated.
        ${TargetResourceGroupID},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtNicInput[]]
        # Updates the NIC for the Azure VM to be created.
        ${NicToUpdate},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Availability Set to be used for VM creation.
        ${TargetAvailabilitySet},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Availability Zone to be used for VM creation.
        ${TargetAvailabilityZone},

        [Parameter()]
        [ValidateSet("NoLicenseType" , "PAYG" , "AHUB")]
        [ArgumentCompleter( { "NoLicenseType" , "PAYG" , "AHUB" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies if Azure Hybrid benefit is applicable for the source server to migrated.
        ${SqlServerLicenseType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.Collections.Hashtable]
        # Specifies the tag to be used for Resource creation.
        ${UpdateTags},

        [Parameter()]
        [ValidateSet("Merge" , "Replace" , "Delete")]
        [ArgumentCompleter( { "Merge" , "Replace" , "Delete" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies update tag operation.
        ${UpdateTagsOperation},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetVmtags]
        # Specifies the tag to be used for VM creation.
        ${UpdateVMTags},

        [Parameter()]
        [ValidateSet("Merge" , "Replace" , "Delete")]
        [ArgumentCompleter( { "Merge" , "Replace" , "Delete" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies update VM tag operation.
        ${UpdateVMTagsOperation},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetNicTags]
        # Specifies the tag to be used for Nic creation.
        ${UpdateNicTags},

        [Parameter()]
        [ValidateSet("Merge" , "Replace" , "Delete")]
        [ArgumentCompleter( { "Merge" , "Replace" , "Delete" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies update Nic tag operation.
        ${UpdateNicTagsOperation},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtEnableMigrationInputTargetDiskTags]
        # Specifies the tag to be used for Disk creation.
        ${UpdateDiskTags},

        [Parameter()]
        [ValidateSet("Merge" , "Replace" , "Delete")]
        [ArgumentCompleter( { "Merge" , "Replace" , "Delete" })]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies update Disk tag operation.
        ${UpdateDiskTagsOperation},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the storage account to be used for boot diagnostics.
        ${TargetBootDiagnosticsStorageAccount},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The subscription Id.
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

        $HasTargetVMName = $PSBoundParameters.ContainsKey('TargetVMName')
        $HasTargetVmSize = $PSBoundParameters.ContainsKey('TargetVMSize')
        $HasTargetNetworkId = $PSBoundParameters.ContainsKey('TargetNetworkId')
        $HasTargetResourceGroupID = $PSBoundParameters.ContainsKey('TargetResourceGroupID')
        $HasNicToUpdate = $PSBoundParameters.ContainsKey('NicToUpdate')
        $HasTargetAvailabilitySet = $PSBoundParameters.ContainsKey('TargetAvailabilitySet')
        $HasTargetAvailabilityZone = $PSBoundParameters.ContainsKey('TargetAvailabilityZone')
        $HasSqlServerLicenseType = $PSBoundParameters.ContainsKey('SqlServerLicenseType')
        $HasUpdateTags = $PSBoundParameters.ContainsKey('UpdateTags')
        $HasUpdateTagsOperation = $PSBoundParameters.ContainsKey('UpdateTagsOperation')
        $HasUpdateVMTags = $PSBoundParameters.ContainsKey('UpdateVMTags')
        $HasUpdateVMTagsOperation = $PSBoundParameters.ContainsKey('UpdateVMTagsOperation')
        $HasUpdateNicTags = $PSBoundParameters.ContainsKey('UpdateNicTags')
        $HasUpdateNicTagsOperation = $PSBoundParameters.ContainsKey('UpdateNicTagsOperation')
        $HasUpdateDiskTags = $PSBoundParameters.ContainsKey('UpdateDiskTags')
        $HasUpdateDiskTagsOperation = $PSBoundParameters.ContainsKey('UpdateDiskTagsOperation')
        $HasTargetBootDignosticStorageAccount = $PSBoundParameters.ContainsKey('TargetBootDiagnosticsStorageAccount')
            

        $null = $PSBoundParameters.Remove('TargetObjectID')
        $null = $PSBoundParameters.Remove('TargetVMName')
        $null = $PSBoundParameters.Remove('TargetVMSize')
        $null = $PSBoundParameters.Remove('TargetNetworkId')
        $null = $PSBoundParameters.Remove('TargetResourceGroupID')
        $null = $PSBoundParameters.Remove('NicToUpdate')
        $null = $PSBoundParameters.Remove('TargetAvailabilitySet')
        $null = $PSBoundParameters.Remove('TargetAvailabilityZone')
        $null = $PSBoundParameters.Remove('SqlServerLicenseType')
        $null = $PSBoundParameters.Remove('UpdateTags')
        $null = $PSBoundParameters.Remove('UpdateTagsOperation')
        $null = $PSBoundParameters.Remove('UpdateVMTags')
        $null = $PSBoundParameters.Remove('UpdateVMTagsOperation')
        $null = $PSBoundParameters.Remove('UpdateNicTags')
        $null = $PSBoundParameters.Remove('UpdateNicTagsOperation')
        $null = $PSBoundParameters.Remove('UpdateDiskTags')
        $null = $PSBoundParameters.Remove('UpdateDiskTagsOperation')

        $null = $PSBoundParameters.Remove('InputObject')
        $null = $PSBoundParameters.Remove('TargetBootDiagnosticsStorageAccount')
        $parameterSet = $PSCmdlet.ParameterSetName

        if ($parameterSet -eq 'ByInputObjectVMwareCbt') {
            $TargetObjectID = $InputObject.Id
        }
        $MachineIdArray = $TargetObjectID.Split("/")
        $ResourceGroupName = $MachineIdArray[4]
        $VaultName = $MachineIdArray[8]
        $FabricName = $MachineIdArray[10]
        $ProtectionContainerName = $MachineIdArray[12]
        $MachineName = $MachineIdArray[14]
            
        $null = $PSBoundParameters.Add("ResourceGroupName", $ResourceGroupName)
        $null = $PSBoundParameters.Add("ResourceName", $VaultName)
        $null = $PSBoundParameters.Add("FabricName", $FabricName)
        $null = $PSBoundParameters.Add("MigrationItemName", $MachineName)
        $null = $PSBoundParameters.Add("ProtectionContainerName", $ProtectionContainerName)
            
        $ReplicationMigrationItem = Az.Migrate.internal\Get-AzMigrateReplicationMigrationItem @PSBoundParameters
        if ($ReplicationMigrationItem -and ($ReplicationMigrationItem.ProviderSpecificDetail.InstanceType -eq 'VMwarecbt')) {
            $ProviderSpecificDetails = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.VMwareCbtUpdateMigrationItemInput]::new()
                
            # Auto fill unchanged parameters
            $ProviderSpecificDetails.InstanceType = 'VMwareCbt'
            $ProviderSpecificDetails.LicenseType = $ReplicationMigrationItem.ProviderSpecificDetail.LicenseType
            $ProviderSpecificDetails.PerformAutoResync = $ReplicationMigrationItem.ProviderSpecificDetail.PerformAutoResync
                
            if ($HasTargetAvailabilitySet) {
                $ProviderSpecificDetails.TargetAvailabilitySetId = $TargetAvailabilitySet
            }
            else {
                $ProviderSpecificDetails.TargetAvailabilitySetId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetAvailabilitySetId
            }

            if ($HasTargetAvailabilityZone) {
                $ProviderSpecificDetails.TargetAvailabilityZone = $TargetAvailabilityZone
            }
            else {
                $ProviderSpecificDetails.TargetAvailabilityZone = $ReplicationMigrationItem.ProviderSpecificDetail.TargetAvailabilityZone
            }

            if ($HasSqlServerLicenseType)
            {
                $validLicenseSpellings = @{ 
                    NoLicenseType = "NoLicenseType";
                    PAYG = "PAYG";
                    AHUB = "AHUB"
                }
                $SqlServerLicenseType = $validLicenseSpellings[$SqlServerLicenseType]
                $ProviderSpecificDetails.SqlServerLicenseType = $SqlServerLicenseType
            }
            else
            {
                $ProviderSpecificDetails.SqlServerLicenseType = $ReplicationMigrationItem.ProviderSpecificDetail.SqlServerLicenseType
            }

            if ($HasUpdateTags -And $HasUpdateTagsOperation)
            {
                $IllegalCharKey = New-Object Collections.Generic.List[String]
                $ExceededLengthKey = New-Object Collections.Generic.List[String]
                $ExceededLengthValue = New-Object Collections.Generic.List[String]

                foreach ($x in $UpdateTags.Keys)
                {
                    if ($x.length -gt 512)
                    {
                        $ExceededLengthKey.add($x)
                    }

                    if ($x -match "[<>%&\?/.]")
                    {
                        $IllegalCharKey.add($x)
                    }

                    if ($($UpdateTags.Item($x)).length -gt 256)
                    {
                        $ExceededLengthValue.add($($UpdateTags.Item($x)))
                    }
                }

                if ($IllegalCharKey.Count -gt 0)
                {
                    throw "InvalidTagNameCharacters : The tag names '$($IllegalCharKey -join ', ')' have reserved characters '<,>,%,&,\,?,/' or control characters. These characters are only allowed for tags that start with the prefix 'hidden, link'."
                }

                if ($ExceededLengthKey.Count -gt 0)
                {
                    throw "InvalidTagName : Tag value too large. Following tag value '$($ExceededLengthKey -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '512' characters."
                }

                if ($ExceededLengthValue.Count -gt 0)
                {
                    throw "InvalidTagValueLength : Tag value too large. Following tag value '$($ExceededLengthValue -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '256' characters."
                }

                if ($UpdateTagsOperation -eq "Merge")
                {
                    foreach ($t in $UpdateTags.Keys)
                    {
                        $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.Add($t, $($UpdateTags.Item($t)))
                        $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.Add($t, $($UpdateTags.Item($t)))
                        $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.Add($t, $($UpdateTags.Item($t)))
                    }
                    
                    $ProviderSpecificDetails.TargetVmTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag
                    $ProviderSpecificDetails.TargetNicTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag
                    $ProviderSpecificDetails.TargetDiskTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag
                }
                elseif ($UpdateTagsOperation -eq "Replace")
                {
                    $ProviderSpecificDetails.TargetVmTag = $UpdateTags
                    $ProviderSpecificDetails.TargetNicTag = $UpdateTags
                    $ProviderSpecificDetails.TargetDiskTag = $UpdateTags
                }
                else
                {
                    foreach($x in $UpdateTags.Keys)
                    {
                        if ($ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.ContainsKey($x) `
                            -And ($($ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.Item($x)) `
                            -eq $($UpdateTags.Item($x))))
                        {
                            $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.Remove($x)
                        }

                        if ($ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.ContainsKey($x) `
                            -And ($($ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.Item($x)) `
                            -eq $($UpdateTags.Item($x))))
                        {
                            $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.Remove($x)
                        }

                        if ($ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.ContainsKey($x) `
                            -And ($($ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.Item($x)) `
                            -eq $($UpdateTags.Item($x))))
                        {
                            $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.Remove($x)
                        }
                    }

                    $ProviderSpecificDetails.TargetVmTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag
                    $ProviderSpecificDetails.TargetNicTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag
                    $ProviderSpecificDetails.TargetDiskTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag

                    if ($ProviderSpecificDetails.TargetVmTag.Count -gt 50)
                    {
                        throw "InvalidTags : Too many tags specified. Requested tag count - '$($ProviderSpecificDetails.TargetVmTag.Count)'. Maximum number of tags allowed - '50'."
                    }

                    if ($ProviderSpecificDetails.TargetNicTag.Count -gt 50)
                    {
                        throw "InvalidTags : Too many tags specified. Requested tag count - '$($ProviderSpecificDetails.TargetNicTag.Count)'. Maximum number of tags allowed - '50'."
                    }

                    if ($ProviderSpecificDetails.TargetDiskTag.Count -gt 50)
                    {
                        throw "InvalidTags : Too many tags specified. Requested tag count - '$($ProviderSpecificDetails.TargetDiskTag.Count)'. Maximum number of tags allowed - '50'."
                    }
                }
            }

            else
            {
                if ($HasUpdateVMTags -And $HasUpdateVMTagsOperation) {
                    $IllegalCharKey = New-Object Collections.Generic.List[String]
                    $ExceededLengthKey = New-Object Collections.Generic.List[String]
                    $ExceededLengthValue = New-Object Collections.Generic.List[String]

                    foreach ($x in $UpdateVMTags.Keys)
                    {
                        if ($x.length -gt 512)
                        {
                            $ExceededLengthKey.add($x)
                        }

                        if ($x -match "[<>%&\?/.]")
                        {
                            $IllegalCharKey.add($x)
                        }

                        if ($($UpdateVMTags.Item($x)).length -gt 256)
                        {
                            $ExceededLengthValue.add($($UpdateVMTags.Item($x)))
                        }
                    }

                    if ($IllegalCharKey.Count -gt 0)
                    {
                        throw "InvalidTagNameCharacters : The tag names '$($IllegalCharKey -join ', ')' have reserved characters '<,>,%,&,\,?,/' or control characters. These characters are only allowed for tags that start with the prefix 'hidden, link'."
                    }

                    if ($ExceededLengthKey.Count -gt 0)
                    {
                        throw "InvalidTagName : Tag value too large. Following tag value '$($ExceededLengthKey -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '512' characters."
                    }

                    if ($ExceededLengthValue.Count -gt 0)
                    {
                        throw "InvalidTagValueLength : Tag value too large. Following tag value '$($ExceededLengthValue -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '256' characters."
                    }

                    if ($UpdateVMTagsOperation -eq "Merge")
                    {
                        foreach ($t in $UpdateVMTags.Keys)
                        {
                            $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.Add($t, $($UpdateVMTags.Item($t)))
                        }
                        $ProviderSpecificDetails.TargetVmTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag
                    }
                    elseif ($UpdateVMTagsOperation -eq "Replace")
                    {
                        $ProviderSpecificDetails.TargetVmTag = $UpdateVMTags
                    }
                    else
                    {
                        foreach($x in $UpdateVMTags.Keys)
                        {
                            if ($ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.ContainsKey($x) `
                                -And ($($ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.Item($x)) `
                                -eq $($UpdateVMTags.Item($x))))
                            {
                                $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag.Remove($x)
                            }
                         }
                         $ProviderSpecificDetails.TargetVmTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag
                    }
                    
                    if ($ProviderSpecificDetails.TargetVmTag.Count -gt 50)
                    {
                        throw "InvalidTags : Too many tags specified. Requested tag count - '$($ProviderSpecificDetails.TargetVmTag.Count)'. Maximum number of tags allowed - '50'."
                    }
                }
                else {
                    $ProviderSpecificDetails.TargetVmTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmTag
                }

                if ($HasUpdateNicTags -And $HasUpdateNicTagsOperation) {
                    $IllegalCharKey = New-Object Collections.Generic.List[String]
                    $ExceededLengthKey = New-Object Collections.Generic.List[String]
                    $ExceededLengthValue = New-Object Collections.Generic.List[String]

                    foreach ($x in $UpdateNicTags.Keys)
                    {
                         if ($x.length -gt 512)
                         {
                             $ExceededLengthKey.add($x)
                         }

                         if ($x -match "[<>%&\?/.]")
                         {
                             $IllegalCharKey.add($x)
                         }

                         if ($($UpdateNicTags.Item($x)).length -gt 256)
                         {
                             $ExceededLengthValue.add($($UpdateNicTags.Item($x)))
                         }
                    }

                    if ($IllegalCharKey.Count -gt 0)
                    {
                        throw "InvalidTagNameCharacters : The tag names '$($IllegalCharKey -join ', ')' have reserved characters '<,>,%,&,\,?,/' or control characters. These characters are only allowed for tags that start with the prefix 'hidden, link'."
                    }

                    if ($ExceededLengthKey.Count -gt 0)
                    {
                        throw "InvalidTagName : Tag value too large. Following tag value '$($ExceededLengthKey -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '512' characters."
                    }

                    if ($ExceededLengthValue.Count -gt 0)
                    {
                        throw "InvalidTagValueLength : Tag value too large. Following tag value '$($ExceededLengthValue -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '256' characters."
                    }

                    if ($UpdateNicTagsOperation -eq "Merge")
                    {
                        foreach ($t in $UpdateNicTags.Keys)
                        {
                            $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.Add($t, $($UpdateNicTags.Item($t)))
                        }

                        $ProviderSpecificDetails.TargetNicTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag
                    }
                    elseif ($UpdateNicTagsOperation -eq "Replace")
                    {
                        $ProviderSpecificDetails.TargetNicTag = $UpdateNicTags
                    }
                    else
                    {
                        foreach($x in $UpdateNicTags.Keys)
                        {
                            if ($ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.ContainsKey($x) `
                                -And ($($ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.Item($x)) `
                                -eq $($UpdateNicTags.Item($x))))
                            {
                                $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag.Remove($x)
                            }
                         }
                         $ProviderSpecificDetails.TargetNicTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag
                    }
                    
                    if ($ProviderSpecificDetails.TargetNicTag.Count -gt 50)
                    {
                        throw "InvalidTags : Too many tags specified. Requested tag count - '$($ProviderSpecificDetails.TargetNicTag.Count)'. Maximum number of tags allowed - '50'."
                    }
                }
                else {
                    $ProviderSpecificDetails.TargetNicTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNicTag
                }

                if ($HasUpdateDiskTags -And $HasUpdateDiskTagsOperation) {
                    $IllegalCharKey = New-Object Collections.Generic.List[String]
                    $ExceededLengthKey = New-Object Collections.Generic.List[String]
                    $ExceededLengthValue = New-Object Collections.Generic.List[String]

                    foreach ($x in $UpdateDiskTags.Keys)
                    {
                         if ($x.length -gt 512)
                         {
                             $ExceededLengthKey.add($x)
                         }

                         if ($x -match "[<>%&\?/.]")
                         {
                             $IllegalCharKey.add($x)
                         }

                         if ($($UpdateDiskTags.Item($x)).length -gt 256)
                         {
                             $ExceededLengthValue.add($($UpdateDiskTags.Item($x)))
                         }
                    }

                    if ($IllegalCharKey.Count -gt 0)
                    {
                        throw "InvalidTagNameCharacters : The tag names '$($IllegalCharKey -join ', ')' have reserved characters '<,>,%,&,\,?,/' or control characters. These characters are only allowed for tags that start with the prefix 'hidden, link'."
                    }

                    if ($ExceededLengthKey.Count -gt 0)
                    {
                        throw "InvalidTagName : Tag value too large. Following tag value '$($ExceededLengthKey -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '512' characters."
                    }

                    if ($ExceededLengthValue.Count -gt 0)
                    {
                        throw "InvalidTagValueLength : Tag value too large. Following tag value '$($ExceededLengthValue -join ', ')' exceeded the maximum length. Maximum allowed length for tag value - '256' characters."
                    }

                    if ($UpdateDiskTagsOperation -eq "Merge")
                    {
                        foreach ($t in $UpdateDiskTags.Keys)
                        {
                            $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.Add($t, $($UpdateDiskTags.Item($t)))
                        }
                        $ProviderSpecificDetails.TargetDiskTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag
                    }
                    elseif ($UpdateDiskTagsOperation -eq "Replace")
                    {
                        $ProviderSpecificDetails.TargetDiskTag = $UpdateDiskTags
                    }
                    else
                    {
                        foreach($x in $UpdateDiskTags.Keys)
                        {
                            if ($ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.ContainsKey($x) `
                                -And ($($ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.Item($x)) `
                                -eq $($UpdateDiskTags.Item($x))))
                            {
                                $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag.Remove($x)
                            }
                         }
                         $ProviderSpecificDetails.TargetDiskTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag
                    }
                    
                    if ($ProviderSpecificDetails.TargetDiskTag.Count -gt 50)
                    {
                        throw "InvalidTags : Too many tags specified. Requested tag count - '$($ProviderSpecificDetails.TargetDiskTag.Count)'. Maximum number of tags allowed - '50'."
                    }
                }
                else{
                    $ProviderSpecificDetails.TargetDiskTag = $ReplicationMigrationItem.ProviderSpecificDetail.TargetDiskTag
                }
            }

            if ($HasTargetNetworkId) {
                $ProviderSpecificDetails.TargetNetworkId = $TargetNetworkId
            }
            else {
                $ProviderSpecificDetails.TargetNetworkId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetNetworkId
            }

            if ($HasTargetVMName) {
                $ProviderSpecificDetails.TargetVMName = $TargetVMName
            }
            else {
                $ProviderSpecificDetails.TargetVMName = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVMName
            }

            if ($HasTargetResourceGroupID) {
                $ProviderSpecificDetails.TargetResourceGroupId = $TargetResourceGroupID
            }
            else {
                $ProviderSpecificDetails.TargetResourceGroupId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetResourceGroupId
            }

            if ($HasTargetVmSize) {
                $ProviderSpecificDetails.TargetVMSize = $TargetVmSize
            }
            else {
                $ProviderSpecificDetails.TargetVMSize = $ReplicationMigrationItem.ProviderSpecificDetail.TargetVmSize
            }

            if ($HasTargetBootDignosticStorageAccount) {
                $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId = $TargetBootDiagnosticsStorageAccount
            }
            else {
                $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId = $ReplicationMigrationItem.ProviderSpecificDetail.TargetBootDiagnosticsStorageAccountId
            }

            # Storage accounts need to be in the same subscription as that of the VM.
            if (($null -ne $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId) -and ($ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId.length -gt 1)) {
                $TargetBDSASubscriptionId = $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId.Split('/')[2]
                $TargetSubscriptionId = $ProviderSpecificDetails.TargetResourceGroupId.Split('/')[2]
                if ($TargetBDSASubscriptionId -ne $TargetSubscriptionId) {
                    $ProviderSpecificDetails.TargetBootDiagnosticsStorageAccountId = $null
                }
            }

            $originalNics = $ReplicationMigrationItem.ProviderSpecificDetail.VMNic
            [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IVMwareCbtNicInput[]]$updateNicsArray = @()

            foreach ($storedNic in $originalNics) {
                $updateNic = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.VMwareCbtNicInput]::new()
                $updateNic.IsPrimaryNic = $storedNic.IsPrimaryNic
                $updateNic.IsSelectedForMigration = $storedNic.IsSelectedForMigration
                $updateNic.NicId = $storedNic.NicId
                $updateNic.TargetStaticIPAddress = $storedNic.TargetIPAddress
                $updateNic.TargetSubnetName = $storedNic.TargetSubnetName
                    
                $matchingUserInputNic = $null
                if ($HasNicToUpdate) {
                    foreach ($userInputNic in $NicToUpdate) {
                        if ($userInputNic.NicId -eq $storedNic.NicId) {
                            $matchingUserInputNic = $userInputNic
                            break
                        }
                    }
                }
                if ($null -ne $matchingUserInputNic) {
                    if ($null -ne $matchingUserInputNic.IsPrimaryNic) {
                        $updateNic.IsPrimaryNic = $matchingUserInputNic.IsPrimaryNic
                        $updateNic.IsSelectedForMigration = $matchingUserInputNic.IsSelectedForMigration
                        if ($updateNic.IsSelectedForMigration -eq "false") {
                            $updateNic.TargetSubnetName = ""
                            $updateNic.TargetStaticIPAddress = ""
                        }
                    }
                    if ($null -ne $matchingUserInputNic.TargetSubnetName) {
                        $updateNic.TargetSubnetName = $matchingUserInputNic.TargetSubnetName
                    }
                    if ($null -ne $matchingUserInputNic.TargetStaticIPAddress) {
                        if ($matchingUserInputNic.TargetStaticIPAddress -eq "auto") {
                            $updateNic.TargetStaticIPAddress = $null
                        }
                        else {
                            $updateNic.TargetStaticIPAddress = $matchingUserInputNic.TargetStaticIPAddress
                        }
                    }
                }
                $updateNicsArray += $updateNic
            }

            # validate there is exactly one primary nic
            $primaryNicCountInUpdate = 0
            foreach ($nic in $updateNicsArray) {
                if ($nic.IsPrimaryNic -eq "true") {
                    $primaryNicCountInUpdate += 1
                }
            }
            if ($primaryNicCountInUpdate -ne 1) {
                throw "One NIC has to be Primary."
            }
                
            $ProviderSpecificDetails.VMNic = $updateNicsArray
            $null = $PSBoundParameters.Add('ProviderSpecificDetail', $ProviderSpecificDetails)
            $null = $PSBoundParameters.Add('NoWait', $true)
            $output = Az.Migrate.internal\Update-AzMigrateReplicationMigrationItem @PSBoundParameters
            $JobName = $output.Target.Split("/")[12].Split("?")[0]

            $null = $PSBoundParameters.Remove('NoWait')
            $null = $PSBoundParameters.Remove('ProviderSpecificDetail')
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("ResourceName")
            $null = $PSBoundParameters.Remove("FabricName")
            $null = $PSBoundParameters.Remove("MigrationItemName")
            $null = $PSBoundParameters.Remove("ProtectionContainerName")

            $null = $PSBoundParameters.Add('JobName', $JobName)
            $null = $PSBoundParameters.Add('ResourceName', $VaultName)
            $null = $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            
            return Az.Migrate.internal\Get-AzMigrateReplicationJob @PSBoundParameters
        }
        else {
            throw "Either machine doesn't exist or provider/action isn't supported for this machine"
        }
    }
}   