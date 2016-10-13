<#
    NOTE:
    =====
    If for any reason, Service Principal needs to be recreated
    The below gPsAutoTestADAppId will have to be hard-coded with the new App Id
    This is required when you already have certificate installed locally and need to login and authenticate
    against service principal using the AppId
#>
$global:gPsAutoTestADAppId = 'b8a1058e-25e8-4b08-b40b-d8d871dda591'

$global:gPsAutoTestSubscriptionName = 'Node CLI Test'
$global:gPsAutoTestSubscriptionId = '2c224e7e-3ef5-431d-a57b-e71f4662e3a6'

$global:gTenantId = '72f988bf-86f1-41af-91ab-2d7cd011db47'
$global:gLocalCertSubjectName = 'CN=PsAutoTestCert, OU=MicrosoftAzurePsTeam'
$global:gPfxLocalFileName = "PsAutoTestCert.pfx"
$global:gpubSettingLocalFileName = "NodeCLITest.publishsettings"

$global:gVaultName = 'KV-PsSdkAuto'
$global:gPsAutoResGrpName = 'AzurePsSdkAuto'


$global:gKVKey_ADAppIdKey = "PsAutoTestAppUsingCertAppId"

$global:gLocalCertStore = 'Cert:\CurrentUser\My'
$global:gCertPwd = ''
$global:gLoggedInCtx = $null
$global:localPfxDirPath = [Environment]::GetEnvironmentVariable("TEMP")

#KV KeyVaules
$global:kvSecKey_PsAutoTestCertNameKey = 'PsAutoTestCertName'
$global:gPsAutoTestADAppUsingSPNKey = 'PsAutoTestADAppUsingSPN'
$global:gkvSecKey_PubSettingFileNameKey = 'NodeCliTestPubSetFile'


Function Check-LoggedInContext()
{
    if($gLoggedInCtx -eq $null)
    {
        Write-Error "'$global:gPsAutoTestSubscriptionName' subcription does not exist in the list of available subscriptions. Make sure to have it to run the tests"
        Exit
    }
}

Function Get-AutomationTestCertificate()
{
    [OutputType([System.Security.Cryptography.X509Certificates.X509Certificate])]
    Param ($cert)

    if($gLoggedInCtx -ne $null)
    {
        #Download Certificate from KeyVault
        $downloadedCertPath = Download-TestCertificateFromKeyVault

        #Install Certificate locally
        Install-TestCertificateOnMachine $downloadedCertPath

        #Verify it was installed locally
        $cert = Get-LocalCertificate
        if($cert -eq $null)
        {
            throw [System.ApplicationException] "Unable to retrieve Automation Test Certificate '$gLocalCertSubjectName'"
        }
    }
    return $cert
}

Function Get-LocalCertificate()
{
    #TODO: Handle case whgere we get multiple test certificates with exactly the same subject
    $cert = Get-ChildItem $gLocalCertStore | Where-Object {$_.Subject -eq $Global:gLocalCertSubjectName}
    if($cert -eq $null)
    {
        Log-Info "Trying to find certificate in LocalMachine"
        $cert = Get-ChildItem 'Cert:\LocalMachine\My' | Where-Object {$_.Subject -eq $Global:gLocalCertSubjectName}
    }

    return $cert
}

