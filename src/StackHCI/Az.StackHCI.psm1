#
# AzureStack HCI Registration and Unregistration Powershell Cmdlets.
#

$ErrorActionPreference = 'Stop'

# Todo: Update actual GA build number and UBR later
$GAOSBuildNumber = 17784
$GAOSUBR = 1374

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
$UnregistrationSuccessDetailsMessage = "Azure Stack HCI is successfully unregistered. The Azure resource representing Azure Stack HCI has been deleted. Azure Stack HCI can’t sync with Azure until you register again."
$RegistrationSuccessDetailsMessage = "Azure Stack HCI is successfully registered. An Azure resource representing Azure Stack HCI has been created in your Azure subscription to enable an Azure-consistent monitoring, billing, and support experience."
$CouldNotGetLatestModuleInformationWarning = "Can't connect to the PowerShell Gallery to verify module version. Make sure you have the latest Az.StackHCI module with major version {0}.*."
$ConnectingToCloudBillingServiceFailed = "Can't reach Azure from node(s) {0}. Make sure every clustered node has network connectivity to Azure. Verify that your network firewall allows outbound HTTPS from port 443 to all the well-known Azure IP addresses and URLs required by Azure Stack HCI. Visit aka.ms/hcidocs for details."
$ResourceExistsInDifferentRegionError = "There is already an Azure Stack HCI resource with the same resource ID in region {0}, which is different from the input region {1}. Either specify the same region or delete the existing resource and try again."

$FetchingRegistrationState = "Checking whether the cluster is already registered"
$ValidatingParametersFetchClusterName = "Validating cmdlet parameters"
$ValidatingParametersRegisteredInfo = "Validating the parameters and checking registration information"
$RegisterProgressActivityName = "Registering Azure Stack HCI with Azure..."
$UnregisterProgressActivityName = "Unregistering Azure Stack HCI from Azure..."
$InstallAzResourcesMessage = "Installing required PowerShell module: Az.Resources"
$InstallAzureADMessage = "Installing required PowerShell module: AzureAD"
$InstallRSATHCIMessage = "Installing required Windows feature: RSAT-Azure-Stack-HCI (if not already installed)"
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
$DeletingCertificateFromAADApp = "Deleting certificate with KeyId {0} from Azure Active Directory"
$SkippingDeleteCertificateFromAADApp = "Certificate with KeyId {0} is still being used by Azure Active Directory and won't be deleted"

#endregion

#region Constants

$UsageServiceFirstPartyAppId = "1322e676-dee7-41ee-a874-ac923822781c"
$MicrosoftTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"

$MSPortalDomain = "https://ms.portal.azure.com"
$AzureCloudPortalDomain = "https://portal.azure.com"
$AzureChinaCloudPortalDomain = "https://portal.azure.cn"
$AzureUSGovernmentPortalDomain = "https://portal.azure.us"
$AzureGermanCloudPortalDomain = "https://portal.microsoftazure.de"
$AzurePPEPortalDomain = "https://df.onecloud.azure-test.net"

$AzureCloud = "AzureCloud"
$AzureChinaCloud = "AzureChinaCloud"
$AzureUSGovernment = "AzureUSGovernment"
$AzureGermanCloud = "AzureGermanCloud"
$AzurePPE = "AzurePPE"

$PortalAADAppPermissionUrl = '/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/{0}/isMSAApp/'
$PortalHCIResourceUrl = '/#@{0}/resource/subscriptions/{1}/resourceGroups/{2}/providers/Microsoft.AzureStackHCI/clusters/{3}/overview'

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
$GraphEndpointResourceIdAzureCloud = "https://graph.windows.net/"

$ServiceEndpointAzurePPE = "https://azurestackhci-df.azurefd.net"
$AuthorityAzurePPE = "https://login.windows-ppe.net"
$BillingServiceApiScopeAzurePPE = "https://azurestackhci-usage-df.azurewebsites.net/.default"
$GraphServiceApiScopeAzurePPE = "https://graph.ppe.windows.net/.default"
$GraphEndpointResourceIdAzurePPE = "https://graph.ppe.windows.net/"

