if(($null -eq $TestName) -or ($TestName -contains 'Add-AzMonitorHealthModelEntityDataAnnotation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzMonitorHealthModelEntityDataAnnotation.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzMonitorHealthModelEntityDataAnnotation' {
    It 'AddExpanded' {
        {
            $detail = @{ source = 'test'; ticket = 'CH-1001' }
            $result = Add-AzMonitorHealthModelEntityDataAnnotation -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -EntityName $env.EntityName -Description 'annotation created by test' -AnnotationDetail $detail
            $result | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'AddViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Add' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'AddViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
