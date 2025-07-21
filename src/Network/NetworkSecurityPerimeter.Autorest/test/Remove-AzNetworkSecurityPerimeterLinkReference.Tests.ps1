if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNetworkSecurityPerimeterLinkReference'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNetworkSecurityPerimeterLinkReference.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNetworkSecurityPerimeterLinkReference' {
    It 'Delete' {
        {
            #/nsp2/linkReferences/Ref-from-link1-nsp1.pg
            
            $nsp8Get = Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp8 -ResourceGroupName $env.rgname

            $linkReferenceName =  'Ref-from-' + $env.tmpLinkDelete3 + '-' + $nsp8Get.perimeterGuid
            
            Remove-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp9 -Name $linkReferenceName

        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $nsp10Get = Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp10 -ResourceGroupName $env.rgname

            $linkReferenceName =  'Ref-from-' + $env.tmpLinkDelete4 + '-' + $nsp10Get.perimeterGuid
            
            $linkRefObj = Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp11 -Name $linkReferenceName
    
            Remove-AzNetworkSecurityPerimeterLinkReference -InputObject $linkRefObj

        } | Should -Not -Throw
    }
}