Function Get-ADAppForAutoTest()
{   
    $displayName = $global:gPsAutoTestADAppUsingSPNKey
    $homePage = "http://www.$displayName.com"
    $identityUri = "http://$displayName"

    $currentDate = Get-Date
    $endDate = $currentDate.AddYears(1)
    $notAfter = $endDate.AddYears(1)

    $psAutoADApp = Get-AzureRmADApplication -DisplayNameStartWith $global:gPsAutoTestADAppUsingSPNKey
    if($psAutoADApp -eq $null)
    {
        $certPwd = "123"
        $secCertPwd = ConvertTo-SecureString -String $certPwd -AsPlainText -Force
        $pfxLocalFilePath = [System.IO.Path]::Combine($global:localPfxDirPath, $global:gPfxLocalFileName)
        $localCert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate($pfxLocalFilePath, $secCertPwd)        

        $localCert.GetEffectiveDateString()
        $localCert.GetExpirationDateString()

        $certRawData = $localCert.GetRawCertData()
        $binaryAsciiCertData = [System.Convert]::ToBase64String($certRawData)

        $keyCredential = New-Object  Microsoft.Azure.Commands.Resources.Models.ActiveDirectory.PSADKeyCredential
        $keyCredential.StartDate = $currentDate
        $keyCredential.EndDate= [DateTime]::Parse($localCert.GetExpirationDateString())
        $keyCredential.KeyId = [guid]::NewGuid()
        #$keyCredential.Type = "AsymmetricX509Cert"
        #$keyCredential.Usage = "Verify"
        #$keyCredential.Value = $binaryAsciiCertData
        $keyCredential.CertValue = $binaryAsciiCertData
                        
        #AD app does not exists, create one
        $psAutoADApp = New-AzureRmADApplication -DisplayName $global:gPsAutoTestADAppUsingSPNKey -HomePage $homePage -IdentifierUris $identityUri -KeyCredentials $keyCredential
  
        if($psAutoADApp -eq $null)
        {
            throw [System.ApplicationException] "Unable to create new Azure AD Applicaiton using 'New-AzureRmADApplication'. Exiting......"
        }

        #delete local copy of pfx copy
        #Remove-Item -Path $pfxLocalFilePath
    }
    
    return $psAutoADApp
}

Function Get-ADServicePrincipalForAutoTest()
{
    #This function assumes, you have already created ADApp, if not then call the function that creates it
    $adApp = Get-AzureRmADApplication -DisplayNameStartWith $global:gPsAutoTestADAppUsingSPNKey
    if($adApp -eq $null)
    {
        throw [System.ApplicationException] "Unable to get '$global:gPsAutoTestADAppUsingSPNKey' AD Application in order to create SPN"
    }

    #search for existing SPN
    $adAppSpn = Get-AzureRmADServicePrincipal -ServicePrincipalName $adApp.ApplicationId
        
    if($adAppSpn -eq $null)
    {
        #Create SPN

        #Note: You create new SPN with AppId as ADApp.AppId, and if you have to search for the SPN, you need to search
        #for SPN using ServicePrincipalName and provide ADApp.AppId
        $adAppSpn = New-AzureRmADServicePrincipal -ApplicationId $adApp.ApplicationId

        #Assign 'Reader' role to the SPN for the entier subscription
        $spnScope = [string]::Format("{0}{1}", "/subscriptions/", "2c224e7e-3ef5-431d-a57b-e71f4662e3a6/")
        New-AzureRmRoleAssignment -RoleDefinitionName "Reader" -ServicePrincipalName $adApp.ApplicationId.Guid -scope $spnScope
    }

    if($adAppSpn -eq $null)
    {
        throw [System.ApplicationException] "Unable to create Service Principal for ADApp '$global:gPsAutoTestADAppUsingSPNKey'"
    }
    #There is a AD Graph bug where we cannot use Get-AzureRmRoleAssignment due to API version mismatch
    #TODO: check if the SPN has the right Role Assignment, if not assign Reader Role

    return $adAppSpn
}

Function Upload-PublishSettingsFileToKv([string] $kvPubFileKeyName, [string] $pubSettingFilePath)
{
    #This function will never be called again, because once the publishsettings file is in KeyVault, unless
    #we change the publish settings file.
    #Here is a sample call
    #Upload-PublishSettingsFileToKv $global:gkvSecKey_PubSettingFileNameKey "<Local Publish setting file path>"

    #TODO: Validation for file path and azure KV existence. Once the file is save, making sure the secret was set correctly
    $pubSetFileContents = [System.IO.File]::ReadAllText($pubSettingFilePath)
    $secureFileContents = ConvertTo-SecureString -String $pubSetFileContents -AsPlainText -Force

    Set-AzureKeyVaultSecret -VaultName $global:gVaultName -Name $global:gkvSecKey_PubSettingFileNameKey -SecretValue $secureFileContents -Tag @{"PublishSettingsFile" = "Logging Into RDFE"}
}

