#########################################################################################
#
# Copyright (c) Microsoft Corporation. All rights reserved.
#
# Licensed under the MIT license.
#
# PSSwaggerUtility Module
#
#########################################################################################
Microsoft.PowerShell.Core\Set-StrictMode -Version Latest
Microsoft.PowerShell.Utility\Import-LocalizedData  LocalizedData -filename PSSwaggerUtility.Resources.psd1

function Get-BasicAuthCredentialInternal {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [PSCredential]
        $Credential
    )
}

function Get-ApiKeyCredentialInternal {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]
        $APIKey,

        [Parameter(Mandatory=$false)]
        [string]
        $Location,

        [Parameter(Mandatory=$false)]
        [string]
        $Name
    )
}

function Get-EmptyAuthCredentialInternal {
    [CmdletBinding()]
    param()
}
