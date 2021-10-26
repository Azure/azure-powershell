Function New-TestCredential
{
    [CmdletBinding(
        SupportsShouldProcess=$true
        )]
    param(
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalDisplayName,

        [Parameter(Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [Parameter(Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

        [Parameter(Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateSet("Playback", "Record", "None")]
        [string]$RecordMode,

        [Parameter(Mandatory=$false, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use (required for existing Service Principal)')]
        [ValidateNotNullOrEmpty()]
        [securestring]$ServicePrincipalSecret,

        [Parameter(Mandatory=$false, HelpMessage="Environment you would like to run in")]
        [ValidateSet("Prod", "Dogfood", "Current", "Next", "Custom")]
        [string]$TargetEnvironment='Prod',
        
        [Parameter(Mandatory=$false)]
        [string]$ResourceManagementUri,
        
        [Parameter(Mandatory=$false)]
        [string]$GraphUri,
        
        [Parameter(Mandatory=$false)]
        [string]$AADAuthUri,
        
        [Parameter(Mandatory=$false)]
        [string]$AADTokenAudienceUri,
        
        [Parameter(Mandatory=$false)]
        [string]$GraphTokenAudienceUri,

        [Parameter(Mandatory=$false)]		
        [string]$IbizaPortalUri,
        
        [Parameter(Mandatory=$false)]
        [string]$ServiceManagementUri,
        
        [Parameter(Mandatory=$false)]
        [string]$RdfePortalUri,
        
        [Parameter(Mandatory=$false)]
        [string]$GalleryUri,
        
        [Parameter(Mandatory=$false)]
        [string]$DataLakeStoreServiceUri,
        
        [Parameter(Mandatory=$false)]
        [string]$DataLakeAnalyticsJobAndCatalogServiceUri,
        
        [Parameter(Mandatory=$false)]
        [switch]$Force
    )

    [hashtable]$credentials = @{}
    $credentials.SubscriptionId = $SubscriptionId
    $credentials.HttpRecorderMode = $RecordMode
    $credentials.Environment = $TargetEnvironment

    if ([string]::IsNullOrEmpty($ServicePrincipalDisplayName) -eq $false) {
        $existingServicePrincipal = Get-AzADServicePrincipal -SearchString $ServicePrincipalDisplayName | Where-Object {$_.DisplayName -eq $ServicePrincipalDisplayName}
        if ($existingServicePrincipal -eq $null -and ($Force -or $PSCmdlet.ShouldContinue("ServicePrincipal `"" + $ServicePrincipalDisplayName + "`" does not exist, would you like to create a new ServicePrincipal with this name?", "Create ServicePrincipal?")))
        {
            if (![string]::IsNullOrEmpty($ServicePrincipalSecret))
            {
                Write-Warning "Service Principal secrets are randomly generated, so provided secret value will not be used during creation."
            }

            if ($TargetEnvironment -ne 'Prod')
            {
                throw "To create a new Service Principal you must be in Prod. Please run again with `$TargetEnvironment set to 'Prod'"
            }
            $Scope = "/subscriptions/" + $SubscriptionId
            $NewServicePrincipal = New-AzADServicePrincipal -DisplayName $ServicePrincipalDisplayName
            Write-Host "New ServicePrincipal created: " $NewServicePrincipal.ApplicationId
    
            $NewRole = Get-AzRoleAssignment -ObjectId $NewServicePrincipal.Id -RoleDefinitionName Contributor -ErrorAction SilentlyContinue
            $Retries = 0;
            While (($NewRole.RoleDefinitionName -ne 'Contributor') -and ($Retries -le 6))
            {
                # Sleep here for a few seconds to allow the service principal application to become active (should only take a couple of seconds normally)
                Start-Sleep 5
                New-AzRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName $NewServicePrincipal.ApplicationId -Scope $Scope | Write-Verbose -ErrorAction SilentlyContinue
                $NewRole = Get-AzRoleAssignment -ObjectId $NewServicePrincipal.Id -ErrorAction SilentlyContinue
                $Retries++;
            }
            
            $credentials.ServicePrincipal = $NewServicePrincipal.ApplicationId
            $ServicePrincipalSecret = $NewServicePrincipal.Secret
            $BSTR = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($ServicePrincipalSecret)
            $UnsecurePassword = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)
            $credentials.ServicePrincipalSecret = $UnsecurePassword
        }
        
        else
        {
            if ([string]::IsNullOrEmpty($ServicePrincipalSecret))
            {
                throw "Service Principal secret required for existing Service Principal."
            }
            $credentials.ServicePrincipal = $existingServicePrincipal.ApplicationId
            $BSTR = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($ServicePrincipalSecret)
            $UnsecurePassword = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)
            $credentials.ServicePrincipalSecret = $UnsecurePassword
        }
    }

    if ([string]::IsNullOrEmpty($TenantId) -eq $false) {
        $credentials.TenantId = $TenantId
    }

    if ([string]::IsNullOrEmpty($ResourceManagementUri) -eq $false) {
        $credentials.ResourceManagementUri = $ResourceManagementUri
    }

    if ([string]::IsNullOrEmpty($GraphUri) -eq $false) {
        $credentials.GraphUri = $GraphUri
    }

    if ([string]::IsNullOrEmpty($AADAuthUri) -eq $false) {
        $credentials.AADAuthUri = $AADAuthUri
    }

    if ([string]::IsNullOrEmpty($AADTokenAudienceUri) -eq $false) {
        $credentials.AADTokenAudienceUri = $AADTokenAudienceUri
    }

    if ([string]::IsNullOrEmpty($GraphTokenAudienceUri) -eq $false) {
        $credentials.GraphTokenAudienceUri = $GraphTokenAudienceUri
    }

    if ([string]::IsNullOrEmpty($IbizaPortalUri) -eq $false) {
        $credentials.IbizaPortalUri = $IbizaPortalUri
    }

    if ([string]::IsNullOrEmpty($ServiceManagementUri) -eq $false) {
        $credentials.ServiceManagementUri = $ServiceManagementUri
    }

    if ([string]::IsNullOrEmpty($RdfePortalUri) -eq $false) {
        $credentials.RdfePortalUri = $RdfePortalUri
    }

    if ([string]::IsNullOrEmpty($GalleryUri) -eq $false) {
        $credentials.GalleryUri = $GalleryUri
    }

    if ([string]::IsNullOrEmpty($DataLakeStoreServiceUri) -eq $false) {
        $credentials.DataLakeStoreServiceUri = $DataLakeStoreServiceUri
    }

    if ([string]::IsNullOrEmpty($DataLakeAnalyticsJobAndCatalogServiceUri) -eq $false) {
        $credentials.DataLakeAnalyticsJobAndCatalogServiceUri = $DataLakeAnalyticsJobAndCatalogServiceUri
    }

    $credentialsJson = $credentials | ConvertTo-Json
    $directoryPath = $Env:USERPROFILE + "\.azure"
    if (!(Test-Path $directoryPath) -and ($Force -or $PSCmdlet.ShouldContinue("Do you want to create directory: " + $directoryPath + " which will contain your credentials file?", "Create directory?"))) {
        New-Item -ItemType Directory -Path $directoryPath
    }
    $filePath = $Env:USERPROFILE + "\.azure\testcredentials.json"
    $credentialsJson | Out-File $filePath

    Write-Host ""
    Write-Host "Created credential file:" $filePath
    
}
Function Set-TestEnvironment
{
<#
.SYNOPSIS
This cmdlet helps you to setup Test Environment for running tests
In order to successfully run a test, you will need SubscriptionId, TenantId
This cmdlet will only prompt you for Subscription and Tenant information, rest all other parameters are optional

#>
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true, HelpMessage='ServicePrincipal/ClientId you would like to use')]   
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalId,

        [Parameter(Mandatory=$true, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [Parameter(Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [Parameter(Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

	    [Parameter(Mandatory=$true, HelpMessage = "Would you like to record or playback your tests?")]
        [ValidateSet("Playback", "Record", "None")]
        [string]$RecordMode='Playback',

        [ValidateSet("Prod", "Dogfood", "Current", "Next")]
        [string]$TargetEnvironment='Prod',

		[string]$ResourceManagementUri,
		[string]$GraphUri,
		[string]$AADAuthUri,
		[string]$AADTokenAudienceUri,
		[string]$GraphTokenAudienceUri,		
		[string]$IbizaPortalUri,
		[string]$ServiceManagementUri,
		[string]$RdfePortalUri,
		[string]$GalleryUri,
		[string]$DataLakeStoreServiceUri,
		[string]$DataLakeAnalyticsJobAndCatalogServiceUri
    )

    $formattedConnStr = [string]::Format("SubscriptionId={0};HttpRecorderMode={1};Environment={2}", $SubscriptionId, $RecordMode, $TargetEnvironment)

    if([string]::IsNullOrEmpty($TenantId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";AADTenant={0}"), $TenantId)
    }

    if([string]::IsNullOrEmpty($ServicePrincipalId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipal={0}"), $ServicePrincipalId)
    }

    if([string]::IsNullOrEmpty($ServicePrincipalSecret) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipalSecret={0}"), $ServicePrincipalSecret)
    }

	#Uris
	if([string]::IsNullOrEmpty($ResourceManagementUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ResourceManagementUri={0}"), $ResourceManagementUri)
    }
	
	if([string]::IsNullOrEmpty($GraphUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";GraphUri={0}"), $GraphUri)
    }
	
	if([string]::IsNullOrEmpty($AADAuthUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";AADAuthUri={0}"), $AADAuthUri)
    }
	
	if([string]::IsNullOrEmpty($AADTokenAudienceUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";AADTokenAudienceUri={0}"), $AADTokenAudienceUri)
    }
	
	if([string]::IsNullOrEmpty($GraphTokenAudienceUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";GraphTokenAudienceUri={0}"), $GraphTokenAudienceUri)
    }
	
	if([string]::IsNullOrEmpty($IbizaPortalUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";IbizaPortalUri={0}"), $IbizaPortalUri)
    }
	
	if([string]::IsNullOrEmpty($ServiceManagementUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServiceManagementUri={0}"), $ServiceManagementUri)
    }
	
	if([string]::IsNullOrEmpty($RdfePortalUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";RdfePortalUri={0}"), $RdfePortalUri)
    }
	
	if([string]::IsNullOrEmpty($GalleryUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";GalleryUri={0}"), $GalleryUri)
    }
	
	if([string]::IsNullOrEmpty($DataLakeStoreServiceUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";DataLakeStoreServiceUri={0}"), $DataLakeStoreServiceUri)
    }
	
	if([string]::IsNullOrEmpty($DataLakeAnalyticsJobAndCatalogServiceUri) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";DataLakeAnalyticsJobAndCatalogServiceUri={0}"), $DataLakeAnalyticsJobAndCatalogServiceUri)
    }

    Write-Host "Below connection string is ready to be set"
    Print-ConnectionString $SubscriptionId $TenantId $ServicePrincipal $ServicePrincipalSecret $RecordMode $TargetEnvironment

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    $env:AZURE_TEST_MODE=$RecordMode
    Write-Host ""

    # Retrieve the environment variable
    Write-Host ""
    Write-Host "Below connection string was set. Please open your service's solution in Visual Studio and run your tests from the Test Explorer." -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/master/documentation/testing-docs/using-azure-test-framework.md" -ForegroundColor Yellow
}

Function Print-ConnectionString([string]$uid, [string]$subId, [string]$aadTenant, [string]$spn, [string]$spnSecret, [string]$recordMode, [string]$targetEnvironment)
{
    if([string]::IsNullOrEmpty($subId) -eq $false)
    {
        Write-Host "SubscriptionId=" -ForegroundColor Green -NoNewline
        Write-Host $subId";" -NoNewline 
    }

    if([string]::IsNullOrEmpty($aadTenant) -eq $false)
    {
        Write-Host "AADTenant=" -ForegroundColor Green -NoNewline
        Write-Host $aadTenant";" -NoNewline
    }

    if([string]::IsNullOrEmpty($spn) -eq $false)
    {
        Write-Host "ServicePrincipal=" -ForegroundColor Green -NoNewline
        Write-Host $spn";" -NoNewline
    }

    if([string]::IsNullOrEmpty($spnSecret) -eq $false)
    {
        Write-Host "ServicePrincipalSecret=" -ForegroundColor Green -NoNewline
        Write-Host $spnSecret";" -NoNewline
    }

    if([string]::IsNullOrEmpty($recordMode) -eq $false)
    {
        Write-Host "HttpRecorderMode=" -ForegroundColor Green -NoNewline
        Write-Host $recordMode";" -NoNewline
    }

    if([string]::IsNullOrEmpty($targetEnvironment) -eq $false)
    {
        Write-Host "Environment=" -ForegroundColor Green -NoNewline
        Write-Host $targetEnvironment";" -NoNewline
    }

    Write-Host ""
}

export-modulemember -Function Set-TestEnvironment
export-modulemember -Function New-TestCredential