$ServiceEndpointAzureChinaCloud = "https://azurestackhci-usage.trafficmanager.cn"
$AuthorityAzureChinaCloud = "https://login.chinacloudapi.cn"
$BillingServiceApiScopeAzureChinaCloud = "https://azurestackhci-usage.azurewebsites.cn/.default"
$GraphServiceApiScopeAzureChinaCloud = "https://graph.chinacloudapi.cn/.default"
$GraphEndpointResourceIdAzureChinaCloud = "https://graph.chinacloudapi.cn/"

$ServiceEndpointAzureUSGovernment = "https://azurestackhci-usage.trafficmanager.us"
$AuthorityAzureUSGovernment = "https://login.microsoftonline.us"
$BillingServiceApiScopeAzureUSGovernment = "https://azurestackhci-usage.azurewebsites.us/.default"
$GraphServiceApiScopeAzureUSGovernment = "https://graph.windows.net/.default"
$GraphEndpointResourceIdAzureUSGovernment = "https://graph.windows.net/"

$ServiceEndpointAzureGermanCloud = "https://azurestackhci-usage.trafficmanager.de"
$AuthorityAzureGermanCloud = "https://login.microsoftonline.de"
$BillingServiceApiScopeAzureGermanCloud = "https://azurestackhci-usage.azurewebsites.de/.default"
$GraphServiceApiScopeAzureGermanCloud = "https://graph.cloudapi.de/.default"
$GraphEndpointResourceIdAzureGermancloud = "https://graph.cloudapi.de/"

$RPAPIVersion = "2020-10-01"

$OutputPropertyResult = "Result"
$OutputPropertyResourceId = "AzureResourceId"
$OutputPropertyPortalResourceURL = "AzurePortalResourceURL"
$OutputPropertyPortalAADAppPermissionsURL = "AzurePortalAADAppPermissionsURL"
$OutputPropertyDetails = "Details"
$OutputPropertyTest = "Test"
$OutputPropertyEndpointTested = "EndpointTested"
$OutputPropertyIsRequired = "IsRequired"
$OutputPropertyFailedNodes = "FailedNodes"

$ConnectionTestToAzureHCIServiceName = "Connect to Azure Stack HCI Service"

$ResourceGroupCreatedByName = "CreatedBy"
$ResourceGroupCreatedByValue = "4C02703C-F5D0-44B0-ADC3-4ED5C2839E61"

$HealthEndpointPath = "/health"

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