Function Download-PublishSettingsFileFromKv([string] $localFilePathToDownload)
{
    $dirPath = [System.IO.Path]::GetDirectoryName($localFilePathToDownload)
    $pubFileSecContents = Get-AzureKeyVaultSecret -VaultName $global:gVaultName -Name $global:gkvSecKey_PubSettingFileNameKey
    Log-Info "Ready to download Publishsettings file to '$localFilePathToDownload' from Azure KeyVault"
    
    if([System.IO.Directory]::Exists($dirPath) -eq $true)
    {
        [System.IO.File]::WriteAllText($localFilePathToDownload, $pubFileSecContents.SecretValueText)
    }
    else
    {
        throw [System.IO.DirectoryNotFoundException] "$dirPath does not exists"
    }
    
    Log-Info "Successfully downloaded Publishsettings file to '$localFilePathToDownload'"
}

Function Create-TestAutoCertificateInKv([string] $vaultName, [string] $certName)
{
    $newlyCreatedCert = $null
    $pollingInterval = 25, 50, 75, 100
    $certExpPolicy = New-AzureKeyVaultCertificatePolicy -SubjectName $global:gLocalCertSubjectName -IssuerName Self -ValidityInMonths 12

    Log-Info "Creating new certificate in Azure KeyVault...."
    Add-AzureKeyVaultCertificate -VaultName $vaultName -Name $certName -CertificatePolicy $certExpPolicy -Tag @{"12 Month Validity" = "TestCertValidity"; "TestAutomation Purpose" = "Cert Purpose"}

    foreach($percCompleted in $pollingInterval)
    {
        $certCreationOperation = Get-AzureKeyVaultCertificateOperation -VaultName $vaultName -Name $certName
        if($certCreationOperation.Status -eq "completed" -and ([string]::IsNullOrEmpty($certCreationOperation.ErrorCode) -eq $true))
        {
            Log-Info "Certificate created successfully in Azure KeyVault"
            $newlyCreatedCert = Get-AzureKeyVaultCertificate -VaultName $vaultName -Name $certName
            break
        }
        else
        {
            Write-Progress -activity "Checking Certification Creation status" -status "Percent completed: " -PercentComplete (($percCompleted / ($pollingInterval.length) * 25)  * 100)
            Start-Sleep -Seconds 10
        }
    }

    if($newlyCreatedCert -eq $null)
    {
        $statusDetails = $certCreationOperation.StatusDetais
        throw [System.ApplicationException] "Unable to create self signed certificate in Key Vault. Last certification status was: $statusDetails"
    }

    return $newlyCreatedCert

    #Get-AzureKeyVaultCertificateOperation -VaultName KV-PsSdkAuto -Name PsAutoTestCertName
    #Get-AzureKeyVaultCertificate -VaultName KV-PsSdkAuto
}

Function Install-TestCertificateOnMachine([string] $localCertPath)
{
    #$certContentType = "application/x-pkcs12"
    if([System.IO.File]::Exists($localCertPath) -ne $true)
    {
        $localCertPath = Download-TestCertificateFromKeyVault
    }

    $pwd = Get-LocalCertificatePassword
    $secCertPwd = ConvertTo-SecureString -String $pwd -AsPlainText -Force

    Log-Info "Ready to install certificate to '$global:gLocalCertStore'"
    Import-PfxCertificate -FilePath $localCertPath -CertStoreLocation $gLocalCertStore -Password $secCertPwd

    $installedCert = Get-LocalCertificate
    if($installedCert -eq $null)
    {
        throw [System.ApplicationException] "Unable to retrieve installed certificate for running automation test"
    }
    else
    {
        Log-Info "Successfully installed certificate to '$global:gLocalCertStore'"
    }
    
    <#
    $kvCertSecret = Get-KVSecretValue $global:kvSecKey_PsAutoTestCertNameKey
        
    #test content type
    $kvCertSecret.Attributes.ContentType

    $kvSecretBytes = [System.Convert]::FromBase64String($kvCertSecret.SecretValueText)
    $certCollection2 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
    $certCollection2.Import($kvSecretBytes, $null, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)
    $thumbPrint = $certCollection2.Item(0).Thumbprint

    #Test retrieved certCollection contents
    #$certCollection2

    #Save Pfx locally
    $certPwd = "123"
    $secCertPwd = ConvertTo-SecureString -String $certPwd -AsPlainText -Force
    $certPwdProtectedInBytes = $certCollection2.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Pkcs12, $certPwd)
    $pfxLocalFilePath = [System.IO.Path]::Combine([Environment]::GetEnvironmentVariable("TEMP"), $global:gPfxLocalFileName)
    if([System.IO.File]::Exists($pfxLocalFilePath) -eq $true)
    {
        [System.IO.File]::Delete($pfxLocalFilePath)
    }

    [System.IO.File]::WriteAllBytes($pfxLocalFilePath, $certPwdProtectedInBytes)

    if([System.IO.File]::Exists($pfxLocalFilePath) -eq $true)
    {
        Import-PfxCertificate -FilePath $pfxLocalFilePath -CertStoreLocation Cert:\LocalMachine\My -Password $secCertPwd
    }

    #Remove-Item -Path $pfxLocalFilePath

    #TODO Find if the certificate was successfully installed
    #>
}

