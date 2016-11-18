[cmdletBinding]
Function New-ServicePrincipal
{
<#
.SYNOPSIS
This cmdlet helps you create:
1) AD Apllication needed for SPN
2) AD SPN
3) Assigning Reader role to the newly created SPN
#>
    param(
    [Parameter(Mandatory=$true, HelpMessage="Azure AD Apllication Display Name")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppDisplayName,
    
    [Parameter(Mandatory=$true, HelpMessage="Azure Subscription Id")]
    [ValidateNotNullOrEmpty()]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication Display Name")]
    [string]$TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47",

    [Parameter(Mandatory=$false, HelpMessage="True: AD App is created if does not exist")]
    [bool]$createADAppIfNotFound = $false,

    [Parameter(Mandatory=$false, HelpMessage="True: AD SPN is created if does not exist")]
    [bool]$createADSpnIfNotFound = $false
    
    )

    Set-Subscription -SubscriptionId $SubscriptionId -TenantId $TenantId

    $azAdApp = Get-ADApp -ADAppDisplayName $ADAppDisplayName
    if($azAdApp -eq $null -and $createADAppIfNotFound -eq $true)
    {
        $displayName = $ADAppDisplayName
        $homePage = "http://www.$displayName.psmodule"
        $identityUri = "http://$displayName"
        $azAdApp = New-AzureRmADApplication -DisplayName $displayName -HomePage $homePage -IdentifierUris $identityUri
    }

    $azSpn = Get-SPN -ADAppId $azAdApp.ApplicationId

    if(($azAdApp -ne $null) -and ($azSpn -eq $null))
    {
        if($createADSpnIfNotFound -eq $true)
        {
            $azSpn = New-AzureRmADServicePrincipal -ApplicationId $azAdApp.ApplicationId            
            Write-Host "Waiting for SPN to fully create and able to query ....."

            for($i=0; $i -lt 3; $i++)
            {
                #need to find a better deterministic way
                #Cases are when you try to assign roles to newly created SPN, it is not able to find it and hence Role Assignment fails
                #Get-SPN -ADAppId $azAdApp.ApplicationId
                Start-Sleep -Seconds 5
            }
        }
    }

    if($azSpn -ne $null)
    {
        $spnScope = [string]::Format("{0}{1}", "/subscriptions/", "$SubscriptionId/")

        $rdStr = [string]::Format("{0} Role will be assigned to SPNName:{1} for scope {2}", "Reader", $azAdApp.ApplicationId, $spnScope)
        Write-Host $rdStr

        $roleDef = Get-AzureRmRoleAssignment -ServicePrincipalName $azAdApp.ApplicationId -Scope $spnScope
        if($roleDef -eq $null)
        {
            New-AzureRmRoleAssignment -RoleDefinitionName "Reader" -ServicePrincipalName $azAdApp.ApplicationId -scope $spnScope
        }
    }

    Get-ServicePrincipalDetails -AdApp $azAdApp -AdSpn $azSpn

    Write-Host "Log onto Azure Portal and use Above SPN Details to find your Service Principal and obtain SPN Secret/ Authentication Key/ Secret Key for the newly created Service Principal" -ForegroundColor DarkYellow
    Write-Host "Visit https://docs.microsoft.com/en-us/azure/resource-group-create-service-principal-portal" -ForegroundColor DarkYellow
}

