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
param (
    [Parameter(Mandatory = $true)]
    [string]
    $TenantId,

    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [Switch]
    $UseCertificateFile,

    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [Switch]
    $UseThumbprint,

    [Parameter(ParameterSetName = 'Password', Mandatory = $true)]
    [Switch]
    $UsePassword,

    [Parameter(ParameterSetName = 'FederatedToken', Mandatory = $true)]
    [Switch]
    $UseFederatedToken,

    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [string]
    $Path,

    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [string]
    $PfxFileName,

    [Parameter(ParameterSetName = 'FederatedToken', Mandatory = $true)]
    [string]
    $FederatedToken,

    [Parameter()]
    [string]
    $KeyVaultName,

    [Parameter()]
    [string]
    $ServicePrincipalName,

    [Parameter()]
    [string]
    $CredentialPrefix,

    [Parameter()]
    [Switch]
    $ClearContext
)

Write-Host "ServicePrincipalAuthFlow: ParameterSet = $($PSCmdlet.ParameterSetName)"

$keyVaultName = if ($KeyVaultName) {$KeyVaultName} else {'LiveTestKeyVault'}
$servicePrincipalName = if ($ServicePrincipalName) {$ServicePrincipalName} else {'AzurePowerShellAzAccountsTest'}
$credentialPrefix = if ($CredentialPrefix) {$CredentialPrefix} else {'AzAccountsTest'}

$certificateName = "${credentialPrefix}Certificate"
$secretName = "${credentialPrefix}Secret"
$password = 'pa88w0rd!'

$null = Set-AzContext -TenantId $tenantId
$module = Get-Module -Name "CertificateUtility"
if ($null -eq $module)
{
    Import-Module "$PSScriptRoot/CertificateUtility.psm1"
}

if ($Path -and $PfxFileName) {
    $paramsCertificate = @{
        KeyVaultName      = $keyVaultName;
        CertificateName   = $certificateName;
        CertPlainPassword = $password;
        Path              = Convert-Path $Path
        PfxFileName       = $PfxFileName
    }
    $pfxFile = Get-CertificateFromKeyVault @paramsCertificate
}

$appId = (Get-AzADServicePrincipal -DisplayName $servicePrincipalName).AppId
$params = @{
    TenantId      = $tenantId;
    ApplicationId = $appId;
}

$azureProfile = $null
if ($PSCmdlet.ParameterSetName -eq 'CertificateFile') {
    $params['CertificatePath'] = $pfxFile
    $params['CertificatePassword'] = (ConvertTo-SecureString -String $password -AsPlainText -Force)
}
elseif ($PSCmdlet.ParameterSetName -eq 'Thumbprint') {
    if ($PSVersionTable.PSEdition -ne "Desktop" -and -not $IsWindows) {
        throw "NonWin System doesn't support Thumbprint Login currently."
    }
    $paramsImport = @{
        FilePath          = $pfxFile
        CertStoreLocation = 'Cert:\CurrentUser\My'
        Password          = (ConvertTo-SecureString -String $password -AsPlainText -Force)
    }
    $null = Import-PfxCertificate @paramsImport

    $pfxCert = New-Object `
        -TypeName 'System.Security.Cryptography.X509Certificates.X509Certificate2' `
        -ArgumentList @($pfxFile, $password)
    $thumbprint = $pfxCert.Thumbprint
    $params['CertificateThumbprint'] = $thumbprint
}
elseif ($PSCmdlet.ParameterSetName -eq 'Password') {
    $secret = Get-AzKeyVaultSecret -VaultName $keyVaultName -Name $secretName
    $credential = New-Object -TypeName 'System.Management.Automation.PSCredential' -ArgumentList $appId, $secret.SecretValue
    $params['Credential'] = $credential
    $null = $params.Remove('ApplicationId')
}
elseif ($PSCmdlet.ParameterSetName -eq 'FederatedToken') {
    $params['FederatedToken'] = $FederatedToken
    #Write-Host 'Press any key to continue'
    #$void = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

#($env:PSModulePath -Split ":") | Get-ChildItem |  Where-Object {$_.FullName.EndsWith('Az.Accounts') } | Get-ChildItem

if ($ClearContext.IsPresent) {
    Clear-AzContext -Verbose -Force
}
$azureProfile = Connect-AzAccount -ServicePrincipal @params
Write-Output $azureProfile