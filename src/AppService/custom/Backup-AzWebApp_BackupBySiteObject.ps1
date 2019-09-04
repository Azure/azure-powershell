function Backup-AzWebApp_BackupBySiteObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IBackupItem')]
    [CmdletBinding(SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppService.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory, HelpMessage='Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Path')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The object representation of the web app or slot.')]
        [Alias('WebApp', 'WebAppSlot')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISite]
        ${SiteObject},

        [Parameter(HelpMessage='Name of the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.String]
        ${BackupName},

        [Parameter(Mandatory, HelpMessage='How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set to Day)')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.Int32]
        ${BackupScheduleFrequencyInterval},

        [Parameter(Mandatory, HelpMessage='The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.FrequencyUnit])]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.FrequencyUnit]
        ${BackupScheduleFrequencyUnit},

        [Parameter(Mandatory, HelpMessage='True if the retention policy should always keep at least one backup in the storage account, regardless how old it is; false otherwise.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${BackupScheduleKeepAtLeastOneBackup},

        [Parameter(Mandatory, HelpMessage='After how many days backups should be deleted.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.Int32]
        ${BackupScheduleRetentionPeriodInDay},

        [Parameter(HelpMessage='When the schedule should start working.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.DateTime]
        ${BackupScheduleStartTime},

        [Parameter(HelpMessage='Databases included in the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IDatabaseBackupSetting[]]
        ${Database},

        [Parameter(HelpMessage='True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${Enabled},

        [Parameter(HelpMessage='Kind of resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.String]
        ${Kind},

        [Parameter(Mandatory, HelpMessage='SAS URL to the container.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.String]
        ${StorageAccountUrl},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $Tokens = $SiteObject.Id.Split("/", [System.StringSplitOptions]::RemoveEmptyEntries)
        $null = $PSBoundParameters.Add("ResourceGroupName", $Tokens[3])
        $null = $PSBoundParameters.Add("Name", $Tokens[7])
        if ($Tokens.Length -eq 10)
        {
            $null = $PSBoundParameters.Add("Slot", $Tokens[9])
        }

        $null = $PSBoundParameters.Remove("SiteObject")
        Az.WebSite\Backup-AzWebApp @PSBoundParameters
    }
}