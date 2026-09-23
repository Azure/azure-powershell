if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLabServicesLab'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLabServicesLab.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)
Describe 'Get-AzLabServicesLab' {
    It 'List' {
         Get-AzLabServicesLab | Should -Not -BeNullOrEmpty
    }
    
    It 'List with Resource Group' {
        Get-AzLabServicesLab -ResourceGroupName $env.ResourceGroupName | Should -Not -BeNullOrEmpty
    }

   It 'Get' {
        Get-AzLabServicesLab -ResourceGroupName $env.ResourceGroupName -Name $env.LabName | Select-Object -Property Name | Should -Be "@{Name=$($env.LabName)}"
    }

    It 'LabPlan' {
        $plan = Get-AzLabServicesLabPlan -Name $env.LabPlanName -ResourceGroupName $env.ResourceGroupName
        Get-AzLabServicesLab -LabPlan $plan -Name $env.LabName | Select-Object -Property Name | Should -Be "@{Name=$($env.LabName)}"
    }
    
    It 'ResourceId' {        
        Get-AzLabServicesLab -ResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.LabServices/labs/$($env.LabName)" | Select-Object -Property Name | Should -Be "@{Name=$($env.LabName)}"
    }

    It 'Name with wildcard' {
        Get-AzLabServicesLab -ResourceGroupName $env.ResourceGroupName -Name $env.LabNameLike | Select-Object -Property Name | Should -Be "@{Name=$($env.LabName)}"
    }
}
