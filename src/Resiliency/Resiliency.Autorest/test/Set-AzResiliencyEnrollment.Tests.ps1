if(($null -eq $TestName) -or ($TestName -contains 'Set-AzResiliencyEnrollment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzResiliencyEnrollment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzResiliencyEnrollment' {
    BeforeAll {
        $parameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName; Name = $env.enrollmentName }
        $body = @{ properties = @{ serviceGroupId = $env.serviceGroupId } }
        function Assert-SetEnrollment([object]$Enrollment) {
            $Enrollment.Name | Should -Be $env.enrollmentName
            $Enrollment.ServiceGroupId | Should -Be $env.serviceGroupId
            $Enrollment.ProvisioningState | Should -Be 'Succeeded'
        }
    }

    It 'UpdateExpanded' {
        $enrollment = Invoke-ResiliencyWithRetry { Set-AzResiliencyEnrollment @parameters -ServiceGroupId $env.serviceGroupId }
        Assert-SetEnrollment $enrollment
    }

    It 'Update' {
        $enrollment = Invoke-ResiliencyWithRetry { Set-AzResiliencyEnrollment @parameters -Resource @{ ServiceGroupId = $env.serviceGroupId } }
        Assert-SetEnrollment $enrollment
    }

    It 'UpdateViaJsonFilePath' {
        $jsonFilePath = Join-Path $TestDrive 'enrollment.json'
        $body | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $enrollment = Invoke-ResiliencyWithRetry { Set-AzResiliencyEnrollment @parameters -JsonFilePath $jsonFilePath }
        Assert-SetEnrollment $enrollment
    }

    It 'UpdateViaJsonString' {
        $json = $body | ConvertTo-Json -Depth 5
        $enrollment = Invoke-ResiliencyWithRetry { Set-AzResiliencyEnrollment @parameters -JsonString $json }
        Assert-SetEnrollment $enrollment
    }
}
