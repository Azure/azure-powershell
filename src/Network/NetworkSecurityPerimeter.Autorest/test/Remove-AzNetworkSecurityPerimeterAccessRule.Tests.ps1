if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeterAccessRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeterAccessRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeterAccessRule' {
    It 'Delete' {
        { 

        Remove-AzNetworkSecurityPerimeterAccessRule -Name tmpAccessRuleDelete1 -ProfileName $env.tmpProfileDelBase1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1

        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
        

        $accessRuleObj = Get-AzNetworkSecurityPerimeterAccessRule -Name $env.tmpAccessRuleDelete2 -ProfileName $env.tmpProfileDelBase1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1

        Remove-AzNetworkSecurityPerimeterAccessRule -InputObject $accessRuleObj
        
        } | Should -Not -Throw
    }
}
