

function Start-AzDataProtectionBackupInstanceRestore
{   
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IOperationJobExtendedInfo')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Triggers restore for a BackupInstance')]

    param(
        # Trigger, TriggerExpanded
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the backup vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the backup vault is present')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(Mandatory, HelpMessage='The name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(ParameterSetName="Trigger", Mandatory, HelpMessage='Restore request object to be initialized using Initialize-AzDataProtectionRestoreRequest cmdlet', ValueFromPipeline=$true)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRestoreRequest]
        ${Parameter},

        [Parameter(Mandatory=$false, HelpMessage='Resource guard operation request in the format similar to <resourceguard-ARMID>/dppTriggerRestoreRequests/default. Use this parameter when the operation is MUA protected.')]
        [System.String[]]
        ${ResourceGuardOperationRequest},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant.')]
        [System.String]        
        ${Token},

        [Parameter(ParameterSetName="TriggerExpanded", Mandatory, HelpMessage='Object type of the restore request')]
        [System.String]
        ${ObjectType},

        [Parameter(ParameterSetName="TriggerExpanded", Mandatory, HelpMessage='Gets or sets the restore target information')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IRestoreTargetInfoBase]
        ${RestoreTargetInfo},

        [Parameter(ParameterSetName="TriggerExpanded", Mandatory, HelpMessage='Type of the source data store')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType]
        ${SourceDataStoreType},

        [Parameter(ParameterSetName="TriggerExpanded", Mandatory=$false, HelpMessage='ARM URL for User Assigned Identity')]
        [System.String]
        ${IdentityDetailUserAssignedIdentityArmUrl}, # TODO: add parameter alias to this and below

        [Parameter(ParameterSetName="TriggerExpanded", Mandatory=$false, HelpMessage='Specifies if the BI is protected by System Identity')]
        [System.Management.Automation.SwitchParameter]
        ${IdentityDetailUseSystemAssignedIdentity},

        [Parameter(ParameterSetName="TriggerExpanded", Mandatory=$false, HelpMessage='Fully qualified Azure Resource Manager ID of the datasource which is being recovered')]
        [System.String]
        ${SourceResourceId},

        [Parameter(Mandatory=$false, HelpMessage='Switch parameter to trigger restore to secondary region (Cross region restore)')]
        [Switch]
        ${RestoreToSecondaryRegion},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
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
                
        [Parameter(HelpMessage='Run the command as a job')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(HelpMessage='Run the command asynchronously')]
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
        $hasRestoreToSecondaryRegion = $PSBoundParameters.Remove("RestoreToSecondaryRegion")        
        
        # MUA
        if($PsCmdlet.ParameterSetName -eq "Trigger" -and $PSBoundParameters.ContainsKey("ResourceGuardOperationRequest")){
            $PSBoundParameters.Remove("ResourceGuardOperationRequest")            
            $Parameter.ResourceGuardOperationRequest = $ResourceGuardOperationRequest            
        }

        if($PSBoundParameters.ContainsKey("Token"))
        {            
            $null = $PSBoundParameters.Remove("Token")
            $null = $PSBoundParameters.Add("Token", "Bearer $Token")
        }
                
        if($hasRestoreToSecondaryRegion){
            
            $hasParameter = $PSBoundParameters.Remove("Parameter")
            $hasObjectType = $PSBoundParameters.Remove("ObjectType")
            $hasRestoreTargetInfo = $PSBoundParameters.Remove("RestoreTargetInfo")
            $hasSourceDataStoreType = $PSBoundParameters.Remove("SourceDataStoreType")
            $hasSourceResourceId = $PSBoundParameters.Remove("SourceResourceId")
            $hasIdentityDetailUserAssignedIdentityArmUrl = $PSBoundParameters.Remove("IdentityDetailUserAssignedIdentityArmUrl")
            $hasIdentityDetailUseSystemAssignedIdentity = $PSBoundParameters.Remove("IdentityDetailUseSystemAssignedIdentity")
                        
            # fetch vault from ARG            
            $hasSubscriptionId = $PSBoundParameters.Remove("SubscriptionId")
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("VaultName")
            $null = $PSBoundParameters.Remove("BackupInstanceName")

            $PSBoundParameters.Add('ResourceGroup', $ResourceGroupName)
            $PSBoundParameters.Add('Vault', $VaultName)
            if($hasSubscriptionId) { $PSBoundParameters.Add('Subscription', $SubscriptionId) }
            
            $vault = Search-AzDataProtectionBackupVaultInAzGraph @PSBoundParameters

            $null = $PSBoundParameters.Remove("Subscription")
            $null = $PSBoundParameters.Remove("ResourceGroup")
            $null = $PSBoundParameters.Remove("Vault")
            $PSBoundParameters.Add('ResourceGroupName', $ResourceGroupName)
            if($hasSubscriptionId) { $PSBoundParameters.Add('SubscriptionId', $SubscriptionId) }
            
            $backupInstanceId = "/subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.DataProtection/backupVaults/" + $VaultName + "/backupInstances/" + $BackupInstanceName

            $crossRegionRestoreDetail = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CrossRegionRestoreDetails]::new()
            $crossRegionRestoreDetail.SourceBackupInstanceId = $backupInstanceId
            $crossRegionRestoreDetail.SourceRegion = $vault.Location
            
            $PSBoundParameters.Add('Location', $vault.ReplicatedRegion[0])
            $PSBoundParameters.Add("CrossRegionRestoreDetail", $crossRegionRestoreDetail)

            if($hasParameter){                
                $PSBoundParameters.Add("RestoreRequestObject", $Parameter)
            }
            else{
                $restoreRequestObject = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.AzureBackupRestoreRequest]::new()
                if($hasObjectType) { $restoreRequestObject.ObjectType = $ObjectType }
                if($hasRestoreTargetInfo) { $restoreRequestObject.RestoreTargetInfo = $RestoreTargetInfo }
                if($hasSourceDataStoreType) { $restoreRequestObject.SourceDataStoreType = $SourceDataStoreType }
                if($hasSourceResourceId) { $restoreRequestObject.SourceResourceId = $SourceResourceId }
                if($hasIdentityDetailUseSystemAssignedIdentity) { $restoreRequestObject.IdentityDetailUseSystemAssignedIdentity = $IdentityDetailUseSystemAssignedIdentity }
                if($hasIdentityDetailUserAssignedIdentityArmUrl) { $restoreRequestObject.IdentityDetailUserAssignedIdentityArmUrl = $IdentityDetailUserAssignedIdentityArmUrl }

                $PSBoundParameters.Add("RestoreRequestObject", $restoreRequestObject)
            }           

            Az.DataProtection.Internal\Start-AzDataProtectionBackupInstanceCrossRegionRestore @PSBoundParameters
        }
        else{        
            Az.DataProtection.Internal\Start-AzDataProtectionBackupInstanceRestore @PSBoundParameters
        }
    }
}