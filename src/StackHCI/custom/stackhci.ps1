#
# AzureStack HCI Registration and Unregistration Powershell Cmdlets.
#

$ErrorActionPreference = 'Stop'

$GAOSBuildNumber = 17784
$GAOSUBR = 1374

$V2OSBuildNumber = 20348
$V2OSUBR = 288

$22H2BuildNumber = 20349
$23H2BuildNumber = 20350

#region User visible strings

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
$HCIResourceGroupNameDifferentErrorMessage = "Cluster resource has already been created in resource group : {0}. Skip '-ResourceGroupName' or provide '-ResourceGroupName' as {0} in Register-AzStackHCI to perform registration."
$HCISubscriptionDifferentErrorMessage = "Cluster is already registered to subscription id : {0}. Skip '-SubscriptionId' or provide '-SubscriptionId' as {0} in Register-AzStackHCI to perform registration."
$HCIResourceNameDifferentErrorMessage = "Cluster is already registered with resource name : {0}. Skip '-ResourceName' or provide '-ResourceName' as {0} in Register-AzStackHCI to perform registration."
$UserCertValidationErrorMessage = "Can't use certificate with thumbprint {0} because it expires in less than 60 days, on {1}. Certificates must be valid for at least 60 days."
$FailedToRemoveRegistrationCertWarning = "Couldn't clean up Azure Stack HCI registration certificate from node(s) {0}. You can ignore this message or clean up the certificate yourself (optional)."
$UnregistrationSuccessDetailsMessage = "Azure Stack HCI is successfully unregistered. The Azure resource representing Azure Stack HCI has been deleted. Azure Stack HCI can't sync with Azure until you register again."
$RegistrationSuccessDetailsMessage = "Azure Stack HCI is successfully registered. An Azure resource representing Azure Stack HCI has been created in your Azure subscription to enable an Azure-consistent monitoring, billing, and support experience."
$CouldNotGetLatestModuleInformationWarning = "Can't connect to the PowerShell Gallery to verify module version. Make sure you have the latest Az.StackHCI module with major version {0}.*."
$ResourceExistsInDifferentRegionError = "There is already an Azure Stack HCI resource with the same resource ID in region {0}, which is different from the input region {1}. Either specify the same region or delete the existing resource and try again."
$ArcCmdletsNotAvailableError = "Azure Arc integration isn't available for the version of Azure Stack HCI installed on node(s) {0} yet. Check the documentation for details. You may need to install an update or join the Preview channel."
$ArcRegistrationDisableInProgressError = "Unregister of Azure Arc integration is in progress. Try Unregister-AzStackHCI to finish unregistration and then try Register-AzStackHCI again."
$ArcAADAppCreationMessage= "Creating AAD application for onboarding ARC"
$FetchingRegistrationState = "Checking whether the cluster is already registered"
$DisablingDefaultExtensions = "Disabling Azure Arc for servers Mandatory extensions"
$CheckingDependentModules = "Checking whether the required modules are installed"
$ValidatingParametersFetchClusterName = "Validating cmdlet parameters"
$ValidatingParametersRegisteredInfo = "Validating the parameters and checking registration information"
$RegisterProgressActivityName = "Registering Azure Stack HCI with Azure..."
$UnregisterProgressActivityName = "Unregistering Azure Stack HCI from Azure..."
$InstallAzResourcesMessage = "Installing required PowerShell module: Az.Resources"
$InstallRSATClusteringMessage = "Installing required Windows feature: RSAT-Clustering-PowerShell"
$LoggingInToAzureMessage = "Logging in to Azure"
$RegisterAzureStackRPMessage = "Registering Microsoft.AzureStackHCI provider to Subscription"
$CreatingResourceGroupMessage = "Creating Azure Resource Group {0}"
$CreatingCloudResourceMessage = "Creating Azure Resource {0} representing Azure Stack HCI by calling Microsoft.AzureStackHCI provider"
$RepairingCloudResourceMessage = "Repairing Azure Resource {0} representing Azure Stack HCI by calling Microsoft.AzureStackHCI provider"
$GettingCertificateMessage = "Getting new certificate from on-premises cluster to use as application credential"
$AddAppCredentialMessage = "Adding certificate as application credential for the Azure AD application {0}"
$DefaultExtensionPromptMessage = "Registering your system will automatically setup Azure Arc-enabled servers and install Mandatory Azure Arc extensions that help improve product quality and make it easier to get remote support. Learn more at aka.ms/azurestackhcimandatoryextensions."
$RegisterAndSyncMetadataMessage = "Registering Azure Stack HCI cluster and syncing cluster census information from the on-premises cluster to the cloud"
$UnregisterHCIUsageMessage = "Unregistering Azure Stack HCI cluster and cleaning up registration state on the on-premises cluster"
$DeletingCloudResourceMessage = "Deleting Azure resource with ID {0} representing the Azure Stack HCI cluster"
$DeletingArcCloudResourceMessage = "Deleting Azure resource with ID {0} representing the Azure Stack HCI cluster Arc integration"
$DeletingExtensionMessage = "Deleting extension {0} on cluster {1}"
$RegisterArcMessage = "Arc for servers registration triggered"
$UnregisterArcMessage = "Arc for servers unregistration triggered"
$ArcMachineAlreadyExistsInResourceGroupError = "Arc machine(s) with names: {0} already exists in the Resource Group {1}. Use a different Resource group for registration or specify a different Arc for Servers Resource Group."
$SetAzureStackHCIRegistrationErrorMessage = "Exception occurred in Set-AzureStackHCIRegistration. ErrorMessage: {0}"
$ArcAlreadyRegisteredInDifferentResourceGroupError = "Arc servers are already registered in Resource Group: {0}. To change resource groups, please unregister and register again"
$ClusterCreationFailureMessage = "Failed to create cluster resource"
$rpObjectIdNullError = "Resource Provider Object Id is Null. Failed to assign roles to HCI RP for ARC Onboarding"
$roleAssignmentHCIRPFailError = "Failed to assign Arc roles to HCI Resource Provider"
$DefaultExtensionErrorMessage = "User has declined to install Mandatory Azure Arc extensions. Registration is not possible without a consent to install Mandatory extensions. Aborting registration."
$RegisterArcProgressActivityName = "Registering Azure Stack HCI with Azure Arc..."
$UnregisterArcProgressActivityName = "Unregistering Azure Stack HCI with Azure Arc..."
$RegisterArcRPMessage = "Registering Microsoft.HybridCompute and Microsoft.GuestConfiguration resource providers to subscription"
$SetupArcMessage = "Initializing Azure Stack HCI integration with Azure Arc"
$StartingArcAgentMessage = "Enabling Azure Arc integration on every clustered node"
$VerifyingArcMessage = "Verifying Azure Arc for Servers registration"
$WaitingUnregisterMessage = "Disabling Azure Arc integration on every clustered node"
$CleanArcMessage = "Cleaning up Azure Arc integration"

$MissingDependentModulesError = "Can't find PowerShell module(s): {0}. Please install the missing module(s) using 'Install-Module -Name <Module_Name>' and try again."
$ArcAlreadyEnabledInADifferentResourceError = "Below mentioned cluster node(s) are already Arc enabled with a different ARM Resource Id:`n{0}`nDisconnect Arc agent on these nodes and run Register-AzStackHCI again."

$ArcAgentRolesInsufficientPreviligeMessage = "Failed to assign required roles for Azure Arc integration. Your Azure AD account must be an Owner or User Access Administrator in the subscription to enable Azure Arc integration."
$RegisterArcFailedErrorMessage = "Some clustered nodes couldn't be Arc-enabled right now. Check the Arc Scheduled Task logs to investigate further. These logs can be found at C:\Windows\Tasks\ArcForServers."
$RegisterArcFailedExceptionMessage = "Failed to enable Arc on some clustered nodes."
$ArcSettingsPatchFailedWarningMessage = "Arc for Servers registration failed. Visit https://learn.microsoft.com/en-us/azure-stack/hci/deploy/troubleshoot-hci-registration#registration-completes-successfully-but-azure-arc-connection-in-portal-says-not-installed and follow the troubleshooting steps. If Azure-Arc registration continues failing for more than 12 hours, contact support."
$ArcSettingsPatchFailedLogMessage = "Arc for Servers registration failed. Unable to find the cluster nodes in Arc Settings resource."
$UnregisterArcFailedError = "Couldn't disable Azure Arc integration on Node {0}. Try running Disable-AzureStackHCIArcIntegration Cmdlet on the node. If the node is in a state where Disable-AzureStackHCIArcIntegration Cmdlet could not be run, remove the node from the cluster and try Unregister-AzStackHCI Cmdlet again."
$ArcExtensionCleanupFailedError = "Couldn't delete Arc extension {0} on cluster nodes. You can try the extension uninstallation steps listed at https://docs.microsoft.com/en-us/azure/azure-arc/servers/manage-agent for removing the extension and try Unregister-AzStackHCI again. If the node is in a state where extension uninstallation could not succeed, try Unregister-AzStackHCI with -Force switch."
$ArcExtensionCleanupFailedWarning = "Couldn't delete Arc extension {0} on cluster nodes. Extension may continue to run even after unregistration."

$SetProgressActivityName = "Setting properties for the Azure Stack HCI resource in Azure..."
$SetProgressStatusGathering = "Gathering information"
$SetProgressStatusGetAzureResource = "Getting the Azure Stack HCI resource"
$SetProgressStatusOpSwitching = "Switching to the subscription ID {0}"
$SetProgressStatusUpdatingProps = "Updating the resource properties"
$SetProgressStatusSyncCluster = "Syncing the Azure Stack HCI cluster with Azure"
$SetAzResourceClusterNotRegistered = "The cluster is not registered with Azure. Register the cluster using Register-AzStackHCI and then try again."
$SetAzResourceClusterNodesDown = "One or more servers in your cluster are offline. Check that all your servers are up and then try again."
$SetAzResourceSuccessWSSE = "Successfully enabled Windows Server Subscription."
$SetAzResourceSuccessWSSD = "Successfully disabled Windows Server Subscription."
$SetAzResourceSuccessDiagLevel = "Successfully configured the Azure Stack HCI diagnostic level to {0}."
$SetProgressShouldProcess = "Update the resource properties to change Windows Server Subscription or Azure Stack HCI diagnostic level"
$SetProgressShouldContinue = "This will enable or disable billing for Windows Server guest licenses through your Azure subscription."
$SetProgressShouldContinueCaption = "Configure Windows Server Subscription"
$SetProgressWarningDiagnosticOff = "Setting diagnostic level to Off will prevent Microsoft from collecting important diagnostic information that helps improve Azure Stack HCI."
$SetProgressWarningWSSD = "Windows Server Subscription will no longer activate your Windows Server VMs. Please check that your VMs are being activated another way."

$SecondaryProgressBarId = 2
$EnableAzsHciImdsActivity = "Enable Azure Stack HCI IMDS Attestation..."
$ConfirmEnableImds = "Enabling IMDS Attestation configures your cluster to use workloads that are exclusively available on Azure."
$ConfirmDisableImds = "Disabling IMDS Attestation will remove the ability for some exclusive Azure workloads to function."
$ImdsClusterNotRegistered = "The cluster is not registered with Azure. Register the cluster using Register-AzStackHCI and then try again."
$DisableAzsHciImdsActivity = "Disable Azure Stack HCI IMDS Attestation..."
$AddAzsHciImdsActivity = "Add Virtual Machines to Azure Stack HCI IMDS Attestation..."
$RemoveAzsHciImdsActivity = "Remove Virtual Machines from Azure Stack HCI IMDS Attestation..."
$ShouldContinueHyperVInstall = "The Hyper-V Powershell management tools are required to be installed on {0} to continue. Install RSAT-Hyper-V-Tools and continue?"
$DiscoveringClusterNodes = "Discovering cluster nodes..."
$AllClusterNodesAreNotOnline = "One or more servers in your cluster are offline. Check that all your servers are up and then try again."
$CheckingClusterNode = "Checking AzureStack HCI IMDS Attestation on {0}"
$ConfiguringClusterNode = "Configuring AzureStack HCI IMDS Attestation on {0}"
$DisablingIMDSOnNode = "Disabling AzureStack HCI IMDS Attestation on {0}"
$RemovingVmImdsFromNode = "Removing AzureStack HCI IMDS Attestation from guests on {0}"
$AttestationNotEnabled = "The IMDS Service on {0} needs to be activated. This is required before guests can be configured. Run Enable-AzStackHCIAttestation cmdlet."
$ErrorAddingAllVMs = "Did not add all guests. Try running Add-AzStackHCIVMAttestation on each node manually."
$MaskString = "XXXXXXX"
$SetupCloudManagementActivityName = "Cloud Management configuration..."
$ConfiguringCloudManagementMessage = "Configuring Cloud Management agent."
$ConfiguringCloudManagementClusterSvc = "Creating Cloud Management cluster resource."
$StartingCloudManagementMessage = "Starting Cloud Management agent."
$RemoteSupportConsentText = "`r`n`r`nBy approving this request, the Microsoft support organization or the Azure engineering team supporting this feature ('Microsoft Support Engineer') will be given direct access to your device for troubleshooting purposes and/or resolving the technical issue described in the Microsoft support case. `r`n`r`nDuring a remote support session, a Microsoft Support Engineer may need to collect logs. By enabling remote support, you have agreed to a diagnostic logs collection by Microsoft Support Engineer to address a support case You also acknowledge and consent to the upload and retention of those logs in an Azure storage account managed and controlled by Microsoft. These logs may be accessed by Microsoft in the context of a support case and to improve the health of Azure Stack HCI. `r`n`r`nThe data will be used only to troubleshoot failures that are subject to a support ticket, and will not be used for marketing, advertising, or any other commercial purposes without your consent. The data may be retained for up to ninety (90) days and will be handled following our standard privacy practices (https://privacy.microsoft.com/en-US/). Any data previously collected with your consent will not be affected by the revocation of your permission."

$AlreadyLoggedFlag = "Already Logged"
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
$PortalHCIResourceUrl = '#@{0}/resource/subscriptions/{1}/resourceGroups/{2}/providers/Microsoft.AzureStackHCI/clusters/{3}/overview'

$Region_EASTUSEUAP = 'eastus2euap'

[hashtable] $ServiceEndpointsAzureCloud = @{
        $Region_EASTUSEUAP = 'https://canary.dp.stackhci.azure.com'
        }

$ServiceEndpointAzureCloudFrontDoor = "https://dp.stackhci.azure.com"
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
$GraphServiceApiScopeAzureUSGovernment = "https://graph.microsoft.us/.default"

$ServiceEndpointAzureGermanCloud = "https://azurestackhci-usage.trafficmanager.de"
$AuthorityAzureGermanCloud = "https://login.microsoftonline.de"
$BillingServiceApiScopeAzureGermanCloud = "https://azurestackhci-usage.azurewebsites.de/.default"
$GraphServiceApiScopeAzureGermanCloud = "https://graph.cloudapi.de/.default"

$RPAPIVersion = "2022-12-01";
$HCIArcAPIVersion = "2023-03-01"
$HCIArcExtensionAPIVersion = "2021-09-01"
$HCApiVersion = "2022-03-10"
$HCIArcInstanceName = "/arcSettings/default"
$HCIArcExtensions = "/Extensions"

$OutputPropertyResult = "Result"
$OutputPropertyResourceId = "AzureResourceId"
$OutputPropertyPortalResourceURL = "AzurePortalResourceURL"
$OutputPropertyDetails = "Details"
$OutputPropertyTest = "Test"
$OutputPropertyEndpointTested = "EndpointTested"
$OutputPropertyIsRequired = "IsRequired"
$OutputPropertyFailedNodes = "FailedNodes"
$OutputPropertyErrorDetail = "ErrorDetail"
$OutputPropertyClusterAgentStatus = "ClusterAgentStatus"
$OutputPropertyClusterAgentError = "ClusterAgentError"

$ConnectionTestToAzureHCIServiceName = "Connect to Azure Stack HCI Service"

$ResourceGroupCreatedByName = "CreatedBy"
$ResourceGroupCreatedByValue = "4C02703C-F5D0-44B0-ADC3-4ED5C2839E61"

$HealthEndpointPath = "/health"


$MainProgressBarId = 1
$ArcProgressBarId = 2

$AzureConnectedMachineOnboardingRole = "Azure Connected Machine Onboarding"
$AzureConnectedMachineResourceAdministratorRole = "Azure Connected Machine Resource Administrator"
$ArcOnboardingRole = "Azure Connected Machine Resource Manager"
$ArcRegistrationTaskName = "ArcRegistrationTask"
$LogFileDir = '\Tasks\ArcForServers'

$ArcMachineResourceType = "Microsoft.HybridCompute/machines"

$ClusterScheduledTaskWaitTimeMinutes = 15
$ClusterScheduledTaskSleepTimeSeconds = 3
$ClusterScheduledTaskRunningState = "Running"
$ClusterScheduledTaskReadyState = "Ready"

$GetArcSettingsWaitTimeMinutes = 1
$GetArcSettingsSleepTimeSeconds = 15
$ArcSettingsVerificationLimit = 5

$ArcSettingsDisableInProgressState = "DisableInProgress"

# Cluster Agent Service Names
$ClusterAgentServiceName = "HciClusterAgentSvc"
$ClusterAgentGroupName = "Cloud Management"

$AzAccountsModuleMinVersion="2.11.2"
$AzResourcesModuleMinVersion="6.2.0"

Function Write-Log {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    Param(
    [Parameter(Mandatory=$False)]
    [ValidateSet("INFO","WARN","ERROR","FATAL","DEBUG")]
    [String]
    $Level = "INFO",

    [Parameter(Mandatory=$True)]
    [string]
    $Message
    )

    $Stamp = (Get-Date).toString("yyyy/MM/dd HH:mm:ss")
    $Line = "$Stamp , $Level , $Message"

    Add-Content $global:LogFileName -Value $Line

}

Function Write-VerboseLog{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
    [Parameter(Mandatory=$True)]
    [string]
    $Message
    )
    Write-Verbose $Message
    Write-Log -Level "DEBUG" -Message $Message
}


Function Write-InfoLog{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
    [Parameter(Mandatory=$True)]
    [string]
    $Message
    )
    Write-Information $Message
    Write-Log -Level "INFO" -Message $Message
}

Function Write-WarnLog{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
    [Parameter(Mandatory=$True)]
    [string]
    $Message
    )
    Write-Warning $Message
    Write-Log -Level "WARN" -Message $Message
}

<#
Writes the Error output to registration log file and console
If Category is passed as 'OperationStopped', the Script will not write the error message again in the final catch block
#>
Function Write-ErrorLog{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
    [Parameter(Mandatory=$true)]
    [string]
    $Message,
    [Parameter(Mandatory=$false)]
    [System.Management.Automation.ErrorRecord]
    $Exception,
    [Parameter(Mandatory=$false)]
    [string]
    $Category
    )
    $ErrorLogMessage = $PSBoundParameters["Message"]
    $WriteErrorMessage = $PSBoundParameters["Message"]
    
    if($PSBoundParameters["Exception"])
    {
        $exceptionFormatted = $Exception | Format-List * -Force | Out-String
        $invocationInfoFormatted = $Exception.InvocationInfo | Format-List * -Force | Out-String
        $innerExceptionFormatted = ""
        $_.Exception.InnerException | ForEach-Object {
            $innerExceptionFormatted = $innerExceptionFormatted + ($_ | Format-List * -Force | Out-String)
        } | Out-Null
        $ErrorLogMessage = $ErrorLogMessage + ("`n{0}`n{1}`n{2}" -f $exceptionFormatted, $invocationInfoFormatted, $innerExceptionFormatted)
        $WriteErrorMessage = $WriteErrorMessage + "`n{0}" -f $exceptionFormatted
    }

    # Writing error message in the log file
    Write-Log -Level "ERROR" -Message $ErrorLogMessage

    if($PSBoundParameters["Category"])
    {
        $WriteErrorMessage = $WriteErrorMessage + "`nCategoryInfo: {0}" -f $Category.ToString()
    }

    # Writing error message on the console
    $Host.UI.WriteErrorLine($WriteErrorMessage)

    # If Category is 'OperationStopped', add 'Already Logged' flag in the $Error variable to prevent logging exception again in the final catch block
    if($PSBoundParameters["Category"] -eq "OperationStopped")
    {
        $Error.Add($AlreadyLoggedFlag) | Out-Null
    }
}

Function Write-NodeEventLog{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
    [Parameter(Mandatory=$True)]
    [string]
    $Message,
    [Parameter(Mandatory=$True)]
    [Int]
    $EventID,
    [Parameter(Mandatory=$True)]
    [bool]
    $IsManagementNode,
    [Parameter(Mandatory=$False)]
    [string]
    $ComputerName,
    [Parameter(Mandatory=$False)]
    [System.Management.Automation.PSCredential]
    $Credentials,
    [Parameter(Mandatory=$False)]
    [EventLogLevel]
    $Level = [EventLogLevel]::Information
    )
    $sourceName="HCI Registration"
    try
    {
        if($IsManagementNode)
        {
            Write-VerboseLog ("Connecting from management node")
            if($Null -eq $Credentials)
            {
                $session = New-PSSession -ComputerName $ComputerName
            }
            else
            {
                $session = New-PSSession -ComputerName $ComputerName -Credential $Credentials
            }
        }
        else
        {
            $session = New-PSSession -ComputerName localhost
        }
        $sourceExists = Invoke-Command -Session $session -ScriptBlock {Get-EventLog -LogName Application -Source $using:sourceName -Newest 1 -ErrorAction SilentlyContinue }
        if(-not $sourceExists)
        {
            Invoke-Command -Session $session -ScriptBlock { New-EventLog -LogName Application -Source $using:sourceName -ErrorAction SilentlyContinue}
        }    
        $levelStr = $Level.ToString()
        Invoke-Command -Session $session -ScriptBlock { Write-EventLog -LogName Application -Source $using:sourceName -EventId $using:EventID -EntryType $using:levelStr -Message $using:Message }
    
    }
    catch
    {
        Write-WarnLog("failed to write events to node"+ $_.Exception.Message)   
    }
}

Function Print-FunctionParameters{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
    [Parameter(Mandatory=$True)]
    [string]
    $Message,
    [Parameter(Mandatory=$True)]
    [hashtable]
    $Parameters
    )

    $body = @{}
    foreach ($param in $Parameters.GetEnumerator()) {
        # remove common parameters (Debug, Verbose, etc)
        if ([System.Management.Automation.PSCmdlet]::CommonParameters -contains $param.key) {
            continue
        } 
        if ($param.key -in @("ArmAccessToken","ArcSpnCredential","Credential","AccountId","GraphAccessToken","AccessToken")) 
        {
            $body.add($param.Key, $MaskString) 
        }
        else
        {
            $body.add($param.Key, $param.Value)
        }
    }    
    return "Parameters for {0} are: {1}" -f $Message, ($body | Out-String ) 
}

$CheckNodeArcRegistrationStateScriptBlock = {
    if(Test-Path -Path "C:\Program Files\AzureConnectedMachineAgent\azcmagent.exe")
    {
        $arcAgentStatus = Invoke-Expression -Command "& 'C:\Program Files\AzureConnectedMachineAgent\azcmagent.exe' show -j"
        
        # Parsing the status received from Arc agent
        $arcAgentStatusParsed = $arcAgentStatus | ConvertFrom-Json

        # Throw an error if the node is Arc enabled to a different resource group or subscription id
        # Agent can be is "Connected"  or disconnected state. If the resource name property on the agent is empty, that means, it is cleanly disconnected , and just the exe exists
        # If the resourceName exists and agent is in "Disconnected" state, indicates agent has temporary connectivity issues to the cloud
        if(-not ([string]::IsNullOrEmpty($arcAgentStatusParsed.resourceName)) -And (($arcAgentStatusParsed.subscriptionId -ne $Using:SubscriptionId) -or ($arcAgentStatusParsed.resourceGroup -ne $Using:ArcResourceGroupName)))
        {
            $differentResourceExceptionMessage = "{0}:  Subscription Id: {1}, Resource Group: {2}" -f $Using:clusterNode, $arcAgentStatusParsed.subscriptionId, $arcAgentStatusParsed.resourceGroup
            throw $differentResourceExceptionMessage
        }
    }
}

