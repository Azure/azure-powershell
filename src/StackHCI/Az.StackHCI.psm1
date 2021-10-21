#
# AzureStack HCI Registration and Unregistration Powershell Cmdlets.
#

$ErrorActionPreference = 'Stop'

$GAOSBuildNumber = 17784
$GAOSUBR = 1374
$V2OSBuildNumber = 20348
$V2OSUBR = 288
#region User visible strings

$AdminConsentWarning = "You need additional Azure Active Directory permissions to register in this Azure subscription. Contact your Azure AD administrator to grant consent to AAD application identity {0} at {1}. Then, run Register-AzStackHCI again with same parameters to complete registration."
$NoClusterError = "Computer {0} is not part of an Azure Stack HCI cluster. Use the -ComputerName parameter to specify an Azure Stack HCI cluster node and try again."
$CloudResourceDoesNotExist = "The Azure resource with ID {0} doesn't exist. Unregister the cluster using Unregister-AzStackHCI and then try again."
$RegisteredWithDifferentResourceId = "Azure Stack HCI is already registered with Azure resource ID {0}. To register or change registration, first unregister the cluster using Unregister-AzStackHCI, then try again."
$RegistrationInfoNotFound = "Additional parameters are required to unregister. Run 'Get-Help Unregister-AzStackHCI -Full' for more information."
$RegionNotSupported = "Azure Stack HCI is not yet available in region {0}. Please choose one of these regions: {1}."
$CertificateNotFoundOnNode = "Certificate with thumbprint {0} not found on node(s) {1}. Make sure the certificate has been added to the certificate store on every clustered node."
$SettingCertificateFailed = "Failed to register. Couldn't generate self-signed certificate on node(s) {0}. Couldn't set and verify registration certificate on node(s) {1}. Make sure every clustered node is up and has Internet connectivity (at least outbound to Azure)."
$InstallLatestVersionWarning = "Newer version of the Az.StackHCI module is available. Update from version {0} to version {1} using Update-Module."
$NotAllTheNodesInClusterAreGA = "Update the operating system on node(s) {0} to version $GAOSBuildNumber.$GAOSUBR or later to continue."
$NoExistingRegistrationExistsErrorMessage = "Can't repair registration because the cluster isn't registered yet. Register the cluster using Register-AzStackHCI without the -RepairRegistration option."
$UserCertValidationErrorMessage = "Can't use certificate with thumbprint {0} because it expires in less than 60 days, on {1}. Certificates must be valid for at least 60 days."
$FailedToRemoveRegistrationCertWarning = "Couldn't clean up Azure Stack HCI registration certificate from node(s) {0}. You can ignore this message or clean up the certificate yourself (optional)."
$UnregistrationSuccessDetailsMessage = "Azure Stack HCI is successfully unregistered. The Azure resource representing Azure Stack HCI has been deleted. Azure Stack HCI can't sync with Azure until you register again."
$RegistrationSuccessDetailsMessage = "Azure Stack HCI is successfully registered. An Azure resource representing Azure Stack HCI has been created in your Azure subscription to enable an Azure-consistent monitoring, billing, and support experience."
$CouldNotGetLatestModuleInformationWarning = "Can't connect to the PowerShell Gallery to verify module version. Make sure you have the latest Az.StackHCI module with major version {0}.*."
$ConnectingToCloudBillingServiceFailed = "Can't reach Azure from node(s) {0}. Make sure every clustered node has network connectivity to Azure. Verify that your network firewall allows outbound HTTPS from port 443 to all the well-known Azure IP addresses and URLs required by Azure Stack HCI. Visit aka.ms/hcidocs for details."
$ResourceExistsInDifferentRegionError = "There is already an Azure Stack HCI resource with the same resource ID in region {0}, which is different from the input region {1}. Either specify the same region or delete the existing resource and try again."
$ArcCmdletsNotAvailableError = "Azure Arc integration isn't available for the version of Azure Stack HCI installed on node(s) {0} yet. Check the documentation for details. You may need to install an update or join the Preview channel."
$ArcRegistrationDisableInProgressError = "Unregister of Azure Arc integration is in progress. Try Unregister-AzStackHCI to finish unregistration and then try Register-AzStackHCI again."
$ArcIntegrationNotAvailableForCloudError = "Azure Arc integration is not available in {0}. Specify '-EnableAzureArcServer:`$false' in Register-AzStackHCI Cmdlet to register without Arc integration."

$FetchingRegistrationState = "Checking whether the cluster is already registered"
$ValidatingParametersFetchClusterName = "Validating cmdlet parameters"
$ValidatingParametersRegisteredInfo = "Validating the parameters and checking registration information"
$RegisterProgressActivityName = "Registering Azure Stack HCI with Azure..."
$UnregisterProgressActivityName = "Unregistering Azure Stack HCI from Azure..."
$InstallAzResourcesMessage = "Installing required PowerShell module: Az.Resources"
$InstallAzureADMessage = "Installing required PowerShell module: AzureAD"
$InstallRSATClusteringMessage = "Installing required Windows feature: RSAT-Clustering-PowerShell"
$LoggingInToAzureMessage = "Logging in to Azure"
$ConnectingToAzureAD = "Connecting to Azure Active Directory"
$RegisterAzureStackRPMessage = "Registering Microsoft.AzureStackHCI provider to Subscription"
$CreatingAADAppMessage = "Creating AAD application {0} in Azure AD directory {1}"
$CreatingResourceGroupMessage = "Creating Azure Resource Group {0}"
$CreatingCloudResourceMessage = "Creating Azure Resource {0} representing Azure Stack HCI by calling Microsoft.AzureStackHCI provider"
$GrantingAdminConsentMessage = "Trying to grant admin consent for the required permissions needed for Azure AD application identity {0}"
$GettingCertificateMessage = "Getting new certificate from on-premises cluster to use as application credential"
$AddAppCredentialMessage = "Adding certificate as application credential for the Azure AD application {0}"
$RegisterAndSyncMetadataMessage = "Registering Azure Stack HCI cluster and syncing cluster census information from the on-premises cluster to the cloud"
$UnregisterHCIUsageMessage = "Unregistering Azure Stack HCI cluster and cleaning up registration state on the on-premises cluster"
$DeletingAADApplicationMessage = "Deleting Azure AD application identity {0}"
$DeletingCloudResourceMessage = "Deleting Azure resource with ID {0} representing the Azure Stack HCI cluster"
$DeletingArcCloudResourceMessage = "Deleting Azure resource with ID {0} representing the Azure Stack HCI cluster Arc integration"
$DeletingExtensionMessage = "Deleting extension {0} on cluster {1}"
$DeletingCertificateFromAADApp = "Deleting certificate with KeyId {0} from Azure Active Directory"
$SkippingDeleteCertificateFromAADApp = "Certificate with KeyId {0} is still being used by Azure Active Directory and won't be deleted"
$RegisterArcMessage = "Arc for servers registration triggered"
$UnregisterArcMessage = "Arc for servers unregistration triggered"

$RegisterArcProgressActivityName = "Registering Azure Stack HCI with Azure Arc..."
$UnregisterArcProgressActivityName = "Unregistering Azure Stack HCI with Azure Arc..."
$RegisterArcRPMessage = "Registering Microsoft.HybridCompute and Microsoft.GuestConfiguration resource providers to subscription"
$SetupArcMessage = "Initializing Azure Stack HCI integration with Azure Arc"
$StartingArcAgentMessage = "Enabling Azure Arc integration on every clustered node"
$WaitingUnregisterMessage = "Disabling Azure Arc integration on every clustered node"
$CleanArcMessage = "Cleaning up Azure Arc integration"

$ArcAgentRolesInsufficientPreviligeMessage = "Failed to assign required roles for Azure Arc integration. Your Azure AD account must be an Owner or User Access Administrator in the subscription to enable Azure Arc integration."
$ArcRolesCleaningWarningMessage = "Couldn't clean up Azure AD application identity {0} used by Azure Arc integration. You can ignore this message or clean it up yourself through the Azure portal (optional)."
$RegisterArcFailedWarningMessage = "Some clustered nodes couldn't be Arc-enabled right now. This can happen if some of the nodes are down. We'll automatically try again in an hour. In the meantime, you can use Get-AzureStackHCIArcIntegration to check status on each node."
$UnregisterArcFailedError = "Couldn't disable Azure Arc integration on Node {0}. Try running Disable-AzureStackHCIArcIntegration Cmdlet on the node. If the node is in a state where Disable-AzureStackHCIArcIntegration Cmdlet could not be run, remove the node from the cluster and try Unregister-AzStackHCI Cmdlet again."
$ArcExtensionCleanupFailedError = "Couldn't delete Arc extension {0} on cluster nodes. You can try the extension uninstallation steps listed at https://docs.microsoft.com/en-us/azure/azure-arc/servers/manage-agent for removing the extension and try Unregister-AzStackHCI again. If the node is in a state where extension uninstallation could not succeed, try Unregister-AzStackHCI with -Force switch."
$ArcExtensionCleanupFailedWarning = "Couldn't delete Arc extension {0} on cluster nodes. Extension may continue to run even after unregistration."

#endregion

#region Constants

$UsageServiceFirstPartyAppId = "1322e676-dee7-41ee-a874-ac923822781c"
$MicrosoftTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"

$MSPortalDomain = "https://ms.portal.azure.com/"
$AzureCloudPortalDomain = "https://portal.azure.com/"
$AzureChinaCloudPortalDomain = "https://portal.azure.cn/"
$AzureUSGovernmentPortalDomain = "https://portal.azure.us/"
$AzureGermanCloudPortalDomain = "https://portal.microsoftazure.de/"
$AzurePPEPortalDomain = "https://df.onecloud.azure-test.net/"
$AzureCanaryPortalDomain = "https://portal.azure.com/"

$AzureCloud = "AzureCloud"
$AzureChinaCloud = "AzureChinaCloud"
$AzureUSGovernment = "AzureUSGovernment"
$AzureGermanCloud = "AzureGermanCloud"
$AzurePPE = "AzurePPE"
$AzureCanary = "AzureCanary"

$PortalCanarySuffix = '?feature.armendpointprefix={0}'
$PortalAADAppPermissionUrl = '#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/{0}/isMSAApp/'
$PortalHCIResourceUrl = '#@{0}/resource/subscriptions/{1}/resourceGroups/{2}/providers/Microsoft.AzureStackHCI/clusters/{3}/overview'

# GUID's of the scopes generated in first party portal
$ClusterReadPermission = "2344a320-6a09-4530-bed7-c90485b5e5e2"
$ClusterReadWritePermission = "493bd689-9082-40db-a506-11f40b68128f"
$ClusterNodeReadPermission = "8fa5445e-80fb-4c71-a3b1-9a16a81a1966"
$ClusterNodeReadWritePermission = "bbe8afc9-f3ba-4955-bb5f-1cfb6960b242"

# Deprecated scopes. Will be deleted during RepairRegistration
$BillingSyncPermission = "e4359fc6-82ee-4411-9a4d-edfc7812cf24"
$CensusSyncPermission = "8c83ab0a-0f96-40e9-940b-20cc5c5ecca9"

$PermissionIds = New-Object System.Collections.Generic.List[string]

$PermissionIds.Add($ClusterReadPermission)
$PermissionIds.Add($ClusterReadWritePermission)
$PermissionIds.Add($ClusterNodeReadPermission)
$PermissionIds.Add($ClusterNodeReadWritePermission)

$Region_EASTUSEUAP = 'eastus2euap'

[hashtable] $ServiceEndpointsAzureCloud = @{
        $Region_EASTUSEUAP = 'https://eus2euap-azurestackhci-usage.azurewebsites.net';
        }

$ServiceEndpointAzureCloudFrontDoor = "https://azurestackhci.azurefd.net"
$ServiceEndpointAzureCloud = $ServiceEndpointAzureCloudFrontDoor

$AuthorityAzureCloud = "https://login.microsoftonline.com"
$BillingServiceApiScopeAzureCloud = "https://azurestackhci-usage.trafficmanager.net/.default"
$GraphServiceApiScopeAzureCloud = "https://graph.microsoft.com/.default"

$ServiceEndpointAzurePPE = "https://azurestackhci-df.azurefd.net"
$AuthorityAzurePPE = "https://login.windows-ppe.net"
$BillingServiceApiScopeAzurePPE = "https://azurestackhci-usage-df.azurewebsites.net/.default"
$GraphServiceApiScopeAzurePPE = "https://graph.ppe.windows.net/.default"

$ServiceEndpointAzureChinaCloud = "https://dp.stackhci.azure.cn"
$AuthorityAzureChinaCloud = "https://login.partner.microsoftonline.cn"
$BillingServiceApiScopeAzureChinaCloud = "$UsageServiceFirstPartyAppId/.default"
$GraphServiceApiScopeAzureChinaCloud = "https://microsoftgraph.chinacloudapi.cn/.default"

$ServiceEndpointAzureUSGovernment = "https://dp.azurestackhci.azure.us"
$AuthorityAzureUSGovernment = "https://login.microsoftonline.us"
$BillingServiceApiScopeAzureUSGovernment = "https://dp.azurestackhci.azure.us/.default"
$GraphServiceApiScopeAzureUSGovernment = "https://graph.windows.net/.default"

$ServiceEndpointAzureGermanCloud = "https://azurestackhci-usage.trafficmanager.de"
$AuthorityAzureGermanCloud = "https://login.microsoftonline.de"
$BillingServiceApiScopeAzureGermanCloud = "https://azurestackhci-usage.azurewebsites.de/.default"
$GraphServiceApiScopeAzureGermanCloud = "https://graph.cloudapi.de/.default"

$RPAPIVersion = "2021-09-01";
$HCIArcAPIVersion = "2021-09-01"
$HCIArcInstanceName = "/arcSettings/default"
$HCIArcExtensions = "/Extensions"

$OutputPropertyResult = "Result"
$OutputPropertyResourceId = "AzureResourceId"
$OutputPropertyPortalResourceURL = "AzurePortalResourceURL"
$OutputPropertyPortalAADAppPermissionsURL = "AzurePortalAADAppPermissionsURL"
$OutputPropertyDetails = "Details"
$OutputPropertyTest = "Test"
$OutputPropertyEndpointTested = "EndpointTested"
$OutputPropertyIsRequired = "IsRequired"
$OutputPropertyFailedNodes = "FailedNodes"
$OutputPropertyErrorDetail = "ErrorDetail"

