
[CmdletBinding()]
Param
(
    [Parameter(Mandatory = $true)]
    [string]
    $Path,

    [Parameter(Mandatory = $true)]
    [string]
    $PfxFileName,

    [Parameter()]
    [string]
    $KeyVaultName,

    [Parameter()]
    [string]
    $ServicePrincipalName,

    [Parameter()]
    [string]
    $CredentialPrefix
)

#$tenantId = '54826b22-38d6-4fb2-bad9-b7b93a3e9c5a';
#$subscriptionId = '0b1f6471-1bf0-4dda-aec3-cb9272f09590'
$subscriptionId = (Get-AzContext).Subscription.Id

$keyVaultName = if ($KeyVaultName) {$KeyVaultName} else {'LiveTestKeyVault'}
$servicePrincipalName = if ($ServicePrincipalName) {$ServicePrincipalName} else {'AzurePowerShellAzAccountsTest'}
$credentialPrefix = if ($CredentialPrefix) {$CredentialPrefix} else {'AzAccountsTest'}

$certificateName = "${credentialPrefix}Certificate"
$secretName = "${credentialPrefix}Secret"
$federatedName = "${credentialPrefix}ADFS"

$password = 'pa88w0rd!'
$subject = 'CN=AzAccountsTest'

Import-Module "$PSScriptRoot/CertificateUtility.psm1"

New-CertificateFromKeyVault -KeyVaultName $keyVaultName -CertificateName $certificateName -SubjectName $subject

$params = @{
    KeyVaultName = $keyVaultName;
    CertificateName = $certificateName;
    CertPlainPassword = $password;
    Path = $Path;
    PfxFileName = $PfxFileName;
}
$pfxFile = Get-CertificateFromKeyVault @params

$sp = New-AzADServicePrincipal -DisplayName $servicePrincipalName
$app = Get-AzADApplication -ApplicationId $sp.AppId

$roleName = "Contributor"
$scope = "/subscriptions/$subscriptionId"
try {
    $spRoleAssg = Get-AzRoleAssignment -ObjectId $app.Id -Scope $scope -RoleDefinitionName $roleName -ErrorAction 'Stop'
    if ($null -eq $spRoleAssg) {
        New-AzRoleAssignment -ApplicationId $sp.AppId -RoleDefinitionName $roleName -Scope $scope -ErrorAction Stop
    }
}
catch {
    throw "Exception occurred when retrieving the role assignment for service principal with error message $($_.Exception.Message)."
}

Set-AzKeyVaultAccessPolicy -VaultName $keyVaultName -ServicePrincipalName $sp.AppId  -PermissionsToSecrets @('Get','List') -PermissionsToKeys @('Get','List') -PermissionsToCertificates @('Get', 'List')

$pfxCert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($pfxFile, $password)
$keyValue = [System.Convert]::ToBase64String($pfxCert.GetRawCertData())

New-AzADAppCredential -ObjectId $app.Id -CertValue $keyValue -StartDate $pfxCert.NotBefore -EndDate $pfxCert.NotAfter
New-AzADAppFederatedCredential -ApplicationObjectId $app.Id `
                               -Name $federatedName `
                               -Audience 'api://AzureADTokenExchange' `
                               -Issuer 'https://token.actions.githubusercontent.com' `
                               -Subject 'repo:Azure/azclitools-actions-test:ref:refs/heads/main'

$secretParams = @{
    VaultName = $keyVaultName;
    Name = $secretName;
    SecretValue = (ConvertTo-SecureString $sp.PasswordCredentials.SecretText -AsPlainText -Force);
    NotBefore = $sp.PasswordCredentials.StartDateTime;
    Expires = $sp.PasswordCredentials.EndDateTime;
}
Set-AzKeyVaultSecret @secretParams

$appInfo = @{
    ObjectId             = $app.Id;
    AppId          = $app.AppId;
    AppDisplayName = $app.DisplayName;
    Password       = $sp.PasswordCredentials.SecretText;
}
Write-Output $appInfo