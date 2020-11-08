#
#  AzureStack HCI Registration and Unregistration Powershell Cmdlets.
#

$ErrorActionPreference = 'Stop'

#region User visible strings

$AdminConsentWarning = "You need additional Azure Active Directory permissions to register in this Azure subscription. Contact your Azure AD administrator to grant consent to AAD application identity {0} at {1}. Then, run Register-AzStackHCI again with same parameters to complete registration."
$NoClusterError = "Computer {0} is not part of an Azure Stack HCI cluster. Use the -ComputerName parameter to specify an Azure Stack HCI cluster node and try again."
$CloudResourceDoesNotExist = "The Azure resource with ID {0} doesn't exist. Unregister the cluster using Unregister-AzStackHCI and then try again."
$RegisteredWithDifferentResourceId = "Azure Stack HCI is already registered with Azure resource ID {0}. To register or change registration, first unregister the cluster using Unregister-AzStackHCI, then try again."
$RegistrationInfoNotFound = "Additional parameters are required to unregister. Run 'Get-Help Unregister-AzStackHCI -Full' for more information."
$RegionNotSupported = "Azure Stack HCI is not yet available in region {0}. Please choose one of these regions: {1}."

$FetchingRegistrationState = "Checking whether the cluster is already registered"
$ValidatingParametersFetchClusterName = "Validating cmdlet parameters"
$ValidatingParametersRegisteredInfo = "Validating the parameters and checking registration information"
$RegisterProgressActivityName = "Registering Azure Stack HCI with Azure..."
$UnregisterProgressActivityName = "Unregistering Azure Stack HCI from Azure..."
$InstallAzResourcesMessage = "Installing required PowerShell module: Az.Resources"
$InstallAzureADMessage = "Installing required PowerShell module: AzureAD"
$InstallRSATHCIMessage = "Installing required Windows feature: RSAT-Azure-Stack-HCI"
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

$ClusterMetadataPermission = "AzureStackHCI.Census.Sync"
$ClusterUsagePermission = "AzureStackHCI.Billing.Sync"

$ServiceEndpointAzureCloud = [string]::Empty

[hashtable] $ServiceEndpointsAzureCloud = @{
        'eastus' = 'https://eus-azurestackhci-usage.azurewebsites.net';
        'westeurope' = 'https://weu-azurestackhci-usage.azurewebsites.net';
        'eastus2euap' = 'https://eus2euap-azurestackhci-usage.azurewebsites.net';
        }

$AuthorityAzureCloud = "https://login.microsoftonline.com"
$BillingServiceApiScopeAzureCloud = "https://azurestackhci-usage.trafficmanager.net/.default"
$GraphServiceApiScopeAzureCloud = "https://graph.microsoft.com/.default"
$GraphEndpointResourceIdAzureCloud = "https://graph.windows.net/"

$ServiceEndpointAzurePPE = "https://wus-azurestackhci-usage-df.azurewebsites.net"
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

$RPAPIVersion = "2020-03-01-preview"

$OutputPropertyResult = "Result"
$OutputPropertyResourceId = "ResourceId"
$OutputPropertyPortalResourceURL = "PortalResourceURL"
$OutputPropertyPortalAADAppPermissionsURL = "PortalAADAppPermissionsURL"

