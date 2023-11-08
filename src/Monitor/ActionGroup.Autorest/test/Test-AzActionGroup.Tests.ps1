if(($null -eq $TestName) -or ($TestName -contains 'Test-AzActionGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzActionGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzActionGroup' {
    It 'CreateExpanded' {
        {
            $email1 = New-AzActionGroupEmailReceiverObject -EmailAddress $env.useremail -Name $env.emailreceiver1
            $email2 = New-AzActionGroupEmailReceiverObject -EmailAddress 'user@example.com' -Name $env.emailreceiver2
            Test-AzActionGroup -ActionGroupName $env.actiongroupname -ResourceGroupName $env.resourceGroup -AlertType servicehealth -Receiver $email1,$email2
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityExpanded' {
        {
            $sms1 = New-AzActionGroupSmsReceiverObject -CountryCode $env.phonecountry -Name $env.smsreceiver -PhoneNumber $env.userphone
            $email1 = New-AzActionGroupEmailReceiverObject -EmailAddress $env.useremail -Name $env.emailreceiver1
            $ag = Get-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup
            Test-AzActionGroup -InputObject $ag -AlertType servicehealth -Receiver $sms1,$email1
        } | Should -Not -Throw
    }
}
