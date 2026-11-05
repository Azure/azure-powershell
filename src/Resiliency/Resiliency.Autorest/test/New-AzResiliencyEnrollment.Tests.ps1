if(($null -eq $TestName) -or ($TestName -contains 'New-AzResiliencyEnrollment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzResiliencyEnrollment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzResiliencyEnrollment' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        $usagePlanIdentity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $env.usagePlanName }
        $body = @{ properties = @{ serviceGroupId = $env.enrollmentServiceGroupId } }
        # Each scenario enrolls the dedicated service group, verifies the enrollment and removes it again.
        function Assert-NewEnrollment([object]$Enrollment, [string]$Name) {
            $Enrollment.Name | Should -Be $Name
            $Enrollment.ServiceGroupId | Should -Be $env.enrollmentServiceGroupId
            $Enrollment.ProvisioningState | Should -Be 'Succeeded'
            Remove-AzResiliencyEnrollment @planParameters -Name $Name
            @(Get-AzResiliencyEnrollment @planParameters).Name | Should -Not -Contain $Name
        }
    }

    It 'CreateExpanded' {
        $name = "$($env.enrollmentName)-new1"
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment @planParameters -Name $name -ServiceGroupId $env.enrollmentServiceGroupId }
        Assert-NewEnrollment $enrollment $name
    }

    It 'CreateViaJsonString' {
        $name = "$($env.enrollmentName)-new2"
        $json = $body | ConvertTo-Json -Depth 5
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment @planParameters -Name $name -JsonString $json }
        Assert-NewEnrollment $enrollment $name
    }

    It 'CreateViaJsonFilePath' {
        $name = "$($env.enrollmentName)-new3"
        $jsonFilePath = Join-Path $TestDrive 'enrollment.json'
        $body | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment @planParameters -Name $name -JsonFilePath $jsonFilePath }
        Assert-NewEnrollment $enrollment $name
    }

    It 'CreateViaIdentityUsagePlanExpanded' {
        $name = "$($env.enrollmentName)-new4"
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment -UsagePlanInputObject $usagePlanIdentity -Name $name -ServiceGroupId $env.enrollmentServiceGroupId }
        Assert-NewEnrollment $enrollment $name
    }

    It 'CreateViaIdentityUsagePlan' {
        $name = "$($env.enrollmentName)-new5"
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment -UsagePlanInputObject $usagePlanIdentity -Name $name -Resource @{ ServiceGroupId = $env.enrollmentServiceGroupId } }
        Assert-NewEnrollment $enrollment $name
    }

    It 'Create' {
        $name = "$($env.enrollmentName)-new6"
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment @planParameters -Name $name -Resource @{ ServiceGroupId = $env.enrollmentServiceGroupId } }
        Assert-NewEnrollment $enrollment $name
    }

    It 'CreateViaIdentityExpanded' {
        $name = "$($env.enrollmentName)-new7"
        $identity = $usagePlanIdentity + @{ EnrollmentName = $name }
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment -InputObject $identity -ServiceGroupId $env.enrollmentServiceGroupId }
        Assert-NewEnrollment $enrollment $name
    }

    It 'CreateViaIdentity' {
        $name = "$($env.enrollmentName)-new8"
        $identity = $usagePlanIdentity + @{ EnrollmentName = $name }
        $enrollment = Invoke-ResiliencyWithRetry { New-AzResiliencyEnrollment -InputObject $identity -Resource @{ ServiceGroupId = $env.enrollmentServiceGroupId } }
        Assert-NewEnrollment $enrollment $name
    }
}
