if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMonitorHealthModelEntityDataAnnotation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorHealthModelEntityDataAnnotation.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMonitorHealthModelEntityDataAnnotation' {
    It 'GetExpanded' {
        {
            Add-AzMonitorHealthModelEntityDataAnnotation -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -EntityName $env.EntityName -Description 'annotation for get' -AnnotationDetail @{ key = 'value' } | Out-Null
            $result = Get-AzMonitorHealthModelEntityDataAnnotation -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -EntityName $env.EntityName -Top 5
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