$hciScript = {
    $hciPowershell = Get-WindowsFeature -Name RSAT-Azure-Stack-HCI;
    if ( $hciPowershell.Installed -eq $false)
    {
        Install-WindowsFeature RSAT-Azure-Stack-HCI | Out-Null;
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

function Get-PortalDomain{
param(
    [string] $TenantId,
    [string] $EnvironmentName
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
}

function Get-GraphAccessToken{
param(
    [string] $TenantId,
    [string] $EnvironmentName
    )

    # Below commands ensure there is graph access token in cache
    Get-AzADApplication -DisplayName SomeApp1 -ErrorAction Ignore | Out-Null

    if($EnvironmentName -eq $AzureCloud)
    {
        $graphTokenItemResource = $GraphEndpointResourceIdAzureCloud
    }
    elseif($EnvironmentName -eq $AzureChinaCloud)
    {
        $graphTokenItemResource = $GraphEndpointResourceIdAzureChinaCloud
    }
    elseif($EnvironmentName -eq $AzureUSGovernment)
    {
        $graphTokenItemResource = $GraphEndpointResourceIdAzureUSGovernment
    }
    elseif($EnvironmentName -eq $AzureGermanCloud)
    {
        $graphTokenItemResource = $GraphEndpointResourceIdAzureGermancloud
    }
    elseif($EnvironmentName -eq $AzurePPE)
    {
        $graphTokenItemResource = $GraphEndpointResourceIdAzurePPE
    }

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

    if($EnvironmentName -eq $AzureCloud)
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
    [string] $EnvironmentName
    )

    $portalBaseUrl = Get-PortalDomain -TenantId $TenantId -EnvironmentName $EnvironmentName
    $portalAADAppRelativeUrl = $PortalAADAppPermissionUrl -f $AppId
    return $portalBaseUrl + $portalAADAppRelativeUrl
}

function Get-PortalHCIResourcePageUrl{
param(
    [string] $TenantId,
    [string] $EnvironmentName,
    [string] $SubscriptionId,
    [string] $ResourceGroupName,
    [string] $ResourceName
    )

    $portalBaseUrl = Get-PortalDomain -TenantId $TenantId -EnvironmentName $EnvironmentName
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
    $usagesp = Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"

    $app = Get-AzureADApplication -Filter "AppId eq '$AppId'"
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
        Set-AzureADApplication -ObjectId $app.ObjectId -RequiredResourceAccess $requiredResourcesAccess | Out-Null
    }
}

function Check-UsageAppRoles{
param(
    [string] $AppId
    )

    Write-Verbose "Checking admin consent status for AAD Application $AppId"
    $usagesp = Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"

    $appSP = Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"
    $assignedPerms = Get-AzureADServiceAppRoleAssignedTo -ObjectId $appSP.ObjectId

    $clusterRead = $assignedPerms | where { ($_.Id -eq $ClusterReadPermission) }
    $clusterReadWrite = $assignedPerms | where { ($_.Id -eq $ClusterReadWritePermission) }
    $clusterNodeRead = $assignedPerms | where { ($_.Id -eq $ClusterNodeReadPermission) }
    $clusterNodeReadWrite = $assignedPerms | where { ($_.Id -eq $ClusterNodeReadWritePermission) }

    if($clusterRead -eq $Null -or $clusterReadWrite -eq $Null -or $clusterNodeRead -eq $Null -or $clusterNodeReadWrite -eq $Null)
    {
        # Try Get-AzureADServiceAppRoleAssignment as well to get app role assignments. WAC token falls under this case.
        $assignedPerms = Get-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId
    }

    if($clusterRead -eq $Null)
    {
        $clusterRead = $assignedPerms | where { ($_.Id -eq $ClusterReadPermission) }
    }

    if($clusterReadWrite -eq $Null)
    {
        $clusterReadWrite = $assignedPerms | where { ($_.Id -eq $ClusterReadWritePermission) }
    }

    if($clusterNodeRead -eq $Null)
    {
        $clusterNodeRead = $assignedPerms | where { ($_.Id -eq $ClusterNodeReadPermission) }
    }

    if($clusterNodeReadWrite -eq $Null)
    {
        $clusterNodeReadWrite = $assignedPerms | where { ($_.Id -eq $ClusterNodeReadWritePermission) }
    }

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
    $usagesp = ''
    $Stoploop = $false
    [int]$Retrycount = "0"
 
    do {
        $usagesp = Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"
        if ($usagesp -eq $Null)
        {
            if ($Retrycount -gt 5)
            {
                Write-Error "Could not get service principal of Billing Service."
                $Stoploop = $true
            }
            else
            {
                $Stoploop = $false
                Write-Verbose "Could not get service principal of Billing Service. Retrying in 10 seconds..."
                Start-Sleep -Seconds 10
                $Retrycount = $Retrycount + 1
            }
        }
        else
        {
            $Stoploop = $true
        }
    }
    While ($Stoploop -eq $false)

    $requiredResourcesAccess = Get-RequiredResourceAccess

    # Create application
    $app = New-AzureADApplication -DisplayName $AppName -RequiredResourceAccess $requiredResourcesAccess
    $sp = New-AzureADServicePrincipal -AppId $app.AppId

    Write-Verbose "Created new AAD Application $app.AppId"

    return $app.AppId
}

function Grant-AdminConsent{
param(
    [string] $AppId
    )

    Write-Verbose "Granting admin consent for AAD Application Id $AppId"
    $usagesp = Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"
    $appSP = Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"

    try 
    {
        New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterReadPermission
        New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterReadWritePermission
        New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterNodeReadPermission
        New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $ClusterNodeReadWritePermission
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
    $appSP = Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"

    # Remove AzureStackHCI.Billing.Sync and AzureStackHCI.Census.Sync permissions if present as we dont need them
    $assignedPerms = Get-AzureADServiceAppRoleAssignedTo -ObjectId $appSP.ObjectId

    $billingSync = $assignedPerms | where { ($_.Id -eq $BillingSyncPermission) }
    $censusSync = $assignedPerms | where { ($_.Id -eq $CensusSyncPermission) }

    if($billingSync -eq $Null -or $censusSync -eq $Null)
    {
        # Try Get-AzureADServiceAppRoleAssignment as well to get app role assignments. WAC token falls under this case.
        $assignedPerms = Get-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId
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
        Remove-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -AppRoleAssignmentId $billingSync.ObjectId | Out-Null
    }

    if($censusSync -ne $Null)
    {
        Remove-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -AppRoleAssignmentId $censusSync.ObjectId | Out-Null
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
    [bool]   $UseDeviceAuthentication
    )

    Write-Progress -activity $ProgressActivityName -status $InstallAzResourcesMessage -percentcomplete 10

    try
    {
        Import-Module -Name Az.Resources -ErrorAction Stop
    }
    catch
    {
        Install-PackageProvider NuGet -Force | Out-Null
        Install-Module -Name Az.Resources -Force -AllowClobber
        Import-Module -Name Az.Resources
    }

    Write-Progress -activity $ProgressActivityName -status $InstallAzureADMessage -percentcomplete 20

    try
    {
        Import-Module -Name AzureAD -ErrorAction Stop
    }
    catch
    {
        Install-Module -Name AzureAD -Force -AllowClobber
        Import-Module -Name AzureAD
    }

    Write-Progress -activity $ProgressActivityName -status $LoggingInToAzureMessage -percentcomplete 30

    if($EnvironmentName -eq $AzurePPE)
    {
        Add-AzEnvironment -Name $AzurePPE -PublishSettingsFileUrl "https://windows.azure-test.net/publishsettings/index" -ServiceEndpoint "https://management-preview.core.windows-int.net/" -ManagementPortalUrl "https://windows.azure-test.net/" -ActiveDirectoryEndpoint "https://login.windows-ppe.net/" -ActiveDirectoryServiceEndpointResourceId "https://management.core.windows.net/" -ResourceManagerEndpoint "https://api-dogfood.resources.windows-int.net/" -GalleryEndpoint "https://df.gallery.azure-test.net/" -GraphEndpoint "https://graph.ppe.windows.net/" -GraphAudience "https://graph.ppe.windows.net/" | Out-Null
    }

    Disconnect-AzAccount | Out-Null

    if([string]::IsNullOrEmpty($ArmAccessToken) -or [string]::IsNullOrEmpty($GraphAccessToken) -or [string]::IsNullOrEmpty($AccountId))
    {
        # Interactive login

        $IsIEPresent = Test-Path "$env:SystemRoot\System32\ieframe.dll"

        if([string]::IsNullOrEmpty($TenantId))
        {
            if(($UseDeviceAuthentication -eq $false) -and ($IsIEPresent))
            {
                Connect-AzAccount -Environment $EnvironmentName -SubscriptionId $SubscriptionId -Scope Process | Out-Null
            }
            else # Use -UseDeviceAuthentication as IE Frame is not available to show Azure login popup
            {
                Write-Progress -activity $ProgressActivityName -Completed # Hide progress activity as it blocks the console output
                Connect-AzAccount -Environment $EnvironmentName -SubscriptionId $SubscriptionId -UseDeviceAuthentication -Scope Process | Out-Null
            }
        }
        else
        {
            if(($UseDeviceAuthentication -eq $false) -and ($IsIEPresent))
            {
                Connect-AzAccount -Environment $EnvironmentName -TenantId $TenantId -SubscriptionId $SubscriptionId -Scope Process | Out-Null
            }
            else # Use -UseDeviceAuthentication as IE Frame is not available to show Azure login popup
            {
                Write-Progress -activity $ProgressActivityName -Completed # Hide progress activity as it blocks the console output
                Connect-AzAccount -Environment $EnvironmentName -TenantId $TenantId -SubscriptionId $SubscriptionId -UseDeviceAuthentication -Scope Process | Out-Null
            }
        }

        Write-Progress -activity $ProgressActivityName -status $ConnectingToAzureAD -percentcomplete 35

        $azContext = Get-AzContext
        $TenantId = $azContext.Tenant.Id
        $AccountId = $azContext.Account.Id
        $GraphAccessToken = Get-GraphAccessToken -TenantId $TenantId -EnvironmentName $EnvironmentName

        Connect-AzureAD -AzureEnvironmentName $EnvironmentName -TenantId $TenantId -AadAccessToken $GraphAccessToken -AccountId $AccountId | Out-Null
    }
    else
    {
        # Not an interactive login

        if([string]::IsNullOrEmpty($TenantId))
        {
            Connect-AzAccount -Environment $EnvironmentName -SubscriptionId $SubscriptionId -AccessToken $ArmAccessToken -AccountId $AccountId -Scope Process | Out-Null
        }
        else
        {
            Connect-AzAccount -Environment $EnvironmentName -TenantId $TenantId -SubscriptionId $SubscriptionId -AccessToken $ArmAccessToken -AccountId $AccountId -Scope Process | Out-Null
        }

        Write-Progress -activity $ProgressActivityName -status $ConnectingToAzureAD -percentcomplete 35

        $azContext = Get-AzContext
        $TenantId = $azContext.Tenant.Id
        Connect-AzureAD -AzureEnvironmentName $EnvironmentName -TenantId $TenantId -AadAccessToken $GraphAccessToken -AccountId $AccountId | Out-Null
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
    $resources = Get-AzResourceProvider -ProviderNamespace Microsoft.AzureStackHCI
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

function Check-ConnectionToCloudBillingService{
param(
    $ClusterNodes,
    [System.Management.Automation.PSCredential] $Credential,
    [string] $HealthEndpoint,
    [System.Collections.ArrayList] $HealthEndPointCheckFailedNodes
    )

    Foreach ($clusNode in $ClusterNodes)
    {
        $nodeSession = $null

        try
        {
            if($Credential -eq $Null)
            {
                $nodeSession = New-PSSession -ComputerName $clusNode.Name
            }
            else
            {
                $nodeSession = New-PSSession -ComputerName $clusNode.Name -Credential $Credential
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
    [System.Collections.HashTable] $CertificatesToBeMaintained
    )

    $userProvidedCertAddedToAAD = $false
    Foreach ($clusNode in $ClusterNodes)
    {
        $nodeSession = $null

        try
        {
            if($Credential -eq $Null)
            {
                $nodeSession = New-PSSession -ComputerName $clusNode.Name
            }
            else
            {
                $nodeSession = New-PSSession -ComputerName $clusNode.Name -Credential $Credential
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
        $nodeBuildNumber = Invoke-Command -Session $nodeSession -ScriptBlock { (Get-ItemProperty -path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion").CurrentBuildNumber }

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
                Invoke-Command -Session $nodeSession -ScriptBlock $hciScript
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
            Write-Progress -activity $RegisterProgressActivityName -status $AddAppCredentialMessageProgress -percentcomplete 80
            $now = [System.DateTime]::UtcNow
            $appCredential = New-AzureADApplicationKeyCredential -ObjectId $ObjectId -Type AsymmetricX509Cert -Usage Verify -Value $CertBase64 -StartDate $now -EndDate $Cert.NotAfter
            $CertificatesToBeMaintained.Add($appCredential.KeyId, $true)
            $userProvidedCertAddedToAAD = $true
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

enum OperationStatus
{
    Unused;
    Failed;
    Success;
    PendingForAdminConsent;
    Cancelled
}

enum ConnectionTestResult
{
    Unused;
    Succeeded;
    Failed
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
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzurePPE

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
    [System.Management.Automation.PSCredential] $Credential
    )

    try
    {
        Setup-Logging -LogFilePrefix "RegisterHCI"

        $registrationOutput = New-Object -TypeName PSObject
        $operationStatus = [OperationStatus]::Unused

        Install-PackageProvider NuGet -Force | Out-Null
        $latestModule = Find-Module -Name Az.StackHCI -ErrorAction Ignore
        $installedModule = Get-Module -Name Az.StackHCI | Sort-Object  -Property Version -Descending | Select-Object -First 1

        if($latestModule -eq $Null)
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

        if([string]::IsNullOrEmpty($ComputerName))
        {
            $ComputerName = [Environment]::MachineName
            $IsManagementNode = $False
        }
        else
        {
            $IsManagementNode = $True
        }

        Write-Progress -activity $RegisterProgressActivityName -status $FetchingRegistrationState -percentcomplete 1

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

        Write-Progress -activity $RegisterProgressActivityName -status $InstallRSATHCIMessage -percentcomplete 2;
        Invoke-Command -Session $clusterNodeSession -ScriptBlock $hciScript
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

        Write-Progress -activity $RegisterProgressActivityName -status $ValidatingParametersFetchClusterName -percentcomplete 4

        if([string]::IsNullOrEmpty($ResourceName))
        {
            $clusScript = {
                $clusterPowershell = Get-WindowsFeature -Name RSAT-Clustering-PowerShell;
                if ( $clusterPowershell.Installed -eq $false)
                {
                    Install-WindowsFeature RSAT-Clustering-PowerShell | Out-Null;
                }
            }

            Write-Progress -activity $RegisterProgressActivityName -status $InstallRSATClusteringMessage -percentcomplete 8;
            Invoke-Command -Session $clusterNodeSession -ScriptBlock $clusScript
            $getCluster = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-Cluster }

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

        $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $RegisterProgressActivityName -UseDeviceAuthentication $UseDeviceAuthentication

        Write-Verbose "Register-AzStackHCI triggered - Region: $Region ResourceName: $ResourceName `
            SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName AccountId: $AccountId EnvironmentName: $EnvironmentName CertificateThumbprint: $CertificateThumbprint RepairRegistration: $RepairRegistration"

        $resourceId = Get-ResourceId -ResourceName $ResourceName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName
        Write-Verbose "ResourceId : $resourceId"
        $portalResourceUrl = Get-PortalHCIResourcePageUrl -TenantId $TenantId -EnvironmentName $EnvironmentName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName
        $resource = Get-AzResource -ResourceId $resourceId -ErrorAction Ignore

        if(($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered) -and ($RepairRegistration -eq $false))
        {
            if(($RegContext.AzureResourceUri -eq $resourceId))
            {
                if($resource -ne $Null)
                {
                    # Already registered with same resource Id and resource exists
                    $appId = $resource.Properties.aadClientId
                    $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName
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
            Write-Progress -activity $RegisterProgressActivityName -status $RegisterAzureStackRPMessage -percentcomplete 40

            $regRP = Register-AzResourceProvider -ProviderNamespace Microsoft.AzureStackHCI

            $resGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction Ignore

            if($resource -ne $null)
            {
                if([string]::IsNullOrEmpty($Region))
                {
                    $Region = $resource.Location
                }
                elseif($Region -ne $resource.Location)
                {
                    $ResourceExistsInDifferentRegionErrorMessage = $ResourceExistsInDifferentRegionError -f $resource.Location, $Region
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
                        $Region = "EastUS"
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

            $regionName = Normalize-RegionName -Region $Region

            # Validate that the input region is supported by the Stack HCI RP

            $supportedRegions = [string]::Empty
            $regionSupported = Validate-RegionName -Region $regionName -SupportedRegions ([ref]$supportedRegions)

            if ($regionSupported -eq $False)
            {
                $RegionNotSupportedMessage = $RegionNotSupported -f $regionName, $supportedRegions
                Write-Error -Message $RegionNotSupportedMessage
                $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value [OperationStatus]::Failed
                Write-Output $registrationOutput
                return
            }

            # Lookup cloud endpoint URL from region name

            if($regionName -eq $Region_EASTUSEUAP)
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointsAzureCloud[$regionName]
            }
            else
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointAzureCloudFrontDoor
            }

            if($resource -eq $Null)
            {
                # Create new application

                $CreatingAADAppMessageProgress = $CreatingAADAppMessage -f $ResourceName, $TenantId
                Write-Progress -activity $RegisterProgressActivityName -status $CreatingAADAppMessageProgress -percentcomplete 50

                $appId = Create-Application -AppName $ResourceName

                $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName

                Write-Verbose "Created AAD Application with Id $appId"

                # Create new resource by calling RP

                if($resGroup -eq $Null)
                {
                     $CreatingResourceGroupMessageProgress = $CreatingResourceGroupMessage -f $ResourceGroupName
                     Write-Progress -activity $RegisterProgressActivityName -status $CreatingResourceGroupMessageProgress -percentcomplete 55
                     $resGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Region -Tag @{$ResourceGroupCreatedByName = $ResourceGroupCreatedByValue}
                }


                $CreatingCloudResourceMessageProgress = $CreatingCloudResourceMessage -f $ResourceName
                Write-Progress -activity $RegisterProgressActivityName -status $CreatingCloudResourceMessageProgress -percentcomplete 60
                $properties = @{"aadClientId"="$appId";"aadTenantId"="$TenantId"}
                $resource = New-AzResource -ResourceId $resourceId -Location $Region -ApiVersion $RPAPIVersion -PropertyObject $properties -Force

                # Try Granting admin consent for requested permissions

                $GrantingAdminConsentMessageProgress = $GrantingAdminConsentMessage -f $ResourceName
                Write-Progress -activity $RegisterProgressActivityName -status $GrantingAdminConsentMessageProgress -percentcomplete 65
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

                $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName

                # Existing AAD app might not have the newly added scopes, if so add them.
                AddRequiredPermissionsIfNotPresent -AppId $appId
                $rolesPresent = Check-UsageAppRoles -AppId $appId

                $GrantingAdminConsentMessageProgress = $GrantingAdminConsentMessage -f $ResourceName
                Write-Progress -activity $RegisterProgressActivityName -status $GrantingAdminConsentMessageProgress -percentcomplete 65

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
                $app = Get-AzureADApplication -Filter "AppId eq '$appId'"
                $objectId = $app.ObjectId
                $appSP = Get-AzureADServicePrincipal -Filter "AppId eq '$appId'"
                $spObjectId = $appSP.ObjectId

                # Add certificate

                Write-Progress -activity $RegisterProgressActivityName -status $GettingCertificateMessage -percentcomplete 70

                $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }

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
                                    -SetCertificateFailedNodes $SetCertificateFailedNodes -OSNotLatestOnNodes $OSNotLatestOnNodes -CertificatesToBeMaintained $CertificatesToBeMaintained

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

                Write-Progress -activity $RegisterProgressActivityName -status $RegisterAndSyncMetadataMessage -percentcomplete 90

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
                    Foreach ($keyCred in (Get-AzureADApplicationKeyCredential -ObjectId $objectId))
                    {
                        if($CertificatesToBeMaintained[$keyCred.KeyId] -eq $true)
                        {
                            Write-Verbose ($SkippingDeleteCertificateFromAADApp -f $keyCred.KeyId)
                            continue
                        }
                        else
                        {
                            Write-Verbose ($DeletingCertificateFromAADApp -f $keyCred.KeyId)
                            Remove-AzureADApplicationKeyCredential -ObjectId $objectId -KeyId $keyCred.KeyId
                        }
                    }
                }

                # Delete old unused scopes if present
                Remove-OldScopes -AppId $appId

                $operationStatus = [OperationStatus]::Success
            }
        }

        Write-Progress -activity $RegisterProgressActivityName -Completed

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
        Write-Error -Exception $_.Exception -Category OperationStopped
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
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzurePPE

    .PARAMETER ComputerName
    Specifies one of the cluster node in on-premise cluster that is being registered to Azure.

    .PARAMETER UseDeviceAuthentication
    Use device code authentication instead of an interactive browser prompt.

    .PARAMETER Credential
    Specifies the credential for the ComputerName. Default is the current user executing the Cmdlet.

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
    [string] $ComputerName,

    [Parameter(Mandatory = $false)]
    [Switch]$UseDeviceAuthentication,

    [Parameter(Mandatory = $false)]
    [System.Management.Automation.PSCredential] $Credential
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

        Write-Progress -activity $UnregisterProgressActivityName -status $FetchingRegistrationState -percentcomplete 1

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

            Write-Progress -activity $UnregisterProgressActivityName -status $InstallRSATHCIMessage -percentcomplete 3;
            Invoke-Command -Session $clusterNodeSession -ScriptBlock $hciScript
            $RegContext = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-AzureStackHCI }
        }
        else
        {
            Write-Progress -activity $UnregisterProgressActivityName -status $InstallRSATHCIMessage -percentcomplete 3;
            Invoke-Command -ScriptBlock $hciScript
            $RegContext = Get-AzureStackHCI
        }

        Write-Progress -activity $UnregisterProgressActivityName -status $ValidatingParametersRegisteredInfo -percentcomplete 5

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
            $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $UnregisterProgressActivityName -UseDeviceAuthentication $UseDeviceAuthentication

            Write-Verbose "Unregister-AzStackHCI triggered - ResourceName: $ResourceName `
                   SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName `
                   AccountId: $AccountId EnvironmentName: $EnvironmentName"

            Write-Progress -activity $UnregisterProgressActivityName -status $UnregisterHCIUsageMessage -percentcomplete 45
        
            if($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered)
            {
                if($IsManagementNode)
                {
                    Invoke-Command -Session $clusterNodeSession -ScriptBlock { Remove-AzureStackHCIRegistration }
                }
                else
                {
                    Remove-AzureStackHCIRegistration
                }

                if($IsManagementNode)
                {
                    $clusterNodes = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-ClusterNode }
                }
                else
                {
                    $clusterNodes = Get-ClusterNode
                }

                Foreach ($clusNode in $clusterNodes)
                {
                    $nodeSession = $null

                    try
                    {
                        if($Credential -eq $Null)
                        {
                            $nodeSession = New-PSSession -ComputerName $clusNode.Name
                        }
                        else
                        {
                            $nodeSession = New-PSSession -ComputerName $clusNode.Name -Credential $Credential
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
                $app = Get-AzureADApplication -Filter "AppId eq '$appId'"
                
                if($app -ne $Null)
                {
                    $DeletingAADApplicationMessageProgress = $DeletingAADApplicationMessage -f $ResourceName
                    Write-Progress -activity $UnregisterProgressActivityName -status $DeletingAADApplicationMessageProgress -percentcomplete 60
                    Remove-AzureADApplication -ObjectId $app.ObjectId
                }

                $DeletingCloudResourceMessageProgress = $DeletingCloudResourceMessage -f $ResourceName
                Write-Progress -activity $UnregisterProgressActivityName -status $DeletingCloudResourceMessageProgress -percentcomplete 80

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

        Write-Progress -activity $UnregisterProgressActivityName -Completed

        $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $operationStatus

        if ($operationStatus -eq [OperationStatus]::Success)
        {
            $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyDetails -Value $UnregistrationSuccessDetailsMessage
        }

        Write-Output $unregistrationOutput
    }
    catch
    {
        Write-Error -Exception $_.Exception -Category OperationStopped
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
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzurePPE

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
            $regionName = Normalize-RegionName -Region $Region

            if($regionName -eq $Region_EASTUSEUAP)
            {
                $ServiceEndpointAzureCloud = $ServiceEndpointsAzureCloud[$regionName]
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

            Check-ConnectionToCloudBillingService -ClusterNodes $clusterNodes -Credential $Credential -HealthEndpoint $EndPointToInvoke -HealthEndPointCheckFailedNodes $HealthEndPointCheckFailedNodes

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
        Write-Error -Exception $_.Exception -Category OperationStopped
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