$registerArcScript = {
    try
    {
        # Params for Enable-AzureStackHCIArcIntegration 
        $AgentInstaller_WebLink                  = 'https://aka.ms/AzureConnectedMachineAgent'
        $AgentInstaller_Name                     =  $env:windir + '\Tasks\ArcForServers' + '\AzureConnectedMachineAgent.msi'
        $AgentInstaller_LogFile                  =  $env:windir + '\Tasks\ArcForServers' +'\ConnectedMachineAgentInstallationLog.txt'
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
        $sourceExists = Get-EventLog -LogName Application -Source 'HCI Registration' -Newest 1 -ErrorAction SilentlyContinue
        if(-not $sourceExists)
        {
            New-EventLog -LogName Application -Source 'HCI Registration' -ErrorAction SilentlyContinue
        }
        Write-Information 'Triggering Arc For Servers registration cmdlet'
        $arcStatus = Get-AzureStackHCIArcIntegration

        $enableAzureStackHCIArcIntegrationRetrySleepTimeSeconds = 10

        if ($arcStatus.ClusterArcStatus -eq 'Enabled')
        {
            $nodeStatus = $arcStatus.NodesArcStatus
    
            if ($nodeStatus.Keys -icontains ($env:computername))
            {
                if ($nodeStatus[$env:computername.ToLowerInvariant()] -ne 'Enabled')
                {
                    Write-Information 'Registering Arc for servers.'
                    Write-EventLog -LogName Application -Source 'HCI Registration' -EventId 9002 -EntryType 'Information' -Message 'Initiating Arc For Servers registration'

                    $enableAzureStackHCIArcIntegrationRetryCount = 10
                    $currentCount = 1
                    $isEnableArcIntegrationSuccessful = $false

                    while (($currentCount -le $enableAzureStackHCIArcIntegrationRetryCount) -and (-Not $isEnableArcIntegrationSuccessful)) 
                    {
                        Write-Information 'Enabling Arc for Servers using Arc SPN Credential'
                        Enable-AzureStackHCIArcIntegration -AgentInstallerWebLink $AgentInstaller_WebLink -AgentInstallerName $AgentInstaller_Name -AgentInstallerLogFile $AgentInstaller_LogFile -AgentExecutablePath $AgentExecutable_Path  *>&1 | Tee-Object -Variable enableArcIntegrationOutput

                        $isEnableArcIntegrationSuccessful = $true
                        if($enableArcIntegrationOutput -ne $null)
                        {
                            $enableArcIntegrationOutput | foreach {
                                Write-Information $_.ToString()
                                if($_.ToString().Contains('401') -or $_.ToString().Contains('403'))
                                {
                                    $isEnableArcIntegrationSuccessful = $false
                                }
                            }
                        }

                        if(($isEnableArcIntegrationSuccessful -eq $false) -and ($currentCount -le $EnableAzureStackHCIArcIntegrationRetryCount))
                        {
                            Write-Information 'Failed to enable Azure Arc integration. Trying it again.'
                            Start-Sleep -Seconds $enableAzureStackHCIArcIntegrationRetrySleepTimeSeconds
                        }

                        $currentCount++
                    }

                    if(-Not $isEnableArcIntegrationSuccessful)
                    {
                        Write-EventLog -LogName Application -Source 'HCI Registration' -EventId 9006 -EntryType 'Information' -Message 'Failed to enable Azure Arc integration.'
                        Write-Information 'Failed to enable Azure Arc integration.'
                        throw 'Failed to enable Azure Arc integration.'
                    }

                    Sync-AzureStackHCI
                    Write-Information 'Completed Arc for Servers registration'
                    Write-EventLog -LogName Application -Source 'HCI Registration' -EventId 9003 -EntryType 'Information' -Message 'Completed Arc For Servers registration'
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
                Write-EventLog -LogName Application -Source 'HCI Registration' -EventId 9002 -EntryType 'Information' -Message 'Initiating Arc For Servers registration'
                Enable-AzureStackHCIArcIntegration -AgentInstallerWebLink $AgentInstaller_WebLink -AgentInstallerName $AgentInstaller_Name -AgentInstallerLogFile $AgentInstaller_LogFile -AgentExecutablePath $AgentExecutable_Path
                Sync-AzureStackHCI
                Write-EventLog -LogName Application -Source 'HCI Registration' -EventId 9003 -EntryType 'Information' -Message 'Completed Arc For Servers registration'
            }
        }
        else
        {
            Write-Information ('Cluster Arc status is not enabled. ClusterArcStatus:' + $arcStatus.ClusterArcStatus.ToString())
        }
    }
    catch
    {
        # Get script line number, offset and Command that resulted in exception. Write-ErrorLog with the exception above does not write this info.
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-EventLog -LogName Application -Source 'HCI Registration' -EventId 9116 -EntryType 'Warning' -Message ('Failed Arc For Servers registration: '+ $positionMessage)
        Write-Error -Message ('Exception occurred in RegisterArcScript : {0}' -f $positionMessage.ToString()) -Exception $_.Exception -Category OperationStopped
    }
    finally
    {
        $customImdsScript = { try{ $customImdsRegKey = Get-Item 'HKLM:\Software\Microsoft\Windows Azure\CurrentVersion\IMDS' -ErrorAction Stop } catch{ $customImdsRegKey = New-Item 'HKLM:\Software\Microsoft\Windows Azure\CurrentVersion\IMDS' -Force -ErrorAction Stop } $customImdsRegKey | New-ItemProperty -Name 'CustomIMDSHostAddress' -Value 'http://127.0.0.1:42542' -Force -ErrorAction Stop | Out-Null }
        try 
        {
            Write-Verbose ('Configuring CustomIMDSHostAddress')
            Invoke-Command -ScriptBlock $customImdsScript 
        } 
        catch 
        {
            Write-Verbose ('Exception occurred while setting custom IMDS host. ErrorMessage : ' + $_.Exception.Message)
            Write-Verbose ($_ | Out-String)
            Write-Warning ('Could not configure CustomIMDSHostAddress for node.')
        }

        try{ Stop-Transcript } catch {}
    }
}

#endregion

$global:LogFileName
function Setup-Logging{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [string] $LogFilePrefix,
    [bool] $DebugEnabled
    )
    
    $date = Get-Date
    $datestring = "{0}{1:d2}{2:d2}-{3:d2}{4:d2}" -f $date.year,$date.month,$date.day,$date.hour,$date.minute
    $global:LogFileName = $LogFilePrefix + "_" + $datestring + ".log"
    if ($DebugEnabled)
    {
        $DebugLogFileName = $LogFilePrefix + "_" + "debug"+ "_" +$datestring + ".log"
        Start-Transcript -LiteralPath $DebugLogFileName -Append | Out-Null
    }

}

function Show-LatestModuleVersion{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param()
    try 
    {
        $latestModule = Find-Module -Name Az.StackHCI -ErrorAction Ignore
    }
    catch 
    {
        Write-VerboseLog $_.Exception.Message
        $latestModule = $Null
    }
    
    if($Null -eq $latestModule)
    {
        $CouldNotGetLatestModuleInformationWarningMsg = $CouldNotGetLatestModuleInformationWarning -f $installedModule.Version.Major
        Write-WarnLog ($CouldNotGetLatestModuleInformationWarningMsg)
    }
    else
    {
        $installedModule = Get-Module -Name Az.StackHCI | Sort-Object  -Property Version -Descending | Select-Object -First 1
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
            Write-WarnLog ($InstallLatestVersionWarningMsg)
        }
    }
}

<#
Executes a script while suppresing any progressbar coming from cmdlets in script
Useful while running long running cmdlets (202 pattern) since progressbar from these cmdlets 
do not have useful information
#>
function Execute-Without-ProgressBar{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param (
        [parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [scriptblock] $ScriptBlock
        )
        $OriginalPref = $ProgressPreference
        try
        {
            $ProgressPreference = "SilentlyContinue"
            $result = Invoke-Command -ScriptBlock $ScriptBlock
        }
        catch
        {
            Write-ErrorLog -Exception $_ -Message "Exception occured while executing cmd: $ScriptBlock" -ErrorAction Continue  
            throw
        }
        finally
        {
            $ProgressPreference = $OriginalPref
        }
        return $result
}

<#
Executes the given script inside an Invoke-Command. 
Useful for scripts where the error needs to be caught inside the Invoke-Command.
Note: The parameters variable used inside $ScriptBlock should be named $Params or the method won't work as expected
#>
function Run-InvokeCommand {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param (
        [parameter(Mandatory=$true)]
        [scriptblock] $ScriptBlock,
        [parameter(Mandatory=$true)]
        [System.Management.Automation.Runspaces.PSSession] $Session,
        [parameter(Mandatory=$true)]
        [System.Collections.HashTable] $Params
    )
    Invoke-Command -Session $Session -ArgumentList $Params, $ScriptBlock -ScriptBlock {
        param ($Params, $ScriptBlock)
        try {
            Invoke-Expression $ScriptBlock
        }
        catch {
            if($null -ne $_.Exception.InnerException.Detail.Error)
            {
                throw $_.Exception.InnerException.Detail.Error
            }
            throw $_.Exception.Message
        }
    }
}

function Retry-Command {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
                    Write-VerboseLog ("Command [{0}] succeeded. Non null result received." -f $ScriptBlock)
                    $completed = $true
                }
                else
                {
                    throw "Null result received."
                }
            }
            else
            {
                Write-VerboseLog ("Command [{0}] succeeded." -f $ScriptBlock)
                $completed = $true
            }
        }
        catch
        {
            $exception = $_.Exception

            if([int]$exception.ErrorCode -eq [int][system.net.httpstatuscode]::Forbidden)
            {
                Write-VerboseLog ("Command [{0}] failed Authorization. Attempt {1}. Exception: {2}" -f $ScriptBlock, $attempt,$exception.Message)
                throw
            }
            else
            {
                if ($attempt -ge $Attempts)
                {
                    Write-VerboseLog ("Command [{0}] failed the maximum number of {1} attempts. Exception: {2}" -f $ScriptBlock, $attempt,$exception.Message)
                    throw
                }
                else
                {
                    $secondsDelay = $MinWaitTimeInSeconds + [int]([Math]::Pow($BaseBackoffTimeInSeconds,($attempt-1)))

                    if($secondsDelay -gt $MaxWaitTimeInSeconds)
                    {
                        $secondsDelay = $MaxWaitTimeInSeconds
                    }

                    Write-VerboseLog ("Command [{0}] failed. Retrying in {1} seconds. Exception: {2}" -f $ScriptBlock, $secondsDelay,$exception.Message)
                    Start-Sleep $secondsDelay
                }
            }
        }
    }

    return $result
}

function Get-PortalDomain{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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


function Get-PortalHCIResourcePageUrl{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [string] $ResourceName,
    [string] $SubscriptionId,
    [string] $ResourceGroupName
    )

    return "/Subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.AzureStackHCI/clusters/" + $ResourceName
}

function Import-DependentModule
{
    param (
        [string] $ModuleName,
        [string] $MinVersion
    )
    $module = Get-Module -Name $ModuleName
    if ((-not $module) -or ($module.Version -lt [System.Version]$MinVersion)) 
    {
        Write-VerboseLog "Required module $ModuleName (minimum version: $MinVersion) is not imported"
        try 
        {
            # Adding this statement to clear all the versions that exist in the current PS session
            Remove-Module -Name $ModuleName -ErrorAction Ignore
            
            Import-Module -Name $ModuleName -MinimumVersion $MinVersion
        }
        catch
        {
            Write-WarnLog "$_.Exception"
            Write-VerboseLog "Required module $ModuleName (minimum version: $MinVersion) is missing"
            throw ("$ModuleName (minimum version: $MinVersion)")
        }
    }
}

function Check-DependentModules 
{
    param()

    $missingDependentModules = [System.Collections.ArrayList]::new()

    # Checking if Az.Accounts is imported
    try 
    {
        Write-VerboseLog "Importing dependent module Az.Accounts"
        Import-DependentModule -ModuleName "Az.Accounts" -MinVersion $AzAccountsModuleMinVersion
    }
    catch 
    {
        $missingDependentModules.Add($_.Exception.Message) | Out-Null
    }

    # Checking if Az.Resources is imported
    try 
    {
        Write-VerboseLog "Importing dependent module Az.Resources"
        Import-DependentModule -ModuleName "Az.Resources" -MinVersion $AzResourcesModuleMinVersion
    }
    catch 
    {
        $missingDependentModules.Add($_.Exception.Message) | Out-Null
    }
    
    if($missingDependentModules.Length -gt 0)
    {
        $missingDependentModules = $missingDependentModules -join ", "
        $MissingDependentModulesExceptionMessage = $MissingDependentModulesError -f $missingDependentModules
        throw $MissingDependentModulesExceptionMessage
    }
}

function Azure-Login{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
    
    Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -status $LoggingInToAzureMessage -percentcomplete 30

    if($EnvironmentName -eq $AzurePPE)
    {
        Write-VerboseLog ("Setting up AzurePPE AzEnvironment")
        Add-AzEnvironment -Name $AzurePPE -PublishSettingsFileUrl "https://windows.azure-test.net/publishsettings/index" -ServiceEndpoint "https://management-preview.core.windows-int.net/" -ManagementPortalUrl "https://windows.azure-test.net/" -ActiveDirectoryEndpoint "https://login.windows-ppe.net/" -ActiveDirectoryServiceEndpointResourceId "https://management.core.windows.net/" -ResourceManagerEndpoint "https://api-dogfood.resources.windows-int.net/" -GalleryEndpoint "https://df.gallery.azure-test.net/" -GraphEndpoint "https://graph.ppe.windows.net/" -GraphAudience "https://graph.ppe.windows.net/" | Out-Null
    }

    $ConnectAzureADEnvironmentName = $EnvironmentName
    $ConnectAzAccountEnvironmentName = $EnvironmentName

    if($EnvironmentName -eq $AzureCanary)
    {
        Write-VerboseLog ("Setting up {0} AzEnvironment" -f $AzureCanary)
        $ConnectAzureADEnvironmentName = $AzureCloud

        if([string]::IsNullOrEmpty($Region))
        {
            $Region = Get-DefaultRegion -EnvironmentName $EnvironmentName
            Write-VerboseLog ("{0} region resolves to {1}" -f $AzureCanary,$Region)
        }

        # Normalize region name
        $Region = Normalize-RegionName -Region $Region

        $ConnectAzAccountEnvironmentName = ($AzureCanary + $Region)

        $azEnv = (Get-AzEnvironment -Name $AzureCloud)
        $azEnv.Name = $ConnectAzAccountEnvironmentName
        $azEnv.ResourceManagerUrl = ('https://{0}.management.azure.com/' -f $Region)
        $azEnv | Add-AzEnvironment -MicrosoftGraphEndpointResourceId "https://graph.microsoft.com" -MicrosoftGraphUrl "https://graph.microsoft.com" | Out-Null
        Write-VerboseLog ("$AzureCanary env details: : {0}" -f ($azEnv | Out-String))
    }

    Disconnect-AzAccount -ErrorAction Ignore | Out-Null

    if([string]::IsNullOrEmpty($ArmAccessToken) -or [string]::IsNullOrEmpty($AccountId))
    {
        # Interactive login

        $IsIEPresent = Test-Path "$env:SystemRoot\System32\ieframe.dll"

        if([string]::IsNullOrEmpty($TenantId))
        {
            Write-VerboseLog ("attempting login without TenantID")
            if(($UseDeviceAuthentication -eq $false) -and ($IsIEPresent))
            {
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    SubscriptionId = $SubscriptionId
                    Scope = "Process"
                }
            }
            else # Use -UseDeviceAuthentication as IE Frame is not available to show Azure login popup
            {
                Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -Completed # Hide progress activity as it blocks the console output
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    SubscriptionId = $SubscriptionId
                    Scope = "Process"
                    UseDeviceAuthentication = $true
                }
            }
        }
        else
        {
            Write-VerboseLog ("Attempting login with TenantID: $TenantId")
            if(($UseDeviceAuthentication -eq $false) -and ($IsIEPresent))
            {
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    SubscriptionId = $SubscriptionId
                    TenantId = $TenantId
                    Scope = "Process"
                }
            }
            else # Use -UseDeviceAuthentication as IE Frame is not available to show Azure login popup
            {
                Write-Progress -Id $MainProgressBarId -activity $ProgressActivityName -Completed # Hide progress activity as it blocks the console output
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    SubscriptionId = $SubscriptionId
                    TenantId = $TenantId
                    UseDeviceAuthentication = $true
                    Scope = "Process"
                }
            }
        }
        Write-InfoLog $(Print-FunctionParameters -Message "Connect-AzAccount" -Parameters $AZConnectParams)
        Connect-AzAccount @AZConnectParams | Out-Null
        $azContext = Get-AzContext
        $TenantId = $azContext.Tenant.Id
    }
    else
    {
        Write-VerboseLog ("Non-interactive Login")

        if([string]::IsNullOrEmpty($TenantId))
        {
            Write-VerboseLog ("attempting login without TenantID")
            if(-not [string]::IsNullOrEmpty($GraphAccessToken))
            {
                Write-VerboseLog ("Using Graph AccessToken")
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    SubscriptionId = $SubscriptionId
                    AccessToken = $ArmAccessToken
                    AccountId = $AccountId
                    GraphAccessToken = $GraphAccessToken
                    Scope = "Process"
                }
            }
            else
            {
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    SubscriptionId = $SubscriptionId
                    AccessToken = $ArmAccessToken
                    AccountId = $AccountId
                    Scope = "Process"
                }
            }
        }
        else
        {
            Write-VerboseLog ("attempting login with TenantID")
            if( -not [string]::IsNullOrEmpty($GraphAccessToken))
            {
                Write-VerboseLog ("Using Graph AccessToken")

                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    TenantId = $TenantId
                    SubscriptionId = $SubscriptionId
                    AccessToken = $ArmAccessToken
                    AccountId = $AccountId
                    GraphAccessToken = $GraphAccessToken
                    Scope = "Process"
                }
            }
            else
            {
                $AZConnectParams = @{
                    Environment = $ConnectAzAccountEnvironmentName
                    TenantId = $TenantId
                    SubscriptionId = $SubscriptionId
                    AccessToken = $ArmAccessToken
                    AccountId = $AccountId
                    Scope = "Process"
                }
            }
        }
        Write-InfoLog $(Print-FunctionParameters -Message "Connect-AzAccount" -Parameters $AZConnectParams)
        Connect-AzAccount @AZConnectParams | Out-Null
        $azContext = Get-AzContext
        $TenantId = $azContext.Tenant.Id
    }

    return $TenantId
}

function Normalize-RegionName{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [string] $Region
    )
    $regionName = $Region -replace '\s',''
    $regionName = $regionName.ToLower()
    return $regionName
}

function Validate-RegionName{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [string] $Region,
    [ref] $SupportedRegions
    )
    $locations = Retry-Command -ScriptBlock { (Get-AzResourceProvider -ProviderNamespace Microsoft.AzureStackHCI).Where{($_.ResourceTypes.ResourceTypeName -eq 'clusters' -and $_.RegistrationState -eq 'Registered')}.Locations } -RetryIfNullOutput $true
    Write-VerboseLog ("RP supported regions : $locations")
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
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [System.Management.Automation.Runspaces.PSSession] $Session
    )

    $clusterNameResourceGUID = Invoke-Command -Session $Session -ScriptBlock { (Get-ItemProperty -Path HKLM:\Cluster -Name ClusterNameResource).ClusterNameResource }
    $clusterDNSSuffix = Invoke-Command -Session $Session -ScriptBlock { (Get-ClusterResource $using:clusterNameResourceGUID | Get-ClusterParameter DnsSuffix).Value }
    return $clusterDNSSuffix
}

function Register-ResourceProviderIfRequired{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [string] $ProviderNamespace
)
    $rpState = Get-AzResourceProvider -ProviderNamespace $ProviderNamespace
    $notRegisteredResourcesForRP = ($rpState.Where({$_.RegistrationState  -ne "Registered"}) | Measure-Object ).Count
    if ($notRegisteredResourcesForRP -eq 0 )
    { 
        Write-VerboseLog("$ProviderNamespace RP already registered, skipping registration")
    } 
    else
    {
        try
        {
            Register-AzResourceProvider -ProviderNamespace $ProviderNamespace | Out-Null
            Write-VerboseLog ("registered Resource Provider: $ProviderNamespace ")
        }
        catch
        {
            Write-ErrorLog -Exception $_ -Message "Exception occured while registering $ProviderNamespace RP" -ErrorAction Continue  
            throw 
        }
    }
}
function Get-ClusterDNSName{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [System.Management.Automation.Runspaces.PSSession] $Session
    )

    $clusterNameResourceGUID = Invoke-Command -Session $Session -ScriptBlock { (Get-ItemProperty -Path HKLM:\Cluster -Name ClusterNameResource).ClusterNameResource }
    $clusterDNSName = Invoke-Command -Session $Session -ScriptBlock { (Get-ClusterResource $using:clusterNameResourceGUID | Get-ClusterParameter DnsName).Value }
    return $clusterDNSName
}

function Check-ConnectionToCloudBillingService{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
                Write-VerboseLog ("StatusCode of invoking cloud billing service health endpoint on node " + $clusNode.Name + " : " + $healthResponse.StatusCode)
                $HealthEndPointCheckFailedNodes.Add($clusNode.Name) | Out-Null
                continue
            }
        }
        catch
        {
            Write-VerboseLog ("Exception occurred while testing health endpoint connectivity on Node: " + $clusNode.Name + " Exception: " + $_.Exception)
            $HealthEndPointCheckFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }
    }
}

function Setup-Certificates{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
    [string] $ClusterDNSSuffix,
    [string] $ResourceId
    )

    $userProvidedCertAdded = $false
    $certificatesToUpload = [System.Collections.ArrayList]::new()

    #1. Gather certificate from each node or check if user cert installed
    Foreach ($clusNode in $ClusterNodes)
    {
        $nodeSession = $null

        Write-VerboseLog ("Setting up certificate for node : {0}" -f $clusNode.Name)
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
            Write-VerboseLog ("Exception occurred in establishing new PSSession to node $($clusNode.Name). ErrorMessage : " + $_.Exception.Message)
            Write-VerboseLog ($_)
            $NewCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            $SetCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }

        # Check if all nodes have required OS version
        $nodeUBR = Invoke-Command -Session $nodeSession -ScriptBlock { (Get-ItemProperty -path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion").UBR }
        $nodeBuildNumber = Invoke-Command -Session $nodeSession -ScriptBlock { (Get-CimInstance -ClassName CIM_OperatingSystem).BuildNumber }

        if(($nodeBuildNumber -lt $GAOSBuildNumber) -or (($nodeBuildNumber -eq $GAOSBuildNumber) -and ($nodeUBR -lt $GAOSUBR)))
        {
            Write-VerboseLog ("$($clusNode.Name) does not have latest build number UBR: $nodeUBR, BuildNumber: $nodeBuildNumber")
            $OSNotLatestOnNodes.Add($clusNode.Name) | Out-Null
            continue
        }

        if([string]::IsNullOrEmpty($CertificateThumbprint))
        {
            # User did not specify certificate, using self-signed certificate
            try
            {
                $certBase64 = Invoke-Command -Session $nodeSession -ScriptBlock { New-AzureStackHCIRegistrationCertificate }
                Write-VerboseLog ("Node certificate generation successful")
            }
            catch
            {
                Write-VerboseLog ("Exception occurred in New-AzureStackHCIRegistrationCertificate. ErrorMessage : " + $_.Exception.Message)
                Write-VerboseLog ($_)
                $NewCertificateFailedNodes.Add($clusNode.Name) | Out-Null
                continue
            }
        }
        else
        {
            Write-VerboseLog ("using user specified Certificate")
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
                Write-VerboseLog ("$CertificateNotFoundErrorMessage")
                return $CertificateNotFoundErrorMessage
            }

            # Certificate should be valid for atleast 60 days from now
            $60days = New-TimeSpan -Days 60
            $expectedValidTo = (Get-Date) + $60days

            if($x509Cert.NotAfter -lt $expectedValidTo)
            {
                $UserCertificateValidationErrorMessage = ($UserCertValidationErrorMessage -f $CertificateThumbprint, $x509Cert.NotAfter)
                Write-VerboseLog ("$UserCertificateValidationErrorMessage")
                return $UserCertificateValidationErrorMessage
            }

            $certBase64 = [System.Convert]::ToBase64String($x509Cert.Export([Security.Cryptography.X509Certificates.X509ContentType]::Cert))
        }

        $Cert = [System.Security.Cryptography.X509Certificates.X509Certificate2]([System.Convert]::FromBase64String($CertBase64))

        # If user provided cert is not already added to AAD app or if we are using one certificate per node
        if(($userProvidedCertAdded -eq $false) -or ([string]::IsNullOrEmpty($CertificateThumbprint)))
        {
            $AddAppCredentialMessageProgress = $AddAppCredentialMessage -f $ResourceName
            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $AddAppCredentialMessageProgress -percentcomplete 80
            $certificatesToUpload.Add($CertBase64) | Out-Null
            $userProvidedCertAdded = $true
            Write-VerboseLog ("successfully verified KeyCredentials added to list")
        }
    }

    #2. Upload certificate to AAD via RP service
    $parameters = @{properties = @{certificates = $certificatesToUpload}}
    $uploadResponse = Execute-Without-ProgressBar -ScriptBlock { Invoke-AzResourceAction -ResourceId $resourceId -Parameters $parameters -ApiVersion $RPAPIVersion -Action uploadCertificate -Force }
    #3. Test certificate on each node
    Foreach ($clusNode in $ClusterNodes)
    {
        $nodeSession = $null

        Write-VerboseLog ("Testing certificate for node : {0}" -f $clusNode.Name)
        try
        {
            if($Credential -eq $Null)
            {
                $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $ClusterDNSSuffix)
            
            }else
            {
                $nodeSession = New-PSSession -ComputerName ($clusNode.Name + "." + $ClusterDNSSuffix) -Credential $Credential
            }
        }
        catch
        {
            Write-VerboseLog ("Exception occurred in establishing new PSSession to node $($clusNode.Name). ErrorMessage : " + $_.Exception.Message)
            Write-VerboseLog ($_)
            $NewCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            $SetCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }

        # Set the certificate - Certificate will be set after testing the certificate by calling cloud service API
        try
        {
            $Params = @{
                        ServiceEndpoint = $ServiceEndpoint
                        BillingServiceApiScope = $BillingServiceApiScope
                        GraphServiceApiScope = $GraphServiceApiScope
                        AADAuthority = $Authority
                        AppId = $AppId
                        TenantId = $TenantId
                        CloudId = $CloudId
                        CertificateThumbprint = $CertificateThumbprint
                    }

            $SetAzureStackHCIRegistrationCertificateScript = {
                Set-AzureStackHCIRegistrationCertificate -ErrorAction Stop @Params
            }

            Run-InvokeCommand -ScriptBlock $SetAzureStackHCIRegistrationCertificateScript -Session $nodeSession -Params $Params

            Write-VerboseLog ("successfully updated authentication parameters on node: {0}" -f ($Params | Out-String))
        }
        catch
        {
            Write-VerboseLog ("Exception occurred in Set-AzureStackHCIRegistrationCertificate. ErrorMessage : " + $_.Exception.Message)
            $SetCertificateFailedNodes.Add($clusNode.Name) | Out-Null
            continue
        }
    }

    Write-VerboseLog ("Setup-Certificates succeeded, returning null")
    return $null
}
function Assign-ArcRoles {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [string] $SpObjectId
    )
    $stopLoop = $false
    [int]$retryCount = "0"
    [int]$maxRetryCount = "14"
    do {
        try
        {
            $arcSPNRbacRoles = Get-AzRoleAssignment -ObjectId $SpObjectId
            $foundConnectedMachineOnboardingRole=$false
            $foundMachineResourceAdminstratorRole=$false
            $arcSPNRbacRoles | ForEach-Object {
                $roleName = $_.RoleDefinitionName
                if ($roleName -eq $AzureConnectedMachineOnboardingRole)
                {
                    $foundConnectedMachineOnboardingRole=$true
                }
                elseif ($roleName -eq $AzureConnectedMachineResourceAdministratorRole)
                {
                    $foundMachineResourceAdminstratorRole=$true
                }
            }
            if( -not $foundConnectedMachineOnboardingRole)
            {
                New-AzRoleAssignment -ObjectId $SpObjectId -RoleDefinitionName $AzureConnectedMachineOnboardingRole | Out-Null
            }
            if( -not $foundMachineResourceAdminstratorRole)
            {
                New-AzRoleAssignment -ObjectId $SpObjectId -RoleDefinitionName $AzureConnectedMachineResourceAdministratorRole | Out-Null
            }
            Write-VerboseLog ("successfully assigned RBAC Roles to ARC SP: {0}" -f $SpObjectId)
            $stopLoop = $true
        }
        catch
        {
            $positionMessage = $_.InvocationInfo.PositionMessage
            if ($retryCount -ge $maxRetryCount)
            {
                # Timed out.
                Write-WarnLog ("Failed to assign roles to service principal with object Id $($SpObjectId). ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage)
                return $false
            }
            if ($_.Exception.Response.Content.Contains("Microsoft.Authorization/roleAssignments/write")) {
                Write-VerboseLog ("New-AzRoleAssignment Missing Permissions. IsWAC: $IsWAC")
                if ($IsWAC -eq $false)
                {
                    # Insufficient privilige error.
                    Write-ErrorLog -Message $ArcAgentRolesInsufficientPreviligeMessage -Exception $_ -ErrorAction Continue
                }
                return $false
            }
            # Service principal creation hasn't propogated fully yet, usually takes 10-20 seconds.
            Write-VerboseLog ("Could not assign roles to service principal with Object Id $($SpObjectId). Retrying in 10 seconds...")
            Start-Sleep -Seconds 10
            $retryCount = $retryCount + 1
        }
    }
    While (-Not $stopLoop)
    return $true
}

