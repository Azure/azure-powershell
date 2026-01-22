if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra' {
    It 'List' {
        $admins = Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        # Administrators may or may not be configured, so check if list is returned
        $admins | Should -Not -BeNull
        # If administrators exist, verify their properties
        if ($admins.Count -gt 0) {
            $admins[0].Name | Should -Not -BeNullOrEmpty
            $admins[0].PrincipalName | Should -Not -BeNullOrEmpty
            $admins[0].PrincipalType | Should -BeIn @('User', 'Group', 'ServicePrincipal')
        }
    }

    It 'Get' {
        $admins = Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        if ($admins.Count -gt 0) {
            $firstAdmin = $admins[0]
            $admin = Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -ObjectId $firstAdmin.ObjectId
            $admin | Should -Not -BeNullOrEmpty
            $admin.ObjectId | Should -Be $firstAdmin.ObjectId
            $admin.PrincipalName | Should -Be $firstAdmin.PrincipalName
            $admin.PrincipalType | Should -Be $firstAdmin.PrincipalType
        } else {
            # Skip if no administrators are configured
            Set-ItResult -Skipped -Because "No Microsoft Entra administrators configured on this server"
        }
    }

    It 'GetViaIdentity' {
        $admins = Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
        if ($admins.Count -gt 0) {
            $firstAdmin = $admins[0]
            $adminViaIdentity = Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -InputObject $firstAdmin
            $adminViaIdentity | Should -Not -BeNullOrEmpty
            $adminViaIdentity.ObjectId | Should -Be $firstAdmin.ObjectId
            $adminViaIdentity.PrincipalName | Should -Be $firstAdmin.PrincipalName
        } else {
            Set-ItResult -Skipped -Because "No Microsoft Entra administrators configured on this server"
        }
    }

    It 'GetViaIdentityFlexibleServer' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $admins = Get-AzPostgreSqlFlexibleServerAdministratorsMicrosoftEntra -FlexibleServerInputObject $server
        $admins | Should -Not -BeNull
        # Verify structure even if no admins are configured
        if ($admins.Count -gt 0) {
            $admins[0].PrincipalType | Should -BeIn @('User', 'Group', 'ServicePrincipal')
            $admins[0].ObjectId | Should -Not -BeNullOrEmpty
        }
    }
