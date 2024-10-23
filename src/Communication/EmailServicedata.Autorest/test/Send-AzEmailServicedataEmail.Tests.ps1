if(($null -eq $TestName) -or ($TestName -contains 'Send-AzEmailServicedataEmail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Send-AzEmailServicedataEmail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Send-AzEmailServicedataEmail' {
    It 'Send' {       
        $emailRecipientTo = @(
            @{
                Address = "contosouser@contoso.com"
                DisplayName = "ContosoUser"
            }
        )
        $message = @{
	        ContentSubject = "Test Email"
	        RecipientTo = @($emailRecipientTo)  # Array of email address objects
	        SenderAddress = $env.senderAddress
	        ContentPlainText = "This is the first email from ACS - HTML"	
        }
        $SendEmailResult = Send-AzEmailServicedataEmail -Message $message -endpoint $env.endPoint
        $SendEmailResult.Status | Should -Be "Succeeded"
    }

    It 'SendExpanded' {
        $emailRecipientTo = @(
            @{
                Address = "contosouser@contoso.com"
                DisplayName = "ContosoUser"
            }
        )
        $contentSubject = "Test Email"
        $contentPlainText = "This is the first email from ACS - HTML"	
        $SendEmailResult = Send-AzEmailServicedataEmail -endpoint $env.endPoint -ContentSubject $contentSubject -RecipientTo @($emailRecipientTo) -SenderAddress $env.senderAddress -ContentPlainText $contentPlainText
        $SendEmailResult.Status | Should -Be "Succeeded"
    }

    It 'SendViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SendViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
