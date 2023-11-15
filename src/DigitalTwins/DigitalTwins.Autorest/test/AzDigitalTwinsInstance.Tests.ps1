if(($null -eq $TestName) -or ($TestName -contains 'AzDigitalTwinsInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDigitalTwinsInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDigitalTwinsInstance' {
    It 'CreateExpanded' {
        {
            $config = New-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName -Location $env.location -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled'
            $config.Name | Should -Be $env.dtInstanceName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzDigitalTwinsInstance
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName
            $config.Name | Should -Be $env.dtInstanceName
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.dtInstanceName
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName
            $config = Update-AzDigitalTwinsInstance -InputObject $config -Tag @{"1234"="abcd"}
            $config.Name | Should -Be $env.dtInstanceName
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDigitalTwinsInstance -ResourceGroupName $env.resourceGroup -ResourceName $env.dtInstanceName
        } | Should -Not -Throw
    }
}
