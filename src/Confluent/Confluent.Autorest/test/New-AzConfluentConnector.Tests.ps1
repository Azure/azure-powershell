if(($null -eq $TestName) -or ($TestName -contains 'New-AzConfluentConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConfluentConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConfluentConnector' {
    It 'CreateExpanded' {
        {    
            try {
                New-AzConfluentConnector -Name $env.connectorName -ResourceGroupName $env.connectorResourceGroup -OrganizationName $env.connectorOrganization -EnvironmentId $env.connectorEnvironmentId -ClusterId $env.connectorClusterId -SubscriptionId $env.SubscriptionId -ConnectorBasicInfoConnectorClass $env.connectorClass -ConnectorBasicInfoConnectorName $env.connectorName -ConnectorBasicInfoConnectorType $env.connectorType -ConnectorServiceTypeInfoConnectorServiceType $env.connectorServiceType -PartnerConnectorInfoPartnerConnectorType $env.connectorPartnerType
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

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityOrganizationExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityEnvironmentExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityClusterExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
