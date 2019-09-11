function Restore-AzWebApp {
    [OutputType('System.Boolean')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppService.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppService.Description('Recovers a web app to a previous snapshot.')]
    param(
        [Parameter(Mandatory, HelpMessage='Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The object representation of the web app or slot.')]
        [Alias('WebApp', 'WebAppSlot')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISite]
        ${SiteObject},

        [Parameter(ParameterSetName='RestoreBySiteObject', Mandatory, HelpMessage='ID of the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='backupId', Required, PossibleTypes=([System.String]), Description='ID of the backup.')]
        [System.String]
        # ID of the backup.
        ${BackupId},

        [Parameter(HelpMessage='When specified, PassThru will force the cmdlet return a ''bool'' given that there isn''t a return type by default.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.
        ${PassThru},

        [Parameter(HelpMessage='If true, custom hostname conflicts will be ignored when recovering to a target web app.This setting is only necessary when RecoverConfiguration is enabled.')]
        [Alias('IgnoreConflictingHostNames')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='ignoreConflictingHostNames', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='If true, custom hostname conflicts will be ignored when recovering to a target web app.This setting is only necessary when RecoverConfiguration is enabled.')]
        [System.Management.Automation.SwitchParameter]
        # If true, custom hostname conflicts will be ignored when recovering to a target web app.This setting is only necessary when RecoverConfiguration is enabled.
        ${IgnoreConflictingHostName},

        [Parameter(HelpMessage='Kind of resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='kind', PossibleTypes=([System.String]), Description='Kind of resource.')]
        [System.String]
        # Kind of resource.
        ${Kind},

        [Parameter(HelpMessage='If <code>true</code> the recovery operation can overwrite source app; otherwise, <code>false</code>.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='overwrite', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='If <code>true</code> the recovery operation can overwrite source app; otherwise, <code>false</code>.')]
        [System.Management.Automation.SwitchParameter]
        # If <code>true</code> the recovery operation can overwrite source app; otherwise, <code>false</code>.
        ${Overwrite},

        [Parameter(ParameterSetName='RecoverBySiteObject', HelpMessage='If true, site configuration, in addition to content, will be reverted.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='recoverConfiguration', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='If true, site configuration, in addition to content, will be reverted.')]
        [System.Management.Automation.SwitchParameter]
        # If true, site configuration, in addition to content, will be reverted.
        ${RecoverConfiguration},

        [Parameter(ParameterSetName='RecoverBySiteObject', HelpMessage='ARM resource ID of the target app. /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='id', PossibleTypes=([System.String]), Description='ARM resource ID of the target app. /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.')]
        [System.String]
        # ARM resource ID of the target app. /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
        ${RecoveryTargetId},

        [Parameter(ParameterSetName='RecoverBySiteObject', HelpMessage='Geographical location of the target web app, e.g. SouthEastAsia, SouthCentralUS')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='location', PossibleTypes=([System.String]), Description='Geographical location of the target web app, e.g. SouthEastAsia, SouthCentralUS')]
        [System.String]
        # Geographical location of the target web app, e.g. SouthEastAsia, SouthCentralUS
        ${RecoveryTargetLocation},

        [Parameter(ParameterSetName='RecoverBySiteObject', HelpMessage='Point in time in which the app recovery should be attempted, formatted as a DateTime string.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='snapshotTime', PossibleTypes=([System.String]), Description='Point in time in which the app recovery should be attempted, formatted as a DateTime string.')]
        [System.String]
        # Point in time in which the app recovery should be attempted, formatted as a DateTime string.
        ${SnapshotTime},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='<code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='adjustConnectionStrings', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='<code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.')]
        [System.Management.Automation.SwitchParameter]
        # <code>true</code> if SiteConfig.ConnectionStrings should be set in new app; otherwise, <code>false</code>.
        ${AdjustConnectionString},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='Specify app service plan that will own restored site.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='appServicePlan', PossibleTypes=([System.String]), Description='Specify app service plan that will own restored site.')]
        [System.String]
        # Specify app service plan that will own restored site.
        ${AppServicePlan},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='Name of a blob which contains the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='blobName', PossibleTypes=([System.String]), Description='Name of a blob which contains the backup.')]
        [System.String]
        # Name of a blob which contains the backup.
        ${BlobName},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='Collection of databases which should be restored. This list has to match the list of databases included in the backup. To construct, see NOTES section for DATABASE properties and create a hash table.')]
        [Alias('Databases')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='databases', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IDatabaseBackupSetting]), Description='Collection of databases which should be restored. This list has to match the list of databases included in the backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IDatabaseBackupSetting[]]
        # Collection of databases which should be restored. This list has to match the list of databases included in the backup.
        # To construct, see NOTES section for DATABASE properties and create a hash table.
        ${Database},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='App Service Environment name, if needed (only when restoring an app to an App Service Environment).')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='hostingEnvironment', PossibleTypes=([System.String]), Description='App Service Environment name, if needed (only when restoring an app to an App Service Environment).')]
        [System.String]
        # App Service Environment name, if needed (only when restoring an app to an App Service Environment).
        ${HostingEnvironment},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='Ignore the databases and only restore the site content')]
        [Alias('IgnoreDatabases')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='ignoreDatabases', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Ignore the databases and only restore the site content')]
        [System.Management.Automation.SwitchParameter]
        # Ignore the databases and only restore the site content
        ${IgnoreDatabase},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='Operation type.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='operationType', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.BackupRestoreOperationType]), Description='Operation type.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.BackupRestoreOperationType]
        # Operation type.
        ${OperationType},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='Name of an app.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='siteName', PossibleTypes=([System.String]), Description='Name of an app.')]
        [System.String]
        # Name of an app.
        ${SiteName},

        [Parameter(ParameterSetName='RestoreBySiteObject', HelpMessage='SAS URL to the container.')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.Info(SerializedName='storageAccountUrl', PossibleTypes=([System.String]), Description='SAS URL to the container.')]
        [System.String]
        # SAS URL to the container.
        ${StorageAccountUrl},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage='Run the command asynchronously')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.AppService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
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
        Az.WebSite\Restore-AzWebApp @PSBoundParameters
    }
}