function Verify-ArcSettings{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [string] $ArcResourceId,
        [System.Management.Automation.Runspaces.PSSession] $Session
    )
    Write-VerboseLog "Verifying Arc settings resource"
    $verifyArcSettingsOutput = [ErrorDetail]::ArcIntegrationFailedOnNodes
    $clusterNodes = Invoke-Command -Session $Session -ScriptBlock { Get-ClusterNode } | ForEach-Object { ($_.Name) }
    $limit = (Get-Date).AddMinutes($GetArcSettingsWaitTimeMinutes)

    while ((Get-Date) -lt $limit) {
        if($verifyArcSettingsOutput -eq [ErrorDetail]::ArcIntegrationFailedOnNodes)
        {
            Write-VerboseLog "Waiting for $GetArcSettingsSleepTimeSeconds seconds"
            Start-Sleep -Seconds $GetArcSettingsSleepTimeSeconds
        }
        else 
        {
            Write-VerboseLog "Arc settings resource successfully verified"
            break
        }
        $verifyArcSettingsOutput = [ErrorDetail]::Success
    
        $arcSettingsResponse = Get-AzResource -ResourceId $ArcResourceId -ApiVersion $HCIArcAPIVersion
    
        $arcSettingsNodesMap = @{}
        $arcSettingsResponse.properties.perNodeDetails | ForEach-Object { $arcSettingsNodesMap.Add($_.Name, $_.State) } | Out-Null

        Foreach ($clusterNode in $clusterNodes)
        {
            if((($arcSettingsNodesMap.Contains($clusterNode) -eq $false) | Out-Null) -or ($arcSettingsNodesMap[$clusterNode] -ne "Connected"))
            {
                Write-VerboseLog "Cluster node : $clusterNode is not in connected state in ArcSettings."
                $verifyArcSettingsOutput = [ErrorDetail]::ArcIntegrationFailedOnNodes
            }
        }
    }
    return $verifyArcSettingsOutput
}

function Verify-ArcRegistration{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [string] $ArcResourceId,
        [System.Management.Automation.Runspaces.PSSession] $Session,
        [bool] $IsManagementNode,
        [System.Management.Automation.PSCredential] $Credential,
        [string] $ComputerName
    )
    Write-VerboseLog "Verifying Arc for Servers registration"
    # Get and verify Arc Settings resource
    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $VerifyingArcMessage -PercentComplete 0

    $arcRegistrationOutput = Verify-ArcSettings -Session $Session -ArcResourceId $ArcResourceId
    $arcSettingsVerificationCount = 1

    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $VerifyingArcMessage -PercentComplete 10
    
    
    while($arcSettingsVerificationCount -lt ($ArcSettingsVerificationLimit + 1 ))
    {
        if($arcRegistrationOutput -eq [ErrorDetail]::ArcIntegrationFailedOnNodes)
        {
            Write-VerboseLog "Unable to find the cluster nodes in Arc Settings resource. Triggering Sync-AzureStackHCI again."
            # Trigger Sync-AzureStackHCI to patch Arc settings
            Invoke-Command -Session $Session -ScriptBlock { Sync-AzureStackHCI }

            # Get and verify Arc Settings resource
            $arcRegistrationOutput = Verify-ArcSettings -Session $Session -ArcResourceId $ArcResourceId
            Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $VerifyingArcMessage -PercentComplete $($arcSettingsVerificationCount * 20)
        }
        else 
        {
            break    
        }
        $arcSettingsVerificationCount++
    }

    if($arcRegistrationOutput -eq [ErrorDetail]::ArcIntegrationFailedOnNodes)
    {
        Write-VerboseLog $ArcSettingsPatchFailedLogMessage
        Write-NodeEventLog -Message $ArcSettingsPatchFailedLogMessage -EventID 9123 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
        Write-Warning $ArcSettingsPatchFailedWarningMessage
    }
    else
    {
        Write-VerboseLog "Successfully verified Arc for Servers registration. Arc for Servers registration succeeded."
    }

    return $arcRegistrationOutput
}

function Verify-NodesArcRegistrationState{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        $ClusterNodes,
        [string] $SubscriptionId,
        [string] $ArcResourceGroupName,
        [System.Management.Automation.PSCredential] $Credential,
        [string] $ClusterDNSSuffix
    )
    $NodesAlreadyArcEnabledDifferentResource = [System.Collections.ArrayList]::new()

    foreach ($clusterNode in $clusterNodes)
    {
        # Create session into the cluster node
        $clusterNodeWithDNSSuffix = "$clusterNode.$ClusterDNSSuffix"
        if($Null -eq $Credential)
        {
            $nodeSession = New-PSSession -ComputerName $clusterNodeWithDNSSuffix
        }
        else
        {
            $nodeSession = New-PSSession -ComputerName $clusterNodeWithDNSSuffix -Credential $Credential
        }

        try
        {
            Invoke-Command -Session $nodeSession -ScriptBlock $CheckNodeArcRegistrationStateScriptBlock -ErrorAction Stop
        }
        catch 
        {
            if(($null -ne $_.Exception.Message) -and $_.Exception.Message.Contains($clusterNode) -and $_.Exception.Message.Contains("Subscription Id") -and $_.Exception.Message.Contains("Resource Group"))
            {
                $NodesAlreadyArcEnabledDifferentResource.Add($_.Exception.Message) | Out-Null
            }
            else
            {
                Write-WarnLog $_.Exception.Message
            }
        }

        # Cleanup node session
        Remove-PSSession $nodeSession | Out-Null 
    }

    if($NodesAlreadyArcEnabledDifferentResource.Length -gt 0)
    {
        $NodesAlreadyArcEnabledDifferentResource = $NodesAlreadyArcEnabledDifferentResource -join "`n"
        $ExceptionMessage = $ArcAlreadyEnabledInADifferentResourceError -f $NodesAlreadyArcEnabledDifferentResource
        throw $ExceptionMessage
    }
}

function Enable-ArcForServers{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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

            if (($null -ne $nodeStatus) -and ($nodeStatus.Count -ge $clusterNodeNames.Count))
            {
                Foreach ($node in $nodeStatus.Keys)
                {
                    if($nodeStatus[$node] -ne $using:enabledArcStatus)
                    {
                        throw $using:RegisterArcFailedExceptionMessage
                    }
                }
            }
            else
            {
                throw $using:RegisterArcFailedExceptionMessage
            }
        }
    }
    catch
    {
        Write-ErrorLog ($RegisterArcFailedErrorMessage)
        $retStatus = [ErrorDetail]::ArcIntegrationFailedOnNodes
        throw $RegisterArcFailedErrorMessage
    }

    # Cleanup sessions.
    Remove-PSSession $clusterNodeSessions | Out-Null

    return $retStatus
}

function Disable-ArcForServers{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [System.Management.Automation.Runspaces.PSSession] $Session,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $ClusterDNSSuffix
    )

    $res = $true
    $AgentUninstaller_LogFile = $env:windir + '\Tasks\ArcForServers' + '\ConnectedMachineAgentUninstallationLog.txt';
    $AgentInstaller_Name      = $env:windir + '\Tasks\ArcForServers' + '\AzureConnectedMachineAgent.msi';
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

    $nodeArcStatus = Invoke-Command -Session $Session -ScriptBlock { $(Get-AzureStackHCIArcIntegration)}
    if($nodeArcStatus.ClusterArcStatus -eq [ArcStatus]::Disabled)
    {
        Write-VerboseLog ("Arc already disabled on $clusterNodeNames")
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
        Write-VerboseLog ("Exception occurred in un-registering nodes from Arc For Servers. ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage)
        Write-VerboseLog ($_)
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
                Write-ErrorLog -Message $UnregisterArcFailedErrorMessage -ErrorAction Continue
            }
        }
    }

    # Cleanup sessions.
    Remove-PSSession $clusterNodeSessions | Out-Null
    return $res
}

function Register-ArcForServers{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [bool] $IsManagementNode,
    [string] $ComputerName,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $TenantId,
    [string] $SubscriptionId,
    [string] $ResourceGroup,
    [string] $Region,
    [string] $ClusterDNSSuffix,
    [System.Management.Automation.PSCredential] $ArcSpnCredential,
    [Switch] $IsWAC,
    [string] $Environment,
    [Object] $ArcResource
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
    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $FetchingRegistrationState -PercentComplete 1
    
    # Register resource providers
    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $RegisterArcRPMessage -PercentComplete 10
    Write-VerboseLog ("$RegisterArcRPMessage")
    Register-ResourceProviderIfRequired -ProviderNamespace "Microsoft.HybridCompute"
    Register-ResourceProviderIfRequired -ProviderNamespace "Microsoft.GuestConfiguration"

    if( ($Environment -eq $AzureCanary) -or ($Environment -eq $AzureCloud) )
    {
        Write-VerboseLog ("Registering Microsoft.HybridConnectivity Resource provider")
        Register-ResourceProviderIfRequired -ProviderNamespace "Microsoft.HybridConnectivity"    
    }

    if($ArcSpnCredential -ne $Null)
    {
        ## Arc spn and password is provided
        $AppId = $ArcSpnCredential.UserName
        $Secret = $ArcSpnCredential.GetNetworkCredential().Password
        Write-VerboseLog ("ARC Spn and password provided")
        $arcSPN = Retry-Command -ScriptBlock { Get-AzADServicePrincipal -ApplicationId  $AppId -ErrorAction SilentlyContinue } -RetryIfNullOutput $false

        if(-Not [string]::IsNullOrEmpty($arcSPN)) # $arcSPN will be null if a user has registered using ArmAccessToken and AccountId
        {
            $rolesPresent = Verify-arcSPNRoles -arcSPNObjectID $arcSPN.Id
            if(-not $rolesPresent)
            {
                Write-VerboseLog ("Supplied ARC SPN: $($arcSPN.ID)  does not have required roles:$AzureConnectedMachineOnboardingRole and $AzureConnectedMachineResourceAdministratorRole. Aborting arc onboarding.")
                return [ErrorDetail]::ArcPermissionsMissing
            }
        }
        else
        {
            Write-VerboseLog "Unable to fetch ArcSpnCredential role assignments. Continuing without checking role assignments."
        }
    }
    else
    {
        if($Null -eq $ArcResource.Properties.arcApplicationObjectId)
        {
            Write-VerboseLog ("Initiating Arc AAD App creation by HCI RP")
            Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $RegisterArcProgressActivityName -Status $ArcAADAppCreationMessage -PercentComplete 30
            Execute-Without-ProgressBar -ScriptBlock { Invoke-AzResourceAction -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -Action createArcIdentity -Force } | Out-Null
            $ArcResource = Get-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -ErrorAction Ignore
            Write-VerboseLog ("Created Arc AAD App by HCI service")
        }
        else
        {
            Write-VerboseLog ("Arc AAD App: $ArcApplicationId already created by service")
        }
        $AppId = $ArcResource.Properties.arcApplicationClientId
        $ArcSpObjectId = $ArcResource.Properties.arcServicePrincipalObjectId
        $roleAssignmentStatus = Assign-ArcRoles -SpObjectId $ArcSpObjectId
        if($roleAssignmentStatus -eq $false)
        {
            return [ErrorDetail]::ArcPermissionsMissing
        }
        # Generate password for Arc SPN by calling HCI RP
        Write-VerboseLog("Generating credentials for ARC SPN")
        $arcSPNPassword = Execute-Without-ProgressBar -ScriptBlock { Invoke-AzResourceAction -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -Action generatePassword -Force }
        Write-VerboseLog("Generated credentials successfully for ARC SPN")
        $Secret = $arcSPNPassword.secretText 
        $clusterDNSName = Get-ClusterDNSName -Session $session
    }

    $arcCommand = Invoke-Command -Session $session -ScriptBlock { Get-Command -Name 'Initialize-AzureStackHCIArcIntegration' -ErrorAction SilentlyContinue } 
    if ($arcCommand.Parameters.ContainsKey('Cloud'))
    {
        $arcEnvironment = $Environment

        if( $Environment -eq $AzureCanary)
        {
            $arcEnvironment = $AzureCloud
        }
        Write-VerboseLog ("invoking Initialize-AzureStackHCIArcIntegration with cloud switch")
        $ArcRegistrationParams = @{
            AppId = $AppId
            Secret = $Secret
            TenantId = $TenantId
            SubscriptionId = $SubscriptionId
            Region = $Region
            ResourceGroup = $ResourceGroup
            cloud  = $arcEnvironment 
        }
    }
    else
    {
        Write-VerboseLog ("invoking Initialize-AzureStackHCIArcIntegration without cloud switch")
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
    Invoke-Command -Session $session -ScriptBlock { Initialize-AzureStackHCIArcIntegration @Using:ArcRegistrationParams } | Out-Null
    Write-VerboseLog ("successfully invoked Initialize-AzureStackHCIArcIntegration")
    # Register clustered scheduled task
    try
    {
        # Connect to cluster and use that session for registering clustered scheduled task
        Write-VerboseLog ("Registering Clustered Scheduled task for Arc Installation")
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
                Register-ClusteredScheduledTask -TaskName $using:ArcRegistrationTaskName -TaskType ClusterWide -Action $action -Trigger $dailyTrigger
            }
            else
            {
                # Update cluster schedule task.
                Set-ClusteredScheduledTask -TaskName $using:ArcRegistrationTaskName -Action $action -Trigger $dailyTrigger
            }
        } | Out-Null
    }
    catch
    {
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-ErrorLog ("Exception occurred in registering cluster scheduled task") -Exception $_ -Category OperationStopped -ErrorAction Continue
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

    if($arcResult -eq [ErrorDetail]::Success)
    {
        Write-VerboseLog ("Successfully registered cluster with Arc for Servers.")

        $arcResult = Verify-ArcRegistration -ArcResourceId $arcResourceId -Session $session -Credential $Credential -ComputerName $ComputerName -IsManagementNode $IsManagementNode
    }

    Write-Progress -Id $ArcProgressBarId -activity $RegisterArcProgressActivityName -Completed

    Remove-PSSession $session | Out-Null

    return $arcResult
}

function Verify-arcSPNRoles{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [string] $arcSPNObjectID
)
    $arcSPNRbacRoles = Get-AzRoleAssignment -ObjectId $arcSPNObjectID
    $foundConnectedMachineOnboardingRole=$false
    $foundMachineResourceAdminstratorRole=$false
    $arcSPNRbacRoles | ForEach-Object { 
        $roleName = $_.RoleDefinitionName
        if ($roleName -eq $AzureConnectedMachineOnboardingRole)
        {
            $foundConnectedMachineOnboardingRole=$true
        }
        elseif ($roleName -eq $AzureConnectedMachineResourceAdministratorRole)
        {
            $foundMachineResourceAdminstratorRole=$true
        }
    }
    
    return $foundMachineResourceAdminstratorRole -and $foundConnectedMachineOnboardingRole 
}
function Unregister-ArcForServers{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
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
        Write-VerboseLog ("connecting via Management node")
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
        Write-VerboseLog ("cluster does not support ARC yet, no operation")
        return $true
    }

    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $FetchingRegistrationState -PercentComplete 1
    $arcStatus = Invoke-Command -Session $session -ScriptBlock { Get-AzureStackHCIArcIntegration }
    $hciStatus = Invoke-Command -Session $session -ScriptBlock { Get-AzureStackHCI }
    $arcResourceId = $ResourceId + $HCIArcInstanceName
    $arcResourceExtensions = $arcResourceId + $HCIArcExtensions

    if ($arcStatus.ClusterArcStatus -eq [ArcStatus]::Enabled)
    {
        Invoke-Command -Session $session -ScriptBlock { Clear-AzureStackHCIArcIntegration -SetDisableInProgress} | Out-Null
        Write-VerboseLog ("Successfully executed Clear-AzureStackHCIArcIntegration")
    }

    $arcres = Get-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -ErrorAction Ignore

    if($arcres -ne $null)
    {
        Write-VerboseLog ("Disabling Azure Arc for Servers Mandatory extensions")
        Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $DisablingDefaultExtensions -PercentComplete 2
        Execute-Without-ProgressBar -ScriptBlock { Invoke-AzResourceAction -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -Action InitializeDisableProcess -Force } | Out-Null

        Write-VerboseLog ("querying installed extensions")
        $extensions = Get-AzResource -ResourceId $arcResourceExtensions -ApiVersion $HCIArcExtensionAPIVersion
        $ArcResourceGroupName = $arcres.Properties.arcInstanceResourceGroup
    }

    $extensionsCleanupSucceeded = $true

    if($extensions -ne $null)
    {
        # Remove extensions one by one. If -Force is passed write warning and proceed, else write error and stop
        for($extIndex = 0; $extIndex -lt $extensions.Count; $extIndex++)
        {
            $extension = $extensions[$extIndex]

            # Default extension not deleted completely
            if($extension.Properties.managedBy -eq "Azure")
            {
                Write-VerboseLog ("Mandatory extension: {0} is not deleted yet" -f $extensions.Name)
                continue
            }

            try
            {
                $DeletingExtensionMessageProgress = $DeletingExtensionMessage -f $extension.Name, $clusterName
                Write-VerboseLog ("$DeletingExtensionMessageProgress")
                $ProgressRange = 27 # Difference between previous and next progress number
                $PercentComplete = [Math]::Round( 3 + ((($extIndex+1)/($extensions.Count)) * $ProgressRange) )
                Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $DeletingExtensionMessageProgress -PercentComplete $PercentComplete
                Execute-Without-ProgressBar -ScriptBlock { Remove-AzResource -ResourceId $extension.ResourceId -ApiVersion $HCIArcExtensionAPIVersion -Force -ErrorAction Stop | Out-Null } 
                Write-VerboseLog ("completed extension deletion {0}" -f $extension.Name)
            }
            catch
            {
                $extensionsCleanupSucceeded = $false
                $positionMessage = $_.InvocationInfo.PositionMessage
                Write-VerboseLog ("Exception occurred in removing extension " + $extension.Name + ". ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $positionMessage)

                if($Force -eq $true)
                {
                    $ArcExtensionCleanupFailedWarningMsg = $ArcExtensionCleanupFailedWarning -f $extension.Name
                    Write-WarnLog ($ArcExtensionCleanupFailedWarningMsg)
                }
                else
                {
                    $ArcExtensionCleanupFailedErrorMsg = $ArcExtensionCleanupFailedError -f $extension.Name
                    Write-ErrorLog -Message $ArcExtensionCleanupFailedErrorMsg -Exception $_ -ErrorAction Continue
                }
            }
        }
    }

    if(($Force -eq $false) -and ($extensionsCleanupSucceeded -eq $false))
    {
        Write-VerboseLog ("not completing ARC unregistration because of failures")
        return $false
    }

    # Clean up clustered scheduled task, if it exists.
    try
    {
        # Connect to cluster and use that session for Unregistering clustered scheduled task
        if($Credential -eq $Null)
        {
            $clusterNameSession = New-PSSession -ComputerName ($clusterDNSName + "." + $ClusterDNSSuffix)
        }
        else
        {
            $clusterNameSession = New-PSSession -ComputerName ($clusterDNSName + "." + $ClusterDNSSuffix) -Credential $Credential
        }
        Write-VerboseLog ("cleaning up cluster scheduled task")
        Invoke-Command -Session $clusterNameSession -ScriptBlock {
            $task =  Get-ScheduledTask -TaskName $using:ArcRegistrationTaskName -ErrorAction SilentlyContinue
            if ($task)
            {
                Unregister-ClusteredScheduledTask -TaskName $using:ArcRegistrationTaskName
            }
        } | Out-Null
    }
    catch
    {
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-ErrorLog ("Exception occurred in unregistering cluster scheduled task") -Exception $_ -Category OperationStopped -ErrorAction Continue
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
        $arcResource = Get-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -ErrorAction Ignore

        if($arcResource -ne $Null)
        {
            $DeletingArcCloudResourceMessageProgress = $DeletingArcCloudResourceMessage -f $arcResourceId
            Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $DeletingArcCloudResourceMessageProgress -PercentComplete 40
            Execute-Without-ProgressBar -ScriptBlock {Remove-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -Force | Out-Null } 
            if(($Null -ne $arcStatus) -and ($Null -ne $arcStatus.ApplicationId))
            {
                $arcAADApplication = Get-AzADApplication -ApplicationId $arcStatus.ApplicationId -ErrorAction:SilentlyContinue
                if($Null -ne $arcAADApplication)
                {
                    # when registration happens via older version of the registration script and unregistration happens via newever version
                    # service will not be able to delete the app since it does not own it.
                    try 
                    {
                        Write-VerboseLog ("Deleting ARC AAD application: $($arcStatus.ApplicationId)")
                        Remove-AzADApplication -ApplicationId $arcStatus.ApplicationId -ErrorAction Stop | Out-Null
                    }
                    catch 
                    {
                        #consume exception, this is best effort. Log warning and continue if it fails.
                        $msg = "Deleting ARC AAD application Failed $($arcStatus.ApplicationId) . ErrorMessage : {0}. Please delete it manually." -f ($_.Exception.Message)
                        Write-NodeEventLog -Message $msg  -EventID 9011 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
                        Write-WarnLog ($msg)
                    }
                }
                
            }
            else
            {
                Write-VerboseLog ("ARC not enabled on the cluster, ignoring ARC application deletion check")
            }
        }

        if ($arcStatus.ClusterArcStatus -ne [ArcStatus]::Disabled)
        {
            Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -Activity $UnregisterArcProgressActivityName -Status $CleanArcMessage -PercentComplete 80
            Invoke-Command -Session $session -ScriptBlock { Clear-AzureStackHCIArcIntegration }

            Write-VerboseLog ("Successfully unregistered cluster from Arc for Servers")
        }

        if (-not([string]::IsNullOrEmpty($ArcResourceGroupName))) 
        {
            # Removing Arc onboarding permissions from HCI RP App on Arc resource group 
            Remove-ArcRoleAssignments -ResourceGroupName $ArcResourceGroupName -ResourceId $ResourceId | Out-Null

            Remove-ResourceGroup -ResourceGroupName $ArcResourceGroupName
        }
    }

    Write-Progress -Id $ArcProgressBarId -ParentId $MainProgressBarId -activity $UnregisterArcProgressActivityName -Completed
    return $disabled
}

