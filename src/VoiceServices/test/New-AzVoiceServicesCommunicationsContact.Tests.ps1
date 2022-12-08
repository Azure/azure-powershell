if(($null -eq $TestName) -or ($TestName -contains 'New-AzVoiceServicesCommunicationsContact'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVoiceServicesCommunicationsContact.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzVoiceServicesCommunicationsContact' {
    It 'CreateExpanded' {
        { 
            New-AzVoiceServicesCommunicationsContact -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.contactName02 -Location $env.location -PhoneNumber "+1-555-1234" -FullContactName "John Smith" -Email "johnsmith@example.com" -Role "Network Manager"
            Get-AzVoiceServicesCommunicationsContact -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01
            Get-AzVoiceServicesCommunicationsContact -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.contactName02
            Update-AzVoiceServicesCommunicationsContact -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.contactName02 -Tag @{'key1'='value1'} 
            Remove-AzVoiceServicesCommunicationsContact -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.contactName02        
        } | Should -Not -Throw
    }
    It 'CreateExpandedViaIdentity' {
        { 
            $contact = New-AzVoiceServicesCommunicationsContact -ResourceGroupName $env.resourceGroup -CommunicationsGatewayName $env.gatewayName01 -Name $env.contactName02 -Location $env.location -PhoneNumber "+1-555-1234" -FullContactName "John Smith" -Email "johnsmith@example.com" -Role "Network Manager"
            Get-AzVoiceServicesCommunicationsContact -InputObject $contact
            Update-AzVoiceServicesCommunicationsContact -InputObject $contact -Tag @{'key1'='value1'} 
            Remove-AzVoiceServicesCommunicationsContact -InputObject $contact       
        } | Should -Not -Throw
    }
}
