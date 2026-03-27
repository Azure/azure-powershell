if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAppConfigurationReplica'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppConfigurationReplica.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAppConfigurationReplica' {
    BeforeAll {
        $removeReplicaStoreName = $env.removeReplicaStoreName
        New-AzAppConfigurationStore -Name $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Location $env.location -Sku Standard
    }

    AfterAll {
        Remove-AzAppConfigurationStore -Name $removeReplicaStoreName -ResourceGroupName $env.resourceGroup
        if ($TestRecordingFile -and (Test-Path $TestRecordingFile)) {
            $content = Get-Content $TestRecordingFile -Raw
            $sanitized = $content -replace '(?<=Secret=)[^\\"]+', 'SANITIZED' `
                                  -replace '(?<=\\"connectionString\\":\\")(Endpoint=https://[^"\\]+)(?=\\")', 'Endpoint=https://sanitized.azconfig.io;Id=XXXX;Secret=SANITIZED' `
                                  -replace '(?<=\\"value\\":\\")[A-Za-z0-9+/]{20,}=*(?=\\")', 'SANITIZED'
            if ($content -ne $sanitized) {
                Set-Content $TestRecordingFile $sanitized -NoNewline
            }
        }
    }

    It 'Delete' {
        {
            $replicaName = "westusreplica"
            New-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName -Location "westus"
            Remove-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $replicaName = "westus2replica"
            New-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName -Location "westus2"
            $replica = Get-AzAppConfigurationReplica -ConfigStoreName $removeReplicaStoreName -ResourceGroupName $env.resourceGroup -Name $replicaName
            Remove-AzAppConfigurationReplica -InputObject $replica
        } | Should -Not -Throw
    }
}
