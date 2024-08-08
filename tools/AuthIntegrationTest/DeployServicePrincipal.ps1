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

$subscriptionId = (Get-AzContext).Subscription.Id

$keyVaultName = if ($KeyVaultName) {$KeyVaultName} else {'LiveTestKeyVault'}
$servicePrincipalName = if ($ServicePrincipalName) {$ServicePrincipalName} else {'AzAccountsTest'}
$credentialPrefix = if ($CredentialPrefix) {$CredentialPrefix} else {'AzAccountsTest'}

$certificateName = "${credentialPrefix}Certificate"
$secretName = "${credentialPrefix}Secret"
$federatedName = "${credentialPrefix}OIDC"

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