Function Download-TestCertificateFromKeyVault()
{
    $certContentType = "application/x-pkcs12"
    $certName = "PsAutoTestCertName"
    $vaultName = "KV-PsSdkAuto"

    Check-LoggedInContext
    $kvCertSecret = Get-AzureKeyVaultSecret -VaultName $global:gVaultName -Name $global:kvSecKey_PsAutoTestCertNameKey

    if($kvCertSecret -eq $null)
    {
        Log-Info "Unable to get certificate from Azure KeyVault"
        $kvCertSecret = Create-TestAutoCertificateInKv $gVaultName $kvSecKey_PsAutoTestCertNameKey
    }
    
    #Once we create certificate and get it, we store it locally
    if($kvCertSecret -ne $null)
    {
        #test content type
        #$kvCertSecret.Attributes.ContentType

        $kvSecretBytes = [System.Convert]::FromBase64String($kvCertSecret.SecretValueText)
        $certCollection2 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
        $certCollection2.Import($kvSecretBytes, $null, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)

        #Test retrieved certCollection contents
        #$certCollection2

        #Save Pfx locally
        $pwd = Get-LocalCertificatePassword
        $certPwdProtectedInBytes = $certCollection2.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Pkcs12, $pwd)
        $pfxLocalFilePath = [System.IO.Path]::Combine($global:localPfxDirPath, $global:gPfxLocalFileName)
        [System.IO.File]::WriteAllBytes($pfxLocalFilePath, $certPwdProtectedInBytes)

        #We are not going the .cer route for now, rather use publishSettings file
        #Save .cer file location to be uploaded to the management portal
        #$kvAutoTestCert = Get-AzureKeyVaultCertificate -VaultName $vaultName -Name $certName
        #$cerLocalFilePath = [Environment]::GetFolderPath("Desktop") + "\PsAutoTestCert.cer"
        #$certBytes = $kvAutoTestCert.Certificate.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Cert)
        #[System.IO.File]::WriteAllBytes($cerLocalFilePath, $certBytes)
    }

    Log-Info "Successfully downloaded certificate at '$pfxLocalFilePath'"
    return $pfxLocalFilePath
}

Function Get-LocalCertificatePassword()
{
    if([string]::IsNullOrEmpty($global:gCertPwd) -eq $true)
    {
        $global:gCertPwd = Read-Host "Please enter certificate password that is ready to be installed on your machine"        
    }

    return $global:gCertPwd
}

<#
This function will allow you to get x509Certificate
#>
Function Get-AutoTestCertFromKv()
{
    $kvAutoTestCert = Get-AzureKeyVaultCertificate -VaultName $Global:gVaultName -Name $global:kvSecKey_PsAutoTestCertNameKey
    if($kvAutoTestCert -eq $null)
    {
        Write-Host "Certificate with name '$global:kvSecKey_PsAutoTestCertNameKey' does not exists in '$Global:gVaultName' Auzre KeyVault"
    }

    return $kvAutoTestCert
}

Function Login-AzureRMWithCertificate()
{
    $appId = $global:gPsAutoTestADAppId

    $localCert = Get-LocalCertificate
    if($localCert -eq $null)
    {
        #we could not find certificate installed locally, get it from KeyVault
        Login-InteractivelyAndSelectTestSubscription
        $localCert = Get-AutomationTestCertificate

        #TODO: Handle the case where local certificate is available, but for some reason Service Principal is not available

        #Verify if Service Principal is available
        $psAutoADApp = Get-ADAppForAutoTest
        $spn = Get-ADServicePrincipalForAutoTest
        $appId = $psAutoADApp.ApplicationId
    }
    
    $thumb = $localCert.Thumbprint
    #Seen cases where for some odd reason, $thumb is being evaluated as object rather than a string, but this does not happen consistently
    $thumbStr = [System.Convert]::ToString($thumb.ToString())

    #Update the LoggedInCtx
    #it seems the cmdLet is trying to find cert first in LocalMachine and if not found writes error string and then looks in CurrentUser
    $gLoggedInCtx = Login-AzureRmAccount -ServicePrincipal -CertificateThumbprint $thumbStr -ApplicationId $appId -TenantId $global:gTenantId    
}

