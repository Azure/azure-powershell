

function Update-AzDataProtectionBackupInstance
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupInstanceResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates a given backup instance')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Unique Name of protected backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(Mandatory=$false, HelpMessage='Id of the Policy to be associated with the backup instance')]
        [System.String]
        ${PolicyId},

        [Parameter(Mandatory=$false, HelpMessage='Use system assigned identity')]
        [System.Nullable[System.Boolean]]
        ${UseSystemAssignedIdentity},

        [Parameter(Mandatory=$false, HelpMessage='User assigned identity ARM Id')]
        [Alias('AssignUserIdentity')]
        [System.String]
        ${UserAssignedIdentityArmId},

        [Parameter(Mandatory=$false, HelpMessage='List of containers to be backed up inside the VaultStore. Use this parameter for DatasourceType AzureBlob.')]
        [System.String[]]
        ${VaultedBackupContainer},
        
        [Parameter(Mandatory=$false, HelpMessage='Resource guard operation request in the format similar to <ResourceGuard-ARMID>/dppModifyPolicy/default. Use this parameter when the operation is MUA protected.')]
        [System.String[]]
        ${ResourceGuardOperationRequest},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch secure authorization token for different tenant and then convert to string using ConvertFrom-SecureString cmdlet.')]
        [System.String]
        ${Token},

        [Parameter(Mandatory=$false, HelpMessage='Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.')]
        [System.Security.SecureString]
        ${SecureToken},

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

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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
        $hasPolicyId = $PSBoundParameters.Remove("PolicyId")
        $hasVaultedBackupContainer = $PSBoundParameters.Remove("VaultedBackupContainer")
        $hasUseSystemAssignedIdentity = $PSBoundParameters.Remove("UseSystemAssignedIdentity")
        $hasUserAssignedIdentityArmId = $PSBoundParameters.Remove("UserAssignedIdentityArmId")        

        $instance = Az.DataProtection\Get-AzDataProtectionBackupInstance @PSBoundParameters
        
        if($hasPolicyId){
            $instance.Property.PolicyInfo.PolicyId = $PolicyId
        }

        $DatasourceType =  GetClientDatasourceType -ServiceDatasourceType $instance.Property.DataSourceInfo.Type 
        # $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()

        if ($hasUseSystemAssignedIdentity -or $hasUserAssignedIdentityArmId) {
            
            if ($hasUserAssignedIdentityArmId -and (!$hasUseSystemAssignedIdentity -or $UseSystemAssignedIdentity)) {
                throw "UserAssignedIdentityArmId cannot be provided without UseSystemAssignedIdentity and UseSystemAssignedIdentity must be false when UserAssignedIdentityArmId is provided."
            }
            
            $instance.Property.IdentityDetail = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IdentityDetails]::new()
            $instance.Property.IdentityDetail.UseSystemAssignedIdentity = $UseSystemAssignedIdentity            

            if ($hasUserAssignedIdentityArmId) {
                $instance.Property.IdentityDetail.UserAssignedIdentityArmUrl = $UserAssignedIdentityArmId
            }
        }
        
        if($hasVaultedBackupContainer){

            if($DatasourceType -ne "AzureBlob"){
                $err = "Parameter VaultedBackupContainer isn't supported for given Datasource"
                throw $err
            }

            # exclude containers which start with $ except $web, $root
            $unsupportedContainers = $VaultedBackupContainer | Where-Object { $_ -like '$*' -and $_ -ne "`$root" -and $_ -ne "`$web"}
            if($unsupportedContainers.Count -gt 0){
                $message = "Following containers are not allowed for configure protection with AzureBlob - $unsupportedContainers. Please remove them and try again."
                throw $message
            }
                        
            $datasourceParam = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList
            
            if($datasourceParam -ne $null -and $datasourceParam[0].ObjectType -eq "BlobBackupDatasourceParameters"){
                $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0].ContainersList = $VaultedBackupContainer
            }
            elseif($datasourceParam -eq $null){
                $backupConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.BlobBackupDatasourceParameters]::new()
                $backupConfiguration.ObjectType = "BlobBackupDatasourceParameters"
                $backupConfiguration.ContainersList = $VaultedBackupContainer

                $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList += @($backupConfiguration)
            }
            else{
                $err = "instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList is not in proper format."
                throw $err
            }
        }

        # deep validate for update-BI
        $instance.Property.ValidationType = "DeepValidation"

        $hasResourceGuardOperationRequest = $PSBoundParameters.Remove("ResourceGuardOperationRequest")
        if($hasResourceGuardOperationRequest){
            $instance.Property.ResourceGuardOperationRequest = $ResourceGuardOperationRequest
        }

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

        # Explicitly setting the whole DSSetInfo object as null when ResourceID is null
        if($instance.Property.DataSourceSetInfo.ResourceId -eq $null){
            $instance.Property.DataSourceSetInfo =$null      
        }

        $null = $PSBoundParameters.Remove("BackupInstanceName")
        $null = $PSBoundParameters.Add("Name", $instance.Name)
        $null = $PSBoundParameters.Add("Parameter", $instance)
        Az.DataProtection.Internal\New-AzDataProtectionBackupInstance @PSBoundParameters
    }
}