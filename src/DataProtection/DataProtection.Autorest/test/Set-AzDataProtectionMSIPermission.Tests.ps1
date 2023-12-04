if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDataProtectionMSIPermission'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDataProtectionMSIPermission.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDataProtectionMSIPermission' {
    It 'DiskGrantPermission' -skip {
        $VaultName = $env.TestGrantPermission.VaultName
        $VaultRG = $env.TestGrantPermission.VaultRG
        $SubscriptionId = $env.TestGrantPermission.SubscriptionId
        $DiskId = $env.TestGrantPermission.DiskId
        $Snapshotrg =$env.TestGrantPermission.Snapshotrg
        $DiskPolicyName = $env.TestGrantPermission.DiskPolicyName
        $Diskrg = $env.TestGrantPermission.Diskrg

        $sub = (Get-AzContext).Subscription.Id
        Set-AzContext -SubscriptionId $SubscriptionId

        $TestBkpVault = Get-AzDataProtectionBackupVault -ResourceGroupName $VaultRG -VaultName $VaultName

        $policyDefn = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
        New-AzDataProtectionBackupPolicy -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -Name $DiskPolicyName -Policy $policyDefn
        $diskBkpPol = Get-AzDataProtectionBackupPolicy -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -Name $DiskPolicyName

        $instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $TestBkpvault.Location -PolicyId $diskBkpPol[0].Id -DatasourceId $DiskId
        $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $Snapshotrg

        #Validation should fail
        try
        {Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -BackupInstance  $instance[0].Property}

        catch
        {
            $err = $_
            $check = $err.Exception.Message.Contains("permissions")
            ($check -eq $true) | Should be $true

            Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup $VaultRG -VaultName $TestBkpVault.Name -PermissionsScope "ResourceGroup"
            #Validation should succeed
            Start-TestSleep -Seconds 30

            $After = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -BackupInstance  $instance[0].Property
            ($After -ne $null) | Should be $true

            Remove-AzRoleAssignment -ObjectId $TestBkpVault.IdentityPrincipalId -RoleDefinitionName "Disk Backup Reader" -Scope $Diskrg

        }
        Set-AzContext -SubscriptionId $sub
    }

    It 'BlobGrantPermission' -skip {
        $VaultName = $env.TestGrantPermission.VaultName
        $VaultRG = $env.TestGrantPermission.VaultRG
        $BlobPolicyName = $env.TestGrantPermission.BlobPolicyName
        $BlobId = $env.TestGrantPermission.BlobId
        $Blobrg = $env.TestGrantPermission.Blobrg
        $SubscriptionId = $env.TestGrantPermission.SubscriptionId

        $sub = (Get-AzContext).Subscription.Id
        Set-AzContext -SubscriptionId $SubscriptionId

        $TestBkpVault = Get-AzDataProtectionBackupVault -ResourceGroupName $VaultRG -VaultName $VaultName

        $policyDefn = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob

        New-AzDataProtectionBackupPolicy -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -Name blobBkpPolicy -Policy $policyDefn
        $blobBkpPol = Get-AzDataProtectionBackupPolicy -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -Name $BlobPolicyName

        $instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureBlob -DatasourceLocation $TestBkpvault.Location -PolicyId $blobBkpPol[0].Id -DatasourceId $BlobId

        #Validation should fail
        try
        {Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -BackupInstance  $instance[0].Property}
        catch
        {
            $err = $_
            $check = $err.Exception.Message.Contains("permissions")
            ($check -eq $true) | Should be $true

            Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup $VaultRG -VaultName $TestBkpVault.Name -PermissionsScope "ResourceGroup"

            Start-TestSleep -Seconds 30
            #Validation should succeed
            $After = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -BackupInstance  $instance[0].Property
            ($After -ne $null) | Should be $true

            Remove-AzRoleAssignment -ObjectId $TestBkpVault.IdentityPrincipalId -RoleDefinitionName "Storage Account Backup Contributor" -Scope $Blobrg

        }
        Set-AzContext -SubscriptionId $sub
    }

    It 'PostgrePermission' -skip {
        $VaultName = $env.TestGrantPermission.VaultName
        $VaultRG = $env.TestGrantPermission.VaultRG
        $OssPolicyName = $env.TestGrantPermission.OssPolicyName
        $ossId = $env.TestGrantPermission.OssId
        $keyURI = $env.TestGrantPermission.KeyURI
        $KeyVaultId = $env.TestGrantPermission.KeyVaultId
        $ossrg = $env.TestGrantPermission.Ossrg

        $SubscriptionId = $env.TestGrantPermission.SubscriptionId
        $sub = (Get-AzContext).Subscription.Id
        Set-AzContext -SubscriptionId $SubscriptionId

        $TestBkpVault = Get-AzDataProtectionBackupVault -ResourceGroupName $VaultRG -VaultName $VaultName

        $policyDefn = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDatabaseForPostgreSQL
        $polOss = New-AzDataProtectionBackupPolicy -ResourceGroupName $VaultRG -VaultName $VaultName -Name $OssPolicyName -Policy $policyDefn

        $instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPostgreSQL -DatasourceLocation $TestBkpvault.Location -PolicyId $polOss[0].Id -DatasourceId $ossId -SecretStoreURI $keyURI -SecretStoreType AzureKeyVault

        #Validation should fail
        try
        {
            Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -BackupInstance  $instance[0].Property
        }

        catch
        {
            $err = $_
            $check = $err.Exception.Message.Contains("permissions")
            ($check -eq $true) | Should be $true

            Set-AzDataProtectionMSIPermission -KeyVaultId $KeyVaultId -BackupInstance $instance -VaultResourceGroup $VaultRG -VaultName $TestBkpVault.Name -PermissionsScope "ResourceGroup" -Confirm:$false

            Start-TestSleep -Seconds 30

            $After = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $VaultRG -VaultName $TestBkpVault.Name -BackupInstance  $instance[0].Property
            ($After -ne $null) | Should be $true

            Remove-AzRoleAssignment -ObjectId $TestBkpVault.IdentityPrincipalId -RoleDefinitionName "Reader" -Scope $ossrg
        }

        Set-AzContext -SubscriptionId $sub
    }

    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