Function Login-AzureWithCertificate()
{
    $fullPath = [System.IO.Path]::Combine($PSScriptRoot, $global:gpubSettingLocalFileName)

    if([System.IO.File]::Exists($fullPath) -ne $true)
    {
        Download-PublishSettingsFileFromKv $fullPath        
    }

    Import-AzurePublishSettingsFile -PublishSettingsFile $fullPath    
}

Function Login-InteractivelyAndSelectTestSubscription()
{
    Log-Info "Logging interactively....."
    $global:gLoggedInCtx = Login-AzureRmAccount
    Log-Info "Selecting '$global:gPsAutoTestSubscriptionId' subscription"
    $global:gLoggedInCtx = Select-AzureRmSubscription -SubscriptionId $global:gPsAutoTestSubscriptionId

    return $global:gLoggedInCtx
}

Function Init([bool]$deleteLocalCertificate=$false)
{
    CleanUp-Subscriptions
    Delete-LocalCertificate $deleteLocalCertificate

    Login-AzureRMWithCertificate
    Select-AzureRmSubscription -SubscriptionId $global:gPsAutoTestSubscriptionId -TenantId $global:gTenantId

    Login-AzureWithCertificate
    Select-AzureSubscription -SubscriptionId $subscriptionIdToUse -Current
}

Function Test-CleanUp()
{
    $pfxFilePath = [System.IO.Path]::Combine($global:localPfxDirPath,$global:gPfxLocalFileName)
    if([System.IO.File]::Exists($pfxFilePath) -eq $true)
    {
        Remove-Item $pfxFilePath
    }

    $pubSettingFile = [System.IO.Path]::Combine($PSScriptRoot,$global:gpubSettingLocalFileName)
    if([System.IO.File]::Exists($pubSettingFile) -eq $true)
    {
        Remove-Item $pubSettingFile
    }
    
    CleanUp-Subscriptions
}

Function Log-Info([string] $info)
{
    $info = [string]::Format("[INFO]: {0}", $info)
    Write-Host $info -ForegroundColor Yellow
}

Function Log-Error([string] $errorInfo)
{
    $errorInfo = [string]::Format("[INFO]: {0}", $errorInfo)
    Write-Error -Message $errorInfo
}

function CleanUp-Subscriptions()
{
    Get-AzureSubscription | ForEach-Object {Remove-AzureSubscription -SubscriptionId $_.SubscriptionId -Force}
}

Function Delete-LocalCertificate([bool]$deleteLocalCertificate)
{
    $cert = Get-LocalCertificate
    if($cert -ne $null -and $deleteLocalCertificate -eq $true)
    {
        $certPath = $cert.PSPath
        Log-Info "Deleting local certificate $certPath"
        Remove-Item $cert.PSPath
    }
}

Function CleanUpSPN()
{
    $psAutoADApp = Get-AzureRmADApplication -DisplayNameStartWith $global:gPsAutoTestADAppUsingSPNKey
    if($psAutoADApp -ne $null)
    {
        Remove-AzureRmADApplication -ObjectId $psAutoADApp.ObjectId
    }
}

Function Check-KvTestCertificateExists([string] $vaultName, [string] $certName)
{
    $certExists = $false
    Try
    {
        Get-AzureKeyVaultCertificate -VaultName $vaultName -Name $certName
        $certExists = $true
    }    
    Catch
    {
        $certExists = $false    
    }

    return $certExists
}

Function Get-KVSecretValue([string] $kvSecretName)
{
    return Get-AzureKeyVaultSecret -VaultName $global:gVaultName -Name $kvSecretName
}

Function Delete-TestCertificateFromKv([string] $vaultName, [string] $certName)
{
    Remove-AzureKeyVaultCertificate -VaultName $vaultName -Name $certName
}