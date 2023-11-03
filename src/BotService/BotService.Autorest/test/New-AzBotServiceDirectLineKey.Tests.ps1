if(($null -eq $TestName) -or ($TestName -contains 'New-AzBotServiceDirectLineKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBotServiceDirectLineKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzBotServiceDirectLineKey' {
    It 'RegenerateExpanded' {
        $SubscriptionId, $ResourceGroupName, $NewBotService1 = $env.SubscriptionId, $env.ResourceGroupName, $env.NewBotService1
        $GeneratedKey = New-AzBotServiceDirectLineKey -ChannelName 'DirectLineChannel' -ResourceGroupName $ResourceGroupName -ResourceName $env.NewBotService1 -Key key1 -SiteName siteName 
        $GeneratedKey.Id | Should -Be "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.BotService/botServices/$NewBotService1/channels/DirectLineChannel"
    }
}
