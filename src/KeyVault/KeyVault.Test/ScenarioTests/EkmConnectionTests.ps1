function Get-EkmTestConnectionOrNull {
    param([string] $HsmName)

    try {
        Get-AzKeyVaultManagedHsmEkmConnection -HsmName $HsmName -ErrorAction Stop
    }
    catch [Azure.RequestFailedException] {
        if ($_.Exception.Status -ne 404) { throw }
    }
}

function Get-EkmTestEndpointOrNull {
    param([string] $HsmName, [string] $Name)

    try {
        Get-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $HsmName -Name $Name -ErrorAction Stop
    }
    catch [Azure.RequestFailedException] {
        if ($_.Exception.Status -ne 404) { throw }
    }
}

function Test-EkmConnectionLifecycle {
    if ($env:AZURE_KEYVAULT_EKM_LIVE_TESTS -ne '1' -or $env:EKM_TEST_ALLOW_CONNECTION_CHANGES -ne '1') {
        throw 'Connection lifecycle requires explicit opt-in and a dedicated, initially unconfigured HSM.'
    }
    $hsmName = $env:EKM_TEST_HSM_NAME
    if (Get-EkmTestConnectionOrNull -HsmName $hsmName) {
        throw 'Refusing to replace an existing EKM connection. Use a dedicated, initially unconfigured test HSM.'
    }
    $submitted = $false
    try {
        $submitted = $true
        $created = New-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -HostName $env:EKM_TEST_HOST `
            -ServerCaCertificate ($env:EKM_TEST_CA_CERT -split ';') -PathPrefix '/api/v1' -Confirm:$false -ErrorAction Stop
        Assert-NotNull $created
        $connection = Get-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -ErrorAction Stop
        Assert-AreEqual $created.Host $connection.Host
        Assert-AreEqual '/api/v1' $connection.PathPrefix
        foreach ($certificate in $connection.ServerCaCertificates) {
            Assert-True ($certificate -is [string])
            Assert-True ([Convert]::FromBase64String($certificate).Length -gt 0)
        }
        Assert-NotNull (Test-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -ErrorAction Stop)
        Assert-NotNull (Get-AzKeyVaultManagedHsmEkmConnectionCertificate -HsmName $hsmName -ErrorAction Stop)
        $updated = Update-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName `
            -ServerSubjectCommonName $env:EKM_TEST_SERVER_CN -Confirm:$false -ErrorAction Stop
        Assert-AreEqual $env:EKM_TEST_SERVER_CN $updated.ServerSubjectCommonName
        Assert-AreEqual $connection.Host $updated.Host
        Assert-AreEqual $connection.PathPrefix $updated.PathPrefix
        Assert-AreEqual ($connection.ServerCaCertificates -join ',') ($updated.ServerCaCertificates -join ',')
        Assert-NotNull (Test-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -ErrorAction Stop)
    }
    finally {
        if ($submitted -and (Get-EkmTestConnectionOrNull -HsmName $hsmName)) {
            Remove-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -Confirm:$false -ErrorAction Stop
            $deadline = [DateTime]::UtcNow.AddMinutes(5)
            while (Get-EkmTestConnectionOrNull -HsmName $hsmName) {
                if ([DateTime]::UtcNow -ge $deadline) { throw 'Timed out cleaning up the dedicated test connection.' }
                Start-Sleep -Seconds 2
            }
        }
    }
}