$ConnectionTestToAzureHCIServiceName = "Connect to Azure Stack HCI Service"

$ResourceGroupCreatedByName = "CreatedBy"
$ResourceGroupCreatedByValue = "4C02703C-F5D0-44B0-ADC3-4ED5C2839E61"

$HealthEndpointPath = "/health"


$MainProgressBarId = 1
$ArcProgressBarId = 2
$IndefinitelyYears = 300

$AzureConnectedMachineOnboardingRole = "Azure Connected Machine Onboarding"
$AzureConnectedMachineResourceAdministratorRole = "Azure Connected Machine Resource Administrator"
$ArcRegistrationTaskName = "ArcRegistrationTask"
$LogFileDir = '\Tasks\ArcForServers'

$ClusterScheduledTaskWaitTimeMinutes = 15
$ClusterScheduledTaskSleepTimeSeconds = 3
$ClusterScheduledTaskRunningState = "Running"
$ClusterScheduledTaskReadyState = "Ready"

$ArcSettingsDisableInProgressState = "DisableInProgress"

enum ArcStatus
{
    Unknown;
    Enabled;
    Disabled;
    DisableInProgress;
}

enum RegistrationStatus
{
    Registered;
    NotYet;
    OutOfPolicy;
}

enum CertificateManagedBy
{
    Invalid;
    User;
    Cluster;
}

$registerArcScript = {
    try
    {
        # Params for Enable-AzureStackHCIArcIntegration 
        $AgentInstaller_WebLink                  = 'https://aka.ms/AzureConnectedMachineAgent'
        $AgentInstaller_Name                     = 'AzureConnectedMachineAgent.msi'
        $AgentInstaller_LogFile                  = 'ConnectedMachineAgentInstallationLog.txt'
        $AgentExecutable_Path                    =  $Env:Programfiles + '\AzureConnectedMachineAgent\azcmagent.exe'

        $DebugPreference = 'Continue'

        # Setup Directory.
        $LogFileDir = $env:windir + '\Tasks\ArcForServers'
        if (-Not $(Test-Path $LogFileDir))
        {
            New-Item -Type Directory -Path $LogFileDir
        }

        # Delete log files older than 15 days
        Get-ChildItem -Path $LogFileDir -Recurse | Where-Object {($_.LastWriteTime -lt (Get-Date).AddDays(-15))} | Remove-Item

        # Setup Log file name.
        $date = Get-Date
        $datestring = '{0}{1:d2}{2:d2}' -f $date.year,$date.month,$date.day
        $LogFileName = $LogFileDir + '\RegisterArc_' + $datestring + '.log'
    
        Start-Transcript -LiteralPath $LogFileName -Append | Out-Null

        Write-Information 'Triggering Arc For Servers registration cmdlet'
        $arcStatus = Get-AzureStackHCIArcIntegration

        if ($arcStatus.ClusterArcStatus -eq 'Enabled')
        {
            $nodeStatus = $arcStatus.NodesArcStatus
    
            if ($nodeStatus.Keys -icontains ($env:computername))
            {
                if ($nodeStatus[$env:computername.ToLowerInvariant()] -ne 'Enabled')
                {
                    Write-Information 'Registering Arc for servers.'
                    Enable-AzureStackHCIArcIntegration -AgentInstallerWebLink $AgentInstaller_WebLink -AgentInstallerName $AgentInstaller_Name -AgentInstallerLogFile $AgentInstaller_LogFile -AgentExecutablePath $AgentExecutable_Path
                    Sync-AzureStackHCI
                }
                else
                {
                    Write-Information 'Node is already registered.'
                }
            }
            else
            {
                # New node added case.
                Write-Information 'Registering Arc for servers.'
                Enable-AzureStackHCIArcIntegration -AgentInstallerWebLink $AgentInstaller_WebLink -AgentInstallerName $AgentInstaller_Name -AgentInstallerLogFile $AgentInstaller_LogFile -AgentExecutablePath $AgentExecutable_Path
                Sync-AzureStackHCI
            }
        }
        else
        {
            Write-Information ('Cluster Arc status is not enabled. ClusterArcStatus:' + $arcStatus.ClusterArcStatus.ToString())
        }
    }
    catch
    {
        Write-Error -Exception $_.Exception -Category OperationStopped
        # Get script line number, offset and Command that resulted in exception. Write-Error with the exception above does not write this info.
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Error ('Exception occured in RegisterArcScript : ' + $positionMessage) -Category OperationStopped
    }
    finally
    {
        try{ Stop-Transcript } catch {}
    }
}

#endregion

function Setup-Logging{
param(
    [string] $LogFilePrefix
    )
    
    $date = Get-Date
    $datestring = "{0}{1:d2}{2:d2}-{3:d2}{4:d2}" -f $date.year,$date.month,$date.day,$date.hour,$date.minute
    $LogFileName = $LogFilePrefix + "_" + $datestring + ".log"

    Start-Transcript -LiteralPath $LogFileName -Append | out-null
}

function Show-LatestModuleVersion{
    
    $latestModule = Find-Module -Name Az.StackHCI -ErrorAction Ignore
    $installedModule = Get-Module -Name Az.StackHCI | Sort-Object  -Property Version -Descending | Select-Object -First 1

    if($Null -eq $latestModule)
    {
        $CouldNotGetLatestModuleInformationWarningMsg = $CouldNotGetLatestModuleInformationWarning -f $installedModule.Version.Major
        Write-Warning $CouldNotGetLatestModuleInformationWarningMsg
    }
    else
    {
        if($latestModule.Version.GetType() -eq [string])
        {
            $latestModuleVersion = [System.Version]::Parse($latestModule.Version)
        }
        else
        {
            $latestModuleVersion = $latestModule.Version
        }

        if(($latestModuleVersion.Major -eq $installedModule.Version.Major) -and ($latestModuleVersion -gt $installedModule.Version))
        {
            $InstallLatestVersionWarningMsg = $InstallLatestVersionWarning -f $installedModule.Version, $latestModuleVersion
            Write-Warning $InstallLatestVersionWarningMsg
        }
    }
}

