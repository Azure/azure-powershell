if(($null -eq $TestName) -or ($TestName -contains 'Start-AzServiceBusMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzServiceBusMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzServiceBusMigration' {
    It 'CreateExpanded' -skip:$($env.secondaryLocation -eq '') {
        $migrationConfig = Start-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace -PostMigrationName $env.postMigrationName -TargetNamespace $env.migrationSecondaryNamespaceResourceId
        $migrationConfig.Name | Should -Be $env.migrationPrimaryNamespace
        $migrationConfig.PostMigrationName | Should -Be $env.postMigrationName
        $migrationConfig.TargetNamespace | Should -Be $env.migrationSecondaryNamespaceResourceId

        do {
            $migrationConfig = Get-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace
            Start-Sleep 10
        } while($migrationConfig.ProvisioningState -ne 'Succeeded')

        Stop-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace

        do {
            $migrationConfig = Get-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace
            Start-Sleep 10
        } while($migrationConfig.ProvisioningState -ne 'Succeeded')

        $migrationConfig.TargetNamespace | Should -Be ""

        { Remove-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace -ErrorAction Stop } | Should -Throw
    
        $migrationConfig = Start-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace -PostMigrationName $env.postMigrationName -TargetNamespace $env.migrationSecondaryNamespaceResourceId
        $migrationConfig.Name | Should -Be $env.migrationPrimaryNamespace
        $migrationConfig.PostMigrationName | Should -Be $env.postMigrationName
        $migrationConfig.TargetNamespace | Should -Be $env.migrationSecondaryNamespaceResourceId

        do {
            $migrationConfig = Get-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace
            Start-Sleep 10
        } while($migrationConfig.ProvisioningState -ne 'Succeeded')

        Complete-AzServiceBusMigration -ResourceGroupName $env.resourceGroup -NamespaceName $env.migrationPrimaryNamespace
        
        Start-Sleep 240

        $drConfig = Get-AzServiceBusGeoDRConfiguration -ResourceGroupName $env.resourceGroup -Name $env.migrationPrimaryNamespace -NamespaceName $env.migrationSecondaryNamespace
        $drConfig.Name | Should -Be $env.migrationPrimaryNamespace
        $drConfig.ResourceGroupName | Should -Be $env.resourceGroup
        $drConfig.PartnerNamespace | Should -Be ""
        $drConfig.Role | Should -Be "PrimaryNotReplicating"
    
    }
}
