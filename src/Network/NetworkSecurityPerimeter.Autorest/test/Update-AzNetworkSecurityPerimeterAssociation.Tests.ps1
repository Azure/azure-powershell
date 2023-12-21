if(($null -eq $TestName) -or ($TestName -contains 'Update-AzNetworkSecurityPerimeterAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzNetworkSecurityPerimeterAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzNetworkSecurityPerimeterAssociation' {
    It 'UpdateExpanded' {
        { 
            $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name $env.association1 -SecurityPerimeterName $env.tmpNsp1 -ResourceGroupName $env.rgname

            $UpdateObj = Update-AzNetworkSecurityPerimeterAssociation -Name $env.association1 -SecurityPerimeterName $env.tmpNsp1 -ResourceGroupName $env.rgname -AccessMode $env.accessMode2

            $UpdateObj.accessMode | Should -Be $env.accessMode2

        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
           #$PSDefaultParameterValues['Disabled'] = $true   

           $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name $env.association1 -SecurityPerimeterName $env.tmpNsp1 -ResourceGroupName $env.rgname

           $UpdateObj = Update-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj -AccessMode $env.accessMode1

           $UpdateObj.accessMode | Should -Be $env.accessMode1

        } | Should -Not -Throw
    }
}
