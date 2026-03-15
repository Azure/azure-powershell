if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzConfluentConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConfluentConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzConfluentConnector' {
    It 'Delete' {
        {    
            try {
                Remove-AzConfluentConnector -Name $env.connectorName -ResourceGroupName $env.connectorResourceGroup -OrganizationName $env.connectorOrganization -EnvironmentId $env.connectorEnvironmentId -ClusterId $env.connectorClusterId -SubscriptionId $env.SubscriptionId
            }
            catch {
                if ($_.Exception.Message -match "HttpClient.Timeout") {
                    Write-Host "Received 'Timeout' response"
                }
                else {
                    throw $_
                }
            }
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityOrganization' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityEnvironment' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityCluster' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
