$taskScriptDir = [System.IO.Path]::GetDirectoryName($PSCommandPath)
$env:repoRoot = [System.IO.Path]::GetDirectoryName($taskScriptDir)
$userPsFileDir = [string]::Empty
[string]$envVariableName="TEST_CSM_ORGID_AUTHENTICATION"

[CmdletBinding]
Function Set-TestEnvironment
{
<#
.SYNOPSIS
This cmdlet helps you to setup Test Environment for running tests
In order to successfully run a test, you will need SubscriptionId, TenantId
This cmdlet will only prompt you for Subscription and Tenant information, rest all other parameters are optional

#>
    [CmdletBinding(DefaultParameterSetName='SpnParamSet')]
    param(
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "UserId (OrgId) you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$UserId,

        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "UserId (OrgId) you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$Password,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal/ClientId you would like to use')]   
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipal,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='ServicePrincipal Secret/ClientId Secret you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$ServicePrincipalSecret,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true)]
        [Parameter(ParameterSetName='UserIdParamSet', Mandatory=$true, HelpMessage = "SubscriptionId you would like to use")]
        [ValidateNotNullOrEmpty()]
        [string]$SubscriptionId,

        [Parameter(ParameterSetName='SpnParamSet', Mandatory=$true, HelpMessage='AADTenant/TenantId you would like to use')]
        [ValidateNotNullOrEmpty()]
        [string]$TenantId,

        [ValidateSet("Playback", "Record", "None")]
        [string]$RecordMode='Playback',

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
		[string]$DataLakeAnalyticsJobAndCatalogServiceUri
    )

    [string]$uris=""

    $formattedConnStr = [string]::Format("SubscriptionId={0};HttpRecorderMode={1};Environment={2}", $SubscriptionId, $RecordMode, $TargetEnvironment)

    if([string]::IsNullOrEmpty($UserId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";UserId={0}"), $UserId)
    }

    if([string]::IsNullOrEmpty($Password) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";Password={0}"), $Password)
    }

    if([string]::IsNullOrEmpty($TenantId) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";AADTenant={0}"), $TenantId)
    }

    if([string]::IsNullOrEmpty($ServicePrincipal) -eq $false)
    {
        $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";ServicePrincipal={0}"), $ServicePrincipal)
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
	
    
    #$formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";BaseUri={0}"), $uris)

    Write-Host "Below connection string is ready to be set"
    #Print-ConnectionString $UserId $Password $SubscriptionId $TenantId $ServicePrincipal $ServicePrincipalSecret $RecordMode $TargetEnvironment $uris 
	Print-ConnectionString $UserId $Password $SubscriptionId $TenantId $ServicePrincipal $ServicePrincipalSecret $RecordMode $TargetEnvironment $uris $ResourceManagementUri $GraphUri $AADAuthUri $AADTokenAudienceUri $GraphTokenAudienceUri $IbizaPortalUri $ServiceManagementUri $RdfePortalUri $GalleryUri $DataLakeStoreServiceUri $DataLakeAnalyticsJobAndCatalogServiceUri

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    Write-Host ""

    # Set AZURE_TEST_MODE
    $env:AZURE_TEST_MODE=$RecordMode

    # Retrieve the environment variable
    Write-Host ""
    Write-Host "Below connection string was set. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
	Write-Host "You can manually set this env. variable as $env:TEST_CSM_ORGID_AUTHENTICATION=<connection string without double quotes>"
    Write-Host "If your needs demand you to set connection string differently, for all the supported Key/Value pairs in connection string"
    Write-Host "Please visit https://github.com/Azure/azure-powershell/blob/dev/documentation/Using-Azure-TestFramework.md" -ForegroundColor Yellow
}

Function Print-ConnectionString([string]$uid, [string]$pwd, [string]$subId, [string]$aadTenant, [string]$spn, [string]$spnSecret, [string]$recordMode, [string]$targetEnvironment, [string]$uris)
{

    if([string]::IsNullOrEmpty($uid) -eq $false)
    {
        Write-Host "UserId=" -ForegroundColor Green -NoNewline
        Write-Host $uid";" -NoNewline 
    }

    if([string]::IsNullOrEmpty($pwd) -eq $false)
    {
        Write-Host "Password=" -ForegroundColor Green -NoNewline
        Write-Host $pwd";" -NoNewline 
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
	
	#========================================
	if([string]::IsNullOrEmpty($ResourceManagementUri) -eq $false)
    {
        Write-Host "ResourceManagementUri=" -ForegroundColor Green -NoNewline
        Write-Host $ResourceManagementUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($GraphUri) -eq $false)
    {
        Write-Host "GraphUri=" -ForegroundColor Green -NoNewline
        Write-Host $GraphUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($AADTokenAudienceUri) -eq $false)
    {
        Write-Host "AADTokenAudienceUri=" -ForegroundColor Green -NoNewline
        Write-Host $AADTokenAudienceUri";" -NoNewline
    }

    if([string]::IsNullOrEmpty($GraphTokenAudienceUri) -eq $false)
    {
        Write-Host "GraphTokenAudienceUri=" -ForegroundColor Green -NoNewline
        Write-Host $GraphTokenAudienceUri -NoNewline
    }
	
	if([string]::IsNullOrEmpty($IbizaPortalUri) -eq $false)
    {
        Write-Host "IbizaPortalUri=" -ForegroundColor Green -NoNewline
        Write-Host $IbizaPortalUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($ServiceManagementUri) -eq $false)
    {
        Write-Host "ServiceManagementUri=" -ForegroundColor Green -NoNewline
        Write-Host $ServiceManagementUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($RdfePortalUri) -eq $false)
    {
        Write-Host "RdfePortalUri=" -ForegroundColor Green -NoNewline
        Write-Host $RdfePortalUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($GalleryUri) -eq $false)
    {
        Write-Host "GalleryUri=" -ForegroundColor Green -NoNewline
        Write-Host $GalleryUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($DataLakeStoreServiceUri) -eq $false)
    {
        Write-Host "DataLakeStoreServiceUri=" -ForegroundColor Green -NoNewline
        Write-Host $DataLakeStoreServiceUri";" -NoNewline
    }
	
	if([string]::IsNullOrEmpty($DataLakeAnalyticsJobAndCatalogServiceUri) -eq $false)
    {
        Write-Host "DataLakeAnalyticsJobAndCatalogServiceUri=" -ForegroundColor Green -NoNewline
        Write-Host $DataLakeAnalyticsJobAndCatalogServiceUri";" -NoNewline
    }

    Write-Host ""
}

export-modulemember -Function Set-TestEnvironment