function Retry-Command {
    param (
        [parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $ScriptBlock,
        [int]  $Attempts                   = 8,
        [int]  $MinWaitTimeInSeconds       = 5,
        [int]  $MaxWaitTimeInSeconds       = 60,
        [int]  $BaseBackoffTimeInSeconds   = 2,
        [bool] $RetryIfNullOutput          = $true
        )

    $attempt = 0
    $completed = $false
    $result = $null

    if($MaxWaitTimeInSeconds -lt $MinWaitTimeInSeconds)
    {
        throw "MaxWaitTimeInSeconds($MaxWaitTimeInSeconds) is less than MinWaitTimeInSeconds($MinWaitTimeInSeconds)"
    }

    while (-not $completed) {
        try
        {
            $attempt = $attempt + 1
            $result = Invoke-Command -ScriptBlock $ScriptBlock

            if($RetryIfNullOutput)
            {
                if($result -ne $null)
                {
                    Write-Verbose ("Command [{0}] succeeded. Non null result received." -f $ScriptBlock)
                    $completed = $true
                }
                else
                {
                    throw "Null result received."
                }
            }
            else
            {
                Write-Verbose ("Command [{0}] succeeded." -f $ScriptBlock)
                $completed = $true
            }
        }
        catch
        {
            $exception = $_.Exception

            if([int]$exception.ErrorCode -eq [int][system.net.httpstatuscode]::Forbidden)
            {
                Write-Verbose ("Command [{0}] failed Authorization. Attempt {1}. Exception: {2}" -f $ScriptBlock, $attempt,$exception.Message)
                throw
            }
            else
            {
                if ($attempt -ge $Attempts)
                {
                    Write-Verbose ("Command [{0}] failed the maximum number of {1} attempts. Exception: {2}" -f $ScriptBlock, $attempt,$exception.Message)
                    throw
                }
                else
                {
                    $secondsDelay = $MinWaitTimeInSeconds + [int]([Math]::Pow($BaseBackoffTimeInSeconds,($attempt-1)))

                    if($secondsDelay -gt $MaxWaitTimeInSeconds)
                    {
                        $secondsDelay = $MaxWaitTimeInSeconds
                    }

                    Write-Verbose ("Command [{0}] failed. Retrying in {1} seconds. Exception: {2}" -f $ScriptBlock, $secondsDelay,$exception.Message)
                    Start-Sleep $secondsDelay
                }
            }
        }
    }

    return $result
}

function Get-PortalDomain{
param(
    [string] $TenantId,
    [string] $EnvironmentName,
    [string] $Region
    )

    if($EnvironmentName -eq $AzureCloud -and $TenantId -eq $MicrosoftTenantId)
    {
        return $MSPortalDomain;
    }
    elseif($EnvironmentName -eq $AzureCloud)
    {
        return $AzureCloudPortalDomain;
    }
    elseif($EnvironmentName -eq $AzureChinaCloud)
    {
        return $AzureChinaCloudPortalDomain;
    }
    elseif($EnvironmentName -eq $AzureUSGovernment)
    {
        return $AzureUSGovernmentPortalDomain;
    }
    elseif($EnvironmentName -eq $AzureGermanCloud)
    {
        return $AzureGermanCloudPortalDomain;
    }
    elseif($EnvironmentName -eq $AzurePPE)
    {
        return $AzurePPEPortalDomain;
    }
    elseif($EnvironmentName -eq $AzureCanary)
    {
        $PortalCanarySuffixWithRegion = $PortalCanarySuffix -f $Region
        return ($AzureCanaryPortalDomain + $PortalCanarySuffixWithRegion);
    }
}

function Get-DefaultRegion{
param(
    [string] $EnvironmentName
    )

    $defaultRegion = "eastus";

    if($EnvironmentName -eq $AzureCloud)
    {
        $defaultRegion = "eastus"
    }
    elseif($EnvironmentName -eq $AzureChinaCloud)
    {
        $defaultRegion = "chinaeast2"
    }
    elseif($EnvironmentName -eq $AzureUSGovernment)
    {
        $defaultRegion = "usgovvirginia"
    }
    elseif($EnvironmentName -eq $AzureGermanCloud)
    {
        $defaultRegion = "germanynortheast"
    }
    elseif($EnvironmentName -eq $AzurePPE)
    {
        $defaultRegion = "westus"
    }
    elseif($EnvironmentName -eq $AzureCanary)
    {
        $defaultRegion = "eastus2euap"
    }

    return $defaultRegion
}

function Get-GraphAccessToken{
param(
    [string] $TenantId,
    [string] $EnvironmentName
    )

    # Below commands ensure there is graph access token in cache
    Get-AzADApplication -DisplayName SomeApp1 -ErrorAction Ignore | Out-Null

    $graphTokenItemResource = (Get-AzContext).Environment.GraphUrl

    $authFactory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.AuthenticationFactory
    $azContext = Get-AzContext
    $graphTokenItem = $authFactory.Authenticate($azContext.Account, $azContext.Environment, $azContext.Tenant.Id, $null, [Microsoft.Azure.Commands.Common.Authentication.ShowDialog]::Never, $null, $graphTokenItemResource)
    return $graphTokenItem.AccessToken
}

function Get-EnvironmentEndpoints{
param(
    [string] $EnvironmentName,
    [ref] $ServiceEndpoint,
    [ref] $Authority,
    [ref] $BillingServiceApiScope,
    [ref] $GraphServiceApiScope
    )

    if(($EnvironmentName -eq $AzureCloud) -or ($EnvironmentName -eq $AzureCanary))
    {
        $ServiceEndpoint.Value = $ServiceEndpointAzureCloud
        $Authority.Value = $AuthorityAzureCloud
        $BillingServiceApiScope.Value = $BillingServiceApiScopeAzureCloud
        $GraphServiceApiScope.Value = $GraphServiceApiScopeAzureCloud
    }
    elseif($EnvironmentName -eq $AzureChinaCloud)
    {
        $ServiceEndpoint.Value = $ServiceEndpointAzureChinaCloud
        $Authority.Value = $AuthorityAzureChinaCloud
        $BillingServiceApiScope.Value = $BillingServiceApiScopeAzureChinaCloud
        $GraphServiceApiScope.Value = $GraphServiceApiScopeAzureChinaCloud
    }
    elseif($EnvironmentName -eq $AzureUSGovernment)
    {
        $ServiceEndpoint.Value = $ServiceEndpointAzureUSGovernment
        $Authority.Value = $AuthorityAzureUSGovernment
        $BillingServiceApiScope.Value = $BillingServiceApiScopeAzureUSGovernment
        $GraphServiceApiScope.Value = $GraphServiceApiScopeAzureUSGovernment
    }
    elseif($EnvironmentName -eq $AzureGermanCloud)
    {
        $ServiceEndpoint.Value = $ServiceEndpointAzureGermanCloud
        $Authority.Value = $AuthorityAzureGermanCloud
        $BillingServiceApiScope.Value = $BillingServiceApiScopeAzureGermanCloud
        $GraphServiceApiScope.Value = $GraphServiceApiScopeAzureGermanCloud
    }
    elseif($EnvironmentName -eq $AzurePPE)
    {
        $ServiceEndpoint.Value = $ServiceEndpointAzurePPE
        $Authority.Value = $AuthorityAzurePPE
        $BillingServiceApiScope.Value = $BillingServiceApiScopeAzurePPE
        $GraphServiceApiScope.Value = $GraphServiceApiScopeAzurePPE
    }
}

function Get-PortalAppPermissionsPageUrl{
param(
    [string] $AppId,
    [string] $TenantId,
    [string] $EnvironmentName,
    [string] $Region
    )

    $portalBaseUrl = Get-PortalDomain -TenantId $TenantId -EnvironmentName $EnvironmentName -Region $Region
    $portalAADAppRelativeUrl = $PortalAADAppPermissionUrl -f $AppId
    return $portalBaseUrl + $portalAADAppRelativeUrl
}

function Get-PortalHCIResourcePageUrl{
param(
    [string] $TenantId,
    [string] $EnvironmentName,
    [string] $SubscriptionId,
    [string] $ResourceGroupName,
    [string] $ResourceName,
    [string] $Region
    )

    $portalBaseUrl = Get-PortalDomain -TenantId $TenantId -EnvironmentName $EnvironmentName -Region $Region
    $portalHCIResourceRelativeUrl = $PortalHCIResourceUrl -f $TenantId, $SubscriptionId, $ResourceGroupName, $ResourceName
    return $portalBaseUrl + $portalHCIResourceRelativeUrl
}

function Get-ResourceId{
param(
    [string] $ResourceName,
    [string] $SubscriptionId,
    [string] $ResourceGroupName
    )

    return "/Subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.AzureStackHCI/clusters/" + $ResourceName
}

function Get-RequiredResourceAccess{
    $requiredResourcesAccess = New-Object System.Collections.Generic.List[Microsoft.Open.AzureAD.Model.RequiredResourceAccess] 

    $requiredAccess = New-Object Microsoft.Open.AzureAD.Model.RequiredResourceAccess
    $requiredAccess.ResourceAppId = $UsageServiceFirstPartyAppId
    $requiredAccess.ResourceAccess = New-Object System.Collections.Generic.List[Microsoft.Open.AzureAD.Model.ResourceAccess]

    Foreach ($permId in $PermissionIds)
    {
        $permAccess = New-Object Microsoft.Open.AzureAD.Model.ResourceAccess
        $permAccess.Type = "Role"
        $permAccess.Id = $permId 
        $requiredAccess.ResourceAccess.Add($permAccess)
    }

    $requiredResourcesAccess.Add($requiredAccess)
    return $requiredResourcesAccess
}

# Called during repair registration.
function AddRequiredPermissionsIfNotPresent{
param(
    [string] $AppId
    )

    Write-Verbose "Adding the required permissions to AAD Application $AppId if not already added"
    $app = Retry-Command -ScriptBlock { Get-AzureADApplication -Filter "AppId eq '$AppId'"}
    $shouldAddRequiredPerms = $false

    if($app.RequiredResourceAccess -eq $Null)
    {
        $shouldAddRequiredPerms = $true
    }
    else
    {
        $reqResourceAccess = $app.RequiredResourceAccess | Where-Object {$_.ResourceAppId -eq $UsageServiceFirstPartyAppId}

        if($reqResourceAccess -eq $Null)
        {
            $shouldAddRequiredPerms = $true
        }
        else
        {
            if ($reqResourceAccess.ResourceAccess -eq $Null)
            {
                $shouldAddRequiredPerms = $true
            }
            else
            {
                $spReqPermClusRW = $reqResourceAccess.ResourceAccess | Where-Object {$_.Id -eq $ClusterReadWritePermission}
                $spReqPermClusR = $reqResourceAccess.ResourceAccess | Where-Object {$_.Id -eq $ClusterReadPermission}
                $spReqPermClusNodeRW = $reqResourceAccess.ResourceAccess | Where-Object {$_.Id -eq $ClusterNodeReadWritePermission}
                $spReqPermClusNodeR = $reqResourceAccess.ResourceAccess | Where-Object {$_.Id -eq $ClusterNodeReadPermission}

                # If App has these permissions, we have already added the required permissions earlier. Not need to add again.
                if(($spReqPermClusRW -ne $Null) -and ($spReqPermClusR -ne $Null) -and ($spReqPermClusNodeRW -ne $Null) -and ($spReqPermClusNodeR -ne $Null))
                {
                    $shouldAddRequiredPerms = $false
                }
                else
                {
                    $shouldAddRequiredPerms = $true
                }
            }
        }
    }

    # Add the required permissions
    if($shouldAddRequiredPerms -eq $true)
    {
        $requiredResourcesAccess = Get-RequiredResourceAccess
        Retry-Command -ScriptBlock { Set-AzureADApplication -ObjectId $app.ObjectId -RequiredResourceAccess $requiredResourcesAccess | Out-Null} -RetryIfNullOutput $false
    }
}

function Check-UsageAppRoles{
param(
    [string] $AppId
    )

    Write-Verbose "Checking admin consent status for AAD Application $AppId"

    $appSP = Retry-Command -ScriptBlock { Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"}

    # Try Get-AzureADServiceAppRoleAssignment as well to get app role assignments. WAC token falls under this case.
    $assignedPerms = Retry-Command -ScriptBlock { @(Get-AzureADServiceAppRoleAssignedTo -ObjectId $appSP.ObjectId) + @(Get-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId)} -RetryIfNullOutput $false

    $clusterRead = $assignedPerms | where { ($_.Id -eq $ClusterReadPermission) }
    $clusterReadWrite = $assignedPerms | where { ($_.Id -eq $ClusterReadWritePermission) }
    $clusterNodeRead = $assignedPerms | where { ($_.Id -eq $ClusterNodeReadPermission) }
    $clusterNodeReadWrite = $assignedPerms | where { ($_.Id -eq $ClusterNodeReadWritePermission) }

    $assignedPermsList = New-Object System.Collections.Generic.List[Microsoft.Open.AzureAD.Model.DirectoryObject]
    $assignedPermsList.Add($clusterRead)
    $assignedPermsList.Add($clusterReadWrite)
    $assignedPermsList.Add($clusterNodeRead)
    $assignedPermsList.Add($clusterNodeReadWrite)

    Foreach ($perm in $assignedPermsList)
    {
        if($perm -eq $null)
        {
            return $false
        }

        if($perm.DeletionTimestamp -ne $Null -and ($perm.DeletionTimestamp -gt $perm.CreationTimestamp))
        {
            return $false
        }
    }

    return $true
}

function Create-Application{
param(
    [string] $AppName
    )

    Write-Verbose "Creating AAD Application $AppName"
    # If the subscription is just registered to have HCI resources, sometimes it may take a while for the billing service principal to propogate

    $usagesp = Retry-Command -ScriptBlock { Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"}

    $requiredResourcesAccess = Get-RequiredResourceAccess

    # Create application
    $app = Retry-Command -ScriptBlock { New-AzureADApplication -DisplayName $AppName -RequiredResourceAccess $requiredResourcesAccess }
    $sp = Retry-Command -ScriptBlock { New-AzureADServicePrincipal -AppId $app.AppId }

    Write-Verbose "Created new AAD Application $app.AppId"

    return $app.AppId
}

function Grant-AdminConsent{
param(
    [string] $AppId
    )

    Write-Verbose "Granting admin consent for AAD Application Id $AppId"
    $usagesp = Retry-Command -ScriptBlock { Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"}
    $appSP = Retry-Command -ScriptBlock { Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"}

    try 
    {
        Retry-Command -ScriptBlock { New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterReadPermission} -RetryIfNullOutput $false
        Retry-Command -ScriptBlock { New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterReadWritePermission} -RetryIfNullOutput $false
        Retry-Command -ScriptBlock { New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterNodeReadPermission} -RetryIfNullOutput $false
        Retry-Command -ScriptBlock { New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterNodeReadWritePermission} -RetryIfNullOutput $false
    }
    catch 
    {
        Write-Debug "Exception occured when granting admin consent"
        $ErrorMessage = $_.Exception.Message
        Write-Debug $ErrorMessage
        return $False
    }

    return $True
}

function Remove-OldScopes{
param(
    [string] $AppId
    )

    Write-Verbose "Removing old scopes on AAD Application with Id $AppId"
    $appSP = Retry-Command -ScriptBlock { Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"}

    # Remove AzureStackHCI.Billing.Sync and AzureStackHCI.Census.Sync permissions if present as we dont need them
    $assignedPerms = Retry-Command -ScriptBlock { Get-AzureADServiceAppRoleAssignedTo -ObjectId $appSP.ObjectId} -RetryIfNullOutput $false

    $billingSync = $assignedPerms | where { ($_.Id -eq $BillingSyncPermission) }
    $censusSync = $assignedPerms | where { ($_.Id -eq $CensusSyncPermission) }

    if($billingSync -eq $Null -or $censusSync -eq $Null)
    {
        # Try Get-AzureADServiceAppRoleAssignment as well to get app role assignments. WAC token falls under this case.
        $assignedPerms = Retry-Command -ScriptBlock { Get-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId} -RetryIfNullOutput $false
    }

    if($billingSync -eq $Null)
    {
        $billingSync = $assignedPerms | where { ($_.Id -eq $BillingSyncPermission) }
    }

    if($censusSync -eq $Null)
    {
        $censusSync = $assignedPerms | where { ($_.Id -eq $CensusSyncPermission) }
    }

    if($billingSync -ne $Null)
    {
        Retry-Command -ScriptBlock { Remove-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -AppRoleAssignmentId $billingSync.ObjectId | Out-Null} -RetryIfNullOutput $false
    }

    if($censusSync -ne $Null)
    {
        Retry-Command -ScriptBlock { Remove-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -AppRoleAssignmentId $censusSync.ObjectId | Out-Null} -RetryIfNullOutput $false
    }
}

function Azure-Login{
param(
    [string] $SubscriptionId,
    [string] $TenantId,
    [string] $ArmAccessToken,
    [string] $GraphAccessToken,
    [string] $AccountId,
    [string] $EnvironmentName,
    [string] $ProgressActivityName,
    [string] $Region,
    [bool]   $UseDeviceAuthentication
    )

    Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -status $InstallAzResourcesMessage -percentcomplete 10

    try
    {
        Import-Module -Name Az.Resources -ErrorAction Stop
    }
    catch
    {
        try
        {
            Import-PackageProvider -Name Nuget -MinimumVersion "2.8.5.201" -ErrorAction Stop
        }
        catch
        {
            Install-PackageProvider NuGet -Force | Out-Null
        }

        Install-Module -Name Az.Resources -Force -AllowClobber
        Import-Module -Name Az.Resources
    }

    Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -status $InstallAzureADMessage -percentcomplete 20

    try
    {
        Import-Module -Name AzureAD -ErrorAction Stop
    }
    catch
    {
        Install-Module -Name AzureAD -Force -AllowClobber
        Import-Module -Name AzureAD
    }

    Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -status $LoggingInToAzureMessage -percentcomplete 30

    if($EnvironmentName -eq $AzurePPE)
    {
        Add-AzEnvironment -Name $AzurePPE -PublishSettingsFileUrl "https://windows.azure-test.net/publishsettings/index" -ServiceEndpoint "https://management-preview.core.windows-int.net/" -ManagementPortalUrl "https://windows.azure-test.net/" -ActiveDirectoryEndpoint "https://login.windows-ppe.net/" -ActiveDirectoryServiceEndpointResourceId "https://management.core.windows.net/" -ResourceManagerEndpoint "https://api-dogfood.resources.windows-int.net/" -GalleryEndpoint "https://df.gallery.azure-test.net/" -GraphEndpoint "https://graph.ppe.windows.net/" -GraphAudience "https://graph.ppe.windows.net/" | Out-Null
    }

    $ConnectAzureADEnvironmentName = $EnvironmentName
    $ConnectAzAccountEnvironmentName = $EnvironmentName

    if($EnvironmentName -eq $AzureCanary)
    {
        $ConnectAzureADEnvironmentName = $AzureCloud

        if([string]::IsNullOrEmpty($Region))
        {
            $Region = Get-DefaultRegion -EnvironmentName $EnvironmentName
        }

        # Normalize region name
        $Region = Normalize-RegionName -Region $Region

        $ConnectAzAccountEnvironmentName = ($AzureCanary + $Region)

        $azEnv = (Get-AzEnvironment -Name $AzureCloud)
        $azEnv.Name = $ConnectAzAccountEnvironmentName
        $azEnv.ResourceManagerUrl = ('https://{0}.management.azure.com/' -f $Region)
        $azEnv | Add-AzEnvironment | Out-Null
    }

    Disconnect-AzAccount -ErrorAction Ignore | Out-Null

    if([string]::IsNullOrEmpty($ArmAccessToken) -or [string]::IsNullOrEmpty($GraphAccessToken) -or [string]::IsNullOrEmpty($AccountId))
    {
        # Interactive login

        $IsIEPresent = Test-Path "$env:SystemRoot\System32\ieframe.dll"

        if([string]::IsNullOrEmpty($TenantId))
        {
            if(($UseDeviceAuthentication -eq $false) -and ($IsIEPresent))
            {
                Connect-AzAccount -Environment $ConnectAzAccountEnvironmentName -SubscriptionId $SubscriptionId -Scope Process | Out-Null
            }
            else # Use -UseDeviceAuthentication as IE Frame is not available to show Azure login popup
            {
                Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -Completed # Hide progress activity as it blocks the console output
                Connect-AzAccount -Environment $ConnectAzAccountEnvironmentName -SubscriptionId $SubscriptionId -UseDeviceAuthentication -Scope Process | Out-Null
            }
        }
        else
        {
            if(($UseDeviceAuthentication -eq $false) -and ($IsIEPresent))
            {
                Connect-AzAccount -Environment $ConnectAzAccountEnvironmentName -TenantId $TenantId -SubscriptionId $SubscriptionId -Scope Process | Out-Null
            }
            else # Use -UseDeviceAuthentication as IE Frame is not available to show Azure login popup
            {
                Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -Completed # Hide progress activity as it blocks the console output
                Connect-AzAccount -Environment $ConnectAzAccountEnvironmentName -TenantId $TenantId -SubscriptionId $SubscriptionId -UseDeviceAuthentication -Scope Process | Out-Null
            }
        }

        Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -status $ConnectingToAzureAD -percentcomplete 35

        $azContext = Get-AzContext
        $TenantId = $azContext.Tenant.Id
        $AccountId = $azContext.Account.Id
        $GraphAccessToken = Get-GraphAccessToken -TenantId $TenantId -EnvironmentName $EnvironmentName

        Connect-AzureAD -AzureEnvironmentName $ConnectAzureADEnvironmentName -TenantId $TenantId -AadAccessToken $GraphAccessToken -AccountId $AccountId | Out-Null
    }
    else
    {
        # Not an interactive login

        if([string]::IsNullOrEmpty($TenantId))
        {
            Connect-AzAccount -Environment $ConnectAzAccountEnvironmentName -SubscriptionId $SubscriptionId -AccessToken $ArmAccessToken -AccountId $AccountId -GraphAccessToken $GraphAccessToken -Scope Process | Out-Null
        }
        else
        {
            Connect-AzAccount -Environment $ConnectAzAccountEnvironmentName -TenantId $TenantId -SubscriptionId $SubscriptionId -AccessToken $ArmAccessToken -AccountId $AccountId -GraphAccessToken $GraphAccessToken -Scope Process | Out-Null
        }

        Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -status $ConnectingToAzureAD -percentcomplete 35

        $azContext = Get-AzContext
        $TenantId = $azContext.Tenant.Id
        Connect-AzureAD -AzureEnvironmentName $ConnectAzureADEnvironmentName -TenantId $TenantId -AadAccessToken $GraphAccessToken -AccountId $AccountId | Out-Null
    }

    return $TenantId
}

function Normalize-RegionName{
param(
    [string] $Region
    )
    $regionName = $Region -replace '\s',''
    $regionName = $regionName.ToLower()
    return $regionName
}

function Validate-RegionName{
param(
    [string] $Region,
    [ref] $SupportedRegions
    )
    $resources = Retry-Command -ScriptBlock { Get-AzResourceProvider -ProviderNamespace Microsoft.AzureStackHCI } -RetryIfNullOutput $true
    $locations = $resources.Where{($_.ResourceTypes.ResourceTypeName -eq 'clusters' -and $_.RegistrationState -eq 'Registered')}.Locations

    $locations | foreach {
        $regionName = Normalize-RegionName -Region $_
        if ($regionName -eq $Region)
        {
            # Supported region

            return $True
        }
    }

    $SupportedRegions.value = $locations -join ','
    return $False
}

function Get-ClusterDNSSuffix{
param(
    [System.Management.Automation.Runspaces.PSSession] $Session
    )

    $clusterNameResourceGUID = Invoke-Command -Session $Session -ScriptBlock { (Get-ItemProperty -Path HKLM:\Cluster -Name ClusterNameResource).ClusterNameResource }
    $clusterDNSSuffix = Invoke-Command -Session $Session -ScriptBlock { (Get-ClusterResource $using:clusterNameResourceGUID | Get-ClusterParameter DnsSuffix).Value }
    return $clusterDNSSuffix
}

function Get-ClusterDNSName{
param(
    [System.Management.Automation.Runspaces.PSSession] $Session
    )

    $clusterNameResourceGUID = Invoke-Command -Session $Session -ScriptBlock { (Get-ItemProperty -Path HKLM:\Cluster -Name ClusterNameResource).ClusterNameResource }
    $clusterDNSName = Invoke-Command -Session $Session -ScriptBlock { (Get-ClusterResource $using:clusterNameResourceGUID | Get-ClusterParameter DnsName).Value }
    return $clusterDNSName
}

function Check-ConnectionToCloudBillingService{
param(
    $ClusterNodes,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $HealthEndpoint,
    [System.Collections.ArrayList] $HealthEndPointCheckFailedNodes,
    [string] $ClusterDNSSuffix
    )

    Foreach ($clusNode in $ClusterNodes)
    {
        $nodeSession = $null

        try
        {
            if($Credential -eq $Null)
            {
                $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $ClusterDNSSuffix)
            }
            else
            {
                $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $ClusterDNSSuffix) -Credential $Credential
            }

            # Check if node can reach cloud billing service
            $healthResponse = Invoke-Command -Session $nodeSession -ScriptBlock { Invoke-WebRequest $Using:HealthEndpoint -UseBasicParsing}

            if(($healthResponse -eq $Null) -or ($healthResponse.StatusCode -ne [int][system.net.httpstatuscode]::ok))
            {
                Write-Verbose ("StatusCode of invoking cloud billing service health endpoint on node " + $clusNode.Name + " : " + $healthResponse.StatusCode)
                $HealthEndPointCheckFailedNodes.Add($clusNode.Name) | Out-Null
                continue
            }
        }
        catch
        {
            Write-Verbose ("Exception occured while testing health endpoint connectivity on Node: " + $clusNode.Name + " Exception: " + $_.Exception)
            $HealthEndPointCheckFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }
    }
}

function Setup-Certificates{
param(
    $ClusterNodes,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $ResourceName,
    [string] $ObjectId,
    [string] $CertificateThumbprint,
    [string] $AppId,
    [string] $TenantId,
    [string] $CloudId,
    [string] $ServiceEndpoint,
    [string] $BillingServiceApiScope,
    [string] $GraphServiceApiScope,
    [string] $Authority,
    [System.Collections.ArrayList] $NewCertificateFailedNodes,
    [System.Collections.ArrayList] $SetCertificateFailedNodes,
    [System.Collections.ArrayList] $OSNotLatestOnNodes,
    [System.Collections.HashTable] $CertificatesToBeMaintained,
    [string] $ClusterDNSSuffix
    )

    $userProvidedCertAddedToAAD = $false
    Foreach ($clusNode in $ClusterNodes)
    {
        $nodeSession = $null

        try
        {
            if($Credential -eq $Null)
            {
                $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $ClusterDNSSuffix)
            }
            else
            {
                $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $ClusterDNSSuffix) -Credential $Credential
            }
        }
        catch
        {
            Write-Debug ("Exception occured in establishing new PSSession. ErrorMessage : " + $_.Exception.Message)
            Write-Debug $_
            $NewCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            $SetCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }

        # Check if all nodes have required OS version
        $nodeUBR = Invoke-Command -Session $nodeSession -ScriptBlock { (Get-ItemProperty -path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion").UBR }
        $nodeBuildNumber = Invoke-Command -Session $nodeSession -ScriptBlock { (Get-CimInstance -ClassName CIM_OperatingSystem).BuildNumber }

        if(($nodeBuildNumber -lt $GAOSBuildNumber) -or (($nodeBuildNumber -eq $GAOSBuildNumber) -and ($nodeUBR -lt $GAOSUBR)))
        {
            $OSNotLatestOnNodes.Add($clusNode.Name) | Out-Null
            continue
        }

        if([string]::IsNullOrEmpty($CertificateThumbprint))
        {
            # User did not specify certificate, using self-signed certificate
            try
            {
                $certBase64 = Invoke-Command -Session $nodeSession -ScriptBlock { New-AzureStackHCIRegistrationCertificate }
            }
            catch
            {
                Write-Debug ("Exception occured in New-AzureStackHCIRegistrationCertificate. ErrorMessage : " + $_.Exception.Message)
                Write-Debug $_
                $NewCertificateFailedNodes.Add($clusNode.Name) | Out-Null
                continue
            }
        }
        else
        {
            # Get certificate from cert store.
            $x509Cert = $Null;
            try
            {
                $x509Cert = Invoke-Command -Session $nodeSession -ScriptBlock { Get-ChildItem Cert:\LocalMachine -Recurse | Where { $_.Thumbprint -eq $Using:CertificateThumbprint} | Select-Object -First 1}
            }
            catch{}

            # Certificate not found on node
            if($x509Cert -eq $Null)
            {
                $CertificateNotFoundErrorMessage = $CertificateNotFoundOnNode -f $CertificateThumbprint,$clusNode.Name
                return $CertificateNotFoundErrorMessage
            }

            # Certificate should be valid for atleast 60 days from now
            $60days = New-TimeSpan -Days 60
            $expectedValidTo = (Get-Date) + $60days

            if($x509Cert.NotAfter -lt $expectedValidTo)
            {
                $UserCertificateValidationErrorMessage = ($UserCertValidationErrorMessage -f $CertificateThumbprint, $x509Cert.NotAfter)
                return $UserCertificateValidationErrorMessage
            }

            $certBase64 = [System.Convert]::ToBase64String($x509Cert.Export([Security.Cryptography.X509Certificates.X509ContentType]::Cert))
        }

        $Cert = [System.Security.Cryptography.X509Certificates.X509Certificate2]([System.Convert]::FromBase64String($CertBase64))

        # If user provided cert is not already added to AAD app or if we are using one certificate per node
        if(($userProvidedCertAddedToAAD -eq $false) -or ([string]::IsNullOrEmpty($CertificateThumbprint)))
        {
            $AddAppCredentialMessageProgress = $AddAppCredentialMessage -f $ResourceName
            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $AddAppCredentialMessageProgress -percentcomplete 80
            $now = [System.DateTime]::UtcNow
            $appCredential = Retry-Command -ScriptBlock { New-AzureADApplicationKeyCredential -ObjectId $ObjectId -Type AsymmetricX509Cert -Usage Verify -Value $CertBase64 -StartDate $now -EndDate $Cert.NotAfter}
            $CertificatesToBeMaintained.Add($appCredential.KeyId, $true)
            $userProvidedCertAddedToAAD = $true

            # Wait till the credential added is returned in Get to avoid the rush in using this new certificate. Gives more time for AAD replication before using certificate.
            $credReturned = Retry-Command -ScriptBlock { Get-AzureADApplicationKeyCredential -ObjectId $ObjectId | where {($_.KeyId -eq $appCredential.KeyId)} }
        }

        # Set the certificate - Certificate will be set after testing the certificate by calling cloud service API
        try
        {
            $SetCertParams = @{
                        ServiceEndpoint = $ServiceEndpoint
                        BillingServiceApiScope = $BillingServiceApiScope
                        GraphServiceApiScope = $GraphServiceApiScope
                        AADAuthority = $Authority
                        AppId = $AppId
                        TenantId = $TenantId
                        CloudId = $CloudId
                        CertificateThumbprint = $CertificateThumbprint
                    }

            Invoke-Command -Session $nodeSession -ScriptBlock { Set-AzureStackHCIRegistrationCertificate @Using:SetCertParams }
        }
        catch
        {
            Write-Debug ("Exception occured in Set-AzureStackHCIRegistrationCertificate. ErrorMessage : " + $_.Exception.Message)
            Write-Debug $_
            $SetCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }
    }

    return $null
}

function Create-ArcApplication{
param(
    [string] $AppName,
    [ref] $AppId,
    [ref] $Secret,
    [Switch] $IsWAC
    )
    Write-Verbose "Creating AAD Arc Agent Application $AppName"

    # Create application and service principal for Arc agent app.
    $app = Retry-Command -ScriptBlock { New-AzureADApplication -DisplayName $AppName }
    $sp = Retry-Command -ScriptBlock { New-AzureADServicePrincipal -AppId $app.AppId }

    # Usually takes 10-20 seconds after app creation to be able to assign roles. Can take upto 140 seconds for AAD to replicate in rare cases.
    $stopLoop = $false
    [int]$retryCount = "0"
    [int]$maxRetryCount = "14"

    do {
        try 
        {
            New-AzRoleAssignment -ObjectId $sp.ObjectId -RoleDefinitionName $AzureConnectedMachineOnboardingRole | Out-Null
            New-AzRoleAssignment -ObjectId $sp.ObjectId -RoleDefinitionName $AzureConnectedMachineResourceAdministratorRole | Out-Null
            $stopLoop = $true
            break
        }
        catch
        {
            $positionMessage = $_.InvocationInfo.PositionMessage

            if ($retryCount -ge $maxRetryCount)
            {
                # Cleanup
                Remove-AzureADApplication -ObjectId $app.ObjectId

                # Timed out.
                Write-Debug ("Failed to assign roles to service principal with App Id $($app.AppId). ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage)
                throw $_
            }

            if ($_.Exception.Message.Contains("Microsoft.Authorization/roleAssignments/write"))
            {
                # Cleanup
                Remove-AzureADApplication -ObjectId $app.ObjectId

                Write-Verbose "Create-ArcApplication Missing Permissions. IsWAC: $IsWAC"

                if($IsWAC -eq $false)
                {
                    # Insufficient privilige error.
                    Write-Error -Message $ArcAgentRolesInsufficientPreviligeMessage -ErrorAction Continue
                }

                return $false
            }
            
            # Service principal creation hasn't propogated fully yet, usually takes 10-20 seconds.
            Write-Verbose "Could not assign roles to service principal with App Id $($app.AppId). Retrying in 10 seconds..."
            Start-Sleep -Seconds 10
            $retryCount = $retryCount + 1
        }
    }
    While (-Not $stopLoop)

    # Set password to never expire.
    $start = Get-Date
    $end = $start.AddYears($IndefinitelyYears)
    $pw = Retry-Command -ScriptBlock { New-AzureADServicePrincipalPasswordCredential -ObjectId $sp.ObjectId -StartDate $start -EndDate $end }

    Write-Verbose "Created new AAD Arc Agent Application $($app.AppId)"
    $AppId.Value = $app.AppId
    $Secret.Value = $pw.Value
    return $true
}

function Remove-ArcApplication{
    param(
        [string] $AppId
        )
    
        $app = Get-AzureADApplication -Filter "AppId eq '$AppId'"
        $sp = Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"
        
        # Remove assigned roles.
        try
        {
            $roles = Get-AzRoleAssignment -ObjectId $sp.ObjectId
            
            $roles | ForEach-Object { 
                $roleName = $_.RoleDefinitionName
                if (($roleName -eq $AzureConnectedMachineOnboardingRole) -or ($roleName -eq $AzureConnectedMachineResourceAdministratorRole))
                {
                    Remove-AzRoleAssignment -ObjectId $sp.ObjectId -RoleDefinitionName $roleName | Out-Null
                }
            }
        }
        catch
        {
            Write-Warning -Message $ArcRolesCleaningWarningMessage
            Write-Debug ("Exception occured in clearing roles on service principal with App Id {0}. ErrorMessage : {1}" -f ($AppId), ($_.Exception.Message))
            Write-Debug $_
        }

        # Delete application.
        Remove-AzureADApplication -ObjectId $app.ObjectId
}

function Enable-ArcForServers{
param(
    [System.Management.Automation.Runspaces.PSSession] $Session,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $ClusterDNSSuffix
    )
    # Create new sessions for all nodes in cluster.
    $clusterNodeNames = Invoke-Command -Session $Session -ScriptBlock { Get-ClusterNode } | ForEach-Object { ($_.Name + "." + $ClusterDNSSuffix) }
    if($Credential -eq $Null)
    {
        $clusterNodeSessions = New-PSSession -ComputerName $clusterNodeNames
    }
    else
    {
        $clusterNodeSessions = New-PSSession -ComputerName $clusterNodeNames -Credential $Credential
    }

    $retStatus = [ErrorDetail]::Success

    # Start running
    try
    {
        Invoke-Command -Session $clusterNodeSessions -ScriptBlock {
            # Cluster scheduled task is triggered asynchronously. Use Get-ScheduledTask to get the task state and wait for its completion.
            Get-ScheduledTask -TaskName $using:ArcRegistrationTaskName | Start-ScheduledTask

            Start-Sleep -Seconds $using:ClusterScheduledTaskSleepTimeSeconds
            $limit = (Get-Date).AddMinutes($using:ClusterScheduledTaskWaitTimeMinutes)

            while ((Get-ScheduledTask -TaskName $using:ArcRegistrationTaskName).State -eq $using:ClusterScheduledTaskRunningState -and (Get-Date) -lt $limit) {
                Start-Sleep -Seconds $using:ClusterScheduledTaskSleepTimeSeconds
            }

            if((Get-ScheduledTask -TaskName $using:ArcRegistrationTaskName).State -ne $using:ClusterScheduledTaskReadyState)
            {
                throw ("Cluster scheduled task runtime exceeded the max configured wait time of {0} minutes" -f ($using:ClusterScheduledTaskWaitTimeMinutes))
            }
        }

        # Show warning if any of the nodes failed to register with Arc
        $enabledArcStatus = [ArcStatus]::Enabled
        Invoke-Command -Session $Session -ScriptBlock {
            $nodeStatus = $(Get-AzureStackHCIArcIntegration).NodesArcStatus

            if ($nodeStatus -ne $null -and $nodeStatus.Count -ge $clusterNodeNames.Count)
            {
                Foreach ($node in $nodeStatus.Keys)
                {
                    if($nodeStatus[$node] -ne $using:enabledArcStatus)
                    {
                        Write-Warning -Message $using:RegisterArcFailedWarningMessage
                        $retStatus = [ErrorDetail]::ArcIntegrationFailedOnNodes
                        break
                    }
                }
            }
            else
            {
                Write-Warning -Message $using:RegisterArcFailedWarningMessage
                $retStatus = [ErrorDetail]::ArcIntegrationFailedOnNodes
            }
        }
    }
    catch
    {
        Write-Warning -Message $RegisterArcFailedWarningMessage
        $retStatus = [ErrorDetail]::ArcIntegrationFailedOnNodes
        Write-Debug ("Exception occured in registering nodes to Arc For Servers. ErrorMessage : {0}" -f ($_.Exception.Message))
        Write-Debug $_
    }

    # Cleanup sessions.
    Remove-PSSession $clusterNodeSessions | Out-Null

    return $retStatus
}

function Disable-ArcForServers{
param(
    [System.Management.Automation.Runspaces.PSSession] $Session,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $ClusterDNSSuffix
    )

    $res = $true
    $AgentUninstaller_LogFile = "ConnectedMachineAgentUninstallationLog.txt";
    $AgentInstaller_Name      = "AzureConnectedMachineAgent.msi";
    $AgentExecutable_Path     = $Env:Programfiles + '\AzureConnectedMachineAgent\azcmagent.exe'

    $clusterNodeNames = Invoke-Command -Session $Session -ScriptBlock { Get-ClusterNode } | ForEach-Object { ($_.Name + "." + $ClusterDNSSuffix) }
    if($Credential -eq $Null)
    {
        $clusterNodeSessions = New-PSSession -ComputerName $clusterNodeNames
    }
    else
    {
        $clusterNodeSessions = New-PSSession -ComputerName $clusterNodeNames -Credential $Credential
    }

    $nodeArcStatus = Invoke-Command -Session $Session -ScriptBlock { (Get-AzureStackHCIArcIntegration)}
    if($nodeArcStatus.ClusterArcStatus -eq [ArcStatus]::Disabled)
    {
        return $res
    }

    $disableFailedOnANode = $false

    try
    {
        Invoke-Command -Session $clusterNodeSessions -ScriptBlock {
            Disable-AzureStackHCIArcIntegration -AgentUninstallerLogFile $using:AgentUninstaller_LogFile -AgentInstallerName $using:AgentInstaller_Name -AgentExecutablePath $using:AgentExecutable_Path
        }
    }
    catch
    {
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Debug ("Exception occured in un-registering nodes from Arc For Servers. ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage)
        Write-Debug $_
        $disableFailedOnANode = $true
    }

    if ($disableFailedOnANode -eq $true)
    {
        $nodeStatus = Invoke-Command -Session $Session -ScriptBlock { $(Get-AzureStackHCIArcIntegration).NodesArcStatus }
        foreach ($node in $nodeStatus.Keys)
        {
            if ($nodeStatus[$node] -ne [ArcStatus]::Disabled)
            {
                $res = $false
                $UnregisterArcFailedErrorMessage = $UnregisterArcFailedError -f $node
                Write-Error -Message $UnregisterArcFailedErrorMessage -ErrorAction Continue
            }
        }
    }

    # Cleanup sessions.
    Remove-PSSession $clusterNodeSessions | Out-Null
    return $res
}

function Register-ArcForServers{
param(
    [bool] $IsManagementNode,
    [string] $ComputerName,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $TenantId,
    [string] $SubscriptionId,
    [string] $ResourceGroup,
    [string] $Region,
    [string] $AppName,
    [string] $ClusterDNSSuffix,
    [Switch] $IsWAC,
    [string] $Environment
    )

    if($IsManagementNode)
    {
        if($Credential -eq $Null)
        {
            $session = New-PSSession -ComputerName $ComputerName
        }
        else
        {
            $session = New-PSSession -ComputerName $ComputerName -Credential $Credential
        }
    }
    else
    {
        $session = New-PSSession -ComputerName localhost
    }

    $clusterName = Invoke-Command -Session $session -ScriptBlock { (Get-Cluster).Name }
    $clusterDNSName = Get-ClusterDNSName -Session $session

    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $FetchingRegistrationState -PercentComplete 1
    $arcStatus = Invoke-Command -Session $session -ScriptBlock { Get-AzureStackHCIArcIntegration }

    $AppId = [string]::Empty
    $Secret = [string]::Empty

    # Register resource providers
    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $RegisterArcRPMessage -PercentComplete 10
    Register-AzResourceProvider -ProviderNamespace Microsoft.HybridCompute | Out-Null
    Register-AzResourceProvider -ProviderNamespace Microsoft.GuestConfiguration | Out-Null

    $arcAppId = $arcStatus.ApplicationId
    $shouldCreateApp = $true

    if(-Not [string]::IsNullOrEmpty($arcAppId))
    {
        $existingArcApp = Retry-Command -ScriptBlock { Get-AzureADApplication -Filter "AppId eq '$arcAppId'" } -RetryIfNullOutput $false

         if(($existingArcApp -ne $Null) -and ($arcStatus.ClusterArcStatus -eq [ArcStatus]::Enabled))
         {
            $shouldCreateApp = $false
         }
    }

    # Setup Arc agent.
    if ($shouldCreateApp)
    {
        # Create application.
        $CreatingAADAppMessageProgress = $CreatingAADAppMessage -f $AppName, $TenantId
        Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $CreatingAADAppMessageProgress -PercentComplete 30
        $appCreated = Create-ArcApplication -AppName $AppName -AppId ([ref]$appId) -Secret ([ref]$secret) -IsWAC:$IsWAC

        if($appCreated -eq $false)
        {
            return [ErrorDetail]::ArcPermissionsMissing
        }

        $arcCommand = Invoke-Command -Session $session -ScriptBlock { Get-Command -Name 'Initialize-AzureStackHCIArcIntegration' -ErrorAction SilentlyContinue }
        if ($arcCommand.Parameters.ContainsKey('Cloud')) 
        {
            Write-Debug ("invoking Initialize-AzureStackHCIArcIntegration with cloud switch")
            $ArcRegistrationParams = @{
                AppId = $AppId
                Secret = $Secret
                TenantId = $TenantId
                SubscriptionId = $SubscriptionId
                Region = $Region
                ResourceGroup = $ResourceGroup 
                cloud  = $Environment 
            }    
        }else
        {
            Write-Debug ("invoking Initialize-AzureStackHCIArcIntegration without cloud switch")
            $ArcRegistrationParams = @{
                AppId = $AppId
                Secret = $Secret
                TenantId = $TenantId
                SubscriptionId = $SubscriptionId
                Region = $Region
                ResourceGroup = $ResourceGroup
            }
        }
        
        # Save Arc context.
        Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $SetupArcMessage -PercentComplete 40
        
        Invoke-Command -Session $session -ScriptBlock { Initialize-AzureStackHCIArcIntegration @Using:ArcRegistrationParams }
    }

    # Register clustered scheduled task
    try
    {
        # Connect to cluster and use that session for registering clustered scheduled task
        if($Credential -eq $Null)
        {
            $clusterNameSession = New-PSSession -ComputerName ($clusterDNSName + "." + $ClusterDNSSuffix)
        }
        else
        {
            $clusterNameSession = New-PSSession -ComputerName ($clusterDNSName + "." + $ClusterDNSSuffix) -Credential $Credential
        }

        Invoke-Command -Session $clusterNameSession -ScriptBlock { 
            $task =  Get-ScheduledTask -TaskName $using:ArcRegistrationTaskName -ErrorAction SilentlyContinue
            $action = New-ScheduledTaskAction -Execute "powershell.exe" -Argument "-Command $using:registerArcScript"
            
            # Repeat the script every hour of every day, starting from now.
            $date = Get-Date
            $dailyTrigger = New-ScheduledTaskTrigger -Daily -At $date
            $hourlyTrigger = New-ScheduledTaskTrigger -Once -At $date -RepetitionInterval (New-TimeSpan -Hours 1) -RepetitionDuration (New-TimeSpan -Hours 23 -Minutes 55)
            $dailyTrigger.Repetition = $hourlyTrigger.Repetition

            if (-Not $task)
            {
                Register-ClusteredScheduledTask -TaskName $using:ArcRegistrationTaskName -TaskType ClusterWide -Action $action -Trigger $dailyTrigger -Cluster $Using:clusterName
            }
            else
            {
                # Update cluster schedule task.
                Set-ClusteredScheduledTask -TaskName $using:ArcRegistrationTaskName -Action $action -Trigger $dailyTrigger -Cluster $Using:clusterName
            }
        } | Out-Null
    }
    catch
    {
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Error ("Exception occured in registering cluster scheduled task. ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage) -Category OperationStopped
        throw
    }
    finally
    {
        if($clusterNameSession -ne $null)
        {
            Remove-PSSession $clusterNameSession -ErrorAction Ignore | Out-Null
        }
    }

    # Run
    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $StartingArcAgentMessage -PercentComplete 50
    $arcResult = Enable-ArcForServers -Session $session -Credential $Credential -ClusterDNSSuffix $ClusterDNSSuffix

    Write-Progress -Id $ArcProgressBarId -activity $RegisterArcProgressActivityName -Completed

    Remove-PSSession $session | Out-Null

    Write-Verbose "Successfully registered cluster with Arc for Servers."

    return $arcResult
}

function Unregister-ArcForServers{
param(
    [bool] $IsManagementNode,
    [string] $ComputerName,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $ResourceId,
    [Switch] $Force,
    [string] $ClusterDNSSuffix
    )

    if($IsManagementNode)
    {
        if($Credential -eq $Null)
        {
            $session = New-PSSession -ComputerName $ComputerName
        }
        else
        {
            $session = New-PSSession -ComputerName $ComputerName -Credential $Credential
        }
    }
    else
    {
        $session = New-PSSession -ComputerName localhost
    }

    $clusterName = Invoke-Command -Session $session -ScriptBlock { (Get-Cluster).Name }
    $clusterDNSName = Get-ClusterDNSName -Session $session

    $cmdlet = Invoke-Command -Session $session -ScriptBlock { Get-Command Get-AzureStackHCIArcIntegration -Type Cmdlet -ErrorAction Ignore }

    if($cmdlet -eq $null)
    {
        return $true
    }

    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $FetchingRegistrationState -PercentComplete 1
    $arcStatus = Invoke-Command -Session $session -ScriptBlock { Get-AzureStackHCIArcIntegration }
    $hciStatus = Invoke-Command -Session $session -ScriptBlock { Get-AzureStackHCI }
    $arcResourceId = $ResourceId + $HCIArcInstanceName
    $arcResourceExtensions = $arcResourceId + $HCIArcExtensions

    if ($arcStatus.ClusterArcStatus -eq [ArcStatus]::Enabled)
    {
        Invoke-Command -Session $session -ScriptBlock { Clear-AzureStackHCIArcIntegration -SetDisableInProgress}
    }

    $arcres = Get-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -ErrorAction Ignore

    # Set aggregateState on HCI RP ArcSettings to DisableInProgress
    if(($arcres -ne $null) -and ($arcres.Properties.aggregateState -ne $ArcSettingsDisableInProgressState))
    {
        $disableProperties = @{"aggregateState" = $ArcSettingsDisableInProgressState}
        $arcres = New-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -PropertyObject $disableProperties -Force
    }

    if($arcres -ne $null)
    {
        $extensions = Get-AzResource -ResourceId $arcResourceExtensions -ApiVersion $HCIArcAPIVersion
    }

    $extensionsCleanupSucceeded = $true

    if($extensions -ne $null)
    {
        # Remove extensions one by one. If -Force is passed write warning and proceed, else write error and stop
        for($extIndex = 0; $extIndex -lt $extensions.Count; $extIndex++)
        {
            $extension = $extensions[$extIndex]

            try
            {
                $DeletingExtensionMessageProgress = $DeletingExtensionMessage -f $extension.Name, $clusterName
                $ProgressRange = 27 # Difference between previous and next progress number
                $PercentComplete = [Math]::Round( 2 + ((($extIndex+1)/($extensions.Count)) * $ProgressRange) )
                Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $DeletingExtensionMessageProgress -PercentComplete $PercentComplete
                Remove-AzResource -ResourceId $extension.ResourceId -ApiVersion $HCIArcAPIVersion -Force -ErrorAction Stop | Out-Null
            }
            catch
            {
                $extensionsCleanupSucceeded = $false
                $positionMessage = $_.InvocationInfo.PositionMessage
                Write-Debug ("Exception occured in removing extension " + $extension.Name + ". ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage)

                if($Force -eq $true)
                {
                    $ArcExtensionCleanupFailedWarningMsg = $ArcExtensionCleanupFailedWarning -f $extension.Name
                    Write-Warning $ArcExtensionCleanupFailedWarningMsg
                }
                else
                {
                    $ArcExtensionCleanupFailedErrorMsg = $ArcExtensionCleanupFailedError -f $extension.Name
                    Write-Error -Message $ArcExtensionCleanupFailedErrorMsg -ErrorAction Continue
                }
            }
        }
    }

    if(($Force -eq $false) -and ($extensionsCleanupSucceeded -eq $false))
    {
        return $false
    }

    # Clean up clustered scheduled task, if it exists.
    try
    {
        # Connect to cluster and use that session for registering clustered scheduled task
        if($Credential -eq $Null)
        {
            $clusterNameSession = New-PSSession -ComputerName ($clusterDNSName + "." + $ClusterDNSSuffix)
        }
        else
        {
            $clusterNameSession = New-PSSession -ComputerName ($clusterDNSName + "." + $ClusterDNSSuffix) -Credential $Credential
        }

        Invoke-Command -Session $clusterNameSession -ScriptBlock {
            $task =  Get-ScheduledTask -TaskName $using:ArcRegistrationTaskName -ErrorAction SilentlyContinue
            if ($task)
            {
                Unregister-ClusteredScheduledTask -Cluster $Using:clusterName -TaskName $using:ArcRegistrationTaskName
            }
        } | Out-Null
    }
    catch
    {
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Error ("Exception occured in unregistering cluster scheduled task. ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage) -Category OperationStopped
        throw
    }
    finally
    {
        if($clusterNameSession -ne $null)
        {
            Remove-PSSession $clusterNameSession -ErrorAction Ignore | Out-Null
        }
    }

    # Unregister all nodes.
    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $WaitingUnregisterMessage -PercentComplete 30
    $disabled = Disable-ArcForServers -Session $session -Credential $Credential -ClusterDNSSuffix $ClusterDNSSuffix

    if ($disabled)
    {
        # Call HCI RP to clean up all Arc proxy resources
        $arcResource = Get-AzResource -ResourceId $arcResourceId -ErrorAction Ignore

        if($arcResource -ne $Null)
        {
            $DeletingArcCloudResourceMessageProgress = $DeletingArcCloudResourceMessage -f $arcResourceId
            Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $DeletingArcCloudResourceMessageProgress -PercentComplete 40
            Remove-AzResource -ResourceId $arcResourceId -Force | Out-Null
        }

        # Clean up Arc registry.
        $appId = $arcStatus.ApplicationId
        if (-Not [string]::IsNullOrEmpty($appId))
        {
            $app = Retry-Command -ScriptBlock { Get-AzureADApplication -Filter "AppId eq '$appId'" } -RetryIfNullOutput $false

            if($app -ne $Null)
            {
                $DeletingAADApplicationMessageProgress = $DeletingAADApplicationMessage -f $app.DisplayName
                Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $DeletingAADApplicationMessageProgress -PercentComplete 50
                Remove-ArcApplication -AppId $appId
            }
        }

        if ($arcStatus.ClusterArcStatus -ne [ArcStatus]::Disabled)
        {
            Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $CleanArcMessage -PercentComplete 80
            Invoke-Command -Session $session -ScriptBlock { Clear-AzureStackHCIArcIntegration }

            Write-Verbose "Successfully unregistered cluster from Arc for Servers"
        }
    }

    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -activity $UnregisterArcProgressActivityName -Completed
    return $disabled
}

enum OperationStatus
{
    Unused;
    Failed;
    Success;
    PendingForAdminConsent;
    Cancelled;
    RegisterSucceededButArcFailed
}

enum ConnectionTestResult
{
    Unused;
    Succeeded;
    Failed
}

enum ErrorDetail
{
    Unused;
    ArcPermissionsMissing;
    ArcIntegrationFailedOnNodes;
    Success
}

<#
    .Description
    Register-AzStackHCI creates a Microsoft.AzureStackHCI cloud resource representing the on-premises cluster and registers the on-premises cluster with Azure.
 
    .PARAMETER SubscriptionId
    Specifies the Azure Subscription to create the resource. This is the only Mandatory parameter.

    .PARAMETER Region
    Specifies the Region to create the resource. Default is EastUS.

    .PARAMETER ResourceName
    Specifies the resource name of the resource created in Azure. If not specified, on-premises cluster name is used.

    .PARAMETER Tag
    Specifies the resource tags for the resource in Azure in the form of key-value pairs in a hash table. For example: @{key0="value0";key1=$null;key2="value2"}

    .PARAMETER TenantId
    Specifies the Azure TenantId.

    .PARAMETER ResourceGroupName
    Specifies the Azure Resource Group name. If not specified <LocalClusterName>-rg will be used as resource group name.

    .PARAMETER ArmAccessToken
    Specifies the ARM access token. Specifying this along with GraphAccessToken and AccountId will avoid Azure interactive logon.

    .PARAMETER GraphAccessToken
    Specifies the Graph access token. Specifying this along with ArmAccessToken and AccountId will avoid Azure interactive logon.

    .PARAMETER AccountId
    Specifies the ARM access token. Specifying this along with ArmAccessToken and GraphAccessToken will avoid Azure interactive logon.

    .PARAMETER EnvironmentName
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

    .PARAMETER ComputerName
    Specifies the cluster name or one of the cluster node in on-premise cluster that is being registered to Azure.

    .PARAMETER CertificateThumbprint
    Specifies the thumbprint of the certificate available on all the nodes. User is responsible for managing the certificate.

    .PARAMETER RepairRegistration
    Repair the current Azure Stack HCI registration with the cloud. This cmdlet deletes the local certificates on the clustered nodes and the remote certificates in the Azure AD application in the cloud and generates new replacement certificates for both. The resource group, resource name, and other registration choices are preserved.

    .PARAMETER UseDeviceAuthentication
    Use device code authentication instead of an interactive browser prompt.
    
    .PARAMETER EnableAzureArcServer
    Specifying this parameter to $false will skip registering the cluster nodes with Arc for servers.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .PARAMETER IsWAC
    Registrations through Windows Admin Center specifies this parameter to true.

    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Result: Success or Failed or PendingForAdminConsent or Cancelled.
    ResourceId: Resource ID of the resource created in Azure.
    PortalResourceURL: Azure Portal Resource URL.
    PortalAADAppPermissionsURL: Azure Portal URL for AAD App permissions page.

    .EXAMPLE
    Invoking on one of the cluster node.
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd"
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster1-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster1
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster1-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster1/overview
    PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/980be58d-578c-4cff-b4cd-43e9c3a77826/isMSAApp/

    .EXAMPLE
    Invoking from the management node
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ComputerName ClusterNode1
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster2-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster2
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster2-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster2/overview
    PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/950be58d-578c-4cff-b4cd-43e9c3a77866/isMSAApp/

    .EXAMPLE
    Invoking from WAC
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -GraphAccessToken acyee..rerrer -AccountId user1@corp1.com -Region westus -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG
    Result: PendingForAdminConsent
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCIRG/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster3
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCIRG/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster3/overview
    PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/980be58d-578c-4cff-b4cd-43e9c3a77866/isMSAApp/

    .EXAMPLE
    Invoking with all the parameters
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -Region westus -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciClusterRG -ArmAccessToken eerrer..ere= -GraphAccessToken acee..rerrer -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/HciClusterRG/providers/Microsoft.AzureStackHCI/clusters/HciCluster1
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/HciClusterRG/providers/Microsoft.AzureStackHCI/clusters/HciCluster1/overview
    PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/990be58d-578c-4cff-b4cd-43e9c3a77866/isMSAApp/
#>
function Register-AzStackHCI{
param(
    [Parameter(Mandatory = $true)]
    [string] $SubscriptionId,

    [Parameter(Mandatory = $false)]
    [string] $Region,

    [Parameter(Mandatory = $false)]
    [string] $ResourceName,

    [Parameter(Mandatory = $false)]
    [System.Collections.Hashtable] $Tag,

    [Parameter(Mandatory = $false)]
    [string] $TenantId,

    [Parameter(Mandatory = $false)]
    [string] $ResourceGroupName,

    [Parameter(Mandatory = $false)]
    [string] $ArmAccessToken,

    [Parameter(Mandatory = $false)]
    [string] $GraphAccessToken,

    [Parameter(Mandatory = $false)]
    [string] $AccountId,

    [Parameter(Mandatory = $false)]
    [string] $EnvironmentName = $AzureCloud,

    [Parameter(Mandatory = $false)]
    [string] $ComputerName,

    [Parameter(Mandatory = $false)]
    [string] $CertificateThumbprint,

    [Parameter(Mandatory = $false)]
    [Switch]$RepairRegistration,

    [Parameter(Mandatory = $false)]
    [Switch]$UseDeviceAuthentication,
    
    [Parameter(Mandatory = $false)]
    [Switch]$EnableAzureArcServer = $true,
    
    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential,

    [Parameter(Mandatory = $false)]
    [Switch]$IsWAC
    )

    try
    {
        Setup-Logging -LogFilePrefix "RegisterHCI"

        $registrationOutput = New-Object -TypeName PSObject
        $operationStatus = [OperationStatus]::Unused

        try
        {
            Import-PackageProvider -Name Nuget -MinimumVersion "2.8.5.201" -ErrorAction Stop
        }
        catch
        {
            Install-PackageProvider NuGet -Force | Out-Null
        }

        Show-LatestModuleVersion

        if([string]::IsNullOrEmpty($ComputerName))
        {
            $ComputerName = [Environment]::MachineName
            $IsManagementNode = $False
        }
        else
        {
            $IsManagementNode = $True
        }

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $FetchingRegistrationState -percentcomplete 1

        if($IsManagementNode)
        {
            if($Credential -eq $Null)
            {
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName
            }
            else
            {
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName -Credential $Credential
            }
        }
        else
        {
            $clusterNodeSession = New-PSSession -ComputerName localhost
        }

        $RegContext = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-AzureStackHCI }

        if($RepairRegistration -eq $true)
        {
            if(-Not ([string]::IsNullOrEmpty($RegContext.AzureResourceUri)))
            {
                if([string]::IsNullOrEmpty($ResourceName))
                {
                    $ResourceName = $RegContext.AzureResourceUri.Split('/')[8]
                }

                if([string]::IsNullOrEmpty($ResourceGroupName))
                {
                    $ResourceGroupName = $RegContext.AzureResourceUri.Split('/')[4]
                }
            }
            else
            {
                Write-Error -Message $NoExistingRegistrationExistsErrorMessage
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput
                return
            }
        }

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $InstallRSATClusteringMessage -percentcomplete 4

        $clusScript = {
                $clusterPowershell = Get-WindowsFeature -Name RSAT-Clustering-PowerShell;
                if ( $clusterPowershell.Installed -eq $false)
                {
                    Install-WindowsFeature RSAT-Clustering-PowerShell | Out-Null;
                }
        }

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $ValidatingParametersFetchClusterName -percentcomplete 8;
        Invoke-Command -Session $clusterNodeSession -ScriptBlock $clusScript
        $getCluster = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-Cluster }
        $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }
        $clusterDNSSuffix = Get-ClusterDNSSuffix -Session $clusterNodeSession
        $clusterDNSName = Get-ClusterDNSName -Session $clusterNodeSession

        if([string]::IsNullOrEmpty($ResourceName))
        {
            if($getCluster -eq $Null)
            {
                $NoClusterErrorMessage = $NoClusterError -f $ComputerName
                Write-Error -Message $NoClusterErrorMessage
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput
                return
            }
            else
            {
                $ResourceName = $getCluster.Name
            }
        }

        if([string]::IsNullOrEmpty($ResourceGroupName))
        {
            $ResourceGroupName = $ResourceName + "-rg"
        }

        Write-Verbose "Register-AzStackHCI triggered - Region: $Region ResourceName: $ResourceName `
            SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName `
            AccountId: $AccountId EnvironmentName: $EnvironmentName CertificateThumbprint: $CertificateThumbprint `
            RepairRegistration: $RepairRegistration EnableAzureArcServer: $EnableAzureArcServer IsWAC: $IsWAC"

            if((($EnvironmentName -eq $AzureChinaCloud) -or ($EnvironmentName -eq $AzureUSGovernment)) -and ($EnableAzureArcServer -eq $true))
        {
            $ArcNotAvailableMessage = $ArcIntegrationNotAvailableForCloudError -f $EnvironmentName
            Write-Error -Message $ArcNotAvailableMessage 
            $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
            Write-Output $registrationOutput
            return
        }

        if(-Not ([string]::IsNullOrEmpty($Region)))
        {
            $Region = Normalize-RegionName -Region $Region
        }

        $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $RegisterProgressActivityName -UseDeviceAuthentication $UseDeviceAuthentication -Region $Region

        $resourceId = Get-ResourceId -ResourceName $ResourceName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName
        Write-Verbose "ResourceId : $resourceId"
        $resource = Get-AzResource -ResourceId $resourceId -ErrorAction Ignore
        $resGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction Ignore

        if($resource -ne $null)
        {
            $resourceLocation = Normalize-RegionName -Region $resource.Location

            if([string]::IsNullOrEmpty($Region))
            {
                $Region = $resourceLocation
            }
            elseif($Region -ne $resourceLocation)
            {
                $ResourceExistsInDifferentRegionErrorMessage = $ResourceExistsInDifferentRegionError -f $resourceLocation, $Region
                Write-Error -Message $ResourceExistsInDifferentRegionErrorMessage
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput
                return
            }
        }
        else
        {
            if($resGroup -eq $Null)
            {
                if([string]::IsNullOrEmpty($Region))
                {
                    $Region = Get-DefaultRegion -EnvironmentName $EnvironmentName
                }
            }
            else
            {
                if([string]::IsNullOrEmpty($Region))
                {
                    $Region = $resGroup.Location
                }
            }
        }

        # Normalize region name
        $Region = Normalize-RegionName -Region $Region

        $portalResourceUrl = Get-PortalHCIResourcePageUrl -TenantId $TenantId -EnvironmentName $EnvironmentName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Region $Region

        if(($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered) -and ($RepairRegistration -eq $false))
        {
            if(($RegContext.AzureResourceUri -eq $resourceId))
            {
                if($resource -ne $Null)
                {
                    # Already registered with same resource Id and resource exists
                    $appId = $resource.Properties.aadClientId
                    $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName -Region $Region
                    $operationStatus = [OperationStatus]::Success
                }
                else
                {
                    # Already registered with same resource Id and resource does not exists
                    $AlreadyRegisteredErrorMessage = $CloudResourceDoesNotExist -f $resourceId
                    Write-Error -Message $AlreadyRegisteredErrorMessage
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput
                    return
                }
            }
            else # Already registered with different resource Id
            {
                $AlreadyRegisteredErrorMessage = $RegisteredWithDifferentResourceId -f $RegContext.AzureResourceUri
                Write-Error -Message $AlreadyRegisteredErrorMessage
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput
                return
            }
        }
        else
        {
            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RegisterAzureStackRPMessage -percentcomplete 40

            $regRP = Register-AzResourceProvider -ProviderNamespace Microsoft.AzureStackHCI

            # Validate that the input region is supported by the Stack HCI RP
            $supportedRegions = [string]::Empty
            $regionSupported = Validate-RegionName -Region $Region -SupportedRegions ([ref]$supportedRegions)

            if ($regionSupported -eq $False)
            {
                $RegionNotSupportedMessage = $RegionNotSupported -f $Region, $supportedRegions
                Write-Error -Message $RegionNotSupportedMessage
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput
                return
            }

            # Lookup cloud endpoint URL from region name

            if($Region -eq $Region_EASTUSEUAP)
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointsAzureCloud[$Region]
            }
            else
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointAzureCloudFrontDoor
            }

            if($resource -eq $Null)
            {
                # Create new application

                $CreatingAADAppMessageProgress = $CreatingAADAppMessage -f $ResourceName, $TenantId
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $CreatingAADAppMessageProgress -percentcomplete 50

                $appId = Create-Application -AppName $ResourceName

                $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName -Region $Region

                Write-Verbose "Created AAD Application with Id $appId"

                # Create new resource by calling RP

                if($resGroup -eq $Null)
                {
                     $CreatingResourceGroupMessageProgress = $CreatingResourceGroupMessage -f $ResourceGroupName
                     Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $CreatingResourceGroupMessageProgress -percentcomplete 55
                     $resGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Region -Tag @{$ResourceGroupCreatedByName = $ResourceGroupCreatedByValue}
                }


                $CreatingCloudResourceMessageProgress = $CreatingCloudResourceMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $CreatingCloudResourceMessageProgress -percentcomplete 60
                $properties = @{"aadClientId"="$appId";"aadTenantId"="$TenantId"}
                $resource = New-AzResource -ResourceId $resourceId -Location $Region -ApiVersion $RPAPIVersion -PropertyObject $properties -Tag $Tag -Force

                # Try Granting admin consent for requested permissions

                $GrantingAdminConsentMessageProgress = $GrantingAdminConsentMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $GrantingAdminConsentMessageProgress -percentcomplete 65
                $adminConsented = Grant-AdminConsent -AppId $appId

                if($adminConsented -eq $False)
                {
                    $AdminConsentWarningMsg = $AdminConsentWarning -f $ResourceName, $appPermissionsPageUrl
                    Write-Warning $AdminConsentWarningMsg
                    $operationStatus = [OperationStatus]::PendingForAdminConsent
                }
            }
            else
            {
                # Resource and Application exists. Check admin consent status

                $appId = $resource.Properties.aadClientId

                $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName -Region $Region

                # Existing AAD app might not have the newly added scopes, if so add them.
                AddRequiredPermissionsIfNotPresent -AppId $appId
                $rolesPresent = Check-UsageAppRoles -AppId $appId
        
                $GrantingAdminConsentMessageProgress = $GrantingAdminConsentMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $GrantingAdminConsentMessageProgress -percentcomplete 65

                if($rolesPresent -eq $False)
                {
                    # Try Granting admin consent for requested permissions

                    $adminConsented = Grant-AdminConsent -AppId $appId

                    if($adminConsented -eq $False)
                    {
                        $AdminConsentWarningMsg = $AdminConsentWarning -f $ResourceName, $appPermissionsPageUrl
                        Write-Warning $AdminConsentWarningMsg
                        $operationStatus = [OperationStatus]::PendingForAdminConsent
                    }
                }
            }

            if($operationStatus -ne [OperationStatus]::PendingForAdminConsent)
            {
                # At this point Application should be created and consented by admin.

                $appId = $resource.Properties.aadClientId
                $cloudId = $resource.Properties.cloudId 
                $app = Retry-Command -ScriptBlock { Get-AzureADApplication -Filter "AppId eq '$appId'"}
                $objectId = $app.ObjectId
                $appSP = Retry-Command -ScriptBlock { Get-AzureADServicePrincipal -Filter "AppId eq '$appId'"}
                $spObjectId = $appSP.ObjectId

                # Add certificate

                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $GettingCertificateMessage -percentcomplete 70

                $CertificatesToBeMaintained = @{}
                $NewCertificateFailedNodes = [System.Collections.ArrayList]::new()
                $SetCertificateFailedNodes = [System.Collections.ArrayList]::new()
                $OSNotLatestOnNodes = [System.Collections.ArrayList]::new()

                $ServiceEndpoint = ""
                $Authority = ""
                $BillingServiceApiScope = ""
                $GraphServiceApiScope = ""

                Get-EnvironmentEndpoints -EnvironmentName $EnvironmentName -ServiceEndpoint ([ref]$ServiceEndpoint) -Authority ([ref]$Authority) -BillingServiceApiScope ([ref]$BillingServiceApiScope) -GraphServiceApiScope ([ref]$GraphServiceApiScope)

                $setupCertsError = Setup-Certificates -ClusterNodes $clusterNodes -Credential $Credential -ResourceName $ResourceName -ObjectId $objectId -CertificateThumbprint $CertificateThumbprint -AppId $appId -TenantId $TenantId -CloudId $cloudId `
                                    -ServiceEndpoint $ServiceEndpoint -BillingServiceApiScope $BillingServiceApiScope -GraphServiceApiScope $GraphServiceApiScope -Authority $Authority -NewCertificateFailedNodes $NewCertificateFailedNodes `
                                    -SetCertificateFailedNodes $SetCertificateFailedNodes -OSNotLatestOnNodes $OSNotLatestOnNodes -CertificatesToBeMaintained $CertificatesToBeMaintained -ClusterDNSSuffix $clusterDNSSuffix

                if($setupCertsError -ne $null)
                {
                    Write-Error -Message $setupCertsError
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput
                    return
                }

                if(($SetCertificateFailedNodes.Count -ge 1) -or ($NewCertificateFailedNodes.Count -ge 1))
                {
                    # Failed on atleast 1 node
                    $SettingCertificateFailedMessage = $SettingCertificateFailed -f ($NewCertificateFailedNodes -join ","),($SetCertificateFailedNodes -join ",")
                    Write-Error -Message $SettingCertificateFailedMessage
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput
                    return
                }

                if($OSNotLatestOnNodes.Count -ge 1)
                {
                    $NotAllTheNodesInClusterAreGAError = $NotAllTheNodesInClusterAreGA -f ($OSNotLatestOnNodes -join ",")
                    Write-Error -Message $NotAllTheNodesInClusterAreGAError
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput
                    return
                }

                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RegisterAndSyncMetadataMessage -percentcomplete 90

                # Register by calling on-prem usage service Cmdlet

                $RegistrationParams = @{
                                            ServiceEndpoint = $ServiceEndpoint
                                            BillingServiceApiScope = $BillingServiceApiScope
                                            GraphServiceApiScope = $GraphServiceApiScope
                                            AADAuthority = $Authority
                                            AppId = $appId
                                            TenantId = $TenantId
                                            CloudId = $cloudId
                                            SubscriptionId = $SubscriptionId
                                            ObjectId = $objectId
                                            ResourceName = $ResourceName
                                            ProviderNamespace = "Microsoft.AzureStackHCI"
                                            ResourceArmId = $resourceId
                                            ServicePrincipalClientId = $spObjectId
                                            CertificateThumbprint = $CertificateThumbprint
                                        }

                Invoke-Command -Session $clusterNodeSession -ScriptBlock { Set-AzureStackHCIRegistration @Using:RegistrationParams }

                # Delete all certificates except certificates which we created in this current registration flow.
                if(($RepairRegistration -eq $true) -or (-Not ([string]::IsNullOrEmpty($CertificateThumbprint))) )
                {
                    $aadAppKeyCreds = Retry-Command -ScriptBlock {Get-AzureADApplicationKeyCredential -ObjectId $objectId}
                    Foreach ($keyCred in $aadAppKeyCreds)
                    {
                        if($CertificatesToBeMaintained[$keyCred.KeyId] -eq $true)
                        {
                            Write-Verbose ($SkippingDeleteCertificateFromAADApp -f $keyCred.KeyId)
                            continue
                        }
                        else
                        {
                            Write-Verbose ($DeletingCertificateFromAADApp -f $keyCred.KeyId)
                            Retry-Command -ScriptBlock { Remove-AzureADApplicationKeyCredential -ObjectId $objectId -KeyId $keyCred.KeyId} -RetryIfNullOutput $false
                        }
                    }
                }

                # Delete old unused scopes if present
                Remove-OldScopes -AppId $appId

                $operationStatus = [OperationStatus]::Success
            }
        }

        if (($operationStatus -ne [OperationStatus]::PendingForAdminConsent) -and ($EnableAzureArcServer -eq $true))
        {
            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RegisterArcMessage -percentcomplete 91

            $ArcCmdletsAbsentOnNodes = [System.Collections.ArrayList]::new()

            Foreach ($clusNode in $clusterNodes)
            {
                $nodeSession = $null

                try
                {
                    if($Credential -eq $Null)
                    {
                        $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $clusterDNSSuffix)
                    }
                    else
                    {
                        $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $clusterDNSSuffix) -Credential $Credential
                    }
                }
                catch
                {
                    Write-Debug ("Exception occured in establishing new PSSession. ErrorMessage : " + $_.Exception.Message)
                    Write-Debug $_
                    $ArcCmdletsAbsentOnNodes.Add($clusNode.Name) | Out-Null
                    continue
                }

                # Check if node has Arc registration Cmdlets
                $cmdlet = Invoke-Command -Session $nodeSession -ScriptBlock { Get-Command Get-AzureStackHCIArcIntegration -Type Cmdlet -ErrorAction Ignore }

                if($cmdlet -eq $null)
                {
                    $ArcCmdletsAbsentOnNodes.Add($clusNode.Name) | Out-Null
                }

                if($nodeSession -ne $null)
                {
                    Remove-PSSession $nodeSession -ErrorAction Ignore | Out-Null
                }
            }

            if($ArcCmdletsAbsentOnNodes.Count -ge 1)
            {
                # Show Arc error on 20h2 only if -EnableAzureArcServer:$true is explicity passed by user
                if($PSBoundParameters.ContainsKey('EnableAzureArcServer'))
                {
                    $ArcCmdletsNotAvailableErrorMsg = $ArcCmdletsNotAvailableError -f ($ArcCmdletsAbsentOnNodes -join ",")
                    Write-Error -Message $ArcCmdletsNotAvailableErrorMsg
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput
                    return
                }
            }
            else
            {
                $arcResourceId = $resourceId + $HCIArcInstanceName
                $arcResourceGroupName = $ResourceGroupName

                $arcres = Get-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -ErrorAction Ignore

                if($arcres -eq $null)
                {
                    $arcres = New-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -Force
                }
                else
                {
                    if ($arcres.Properties.aggregateState -eq $ArcSettingsDisableInProgressState)
                    {
                        Write-Error -Message $ArcRegistrationDisableInProgressError
                        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                        Write-Output $registrationOutput
                        return
                    }
                }

                $arcResourceGroupName = $arcres.Properties.arcInstanceResourceGroup
                $arcAppName = $ResourceName + ".arc"

                Write-Verbose "Register-AzStackHCI: Arc registration triggered. ArcResourceGroupName: $arcResourceGroupName"
                $arcResult = Register-ArcForServers -IsManagementNode $IsManagementNode -ComputerName $ComputerName -Credential $Credential -TenantId $TenantId -SubscriptionId $SubscriptionId -ResourceGroup $arcResourceGroupName -Region $Region -AppName $arcAppName -ClusterDNSSuffix $clusterDNSSuffix -IsWAC:$IsWAC -Environment:$EnvironmentName

                if($arcResult -ne [ErrorDetail]::Success)
                {
                    $operationStatus = [OperationStatus]::RegisterSucceededButArcFailed
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value $arcResult
                }
            }
        }

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -Completed

        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $operationStatus
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyPortalResourceURL -Value $portalResourceUrl
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResourceId -Value $resourceId
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyPortalAADAppPermissionsURL -Value $appPermissionsPageUrl

        if($operationStatus -eq [OperationStatus]::PendingForAdminConsent)
        {
            $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $AdminConsentWarningMsg
        }
        else
        {
            $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $RegistrationSuccessDetailsMessage
        }

        Write-Output $registrationOutput
    }
    catch
    {
        Write-Error -Exception $_.Exception -Category OperationStopped -ErrorAction Continue
        # Get script line number, offset and Command that resulted in exception. Write-Error with the exception above does not write this info.
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Error ("Exception occured in Register-AzStackHCI : " + $positionMessage) -Category OperationStopped
        throw
    }
    finally
    {
        try{ Disconnect-AzAccount | Out-Null } catch{}
        try{ Disconnect-AzureAD | Out-Null } catch{}
        Stop-Transcript | out-null
    }
}

<#
    .Description
    Unregister-AzStackHCI deletes the Microsoft.AzureStackHCI cloud resource representing the on-premises cluster and unregisters the on-premises cluster with Azure.
    The registered information available on the cluster is used to unregister the cluster if no parameters are passed.

    .PARAMETER SubscriptionId
    Specifies the Azure Subscription to create the resource

    .PARAMETER Region
    Specifies the Region the resource is created in Azure.

    .PARAMETER ResourceName
    Specifies the resource name of the resource created in Azure. If not specified, on-premises cluster name is used.

    .PARAMETER TenantId
    Specifies the Azure TenantId.

    .PARAMETER ResourceGroupName
    Specifies the Azure Resource Group name. If not specified <LocalClusterName>-rg will be used as resource group name.

    .PARAMETER ArmAccessToken
    Specifies the ARM access token. Specifying this along with GraphAccessToken and AccountId will avoid Azure interactive logon.

    .PARAMETER GraphAccessToken
    Specifies the Graph access token. Specifying this along with ArmAccessToken and AccountId will avoid Azure interactive logon.

    .PARAMETER AccountId
    Specifies the ARM access token. Specifying this along with ArmAccessToken and GraphAccessToken will avoid Azure interactive logon.

    .PARAMETER EnvironmentName
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

    .PARAMETER UseDeviceAuthentication
    Use device code authentication instead of an interactive browser prompt.

    .PARAMETER ComputerName
    Specifies one of the cluster node in on-premise cluster that is being registered to Azure.

    .PARAMETER DisableOnlyAzureArcServer
    Specifying this parameter to $true will only unregister the cluster nodes with Arc for servers and Azure Stack HCI registration will not be altered.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .PARAMETER Force
    Specifies that unregistration should continue even if we could not delete the Arc extensions on the nodes.

    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Result: Success or Failed or Cancelled.

    .EXAMPLE
    Invoking on one of the cluster node
    C:\PS>Unregister-AzStackHCI
    Result: Success

    .EXAMPLE
    Invoking from the management node
    C:\PS>Unregister-AzStackHCI -ComputerName ClusterNode1
    Result: Success

    .EXAMPLE
    Invoking from WAC
    C:\PS>Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -GraphAccessToken acyee..rerrer -AccountId user1@corp1.com -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG -Confirm:$False
    Result: Success

    .EXAMPLE
    Invoking with all the parameters
    C:\PS>Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciClusterRG -ArmAccessToken eerrer..ere= -GraphAccessToken acee..rerrer -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential
    Result: Success
#>
function Unregister-AzStackHCI{
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
param(
    [Parameter(Mandatory = $false)]
    [string] $SubscriptionId,

    [Parameter(Mandatory = $false)]
    [string] $ResourceName,

    [Parameter(Mandatory = $false)]
    [string] $TenantId,

    [Parameter(Mandatory = $false)]
    [string] $ResourceGroupName,

    [Parameter(Mandatory = $false)]
    [string] $ArmAccessToken,

    [Parameter(Mandatory = $false)]
    [string] $GraphAccessToken,

    [Parameter(Mandatory = $false)]
    [string] $AccountId,

    [Parameter(Mandatory = $false)]
    [string] $EnvironmentName = $AzureCloud,

    [Parameter(Mandatory = $false)]
    [string] $Region,

    [Parameter(Mandatory = $false)]
    [string] $ComputerName,

    [Parameter(Mandatory = $false)]
    [Switch]$UseDeviceAuthentication,

    [Parameter(Mandatory = $false)]
    [Switch]$DisableOnlyAzureArcServer = $false,

    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential,

    [Parameter(Mandatory = $false)]
    [Switch] $Force
    )

    try
    {
        Setup-Logging -LogFilePrefix "UnregisterHCI"

        $unregistrationOutput = New-Object -TypeName PSObject
        $operationStatus = [OperationStatus]::Unused

        if([string]::IsNullOrEmpty($ComputerName))
        {
            $ComputerName = [Environment]::MachineName
            $IsManagementNode = $False
        }
        else
        {
            $IsManagementNode = $True
        }

        Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $FetchingRegistrationState -percentcomplete 1

        if($IsManagementNode)
        {
            if($Credential -eq $Null)
            {
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName
            }
            else
            {
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName -Credential $Credential
            }

            $RegContext = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-AzureStackHCI }
        }
        else
        {
            $RegContext = Get-AzureStackHCI
            $clusterNodeSession = New-PSSession -ComputerName localhost
        }

        $clusScript = {
                $clusterPowershell = Get-WindowsFeature -Name RSAT-Clustering-PowerShell;
                if ( $clusterPowershell.Installed -eq $false)
                {
                    Install-WindowsFeature RSAT-Clustering-PowerShell | Out-Null;
                }
            }

        Invoke-Command -Session $clusterNodeSession -ScriptBlock $clusScript
        $clusterDNSSuffix = Get-ClusterDNSSuffix -Session $clusterNodeSession
        $clusterDNSName = Get-ClusterDNSName -Session $clusterNodeSession

        Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $ValidatingParametersRegisteredInfo -percentcomplete 5

        if([string]::IsNullOrEmpty($ResourceName) -or [string]::IsNullOrEmpty($SubscriptionId))
        {
            if($RegContext.RegistrationStatus -ne [RegistrationStatus]::Registered)
            {
                Write-Error -Message $RegistrationInfoNotFound
                $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $unregistrationOutput
                return
            }
        }

        if([string]::IsNullOrEmpty($SubscriptionId))
        {
            $SubscriptionId = $RegContext.AzureResourceUri.Split('/')[2]
        }

        if([string]::IsNullOrEmpty($ResourceGroupName))
        {
            $ResourceGroupName = If ($RegContext.RegistrationStatus -ne [RegistrationStatus]::Registered) { $ResourceName + "-rg" } Else { $RegContext.AzureResourceUri.Split('/')[4] }
        }

        if([string]::IsNullOrEmpty($ResourceName))
        {
            $ResourceName = $RegContext.AzureResourceUri.Split('/')[8]
        }

        $resourceId = Get-ResourceId -ResourceName $ResourceName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName

        if ($PSCmdlet.ShouldProcess($resourceId))
        {
            Write-Verbose "Unregister-AzStackHCI triggered - ResourceName: $ResourceName Region: $Region `
                   SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName `
                   AccountId: $AccountId EnvironmentName: $EnvironmentName DisableOnlyAzureArcServer: $DisableOnlyAzureArcServer Force:$Force"

            if(-Not ([string]::IsNullOrEmpty($Region)))
            {
                $Region = Normalize-RegionName -Region $Region
            }

            $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $UnregisterProgressActivityName -UseDeviceAuthentication $UseDeviceAuthentication -Region $Region

            Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $UnregisterArcMessage -percentcomplete 40

            $arcUnregisterRes = Unregister-ArcForServers -IsManagementNode $IsManagementNode -ComputerName $ComputerName -Credential $Credential -ResourceId $resourceId -Force:$Force -ClusterDNSSuffix $clusterDNSSuffix

            if($arcUnregisterRes -eq $false)
            {
                $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $unregistrationOutput
                return
            }
            else
            {
                if ($DisableOnlyAzureArcServer -eq $true)
                {
                    $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Success
                    Write-Output $unregistrationOutput
                    return
                }
            }

            Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $UnregisterHCIUsageMessage -percentcomplete 45
        
            if($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered)
            {

                Invoke-Command -Session $clusterNodeSession -ScriptBlock { Remove-AzureStackHCIRegistration }
                $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }

                Foreach ($clusNode in $clusterNodes)
                {
                    $nodeSession = $null

                    try
                    {
                        if($Credential -eq $Null)
                        {
                            $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $clusterDNSSuffix)
                        }
                        else
                        {
                            $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $clusterDNSSuffix) -Credential $Credential
                        }

                        if([Environment]::MachineName -eq $clusNode.Name)
                        {
                            Remove-AzureStackHCIRegistrationCertificate
                        }
                        else
                        {
                            Invoke-Command -Session $nodeSession -ScriptBlock { Remove-AzureStackHCIRegistrationCertificate }
                        }
                    }
                    catch
                    {
                        Write-Warning ($FailedToRemoveRegistrationCertWarning -f $clusNode.Name)
                        Write-Debug ("Exception occured in clearing certificate on {0}. ErrorMessage : {1}" -f ($clusNode.Name), ($_.Exception.Message))
                        Write-Debug $_
                        continue
                    }
                }
            }

            $resource = Get-AzResource -ResourceId $resourceId -ErrorAction Ignore

            if($resource -ne $Null)
            {
                $appId = $resource.Properties.aadClientId
                $app = Retry-Command -ScriptBlock { Get-AzureADApplication -Filter "AppId eq '$appId'"} -RetryIfNullOutput $false
                
                if($app -ne $Null)
                {
                    $DeletingAADApplicationMessageProgress = $DeletingAADApplicationMessage -f $ResourceName
                    Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $DeletingAADApplicationMessageProgress -percentcomplete 60
                    Retry-Command -ScriptBlock { Remove-AzureADApplication -ObjectId $app.ObjectId} -RetryIfNullOutput $false
                }

                $DeletingCloudResourceMessageProgress = $DeletingCloudResourceMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $DeletingCloudResourceMessageProgress -percentcomplete 80

                $remResource = Remove-AzResource -ResourceId $resourceId -Force
            }

            $resGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction Ignore
            if($resGroup -ne $Null)
            {
                $resGroupTags = $resGroup.Tags

                if($resGroupTags -ne $null)
                {
                    $resGroupTagsCreatedBy = $resGroupTags[$ResourceGroupCreatedByName]

                    # If resource is created by us during registration and if there are no resources in resource group, then delete it.
                    if($resGroupTagsCreatedBy -eq $ResourceGroupCreatedByValue)
                    {
                        $resourcesInRG = Get-AzResource -ResourceGroupName $ResourceGroupName

                        if($resourcesInRG -eq $null) # Resource group is empty
                        {
                            Remove-AzResourceGroup -Name $ResourceGroupName -Force | Out-Null
                        }
                    }
                }
            }

            $operationStatus = [OperationStatus]::Success
        }
        else
        {
            $operationStatus = [OperationStatus]::Cancelled
        }

        Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -Completed

        $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $operationStatus

        if ($operationStatus -eq [OperationStatus]::Success)
        {
            $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $UnregistrationSuccessDetailsMessage
        }

        Write-Output $unregistrationOutput
    }
    catch
    {
        Write-Error -Exception $_.Exception -Category OperationStopped -ErrorAction Continue
        # Get script line number, offset and Command that resulted in exception. Write-Error with the exception above does not write this info.
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Error ("Exception occured in Unregister-AzStackHCI : " + $positionMessage) -Category OperationStopped
        throw
    }
    finally
    {
        try{ Disconnect-AzAccount | Out-Null } catch{}
        try{ Disconnect-AzureAD | Out-Null } catch{}
        Stop-Transcript | out-null
    }
}

<#
    .Description
    Test-AzStackHCIConnection verifies connectivity from on-premises clustered nodes to the Azure services required by Azure Stack HCI.

    .PARAMETER EnvironmentName
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

    .PARAMETER Region
    Specifies the Region to connect to. Not used unless it is Canary region.

    .PARAMETER ComputerName
    Specifies one of the cluster node in on-premise cluster that is being registered to Azure.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Test: Name of the test performed.
    EndpointTested: Endpoint used in the test.
    IsRequired: True or False
    Result: Succeeded or Failed
    FailedNodes: List of nodes on which the test failed.

    .EXAMPLE
    Invoking on one of the cluster node. Success case.
    C:\PS>Test-AzStackHCIConnection
    Test: Connect to Azure Stack HCI Service
    EndpointTested: https://azurestackhci-df.azurefd.net/health
    IsRequired: True
    Result: Succeeded

    .EXAMPLE
    Invoking on one of the cluster node. Failed case.
    C:\PS>Test-AzStackHCIConnection
    Test: Connect to Azure Stack HCI Service
    EndpointTested: https://azurestackhci-df.azurefd.net/health
    IsRequired: True
    Result: Failed
    FailedNodes: Node1inClus2, Node2inClus3
#>
function Test-AzStackHCIConnection{
param(
    [Parameter(Mandatory = $false)]
    [string] $EnvironmentName = $AzureCloud,

    [Parameter(Mandatory = $false)]
    [string] $Region,

    [Parameter(Mandatory = $false)]
    [string] $ComputerName,

    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential
    )

    try
    {
        Setup-Logging -LogFilePrefix "TestAzStackHCIConnection"

        $testConnectionnOutput = New-Object -TypeName PSObject
        $connectionTestResult = [ConnectionTestResult]::Unused

        if([string]::IsNullOrEmpty($ComputerName))
        {
            $ComputerName = [Environment]::MachineName
            $IsManagementNode = $False
        }
        else
        {
            $IsManagementNode = $True
        }

        if($IsManagementNode)
        {
            if($Credential -eq $Null)
            {
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName
            }
            else
            {
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName -Credential $Credential
            }
        }
        else
        {
            $clusterNodeSession = New-PSSession -ComputerName localhost
        }

        if(-not([string]::IsNullOrEmpty($Region)))
        {
            $Region = Normalize-RegionName -Region $Region

            if($Region -eq $Region_EASTUSEUAP)
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointsAzureCloud[$Region]
            }
            else
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointAzureCloudFrontDoor
            }
        }

        $clusScript = {
                $clusterPowershell = Get-WindowsFeature -Name RSAT-Clustering-PowerShell;
                if ( $clusterPowershell.Installed -eq $false)
                {
                    Install-WindowsFeature RSAT-Clustering-PowerShell | Out-Null;
                }
            }

        Invoke-Command -Session $clusterNodeSession -ScriptBlock $clusScript
        $getCluster = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-Cluster }
        $clusterDNSSuffix = Get-ClusterDNSSuffix -Session $clusterNodeSession
        $clusterDNSName = Get-ClusterDNSName -Session $clusterNodeSession

        if($getCluster -eq $Null)
        {
            $NoClusterErrorMessage = $NoClusterError -f $ComputerName
            Write-Error -Message $NoClusterErrorMessage
            return
        }
        else
        {
            $ServiceEndpoint = ""
            $Authority = ""
            $BillingServiceApiScope = ""
            $GraphServiceApiScope = ""

            Get-EnvironmentEndpoints -EnvironmentName $EnvironmentName -ServiceEndpoint ([ref]$ServiceEndpoint) -Authority ([ref]$Authority) -BillingServiceApiScope ([ref]$BillingServiceApiScope) -GraphServiceApiScope ([ref]$GraphServiceApiScope)
            $EndPointToInvoke = $ServiceEndpoint + $HealthEndpointPath

            $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }
            $HealthEndPointCheckFailedNodes = [System.Collections.ArrayList]::new()

            $testConnectionnOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyTest -Value $ConnectionTestToAzureHCIServiceName
            $testConnectionnOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyEndpointTested -Value $EndPointToInvoke
            $testConnectionnOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyIsRequired -Value $True

            Check-ConnectionToCloudBillingService -ClusterNodes $clusterNodes -Credential $Credential -HealthEndpoint $EndPointToInvoke -HealthEndPointCheckFailedNodes $HealthEndPointCheckFailedNodes -ClusterDNSSuffix $clusterDNSSuffix

            if($HealthEndPointCheckFailedNodes.Count -ge 1)
            {
                # Failed on atleast 1 node
                $connectionTestResult = [ConnectionTestResult]::Failed
                $testConnectionnOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyFailedNodes -Value $HealthEndPointCheckFailedNodes
            }
            else
            {
                $connectionTestResult = [ConnectionTestResult]::Succeeded
            }

            $testConnectionnOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $connectionTestResult
            Write-Output $testConnectionnOutput
            return
        }
    }
    catch
    {
        Write-Error -Exception $_.Exception -Category OperationStopped -ErrorAction Continue
        # Get script line number, offset and Command that resulted in exception. Write-Error with the exception above does not write this info.
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-Error ("Exception occured in Test-AzStackHCIConnection : " + $positionMessage) -Category OperationStopped
        throw
    }
    finally
    {
        Stop-Transcript | out-null
    }
}

Export-ModuleMember -Function Register-AzStackHCI
Export-ModuleMember -Function Unregister-AzStackHCI
Export-ModuleMember -Function Test-AzStackHCIConnection
