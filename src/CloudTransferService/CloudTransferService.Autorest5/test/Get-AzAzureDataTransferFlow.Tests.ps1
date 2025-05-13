if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAzureDataTransferFlow'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAzureDataTransferFlow.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAzureDataTransferFlow' {
    # Test for the 'List' parameter set
    It 'List - Should retrieve all flows for a connection' {
        $connectionName = "faikh-send-connection-6"
        $resourceGroupName = "rpaas-rg"

        $result = Get-AzAzureDataTransferFlow -ConnectionName $connectionName -ResourceGroupName $resourceGroupName
        $result | Should -Not -BeNullOrEmpty
        $result.Count | Should -BeGreaterThan 0
        $result[0].Name | Should -Not -BeNullOrEmpty
    }

    # Test for invalid parameters
    It 'Invalid Parameters - Should throw an error for missing required parameters' {
        { Get-AzAzureDataTransferFlow } | Should -Throw
    }
    
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityConnection1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityConnection' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
