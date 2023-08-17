


function New-AzDataProtectionBackupInstance {
    [OutputType('')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Configures Backup for supported azure resources')]

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

        [Parameter(Mandatory, HelpMessage='Backup instance request object which will be used to configure backup')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupInstanceResource]
        ${BackupInstance},

        [Parameter(Mandatory=$false, HelpMessage='Resource tags')]        
        [Hashtable]
        ${Tag},

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

    process {
        $name = $BackupInstance.BackupInstanceName
        $null = $PSBoundParameters.Remove("BackupInstance")
        
        if($Tag -ne $null)
        {
            $null = $PSBoundParameters.Remove("Tag")
            $BackupInstance.Tag = $Tag
        }

        # commenting inline validate for now
        # $null = $PSBoundParameters.Add("BackupInstance", $BackupInstance.Property)
        # $null = Az.DataProtection\Test-AzDataProtectionBackupInstanceReadiness @PSBoundParameters
        # $null = $PSBoundParameters.Remove("BackupInstance")

        $null = $PSBoundParameters.Add("Name", $name)        
        $null = $PSBoundParameters.Add("Parameter", $BackupInstance)
        Az.DataProtection.Internal\New-AzDataProtectionBackupInstance @PSBoundParameters
    }

}