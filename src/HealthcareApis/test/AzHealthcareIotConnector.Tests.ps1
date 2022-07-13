if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareIotConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareIotConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareIotConnector' {
    It 'CreateExpanded' {
        {
            $arr = @()
            $config = New-AzHealthcareIotConnector -Name $env.iotConnector2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location -IngestionEndpointConfigurationConsumerGroup "sajob-01-portal_input-01_consumer_group" -IngestionEndpointConfigurationEventHubName "sajob01portaleventhub" -IngestionEndpointConfigurationFullyQualifiedEventHubNamespace "sdk-Namespace-4761" -DeviceMappingContent @{"templateType"="CollectionContent";"template"=$arr}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector2)"

            $config = New-AzHealthcareIotConnector -Name $env.iotConnector3 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location -IngestionEndpointConfigurationConsumerGroup "sajob-01-portal_input-01_consumer_group" -IngestionEndpointConfigurationEventHubName "sajob01portaleventhub" -IngestionEndpointConfigurationFullyQualifiedEventHubNamespace "sdk-Namespace-4761" -DeviceMappingContent @{"templateType"="CollectionContent";"template"=$arr}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector3)"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzHealthcareIotConnector -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzHealthcareIotConnector -Name $env.iotConnector2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector2)"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzHealthcareIotConnector -Name $env.iotConnector2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Tag @{"123"="abc"}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector2)"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzHealthcareIotConnector -Name $env.iotConnector3 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config = Update-AzHealthcareIotConnector -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector3)"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzHealthcareIotConnector -Name $env.iotConnector2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzHealthcareIotConnector -Name $env.iotConnector3 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            Remove-AzHealthcareIotConnector -InputObject $config
        } | Should -Not -Throw
    }
}