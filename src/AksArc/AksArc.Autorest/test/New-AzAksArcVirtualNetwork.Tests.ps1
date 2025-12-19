if(($null -eq $TestName) -or ($TestName -contains 'New-AzAksArcVirtualNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAksArcVirtualNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAksArcVirtualNetwork' {
    BeforeAll {
        $vnetName = "test-vnet"
        $mocGroup = "test-group"
        $mocLocation = "test-moclocation"
        $jsonString = @"
{
  "properties": {
      "infraVnetProfile": {
        "hci": {
          "mocVnetName": "$($env.mocVnetName)",
          "mocGroup": "$mocGroup",
          "mocLocation": "$mocLocation"
        }
      }
  },
  "location": "$($env.location)",
  "extendedLocation": {
      "type": "CustomLocation",
      "name": "$($env.customLocationID)"
  }
}
"@
    }

    AfterAll {
        Remove-AzAksArcVirtualNetwork -Name $vnetName `
	        -ResourceGroupName $env.resourceGroupName
    }

    It 'CreateExpanded' {
        $vnet = New-AzAksArcVirtualNetwork -Name $vnetName `
            -ResourceGroupName $env.resourceGroupName `
            -CustomLocationName $env.customLocationName `
            -MocVnetName $env.mocVnetName `
            -MocGroup $mocGroup `
	        -MocLocation $mocLocation `
            -Location $env.location
        $vnet | Should -Not -BeNullOrEmpty
        $vnet.ProvisioningState | Should -be "Succeeded"
        $vnet.Type | Should -be  "microsoft.hybridcontainerservice/virtualNetworks"
    }

    It 'CreateViaJsonString' {
        New-AzAksArcVirtualNetwork -Name $vnetName `
            -ResourceGroupName $env.resourceGroupName  `
            -JsonString $jsonString
    }

    It 'CreateViaJsonFilePath' {
        $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath "New-AzAksArcVirtualNetwork-Params.json"
        $jsonString | Out-File -FilePath $jsonFilePath

        New-AzAksArcVirtualNetwork -Name $vnetName `
            -ResourceGroupName $env.resourceGroupName  `
            -JsonFilePath $jsonFilePath
    }
}
