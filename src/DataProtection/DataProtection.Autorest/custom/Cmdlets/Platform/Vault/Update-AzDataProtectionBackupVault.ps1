function Update-AzDataProtectionBackupVault
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupVaultResource')]
    [CmdletBinding(DefaultParameterSetName="UpdateExpanded", PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates a BackupVault resource belonging to a resource group. For example updating tags for a resource.')]

    param(
        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='The ID of the target subscription. The value must be an UUID.')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory, HelpMessage='The name of the resource group. The name is case insensitive.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory, HelpMessage='The name of the backup vault.')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="UpdateExpanded",HelpMessage='The identityType which can take values: "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned", "None"')]
        [System.String]
        ${IdentityType},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Parameter to Enable or Disable built-in azure monitor alerts for job failures. Security alerts cannot be disabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AlertsState]
        [ValidateSet('Enabled','Disabled')]
        ${AzureMonitorAlertsForAllJobFailure},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Immutability state of the vault. Allowed values are Disabled, Unlocked, Locked.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ImmutabilityState]
        [ValidateSet('Disabled','Unlocked', 'Locked')]
        ${ImmutabilityState},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Cross region restore state of the vault. Allowed values are Disabled, Enabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossRegionRestoreState]
        [ValidateSet('Disabled','Enabled')]
        ${CrossRegionRestoreState},
        
        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Cross subscription restore state of the vault. Allowed values are Disabled, Enabled, PermanentlyDisabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossSubscriptionRestoreState]
        [ValidateSet('Disabled','Enabled', 'PermanentlyDisabled')]
        ${CrossSubscriptionRestoreState},
        
        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Soft delete retention duration in days')]
        [System.Double]
        ${SoftDeleteRetentionDurationInDay},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Soft delete state of the vault. Allowed values are Off, On, AlwaysOn')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SoftDeleteState]
        [ValidateSet('Off','On', 'AlwaysOn')]  
        ${SoftDeleteState},

        [Parameter(ParameterSetName="UpdateExpanded",HelpMessage='Resource tags.')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Gets or sets the user assigned identities.')]
        [Alias('UserAssignedIdentity', 'AssignUserIdentity')]
        [System.Collections.Hashtable]
        ${IdentityUserAssignedIdentity},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='Enable CMK encryption state for a Backup Vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.EncryptionState]
        ${CmkEncryptionState},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='The identity type to be used for CMK encryption - SystemAssigned or UserAssigned Identity.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.IdentityType]
        ${CmkIdentityType},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='This parameter is required if the identity type is UserAssigned. Add the user assigned managed identity id to be used which has access permissions to the Key Vault.')]
        [System.String]
        ${CmkUserAssignedIdentityId},

        [Parameter(ParameterSetName="UpdateExpanded",Mandatory=$false, HelpMessage='The Key URI of the CMK key to be used for encryption. To enable auto-rotation of keys, exclude the version component from the Key URI. ')]
        [System.String]
        ${CmkEncryptionKeyUri},
        
        [Parameter(ParameterSetName="UpdateExpanded", Mandatory=$false, HelpMessage='Resource guard operation request in the format similar to <ResourceGuard-ARMID>/operationName/default. Here operationName can be any of dppReduceImmutabilityStateRequests, dppReduceSoftDeleteSecurityRequests, dppModifyEncryptionSettingsRequests. Use this parameter when the operation is MUA protected.')]
        [System.String[]]
        ${ResourceGuardOperationRequest},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch secure authorization token for different tenant and then convert to string using ConvertFrom-SecureString cmdlet.')]
        [System.String]
        ${Token},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.')]
        [System.Security.SecureString]
        ${SecureToken},

        [Parameter(HelpMessage='The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
            
        [Parameter(HelpMessage='Run the command as a job')]
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
        $hasToken = $PSBoundParameters.Remove("Token")
        $hasSecureToken = $PSBoundParameters.Remove("SecureToken")
        if($hasToken -or $hasSecureToken)
        {   
            if($hasSecureToken -and $hasToken){
                throw "Both Token and SecureToken parameters cannot be provided together"
            }
            elseif($hasToken){
                Write-Warning -Message 'The Token parameter is deprecated and will be removed in future versions. Please use SecureToken instead.'
                $null = $PSBoundParameters.Add("Token", "Bearer $Token")
            }
            else{
                $plainToken = UnprotectSecureString -SecureString $SecureToken
                $null = $PSBoundParameters.Add("Token", "Bearer $plainToken")
            }
        }

        $hasCmkEncryptionState = $PSBoundParameters.Remove("CmkEncryptionState")
        $hasCmkIdentityType = $PSBoundParameters.Remove("CmkIdentityType")
        $hasCmkUserAssignedIdentityId = $PSBoundParameters.Remove("CmkUserAssignedIdentityId")
        $hasCmkEncryptionKeyUri = $PSBoundParameters.Remove("CmkEncryptionKeyUri")

        if (-not $hasCmkEncryptionState -and -not $hasCmkIdentityType -and -not $hasCmkUserAssignedIdentityId -and -not $hasCmkEncryptionKeyUri) {
            Az.DataProtection.Internal\Update-AzDataProtectionBackupVault @PSBoundParameters
            return
        }

        $hasIdentityType = $PSBoundParameters.Remove("IdentityType")
        $hasAzureMonitorAlertsForAllJobFailure = $PSBoundParameters.Remove("AzureMonitorAlertsForAllJobFailure")
        $hasImmutabilityState = $PSBoundParameters.Remove("ImmutabilityState")
        $hasCrossRegionRestoreState = $PSBoundParameters.Remove("CrossRegionRestoreState")
        $hasCrossSubscriptionRestoreState = $PSBoundParameters.Remove("CrossSubscriptionRestoreState")
        $hasSoftDeleteRetentionDurationInDay = $PSBoundParameters.Remove("SoftDeleteRetentionDurationInDay")
        $hasSoftDeleteState = $PSBoundParameters.Remove("SoftDeleteState")
        $hasTag = $PSBoundParameters.Remove("Tag")
        $hasUserAssignedIdentity = $PSBoundParameters.Remove("UserAssignedIdentity")

        $vault = Az.DataProtection\Get-AzDataProtectionBackupVault @PSBoundParameters

        $encryptionSettings = $null

        if ($vault.EncryptionSetting -ne $null) { $encryptionSettings = $vault.EncryptionSetting }
        else { 
            $encryptionSettings = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.EncryptionSettings]::new()
            $encryptionSettings.CmkIdentity = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKekIdentity]::new()
            $encryptionSettings.CmkKeyVaultProperty = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKeyVaultProperties]::new()
        }

        if ($hasCmkEncryptionState) { $encryptionSettings.State = $CmkEncryptionState }
        if ($hasCmkIdentityType) { 
            $encryptionSettings.CmkIdentity.IdentityType = $CmkIdentityType 
            if ( $CmkIdentityType -eq "SystemAssigned" ) {
                $encryptionSettings.CmkIdentity.IdentityId = $null
            }
        }
        if ($hasCmkUserAssignedIdentityId) { $encryptionSettings.CmkIdentity.IdentityId = $CmkUserAssignedIdentityId }
        if ($hasCmkEncryptionKeyUri) { $encryptionSettings.CmkKeyVaultProperty.KeyUri = $CmkEncryptionKeyUri }

        $PSBoundParameters.Add("EncryptionSetting", $encryptionSettings)

        if ($hasIdentityType) { $PSBoundParameters.Add("IdentityType", $IdentityType) }
        if ($hasAzureMonitorAlertsForAllJobFailure) { $PSBoundParameters.Add("AzureMonitorAlertsForAllJobFailure", $AzureMonitorAlertsForAllJobFailure) }
        if ($hasImmutabilityState) { $PSBoundParameters.Add("ImmutabilityState", $ImmutabilityState) }
        if ($hasCrossRegionRestoreState) { $PSBoundParameters.Add("CrossRegionRestoreState", $CrossRegionRestoreState) }
        if ($hasCrossSubscriptionRestoreState) { $PSBoundParameters.Add("CrossSubscriptionRestoreState", $CrossSubscriptionRestoreState) }
        if ($hasSoftDeleteRetentionDurationInDay) { $PSBoundParameters.Add("SoftDeleteRetentionDurationInDay", $SoftDeleteRetentionDurationInDay) }
        if ($hasSoftDeleteState) { $PSBoundParameters.Add("SoftDeleteState", $SoftDeleteState) }
        if ($hasTag) { $PSBoundParameters.Add("Tag", $Tag) }
        if ($hasUserAssignedIdentity) { $PSBoundParameters.Add("UserAssignedIdentity", $UserAssignedIdentity) }

        Az.DataProtection.Internal\Update-AzDataProtectionBackupVault @PSBoundParameters
    }
}