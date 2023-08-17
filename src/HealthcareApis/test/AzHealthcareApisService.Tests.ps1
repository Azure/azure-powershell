if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareApisService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareApisService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareApisService' {
    It 'CreateExpanded' {
        {
            $config = New-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService1 -Kind 'fhir' -Location $env.location -CosmosOfferThroughput 400
            $config.Name | Should -Be $env.apiService1

            $config = New-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService2 -Kind 'fhir' -Location $env.location -CosmosOfferThroughput 400
            $config.Name | Should -Be $env.apiService2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzHealthcareApisService
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzHealthcareApisService -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService1
            $config.Name | Should -Be $env.apiService1
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService1 -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.apiService1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService2
            $config = Update-AzHealthcareApisService -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.apiService2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzHealthcareApisService -ResourceGroupName $env.resourceGroup -Name $env.apiService2
            Remove-AzHealthcareApisService -InputObject $config
        } | Should -Not -Throw
    }
}