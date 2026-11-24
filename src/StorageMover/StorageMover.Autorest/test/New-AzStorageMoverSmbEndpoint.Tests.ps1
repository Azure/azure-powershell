if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverSmbEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverSmbEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New/Update-AzStorageMoverSmbEndpoint' {
    It 'Create and update' {
        $endpointName = "testsmbendpoint1" + $env.RandomString
        $shareName = "shareName" + $env.RandomString
        $smbendpoint = New-AzStorageMoverSmbEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Host "10.0.0.1" -ShareName $shareName  -CredentialsUsernameUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username" -CredentialsPasswordUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password" -Description "new smb endpoint"
        $smbendpoint.Name | Should -Be $endpointName
        $smbendpoint.Property.CredentialsType | Should -Be "AzureKeyVaultSmb"
        $smbendpoint.Property.CredentialsPasswordUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password"
        $smbendpoint.Property.CredentialsUsernameUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username"
        $smbendpoint.Property.EndpointType | Should -Be "SmbMount"
        $smbendpoint.Property.ShareName | Should -Be $shareName
        $smbendpoint.Property.Description | Should -Be "new smb endpoint"

        $smbendpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $smbendpoint.Name | Should -Be $endpointName
        $smbendpoint.Property.CredentialsType | Should -Be "AzureKeyVaultSmb"
        $smbendpoint.Property.CredentialsPasswordUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password"
        $smbendpoint.Property.CredentialsUsernameUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username"
        $smbendpoint.Property.EndpointType | Should -Be "SmbMount"
        $smbendpoint.Property.ShareName | Should -Be $shareName
        $smbendpoint.Property.Description | Should -Be "new smb endpoint"

        $smbendpoint = Update-AzStorageMoverSmbEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -CredentialsUsernameUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username1" -CredentialsPasswordUri "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password1" -Description "update smb endpoint"
        $smbendpoint.Name | Should -Be $endpointName
        $smbendpoint.Property.CredentialsType | Should -Be "AzureKeyVaultSmb"
        $smbendpoint.Property.CredentialsPasswordUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password1"
        $smbendpoint.Property.CredentialsUsernameUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username1"
        $smbendpoint.Property.EndpointType | Should -Be "SmbMount"
        $smbendpoint.Property.ShareName | Should -Be $shareName
        $smbendpoint.Property.Description | Should -Be "update smb endpoint"

        $smbendpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $smbendpoint.Name | Should -Be $endpointName
        $smbendpoint.Property.CredentialsType | Should -Be "AzureKeyVaultSmb"
        $smbendpoint.Property.CredentialsPasswordUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-password1"
        $smbendpoint.Property.CredentialsUsernameUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/examples-username1"
        $smbendpoint.Property.EndpointType | Should -Be "SmbMount"
        $smbendpoint.Property.ShareName | Should -Be $shareName
        $smbendpoint.Property.Description | Should -Be "update smb endpoint"

        $smbendpoint = Update-AzStorageMoverSmbEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -CredentialsUsernameUri "" -CredentialsPasswordUri ""
        $smbendpoint.Name | Should -Be $endpointName
        $smbendpoint.Property.CredentialsType | Should -Be "AzureKeyVaultSmb"
        $smbendpoint.Property.CredentialsPasswordUri | Should -Be ""
        $smbendpoint.Property.CredentialsUsernameUri | Should -Be ""
        $smbendpoint.Property.EndpointType | Should -Be "SmbMount"
        $smbendpoint.Property.ShareName | Should -Be $shareName
        $smbendpoint.Property.Description | Should -Be "update smb endpoint"
    }

    It 'CreateExpandedFsxSmb' {
        $endpointName = "smbfsx"
        $smbEndpoint = New-AzStorageMoverSmbEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -Host "10.0.0.6" -ShareName "share" -SourceType FSX-SMB -EndpointKind Source
        $smbEndpoint.Property.EndpointType | Should -Be "SmbMount"
        $smbEndpoint.Property.EndpointKind | Should -Be "Source"

        $smbEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName
        $smbEndpoint.Property.ProvisioningState | Should -Be "Succeeded"
    }

}

Describe 'New-AzStorageMoverSmbEndpoint RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'CreateExpandedSourceTypeRequest' {
        $capture = Invoke-StorageMoverTestRequest -Response @{ properties = @{ endpointType = 'SmbMount' } } -Command {
            param($pipeline)
            New-AzStorageMoverSmbEndpoint -Name 'smbfsxo' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -Host '10.0.0.6' -ShareName 'share' -SourceType FSX-SMB -CredentialsUsernameUri 'https://examples-azureKeyVault.vault.azure.net/secrets/username' -CredentialsPasswordUri 'https://examples-azureKeyVault.vault.azure.net/secrets/password' -HttpPipelinePrepend $pipeline
        }
        $capture.Requests[0].Method | Should -Be 'PUT'
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.sourceType | Should -Be "FSX-SMB"
        $request.credentials.usernameUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/username"
        $request.credentials.passwordUri | Should -Be "https://examples-azureKeyVault.vault.azure.net/secrets/password"
    }
}

Describe 'New-AzStorageMoverSmbEndpoint PythonParity' -Tag 'PythonParity' {
    It 'RejectTargetEndpointKind' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-smb-target-validation'
            Invoke-StorageMoverTestFailure -Command {
                New-AzStorageMoverSmbEndpoint @context -Name 'invalid' -Host '10.0.0.1' -ShareName 'testshare' -EndpointKind Target -ErrorAction Stop
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}
