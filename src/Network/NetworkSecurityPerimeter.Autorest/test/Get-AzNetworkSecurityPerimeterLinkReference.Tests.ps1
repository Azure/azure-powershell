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
            Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2 -Debug
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $linkObj = Get-AzNetworkSecurityPerimeterLink -Name $env.tmpLink1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2 -Debug

            $nspObj = Get-AzNetworkSecurityPerimeter -Name $env.tmpNsp3 -ResourceGroupName $env.rgname

            $linkReferenceName =  'Ref-from-' + $env.tmpLink1 + '-' + $nspObj.perimeterGuid
            
            Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2 -Name $linkReferenceName -Debug

        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $linkObj = Get-AzNetworkSecurityPerimeterLink -Name $env.tmpLink1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2

            $linkReferenceName =  'Ref-from-' + $env.tmpLink1 + '-' + $linkObj.remotePerimeterGuid
            
            Write-Output "Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2 -Name $linkReferenceName"

            $GetObj = Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2 -Name $linkReferenceName

            $GETObjViaIdentity = Get-AzNetworkSecurityPerimeterLinkReference -InputObject $GETObj
            $GETObj.Name | Should -Be $GETObjViaIdentity.Name
        } | Should -Not -Throw
    }
}
