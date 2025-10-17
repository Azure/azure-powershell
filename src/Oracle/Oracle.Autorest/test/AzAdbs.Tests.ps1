if(($null -eq $TestName) -or ($TestName -contains 'AzAdbs'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzAdbs.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzAdbs' {
    It 'CreateAdbs' {
        {
            [SecureString]$adbsAdminPassword = ConvertTo-SecureString -String "PowerShellTestPass123" -AsPlainText -Force
            $adbs = New-AzOracleAutonomousDatabase -Name $env.adbsName -ResourceGroupName $env.resourceGroup -Location $env.location -DisplayName $env.adbsName -DbWorkload $env.adbsDbWorkload -ComputeCount $env.adbsComputeCount -ComputeModel $env.adbsComputeModel -DbVersion $env.adbsDbVersion -DataStorageSizeInGb $env.adbsDataStorageInGb -AdminPassword $adbsAdminPassword -LicenseModel $env.adbsLicenseModel -SubnetId $env.subnetId -VnetId $env.vnetId -DataBaseType $env.adbsDatabaseType -CharacterSet $env.adbsCharacterSet -NcharacterSet $env.adbsNCharacterSet
            $adbs.Name | Should -Be $env.adbsName
        } | Should -Not -Throw
    }
    It 'GetAdbs' {
        {
            $adbs = Get-AzOracleAutonomousDatabase -Name $env.adbsName -ResourceGroupName $env.resourceGroup
            $adbs.Name | Should -Be $env.adbsName
        } | Should -Not -Throw
    }
    It 'ListAdbs' {
        {
            $adbsList = Get-AzOracleAutonomousDatabase
            $adbsList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    It 'UpdateAdbs' {
        {
            $tagHashTable = @{'tagName'="tagValue"}
            Update-AzOracleAutonomousDatabase -Name $env.adbsName -ResourceGroupName $env.resourceGroup -Tag $tagHashTable
            $adbs = Get-AzOracleAutonomousDatabase -Name $env.adbsName -ResourceGroupName $env.resourceGroup
            $adbs.Tag.Get_Item("tagName") | Should -Be "tagValue"
        } | Should -Not -Throw
    }
    It 'DeleteAdbs' {
        {
            Remove-AzOracleAutonomousDatabase -NoWait -Name $env.adbsName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
