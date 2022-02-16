if(($null -eq $TestName) -or ($TestName -contains 'Send-AzLabServicesUserInvite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Send-AzLabServicesUserInvite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Send-AzLabServicesUserInvite' {
    It 'Send-AzLabServicesUserInvite User' {
        {Send-AzLabServicesUserInvite -ResourceGroupName $ENV:ResourceGroupName -LabName $ENV:LabName -UserName $ENV:UserName -Text "testing 1."} | Should -Not -Throw
    }

    It 'Send-AzLabServicesUserInvite Id' -Skip {
        $user = Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -Name $ENV:UserNameSecond
        {Send-AzLabServicesUserInvite -ResourceId $user.Id -Text "testing 2."} | Should -Not -Throw
    }
}
