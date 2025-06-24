if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmServer' {
    It 'CreateExpanded' {
        {
            $securePassword = ConvertTo-SecureString -String $env.ServerPassword -AsPlainText -Force
            $result = New-AzScVmmServer -Name $env.VmmServerName -ResourceGroupName $env.ResourceGroupVmmTest -Location $env.location -CustomLocationId $env.CustomLocationVmmTest -FQDN $env.FQDN -Port $env.Port -Username $env.ServerUsername -Password $securePassword 
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
    
    It 'ListBySubscription - List' {
        {
            $result = Get-AzScVmmServer
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup - List1' {
        {
            $result = Get-AzScVmmServer -ResourceGroupName $env.ResourceGroupVmmTest
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        $result = Update-AzScVmmServer -ResourceGroupName $env.ResourceGroupVmmTest -Name $env.VmmServerName -Tag @{tag1="value1"}
        $result.ProvisioningState | Should -Be 'Succeeded' 
        $result.Tag['tag1'] | Should -Be 'value1'
    }

    It 'Get' {
        {
            $result = Get-AzScVmmServer -ResourceGroupName $env.ResourceGroupVmmTest -Name $env.VmmServerName
            $result.Name | Should -Be $env.VmmServerName
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmServer -ResourceGroupName $env.ResourceGroupVmmTest -Name $env.VmmServerName
        } | Should -Not -Throw
    }
}
