<#
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

This script will allow to login as long as you have required certificate installed on your machine

WorkFlow# 1
===========
1) Will Check if the certificate is installed
2) If not will ask you to login (one time) to access KeyVault
3) Download Certificate, install certificate on the machine (will prompt to set certificate password)
4) Login using the recently installed certificate
5) Set the context for Test Subscription
6) Download PublishSettings file from keyVault to enable log into ASM
8) Run Tests
9) Clean up - Delete any locally downloaded certificates or publishsettings file

WorkFlow# 2
============
1) Check if certificate is installed
2) If Yes, log in using certificate
3) Download publishsettings file from KeyVault
4) Log into ASM using publish settings file
5) Run Tests
6) Clean up

TODO:
1) Currently ServicePrincipal ClientId is hard-Coded in script
Will need to push that in KeyVault and use it to get the ClientId every single time you need to login using service principal
Will also need a way to replace existing ClientId ID, if Service principal is recreated.
<#--------Current certificate expires 10/7/2017 --------->
2) Will need a way check if local certificate is near expiry, if yes create a new one in keyVault and delete existing one.
3) When replacing Certificate, you will also need to set new role Assignment using the new certificate.

Issues:
1) During the very first log in using certificate, an error pops up "Connect-AzureRmAccount : No certificate was found in the certificate store with thumbprint System.Object[]"
This is a transient error, but eventually the login is successful as it finds the certificate in Currentuser store
So after the first try, this error no longer shows up.
Will open an issue to investigate where we try both the cert store simultenously rather we should try Currentuser and if not found then try LocalMachine.
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

$global:gLocalCertStore = 'Cert:\CurrentUser\My'
$global:gCertPwd = ''
$global:gLoggedInCtx = $null
$global:localPfxDirPath = [Environment]::GetEnvironmentVariable("TEMP")

#KV KeyVaules
$global:kvSecKey_PsAutoTestCertNameKey = 'PsAutoTestCertName'
$global:gPsAutoTestADAppUsingSPNKey = 'PsAutoTestADAppUsingSPN'
$global:gkvSecKey_PubSettingFileNameKey = 'NodeCliTestPubSetFile'
$global:gKVKey_ADAppIdKey = "PsAutoTestAppUsingCertAppId"


