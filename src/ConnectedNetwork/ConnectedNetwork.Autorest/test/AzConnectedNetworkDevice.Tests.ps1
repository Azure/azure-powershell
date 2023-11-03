if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkDevice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkDevice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkDevice' {
    It 'CreateExpanded' {
        {
            $ase = New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId $env.AzureStackEdgeId
            $config = New-AzConnectedNetworkDevice -Name $env.DeviceName1 -ResourceGroupName $env.ResourceGroupName1 -Location $env.Location -Property $ase
            $config.Name | Should -Be $env.DeviceName1

            $config = New-AzConnectedNetworkDevice -Name $env.DeviceName2 -ResourceGroupName $env.ResourceGroupName2 -Location $env.Location -Property $ase
            $config.Name | Should -Be $env.DeviceName2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkDevice
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkDevice -ResourceGroupName $env.ResourceGroupName1 -Name $env.DeviceName1
            $config.Name | Should -Be $env.DeviceName1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzConnectedNetworkDevice -ResourceGroupName $env.ResourceGroupName2
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzConnectedNetworkDeviceTag -ResourceGroupName $env.ResourceGroupName2 -DeviceName $env.DeviceName2 -Tag @{ "NewTag" = "NewTagValue"}
            $config.Name | Should -Be $env.DeviceName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzConnectedNetworkDevice -ResourceGroupName $env.ResourceGroupName1 -Name $env.DeviceName1
            $config = Update-AzConnectedNetworkDeviceTag -InputObject $config -Tag @{ "NewTag" = "NewTagValue"} 
            $config.Name | Should -Be $env.DeviceName1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkDevice -ResourceGroupName $env.ResourceGroupName2 -Name $env.DeviceName2
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzConnectedNetworkDevice -ResourceGroupName $env.ResourceGroupName1 -Name $env.DeviceName1
            Remove-AzConnectedNetworkDevice -InputObject $config
        } | Should -Not -Throw
    }
}
