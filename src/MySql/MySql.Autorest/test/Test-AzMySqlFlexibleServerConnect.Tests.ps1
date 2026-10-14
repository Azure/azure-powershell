if(($null -eq $TestName) -or ($TestName -contains 'Test-AzMySqlFlexibleServerConnect'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzMySqlFlexibleServerConnect.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$flexibleServerName = 'mysql-flexible-test-400'

Describe 'Test-AzMySqlFlexibleServerConnect' -Tag 'LiveOnly' {
    It 'Create' {
        New-AzMySqlFlexibleServer -Name $flexibleServerName -ResourceGroupName $env.resourceGroup -AdministratorUserName mysql_test -AdministratorLoginPassword ($env.password | ConvertTo-SecureString -AsPlainText -Force) -Location $env.location -SkuTier GeneralPurpose -Sku Standard_D2ads_v5 -PublicAccess All
    }

    It 'Test' {
        {
            Test-AzMySqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $flexibleServerName -AdministratorLoginPassword ($env.password | ConvertTo-SecureString -AsPlainText -Force)
        } | Should -Not -Throw
    }

    It 'TestViaIdentity' {
        {
            $ID = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $flexibleServerName
            Test-AzMySqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword ($env.password | ConvertTo-SecureString -AsPlainText -Force)
        } | Should -Not -Throw
    }

    It 'TestAndQuery' {
        {
            $sql = @"
CREATE DATABASE IF NOT EXISTS mysqldb CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE mysqldb;
CREATE TABLE IF NOT EXISTS simple_table (
  name VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
"@

            Test-AzMySqlFlexibleServerConnect -ResourceGroupName $env.resourceGroup -ServerName $flexibleServerName -AdministratorLoginPassword ($env.password | ConvertTo-SecureString -AsPlainText -Force) -QueryText $sql
        } | Should -Not -Throw
    }

    It 'TestViaIdentityAndQuery' {
        {
            $ID = Get-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $flexibleServerName
            Test-AzMySqlFlexibleServerConnect -InputObject $ID -AdministratorLoginPassword ($env.password | ConvertTo-SecureString -AsPlainText -Force) -QueryText "CREATE TABLE flexibleserverdb.dbtest (col1 INT)"
        } | Should -Not -Throw
    }

    It 'Delete' {
        Remove-AzMySqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $flexibleServerName
    }
}