function Test-EkmPrivateEndpointLifecycle {
    if ($env:AZURE_KEYVAULT_EKM_LIVE_TESTS -ne '1') { throw 'Private endpoint lifecycle requires explicit live-test opt-in.' }
    $hsmName = $env:EKM_TEST_HSM_NAME
    $name = 'ps-ekm-' + [Guid]::NewGuid().ToString('N').Substring(0, 12)
    $baseline = Get-EkmTestConnectionOrNull -HsmName $hsmName | ConvertTo-Json -Depth 10 -Compress
    if (Get-EkmTestEndpointOrNull -HsmName $hsmName -Name $name) { throw 'Temporary endpoint name already exists.' }
    $submitted = $false
    try {
        $submitted = $true
        $operation = New-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $hsmName -Name $name `
            -PrivateLinkServiceAlias $env:EKM_TEST_PLS_ALIAS -RequestMessage 'Azure PowerShell temporary EKM scenario test' `
            -Confirm:$false -ErrorAction Stop
        Assert-AreEqual 'Succeeded' $operation.Status
        Assert-NotNull $operation.JobId
        $status = Get-AzKeyVaultManagedHsmEkmPrivateEndpointOperation -HsmName $hsmName -JobId $operation.JobId -ErrorAction Stop
        Assert-AreEqual $operation.JobId $status.JobId
        $endpoint = Get-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $hsmName -Name $name -ErrorAction Stop
        Assert-AreEqual $name $endpoint.Name
        $listed = @(Get-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $hsmName -ErrorAction Stop)
        Assert-True ($listed.Name -contains $name)
        $ready = Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $hsmName -Name $name -TimeoutSeconds 600 -IntervalSeconds 2 -ErrorAction Stop
        Assert-AreEqual 'Succeeded' $ready.ProvisioningState
    }
    finally {
        if ($submitted -and (Get-EkmTestEndpointOrNull -HsmName $hsmName -Name $name)) {
            Remove-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $hsmName -Name $name -NoWait -Confirm:$false -ErrorAction Stop
            Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName $hsmName -Name $name -Deleted -TimeoutSeconds 600 -IntervalSeconds 2 -ErrorAction Stop
        }
        $after = Get-EkmTestConnectionOrNull -HsmName $hsmName | ConvertTo-Json -Depth 10 -Compress
        Assert-AreEqual $baseline $after
    }
}

function Test-CreateExternalKey {
    if ($env:AZURE_KEYVAULT_EKM_LIVE_TESTS -ne '1' -or $env:EKM_TEST_ALLOW_KEY_CHANGES -ne '1') {
        throw 'External key lifecycle requires explicit authorization on a preconfigured test HSM.'
    }
    $hsmName = $env:EKM_TEST_KEY_HSM_NAME
    if (-not (Get-EkmTestConnectionOrNull -HsmName $hsmName)) { throw 'External key test requires a configured EKM connection.' }
    $keyName = 'ps-ekm-key-' + [Guid]::NewGuid().ToString('N').Substring(0, 12)
    $created = $false
    try {
        $key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -ExternalKeyId $env:EKM_TEST_EXTERNAL_KEY_ID -ErrorAction Stop
        $created = $true
        Assert-AreEqual $env:EKM_TEST_EXTERNAL_KEY_ID $key.ExternalKeyId
        $retrieved = Get-AzKeyVaultKey -HsmName $hsmName -Name $keyName -ErrorAction Stop
        Assert-AreEqual $key.ExternalKeyId $retrieved.ExternalKeyId
        $plainKey = [byte[]](1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
        $algorithm = if ($env:EKM_TEST_WRAP_ALGORITHM) { $env:EKM_TEST_WRAP_ALGORITHM } else { 'A256KW' }
        $wrapped = Invoke-AzKeyVaultKeyOperation -HsmName $hsmName -Name $keyName -Operation Wrap `
            -Algorithm $algorithm -ByteArrayValue $plainKey -Confirm:$false -ErrorAction Stop
        Assert-True ($wrapped.RawResult.Length -gt 0)
        $unwrapped = Invoke-AzKeyVaultKeyOperation -HsmName $hsmName -Name $keyName -Operation Unwrap `
            -Algorithm $algorithm -ByteArrayValue $wrapped.RawResult -Confirm:$false -ErrorAction Stop
        Assert-AreEqual ([Convert]::ToBase64String($plainKey)) ([Convert]::ToBase64String($unwrapped.RawResult))
    }
    finally {
        if ($created) { Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force -ErrorAction Stop }
    }
}