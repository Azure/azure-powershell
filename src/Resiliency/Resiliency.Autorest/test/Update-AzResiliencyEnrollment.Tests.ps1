if(($null -eq $TestName) -or ($TestName -contains 'Update-AzResiliencyEnrollment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzResiliencyEnrollment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzResiliencyEnrollment' {
    BeforeAll {
        $parameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName; Name = $env.enrollmentName }
        $usagePlanIdentity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        $identity = $usagePlanIdentity + @{ EnrollmentName = $env.enrollmentName }
        function Assert-UpdatedEnrollment([object]$Enrollment) {
            $Enrollment.Name | Should -Be $env.enrollmentName
            $Enrollment.ServiceGroupId | Should -Be $env.serviceGroupId
            $Enrollment.ProvisioningState | Should -Be 'Succeeded'
        }
    }

    It 'UpdateExpanded' {
        $enrollment = Invoke-ResiliencyWithRetry { Update-AzResiliencyEnrollment @parameters -ServiceGroupId $env.serviceGroupId }
        Assert-UpdatedEnrollment $enrollment
    }

    It 'UpdateViaIdentityUsagePlanExpanded' {
        $enrollment = Invoke-ResiliencyWithRetry { Update-AzResiliencyEnrollment -UsagePlanInputObject $usagePlanIdentity -Name $env.enrollmentName -ServiceGroupId $env.serviceGroupId }
        Assert-UpdatedEnrollment $enrollment
    }

    It 'UpdateViaIdentityUsagePlan' {
        $enrollment = Invoke-ResiliencyWithRetry { Update-AzResiliencyEnrollment -UsagePlanInputObject $usagePlanIdentity -Name $env.enrollmentName -Resource @{ ServiceGroupId = $env.serviceGroupId } }
        Assert-UpdatedEnrollment $enrollment
    }

    It 'Update' {
        $enrollment = Invoke-ResiliencyWithRetry { Update-AzResiliencyEnrollment @parameters -Resource @{ ServiceGroupId = $env.serviceGroupId } }
        Assert-UpdatedEnrollment $enrollment
    }

    It 'UpdateViaIdentityExpanded' {
        $enrollment = Invoke-ResiliencyWithRetry { Update-AzResiliencyEnrollment -InputObject $identity -ServiceGroupId $env.serviceGroupId }
        Assert-UpdatedEnrollment $enrollment
    }

    It 'UpdateViaIdentity' {
        $enrollment = Invoke-ResiliencyWithRetry { Update-AzResiliencyEnrollment -InputObject $identity -Resource @{ ServiceGroupId = $env.serviceGroupId } }
        Assert-UpdatedEnrollment $enrollment
    }
}
