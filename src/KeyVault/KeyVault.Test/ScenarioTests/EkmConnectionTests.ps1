<#
.SYNOPSIS
Scenario tests for the External Key Manager (EKM) connection on a Managed HSM and
for EKM-backed external keys (Preview).

These tests require a pre-provisioned Managed HSM that is wired to a reachable EKM
proxy. They are LiveOnly. Before recording, set the variables below to match the
target environment (for example the INT test HSM provisioned by the Key Vault HSM
team). After recording, sanitize the endpoint and tenant in the generated
SessionRecords/*.json before committing.

Required setup before Record:
 - $hsmName            : name of an existing Managed HSM the caller can administer
 - $ekmHost            : EKM proxy host (FQDN or FQDN:port)
 - $serverCaCertPath   : path to the EKM proxy CA certificate (PEM or DER)
 - $externalKeyId      : an existing key id in the external key manager
#>

function Get-EkmTestSettings {
	return @{
		HsmName          = $env:EKM_TEST_HSM_NAME
		EkmHost          = $env:EKM_TEST_HOST
		ServerCaCertPath = $env:EKM_TEST_CA_CERT
		ExternalKeyId    = $env:EKM_TEST_EXTERNAL_KEY_ID
	}
}

function Test-EkmConnectionLifecycle {
	$s = Get-EkmTestSettings
	$hsmName = $s.HsmName

	try {
		# Create the EKM connection.
		$created = New-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -HostName $s.EkmHost `
			-ServerCaCertificate $s.ServerCaCertPath -PathPrefix "/api/v1"
		Assert-NotNull $created "New-AzKeyVaultManagedHsmEkmConnection returned null"
		Assert-AreEqual $hsmName $created.HsmName "HSM name mismatch on create"
		Assert-NotNull $created.Host "created connection host is null"

		# Read it back.
		$got = Get-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName
		Assert-NotNull $got "Get-AzKeyVaultManagedHsmEkmConnection returned null"
		Assert-AreEqual $created.Host $got.Host "round-tripped host mismatch"
		Assert-AreEqual "/api/v1" $got.PathPrefix "round-tripped path prefix mismatch"

		# Probe connectivity / authentication.
		$probe = Test-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName
		Assert-NotNull $probe "Test-AzKeyVaultManagedHsmEkmConnection returned null"

		# Read the EKM proxy client certificate.
		$cert = Get-AzKeyVaultManagedHsmEkmConnectionCertificate -HsmName $hsmName
		Assert-NotNull $cert "Get-AzKeyVaultManagedHsmEkmConnectionCertificate returned null"

		# Update the path prefix.
		$updated = Update-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -PathPrefix "/api/v2"
		Assert-AreEqual "/api/v2" $updated.PathPrefix "updated path prefix mismatch"
	}
	finally {
		# Remove the connection.
		Remove-AzKeyVaultManagedHsmEkmConnection -HsmName $hsmName -Force -ErrorAction SilentlyContinue
	}
}

function Test-CreateExternalKey {
	$s = Get-EkmTestSettings
	$hsmName = $s.HsmName
	$keyName = (GetAssetName)

	try {
		# Create an EKM-backed external key. The service rejects client-specified
		# key type/size/curve for external keys, so only -Name and -ExternalKeyId
		# are supplied.
		$key = Add-AzKeyVaultKey -HsmName $hsmName -Name $keyName -ExternalKeyId $s.ExternalKeyId
		Assert-NotNull $key "Add-AzKeyVaultKey -ExternalKeyId returned null"
		Assert-AreEqual $keyName $key.Name "external key name mismatch"
		Assert-AreEqual $s.ExternalKeyId $key.ExternalKeyId "external key id mismatch"

		# The key must be retrievable.
		$got = Get-AzKeyVaultKey -HsmName $hsmName -Name $keyName
		Assert-NotNull $got "Get-AzKeyVaultKey returned null for external key"
	}
	finally {
		Remove-AzKeyVaultKey -HsmName $hsmName -Name $keyName -Force -ErrorAction SilentlyContinue
	}
}
