if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterLinkReference'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterLinkReference.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterLinkReference' {
    It 'List' {
        {
            $listObj = Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp3

        } | Should -Not -Throw
    }

    It 'Get' {
        {
            #/nsp2/linkReferences/Ref-from-link1-nsp1.pg
            
            $nsp2Get = Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp2 -ResourceGroupName $env.rgname

            $linkReferenceName =  'Ref-from-' + $env.tmpLink1 + '-' + $nsp2Get.perimeterGuid
            
            Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp3 -Name $linkReferenceName

        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $nsp2Get = Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp2 -ResourceGroupName $env.rgname

            $linkReferenceName =  'Ref-from-' + $env.tmpLink1 + '-' + $nsp2Get.perimeterGuid
            
            $linkRef1Get = Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp3 -Name $linkReferenceName

            $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterLinkReference -InputObject $linkRef1Get
            $linkRef1Get.Name | Should -Be $GETObjViaIdentity.Name
        } | Should -Not -Throw
    }
}
