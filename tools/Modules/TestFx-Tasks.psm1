Function New-AzureCredential
{
    [CmdletBinding(
        DefaultParameterSetName='CreateSpnParamSet', 
        SupportsShouldProcess=$true
        )]
    param(
        [Parameter(ParameterSetName='CreateSpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal DisplayName you would like to set')]
        [ValidateNotNullOrEmpty()]
        [string]$NewServicePrincipalDisplayName,

        [Parameter(ParameterSetName='CreateSpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal password')]
        [ValidateNotNullOrEmpty()]
        [string]$NewServicePrincipalSecret,

        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "UserId (OrgId) you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$UserId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal/ClientId you would like to use')]   
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [Parameter(ParameterSetName='CreateSpnParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [Parameter(ParameterSetName='CreateSpnParamSet', Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

        [Parameter(ParameterSetName='CreateSpnParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage = "Record tests, Playback tests, or neither")]
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "Record tests, Playback tests, or neither")]
        [ValidateSet("Playback", "Record", "None")]
        [string]$RecordMode,

        [ValidateSet("Prod", "Dogfood", "Current", "Next", "Custom")]
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
        [string]$DataLakeAnalyticsJobAndCatalogServiceUri,
        
        [switch]$Force
    )

    [hashtable]$credentials = @{}
    $credentials.SubscriptionId = $SubscriptionId
    $credentials.HttpRecorderMode = $RecordMode
    $credentials.Environment = $TargetEnvironment

    if ([string]::IsNullOrEmpty($NewServicePrincipalDisplayName) -eq $false) {
        $Scope = "/subscriptions/" + $SubscriptionId
        $SecureStringSecret = ConvertTo-SecureString $NewServicePrincipalSecret -AsPlainText -Force
        $NewServicePrincipal = New-AzureRMADServicePrincipal -DisplayName $NewServicePrincipalDisplayName -Password $SecureStringSecret
        Write-Host "New ServicePrincipal created: " + $NewServicePrincipal

        $NewRole = $null
        $Retries = 0;
        While ($NewRole -eq $null -and $Retries -le 6)
        {
            # Sleep here for a few seconds to allow the service principal application to become active (should only take a couple of seconds normally)
            Start-Sleep 5
            New-AzureRMRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName $NewServicePrincipal.ApplicationId -Scope $Scope | Write-Verbose -ErrorAction SilentlyContinue
            $NewRole = Get-AzureRMRoleAssignment -ObjectId $NewServicePrincipal.Id -ErrorAction SilentlyContinue
            $Retries++;
        }
        
        $credentials.ServicePrincipal = $NewServicePrincipal.ApplicationId
        $credentials.ServicePrincipalSecret = $NewServicePrincipalSecret
    }

    if ([string]::IsNullOrEmpty($UserId) -eq $false) {
        $credentials.UserId = $UserId
    }
    
    if ([string]::IsNullOrEmpty($ServicePrincipalId) -eq $false) {
        $credentials.ServicePrincipal = $ServicePrincipalId
        $credentials.ServicePrincipalSecret = $ServicePrincipalSecret
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
    [CmdletBinding(DefaultParameterSetName='UserIdParamSet')]
    param(
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "UserId (OrgId) you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$UserId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal/ClientId you would like to use')]   
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

	[Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage = "Would you like to record or playback your tests?")]
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "Would you like to record or playback your tests?")]
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

    if([string]::IsNullOrEmpty($UserId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";UserId={0}"), $UserId)
    }

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
    Print-ConnectionString $UserId $SubscriptionId $TenantId $ServicePrincipal $ServicePrincipalSecret $RecordMode $TargetEnvironment

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    $env:AZURE_TEST_MODE=$RecordMode
    Write-Host ""

    # Retrieve the environment variable
    Write-Host ""
    Write-Host "Below connection string was set. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md" -ForegroundColor Yellow
}

Function Print-ConnectionString([string]$uid, [string]$subId, [string]$aadTenant, [string]$spn, [string]$spnSecret, [string]$recordMode, [string]$targetEnvironment)
{

    if([string]::IsNullOrEmpty($uid) -eq $false)
    {
        Write-Host "UserId=" -ForegroundColor Green -NoNewline
        Write-Host $uid";" -NoNewline 
    }

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
export-modulemember -Function New-AzureCredential
