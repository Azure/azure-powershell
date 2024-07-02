if(($null -eq $TestName) -or ($TestName -contains 'AzExaInfra'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzExaInfra.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzExaInfra' {
    It 'CreateExaInfra' {
        {
            $exaInfra = New-AzOracleDatabaseCloudExadataInfrastructure -Name $env.exaInfraName -ResourceGroupName $env.resourceGroup -Location $env.location -Zone $env.zone -Shape $env.exaInfraShape -ComputeCount $env.exaInfraComputeCount -StorageCount $env.exaInfraStorageCount -DisplayName $env.exaInfraName
            $exaInfra.Name | Should -Be $env.exaInfraName
        } | Should -Not -Throw
    }
    It 'GetExaInfra' {
        {
            $exaInfra = Get-AzOracleDatabaseCloudExadataInfrastructure -Name $env.exaInfraName -ResourceGroupName $env.resourceGroup
            $exaInfra.Name | Should -Be $env.exaInfraName
        } | Should -Not -Throw
    }
    It 'ListExaInfras' {
        {
            $exaInfraList = Get-AzOracleDatabaseCloudExadataInfrastructure
            $exaInfraList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    It 'DeleteExaInfra' {
        {
            Remove-AzOracleDatabaseCloudExadataInfrastructure -NoWait -Name $env.exaInfraName -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
