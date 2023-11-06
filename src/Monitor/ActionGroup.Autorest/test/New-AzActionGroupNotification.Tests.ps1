if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupNotification'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupNotification.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupNotification' {
    It 'CreateExpanded' {
        {
            $email1 = New-AzActionGroupEmailReceiverObject -EmailAddress $env.useremail -Name $env.emailreceiver
            New-AzActionGroupNotification -ActionGroupName $env.actiongroupname -ResourceGroupName $env.resourceGroup -AlertType servicehealth -EmailReceiver $email1
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
            $ag = Get-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup
            New-AzActionGroupNotification -InputObject $ag -AlertType servicehealth -SmsReceiver $sms1
        } | Should -Not -Throw
    }
}
