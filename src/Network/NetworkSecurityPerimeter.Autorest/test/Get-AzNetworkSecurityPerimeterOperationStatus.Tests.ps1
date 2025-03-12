if(($null -eq $TestName) -or ($TestName -contains 'Get-AzNetworkSecurityPerimeterOperationStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzNetworkSecurityPerimeterOperationStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzNetworkSecurityPerimeterOperationStatus' {
    It 'Get' {
        {
            $remove_response = Remove-AzNetworkSecurityPerimeterAssociation -Name $env.tmpAssociationDelete1 -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNspDelBase1 -NoWait
            $url = $remove_response.Target -split '\?' | Select-Object -First 1
            $operationId = $url -split '/' | Select-Object -Last 1

            Get-AzNetworkSecurityPerimeterOperationStatus -OperationId $operationId -Location $env.location
        } | Should -Not -Throw
    }

    It 'GetViaIdentityLocation' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
