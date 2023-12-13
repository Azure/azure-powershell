[CmdletBinding()]
param (
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
    [string]
    $TenantId,

    [Parameter()]
    [Switch]
    $ClearContext
)

Write-Host "ParameterSet = $($PSCmdlet.ParameterSetName)"

$keyVaultName = if ($KeyVaultName) {$KeyVaultName} else {'LiveTestKeyVault'}
$servicePrincipalName = if ($ServicePrincipalName) {$ServicePrincipalName} else {'AzurePowerShellAzAccountsTest'}
$credentialPrefix = if ($CredentialPrefix) {$CredentialPrefix} else {'AzAccountsTest'}
$tenantId = if ($TenantId) {$TenantId} else {'54826b22-38d6-4fb2-bad9-b7b93a3e9c5a'}

$certificateName = "${credentialPrefix}Certificate"
$secretName = "${credentialPrefix}Secret"
$password = 'pa88w0rd!'

$null = Set-AzContext -TenantId $tenantId
$module = Get-Module -Name "CertificateUtility"
if ($module -eq $null)
{
    Import-Module "$PSScriptRoot/CertificateUtility.psm1"
}

if ($Path -and $PfxFileName) {
    $paramsCertificate = @{
        KeyVaultName      = $keyVaultName;
        CertificateName   = $certificateName;
        CertPlainPassword = $password;
        Path              = $Path
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
    if ($ClearContext.IsPresent) {
        Clear-AzContext -Force
    }
    $azureProfile = Connect-AzAccount -ServicePrincipal @params
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
    if ($ClearContext.IsPresent) {
        Clear-AzContext -Force
    }
    $azureProfile = Connect-AzAccount -ServicePrincipal @params
}
elseif ($PSCmdlet.ParameterSetName -eq 'Password') {
    $secret = Get-AzKeyVaultSecret -VaultName $keyVaultName -Name $secretName
    $credential = New-Object -TypeName 'System.Management.Automation.PSCredential' -ArgumentList $appId, $secret.SecretValue
    if ($ClearContext.IsPresent) {
        Clear-AzContext -Force
    }
    $azureProfile = Connect-AzAccount -ServicePrincipal -TenantId $tenantId -Credential $credential
}
elseif ($PSCmdlet.ParameterSetName -eq 'FederatedToken') {
    $params['FederatedToken'] = $FederatedToken
    if ($ClearContext.IsPresent) {
        Clear-AzContext -Force
    }
    Write-Host 'Press any key to continue'
    $void = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    $azureProfile = Connect-AzAccount -ServicePrincipal @params
}

$azureProfile | Format-Table

Get-AzAccessToken