class Identity {
    [string] $type = "SystemAssigned"
}

class ResourceProperties {
    [string] $location
    [object] $properties
    [System.Collections.Hashtable] $tags
    [Identity] $identity = [Identity]::new()

    ResourceProperties (
        [string] $location,
        [object] $properties,
        [System.Collections.Hashtable] $tags
    )
    {
        $this.location = $location
        $this.properties = $properties
        $this.tags = $tags
    }
}

enum OperationStatus 
{
    Unused;
    Failed;
    Success;
    Cancelled;
    RegisterSucceededButArcFailed;
    ArcFailed
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
    Specifies the Azure Subscription to create the resource. SubscriptionId is a Mandatory parameter.

    .PARAMETER Region
    Specifies the Region to create the resource. Region is a Mandatory parameter.

    .PARAMETER ResourceName
    Specifies the resource name of the resource created in Azure. If not specified, on-premises cluster name is used.

    .PARAMETER Tag
    Specifies the resource tags for the resource in Azure in the form of key-value pairs in a hash table. For example: @{key0="value0";key1=$null;key2="value2"}

    .PARAMETER TenantId
    Specifies the Azure TenantId.

    .PARAMETER ResourceGroupName
    Specifies the Azure Resource Group name. If not specified <LocalClusterName>-rg will be used as resource group name.

    .PARAMETER ArmAccessToken
    Specifies the ARM access token. Specifying this along with AccountId will avoid Azure interactive logon.

    .PARAMETER GraphAccessToken
    GraphAccessToken is deprecated.

    .PARAMETER AccountId
    Specifies the Account Id. Specifying this along with ArmAccessToken will avoid Azure interactive logon.

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
    
    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .PARAMETER IsWAC
    Registrations through Windows Admin Center specifies this parameter to true.

    .PARAMETER ArcServerResourceGroupName
    Specifies the Arc Resource Group name. If not specified, cluster resource group name will be used.

     .PARAMETER ArcSpnCredential
    Specifies the credentials to be used for onboarding ARC agent. If not specified, new set of credentials will be generated.
    
    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Result: Success or Failed or Cancelled.
    ResourceId: Resource ID of the resource created in Azure.
    PortalResourceURL: Azure Portal Resource URL.

    .EXAMPLE
    Invoking on one of the cluster node.
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -Region "eastus"
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster1-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster1
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster1-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster1/overview

    .EXAMPLE
    Invoking from the management node
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ComputerName ClusterNode1 -Region "eastus"
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster2-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster2
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster2-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster2/overview

    .EXAMPLE
    Invoking from WAC
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -AccountId user1@corp1.com -Region westus -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCIRG/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster3
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCIRG/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster3/overview

    .EXAMPLE
    Invoking with all the parameters
    C:\PS>Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -Region westus -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciRG -ArcServerResourceGroupName HciRG -ArmAccessToken eerrer..ere= -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential    
    Result: Success
    ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/HciRG/providers/Microsoft.AzureStackHCI/clusters/HciCluster1
    PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/HciRG/providers/Microsoft.AzureStackHCI/clusters/HciCluster1/overview
#>
function Register-AzStackHCI{
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
param(
    [Parameter(Mandatory = $true)]
    [string] $SubscriptionId,

    [Parameter(Mandatory = $true)]
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
    [System.Management.Automation.PSCredential] $Credential, 

    [Parameter(Mandatory = $false)]
    [Switch]$IsWAC,

    [Parameter(Mandatory = $false)]
    [string] $ArcServerResourceGroupName,

    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $ArcSpnCredential
    )
    
    if([string]::IsNullOrEmpty($ComputerName))
    {
        $ComputerName = [Environment]::MachineName
        $IsManagementNode = $False
    }
    else
    {
        $IsManagementNode = $True
    }

    try
    {
        Setup-Logging -LogFilePrefix "RegisterHCI" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")

        $registrationOutput = New-Object -TypeName PSObject
        $operationStatus = [OperationStatus]::Unused
        
        Show-LatestModuleVersion

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $CheckingDependentModules -percentcomplete 1
        Check-DependentModules

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $FetchingRegistrationState -percentcomplete 2
        if($IsManagementNode)
        {
            Write-VerboseLog ("Connecting via Management Node")
            if($Credential -eq $Null)
            {
                Write-VerboseLog ("Connecting without credentials")
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName
            }
            else
            {
                Write-VerboseLog ("Connecting to $ComputerName with credentials")
                $clusterNodeSession = New-PSSession -ComputerName $ComputerName -Credential $Credential
            }
        }
        else
        {
            $clusterNodeSession = New-PSSession -ComputerName localhost
        }

        $msg = Print-FunctionParameters -Message "Register-AzStackHCI" -Parameters $PSBoundParameters
        Write-NodeEventLog -Message $msg  -EventID 9009 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName

        $RegContext = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-AzureStackHCI }

            if(-Not ([string]::IsNullOrEmpty($RegContext.AzureResourceUri)))
            {
                if([string]::IsNullOrEmpty($ResourceName))
                {
                    $ResourceName = $RegContext.AzureResourceUri.Split('/')[8]
                    Write-VerboseLog ("resolved resource Name $ResourceName from registration context")
                }
                elseif ($ResourceName -ne $RegContext.AzureResourceUri.Split('/')[8]) 
                {
                    Write-ErrorLog -Message ($HCIResourceNameDifferentErrorMessage -f $RegContext.AzureResourceUri.Split('/')[8]) -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message ($HCIResourceNameDifferentErrorMessage -f $RegContext.AzureResourceUri.Split('/')[8]) -EventID 9127 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    throw
                }

                if([string]::IsNullOrEmpty($ResourceGroupName))
                {
                    $ResourceGroupName = $RegContext.AzureResourceUri.Split('/')[4]
                    Write-VerboseLog ("resolved resource group name $ResourceGroupName from registration context")
                }
                elseif ($ResourceGroupName -ne $RegContext.AzureResourceUri.Split('/')[4]) 
                {
                    Write-ErrorLog -Message ($HCIResourceGroupNameDifferentErrorMessage -f $RegContext.AzureResourceUri.Split('/')[4]) -Category OperationStopped -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message ($HCIResourceGroupNameDifferentErrorMessage -f $RegContext.AzureResourceUri.Split('/')[4]) -EventID 9125 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    throw
                }

                if($SubscriptionId -ne $RegContext.AzureResourceUri.Split('/')[2])
                {
                    Write-ErrorLog -Message ($HCISubscriptionDifferentErrorMessage -f $RegContext.AzureResourceUri.Split('/')[2]) -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message ($HCISubscriptionDifferentErrorMessage -f $RegContext.AzureResourceUri.Split('/')[2]) -EventID 9128 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    throw
                }
            }
        elseif ($RepairRegistration -eq $true)
        {
            Write-ErrorLog -Message $NoExistingRegistrationExistsErrorMessage -Category OperationStopped -ErrorAction Continue
            $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
            Write-Output $registrationOutput | Format-List
            Write-NodeEventLog -Message $NoExistingRegistrationExistsErrorMessage -EventID 9101 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
            throw
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
        
        Write-VerboseLog ("installing RSAT-Clustering-PowerShell module on the cluster")
        Invoke-Command -Session $clusterNodeSession -ScriptBlock $clusScript
        
        Write-VerboseLog ("invoking Get-Cluster module on the cluster")
        $getCluster = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-Cluster }
        
        Write-VerboseLog ("invoking Get-ClusterNode module on the cluster")
        $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }
        
        $clusterDNSSuffix = Get-ClusterDNSSuffix -Session $clusterNodeSession
        Write-VerboseLog ("clusterDNSSuffix resolved to:  $clusterDNSSuffix")
        
        $clusterDNSName = Get-ClusterDNSName -Session $clusterNodeSession
        Write-VerboseLog ("clusterDNSName resolved to:  $clusterDNSName")

        if([string]::IsNullOrEmpty($ResourceName))
        {
            if($getCluster -eq $Null)
            {
                $NoClusterErrorMessage = $NoClusterError -f $ComputerName
                Write-ErrorLog -Message $NoClusterErrorMessage -Category OperationStopped -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $NoClusterErrorMessage -EventID 9102 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }
            else
            {
                $ResourceName = $getCluster.Name
                Write-VerboseLog ("using cluster Name as resource name: {0}" -f $ResourceName)
            }
        }

        if([string]::IsNullOrEmpty($ResourceGroupName))
        {
            $ResourceGroupName = $ResourceName + "-rg"
            Write-VerboseLog ("using cluster Name as resourcegroup name: $ResourceGroupName")
        }

        $Region = Normalize-RegionName -Region $Region
        Write-VerboseLog ("Normailzed region string: $Region")

        $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $RegisterProgressActivityName -UseDeviceAuthentication $UseDeviceAuthentication -Region $Region

        $resourceId = Get-ResourceId -ResourceName $ResourceName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName
        Write-VerboseLog ("ResourceId of cluster resource: $resourceId")

        $resource = Get-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore
        $resGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction Ignore

        if($resource -ne $null)
        {
            Write-VerboseLog ("Cluster resource is already created")

            # Fetching Arc settings resource
            $arcResourceId = $resourceId + $HCIArcInstanceName
            $arcres = Get-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -ErrorAction Ignore

            # Setting the value for ArcServerResourceGroupName
            if ([string]::IsNullOrEmpty($ArcServerResourceGroupName)) 
            {
                if($null -ne $arcres)
                {
                    $ArcServerResourceGroupName = $arcres.Properties.arcInstanceResourceGroup
                    Write-VerboseLog ("Arc for servers resource already exist. Resolved Arc for servers Resource group name from Arc for servers resource: $ArcServerResourceGroupName")
                }

                # Use Cluster RG as Arc RG if Arc RG is empty and Arc settings is not set
                else
                {
                    $ArcServerResourceGroupName = $resourceGroupName
                    Write-VerboseLog ("Using Cluster Resource group as Arc for Servers Resource group name: $ArcServerResourceGroupName")
                }
            }
            else 
            {
                if (($null -ne $arcres) -and ($arcres.Properties.arcInstanceResourceGroup -ne $ArcServerResourceGroupName))
                {
                    $ArcAlreadyRegisteredInDifferentResourceGroupErrorMessage = $ArcAlreadyRegisteredInDifferentResourceGroupError -f $arcres.Properties.arcInstanceResourceGroup
                    Write-ErrorLog -Message $ArcAlreadyRegisteredInDifferentResourceGroupErrorMessage -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $ArcAlreadyRegisteredInDifferentResourceGroupErrorMessage
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message $ArcAlreadyRegisteredInDifferentResourceGroupErrorMessage -EventID 9129 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning 
                    throw
                }
            }
            
            $resourceLocation = Normalize-RegionName -Region $resource.Location
            Write-VerboseLog ("Location resolved from  cloud resource: $resourceLocation")
            if($Region -ne $resourceLocation)
            {
                $ResourceExistsInDifferentRegionErrorMessage = $ResourceExistsInDifferentRegionError -f $resourceLocation, $Region
                Write-ErrorLog -Message $ResourceExistsInDifferentRegionErrorMessage -Category OperationStopped -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $ResourceExistsInDifferentRegionErrorMessage -EventID 9104 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }
        }
        
