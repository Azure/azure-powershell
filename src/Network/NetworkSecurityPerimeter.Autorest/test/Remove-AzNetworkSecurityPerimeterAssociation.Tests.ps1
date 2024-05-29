if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeterAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeterAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeterAssociation' {
    It 'Delete' {
        { 
        
        Remove-AzNetworkSecurityPerimeterAssociation -Name $env.tmpAssociationDelete1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1
        
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
        
        $associationObj = Get-AzNetworkSecurityPerimeterAssociation -Name $env.tmpAssociationDelete2 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1 

        Remove-AzNetworkSecurityPerimeterAssociation -InputObject $associationObj

        } | Should -Not -Throw
    }
}