enum RegistrationStatus
{
    Registered;
    NotYet;
    OutOfPolicy;
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

function Check-UsageAppRoles{
param(
    [string] $AppId
    )

    Write-Verbose "Checking admin consent status for AAD Application $AppId"
    $usagesp = Get-AzureADServicePrincipal -Filter "AppId eq '$UsageServiceFirstPartyAppId'"
    $usageWritePermission = $usagesp.AppRoles| Where-Object {$_.Value -contains $ClusterUsagePermission}
    $metadataWritePermission = $usagesp.AppRoles| Where-Object {$_.Value -contains $ClusterMetadataPermission}
    $appSP = Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"
    $assignedPerms = Get-AzureADServiceAppRoleAssignedTo -ObjectId $appSP.ObjectId
    $usageWrite = $assignedPerms | where { ($_.Id -eq $usageWritePermission.Id) }
    $metadataWrite = $assignedPerms | where { ($_.Id -eq $metadataWritePermission.Id) }

    if($usageWrite -eq $Null -or $metadataWrite -eq $Null)
    {
        # Try Get-AzureADServiceAppRoleAssignment as well to get app role assignments. WAC token falls under this case.
        $assignedPerms = Get-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId
    }

    if($usageWrite -eq $Null)
    {
        $usageWrite = $assignedPerms | where { ($_.Id -eq $usageWritePermission.Id) }
    }

    if($metadataWrite -eq $Null)
    {
        $metadataWrite = $assignedPerms | where { ($_.Id -eq $metadataWritePermission.Id) }
    }

    if($usageWrite -ne $Null -and $metadataWrite -ne $Null) # Check both Usage.Write and Metadata.Write are in consented state.
    {
        if($usageWrite.DeletionTimestamp -eq $Null -or ($usageWrite.DeletionTimestamp -lt $usageWrite.CreationTimestamp))
        {
            if($metadataWrite.DeletionTimestamp -eq $Null -or ($metadataWrite.DeletionTimestamp -lt $metadataWrite.CreationTimestamp))
            {
                return $True
            }
        }
    }

    return $false
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

    $usageWritePermission = $usagesp.AppRoles| Where-Object {$_.Value -contains $ClusterUsagePermission}
    $metadataWritePermission = $usagesp.AppRoles| Where-Object {$_.Value -contains $ClusterMetadataPermission}

    $requiredResourcesAccess = New-Object System.Collections.Generic.List[Microsoft.Open.AzureAD.Model.RequiredResourceAccess] 

    $requiredAccess = New-Object Microsoft.Open.AzureAD.Model.RequiredResourceAccess
    $requiredAccess.ResourceAppId = $usagesp.AppId
    $requiredAccess.ResourceAccess = New-Object System.Collections.Generic.List[Microsoft.Open.AzureAD.Model.ResourceAccess]  

    $usageWriteAccess = New-Object Microsoft.Open.AzureAD.Model.ResourceAccess
    $usageWriteAccess.Type = "Role"
    $usageWriteAccess.Id = $usageWritePermission.Id 
    $requiredAccess.ResourceAccess.Add($usageWriteAccess)

    $metadataWriteAccess = New-Object Microsoft.Open.AzureAD.Model.ResourceAccess
    $metadataWriteAccess.Type = "Role"
    $metadataWriteAccess.Id = $metadataWritePermission.Id 
    $requiredAccess.ResourceAccess.Add($metadataWriteAccess)

    $requiredResourcesAccess.Add($requiredAccess)

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
    $usageWritePermission = $usagesp.AppRoles| Where-Object {$_.Value -contains $ClusterUsagePermission}
    $metadataWritePermission = $usagesp.AppRoles| Where-Object {$_.Value -contains $ClusterMetadataPermission}
    $appSP = Get-AzureADServicePrincipal -Filter "AppId eq '$AppId'"

    try 
    {
        New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $metadataWritePermission.Id 
        New-AzureADServiceAppRoleAssignment -ObjectId $appSP.ObjectId -PrincipalId $appSP.ObjectId -ResourceId $usagesp.ObjectId -Id $usageWritePermission.Id 
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

function Azure-Login{
param(
    [string] $SubscriptionId,
    [string] $TenantId,
    [string] $ArmAccessToken,
    [string] $GraphAccessToken,
    [string] $AccountId,
    [string] $EnvironmentName,
    [string] $ProgressActivityName
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
            if($IsIEPresent)
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
            if($IsIEPresent)
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

enum OperationStatus
{
    Unused;
    Failed;
    Success;
    PendingForAdminConsent;
    Cancelled
}

<#
    .Description
    Register-AzStackHCI creates a Microsoft.AzureStackHCI cloud resource representing the on-premise cluster and registers the on-premise cluster with Azure.

    .PARAMETER SubscriptionId
    Specifies the Azure Subscription to create the resource. This is the only Mandatory parameter.

    .PARAMETER Region
    Specifies the Region to create the resource. Default is EastUS.

    .PARAMETER ResourceName
    Specifies the resource name of the resource created in Azure. If not specified, on-premise cluster name is used.

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
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzureChinaCloud, AzureUSGovernment, AzureGermanCloud, AzurePPE

    .PARAMETER ComputerName
    Specifies the cluster name or one of the cluster node in on-premise cluster that is being registered to Azure.

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
    [System.Management.Automation.PSCredential] $Credential
    )

    try
    {
        Setup-Logging -LogFilePrefix "RegisterHCI"

        $registrationOutput = New-Object -TypeName PSObject
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

            Write-Progress -activity $RegisterProgressActivityName -status $InstallRSATHCIMessage -percentcomplete 2;
            Invoke-Command -Session $clusterNodeSession -ScriptBlock $hciScript
            $RegContext = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-AzureStackHCI }
        }
        else
        {
            Write-Progress -activity $RegisterProgressActivityName -status $InstallRSATHCIMessage -percentcomplete 2;
            Invoke-Command -ScriptBlock $hciScript
            $RegContext = Get-AzureStackHCI
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

            if($IsManagementNode)
            {
                Write-Progress -activity $RegisterProgressActivityName -status $InstallRSATClusteringMessage -percentcomplete 8;
                Invoke-Command -Session $clusterNodeSession -ScriptBlock $clusScript
                $getCluster = Invoke-Command -Session $clusterNodeSession -ScriptBlock { Get-Cluster }
            }
            else
            {
                Write-Progress -activity $RegisterProgressActivityName -status $InstallRSATClusteringMessage -percentcomplete 8;
                Invoke-Command -ScriptBlock $clusScript
                $getCluster = Get-Cluster
            }

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

        $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $RegisterProgressActivityName

        Write-Verbose "Register-AzStackHCI triggered - Region: $Region ResourceName: $ResourceName `
            SubscriptionId: $SubscriptionId Tenant: $TenantId ResourceGroupName: $ResourceGroupName AccountId: $AccountId EnvironmentName: $EnvironmentName"

        $resourceId = Get-ResourceId -ResourceName $ResourceName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName
        Write-Verbose "ResourceId : $resourceId"
        $portalResourceUrl = Get-PortalHCIResourcePageUrl -TenantId $TenantId -EnvironmentName $EnvironmentName -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName
        $resource = Get-AzResource -ResourceId $resourceId -ErrorAction Ignore

        if($RegContext.RegistrationStatus -eq [RegistrationStatus]::Registered)
        {
            if(($RegContext.AzureResourceUri -eq $resourceId) -and ($resource -ne $Null)) # Already registered with same resource Id
            {
                $appId = $resource.Properties.aadClientId
                $appPermissionsPageUrl = Get-PortalAppPermissionsPageUrl -AppId $appId -TenantId $TenantId -EnvironmentName $EnvironmentName
                $operationStatus = [OperationStatus]::Success
            }
            else # Already registered with different resource Id or cloud resource does not exist.
            {
                $AlreadyRegisteredErrorMessage = If ($resource -eq $Null) { $CloudResourceDoesNotExist -f $resourceId } Else { $RegisteredWithDifferentResourceId -f $RegContext.AzureResourceUri }
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

            $ServiceEndpointAzureCloud = $ServiceEndpointsAzureCloud[$regionName]

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
                     $resGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Region
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

                if($IsManagementNode)
                {
                    $certBase64 = Invoke-Command -Session $clusterNodeSession -ScriptBlock { New-AzureStackHCIRegistrationCertificate }
                }
                else
                {
                    $certBase64 = New-AzureStackHCIRegistrationCertificate
                }

                $Cert = [System.Security.Cryptography.X509Certificates.X509Certificate2]([System.Convert]::FromBase64String($CertBase64))

                $AddAppCredentialMessageProgress = $AddAppCredentialMessage -f $ResourceName
                Write-Progress -activity $RegisterProgressActivityName -status $AddAppCredentialMessageProgress -percentcomplete 80
                $now = [System.DateTime]::UtcNow
                $appCredential = New-AzureADApplicationKeyCredential -ObjectId $objectId -Type AsymmetricX509Cert -Usage Verify -Value $CertBase64 -StartDate $now -EndDate $Cert.NotAfter

                Write-Progress -activity $RegisterProgressActivityName -status $RegisterAndSyncMetadataMessage -percentcomplete 90

                # Register by calling on-prem usage service Cmdlet

                $ServiceEndpoint = ""
                $Authority = ""
                $BillingServiceApiScope = ""
                $GraphServiceApiScope = ""

                Get-EnvironmentEndpoints -EnvironmentName $EnvironmentName -ServiceEndpoint ([ref]$ServiceEndpoint) -Authority ([ref]$Authority) -BillingServiceApiScope ([ref]$BillingServiceApiScope) -GraphServiceApiScope ([ref]$GraphServiceApiScope)

                $RegistrationParams = @{
                                            ServiceEndpoint = $ServiceEndpoint
                                            BillingServiceApiScope = $BillingServiceApiScope
                                            GraphServiceApiScope = $GraphServiceApiScope
                                            AADAuthority = $Authority
                                            AppId = $appId
                                            TenantId = $TenantId
                                            CloudId = $cloudId
                                            SubscriptionId = $SubscriptionId
                                            Certificate = $certBase64
                                            ObjectId = $objectId
                                            ResourceName = $ResourceName
                                            ProviderNamespace = "Microsoft.AzureStackHCI"
                                            ResourceArmId = $resourceId
                                            ServicePrincipalClientId = $spObjectId
                                        }

                if($IsManagementNode)
                {
                    Invoke-Command -Session $clusterNodeSession -ScriptBlock { Set-AzureStackHCIRegistration @Using:RegistrationParams }
                }
                else
                {
                    Set-AzureStackHCIRegistration @RegistrationParams
                }

                $operationStatus = [OperationStatus]::Success
            }
        }

        Write-Progress -activity $RegisterProgressActivityName -Completed

        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $operationStatus
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResourceId -Value $resourceId
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyPortalResourceURL -Value $portalResourceUrl
        $registrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyPortalAADAppPermissionsURL -Value $appPermissionsPageUrl

        Write-Output $registrationOutput
    }
    catch
    {
        Write-Debug ("Exception occured in Register-AzStackHCI. ErrorMessage : " + $_.Exception.Message)
        Write-Debug $_
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
    Unregister-AzStackHCI deletes the Microsoft.AzureStackHCI cloud resource representing the on-premise cluster and unregisters the on-premise cluster with Azure.
    The registered information available on the cluster is used to unregister the cluster if no parameters are passed.

    .PARAMETER SubscriptionId
    Specifies the Azure Subscription to create the resource

    .PARAMETER ResourceName
    Specifies the resource name of the resource created in Azure. If not specified, on-premise cluster name is used.

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
    Specifies the Azure Environment. Default is AzureCloud. Valid values are AzureCloud, AzureChinaCloud, AzureUSGovernment, AzureGermanCloud, AzurePPE

    .PARAMETER ComputerName
    Specifies one of the cluster node in on-premise cluster that is being registered to Azure.

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
            $TenantId = Azure-Login -SubscriptionId $SubscriptionId -TenantId $TenantId -ArmAccessToken $ArmAccessToken -GraphAccessToken $GraphAccessToken -AccountId $AccountId -EnvironmentName $EnvironmentName -ProgressActivityName $UnregisterProgressActivityName

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

            $operationStatus = [OperationStatus]::Success
        }
        else
        {
            $operationStatus = [OperationStatus]::Cancelled
        }

        Write-Progress -activity $UnregisterProgressActivityName -Completed

        $unregistrationOutput | Add-Member -MemberType NoteProperty -Name $OutputPropertyResult -Value $operationStatus
        Write-Output $unregistrationOutput
    }
    catch
    {
        Write-Debug ("Exception occured in Unregister-AzStackHCI. ErrorMessage : " + $_.Exception.Message)
        Write-Debug $_
        throw
    }
    finally
    {
        try{ Disconnect-AzAccount | Out-Null } catch{}
        try{ Disconnect-AzureAD | Out-Null } catch{}
        Stop-Transcript | out-null
    }
}

Export-ModuleMember -Function Register-AzStackHCI
Export-ModuleMember -Function Unregister-AzStackHCI
