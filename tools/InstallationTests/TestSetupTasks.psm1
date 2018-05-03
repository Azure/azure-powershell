<#
    TODO:
    This needs to be switched to a script module
#>

# we include ps1 file so that we can reference the variables that are defined at one place
. "$PSScriptRoot\AutoTestLogin.ps1"

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
        $kvCertObj = Get-AzureKeyVaultCertificate -VaultName $global:gVaultName -Name $global:kvSecKey_PsAutoTestCertNameKey
        $localCert = $kvCertObj.Certificate

        $certRawData = $localCert.GetRawCertData()
        $binaryAsciiCertData = [System.Convert]::ToBase64String($certRawData)

        $keyCredential = New-Object  Microsoft.Azure.Commands.Resources.Models.ActiveDirectory.PSADKeyCredential
        $keyCredential.StartDate = $currentDate
        $keyCredential.EndDate= [DateTime]::Parse($localCert.GetExpirationDateString())
        $keyCredential.KeyId = [guid]::NewGuid()
        $keyCredential.CertValue = $binaryAsciiCertData
                        
        #AD app does not exists, create one
        $psAutoADApp = New-AzureRmADApplication -DisplayName $global:gPsAutoTestADAppUsingSPNKey -HomePage $homePage -IdentifierUris $identityUri -KeyCredentials $keyCredential
  
        if($psAutoADApp -eq $null)
        {
            throw [System.ApplicationException] "Unable to create new Azure AD Applicaiton using 'New-AzureRmADApplication'. Exiting......"
        }
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