Function Check-LoggedInContext()
{
    if($gLoggedInCtx -eq $null)
    {
        Write-Error "'$global:gPsAutoTestSubscriptionName' subscription does not exist in the list of available subscriptions. Make sure to have it to run the tests"
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

Function Download-PublishSettingsFileFromKv([string] $localFilePathToDownload)
{
    $dirPath = [System.IO.Path]::GetDirectoryName($localFilePathToDownload)
    $pubFileSecContents = Get-AzureKeyVaultSecret -VaultName $global:gVaultName -Name $global:gkvSecKey_PubSettingFileNameKey
    Log-Info "Ready to download Publishsettings file to '$localFilePathToDownload' from Azure KeyVault"
    
    if([System.IO.Directory]::Exists($dirPath) -eq $true)
    {
        $secretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($pubFileSecContents.SecretValue))	
        [System.IO.File]::WriteAllText($localFilePathToDownload, $secretValueText)
    }
    else
    {
        throw [System.IO.DirectoryNotFoundException] "$dirPath does not exists"
    }
    
    Log-Info "Successfully downloaded Publishsettings file to '$localFilePathToDownload'"
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
}

Function Download-TestCertificateFromKeyVault()
{

    Check-LoggedInContext
    $kvCertSecret = Get-AzureKeyVaultSecret -VaultName $global:gVaultName -Name $global:kvSecKey_PsAutoTestCertNameKey

    #ToDo: Handle the case where access denied to keyVault will result in an attempt to create a new certificate (which will fail again, but needs to be handled)
    #if($kvCertSecret -eq $null)
    #{
    #    Log-Info "Unable to get certificate from Azure KeyVault"
    #    $kvCertSecret = Create-TestAutoCertificateInKv $gVaultName $kvSecKey_PsAutoTestCertNameKey
    #}
    
    #Once we create certificate and get it, we store it locally
    if($kvCertSecret -ne $null)
    {
        $kvSecretValueText = [System.Runtime.InteropServices.marshal]::PtrToStringAuto([System.Runtime.InteropServices.marshal]::SecureStringToBSTR($kvCertSecret.SecretValue))		
        $kvSecretBytes = [System.Convert]::FromBase64String($kvSecretValueText)
        $certCollection2 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
        $certCollection2.Import($kvSecretBytes, $null, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)
        
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

        Log-Info "Successfully downloaded certificate at '$pfxLocalFilePath'"
    }

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

Function Login-AzureRMWithCertificate([bool]$runOnCIMachine=$false)
{
    $appId = $global:gPsAutoTestADAppId
    
    $localCert = Get-LocalCertificate
    if($localCert -eq $null)
    {
        If($runOnCIMachine -eq $false)
        {
            $global:ErrorActionPreference = "SilentlyContinue" #the very first time you install cert, you get an error when you login
            #we could not find certificate installed locally, get it from KeyVault
            Login-InteractivelyAndSelectTestSubscription
            $localCert = Get-AutomationTestCertificate
            #TODO: Handle the case where local certificate is available, but for some reason Service Principal is not available
        }
        else
        {
            throw [System.ApplicationException] "Local Certificate missing on machine and 'runOnCIMachine' is passed as $runOnCIMachine"
        }
    }
    
    $thumbprint = $localCert.Thumbprint
    #Seen cases where for some odd reason, $thumb is being evaluated as object rather than a string, but this does not happen consistently
    $thumbStr = [System.Convert]::ToString($thumbprint.ToString())
        
    #Update the LoggedInCtx    
    $gLoggedInCtx = Connect-AzureRmAccount -ServicePrincipal -CertificateThumbprint $thumbStr -ApplicationId $appId -TenantId $global:gTenantId    
    $global:ErrorActionPreference = "Stop" #setting it back to default option that were set in Test-Setup
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
    Log-Info "Login interactively....."
    $global:gLoggedInCtx = Connect-AzureRmAccount

    Check-LoggedInContext
    Log-Info "Selecting '$global:gPsAutoTestSubscriptionId' subscription"
    $global:gLoggedInCtx = Select-AzureRmSubscription -SubscriptionId $global:gPsAutoTestSubscriptionId

    return $global:gLoggedInCtx
}

Function Login-Azure([bool]$deleteLocalCertificate=$false, [bool]$runOnCIMachine=$false)
{
    try
    {
        Remove-AllSubscriptions

        if($deleteLocalCertificate -eq $true)
        {
            Delete-LocalCertificate
        }

        Login-AzureRMWithCertificate $runOnCIMachine
        Select-AzureRmSubscription -SubscriptionId $global:gPsAutoTestSubscriptionId -TenantId $global:gTenantId

        Login-AzureWithCertificate
        Select-AzureSubscription -SubscriptionId $global:gPsAutoTestSubscriptionId -Current
    }
    finally
    {
        Delete-DownloadedCertAndPubSetting
    }
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

Function Delete-LocalCertificate()
{
    $cert = Get-LocalCertificate
    if($cert -ne $null)
    {
        $certPath = $cert.PSPath
        Log-Info "Deleting local certificate $certPath"
        Remove-Item $cert.PSPath
    }
}

Function Delete-DownloadedCertAndPubSetting
{
    $pfxFilePath = [System.IO.Path]::Combine($global:localPfxDirPath,$global:gPfxLocalFileName)
    if([System.IO.File]::Exists($pfxFilePath) -eq $true)
    {
        #Log-Info "Deleting '$pfxFilePath'"
        Remove-Item $pfxFilePath
    }

    $pubSettingFile = [System.IO.Path]::Combine($PSScriptRoot,$global:gpubSettingLocalFileName)
    if([System.IO.File]::Exists($pubSettingFile) -eq $true)
    {
        #Log-Info "Deleting '$pubSettingFile'"
        Remove-Item $pubSettingFile
    }
}