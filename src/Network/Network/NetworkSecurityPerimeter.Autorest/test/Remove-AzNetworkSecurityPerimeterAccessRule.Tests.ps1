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
        #Remove-AzNetworkSecurityPerimeterAccessRule -Name $templateVariables.tmpAccessRuleDelete1 -ProfileName $templateVariables.tmpProfile1  -ResourceGroupName $env.rgname -SecurityPerimeterName $templateVariables.tmpNsp1 
         } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { 
        
        #Get-AzNetworkSecurityPerimeterAccessRule -Name $templateVariables.tmpAccessRuleDelete2 -ProfileName $templateVariables.tmpProfile1  -ResourceGroupName $env.rgname -SecurityPerimeterName $templateVariables.tmpNsp1 | Remove-AzNetworkSecurityPerimeterAccessRule
        } | Should -Not -Throw
    }
}
