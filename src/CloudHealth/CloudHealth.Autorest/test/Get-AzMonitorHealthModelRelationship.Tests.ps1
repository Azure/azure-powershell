if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMonitorHealthModelRelationship'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorHealthModelRelationship.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMonitorHealthModelRelationship' {
    It 'List' {
        {
            $result = Get-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName
            $result | Should -Not -BeNullOrEmpty
            @($result | Where-Object Name -eq $env.RelationshipName).Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzMonitorHealthModelRelationship -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.RelationshipName
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.RelationshipName
        } | Should -Not -Throw
    }

    It 'GetViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
