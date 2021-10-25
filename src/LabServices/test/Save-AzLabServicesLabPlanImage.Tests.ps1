if(($null -eq $TestName) -or ($TestName -contains 'Save-AzLabServicesLabPlanImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Save-AzLabServicesLabPlanImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Save-AzLabServicesLabPlanImage' {
    It 'Save' {        
        {Save-AzLabServicesLabPlanImage -LabPlanName $ENV:LabPlanName -ResourceGroupName $ENV:ResourceGroupName -Name 'UnitTestSave' -LabVirtualMachineId "/subscriptions/$($ENV:SubscriptionId)/resourceGroups/$($ENV:ResourceGroupName)/providers/Microsoft.LabServices/labs/$($ENV:LabName)/virtualMachines/0"} | Should -Not -Throw
    }

}