Function Get-ADApp
{
    param(
    [Parameter(Mandatory=$true, HelpMessage="Azure AD Apllication Display Name")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppDisplayName
    )

    $displayName = $ADAppDisplayName
    $homePage = "http://www.$displayName.psmodule"
    $identityUri = "http://$displayName"

    $azAdApp = Get-AzureRmADApplication -IdentifierUri $identityUri

    $PsCmdLet.WriteObject($azAdApp)
}

[CmdletBinding]
Function Get-SPN
{
    param(
    [Parameter(Mandatory=$true, ParameterSetName="DisplayName", HelpMessage="Azure AD Apllication Display Name")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppDisplayName,

    [Parameter(Mandatory=$true, ParameterSetName="AppId", HelpMessage="Azure AD Apllication ID")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppId
    )

    $appId = ""
    if([string]::IsNullOrEmpty($ADAppDisplayName) -eq $false)
    {
        $azAdApp = Get-ADApp -ADAppDisplayName $ADAppDisplayName
        $appId = $azAdApp.ApplicationId
    }
    
    if([string]::IsNullOrEmpty($ADAppDisplayName) -eq $true)
    {
        $appId = $ADAppId
    }

    $azSpn = Get-AzureRmADServicePrincipal -ServicePrincipalName $appId
    

    $Pscmdlet.WriteObject($azSpn)
}

[CmdletBinding]
Function Set-Subscription
{    
    param(
    [Parameter(Mandatory=$true, HelpMessage="Azure Subscription Id")]
    [ValidateNotNullOrEmpty()]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication Display Name")]
    [string]$TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    )

    $azCtx = Get-AzureRmContext

    if($azCtx -ne $null)
    {
        if($azCtx.Subscription.SubscriptionId -ne $SubscriptionId)
        {
            $azSub = Get-AzureRmSubscription -SubscriptionId $SubscriptionId -TenantId $TenantId

            if($azSub -ne $null)
            {
                if($azSub.SubscriptionId -ne $SubscriptionId)
                {
                    throw [System.ApplicationException] "'$SubscriptionId' subscriptionId is not selected'. Exiting......"
                }
                else
                {
                    Select-AzureRmSubscription -SubscriptionId $SubscriptionId -TenantId $TenantId
                }
            }
            else
            {
                throw [System.ApplicationException] "Unable to retrieve '$SubscriptionId'. Exiting......"
            }
        }
    }
}

[cmdletBinding]
Function Get-ServicePrincipalDetails
{
    param(
        [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication")]
        [Microsoft.Azure.Commands.Resources.Models.ActiveDirectory.PSADApplication] $AdApp,

        [Parameter(Mandatory=$false, HelpMessage="Azure AD ServicePrincipal")]
        [Microsoft.Azure.Commands.Resources.Models.ActiveDirectory.PSADServicePrincipal] $AdSpn
    )

    if($AdApp -ne $null)
    {
        Write-Host "AD App Info"
        Write-Host ([string]::Format("Active Directory App Display Name: {0}", $AdApp.DisplayName))
        Write-Host ([string]::Format("Active Directory App ClientId: {0}", $AdApp.ApplicationId))
        Write-Host ([string]::Format("Active Directory App Identifier Uri: {0}", $AdApp.IdentifierUris[0].ToString()))
        Write-Host
    }

    if($AdSpn -ne $null)
    {
        Write-Host "SPN Info"
        Write-Host ([string]::Format("SPN Id: {0}", $AdSpn.Id))        
        Write-Host ([string]::Format("SPN Display Name: {0}", $AdSpn.DisplayName))        
        Write-Host ([string]::Format("SPN associated with Active Directory App Id: {0}", $AdSpn.ApplicationId))        
        Write-Host
    }
}

[cmdletBinding]
Function Remove-ServicePrincipal
{
    [CmdletBinding(SupportsShouldProcess=$true)]

    param(
    [Parameter(Mandatory=$true, HelpMessage="Azure AD Apllication Display Name")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppDisplayName,
    
    [Parameter(Mandatory=$true, HelpMessage="Azure Subscription Id")]
    [ValidateNotNullOrEmpty()]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication Display Name")]
    [string]$TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    )

    Set-Subscription -SubscriptionId $SubscriptionId -TenantId $TenantId

    if($PSCmdlet.ShouldProcess("$ADAppDisplayName"))
    {
        $AdApp = Get-ADApp -ADAppDisplayName $ADAppDisplayName
        $azSpn = Get-SPN -ADAppId $adApp.ApplicationId
        $adappStr = [string]::Format("{0} ADApp will be deleted", $AdApp.ApplicationId.ToString())
        $spnStr = [string]::Format("{0} SPN will be deleted", $azSpn.DisplayName)

        Remove-AzureRmADServicePrincipal -ObjectId $azSpn.Id -Force
        Remove-AzureRmADApplication -ObjectId $AdApp.ObjectId -Force
        Write-Host $adappStr
        Write-Host $spnStr

    }
    else
    {
        $AdApp = Get-ADApp -ADAppDisplayName $ADAppDisplayName
        $azSpn = Get-SPN -ADAppId $adApp.ApplicationId

        $adappStr = [string]::Format("{0} ADApp will be deleted", $AdApp.ApplicationId.ToString())
        $spnStr = [string]::Format("{0} SPN will be deleted", $azSpn.DisplayName)
        Write-Host $adappStr
        Write-Host $spnStr
    }
}

[cmdletBinding]
Function Set-SPNRole
{
    param(
    [Parameter(Mandatory=$true, HelpMessage="Azure AD Application Display Name")]
    [ValidateNotNullOrEmpty()]
    [string]$ADAppDisplayName,
    
    [Parameter(Mandatory=$true, HelpMessage="Azure Subscription Id")]
    [ValidateNotNullOrEmpty()]
    [string]$SubscriptionId,

    [Parameter(Mandatory=$false, HelpMessage="Azure AD Apllication Display Name")]
    [string]$TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    )

    Set-Subscription -SubscriptionId $SubscriptionId -TenantId $TenantId
    $adApp = Get-ADApp -ADAppDisplayName $ADAppDisplayName

    if($adApp -ne $null)
    {
        $azSpn = Get-SPN -ADAppId $adApp.ApplicationId
        $spnScope = [string]::Format("{0}{1}", "/subscriptions/", "$SubscriptionId/")    
        $roleDef = Get-AzureRmRoleAssignment -ServicePrincipalName $adApp.ApplicationId -Scope $spnScope

        if($roleDef -eq $null)
        {
            $rdStr = [string]::Format("{0} Role will be assigned to SPNName:{1} for scope {2}", "Reader", $adApp.ApplicationId, $spnScope)
            Write-Host $rdStr
            New-AzureRmRoleAssignment -RoleDefinitionName "Reader" -ServicePrincipalName $adApp.ApplicationId -scope $spnScope
        }
    }
    else
    {
        Write-Host "Unable to find AD App: $ADAppDisplayName"
    }
}

[CmdletBinding]
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

        [ValidateSet("Prod", "Dogfood", "Current", "Next")]
        [string]$TargetEnvironment='Prod'
    )

    [string]$uris="https://management.azure.com/"

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
    
    $formattedConnStr = [string]::Format([string]::Concat($formattedConnStr, ";BaseUri={0}"), $uris)

    Write-Host "Below connection string is ready to be set"
    Print-ConnectionString $UserId $Password $SubscriptionId $TenantId $ServicePrincipal $ServicePrincipalSecret $RecordMode $TargetEnvironment $uris

    #Set connection string to Environment variable
    $env:TEST_CSM_ORGID_AUTHENTICATION=$formattedConnStr
    Write-Host ""

    # Retrieve the environment variable
    Write-Host ""
    Write-Host "Below connection string was set. Start Visual Studio by typing devenv" -ForegroundColor Green
    [Environment]::GetEnvironmentVariable($envVariableName)
    Write-Host ""
    
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

    if([string]::IsNullOrEmpty($uris) -eq $false)
    {
        Write-Host "BaseUri=" -ForegroundColor Green -NoNewline
        Write-Host $uris -NoNewline
    }

    Write-Host ""
}

export-modulemember -Function Set-TestEnvironment
export-modulemember -Function Remove-ServicePrincipal
export-modulemember -Function New-ServicePrincipal
export-modulemember -Function Set-SPNRole