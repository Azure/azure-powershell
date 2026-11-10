if(($null -eq $TestName) -or ($TestName -contains 'New-AzResiliencyUsagePlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzResiliencyUsagePlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzResiliencyUsagePlan' {
    BeforeAll {
        $planParameters = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName }
        function Assert-NewUsagePlan([object]$Plan, [string]$Name) {
            $Plan.Name | Should -Be $Name
            $Plan.Location | Should -Be 'global'
            $Plan.PlanType | Should -Be 'Standard'
            $Plan.ProvisioningState | Should -Be 'Succeeded'
            Remove-AzResiliencyUsagePlan @planParameters -Name $Name
            @(Get-AzResiliencyUsagePlan @planParameters).Name | Should -Not -Contain $Name
        }
    }

    It 'CreateExpanded' {
        $name = "$($env.usagePlanName)-new1"
        $plan = New-AzResiliencyUsagePlan @planParameters -Name $name -Location global -PlanType Standard
        Assert-NewUsagePlan $plan $name
    }

    It 'CreateViaJsonString' {
        $name = "$($env.usagePlanName)-new2"
        $json = @{ location = 'global'; properties = @{ planType = 'Standard' } } | ConvertTo-Json -Depth 5
        $plan = New-AzResiliencyUsagePlan @planParameters -Name $name -JsonString $json
        Assert-NewUsagePlan $plan $name
    }

    It 'CreateViaJsonFilePath' {
        $name = "$($env.usagePlanName)-new3"
        $jsonFilePath = Join-Path $TestDrive 'usagePlan.json'
        @{ location = 'global'; properties = @{ planType = 'Standard' } } | ConvertTo-Json -Depth 5 | Set-Content $jsonFilePath
        $plan = New-AzResiliencyUsagePlan @planParameters -Name $name -JsonFilePath $jsonFilePath
        Assert-NewUsagePlan $plan $name
    }

    It 'Create' {
        $name = "$($env.usagePlanName)-new4"
        $plan = New-AzResiliencyUsagePlan @planParameters -Name $name -Resource @{ Location = 'global'; PlanType = 'Standard' }
        Assert-NewUsagePlan $plan $name
    }

    It 'CreateViaIdentityExpanded' {
        $name = "$($env.usagePlanName)-new5"
        $identity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $name }
        $plan = New-AzResiliencyUsagePlan -InputObject $identity -Location global -PlanType Standard
        Assert-NewUsagePlan $plan $name
    }

    It 'CreateViaIdentity' {
        $name = "$($env.usagePlanName)-new6"
        $identity = @{ SubscriptionId = $env.SubscriptionId; ResourceGroupName = $env.resourceGroupName; UsagePlanName = $name }
        $plan = New-AzResiliencyUsagePlan -InputObject $identity -Resource @{ Location = 'global'; PlanType = 'Standard' }
        Assert-NewUsagePlan $plan $name
    }
}
