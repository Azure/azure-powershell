function Undo-AzDataProtectionVaultDeletion
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupVaultResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Undeletes a soft deleted backup vault')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the deleted vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory=$false, HelpMessage='Resource Group Name to validate against the deleted vault. Used to ensure the correct vault is selected.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Deleted vault name (GUID) of the soft deleted vault')]
        [Alias('DeletedVaultGUID')]
        [System.String]
        ${DeletedVaultName},

        [Parameter(Mandatory, HelpMessage='Location of the deleted vault')]
        [System.String]
        ${Location},

        [Parameter(Mandatory=$false, HelpMessage='The identityType can take values - "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned", "None".')]
        [System.String]
        ${IdentityType},

        [Parameter(Mandatory=$false, HelpMessage='Gets or sets the user assigned identities.')]
        [Alias('AssignUserIdentity')]
        [System.Collections.Hashtable]
        ${IdentityUserAssignedIdentity},
        
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
            
        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process
    {
        # Get the deleted vault to retrieve its details
        $getDeletedVaultParams = @{
            DeletedVaultName = $DeletedVaultName
            Location = $Location
        }

        if($PSBoundParameters.ContainsKey("SubscriptionId"))
        {
            $getDeletedVaultParams.Add("SubscriptionId", $SubscriptionId)
        }

        if($PSBoundParameters.ContainsKey("DefaultProfile"))
        {
            $getDeletedVaultParams.Add("DefaultProfile", $DefaultProfile)
        }

        if($PSBoundParameters.ContainsKey("HttpPipelinePrepend"))
        {
            $getDeletedVaultParams.Add("HttpPipelinePrepend", $HttpPipelinePrepend)
        }

        if($PSBoundParameters.ContainsKey("HttpPipelineAppend"))
        {
            $getDeletedVaultParams.Add("HttpPipelineAppend", $HttpPipelineAppend)
        }

        try 
        {
            # Get the specific deleted vault by its GUID name
            $deletedVault = Az.DataProtection\Get-AzDataProtectionSoftDeletedBackupVault @getDeletedVaultParams
            
            if($null -eq $deletedVault)
            {
                throw "Could not find deleted vault with ID '$DeletedVaultName' in location '$Location'."
            }

            # Check if we got multiple results (shouldn't happen with specific DeletedVaultName, but handle it)
            if($deletedVault -is [array])
            {
                if($PSBoundParameters.ContainsKey("ResourceGroupName"))
                {
                    # Filter by resource group if provided
                    $deletedVault = $deletedVault | Where-Object { $_.OriginalBackupVaultResourceGroup -eq $ResourceGroupName }
                    
                    if($null -eq $deletedVault)
                    {
                        throw "Deleted vault '$DeletedVaultName' found in location '$Location', but it does not belong to resource group '$ResourceGroupName'."
                    }
                    
                    if($deletedVault -is [array])
                    {
                        Write-Warning "Multiple deleted vaults found with ID '$DeletedVaultName' in resource group '$ResourceGroupName'. Using the first one."
                        $deletedVault = $deletedVault[0]
                    }
                }
                else
                {
                    throw "Multiple deleted vaults found with ID '$DeletedVaultName'. Please specify the ResourceGroupName parameter to identify the correct vault."
                }
            }
            else
            {
                # Single result - validate resource group if provided
                if($PSBoundParameters.ContainsKey("ResourceGroupName"))
                {
                    if($deletedVault.OriginalBackupVaultResourceGroup -ne $ResourceGroupName)
                    {
                        throw "Deleted vault '$DeletedVaultName' exists in location '$Location', but its original resource group is '$($deletedVault.OriginalBackupVaultResourceGroup)', not '$ResourceGroupName'."
                    }
                }
            }

            # Extract the original vault name and deleted vault ID
            $originalVaultName = $deletedVault.OriginalBackupVaultName
            $originalResourceGroup = $deletedVault.OriginalBackupVaultResourceGroup
            $deletedVaultId = $deletedVault.Name  # This is the GUID of the deleted vault
            $vaultLocation = $deletedVault.Location

            # Initialize storage settings from deleted vault
            $storageSetting = $deletedVault.StorageSetting
            if($null -eq $storageSetting -or $storageSetting.Count -eq 0)
            {
                # If no storage settings found in deleted vault, use default
                Write-Warning "No storage settings found in deleted vault. Using default storage settings (VaultStore, LocallyRedundant)."
                $storageSetting = @(New-AzDataProtectionBackupVaultStorageSettingObject -Type LocallyRedundant -DataStoreType VaultStore)
            }

            # Prepare parameters for creating the vault (always restore to original location)
            $createVaultParams = @{
                ResourceGroupName = $originalResourceGroup
                VaultName = $originalVaultName
                Location = $vaultLocation
                # StorageSetting = $storageSetting
            }

            if($PSBoundParameters.ContainsKey("SubscriptionId"))
            {
                $createVaultParams.Add("SubscriptionId", $SubscriptionId)
            }

            # Set identity type (default to SystemAssigned if not specified)
            if($PSBoundParameters.ContainsKey("IdentityType"))
            {
                $createVaultParams.Add("IdentityType", $IdentityType)
            }
            else
            {
                $createVaultParams.Add("IdentityType", "SystemAssigned")
            }

            if($PSBoundParameters.ContainsKey("IdentityUserAssignedIdentity"))
            {
                $createVaultParams.Add("IdentityUserAssignedIdentity", $IdentityUserAssignedIdentity)
            }

            if($PSBoundParameters.ContainsKey("DefaultProfile"))
            {
                $createVaultParams.Add("DefaultProfile", $DefaultProfile)
            }

            if($PSBoundParameters.ContainsKey("AsJob"))
            {
                $createVaultParams.Add("AsJob", $AsJob)
            }

            if($PSBoundParameters.ContainsKey("NoWait"))
            {
                $createVaultParams.Add("NoWait", $NoWait)
            }

            if($PSBoundParameters.ContainsKey("Break"))
            {
                $createVaultParams.Add("Break", $Break)
            }

            if($PSBoundParameters.ContainsKey("Debug"))
            {
                $createVaultParams.Add("Debug", $DebugPreference)
            }

            if($PSBoundParameters.ContainsKey("Proxy"))
            {
                $createVaultParams.Add("Proxy", $Proxy)
            }

            if($PSBoundParameters.ContainsKey("ProxyCredential"))
            {
                $createVaultParams.Add("ProxyCredential", $ProxyCredential)
            }

            if($PSBoundParameters.ContainsKey("ProxyUseDefaultCredentials"))
            {
                $createVaultParams.Add("ProxyUseDefaultCredentials", $ProxyUseDefaultCredentials)
            }

            # Create a custom header step to inject the x-ms-deleted-vault-id header
            # This header is required by the API to identify which deleted vault to restore
            # There is one more optional parameter XmsDeletedVaultId, which can be used as an alternate option
            $headerStep = {
                param($request, $callback, $next)
                
                # Add the custom header for undelete operation
                $request.Headers.Add("x-ms-deleted-vault-id", $deletedVaultId)
                
                # Continue with the pipeline
                return $next.SendAsync($request, $callback)
            }

            # Add the header injection step to the pipeline
            if($PSBoundParameters.ContainsKey("HttpPipelinePrepend"))
            {
                $createVaultParams["HttpPipelinePrepend"] = @($headerStep) + $HttpPipelinePrepend
            }
            else
            {
                $createVaultParams.Add("HttpPipelinePrepend", @($headerStep))
            }

            # Call the internal New-AzDataProtectionBackupVault cmdlet with the custom header
            Az.DataProtection.Internal\New-AzDataProtectionBackupVault @createVaultParams 
        }
        catch 
        {
            throw
        }
    }
}
