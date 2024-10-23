if(($null -eq $TestName) -or ($TestName -contains 'Get-AzEmailServicedataEmailSendResult'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzEmailServicedataEmailSendResult.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzEmailServicedataEmailSendResult' {
    It 'Get' {
        $emailRecipientTo = @(
            @{
                Address = "contosouser@contoso.com"
                DisplayName = "ContosoUser"
            }
        )
        $message = @{
	        ContentSubject = "Test Email"
	        RecipientTo = @($emailRecipientTo)
	        SenderAddress = $env.senderAddress
	        ContentPlainText = "This is the first email from ACS - HTML"	
        }
        $sendEmailResult = Send-AzEmailServicedataEmail -Message $message -endpoint $env.endPoint        
        $getEmailResult = Get-AzEmailServicedataEmailSendResult -Endpoint $env.endPoint -OperationId $sendEmailResult.Id
        $sendEmailResult.Status | Should -Be $getEmailResult.Status
    }

    It 'GetViaIdentity' {
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

        $sendEmailResult = Send-AzEmailServicedataEmail -Message $message -endpoint $env.endPoint            
        $inputObject = @{
	        OperationId = $sendEmailResult.Id
        }
        $getEmailResult = Get-AzEmailServicedataEmailSendResult -Endpoint $env.endPoint -InputObject $inputObject
        $sendEmailResult.Status | Should -Be $getEmailResult.Status
    }
}