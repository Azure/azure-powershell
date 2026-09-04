if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAppNetworkMember'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAppNetworkMember.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAppNetworkMember' {
    It 'Delete' {
        {
            Remove-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup
            { Get-AzAppNetworkMember -Name $env.memberName -AppLinkName $env.appLinkName -ResourceGroupName $env.resourceGroup -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityAppLink' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
