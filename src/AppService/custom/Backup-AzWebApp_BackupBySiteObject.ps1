function Backup-AzWebApp_BackupBySiteObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IBackupItem')]
    [CmdletBinding(SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory, HelpMessage='Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Path')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The object representation of the web app or slot.')]
        [Alias('WebApp', 'WebAppSlot')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISite]
        ${SiteObject},

        [Parameter(HelpMessage='Name of the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.String]
        ${BackupName},

        [Parameter(Mandatory, HelpMessage='How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set to Day)')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.Int32]
        ${BackupScheduleFrequencyInterval},

        [Parameter(Mandatory, HelpMessage='The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.FrequencyUnit])]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.FrequencyUnit]
        ${BackupScheduleFrequencyUnit},

        [Parameter(Mandatory, HelpMessage='True if the retention policy should always keep at least one backup in the storage account, regardless how old it is; false otherwise.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${BackupScheduleKeepAtLeastOneBackup},

        [Parameter(Mandatory, HelpMessage='After how many days backups should be deleted.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.Int32]
        ${BackupScheduleRetentionPeriodInDay},

        [Parameter(ParameterSetName='BackupExpanded', HelpMessage='When the schedule should start working.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.DateTime]
        ${BackupScheduleStartTime},

        [Parameter(ParameterSetName='BackupExpanded', HelpMessage='Databases included in the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IDatabaseBackupSetting[]]
        ${Database},

        [Parameter(ParameterSetName='BackupExpanded', HelpMessage='True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${Enabled},

        [Parameter(ParameterSetName='BackupExpanded', HelpMessage='Kind of resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.String]
        ${Kind},

        [Parameter(ParameterSetName='BackupExpanded', Mandatory, HelpMessage='SAS URL to the container.')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Body')]
        [System.String]
        ${StorageAccountUrl},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.WebSite.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $Tokens = $SiteObject.Id.Split("/", [System.StringSplitOptions]::RemoveEmptyEntries)
        $PSBoundParameters.Add("ResourceGroupName", $Tokens[3]) | Out-Null
        $PSBoundParameters.Add("Name", $Tokens[7]) | Out-Null
        if ($Tokens.Length -eq 10)
        {
            $PSBoundParameters.Add("Slot", $Tokens[9]) | Out-Null
        }

        $PSBoundParameters.Remove("SiteObject") | Out-Null
        Az.WebSite\Backup-AzWebApp @PSBoundParameters
    }
}