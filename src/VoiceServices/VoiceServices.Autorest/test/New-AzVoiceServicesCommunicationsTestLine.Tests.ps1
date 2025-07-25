if(($null -eq $TestName) -or ($TestName -contains 'New-AzVoiceServicesCommunicationsTestLine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVoiceServicesCommunicationsTestLine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzVoiceServicesCommunicationsTestLine' {
    It 'CreateExpanded' {
        { 
            New-AzVoiceServicesCommunicationsTestLine -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.testlineName02 -Location $env.location -Purpose 'Automated' -PhoneNumber "+1-555-1234" 
            Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01
            Get-AzVoiceServicesCommunicationsTestLine -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.testlineName02
            Update-AzVoiceServicesCommunicationsTestLine -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.testlineName02 -Tag @{'key1'='value1'}
            Remove-AzVoiceServicesCommunicationsTestLine -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.testlineName02
        } | Should -Not -Throw
    }
    It 'CreateExpandedViaIdentity' {
        { 
            $testline = New-AzVoiceServicesCommunicationsTestLine -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.testlineName02 -Location $env.location -Purpose 'Automated' -PhoneNumber "+1-555-1234" 
            Get-AzVoiceServicesCommunicationsTestLine -InputObject $testline
            Update-AzVoiceServicesCommunicationsTestLine -InputObject $testline -Tag @{'key1'='value1'}
            Remove-AzVoiceServicesCommunicationsTestLine -InputObject $testline
        } | Should -Not -Throw
    }
}
