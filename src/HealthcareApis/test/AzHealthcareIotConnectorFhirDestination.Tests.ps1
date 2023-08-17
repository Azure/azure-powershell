if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareIotConnectorFhirDestination'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareIotConnectorFhirDestination.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareIotConnectorFhirDestination' {
    It 'CreateExpanded1' {
        {
            $arr = @()
            $config = New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName $env.iotFhirDestination1 -IotConnectorName $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -FhirServiceResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.HealthcareApis/workspaces/$($env.apiWorkspace1)/fhirservices/$($env.fhirService1)" -ResourceIdentityResolutionType 'Create' -Location $env.location -FhirMappingContent @{"templateType"="CollectionFhirTemplate";"template"=$arr}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector1)/$($env.iotFhirDestination1)"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzHealthcareIotConnectorFhirDestination -FhirDestinationName $env.iotFhirDestination1 -IotConnectorName $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector1)/$($env.iotFhirDestination1)"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzHealthcareIotConnectorFhirDestination -FhirDestinationName $env.iotFhirDestination1 -IotConnectorName $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
        } | Should -Not -Throw
    }

    It 'CreateExpanded2' {
        {
            $arr = @()
            $config = New-AzHealthcareIotConnectorFhirDestination -FhirDestinationName $env.iotFhirDestination2 -IotConnectorName $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -FhirServiceResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.HealthcareApis/workspaces/$($env.apiWorkspace1)/fhirservices/$($env.fhirService1)" -ResourceIdentityResolutionType 'Create' -Location $env.location -FhirMappingContent @{"templateType"="CollectionFhirTemplate";"template"=$arr}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.iotConnector1)/$($env.iotFhirDestination2)"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzHealthcareFhirDestination -IotConnectorName $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzHealthcareIotConnectorFhirDestination -FhirDestinationName $env.iotFhirDestination2 -IotConnectorName $env.iotConnector1 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            Remove-AzHealthcareIotConnectorFhirDestination -InputObject $config
        } | Should -Not -Throw
    }
}