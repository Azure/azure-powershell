# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

function Check-SubscriptionLogIn
{
    param (
        [string] $SubscriptionId,
        [string] $AzKVaultName
    )

    Import-Module -Name Az.Accounts

    $azContext = Az.Accounts\Get-AzContext
    if (($azContext -eq $null) -or ($azContext.Subscription.Id -ne $SubscriptionId))
    {
        throw "To use ${AzKVaultName} Azure vault, the current user must be logged into Azure account subscription ${SubscriptionId}. Run 'Connect-AzAccount -SubscriptionId ${SubscriptionId}'."
    }
}

function Get-Secret
{
    param (
        [string] $Name,
        [string] $VaultName,
        [hashtable] $AdditionalParameters
    )

    Check-SubscriptionLogIn $AdditionalParameters.SubscriptionId $AdditionalParameters.AZKVaultName

    Import-Module -Name Az.KeyVault

    $secret = Az.KeyVault\Get-AzKeyVaultSecret -Name $Name -VaultName $AdditionalParameters.AZKVaultName
    if ($secret -ne $null)
    {
        return $secret.SecretValue
    }
}

function Set-Secret
{
    param (
        [string] $Name,
        [object] $Secret,
        [string] $VaultName,
        [hashtable] $AdditionalParameters
    )

    Check-SubscriptionLogIn $AdditionalParameters.SubscriptionId $AdditionalParameters.AZKVaultName

    Import-Module -Name Az.KeyVault

    $null = Az.KeyVault\Set-AzKeyVaultSecret -Name $Name -SecretValue $Secret -VaultName $AdditionalParameters.AZKVaultName
    return $?
}

function Remove-Secret
{
    param (
        [string] $Name,
        [string] $VaultName,
        [hashtable] $AdditionalParameters
    )

    Check-SubscriptionLogIn $AdditionalParameters.SubscriptionId $AdditionalParameters.AZKVaultName

    Import-Module -Name Az.KeyVault

    $null = Az.KeyVault\Remove-AzKeyVaultSecret -Name $Name -VaultName $AdditionalParameters.AZKVaultName -Force
    return $?
}

function Get-SecretInfo
{
    param (
        [string] $Filter,
        [string] $VaultName,
        [hashtable] $AdditionalParameters
    )

    Check-SubscriptionLogIn $AdditionalParameters.SubscriptionId $AdditionalParameters.AZKVaultName

    Import-Module -Name Az.KeyVault

    if ([string]::IsNullOrEmpty($Filter))
    {
        $Filter = "*"
    }

    $pattern = [WildcardPattern]::new($Filter)
    $vaultSecretInfos = Az.KeyVault\Get-AzKeyVaultSecret -VaultName $AdditionalParameters.AZKVaultName
    foreach ($vaultSecretInfo in $vaultSecretInfos)
    {
        if ($pattern.IsMatch($vaultSecretInfo.Name))
        {
            Write-Output (
                [Microsoft.PowerShell.SecretManagement.SecretInformation]::new(
                    $vaultSecretInfo.Name,
                    [Microsoft.PowerShell.SecretManagement.SecretType]::SecureString,
                    $VaultName)
            )
        }
    }
}

function Test-SecretVault
{
    param (
        [string] $VaultName,
        [hashtable] $AdditionalParameters
    )

    try
    {
        Check-SubscriptionLogIn $AdditionalParameters.SubscriptionId $AdditionalParameters.AZKVaultName
    }
    catch
    {
        Write-Error $_
        return $false
    }

    return $true
}
