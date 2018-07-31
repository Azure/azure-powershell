<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Generate encryption key for infrastructure backups.

.DESCRIPTION
    Generate encryption key for infrastructure backups.

.EXAMPLE

    PS C:\>New-EncryptionKeyBase64

    Generate encryption key for infrastructure backups.

#>
function New-AzsEncryptionKeyBase64
{
    $tempEncryptionKeyString = ""
    foreach($i in 1..64) { $tempEncryptionKeyString += -join ((65..90) + (97..122) | Get-Random | % {[char]$_}) }
    $tempEncryptionKeyBytes = [System.Text.Encoding]::UTF8.GetBytes($tempEncryptionKeyString)
    $BackupEncryptionKeyBase64 = [System.Convert]::ToBase64String($tempEncryptionKeyBytes)
    return $BackupEncryptionKeyBase64
}
