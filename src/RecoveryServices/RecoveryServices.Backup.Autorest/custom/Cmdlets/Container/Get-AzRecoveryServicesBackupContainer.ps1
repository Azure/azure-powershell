function Get-AzRecoveryServicesBackupContainer
{
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Gets list of backup containers registered with a recovery services vault')]

	param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The name of the resource group where the recovery services vault is present.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The name of the recovery services vault.')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory=$false, HelpMessage='Specifies the friendly name of the container to get')]
        [System.String]
        ${FriendlyName},

        [Parameter(Mandatory=$false, HelpMessage='Specifies the DatasourceType')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(Mandatory=$true, HelpMessage='Specifies the backup container type. The acceptable values for this parameter are: AzureVM, Windows, AzureStorage, AzureVMAppContainer')]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.BackupContainerType]
        ${ContainerType},

        [Parameter(Mandatory=$false, HelpMessage='The ResourceGroup of the resource being managed by the Azure Backup service for example: ResourceGroup name of the VM')]
        [System.String]
        ${ContainerResourceGroupName},
                
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
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
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
        $containerResourceGroupName = $ContainerResourceGroupName

        $filter = Get-ContainerFilter -ContainerType $ContainerType -FriendlyName $FriendlyName -DatasourceType $DatasourceType
        Write-Debug "Container filter - $filter"

        $inquiryContainerType = $null
        if($PSBoundParameters.ContainsKey("DatasourceType")){
            # load manifest and get workload type filter if enabled
            $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
                
            if($manifest.containerInquiryType -ne $null){
                $inquiryContainerType = $manifest.containerInquiryType
            }
        }

        $null = $PSBoundParameters.Remove("ContainerType")
        $null = $PSBoundParameters.Remove("FriendlyName")
        $null = $PSBoundParameters.Remove("DatasourceType")
        $null = $PSBoundParameters.Remove("ContainerResourceGroupName")
        
        if($filter -ne $null){
            $null = $PSBoundParameters.Add("Filter", $filter)
        }

        $containersList = Az.RecoveryServices.Internal\Get-AzRecoveryServicesBackupProtectionContainer @PSBoundParameters
        
        # filter by container resource group
        if($containerResourceGroupName -ne ""){
            $containersList = $containersList | Where-Object { $_.Id.Split(';')[-2] -eq $containerResourceGroupName }
        }

        # filter by worloadType -  MSSQL, SAPHANA
        if($inquiryContainerType -ne ""){
            $containersList = $containersList | Where-Object { $_.Property.ExtendedInfo.InquiryInfo.InquiryDetail.Type -match $inquiryContainerType }
        }        

        $containersList
    }
}