function New-AzDataProtectionBackupVault
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates or updates a BackupVault resource belonging to a resource group.')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group Name of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(HelpMessage='Optional ETag.')]
        [System.String]
        ${ETag},

        [Parameter(HelpMessage='The identityType can take values - "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned", "None".')]
        [System.String]
        ${IdentityType},

        [Parameter(Mandatory, HelpMessage='Resource location.')]
        [System.String]
        ${Location},

        [Parameter(Mandatory, HelpMessage='Storage Settings of the vault. Use New-AzDataProtectionBackupVaultStorageSetting Cmdlet to Create.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IStorageSetting[]]
        ${StorageSetting},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to Enable or Disable built-in azure monitor alerts for job failures. Security alerts cannot be disabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AlertsState]
        [ValidateSet('Enabled','Disabled')]
        ${AzureMonitorAlertsForAllJobFailure},

        [Parameter(Mandatory=$false, HelpMessage='Immutability state of the vault. Allowed values are Disabled, Unlocked, Locked.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ImmutabilityState]
        [ValidateSet('Disabled','Unlocked', 'Locked')]
        ${ImmutabilityState},

        [Parameter(Mandatory=$false, HelpMessage='Cross region restore state of the vault. Allowed values are Disabled, Enabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossRegionRestoreState]
        [ValidateSet('Disabled','Enabled')]
        ${CrossRegionRestoreState},
        
        [Parameter(Mandatory=$false, HelpMessage='Cross subscription restore state of the vault. Allowed values are Disabled, Enabled, PermanentlyDisabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossSubscriptionRestoreState]
        [ValidateSet('Disabled','Enabled', 'PermanentlyDisabled')]
        ${CrossSubscriptionRestoreState},
        
        [Parameter(Mandatory=$false, HelpMessage='Soft delete retention duration in days')]
        [System.Double]
        ${SoftDeleteRetentionDurationInDay},

        [Parameter(Mandatory=$false, HelpMessage='Soft delete state of the vault. Allowed values are Off, On, AlwaysOn')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SoftDeleteState]
        [ValidateSet('Off','On', 'AlwaysOn')]  
        ${SoftDeleteState},

        [Parameter(HelpMessage='Resource tags.')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(Mandatory=$false, HelpMessage='Gets or sets the user assigned identities.')]
        [Alias('UserAssignedIdentity', 'AssignUserIdentity')]
        [System.Collections.Hashtable]
        ${IdentityUserAssignedIdentity},

        [Parameter(Mandatory=$false, HelpMessage='Enable CMK encryption state for a Backup Vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.EncryptionState]
        ${CmkEncryptionState},

        [Parameter(Mandatory=$false, HelpMessage='Enable infrastructure encryption with CMK on this vault. Infrastructure encryption must be configured only when creating the vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.InfrastructureEncryptionState]
        ${CmkInfrastructureEncryption},

        [Parameter(Mandatory=$false, HelpMessage='The identity type to be used for CMK encryption - SystemAssigned or UserAssigned Identity.')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.IdentityType]
        ${CmkIdentityType},

        [Parameter(Mandatory=$false, HelpMessage='This parameter is required if the identity type is UserAssigned. Add the user assigned managed identity id to be used which has access permissions to the Key Vault.')]
        [System.String]
        ${CmkUserAssignedIdentityId},

        [Parameter(Mandatory=$false, HelpMessage='The Key URI of the CMK key to be used for encryption. To enable auto-rotation of keys, exclude the version component from the Key URI. ')]
        [System.String]
        ${CmkEncryptionKeyUri},
        
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
        if($PSBoundParameters.ContainsKey("IdentityType") -eq $false)
        {
            $null = $PSBoundParameters.Add("IdentityType", "SystemAssigned")
        }

        $hasCmkEncryptionState = $PSBoundParameters.Remove("CmkEncryptionState")
        $hasCmkIdentityType = $PSBoundParameters.Remove("CmkIdentityType")
        $hasCmkUserAssignedIdentityId = $PSBoundParameters.Remove("CmkUserAssignedIdentityId")
        $hasCmkEncryptionKeyUri = $PSBoundParameters.Remove("CmkEncryptionKeyUri")
        $hasCmkInfrastructureEncryption = $PSBoundParameters.Remove("CmkInfrastructureEncryption")

        if (-not $hasCmkEncryptionState -and -not $hasCmkIdentityType -and -not $hasCmkUserAssignedIdentityId -and -not $hasCmkEncryptionKeyUri) {
            Az.DataProtection.Internal\New-AzDataProtectionBackupVault @PSBoundParameters
            return
        }

        $encryptionSettings = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.EncryptionSettings]::new()
        $encryptionSettings.State = $CmkEncryptionState
        $encryptionSettings.CmkInfrastructureEncryption = $CmkInfrastructureEncryption
        $encryptionSettings.CmkIdentity = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKekIdentity]::new()
        $encryptionSettings.CmkIdentity.IdentityType = $CmkIdentityType
        $encryptionSettings.CmkIdentity.IdentityId = $CmkUserAssignedIdentityId
        $encryptionSettings.CmkKeyVaultProperty = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKeyVaultProperties]::new()
        $encryptionSettings.CmkKeyVaultProperty.KeyUri = $CmkEncryptionKeyUri

        $PSBoundParameters.Add("EncryptionSetting", $encryptionSettings)

        Az.DataProtection.Internal\New-AzDataProtectionBackupVault @PSBoundParameters
    }
}