if(($null -eq $TestName) -or ($TestName -contains 'Update-AzUserAssignedIdentity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzUserAssignedIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzUserAssignedIdentity' {
    It 'UpdateExpanded' {
        $ide = Update-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName01 -Tag @{"key01"="value01"; "key02" = "value02"}
        $ide.Tag.Count | Should -Be 2
    }

    It 'UpdateViaIdentityExpanded' {
        $ide = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName01
        $ide = Update-AzUserAssignedIdentity -InputObject $ide -Tag @{"key01"="value01"; "key02" = "value02"; "key03" = "value03"}
        $ide.Tag.Count | Should -Be 3
    }
}