        # Check if OS version is 22H2 or newer
        $osVersionDetectoid       = { $displayVersion = (Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion").DisplayVersion; $buildNumber = (Get-CimInstance -ClassName CIM_OperatingSystem).BuildNumber; New-Object -TypeName PSObject -Property @{'DisplayVersion'=$displayVersion; 'BuildNumber'=$buildNumber} }
        $cloudManagementDetectoid = { $cloudManagementSvc = Get-Item -Path ("{0}\System32\azshci\{1}.exe" -f $env:SystemRoot, $Using:ClusterAgentServiceName) -ErrorAction SilentlyContinue; $cloudManagementSvc -ne $null }

        $osVersionInfo            = Invoke-Command -Session $clusterNodeSession -ScriptBlock $osVersionDetectoid
        $cloudManagementCapable   = Invoke-Command -Session $clusterNodeSession -ScriptBlock $cloudManagementDetectoid
        Write-VerboseLog ("Display Version: {0}, Build Number: {1}, Cloud Management capable: {2}" -f $osVersionInfo.DisplayVersion, $osVersionInfo.BuildNumber, $cloudManagementCapable)

        $isCloudManagementSupported = ([Int]::Parse($osVersionInfo.BuildNumber) -ge $22H2BuildNumber) -and ($cloudManagementCapable -eq $true)
        $isDefaultExtensionSupported = ([Int]::Parse($osVersionInfo.BuildNumber) -ge $23H2BuildNumber)
        Write-VerboseLog ("Cloud Management supported: {0}" -f $isCloudManagementSupported)
        Write-VerboseLog ("Installing Mandatory extensions supported: {0}" -f $isDefaultExtensionSupported)
        
        if(($isDefaultExtensionSupported) -and (($null -eq $arcres) -or ($null -eq $arcres.Properties.DefaultExtensions.ConsentTime)))
        {
            if($PSCmdlet.ShouldProcess($DefaultExtensionPromptMessage, $DefaultExtensionPromptMessage, "Do you want to continue?"))
            {
                Write-VerboseLog ("User has consented to install mandatory Azure Arc extensions. Continuing with registration.")                        
            }
            else
            {
                Write-VerboseLog ("User has declined to install Mandatory Azure Arc extensions. Registration is not possible without a consent to install Mandatory extensions. Aborting registration.")  
                Write-ErrorLog -Message $DefaultExtensionErrorMessage                      
                throw
            }
        }

        #USE CLUSTER RG AS ARC RG
        if ([string]::IsNullOrEmpty($ArcServerResourceGroupName)) 
        {
            $ArcServerResourceGroupName = $resourceGroupName
            Write-VerboseLog ("using cluster rg as arcserver resourcegroup name: $ResourceGroupName")
        }

        try
        {
            Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId $SubscriptionId -ArcResourceGroupName $ArcServerResourceGroupName -Credential $Credential -ClusterDNSSuffix $clusterDNSSuffix
        }
        catch
        {
            Write-ErrorLog $_.Exception.Message -Category OperationStopped
            $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
            Write-Output $registrationOutput | Format-List
            throw
        }

        $arcResGroup = Get-AzResourceGroup -Name $ArcServerResourceGroupName -ErrorAction Ignore

        $registrationBeginMsg="Register-AzStackHCI triggered - Region: $Region ResourceName: $ResourceName `
        SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName `
        AccountId: $AccountId EnvironmentName: $EnvironmentName CertificateThumbprint: $CertificateThumbprint `
        RepairRegistration: $RepairRegistration IsWAC: $IsWAC `
        ArcServerResourceGroupName: $ArcServerResourceGroupName"
    
        $registrationBeginMsgPIIScrubbed="Register-AzStackHCI triggered - Region: $Region ResourceName: $ResourceName `
        SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName `
        EnvironmentName: $EnvironmentName CertificateThumbprint: $CertificateThumbprint `
        RepairRegistration: $RepairRegistration IsWAC: $IsWAC `
        ArcServerResourceGroupName: $ArcServerResourceGroupName"
    
        Write-VerboseLog ($registrationBeginMsg)
        Write-NodeEventLog -Message $registrationBeginMsgPIIScrubbed -EventID 9001 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName

        if ($Null -ne $arcResGroup)
        {
            Write-VerboseLog("Checking if an arc machine with same name as current nodes already exists in the Arc For Server Resource Group")
            forEach ($clusNode in $clusterNodes) 
            {
                $machineResourceId = "/Subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ArcServerResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $clusNode
                $machineResourceIdWithAPI = "{0}?api-version={1}" -f $machineResourceId, $HCApiVersion
                $arcMachineResource = Get-AzResource -ResourceId $machineResourceIdWithAPI -ErrorAction Ignore
                $sameNodeNames = [System.Collections.ArrayList]::new()

                if ($Null -ne $arcMachineResource) 
                {
                    $parentClusterResourceId = $arcMachineResource.properties.parentClusterResourceId
                    #If ParentClusterResourceId is empty, Arc enablement happened before Registration. 
                    if ([string]::IsNullOrEmpty($parentClusterResourceId)) 
                    {
                        Write-VerboseLog("ParentClusterResourceId for Node $clusNode is empty, continue.")
                        continue
                    }
                    #Case: ParentClusterResourceId is Set. 
                    else 
                    {
                        $errorMessage = "Cluster is {} and ParentClusterResourceId for $clusNode does not match the Cluster Resource."
                        # If Cluster is registered from before, then ParentClusterResourceId should match the clusterResourceId 
                        if ($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered) 
                        {
                            if ($parentClusterResourceId -eq $resourceId) 
                            {
                                Write-VerboseLog ("Cluster is registered and ParentClusterResourceId for $clusNode matches the Cluster Resource, continue.")
                                continue
                            }
                            else 
                            {
                                $errorMessageLog = $errorMessage -f "registered"
                                Write-ErrorLog($errorMessageLog)
                                $sameNodeNames.Add($clusNode) | Out-Null
                            }
                        }
                        #If Cluster is not yet registered, then ParentClusterResourceId should be Null 
                        else 
                        {
                            $errorMessageLog = $errorMessage -f "not registered"
                            Write-ErrorLog ($errorMessageLog)
                            $sameNodeNames.Add($clusNode) | Out-Null
                        }
                    }
                }
            }

            if ($sameNodeNames.Count -gt 0) 
            {
                Write-VerboseLog("A node exists with the same name in the arc for servers resource group. Choose a different resource group for Arc for server resources.")
                $sameNodeNamesAsList = $sameNodeNames -join ","
                $ArcMachineAlreadyExistsInResourceGroupErrorMessage = $ArcMachineAlreadyExistsInResourceGroupError -f $sameNodeNamesAsList, $ArcServerResourceGroupName
                Write-ErrorLog -Message $ArcMachineAlreadyExistsInResourceGroupErrorMessage -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $ArcMachineAlreadyExistsInResourceGroupErrorMessage 
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $ArcMachineAlreadyExistsInResourceGroupErrorMessage -EventID 9105 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }
        }

        if ($arcResGroup -eq $Null) 
        {
            $CreatingResourceGroupMessageProgress = $CreatingResourceGroupMessage -f $ArcServerResourceGroupName
            Write-VerboseLog ("$CreatingResourceGroupMessageProgress")
            $arcResGroup = New-AzResourceGroup -Name $ArcServerResourceGroupName -Location $Region -Tag @{$ResourceGroupCreatedByName = $ResourceGroupCreatedByValue }
        }
        $resGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction Ignore

        # Normalize region name
        $Region = Normalize-RegionName -Region $Region

        $portalResourceUrl = Get-PortalHCIResourcePageUrl -TenantId $TenantId -EnvironmentName $EnvironmentName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Region $Region

        if(($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered) -and ($RepairRegistration -eq $false))
        {
            
            if(($RegContext.AzureResourceUri -eq $resourceId))
            {
                if($resource -ne $Null)
                {
                    Write-VerboseLog ("Cluster is already registered with same resourceID. Nothing to do.")
                    # Already registered with same resource Id and resource exists
                    $appId = $resource.Properties.aadClientId
                    $operationStatus = [OperationStatus]::Success
                }
                else
                {
                    Write-VerboseLog ("Cluster is already registered but the cloud resource does not exist.")
                    # Already registered with same resource Id and resource does not exists
                    $AlreadyRegisteredErrorMessage = $CloudResourceDoesNotExist -f $resourceId
                    Write-ErrorLog -Message $AlreadyRegisteredErrorMessage -Category OperationStopped -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message $AlreadyRegisteredErrorMessage -EventID 9106 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    throw
                }
            }
            else # Already registered with different resource Id
            {
                Write-VerboseLog ("Cluster is already registered and cloud resource does not match.")
                $AlreadyRegisteredErrorMessage = $RegisteredWithDifferentResourceId -f $RegContext.AzureResourceUri
                Write-ErrorLog -Message $AlreadyRegisteredErrorMessage -Category OperationStopped -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $AlreadyRegisteredErrorMessage -EventID 9107 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }
        }
        else
        {
            Write-VerboseLog ("$RegisterProgressActivityName")
            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RegisterAzureStackRPMessage -percentcomplete 40
            Register-ResourceProviderIfRequired -ProviderNamespace "Microsoft.AzureStackHCI"
            # Validate that the input region is supported by the Stack HCI RP
            $supportedRegions = [string]::Empty
            $regionSupported = Validate-RegionName -Region $Region -SupportedRegions ([ref]$supportedRegions)

            if ($regionSupported -eq $False)
            {
                $RegionNotSupportedMessage = $RegionNotSupported -f $Region, $supportedRegions
                Write-ErrorLog -Message $RegionNotSupportedMessage -Category OperationStopped -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $RegionNotSupportedMessage -EventID 9108 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }

            if($Null -eq $resource)
            {
                # Create new HCI resource by calling RP

                if($Null -eq $resGroup)
                {
                    $CreatingResourceGroupMessageProgress = $CreatingResourceGroupMessage -f $ResourceGroupName
                    Write-VerboseLog ("$CreatingResourceGroupMessageProgress")
                    Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $CreatingResourceGroupMessageProgress -percentcomplete 55
                    $resGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Region -Tag @{$ResourceGroupCreatedByName = $ResourceGroupCreatedByValue }
                }

                $CreatingCloudResourceMessageProgress = $CreatingCloudResourceMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $CreatingCloudResourceMessageProgress -percentcomplete 60

                $properties = [ResourceProperties]::new($Region, @{}, $Tag)
                $payload = ConvertTo-Json -InputObject $properties
                $resourceIdWithAPI = "{0}?api-version={1}" -f $resourceId, $RPAPIVersion
                Write-VerboseLog ("$CreatingCloudResourceMessageProgress with properties : {0}" -f ($payload | Out-String))
                Write-VerboseLog ("ResorceIdWithApi: $resourceIdWithAPI")
                $clusterResult = New-ClusterWithRetries -ResourceIdWithAPI $resourceIdWithAPI -Payload $payload
                if($clusterResult -eq $false) 
                {
                    Write-ErrorLog -Message $ClusterCreationFailureMessage -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message $ClusterCreationFailureMessage -EventID 9130 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    throw
                }

                $resource = Get-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore
            }

            if((($Null -eq $resource.Identity) -or ($resource.Identity.Type -ne "SystemAssigned")))
            {
                #we are here, if we are in repairregistration flow and resource might have been already created, we will check if MSI is not enabled, if it is not enabled, we will patch the resource again.
                $RepairingCloudResourceMessageProgress = $RepairingCloudResourceMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RepairingCloudResourceMessageProgress -percentcomplete 60
                Write-VerboseLog ("Enabling SystemAssignedIdentity on : $resourceId")
                $properties = New-Object -TypeName PSObject
                $properties | Add-Member -MemberType NoteProperty -Name "identity" -Value $([Identity]::new())
                if ($Tag.Count -ne 0)
                {
                    $properties | Add-Member -MemberType NoteProperty -Name "tags" -Value $Tag
                }

                $payload = ConvertTo-Json -InputObject $properties
                $resourceIdWithAPI = "{0}?api-version={1}" -f $resourceId, $RPAPIVersion
                Write-VerboseLog ("$CloudResourceMessageProgress with properties : {0}" -f ($payload | Out-String))
                Write-VerboseLog ("ResorceIdWithApi: $resourceIdWithAPI")
                $response = Invoke-AzRestMethod -Path $resourceIdWithAPI -Method PATCH -Payload $payload
                if(-not(($response.StatusCode -ge 200) -and ($response.StatusCode -lt 300)))
                {
                    Write-ErrorLog -Message ("Failed to repair ARM resource representing the cluster. Code: {0}, Details: {1}" -f $response.StatusCode, $response.Content) -Category OperationStopped
                    throw
                }
                $resource = Get-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore
            }

            if($resource.Properties.aadApplicationObjectId -eq $Null)
            {
                # create cluster identity by calling HCI RP
                $clusterIdentity = Execute-Without-ProgressBar -ScriptBlock { Invoke-AzResourceAction -ResourceId $resourceId -ApiVersion $RPAPIVersion -Action createClusterIdentity -Force }
                # Get cluster again for identity details
                $resource = Get-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore
            }

            # if the RPObjectId is null, we will do a patch call on the resource. Case: cluster was created before RPObjectId was introduced 
            if($Null -eq $resource.Properties.ResourceProviderObjectId)
            {
                Write-VerboseLog("Populating Resource Provider Object Id for cluster: $resourceId")
                $properties = @{}
                $payload = ConvertTo-Json -InputObject $properties
                $resourceIdWithAPI = "{0}?api-version={1}" -f $resourceId, $RPAPIVersion
                Write-VerboseLog ("Patching Cloud Resource with properties : {0}" -f ($payload | Out-String))
                Write-VerboseLog ("ResourceIdWithApi: $resourceIdWithAPI")
                Invoke-AzRestMethod -Path $ResourceIdWithAPI -Method PATCH -Payload $Payload
                $resource = Get-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore
            }

            if ($Null -eq $resource.Properties.ResourceProviderObjectId) 
            {
                Write-VerboseLog("Resource Provider Object Id is Null. Can't assign roles to HCI RP for ARC Onboarding")
                Write-ErrorLog -Message $rpObjectIdNullError -Category OperationStopped
                $operationStatus = [OperationStatus]::ArcFailed
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value [ErrorDetail]::ArcPermissionsMissing
                Write-NodeEventLog -Message $rpObjectIdNullError -EventID 9131 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Error
                throw
            }

            $RPObjectId = $resource.Properties.ResourceProviderObjectId
            $setRolesResult = Set-ArcRoleforRPSpn -RPObjectId $RPObjectId -ArcServerResourceGroupName $ArcServerResourceGroupName
            if($setRolesResult -ne [ErrorDetail]::Success) 
            {
                Write-VerboseLog("Failed to assign Arc roles to HCI Resource Provider")
                Write-ErrorLog -Message $roleAssignmentHCIRPFailError -Category OperationStopped
                $operationStatus = [OperationStatus]::ArcFailed
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value $setRolesResult
                Write-NodeEventLog -Message $rpObjectIdNullError -EventID 9132 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Error
                throw
            }

            $serviceEndpoint = $resource.properties.serviceEndpoint
            $appId = $resource.Properties.aadClientId
            $cloudId = $resource.Properties.cloudId 
            $objectId = $resource.Properties.aadApplicationObjectId
            $spObjectId = $resource.Properties.aadServicePrincipalObjectId

            # Add certificate

            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $GettingCertificateMessage -percentcomplete 70

            $CertificatesToBeMaintained = @{}
            $NewCertificateFailedNodes = [System.Collections.ArrayList]::new()
            $SetCertificateFailedNodes = [System.Collections.ArrayList]::new()
            $OSNotLatestOnNodes = [System.Collections.ArrayList]::new()

            $TempServiceEndpoint = ""
            $Authority = ""
            $BillingServiceApiScope = ""
            $GraphServiceApiScope = ""

            Get-EnvironmentEndpoints -EnvironmentName $EnvironmentName -ServiceEndpoint ([ref]$TempServiceEndpoint ) -Authority ([ref]$Authority) -BillingServiceApiScope ([ref]$BillingServiceApiScope) -GraphServiceApiScope ([ref]$GraphServiceApiScope)

            $setupCertsError = Setup-Certificates -ClusterNodes $clusterNodes -Credential $Credential -ResourceName $ResourceName -ObjectId $objectId -CertificateThumbprint $CertificateThumbprint -AppId $appId -TenantId $TenantId -CloudId $cloudId `
                                -ServiceEndpoint $ServiceEndpoint -BillingServiceApiScope $BillingServiceApiScope -GraphServiceApiScope $GraphServiceApiScope -Authority $Authority -NewCertificateFailedNodes $NewCertificateFailedNodes `
                                -SetCertificateFailedNodes $SetCertificateFailedNodes -OSNotLatestOnNodes $OSNotLatestOnNodes -CertificatesToBeMaintained $CertificatesToBeMaintained -ClusterDNSSuffix $clusterDNSSuffix -ResourceId $resourceId

            Write-VerboseLog ("Setup-Certificates returned {0}" -f $setupCertsError)
            if($null -ne $setupCertsError)
            {
                Write-VerboseLog ("Setup-Certificates has failed")
                Write-ErrorLog -Message $setupCertsError -Category OperationStopped
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $setupCertsError -EventID 9109 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }

            if(($SetCertificateFailedNodes.Count -ge 1) -or ($NewCertificateFailedNodes.Count -ge 1))
            {
                Write-VerboseLog ("Setup-Certificates failed on atleast one node")
                $SettingCertificateFailedMessage = $SettingCertificateFailed -f ($NewCertificateFailedNodes -join ","),($SetCertificateFailedNodes -join ",")
                Write-ErrorLog -Message $SettingCertificateFailedMessage -Category OperationStopped -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $SettingCertificateFailedMessage -EventID 9110 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }

            if($OSNotLatestOnNodes.Count -ge 1)
            {
                $NotAllTheNodesInClusterAreGAError = $NotAllTheNodesInClusterAreGA -f ($OSNotLatestOnNodes -join ",")
                Write-ErrorLog -Message $NotAllTheNodesInClusterAreGAError -Category OperationStopped -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                Write-NodeEventLog -Message $NotAllTheNodesInClusterAreGAError -EventID 9111 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }

            Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RegisterAndSyncMetadataMessage -percentcomplete 90

            # Register by calling on-prem usage service Cmdlet
            try 
            {
                $Params = @{
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

                $SetAzureStackHCIRegistrationScript = {
                    Set-AzureStackHCIRegistration -ErrorAction Stop @Params
                }

                Run-InvokeCommand -ScriptBlock $SetAzureStackHCIRegistrationScript -Session $clusterNodeSession -Params $Params
                Write-VerboseLog ("Successfully performed: {0}" -f ($Params | Out-String))
            }
            catch
            {
                $errorMessage = $_.Exception.Message.ToString()
                Write-VerboseLog ($SetAzureStackHCIRegistrationErrorMessage -f $errorMessage)
                Write-ErrorLog ($SetAzureStackHCIRegistrationErrorMessage -f $errorMessage) -Category OperationStopped -Exception $_ -ErrorAction Continue
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput | Format-List
                throw
            }

            $isCloudManagementFeatureEnabled = $false
            if ($isCloudManagementSupported -eq $true)
            {
                $cloudManagementFeatureDetectoid = { $null -ne (Get-AzureStackHCI).NextSync }
                $isCloudManagementFeatureEnabled = Invoke-Command -Session $clusterNodeSession -ScriptBlock $cloudManagementFeatureDetectoid -ErrorAction Ignore
                Write-VerboseLog ("Cloud Management supported: {0}" -f $isCloudManagementSupported)
                Write-VerboseLog ("Cloud Management enabled:   {0}" -f $isCloudManagementFeatureEnabled)
            }

            if ($isCloudManagementSupported -eq $true -AND $isCloudManagementFeatureEnabled -eq $true)
            {
                Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $ConfiguringCloudManagementMessage -percentcomplete 91
                Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -status $ConfiguringCloudManagementMessage -percentcomplete 10
                Write-VerboseLog ("$ConfiguringCloudManagementMessage")
    
                # Start Cluster Agent Servce as Clustered Role
                $service = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-Service -Name $using:ClusterAgentServiceName -ErrorAction Ignore }
                
                $serviceError = $null
                if ($null -eq $service)
                {
                    $serviceError = "{0} service doesn't exist." -f $ClusterAgentServiceName
                    Write-ErrorLog -Message $serviceError -ErrorAction Continue
                    Write-NodeEventLog -Message $serviceError -EventID 9119 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                }
                else
                {
                    # Run agent service as cluster resource
                    Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -status $ConfiguringCloudManagementClusterSvc -percentcomplete 20

                    $displayName = $service.DisplayName
                    Write-VerboseLog ("Found Cloud Management Agent: $displayName")
                    $group = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterGroup -Name $using:ClusterAgentGroupName -ErrorAction Ignore }
                    if ($null -eq $group)
                    {
                        Write-VerboseLog ("Creating Cloud Management cluster group: $ClusterAgentGroupName")
                        $group = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Add-ClusterGroup -Name $using:ClusterAgentGroupName -ErrorAction Ignore }
                    }

                    if ($null -ne $group)
                    {
                        Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -status $ConfiguringCloudManagementClusterSvc -percentcomplete 40
                        Write-VerboseLog ("Cloud Management cluster group: $($group | Format-List | Out-String)")
                        $svcResource = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterGroup -Name $using:ClusterAgentGroupName | Get-ClusterResource -ErrorAction Ignore | Where-Object {$_.Name -eq $using:displayName} }

                        if ($null -eq $svcResource)
                        {
                            Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -status $ConfiguringCloudManagementClusterSvc -percentcomplete 60
                            Write-VerboseLog ("Creating cluster resource for Cloud Management agent")
                            $svcResource = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Add-ClusterResource -Name $using:displayName -ResourceType "Generic Service" -Group $using:ClusterAgentGroupName -ErrorAction Ignore }
                        }

                        if ($null -ne $svcResource)
                        {
                            Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -status $ConfiguringCloudManagementClusterSvc -percentcomplete 80
                            Write-VerboseLog ("Cloud Management cluster resource: $($svcResource | Format-List | Out-String)")
                            Write-VerboseLog ("Setting cluster resource parameter ServiceName = $ClusterAgentServiceName")
                            Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterGroup -Name $using:ClusterAgentGroupName | Get-ClusterResource -ErrorAction Ignore | Where-Object {$_.Name -eq $using:displayName} | Set-ClusterParameter -Name ServiceName -Value $using:ClusterAgentServiceName -ErrorAction Ignore}
                            $group = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterGroup -Name $using:ClusterAgentGroupName -ErrorAction Ignore }
                        }
                        else
                        {
                            $serviceError = "Failed to create cluster resource {0} in group {1}." -f $ClusterAgentServiceName, $ClusterAgentGroupName
                            Write-ErrorLog -Message $serviceError -ErrorAction Continue
                            Write-NodeEventLog -Message $serviceError -EventID 9120 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                        }
                    }
                    else
                    {
                        $serviceError = "Failed to create cluster group {0}." -f $ClusterAgentGroupName
                        Write-ErrorLog -Message $serviceError -ErrorAction Continue
                        Write-NodeEventLog -Message $serviceError -EventID 9120 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    }

                    Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -status $StartingCloudManagementMessage -percentcomplete 90
                    if ($null -ne $group -and $group.State -ne "Online")
                    {
                        Write-VerboseLog ("Cloud Management cluster resource: $($svcResource | Format-List |Out-String)")
                        Write-VerboseLog ("Starting Cluster Group $ClusterAgentGroupName")
                        $group = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Start-ClusterGroup -Name $using:ClusterAgentGroupName -Wait 120 -ErrorAction Ignore }
                        if ($group.State -ne "Online")
                        {
                            $serviceError = "Failed to start {0} clustered role." -f $ClusterAgentGroupName
                            Write-ErrorLog -Message $serviceError -ErrorAction Continue
                            Write-NodeEventLog -Message $serviceError -EventID 9121 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                        }
                    }
                }

                Write-Progress -Id $SecondaryProgressBarId -activity $SetupCloudManagementActivityName -Completed
                Write-VerboseLog ("Cloud Management group: $($group | Format-List | Out-String)")
                Write-VerboseLog ("Cloud Management resource: $($svcResource | Format-List | Out-String)")
                Write-VerboseLog ("Cloud Management agent setup complete")

                if ($null -eq $serviceError)
                {
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyClusterAgentStatus -Value ([OperationStatus]::Success)
                    # Perform a Sync on successful agent setup.
                    Invoke-Command -Session $clusterNodeSession -ScriptBlock { Sync-AzureStackHCI -ErrorAction Ignore}
                }
                else
                {
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyClusterAgentStatus -Value ([OperationStatus]::Failed)
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyClusterAgentError -Value $serviceError
                }
            }

            $operationStatus = [OperationStatus]::Success
        }

        # Arc enablement starts here
        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -status $RegisterArcMessage -percentcomplete 93
        Write-VerboseLog ("$RegisterArcMessage")
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
                Write-VerboseLog ("Exception occurred in establishing new PSSession to $($clusNode.Name). ErrorMessage : " + $_.Exception.Message)
                Write-VerboseLog ($_)
                $ArcCmdletsAbsentOnNodes.Add($clusNode.Name) | Out-Null
                continue
            }

            # Check if node has Arc registration Cmdlets
            $cmdlet = Invoke-Command -Session $nodeSession -ScriptBlock { Get-Command Get-AzureStackHCIArcIntegration -Type Cmdlet -ErrorAction Ignore }

            if($cmdlet -eq $null)
            {
                Write-VerboseLog ("Arc cmdlet not present on node : {0}" -f $clusNode.Name)
                $ArcCmdletsAbsentOnNodes.Add($clusNode.Name) | Out-Null
            }

            if($nodeSession -ne $null)
            {
                Remove-PSSession $nodeSession -ErrorAction Ignore | Out-Null
            }
        }

        if($ArcCmdletsAbsentOnNodes.Count -ge 1)
        {
            $ArcCmdletsNotAvailableErrorMsg = $ArcCmdletsNotAvailableError -f ($ArcCmdletsAbsentOnNodes -join ",")
            Write-ErrorLog -Message $ArcCmdletsNotAvailableErrorMsg -Category OperationStopped -ErrorAction Continue
            $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
            Write-Output $registrationOutput | Format-List
            Write-NodeEventLog -Message $ArcCmdletsNotAvailableErrorMsg -EventID 9112 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
            throw
        }
        else
        {
            $arcResourceId = $resourceId + $HCIArcInstanceName

            Write-VerboseLog ("checking if Arc resource $arcResourceId already exists")
            
            if($null -eq $arcres)
            {
                Write-VerboseLog ("Arc Resource does not exist, create new resource")
                $arcInstanceResourceGroup = @{"arcInstanceResourceGroup" = $ArcServerResourceGroupName}
                $arcres = New-AzResource -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -PropertyObject $arcInstanceResourceGroup -Force
            }
            else
            {
                Write-VerboseLog ("Arc Resource already exists")
                if ($arcres.Properties.aggregateState -eq $ArcSettingsDisableInProgressState)
                {
                    Write-ErrorLog -Message $ArcRegistrationDisableInProgressError -Category OperationStopped -ErrorAction Continue
                    $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                    Write-Output $registrationOutput | Format-List
                    Write-NodeEventLog -Message $ArcRegistrationDisableInProgressError  -EventID 9113 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                    throw
                }
            }

            Write-VerboseLog ("Register-AzStackHCI: Arc registration triggered. ArcResourceGroupName: $ArcServerResourceGroupName")

            if($isDefaultExtensionSupported)
            {
                Write-VerboseLog "Mandatory extensions are supported. Triggering installation for mandatory extensions."
                Execute-Without-ProgressBar -ScriptBlock { Invoke-AzResourceAction -ResourceId $arcResourceId -ApiVersion $HCIArcAPIVersion -Action consentAndInstallDefaultExtensions -Force } | Out-Null
            }

            try {
                $arcResult = Register-ArcForServers -IsManagementNode $IsManagementNode -ComputerName $ComputerName -Credential $Credential -TenantId $TenantId -SubscriptionId $SubscriptionId -ResourceGroup $ArcServerResourceGroupName -Region $Region -ArcSpnCredential $ArcSpnCredential -ClusterDNSSuffix $clusterDNSSuffix -IsWAC:$IsWAC -Environment:$EnvironmentName -ArcResource $arcres -HCIResource $resource
            }
            catch {
                $operationStatus = [OperationStatus]::ArcFailed
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value $operationStatus
                Write-Output $registrationOutput | Format-List
                throw $_.Exception.Message
            }


            if($arcResult -ne [ErrorDetail]::Success)
            {
                $operationStatus = [OperationStatus]::RegisterSucceededButArcFailed
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value $arcResult
            }
        }

        Write-Progress -Id $MainProgressBarId -activity $RegisterProgressActivityName -Completed

        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $operationStatus
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyPortalResourceURL -Value $portalResourceUrl
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResourceId -Value $resourceId
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $RegistrationSuccessDetailsMessage
        

        Write-Output $registrationOutput | Format-List
        $RegistrationCompleteEvent = "Registration completed with status:  {0}" -f ($registrationOutput | Format-List | Out-String )
        Write-InfoLog($RegistrationCompleteEvent)
        Write-NodeEventLog -Message $RegistrationCompleteEvent -EventID 9004 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
    }
    catch
    {
        # Get script line number, offset and Command that resulted in exception. Write-Error with the exception above does not write this info.
        $positionMessage = $_.InvocationInfo.PositionMessage
        Write-NodeEventLog -Message ("Exception occurred in Register-AzStackHCI : " + $positionMessage) -EventID 9114 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning

        if(-Not $Error.Contains($AlreadyLoggedFlag))
        {
            Write-ErrorLog ("Exception occurred in Register-AzStackHCI") -Exception $_ -Category OperationStopped
        }
    }
    finally
    {
        try{ Disconnect-AzAccount | Out-Null } catch{}
        if($DebugPreference -ne "SilentlyContinue")
        {
            try{ Stop-Transcript | Out-Null }catch{}
        }
    }
}

function Set-ArcRoleforRPSpn {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [String] $RPObjectId,
        [String] $ArcServerResourceGroupName
    )
    $stopLoop = $false
    [int]$retryCount = "0"
    [int]$maxRetryCount = "5"
    Write-VerboseLog ("Assigning HCI RP App Arc Onboarding permissions")
    do
    {
        try 
        {
            New-AzRoleAssignment -ObjectId $RPObjectId -ResourceGroupName $ArcServerResourceGroupName -RoleDefinitionName $ArcOnboardingRole | Out-Null
            Write-VerboseLog("Sucessfully assigned ARC Roles to HCI RP service principal with Object Id $($RPObjectId)")
            $stopLoop = $true
        }
        catch 
        {
            # 'Conflict' can happen when either the RoleAssignment already exists or the limit for number of role assignments has been reached.
            if ($_.Exception.Response.StatusCode -eq 'Conflict') 
            {
                $roleAssignment  = Get-AzRoleAssignment -ObjectId $RPObjectId -ResourceGroupName $ArcServerResourceGroupName -RoleDefinitionName $ArcOnboardingRole
                if ($null -ne $roleAssignment) 
                {
                    Write-VerboseLog("Sucessfully assigned ARC Roles to HCI RP service principal with Object Id $($RPObjectId)")
                    return [ErrorDetail]::Success
                }
                Write-ErrorLog ("Failed to assign roles to service principal with object Id $($RPObjectId). ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $_.InvocationInfo.PositionMessage)
                return [ErrorDetail]::ArcPermissionsMissing
            }
            if ($retryCount -ge $maxRetryCount) 
            {
                # Timed out.
                Write-ErrorLog ("Failed to assign roles to service principal with object Id $($RPObjectId). ErrorMessage: " + $_.Exception.Message + " PositionalMessage: " + $_.InvocationInfo.PositionMessage)
                return [ErrorDetail]::ArcPermissionsMissing
            }
            Write-VerboseLog ("Could not assign roles to service principal with Object Id $($RPObjectId). Retrying in 10 seconds...")
            Start-Sleep -Seconds 10
            $retryCount = $retryCount + 1
        }
    }
    While(-Not $stopLoop)
    return [ErrorDetail]::Success
}

function New-ClusterWithRetries {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [String] $ResourceIdWithAPI, 
        [String] $Payload
    )
    $stopLoop = $false
    [int]$retryCount = "0"
    [int]$maxRetryCount = "10"
    do 
    {
        
        $response = Invoke-AzRestMethod -Path $ResourceIdWithAPI -Method PUT -Payload $Payload
    
        if (($response.StatusCode -ge 200) -and ($response.StatusCode -lt 300)) 
        {
            $stopLoop = $true
            return $true
        }
        if ($retryCount -ge $maxRetryCount) 
        {
            # Timed out.
            Write-WarnLog ("Failed to create ARM resource representing the cluster. StatusCode: {0}, ErrorCode: {1}, Details: {2}" -f $response.StatusCode, $response.ErrorCode, $response.Content)
            return $false
        }
        Write-VerboseLog ("Failed to create ARM resource representing the cluster. Retrying in 10 seconds...")
        Start-Sleep -Seconds 10
        $retryCount = $retryCount + 1

    }
    While (-Not $stopLoop)
    return $true
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
    Specifies the ARM access token. Specifying this along with AccountId will avoid Azure interactive logon.

    .PARAMETER GraphAccessToken
    GraphAccessToken is deprecated.

    .PARAMETER AccountId
    Specifies the AccoundId. Specifying this along with ArmAccessToken will avoid Azure interactive logon.

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
    C:\PS>Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -AccountId user1@corp1.com -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG -Confirm:$False
    Result: Success

    .EXAMPLE
    Invoking with all the parameters
    C:\PS>Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciClusterRG -ArmAccessToken eerrer..ere= -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential
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

    if([string]::IsNullOrEmpty($ComputerName))
    {
        $ComputerName = [Environment]::MachineName
        $IsManagementNode = $False
    }
    else
    {
        $IsManagementNode = $True
    }

    try
    {
        Setup-Logging -LogFilePrefix "UnregisterHCI" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")

        $unregistrationOutput = New-Object -TypeName PSObject
        $operationStatus = [OperationStatus]::Unused

        Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $CheckingDependentModules -percentcomplete 1
        Check-DependentModules
        
        Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $FetchingRegistrationState -percentcomplete 2
        Write-VerboseLog ($UnregisterProgressActivityName)
        $msg = Print-FunctionParameters -Message "Unregister-AzStackHCI" -Parameters $PSBoundParameters
        Write-NodeEventLog -Message $msg  -EventID 9009 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
        Write-NodeEventLog -Message $UnregisterProgressActivityName -EventID 9005 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
        if($IsManagementNode)
        {
            Write-VerboseLog ("Connecting from management node")
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
        Write-VerboseLog ("Cluster DNS suffix resolves to : $clusterDNSSuffix")
        
        $clusterDNSName = Get-ClusterDNSName -Session $clusterNodeSession
        Write-VerboseLog ("Cluster DNS Name resolves to : $clusterDNSName")

        Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $ValidatingParametersRegisteredInfo -percentcomplete 5

        if([string]::IsNullOrEmpty($ResourceName) -or [string]::IsNullOrEmpty($SubscriptionId))
        {
            if($RegContext.RegistrationStatus -ne [RegistrationStatus]::Registered)
            {
                Write-ErrorLog -Message $RegistrationInfoNotFound -Category OperationStopped -ErrorAction Continue
                $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $unregistrationOutput | Format-List
                Write-NodeEventLog -Message $RegistrationInfoNotFound -EventID 9115 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                throw
            }
        }

        if([string]::IsNullOrEmpty($SubscriptionId))
        {
            $SubscriptionId = $RegContext.AzureResourceUri.Split('/')[2]
            Write-VerboseLog ("Subscription ID resolves to: $SubscriptionId")
        }

        if([string]::IsNullOrEmpty($ResourceGroupName))
        {
            $ResourceGroupName = If ($RegContext.RegistrationStatus -ne [RegistrationStatus]::Registered) { $ResourceName + "-rg" } Else { $RegContext.AzureResourceUri.Split('/')[4] }
            Write-VerboseLog ("resource Group resolves to: $ResourceGroupName")
        }

        if([string]::IsNullOrEmpty($ResourceName))
        {
            $ResourceName = $RegContext.AzureResourceUri.Split('/')[8]
            Write-VerboseLog ("resource name resolves to: $ResourceName")
        }

        $resourceId = Get-ResourceId -ResourceName $ResourceName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName

        if ($PSCmdlet.ShouldProcess($resourceId))
        {
            Write-VerboseLog ("Unregister-AzStackHCI triggered - ResourceName: $ResourceName Region: $Region `
                   SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName `
                   AccountId: $AccountId EnvironmentName: $EnvironmentName DisableOnlyAzureArcServer: $DisableOnlyAzureArcServer Force:$Force")

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
                Write-Output $unregistrationOutput | Format-List
                Write-NodeEventLog -Message "ARC unregistration failed" -EventID 9117 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning
                return
            }
            else
            {
                if ($DisableOnlyAzureArcServer -eq $true)
                {
                    $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Success
                    Write-Output $unregistrationOutput | Format-List
                    Write-NodeEventLog -Message "Disabling only ARC for Servers. UnRegistration completed successfully" -EventID 9008 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
                    return
                }
            }

            Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $UnregisterHCIUsageMessage -percentcomplete 45
        
            # Stop cluster agent service
            Invoke-Command -Session $clusterNodeSession -ScriptBlock { Remove-ClusterGroup -Name $using:ClusterAgentGroupName -RemoveResources -ErrorAction Ignore -Force | Out-Null }

            if($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered)
            {
                Invoke-Command -Session $clusterNodeSession -ScriptBlock { Remove-AzureStackHCIRegistration }
                Write-VerboseLog ("Successfully completed Remove-AzureStackHCIRegistration on cluster")
                $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }

                Foreach ($clusNode in $clusterNodes)
                {
                    $nodeSession = $null
                    Write-VerboseLog ("invoking Remove-AzureStackHCIRegistrationCertificate on {0}" -f $clusNode.Name)
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
                        Write-WarnLog ($FailedToRemoveRegistrationCertWarning -f $clusNode.Name)
                        Write-VerboseLog ("Exception occurred in clearing certificate on {0}. ErrorMessage : {1}" -f ($clusNode.Name), ($_.Exception.Message))
                        Write-VerboseLog ($_)
                        continue
                    }
                }
            }

            $resource = Get-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore

            if($resource -ne $Null)
            {
                $DeletingCloudResourceMessageProgress = $DeletingCloudResourceMessage -f $ResourceName
                Write-Progress -Id $MainProgressBarId -activity $UnregisterProgressActivityName -status $DeletingCloudResourceMessageProgress -percentcomplete 80
                Write-VerboseLog ("$DeletingCloudResourceMessageProgress")
                $remResource =  Execute-Without-ProgressBar -ScriptBlock { Remove-AzResource -ResourceId $resourceId -ApiVersion $RPAPIVersion -Force } 
                $clusterAADApplication = Get-AzADApplication -ApplicationId $resource.Properties.aadClientId -ErrorAction:SilentlyContinue
                if($clusterAADApplication -ne $Null)
                {
                    # when registration happens via older version of the registration script and unregistration happens via newever version
                    # service will  not be able to delete the app since it does not own it.
                    try
                    {
                        Write-VerboseLog ("Deleting Cluster AAD application: $($resource.Properties.aadClientId)") 
                        Remove-AzADApplication -ApplicationId  $resource.Properties.aadClientId -ErrorAction Stop | Out-Null
                    }
                    catch
                    {
                        #consume exception, this is best effort. Log warning and continue if it fails.
                        $msg = "Deleting Cluster AAD application Failed $($resource.Properties.aadClientId) . ErrorMessage : {0}. Please delete it manually." -f ($_.Exception.Message)
                        Write-NodeEventLog -Message $msg  -EventID 9010 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
                        Write-WarnLog ($msg)
                    }
                    
                }
            }
            Write-VerboseLog("Unregister ResourceGroupName $ResourceGroupName")
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName

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
            Write-NodeEventLog -Message $UnregistrationSuccessDetailsMessage -EventID 9007 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName
        }

        Write-Output $unregistrationOutput | Format-List
    }
    catch
    {
         # Get script line number, offset and Command that resulted in exception. Write-ErrorLog with the exception above does not write this info.
         $positionMessage = $_.InvocationInfo.PositionMessage
         Write-NodeEventLog -Message ("Exception occurred in Unregister-AzStackHCI : " + $positionMessage) -EventID 9118 -IsManagementNode $IsManagementNode -credentials $Credential -ComputerName $ComputerName -Level Warning

        if(-Not $Error.Contains($AlreadyLoggedFlag))
        {
            Write-ErrorLog ("Exception occurred in Unregister-AzStackHCI") -Exception $_ -Category OperationStopped -ErrorAction Continue
        }

    }
    finally
    {
        try{ Disconnect-AzAccount | Out-Null } catch{}
        if($DebugPreference -ne "SilentlyContinue")
        {
            try{ Stop-Transcript | Out-Null }catch{}
        }
    }
}

function Remove-ArcRoleAssignments {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [String] $ResourceGroupName,
        [String] $ResourceId
    )
    try 
    {
        Write-VerboseLog ("Removing Arc onboarding role from HCI RP App on resource group: $ResourceGroupName.")
        $arcResourcesInArcRG = Get-AzResource -ResourceGroupName $ResourceGroupName -ResourceType $ArcMachineResourceType
        $clusterCloudResource = Get-AzResource -ResourceId $ResourceId -ApiVersion $RPAPIVersion -ErrorAction Ignore
    
        foreach ($arcResource in $arcResourcesInArcRG)
        {
            $arcResourceDetails = Get-AzResource -ResourceId $arcResource.ResourceId -ApiVersion $HCApiVersion
            if(-Not [string]::IsNullOrEmpty($arcResourceDetails.Properties.parentClusterResourceId))
            {
                Write-VerboseLog ("Arc for server resource with parentClusterResourceId set exists in the resource group: $ResourceGroupName. Won't remove Arc onboarding role from HCI RP App.")
                return
            }
        }
    
        if(($null -ne $clusterCloudResource) -and ($null -ne $clusterCloudResource.Properties.resourceProviderObjectId))
        {
            Remove-AzRoleAssignment -ObjectId $clusterCloudResource.Properties.resourceProviderObjectId -ResourceGroupName $ResourceGroupName -RoleDefinitionName $ArcOnboardingRole -ErrorAction Stop
            Write-VerboseLog ("Successfully removed role: {0} from HCI RP App on resource group: {1}" -f $ArcOnboardingRole, $ResourceGroupName)
        }
        else
        {
            if($null -eq $clusterCloudResource)
            {
                Write-VerboseLog ("Unable to remove Arc onboarding role from HCI RP App as HCI cluster cloud resource doesn't exist.")
            }
            else
            {
                Write-VerboseLog ("Unable to remove Arc onboarding role from HCI RP App as HCI cluster cloud resource doesn't contain resourceProviderObjectId.")
            }
        }        
    }
    catch 
    {
        Write-VerboseLog ("Exception occurred while removing Arc onboarding role from HCI RP App on Arc resource group: {0}" -f $_.Exception.Message)    
    }
}

function Remove-ResourceGroup {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
        [String] $ResourceGroupName 
    )
    Write-VerboseLog ("Trying to delete resource group: $ResourceGroupName")
    $resGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction Ignore
    if ($Null -eq $resGroup) 
    {
        Write-VerboseLog ("Resource Group Not Found")
        return
    }

    $resGroupTags = $resGroup.Tags
    if ($Null -eq $resGroupTags) 
    {
        Write-VerboseLog ("No tags found on the Resource Group, Not Deleting.")
        return
    }
    $resGroupTagsCreatedBy = $resGroupTags[$ResourceGroupCreatedByName]

    # If resource is created by us during registration and if there are no resources in resource group, then delete it.
    if ($resGroupTagsCreatedBy -eq $ResourceGroupCreatedByValue) 
    {
        $resourcesInRG = Get-AzResource -ResourceGroupName $ResourceGroupName

        if ($null -eq $resourcesInRG) 
        {
            # Resource group is empty
            Write-VerboseLog ("Resource group $ResourceGroupName is empty and created by Az.StackHCI. Deleting it")
            try 
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -Force | Out-Null
            }
            catch 
            {
                Write-VerboseLog ("Deleting Resource Group $ResourceGroupName failed. ErrorMessage : {0}" -f ($_.Exception.Message))
            }
        }
        else 
        {
            Write-VerboseLog ("Resource group is not empty, not deleting ")
        }
    }
    else 
    {
        Write-VerboseLog ("Resource group not created by Az.StackHCI. Not deleting")
    }
}

<#
    .Description
    Set-AzStackHCI modifies resource properties of the Microsoft.AzureStackHCI cloud resource representing the on-premises cluster to enable or disable features.

    .PARAMETER ComputerName
    Specifies one of the cluster node in on-premise cluster that is registered to Azure.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .PARAMETER ResourceId
    Specifies the fully qualified resource ID, including the subscription, as in the following example: `/Subscriptions/`subscription ID`/providers/Microsoft.AzureStackHCI/clusters/MyCluster`

    .PARAMETER EnableWSSubscription
    Specifies if Windows Server Subscription should be enabled or disabled. Enabling this feature starts billing through your Azure subscription for Windows Server guest licenses.

    .PARAMETER DiagnosticLevel
    Specifies the diagnostic level for the cluster.

    .PARAMETER TenantId
    Specifies the Azure TenantId.

    .PARAMETER ArmAccessToken
    Specifies the ARM access token. Specifying this along with AccountId will avoid Azure interactive logon.

    .PARAMETER GraphAccessToken
    GraphAccessToken is deprecated.

    .PARAMETER AccountId
    Specifies the ARM access token. Specifying this along with ArmAccessToken will avoid Azure interactive logon.

    .PARAMETER EnvironmentName
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

    .PARAMETER UseDeviceAuthentication
    Use device code authentication instead of an interactive browser prompt.

    .PARAMETER Force
    Forces the command to run without asking for user confirmation.

    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Result: Success or Failed or Cancelled.

    .EXAMPLE
    Invoking on one of the cluster node to enable Windows Server Subscription feature
    PS C:\> Set-AzStackHCI -EnableWSSubscription $true
    Result: Success

    .EXAMPLE
    Invoking from the management node to set the diagnostic level to Basic
    PS C:\> Set-AzStackHCI -ComputerName ClusterNode1 -DiagnosticLevel Basic
    Result: Success
#>
function Set-AzStackHCI{
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
[OutputType([PSCustomObject])]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [string] $ComputerName,

    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential,

    [Parameter(Mandatory = $false)]
    [string] $ResourceId,

    [Parameter(Mandatory = $false)]
    [Bool] $EnableWSSubscription,

    [Parameter(Mandatory = $false)]
    [DiagnosticLevel] $DiagnosticLevel,

    [Parameter(Mandatory = $false)]
    [string] $TenantId,

    [Parameter(Mandatory = $false)]
    [string] $ArmAccessToken,

    [Parameter(Mandatory = $false)]
    [string] $AccountId,

    [Parameter(Mandatory = $false)]
    [string] $EnvironmentName = $AzureCloud,

    [Parameter(Mandatory = $false)]
    [Switch]$UseDeviceAuthentication,

    [Parameter(Mandatory = $false)]
    [Switch] $Force
    )

    $setOutput          = New-Object -TypeName PSObject
    $doSetResource      = $false
    $needShouldContinue = $false
    $doAzAuth           = $false
    $isManagementNode   = $false
    $nodeSessionParams  = @{}
    $subscriptionId     = [string]::Empty
    $armResourceId      = [string]::Empty
    $armResource        = $null

    $successMessage     = New-Object -TypeName System.Text.StringBuilder

    try
    {
        Setup-Logging -LogFilePrefix "SetAzStackHCI"  -DebugEnabled  ($DebugPreference -ne "SilentlyContinue")

        Show-LatestModuleVersion

        if([string]::IsNullOrEmpty($ComputerName))
        {
            $ComputerName = [Environment]::MachineName
            $isManagementNode = $false
        }
        else
        {
            $isManagementNode = $true
        }
        
        Write-Progress -Id $MainProgressBarId -Activity $SetProgressActivityName -Status $CheckingDependentModules -PercentComplete 2
        Check-DependentModules
        
        Write-Progress -Id $MainProgressBarId -Activity $SetProgressActivityName -Status $SetProgressStatusGathering -PercentComplete 5

        if($PSBoundParameters.ContainsKey('ResourceId') -eq $false)
        {
            $regContext = $null

            if($isManagementNode)
            {
                $nodeSessionParams.Add('ComputerName', $ComputerName)

                if($Credential -ne $null)
                {
                    $nodeSessionParams.Add('Credential', $Credential)
                }

                $regContext = Invoke-Command @nodeSessionParams -ScriptBlock { Get-AzureStackHCI }
            }
            else
            {
                $regContext = Get-AzureStackHCI
            }

            if ($regContext.RegistrationStatus -ne [RegistrationStatus]::Registered)
            {
                Write-ErrorLog -Category InvalidOperation -Message $SetAzResourceClusterNotRegistered -Category OperationStopped -ErrorAction Continue
                $setOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value ([OperationStatus]::Failed)
                $setOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value $SetAzResourceClusterNotRegistered
                Write-Output $setOutput | Format-List
                throw
            }

            $clusScript = {
                    $clusterPowershell = Get-WindowsFeature -Name RSAT-Clustering-PowerShell;
                    if ( $clusterPowershell.Installed -eq $false)
                    {
                        Install-WindowsFeature RSAT-Clustering-PowerShell | Out-Null;
                    }
                }

            Invoke-Command @nodeSessionParams -ScriptBlock $clusScript

            $clusterNodes = Invoke-Command @nodeSessionParams -ScriptBlock { Get-ClusterNode }

            $nodeDown = $false
            $nodeDown = ($clusterNodes | % { if ($_.State -ne 'Up') { return $true } })

            if ($nodeDown -eq $true)
            {
                Write-ErrorLog -Category ConnectionError -Message $SetAzResourceClusterNodesDown -Category OperationStopped -ErrorAction Continue
                $setOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value ([OperationStatus]::Failed)
                $setOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyErrorDetail -Value $SetAzResourceClusterNodesDown
                Write-Output $setOutput | Format-List
                throw
            }

            $subscriptionId    = $regContext.AzureResourceUri.Split('/')[2]
            $resourceGroupName = $regContext.AzureResourceUri.Split('/')[4]
            $resourceName      = $regContext.AzureResourceUri.Split('/')[8]

            $armResourceId = Get-ResourceId -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -ResourceName $resourceName
        }
        else
        {
            $armResourceId  = $ResourceId
            $subscriptionId = $ResourceId.Split('/')[2]
        }

        Write-Progress -Id $MainProgressBarId -Activity $SetProgressActivityName -Status $SetProgressStatusGetAzureResource -PercentComplete 20

        if($PSBoundParameters.ContainsKey('ArmAccessToken') -eq $true)
        {
            $doAzAuth = $true
        }
        else
        {
            $azContext = Get-AzContext -ErrorAction SilentlyContinue

            if ($azContext -eq $null)
            {
                $doAzAuth = $true
            }
            else
            {
                if ($azContext.Subscription.Id -ne $subscriptionId)
                {
                    $currentOperation = ($SetProgressStatusOpSwitching -f $subscriptionId)
                    Write-Progress -Id $MainProgressBarId -Activity $SetProgressActivityName -Status $SetProgressStatusGetAzureResource -CurrentOperation $currentOperation -PercentComplete 35

                    $azContext = Set-AzContext -SubscriptionId $subscriptionId -ErrorAction Stop
                }
            }
        }

        if ($doAzAuth -eq $true)
        {
            $azureLoginParameters = @{
                                        'SubscriptionId'          = $subscriptionId;
                                        'TenantId'                = $TenantId;
                                        'ArmAccessToken'          = $ArmAccessToken;
                                        'GraphAccessToken'        = $GraphAccessToken;
                                        'AccountId'               = $AccountId;
                                        'EnvironmentName'         = $EnvironmentName;
                                        'UseDeviceAuthentication' = $UseDeviceAuthentication;
                                        'ProgressActivityName'    = $SetProgressActivityName
                                     }

            $TenantId = Azure-Login @azureLoginParameters
        }

        $armResource = Get-AzResource -ResourceId $armResourceId -ExpandProperties -ApiVersion $RPAPIVersion -ErrorAction Stop

        $properties = [PSCustomObject]@{
            desiredProperties = $armResource.Properties.desiredProperties
            aadClientId = $armResource.Properties.aadClientId
            aadTenantId = $armResource.Properties.aadTenantId
            aadServicePrincipalObjectId = $armResource.Properties.aadServicePrincipalObjectId
            aadApplicationObjectId = $armResource.Properties.aadApplicationObjectId
        }

        if ($properties.desiredProperties -eq $null)
        {
            #
            # Create desiredProperties object with default values
            #
            $desiredProperties = New-Object -TypeName PSObject
            $desiredProperties | Add-Member -MemberType NoteProperty -Name 'windowsServerSubscription' -Value 'Disabled'
            $desiredProperties | Add-Member -MemberType NoteProperty -Name 'diagnosticLevel' -Value 'Basic'

            $properties | Add-Member -MemberType NoteProperty -Name 'desiredProperties' -Value $desiredProperties
        }

        if ($PSBoundParameters.ContainsKey('EnableWSSubscription'))
        {
            if ($EnableWSSubscription -eq $true)
            {
                $properties.desiredProperties.windowsServerSubscription = 'Enabled';

                $successMessage.Append($SetAzResourceSuccessWSSE) | Out-Null;
            }
            else
            {
                $properties.desiredProperties.windowsServerSubscription = 'Disabled';

                $successMessage.Append($SetAzResourceSuccessWSSD) | Out-Null;
            }

            $doSetResource      = $true
            $needShouldContinue = $true
        }

        if ($PSBoundParameters.ContainsKey('DiagnosticLevel'))
        {
            $properties.desiredProperties.diagnosticLevel = $DiagnosticLevel.ToString()

            if ($successMessage.Length -gt 0)
            {
                $successMessage.AppendFormat(" {0}", ($SetAzResourceSuccessDiagLevel -f $DiagnosticLevel.ToString())) | Out-Null
            }
            else
            {
                $successMessage.AppendFormat("{0}", ($SetAzResourceSuccessDiagLevel -f $DiagnosticLevel.ToString())) | Out-Null
            }

            $doSetResource = $true
        }

        if ($doSetResource -eq $true)
        {
            if ($PSCmdlet.ShouldProcess($armResourceId, $SetProgressShouldProcess))
            {
                if ($needShouldContinue -eq $true)
                {
                    if (($Force -or $PSCmdlet.ShouldContinue($SetProgressShouldContinue, $SetProgressShouldContinueCaption)) -eq $false)
                    {
                        return;
                    }
                }

                Write-Progress -Id $MainProgressBarId -Activity $SetProgressActivityName -Status $SetProgressStatusUpdatingProps -PercentComplete 60

                $setAzResourceParameters = @{
                                            'ResourceId'  = $armResource.Id;
                                            'Properties'  = $properties;
                                            'ApiVersion'  = $RPAPIVersion
                                            }

                $localResult = Set-AzResource @setAzResourceParameters -Confirm:$false -Force -ErrorAction Stop

                if ($PSBoundParameters.ContainsKey('EnableWSSubscription') -and ($EnableWSSubscription -eq $false))
                {
                    Write-WarnLog ($SetProgressWarningWSSD)
                }

                if ($PSBoundParameters.ContainsKey('DiagnosticLevel') -and ($DiagnosticLevel -eq [DiagnosticLevel]::Off))
                {
                    Write-WarnLog ($SetProgressWarningDiagnosticOff)
                }
            }
            else
            {
                return;
            }
        }

        #
        # Schedule a sync on the cluster
        #
        if($PSBoundParameters.ContainsKey('ResourceId') -eq $false)
        {
            if ($doSetResource -eq $true)
            {
                Write-Progress -Id $MainProgressBarId -Activity $SetProgressActivityName -Status $SetProgressStatusSyncCluster -PercentComplete 90

                Invoke-Command @nodeSessionParams -ScriptBlock { Sync-AzureStackHCI }
            }
        }

        Write-Progress -Id $MainProgressBarId -activity $SetProgressActivityName -Completed

        $setOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value ([OperationStatus]::Success)
        $setOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value ($successMessage.ToString())

        Write-Output $setOutput | Format-List
    }
    catch
    {
        if(-Not $Error.Contains($AlreadyLoggedFlag))
        {
            Write-ErrorLog ("Exception occurred in {0}" -f $PSCmdlet.MyInvocation.InvocationName) -Exception $_ -Category OperationStopped
        }
    }
    finally
    {
        if ($doAzAuth -eq $true)
        {
            try { Disconnect-AzAccount | Out-Null } catch{}
        }
        if($DebugPreference -ne "SilentlyContinue")
        {
            try{ Stop-Transcript | Out-Null }catch{}
        }
    }
}

#
# IMDS Attestation Section
#
function Add-VMDevicesForImds{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [hashtable] $VmAdapterParams,
    [hashtable] $VmAdapterAdditionalParams,
    [hashtable] $VmAdapterVlanParams,
    [hashtable] $SessionParams
)
    $ret = @{ 
            Return    = $null
            Exception = $null
    }
    $sc = {
        param([hashtable]$VmAdapterParams, [hashtable]$VmAdapterAdditionalParams, [hashtable]$VmAdapterVlanParams)

        try
        {
            $hostVmSwitch   = $VmAdapterParams.VMSwitch
            $adapterParams  = @{
                    VM      = $VmAdapterParams.VM
                    Name    = $VmAdapterParams.Name
            }

            Write-Information ("Checking for previously configured adapter")
            $foundAdapter       = Get-VMNetworkAdapter @adapterParams -ErrorAction SilentlyContinue
            $adapterCount       = ($foundAdapter | Measure-Object).Count

            if ($adapterCount -eq 0)
            {
                Write-Information ("Creating IMDS network adapter on guest $($VM.Name)")
                $vmAdapter = Add-VMNetworkAdapter @adapterParams -Confirm: $false -Passthru
            }
            elseif ($adapterCount -eq 1)
            {
                Write-Information ("Found existing adapter on guest $($VM.Name)")
                $vmAdapter = $foundAdapter
            }
            else 
            {
                Write-Information ("Found additional IMDS configuration on guest $($VM.Name) adapter count=$($adapterCount)")
                $vmAdapter = $foundAdapter[0]    
            }

            $vmAdapter      = $vmAdapter | Set-VMNetworkAdapter @VmAdapterAdditionalParams -Confirm: $false -Passthru
        
            Connect-VMNetworkAdapter -VMNetworkAdapter $vmAdapter -VMSwitch $hostVmSwitch -Confirm: $false

            $vmAdapter      = Set-VMNetworkAdapterVlan -VMNetworkAdapter $vmAdapter @VmAdapterVlanParams -Confirm: $false -Passthru
        
            $ret.Return = $vmAdapter
            return $ret
        }
        catch
        {
            $ret.Exception = $_
            return $ret
        }
        finally
        {
            if ($ret.Exception) { try{ Remove-VMNetworkAdapter -VMNetworkAdapter $vmAdapter -Force }catch{}}
        }
    }

    $ret = Invoke-Command @SessionParams -ScriptBlock $sc -ArgumentList $VmAdapterParams,$VmAdapterAdditionalParams,$VmAdapterVlanParams -InformationVariable inf

    Write-InfoLog ($inf)
    
    if ($ret.Exception)
    {
        Write-ErrorLog "Unable to configure IMDS Service on VM. $($ret.Exception)" -Exception $ret.Exception -ErrorAction Continue
        throw
    }

    return $ret.Return
}

function Add-HostDevicesForImds{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [hashtable] $VmSwitchParams,
    [hashtable] $HostAdapterVlanParams,
    [hashtable] $NetAdapterIpParams,
    [hashtable] $SessionParams
)
    $sc = {
        param([hashtable]$VmSwitchParams, [hashtable]$HostAdapterVlanParams, [hashtable]$NetAdapterIpParams)

        $ret = @{ 
            Return    = $null
            Exception = $null
        }
        try
        {
            $ignoreAdaptersParams = @{
                Path = "HKLM:\system\currentcontrolset\services\clussvc\parameters"
                Name = "ExcludeAdaptersByFriendlyName"
            }
            $propVal    = $VmSwitchParams.Name
            $propExists = Get-ItemProperty @ignoreAdaptersParams -ErrorAction SilentlyContinue

            if ($propExists)
            {
                $existingEntries = $propExists.ExcludeAdaptersByFriendlyName -Split ","
                if ($existingEntries -notcontains $propVal)
                {
                    $existingEntries += $propVal
                }
                $propVal = $existingEntries -Join ","
            }

            New-ItemProperty @ignoreAdaptersParams -Value $propVal -Force -ErrorAction SilentlyContinue | Out-Null
            
            Write-Information ("Searching for previous IMDS switch")
            if ($VmSwitchParams.SwitchId)
            {
                $findSwitch         = Get-VMSwitch -Id $VmSwitchParams.SwitchId -ErrorAction SilentlyContinue
            }
            

            $switchCount = ($findSwitch | Measure-Object).Count

            if ($switchCount -eq 0)
            {
                Write-Information ("Creating IMDS switch")
                $VmSwitchParams.Remove("SwitchId")
                $hostSwitch     = New-VMSwitch @VmSwitchParams
            }
            elseif ($switchCount -eq 1)
            {
                Write-Information ("Found existing IMDS Service Switch.")
                $hostSwitch = $findSwitch
            }
        
            $hostVMNetAdapter   = Get-VMNetworkAdapter -ManagementOS -SwitchName $hostSwitch.Name | Where-Object { $_.SwitchId -eq $hostSwitch.Id }

            if (!$hostVMNetAdapter)
            {
                throw("Missing host adapter.")
            }

            $hostNetAdapter     = Get-NetAdapter | Where-Object { ($_.MacAddress -replace "[^a-zA-Z0-9]","") -eq ($hostVMNetAdapter.MacAddress -replace "[^a-zA-Z0-9]","") }

            $nooutput           = $hostNetAdapter | Remove-NetIPAddress -Confirm:$false -ErrorAction SilentlyContinue

            $hostNetAdapterIP   = $hostNetAdapter | New-NetIPAddress @NetAdapterIpParams

            $hostNetAdapter     = $hostNetAdapter | Rename-NetAdapter -NewName $hostSwitch.Name -PassThru -ErrorAction SilentlyContinue

            $hostBindings       = $hostNetAdapter | Get-NetAdapterBinding | Where-Object { $_.ComponentID -ne "ms_tcpip" }

            $hostBindings | Disable-NetAdapterBinding

            $retry = 2
            while ($retry -ne 0)
            {
                $clusInterface = Get-ClusterNetworkInterface -ErrorAction SilentlyContinue | Where-Object {$_.AdapterId -eq ($hostNetAdapter.DeviceId -replace "[{}]","")}

                if (($clusInterface | Measure-Object).Count -eq 1)
                {
                    Write-Information "Found ClusterNetworkInterface for Attestation adapter $($hostNetAdapter.DeviceId)."
                    $notAttestationNet = ($clusInterface.Network | Get-ClusterNetworkInterface -ErrorAction SilentlyContinue -ErrorVariable e | Where-Object {$_.Name -notlike "*$($hostNetAdapter.Name)*"})

                    if (($notAttestationNet | Measure-Object).Count -eq 0 -and $null -eq $e)
                    {
                        Write-Information "Setting Cluster network $($clusInterface.Network.Name) Role to None."
                        ($clusInterface.Network).Role = 0
                        break
                    }

                    if ($null -ne $e)
                    {
                        Write-Information "Could not query Cluster network interface. Error=$($e | Out-String)"
                    }
                    else
                    {
                        Write-Information "Cluster network contains other network adapters. Not updating Role."
                    }
                }

                Write-Information "Retrying Attestation Cluster Network Interface check..."
                $retry--
                Start-Sleep 2
            }

            $HostAdapterVlanCommonParams = @{
                VMNetworkAdapter    = $hostVMNetAdapter
            }

            Set-VMNetworkAdapterVlan @HostAdapterVlanCommonParams @HostAdapterVlanParams -Confirm: $false| Out-Null
            
            $ret.Return = $hostSwitch.Id
            return $ret
        }
        catch
        {
            $ret.Exception = $_
            return $ret
        }
        finally
        {
            if ($ret.Exception) { try{ Remove-VMSwitch -VMSwitch $hostSwitch -Force }catch{}}
        }
    }

    $ret = Invoke-Command @SessionParams -ScriptBlock $sc -ArgumentList $VMSwitchParams,$HostAdapterVlanParams,$NetAdapterIpParams -InformationVariable inf

    Write-InfoLog ($inf)

    if ($ret.Exception)
    {
        Write-ErrorLog "Unable to configure IMDS Service on host. $($ret.Exception)" -Exception $ret.Exception
        throw
    }

    return $ret.Return
}

function Set-AttestationFirewallRules{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
param(
    [bool] $Enabled,
    [hashtable] $SessionParams
)
    $sc = {
        param([bool]$Enabled)

        $TemplateFirewallRuleBlockCommon = @{
            Group                = "Azure Stack HCI"
            Enabled              = "True"
            Profile              = "Any"
            Action               = "Block"
            EdgeTraversalPolicy  = "Block"
            LooseSourceMapping   = $False
            LocalOnlyMapping     = $False
            LocalAddress         = "169.254.169.253"
            RemoteAddress        = "Any"
            RemotePort           = "Any"
            IcmpType             = "Any"
            Program              = "Any"
            Service              = "Any"
            InterfaceAlias       = "Any"
            InterfaceType        = "Any"
            LocalUser            = "Any"
            RemoteUser           = "Any"
            RemoteMachine        = "Any"
            Authentication       = "NotRequired"
            Encryption           = "NotRequired"
        }
        
        $TemplateFirewallRuleBlockTcpOutgoing = @{
            Name                 = "AzsHci-ImdsAttestation-Block-TCP-Out"
            DisplayName          = "Azure Stack HCI IMDS Attestation (TCP-Out)"
            Description          = "Outbound rule to block all traffic for Attestation interface [TCP]"
            Direction            = "Outbound"
            Protocol             = "TCP"
            LocalPort            = "Any"
        } + $TemplateFirewallRuleBlockCommon
        
        $TemplateFirewallRuleBlockTcpIncoming = @{
            Name                 = "AzsHci-ImdsAttestation-Block-TCP-In"
            DisplayName          = "Azure Stack HCI IMDS Attestation (TCP-In)"
            Description          = "Inbound rule to block all traffic for Attestation interface [TCP]"
            Direction            = "Inbound"
            Protocol             = "TCP"
            LocalPort            = @("1-79","81-65535")
        } + $TemplateFirewallRuleBlockCommon
        
        $TemplateFirewallRuleBlockUdpOutgoing = @{
            Name                 = "AzsHci-ImdsAttestation-Block-UDP-Out"
            DisplayName          = "Azure Stack HCI IMDS Attestation (UDP-Out)"
            Description          = "Outbound rule to block all traffic for Attestation interface [UDP]"
            Direction            = "Outbound"
            Protocol             = "UDP"
            LocalPort            = "Any"
        } + $TemplateFirewallRuleBlockCommon
        
        $TemplateFirewallRuleBlockUdpIncoming = @{
            Name                 = "AzsHci-ImdsAttestation-Block-UDP-In"
            DisplayName          = "Azure Stack HCI IMDS Attestation (UDP-In)"
            Description          = "Inbound rule to block all traffic for Attestation interface [UDP]"
            Direction            = "Inbound"
            Protocol             = "UDP"
            LocalPort            = "Any"
        } + $TemplateFirewallRuleBlockCommon

        $DisplayGroup = "@FirewallAPI.dll,-55001"

        $firewallRules = @($TemplateFirewallRuleBlockTcpOutgoing, $TemplateFirewallRuleBlockTcpIncoming, $TemplateFirewallRuleBlockUdpOutgoing, $TemplateFirewallRuleBlockUdpIncoming)

        foreach ($rule in $firewallRules)
        {
            $foundRule = Get-NetFirewallRule -Name ($rule.Name) -ErrorAction SilentlyContinue

            if (!$foundRule)
            {
                New-NetFirewallRule @rule
                $tmpRule = Get-NetFirewallRule -Name ($rule.Name)
                $tmpRule.Group = $DisplayGroup
                $tmpRule | Set-NetFirewallRule
            }

            Set-NetFirewallRule -Name ($rule.Name) -Enabled $($Enabled.ToString())
        }

        # Also set the embedded rule with OS
        Set-NetFirewallRule -Name "AzsHci-ImdsAttestation-Allow-In" -Enabled $($Enabled.ToString())
    }

    $ret = Invoke-Command @SessionParams -ScriptBlock $sc -ArgumentList $Enabled
}


$TemplateHostImdsParams = @{
    Name                    = "AZSHCI_HOST-IMDS_DO_NOT_MODIFY"
    SwitchType              = "Internal"
    Notes                   = "Managed by Azure Stack HCI IMDS Attestation Service"
    Promiscuous             = $true
    PrimaryVlanId           = 10
    SecondaryVlanIdList     = 200
    IPAddress               = "169.254.169.253"
    PrefixLength            = 16
    NetFirewallRuleName     = "AzsHci-ImdsAttestation-Allow-In"
}
$TemplateVmImdsParams = @{
    Name                    = "AZSHCI_GUEST-IMDS_DO_NOT_MODIFY"
    MacAddressSpoofing      = "Off"
    DhcpGuard               = "On"
    RouterGuard             = "On"
    NotMonitoredInCluster   = $true
    Isolated                = $true
    PrimaryVlanId           = 10
    SecondaryVlanId         = 200
}

<#
    .Description
    Enable-AzStackHCIAttestation configures the host and enables specified guests for IMDS attestation.
    
    .PARAMETER ComputerName
    Specifies the AzureStack HCI host to perform the operation on. Note: this host should match the host of VMName.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .PARAMETER AddVM
    After enabling each cluster node for Attestation, add all guests on each node.

    .PARAMETER Force
    No confirmations.
    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Cluster:     Name of cluster
    Node:        Name of the host.
    Attestation: IMDS Attestation status.

    .EXAMPLE
    Invoking on one of the cluster node.
    C:\PS>Enable-AzStackHCIAttestation -AddVM

    .EXAMPLE
    Invoking from WAC/Management node and adding all existing VMs cluster-wide
    C:\PS>Enable-AzStackHCIAttestation -ComputerName "host1" -AddVM
#>
function Enable-AzStackHCIAttestation{
    [CmdletBinding(SupportsShouldProcess)]
    [OutputType([PSCustomObject])]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [string] $ComputerName,
    
    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential = [System.Management.Automation.PSCredential]::Empty,

    [Parameter(Mandatory = $false)]
    [switch] $AddVM,

    [Parameter(Mandatory = $false)]
    [switch] $Force
    )

    begin
    {   
        if ($Force)
        {
            $ConfirmPreference = 'None'
        }

        try
        {
            $logPath = "EnableAzureStackHCIImds"
            Setup-Logging -LogFilePrefix $logPath -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
            #Show-LatestModuleVersion

            $enableImdsOutputList = [System.Collections.ArrayList]::new()
            $HyperVInstallConfirmed = $false

            if([string]::IsNullOrEmpty($ComputerName))
            {
                $ComputerName = [Environment]::MachineName
                $IsManagementNode = $False
            }
            else
            {
                $IsManagementNode = $True
            }

            $percentComplete = 1
            Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status $FetchingRegistrationState -percentcomplete $percentComplete
            
            $SessionParams = @{
                    ErrorAction = "Stop"
            }

            if($IsManagementNode)
            {
                $SessionParams.Add("ComputerName", $ComputerName)
                
                if($Null -eq $Credential)
                {
                    $SessionParams.Add("Credential", $Credential)
                }
            }
            else
            {
                # An empty SessionParams will ensure commands run locally without issue
                #$SessionParams.add("ComputerName", "localhost")
            }

            # Validate cluster is registered
            $RegContext = Invoke-Command @SessionParams -ScriptBlock { Get-AzureStackHCI }

            if($RegContext.RegistrationStatus -ne [RegistrationStatus]::Registered)
            {
                throw $ImdsClusterNotRegistered
            }

            $percentComplete = 5
            Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status $DiscoveringClusterNodes -percentcomplete $percentComplete

            $ClusterName  = Invoke-Command @SessionParams -ScriptBlock { (Get-Cluster).Name }
            $ClusterNodes = Invoke-Command @SessionParams -ScriptBlock { Get-ClusterNode }

            # Validate Cluster nodes are online
            if (($ClusterNodes | Where {$_.State -ne [Microsoft.FailoverClusters.PowerShell.ClusterNodeState]::Up} | Measure-Object).Count -ne 0)
            {
                throw $AllClusterNodesAreNotOnline
            }

            $percentComplete = 10
            Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status $DiscoveringClusterNodes -percentcomplete $percentComplete

            $nodePercentChunk = (100 - ($percentComplete + 5)) / $ClusterNodes.Count / 2

        }
        catch
        {
            Write-ErrorLog -Message "Exception occurred in Enable-AzueStackHCIImdsAttestation" -Exception $_ -Category OperationStopped  -ErrorAction Continue
            throw
        }
    }

    Process
    {
        foreach ($node in $ClusterNodes)
        {
            $NodeName = $node.Name
            
            try 
            {
                Write-InfoLog ("Enabling IMDS Attestation on $NodeName")
                
                $percentComplete = $percentComplete + ($nodePercentChunk / 2)
                $ConfiguringClusterNode -f $NodeName | % { Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete }

                $SessionParams["ComputerName"] = $NodeName
            
                if ($NodeName -ieq [Environment]::MachineName)
                {
                    $SessionParams.Remove("ComputerName")
                }

                $needHyperV = Invoke-Command @SessionParams -ScriptBlock { (Get-WindowsFeature -Name RSAT-Hyper-V-Tools).Installed -eq $false }   
                if ($needHyperV)
                {
                    if ($Force -or $HyperVInstallConfirmed -or $PSCmdlet.ShouldContinue($ShouldContinueHyperVInstall -f $NodeName, "Install Management Tools"))
                    {
                        if ($HyperVInstallConfirmed -or $PSCmdlet.ShouldProcess("Windows Feature RSAT-Hyper-V-Tools is installed on $($NodeName).", "Install RSAT-Hyper-V-Tools?", ""))
                        {
                            $HyperVInstallConfirmed = $true
                            Invoke-Command @SessionParams -ScriptBlock { Install-WindowsFeature RSAT-Hyper-V-Tools | Out-Null }
                        }
                    }
                    else
                    {
                        throw "Hyper-V RSAT tools required to continue"
                    }
                }
            
                $attestationSwitchId = Invoke-Command @SessionParams -ScriptBlock { (Get-AzureStackHCIAttestation).AttestationSwitchId }

                $HostVmSwitchParams = @{
                                Name                = $TemplateHostImdsParams["Name"]
                                SwitchType          = $TemplateHostImdsParams["SwitchType"]
                                Notes               = $TemplateHostImdsParams["Notes"]
                                SwitchId            = $attestationSwitchId
                }
                $HostAdapterVlanParams = @{
                                Promiscuous         = $TemplateHostImdsParams["Promiscuous"]
                                PrimaryVlanId       = $TemplateHostImdsParams["PrimaryVlanId"]
                                SecondaryVlanIdList = $TemplateHostImdsParams["SecondaryVlanIdList"]
                }
                $NetAdapterIpParams = @{
                                IPAddress           = $TemplateHostImdsParams["IPAddress"]
                                PrefixLength        = $TemplateHostImdsParams["PrefixLength"]
                }

                # Validate or Configure a new switch on host
                if($attestationSwitchId -or $Force -or $PSCmdlet.ShouldContinue($ConfirmEnableImds, "Enable Cluster $($ClusterName)?"))
                {
                    $Force = $true
                    if ($PSCmdlet.ShouldProcess("IMDS Service will be configured/validated on the host $($NodeName).", "A switch managed by the IMDS Service must be configured/validated on the host $($NodeName). Process host?", ""))
                    {
                        $percentComplete = $percentComplete + ($nodePercentChunk / 2)
                        $ConfiguringClusterNode -f $NodeName | % { Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete }
                        
                        $NotifyServiceNewSwitch = !$attestationSwitchId
                        $attestationSwitchId = Add-HostDevicesForImds -VmSwitchParams $HostVmSwitchParams -HostAdapterVlanParams $HostAdapterVlanParams -NetAdapterIpParams $NetAdapterIpParams -SessionParams $SessionParams
                        
                        # Wait for networking stack to stabalize
                        $percentComplete = $percentComplete + ($nodePercentChunk / 2)
                        Start-Sleep 10

                        if ($NotifyServiceNewSwitch)
                        {
                            Invoke-Command @SessionParams -ScriptBlock { param($switchId); Set-AzureStackHCIAttestation -SwitchId $switchId } -ArgumentList $attestationSwitchId | Out-Null
                        }

                        Set-AttestationFirewallRules -SessionParams $SessionParams -Enabled $True

                        $nodeAttestation = (Invoke-Command @SessionParams -ScriptBlock { Get-AzureStackHCIAttestation })

                        $enableImdsOutput = New-Object -TypeName PSObject
                        $enableImdsOutput | Add-Member -MemberType NoteProperty -Name ComputerName -Value ($nodeAttestation.ComputerName)
                        $enableImdsOutput | Add-Member -MemberType NoteProperty -Name Status -Value ([ImdsAttestationNodeStatus]($nodeAttestation.Status))
                        $enableImdsOutput | Add-Member -MemberType NoteProperty -Name Expiration -Value ($nodeAttestation.Expiration)

                        $enableImdsOutputList.Add($enableImdsOutput) | Out-Null
                    }
                    elseif ($WhatIfPreference.IsPresent)
                    {
                        $attestationSwitchId = "Whatif:$(New-Guid)"
                    }
                }
                else 
                {
                    return
                }          
            }
            catch 
            {
                Write-ErrorLog ("Exception occurred in Enable-AzStackHCIAttestation") -Exception $_ -Category OperationStopped -ErrorAction Continue
                throw
            }
        }

        if ($AddVM)
        {
            foreach ($node in $ClusterNodes)
            {
                $NodeName = $node.Name
                
                $SessionParams["ComputerName"] = $NodeName
            
                if ($NodeName -ieq [Environment]::MachineName)
                {
                    $SessionParams.Remove("ComputerName")
                }
                try 
                {
                    Write-InfoLog ("Adding VMs to IMDS Attestation on $NodeName")
                    $ConfiguringClusterNode -f $NodeName | % { Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete }

                    Invoke-Command @SessionParams -ScriptBlock { Add-AzStackHCIVMAttestation -AddAll } | Out-Null
                }
                catch 
                {
                    Write-ErrorLog $ErrorAddingAllVMs -Category OperationStopped 
                }
            }
        }

        Invoke-Command @SessionParams -ScriptBlock { Sync-AzureStackHCI }

        Write-Progress -Id $MainProgressBarId -activity $EnableAzsHciImdsActivity -status "Complete" -percentcomplete 100
    }
    End
    {
        $enableImdsOutputList | Write-Output
    }
}

<#
    .Description
    Disable-AzStackHCIAttestation disables IMDS Attestation on the host

    .PARAMETER RemoveVM
    Specifies the guests on each node should be removed from IMDS Attestation before disabling on cluster. Disable cannot continue before guests are removed.
    
    .PARAMETER ComputerName
    Specifies the AzureStack HCI host to perform the operation on.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

    .PARAMETER Force
    No confirmation.
    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Cluster:     Name of cluster
    Node:        Name of the host.
    Attestation: IMDS Attestation status.
    .EXAMPLE
    Remove all guests from IMDS Attestation before disabling on cluster nodes.
    C:\PS>Disable-AzStackHCIAttestation -RemoveVM

    .EXAMPLE
    Invoking from the management node/WAC
    C:\PS>Disable-AzStackHCIAttestation -ComputerName "host1"
#>
function Disable-AzStackHCIAttestation{
    [CmdletBinding(SupportsShouldProcess)]
    [OutputType([PSCustomObject])]
param(
    [Parameter(Position = 0, Mandatory = $false)]
    [string] $ComputerName,
    
    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential = [System.Management.Automation.PSCredential]::Empty,

    [Parameter(Mandatory = $false)]
    [switch] $RemoveVM,

    [Parameter(Mandatory = $false)]
    [switch] $Force
    )

    begin
    {   
        try
        {
            $logPath = "DisableAzureStackHCIImds"
            Setup-Logging -LogFilePrefix $logPath -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
            #Show-LatestModuleVersion

            $disableImdsOutputList = [System.Collections.ArrayList]::new()

            if([string]::IsNullOrEmpty($ComputerName))
            {
                $ComputerName = [Environment]::MachineName
                $IsManagementNode = $False
            }
            else
            {
                $IsManagementNode = $True
            }

            $percentComplete = 1
            Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $FetchingRegistrationState -percentcomplete $percentComplete
            
            $SessionParams = @{
                    ErrorAction = "Stop"
            }

            if($IsManagementNode)
            {
                $SessionParams.Add("ComputerName", $ComputerName)
                
                if($Null -eq $Credential)
                {
                    $SessionParams.Add("Credential", $Credential)
                }
            }
            else
            {
                # An empty SessionParams will ensure commands run locally without issue
                #$SessionParams.add("ComputerName", "localhost")
            }

            $percentComplete = 5
            Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $DiscoveringClusterNodes -percentcomplete $percentComplete

            $ClusterName  = Invoke-Command @SessionParams -ScriptBlock { (Get-Cluster).Name }            
            $ClusterNodes = Invoke-Command @SessionParams -ScriptBlock { Get-ClusterNode }

            foreach ($node in $ClusterNodes)
            {
                $percentComplete += 1
                $CheckingClusterNode -f $node.name | % {Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete}
                $NodeName = $node.Name
                $SessionParams["ComputerName"] = $NodeName
            
                if (!$IsManagementNode -and ($NodeName -ieq $ComputerName))
                {
                    $SessionParams.Remove("ComputerName")
                }

                if (!$RemoveVM)
                {
                    $guests = Invoke-Command @SessionParams -ScriptBlock { Get-AzStackHCIVMAttestation -Local }
                    if (($guests | Measure-Object).Count -ne 0)
                    {
                        throw ("There are still guests connected to IMDS Attestation. Use switch -RemoveVM or Remove-AzStackHCIVMAttestation cmdlet.")
                    }
                }
                else 
                {
                    $RemovingVmImdsFromNode -f $node.name | % {Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete}
                    $removedGuests = Invoke-Command @SessionParams -ScriptBlock { Remove-AzStackHCIVMAttestation -RemoveAll }
                }
            }

            $percentComplete = 10
            Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $DiscoveringClusterNodes -percentcomplete $percentComplete

            $nodePercentChunk = (100 - ($percentComplete + 5)) / $ClusterNodes.Count
        }
        catch
        {
            Write-ErrorLog ("Exception occurred in Enable-AzueStackHCIImdsAttestation") -Exception $_ -Category OperationStopped -ErrorAction Continue
            throw
        }
    }

    Process
    {
        if($Force -or $PSCmdlet.ShouldContinue($ConfirmDisableImds, "Disable Cluster $($ClusterName)?"))
        {
        foreach ($node in $ClusterNodes)
        {
            $NodeName = $node.Name
            
            try 
            {
                Write-InfoLog ("Disabling IMDS Attestation on $NodeName")
                
                $percentComplete = $percentComplete + ($nodePercentChunk / 2)
                $DisablingIMDSOnNode -f $NodeName | % {Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete;}

                $SessionParams["ComputerName"] = $NodeName
            
                if ($NodeName -ieq [Environment]::MachineName)
                {
                    $SessionParams.Remove("ComputerName")
                }
            
                $attestationSwitchId = Invoke-Command @SessionParams -ScriptBlock { (Get-AzureStackHCIAttestation).AttestationSwitchId }
                if ($attestationSwitchId -ne [Guid]::Empty -and $attestationSwitchId)
                {
                    Invoke-Command @SessionParams -ScriptBlock { param($switchId); Get-VMSwitch -SwitchId $switchId -ErrorAction SilentlyContinue | Remove-VMSwitch -Force -ErrorAction SilentlyContinue } -ArgumentList $attestationSwitchId
                }


                $percentComplete = $percentComplete + ($nodePercentChunk / 2)
                $DisablingIMDSOnNode -f $NodeName | % {Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status $_ -percentcomplete $percentComplete; }
                
                Invoke-Command @SessionParams -ScriptBlock { param($switchId); Set-AzureStackHCIAttestation -SwitchId $switchId } -ArgumentList ([Guid]::Empty) | Out-Null

                Set-AttestationFirewallRules -SessionParams $SessionParams -Enabled $False

                $nodeAttestation = (Invoke-Command @SessionParams -ScriptBlock { Get-AzureStackHCIAttestation })

                $disableImdsOutput = New-Object -TypeName PSObject
                $disableImdsOutput | Add-Member -MemberType NoteProperty -Name ComputerName -Value ($nodeAttestation.ComputerName)
                $disableImdsOutput | Add-Member -MemberType NoteProperty -Name Status -Value ([ImdsAttestationNodeStatus]($nodeAttestation.Status))
                $disableImdsOutput | Add-Member -MemberType NoteProperty -Name Expiration -Value ($nodeAttestation.Expiration)
                
                $disableImdsOutputList.Add($disableImdsOutput) | Out-Null
            }
            catch 
            {
                Write-ErrorLog ("Exception occurred in Enable-AzueStackHCIImdsAttestation") -Exception $_ -Category OperationStopped -ErrorAction Continue
                throw
            }
        }
    }
        Invoke-Command @SessionParams -ScriptBlock { Sync-AzureStackHCI }

        Write-Progress -Id $MainProgressBarId -activity $DisableAzsHciImdsActivity -status "Complete" -percentcomplete 100
    }
    End
    {
        $disableImdsOutputList | Write-Output
    }
}

<#
    .Description
    Add-AzStackHCIVMAttestation configures guests for AzureStack HCI IMDS Attestation.
    
    .PARAMETER VMName
    Specifies an array of guest VMs to enable.

    .PARAMETER VM
    Specifies an array of VM objects from Get-VM.

    .PARAMETER AddAll
    Specifies a switch that will add all current guest VMs on host to IMDS Attestation on the current node.

    .Parameter Force
    No confirmations.
    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Name:            Name of the VM.
    AttestationHost: Host that VM is currently connected.
    Status:          Connection status.

    .EXAMPLE
    Adding all guests on current node
    C:\PS>Add-AzStackHCIVMAttestation -AddAll

    .EXAMPLE
    Invoking from the management node/WAC
    C:\PS>Invoke-Command -ScriptBlock {Add-AzStackHCIVMAttestation -VMName "guest1", "guest2"} -ComputerName "node1"
#>
function Add-AzStackHCIVMAttestation{
    [CmdletBinding(DefaultParameterSetName="VMName", SupportsShouldProcess)]
    [OutputType([PSCustomObject])]
param(
    [Parameter(Position = 0, Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "VMName")]
    [string[]] $VMName,

    [parameter(Position = 0, Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "VMObject")]
    [Object[]] $VM,

    [Parameter(Mandatory = $true, ParameterSetName = "AddAll")]
    [Switch]$AddAll,

    [Parameter(Mandatory = $false)]
    [switch] $Force
    )

    begin
    {   
        if ($Force)
        {
            $ConfirmPreference = 'None'
        }

        try
        {
            $logPath = "AddAzureStackHCIImds"
            Setup-Logging -LogFilePrefix $logPath -DebugEnabled ($DebugPreference -ne "SilentlyContinue")

            $enableImdsOutputList = [System.Collections.ArrayList]::new()
            $ComputerName = [Environment]::MachineName

            $percentcomplete = 1
            Write-Progress -Id $SecondaryProgressBarId -activity $AddAzsHciImdsActivity -status $FetchingRegistrationState -percentcomplete $percentcomplete
            
            $SessionParams = @{
                    ErrorAction = "Stop"
            }

            # Validate cluster is registered
            $RegContext = Invoke-Command @SessionParams -ScriptBlock { Get-AzureStackHCI }

            if($RegContext.RegistrationStatus -ne [RegistrationStatus]::Registered)
            {
                throw $ImdsClusterNotRegistered
            }

            $percentcomplete = 2
            Write-Progress -Id $SecondaryProgressBarId -activity $AddAzsHciImdsActivity -status "Verifying attestation" -percentcomplete $percentComplete

            
            $attestationSwitchId = Invoke-Command @SessionParams -ScriptBlock { (Get-AzureStackHCIAttestation).AttestationSwitchId }

            # Validate or Configure a new switch on host
            if(!$attestationSwitchId)
            {
                $message = $AttestationNotEnabled -f $ComputerName
                throw $message
            }          

            if ($WhatIfPreference.IsPresent)
            {
                $attestationSwitchId = "Whatif:$(New-Guid)"
            }
            
            if ($PSCmdlet.ShouldProcess("Will use IMDS switch $($attestationSwitchId) on $($ComputerName).", "The IMDS switch $($attestationSwitchId) was validated on $($ComputerName). Select and Continue?", ""))
            {
                $attestationSwitch = Invoke-Command @SessionParams -ScriptBlock {param($attestationSwitchId) Get-VMSwitch -Id $attestationSwitchId} -ArgumentList $attestationSwitchId
            }
            else
            {
                return
            }
            

            if ($PSCmdlet.ParameterSetName -eq "AddAll")
            {
                $VirtualMachines = Invoke-Command @SessionParams -ScriptBlock { Get-VM }
                Write-VerboseLog ("EnableAll specified. Found ($(($VirtualMachines | Measure-Object).Count) guests VMs.")
            }
        }
        catch
        {
            Write-ErrorLog ("Exception occurred in Add-AzStackHCIVMAttestation") -Exception $_ -Category OperationStopped -ErrorAction Continue
            throw
        }
    }

    Process
    {
        try 
        {
            if (!$attestationSwitch)
            {
                throw ("Did not validate host configuration")
            }
            Write-InfoLog ("Enabling IMDS Attestation on guest virtual machines")
            if ($VMName) 
            {
                $VirtualMachines = Invoke-Command @SessionParams -ScriptBlock {param($vms) Get-VM $vms} -ArgumentList (,$VMName)
            }
            elseif ($VM) 
            {
                $VirtualMachines = $VM
            }
            
            $VmNetAdapterParams = @{
                    Name                    = $TemplateVmImdsParams["Name"]
                    VmSwitch                = $attestationSwitch
            }
            $VmAdapterAdditionalParams = @{
                    MacAddressSpoofing      = $TemplateVmImdsParams["MacAddressSpoofing"]
                    DhcpGuard               = $TemplateVmImdsParams["DhcpGuard"]
                    RouterGuard             = $TemplateVmImdsParams["RouterGuard"]
                    NotMonitoredInCluster   = $TemplateVmImdsParams["NotMonitoredInCluster"]
            }
            $VmAdapterVlanParams = @{
                    Isolated                = $TemplateVmImdsParams["Isolated"]
                    PrimaryVlanId           = $TemplateVmImdsParams["PrimaryVlanId"]
                    SecondaryVlanId         = $TemplateVmImdsParams["SecondaryVlanId"]
            }

            foreach ($vm in $VirtualMachines)
            {
                if ($PSCmdlet.ShouldProcess("Added/Validated $($vm.Name) on host $($attestationSwitch.ComputerName)", "Add/Validate $($vm.Name) to IMDS Attestation on $($attestationSwitch.ComputerName)?", ""))
                {
                    $VmNetAdapterParams["VM"] = $vm
                    $vmAdapter = Add-VMDevicesForImds $VmNetAdapterParams $VmAdapterAdditionalParams $VmAdapterVlanParams $SessionParams
                    
                    $enableImdsOutput = New-Object -TypeName PSObject
                    $enableImdsOutput | Add-Member -MemberType NoteProperty -Name Name -Value $vm.Name
                    $enableImdsOutput | Add-Member -MemberType NoteProperty -Name AttestationHost -Value $ComputerName
                    $enableImdsOutput | Add-Member -MemberType NoteProperty -Name Status -Value ([VMAttestationStatus]::Connected)
                    $enableImdsOutputList.Add($enableImdsOutput) | Out-Null
                }
            } 
            
        }
        catch 
        {
            Write-ErrorLog ("Exception occurred in Add-AzStackHCIVMAttestation") -Exception $_ -Category OperationStopped -ErrorAction Continue
            throw
        }
    }
    End
    {
        $enableImdsOutputList | Write-Output
    }
}

<#
    .Description
    Remove-AzStackHCIVMAttestation removes guests from AzureStack HCI IMDS Attestation.
    
    .PARAMETER VMName
    Specifies an array of guest VMs to enable.

    .PARAMETER VM
    Specifies an array of VM objects from Get-VM.

    .PARAMETER RemoveAll
    Specifies a switch that will remove all guest VMs from Attestation on the current node

    .PARAMETER Force
    No confirmations.
    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject
    Name:            Name of the VM.
    AttestationHost: Host that VM is currently connected.
    Status:          Connection status.

    .EXAMPLE
    Removing all guests on current node
    C:\PS>Remove-AzStackHCIVMAttestation -RemoveVM

    .EXAMPLE
    Invoking from the management node/WAC
    C:\PS>Invoke-Command -ScriptBlock {Remove-AzStackHCIVMAttestation -VMName "guest1", "guest2"} -ComputerName "node1"
#>
function Remove-AzStackHCIVMAttestation{
    [CmdletBinding(DefaultParameterSetName="VMName", SupportsShouldProcess)]
    [OutputType([PSCustomObject])]
param(
    [Parameter(Position = 0, Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "VMName")]
    [string[]] $VMName,

    [parameter(Position = 0, Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = "VMObject")]
    [Object[]] $VM,

    [Parameter(Mandatory = $true, ParameterSetName = "RemoveAll")]
    [Switch]$RemoveAll,

    [Parameter(Mandatory = $false)]
    [switch] $Force
    )

    begin
    {   
        if ($Force)
        {
            $ConfirmPreference = 'None'
        }

        try
        {
            $logPath = "RemoveAzureStackHCIImds"
            Setup-Logging -LogFilePrefix $logPath -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
            #Show-LatestModuleVersion

            $removeImdsOutputList = [System.Collections.ArrayList]::new()
            $ComputerName = [Environment]::MachineName

            $percentcomplete = 1
            Write-Progress -Id $SecondaryProgressBarId -activity $RemoveAzsHciImdsActivity -status $FetchingRegistrationState -percentcomplete $percentcomplete
            
            $SessionParams = @{
                    ErrorAction = "Stop"
            }

            $percentcomplete = 2
            Write-Progress -Id $SecondaryProgressBarId -activity $RemoveAzsHciImdsActivity -status "Removing guest attestation" -percentcomplete $percentComplete

            if ($PSCmdlet.ParameterSetName -eq "RemoveAll")
            {
                $VirtualMachines = Invoke-Command @SessionParams -ScriptBlock { param($adapterName); Get-VMNetworkAdapter -All -Name $adapterName -ErrorAction SilentlyContinue | % {Get-VM $_.VMId -ErrorAction SilentlyContinue} } -ArgumentList $TemplateVmImdsParams["Name"]
                Write-VerboseLog ("RemoveAll specified. Found ($(($VirtualMachines | Measure-Object).Count) guests VMs to remove IMDS Attestation from.")
            }
        }
        catch
        {
            Write-ErrorLog ("Exception occurred in Remove-AzStackHCIVMAttestation") -Exception $_ -Category OperationStopped -ErrorAction Continue
            throw
        }
    }

    Process
    {
        try 
        {
            Write-InfoLog ("Removing IMDS Attestation on guest virtual machines")
            if ($VMName) 
            {
                $VirtualMachines = Invoke-Command @SessionParams -ScriptBlock {param($vms) Get-VM $vms} -ArgumentList (,$VMName)
            }
            elseif ($VM) 
            {
                $VirtualMachines = $VM
            }

            foreach ($vm in $VirtualMachines)
            {
                if ($PSCmdlet.ShouldProcess("Remove IMDS Attestation from $($vm.Name) on host $ComputerName", "Remove $($vm.Name) from IMDS Attestation on $ComputerName?", ""))
                {
                    Invoke-Command @SessionParams -ScriptBlock { param($adapterName); Remove-VMNetworkAdapter -VM $vm -Name $adapterName -ErrorAction Stop } -ArgumentList $TemplateVmImdsParams["Name"]
                    
                    $removeImdsOutput = New-Object -TypeName PSObject
                    $removeImdsOutput | Add-Member -MemberType NoteProperty -Name Name -Value $vm.Name
                    $removeImdsOutput | Add-Member -MemberType NoteProperty -Name AttestationHost -Value $ComputerName
                    $removeImdsOutput | Add-Member -MemberType NoteProperty -Name Status -Value ([VMAttestationStatus]::Disconnected)
                    $removeImdsOutputList.Add($removeImdsOutput) | Out-Null
                }
            }
            
        }
        catch 
        {
            Write-ErrorLog ("Exception occurred in Remove-AzStackHCIVMAttestation. Check logs for details.") -Exception $_ -Category OperationStopped -ErrorAction Continue
            throw
        }
    }
    End
    {
        $removeImdsOutputList | Write-Output
    }
}

<#
    .Description
    Get-AzStackHCIVMAttestation shows a list of guests added to IMDS Attestation on a node.

    .PARAMETER Local
    Only retrieve guests with Attestation from the node executing the cmdlet.

    .OUTPUTS
    PSCustomObject. Returns following Properties in PSCustomObject.
    Name:            Name of the VM.
    AttestationHost: Host that VM is currently connected.
    Status:          Connection status.

    .EXAMPLE
    Get all guests on cluster.
    C:\PS>Get-AzStackHCIVMAttestation

    .EXAMPLE
    Get all guests on current node.
    C:\PS>Get-AzStackHCIVMAttestation -Local

#>
function Get-AzStackHCIVMAttestation {
    [CmdletBinding()]
    [OutputType([PSCustomObject])]
param(
    [Parameter(Mandatory = $false)]
    [switch] $Local
)

    begin
    {   
        try
        {
            $getImdsOutputList = [System.Collections.ArrayList]::new()
            
            $SessionParams = @{
                    ErrorAction = "Stop"
            }
        }
        catch
        {
            Write-ErrorLog ("Exception occurred in Get-AzStackHCIVMAttestation") -Exception $_ -Category OperationStopped
            throw
        }
    }

    Process
    {
        try 
        {   
            $nodes = [Environment]::MachineName

            if (!$Local)
            {
                $nodes = (Get-ClusterNode | Select-Object Name).Name
            }

            foreach ($node in $nodes)
            {
                $SessionParams["ComputerName"] = $node
            
                if ($node -ieq [Environment]::MachineName)
                {
                    $SessionParams.Remove("ComputerName")
                }

                try 
                {
                    $VirtualMachinesAdapters = $null
                    $VirtualMachinesAdapters = Invoke-Command @SessionParams -ScriptBlock {param($adapterName); Get-VMNetworkAdapter -All -Name $adapterName -ErrorAction SilentlyContinue} -ArgumentList $TemplateVmImdsParams["Name"]
                }
                catch 
                {
                    Write-ErrorLog ("Exception occurred when querying cluster node $NodeName") -Exception $_ -Category OperationStopped
                }
                
                foreach ($adapter in $VirtualMachinesAdapters)
                {
                    $getImdsOutput = New-Object -TypeName PSObject
                    $getImdsOutput | Add-Member -MemberType NoteProperty -Name Name -Value $adapter.VMName
                    $getImdsOutput | Add-Member -MemberType NoteProperty -Name AttestationHost -Value $node
                    $getImdsOutput | Add-Member -MemberType NoteProperty -Name Status -Value ([VMAttestationStatus]::Connected)
                    $getImdsOutputList.Add($getImdsOutput) | Out-Null
                }
            }   
        }
        catch 
        {
            Write-ErrorLog ("Exception occurred in Get-AzStackHCIVMAttestation. Check logs for details.") -Exception $_ -Category OperationStopped
            throw
        }
    }
    End
    {
        $getImdsOutputList | Write-Output
    }
}

<#
.DESCRIPTION
    New-Directory creates new directory if doesn't exist already.

.PARAMETER Path
    Mandatory. Directory path.

.EXAMPLE
    Get all guests on cluster.
    C:\PS>New-Directory -Path "C:\tool"

.NOTES
#>
function New-Directory{
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    param(
    [Parameter(Mandatory=$true)][ValidateNotNull()][string]$Path
    )

    if (!(Test-Path -Path $Path -PathType Container))
    {
        Write-Progress("Creating directory at $Path")
        New-Item -ItemType Directory -Path $Path | Out-Null
    }
    else
    {
        Write-Progress("Directory already exists at $Path")
    }
}

<#
.SYNOPSIS
    Invokes deployment module download

.Description
    Invoke-DeploymentModuleDownload downloads Remote Support Deployment module from storage account.

.EXAMPLE
    Get all guests on cluster.
    C:\PS>Invoke-DeploymentModuleDownload

.NOTES
#>
function Invoke-DeploymentModuleDownload{
    # Remote Support
    New-Variable -Name RemoteSupportPackageUri -Value "https://remotesupportpackages.blob.core.windows.net/packages" -Option Constant -Scope Script
    $DownloadCacheDirectory = Join-Path $env:Temp "RemoteSupportPkgCache"

    $BlobLocation = "$script:RemoteSupportPackageUri/Microsoft.AzureStack.Deployment.RemoteSupport.psm1"
    $OutFile = (Join-Path $DownloadCacheDirectory "Microsoft.AzureStack.Deployment.RemoteSupport.psm1")
    New-Directory -Path $DownloadCacheDirectory
    Write-Progress("Downloading Remote Support Deployment module from the BLOB $BlobLocation")
    $retryCount = 3
    try
    {
        Setup-Logging -LogFilePrefix "AzStackHCIRemoteSupport" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
        Retry-Command -Attempts $retryCount -RetryIfNullOutput $false -ScriptBlock { Invoke-WebRequest -Uri $BlobLocation -outfile $OutFile }
    }
    finally
    {
       if($DebugPreference -ne "SilentlyContinue")
        {
            try{ Stop-Transcript | Out-Null }catch{}
        }
    }
}

<#
.SYNOPSIS
    Installs deploy module.

.DESCRIPTION 
    Install-DeployModule checks if given module is loaded and if not, it downloads, imports and installs remote support deployment module.

.EXAMPLE
    C:\PS>Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"

.NOTES
#>
function Install-DeployModule {
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute()]
    [CmdletBinding()]
    param (
        [Parameter(Mandatory=$true)]
        [string]
        $ModuleName
    )

    Setup-Logging -LogFilePrefix "AzStackHCIRemoteSupportInstallModule" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
    if(Get-Module | Where-Object { $_.Name -eq $ModuleName }){
        Write-InfoLog("$ModuleName is loaded already ...")
    }
    else{
        Write-InfoLog("$ModuleName is not loaded, downloading...")

        # Download Remote Support Deployment module from storage
        Invoke-DeploymentModuleDownload
    }

    $DownloadCacheDirectory = Join-Path $env:Temp "RemoteSupportPkgCache"
    # Import Remote Support Deployment module
    Import-Module (Join-Path $DownloadCacheDirectory "Microsoft.AzureStack.Deployment.RemoteSupport.psm1") -Force
}

<#
.SYNOPSIS
    Installs Remote Support.

.DESCRIPTION
    Install-AzStackHCIRemoteSupport installs Remote Support Deployment module.

.EXAMPLE
    C:\PS>Install-AzStackHCIRemoteSupport

.NOTES
#>
function Install-AzStackHCIRemoteSupport{
    [CmdletBinding(SupportsShouldProcess)]
    [OutputType([Boolean])]
    param()

    Setup-Logging -LogFilePrefix "AzStackHCIRemoteSupportInstall" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
    if(Assert-IsObservabilityStackPresent){
        Write-InfoLog("Install-AzStackHCIRemoteSupport is not available.")
    }
    else{
        Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"
        Microsoft.AzureStack.Deployment.RemoteSupport\Install-RemoteSupport
    }
}

<#
.SYNOPSIS
    Removes Remote Support.

.DESCRIPTION
    Remove-AzStackHCIRemoteSupport uninstalls Remote Support Deployment module.

.EXAMPLE
    C:\PS>Remove-AzStackHCIRemoteSupport

.NOTES
#>
function Remove-AzStackHCIRemoteSupport{
    [CmdletBinding(SupportsShouldProcess)]
    [OutputType([Boolean])]
    param()

    Setup-Logging -LogFilePrefix "AzStackHCIRemoteSupportRemove" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
    if(Assert-IsObservabilityStackPresent){
        Write-InfoLog("Remove-AzStackHCIRemoteSupport is not available.")
    }
    else{
        Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"
        Microsoft.AzureStack.Deployment.RemoteSupport\Remove-RemoteSupport
    }
}

<#
.SYNOPSIS
    Enables Remote Support.

.DESCRIPTION
    Enables Remote Support allows authorized Microsoft Support users to remotely access the device for diagnostics or repair depending on the access level granted.

.PARAMETER AccessLevel
    Controls the remote operations that can be performed. This can be either Diagnostics or DiagnosticsAndRepair.

.PARAMETER ExpireInDays
    Optional. Defaults to 8 hours.

.PARAMETER SasCredential
    Hybrid Connection SAS Credential.

.PARAMETER AgreeToRemoteSupportConsent
    Optional. If set to true then records user consent as provided and proceeds without prompt.

.EXAMPLE
    The example below enables remote support for diagnostics only for 1 day. After expiration no more remote access is allowed.
    PS C:\> Enable-AzStackHCIRemoteSupport -AccessLevel Diagnostics -ExpireInMinutes 1440 -SasCredential "Sample SAS"

.NOTES
    Requires Support VM to have stable internet connectivity.
#>
function Enable-AzStackHCIRemoteSupport{
    [CmdletBinding(SupportsShouldProcess)]
    [OutputType([Boolean])]
    param (
        [Parameter(Mandatory=$true)]
        [ValidateSet("Diagnostics","DiagnosticsRepair")]
        [string]
        $AccessLevel,

        [Parameter(Mandatory=$false)]
        [int]
        $ExpireInMinutes = 480,

        [Parameter(Mandatory=$false)]
        [string]
        $SasCredential,

        [Parameter(Mandatory=$false)]
        [switch]
        $AgreeToRemoteSupportConsent
    )

    if ($AgreeToRemoteSupportConsent -ne $true)
    {
        if($PSCmdlet.ShouldContinue("`r`nProceed with enabling remote support?", $RemoteSupportConsentText))
        {
            $AgreeToRemoteSupportConsent = $true
        }
        else
        {
            return
        }
    }

    if(Assert-IsObservabilityStackPresent){
        Import-Module DiagnosticsInitializer -Force
        Enable-RemoteSupport -AccessLevel $AccessLevel -ExpireInMinutes $ExpireInMinutes -SasCredential $SasCredential -AgreeToRemoteSupportConsent:$AgreeToRemoteSupportConsent
    }
    else{
        Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"
        Microsoft.AzureStack.Deployment.RemoteSupport\Enable-RemoteSupport -AccessLevel $AccessLevel -ExpireInMinutes $ExpireInMinutes -SasCredential $SasCredential -AgreeToRemoteSupportConsent:$AgreeToRemoteSupportConsent
    }
}

<#
.SYNOPSIS
    Disables Remote Support.

.DESCRIPTION
    Disable Remote Support revokes all access levels previously granted. Any existing support sessions will be terminated, and new sessions can no longer be established.

.EXAMPLE
    The example below disables remote support.
    PS C:\> Disable-AzStackHCIRemoteSupport

.NOTES

#>
function Disable-AzStackHCIRemoteSupport{
    [CmdletBinding(SupportsShouldProcess)]
    [OutputType([Boolean])]
    param()
    if(Assert-IsObservabilityStackPresent){
        Import-Module DiagnosticsInitializer -Force
        Disable-RemoteSupport
    }
    else{
        Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"
        Microsoft.AzureStack.Deployment.RemoteSupport\Disable-RemoteSupport
    }
}

<#
.SYNOPSIS
    Gets Remote Support Access.

.DESCRIPTION
    Gets remote support access.

.PARAMETER IncludeExpired
    Optional. Defaults to false. Indicates whether to include past expired entries.

.PARAMETER Cluster
    Optional. Defaults to false. Indicates whether to show remote support sessions across cluster.

.EXAMPLE
    The example below retrieves access level granted for remote support. The result will also include expired consents in the last 30 days.
    PS C:\> Get-AzStackHCIRemoteSupportAccess -IncludeExpired -Cluster

.NOTES

#>
function Get-AzStackHCIRemoteSupportAccess{
    [OutputType([Boolean])]
    Param(
        [Parameter(Mandatory=$false)]
        [switch]
        $Cluster,

        [Parameter(Mandatory=$false)]
        [switch]
        $IncludeExpired
    )

    if(Assert-IsObservabilityStackPresent){
        Import-Module DiagnosticsInitializer -Force
        Get-RemoteSupportAccess -IncludeExpired:$IncludeExpired
    }
    else{
        Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"
        Microsoft.AzureStack.Deployment.RemoteSupport\Get-RemoteSupportAccess -Cluster:$Cluster -IncludeExpired:$IncludeExpired
    }
}

<#
.SYNOPSIS
    Gets if Observability Remote Support Service exists. 

.DESCRIPTION
    Gets if Observability Remote Support Service exists to determine module to import.

.PARAMETER 

.EXAMPLE
    The example below returns whether environment is HCI or not.
    PS C:\> Assert-IsObservabilityStackPresent

.NOTES
#>
function Assert-IsObservabilityStackPresent{
    [OutputType([Boolean])]
    param()

    Setup-Logging -LogFilePrefix "AzStackHCIRemoteSupportObsStackPresent" -DebugEnabled ($DebugPreference -ne "SilentlyContinue")
    try{
        $obsService = Get-Service -Name "*Observability RemoteSupportAgent*" -ErrorAction SilentlyContinue
        $deviceType = (Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\AzureStack" -ErrorAction SilentlyContinue).DeviceType
        if($obsService -or $deviceType -eq "AzureEdge"){
            Write-InfoLog("AzureStack device type is AzureEdge.")
            return $true
        }
        else{
            Write-InfoLog("AzureStack device type is not AzureEdge.")
            return $false
        }
    }
    catch{
        Write-ErrorLog "Failed while getting Observability Remote Support service." -Exception $_
        return $false
    }
}

<#
.SYNOPSIS
    Gets Remote Support Session History Details.

.DESCRIPTION
    Session history represents all remote accesses made by Microsoft Support for either Diagnostics or DiagnosticsRepair based on the Access Level granted.

.PARAMETER SessionId
    Optional. Session Id to get details for a specific session. If omitted then lists all sessions starting from date 'FromDate'.

.PARAMETER IncludeSessionTranscript
    Optional. Defaults to false. Indicates whether to include complete session transcript. Transcript provides details on all operations performed during the session.

.PARAMETER FromDate
    Optional. Defaults to last 7 days. Indicates date from where to start listing sessions from until now.

.EXAMPLE
    The example below retrieves session history with transcript details for the specified session.
    PS C:\> Get-AzStackHCIRemoteSupportSessionHistory -SessionId 467e3234-13f4-42f2-9422-81db248930fa -IncludeSessionTranscript $true

.EXAMPLE
    The example below lists session history starting from last 7 days (default) to now.
    PS C:\> Get-AzStackHCIRemoteSupportSessionHistory

.NOTES

#>
function Get-AzStackHCIRemoteSupportSessionHistory{
    [OutputType([Boolean])]
    Param(
        [Parameter(Mandatory=$false)]
        [string]
        $SessionId,

        [Parameter(Mandatory=$false)]
        [switch]
        $IncludeSessionTranscript,

        [Parameter(Mandatory=$false)]
        [DateTime]
        $FromDate = (Get-Date).AddDays(-7)
    )

    if(Assert-IsObservabilityStackPresent){
        Import-Module DiagnosticsInitializer -Force
        Get-RemoteSupportSessionHistory -SessionId $SessionId -FromDate $FromDate -IncludeSessionTranscript:$IncludeSessionTranscript
    }
    else{
        Install-DeployModule -ModuleName "Microsoft.AzureStack.Deployment.RemoteSupport"
        Microsoft.AzureStack.Deployment.RemoteSupport\Get-RemoteSupportSessionHistory -SessionId $SessionId -FromDate $FromDate -IncludeSessionTranscript:$IncludeSessionTranscript
    }
}

# Export-ModuleMember -Function Register-AzStackHCI
# Export-ModuleMember -Function Unregister-AzStackHCI
# Export-ModuleMember -Function Set-AzStackHCI
# Export-ModuleMember -Function Enable-AzStackHCIAttestation
# Export-ModuleMember -Function Disable-AzStackHCIAttestation
# Export-ModuleMember -Function Add-AzStackHCIVMAttestation
# Export-ModuleMember -Function Remove-AzStackHCIVMAttestation
# Export-ModuleMember -Function Get-AzStackHCIVMAttestation
# Export-ModuleMember -Function Install-AzStackHCIRemoteSupport
# Export-ModuleMember -Function Remove-AzStackHCIRemoteSupport
# Export-ModuleMember -Function Enable-AzStackHCIRemoteSupport
# Export-ModuleMember -Function Disable-AzStackHCIRemoteSupport
# Export-ModuleMember -Function Get-AzStackHCIRemoteSupportAccess
# Export-ModuleMember -Function Get-AzStackHCIRemoteSupportSessionHistory