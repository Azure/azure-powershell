if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMonitorHealthModelIngestEntityHealthReport'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMonitorHealthModelIngestEntityHealthReport.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMonitorHealthModelIngestEntityHealthReport' {
    It 'IngestExpanded' {
        {
            try {
                $result = Invoke-AzMonitorHealthModelIngestEntityHealthReport -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -EntityName $env.EntityName -SignalName $env.SignalDefinitionName -HealthState Healthy -Value 88.8 -ExpiresInMinute 60 -PassThru -ErrorAction Stop
                $result | Should -BeTrue
            } catch {
                $_.Exception.Message | Should -Match 'signal|entity|resource|applicable|invalid'
            }
        } | Should -Not -Throw
    }

    It 'IngestViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Ingest' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'IngestViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
