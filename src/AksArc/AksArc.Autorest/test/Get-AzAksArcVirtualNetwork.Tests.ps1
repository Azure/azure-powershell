if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksArcVirtualNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksArcVirtualNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksArcVirtualNetwork' {
    BeforeAll {
        $vnetName = "test-vnet"
        $mocGroup = "test-group"
        $mocLocation = "test-moclocation"
        $vnet = New-AzAksArcVirtualNetwork -Name $vnetName `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID `
            -CustomLocationName $env.customLocationName `
            -MocVnetName $env.mocVnetName `
            -MocGroup $mocGroup `
	        -MocLocation $mocLocation `
            -Location $env.location
    }

    AfterAll {
        $vnet | Remove-AzAksArcVirtualNetwork
    }

    It 'List all' {
        $list = Get-AzAksArcVirtualNetwork
        $list | Should -Not -BeNullOrEmpty
        $list.Count | Should -Be 1
        $list.Type | Should -Be $vnet.Type
        $list.Id | Should -Be $vnet.Id
    }

    It 'List has multiple' {
        $vnetName2 = "test-vnet2"
        $vnet2 = New-AzAksArcVirtualNetwork -Name $vnetName2 `
            -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID `
            -CustomLocationName $env.customLocationName `
            -MocVnetName $env.mocVnetName `
            -MocGroup $mocGroup `
	        -MocLocation $mocLocation `
            -Location $env.location
        $list = Get-AzAksArcVirtualNetwork
        $list | Should -Not -BeNullOrEmpty
        $list.Count | Should -Be 2
        if ($list[0].Name -ne $vnet.Name) {
            $temp = $list[0]
            $list[0] = $list[1]
            $list[1] = $temp
        }
        $list[0].Type | Should -Be $vnet.Type
        $list[0].Id | Should -Be $vnet.Id
        $list[1].Type | Should -Be $vnet2.Type
        $list[1].Id | Should -Be $vnet2.Id
        $vnet2 | Remove-AzAksArcVirtualNetwork
        try {
            $vnet2 | Get-AzAksArcVirtualNetwork
        } catch {
            $_.Exception.Message -like "*ResourceNotFound*" | Should -BeTrue
        }
    }

    It 'List by resource group' {
        $list = Get-AzAksArcVirtualNetwork -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $list | Should -Not -BeNullOrEmpty
        $list.Count | Should -Be 1
        $list.Type | Should -Be $vnet.Type
        $list.Id | Should -Be $vnet.Id
    }

    It 'Retrieve' {
        $vnetTemp = Get-AzAksArcVirtualNetwork -Name $vnetName `
	        -ResourceGroupName $env.resourceGroupName `
            -SubscriptionId $env.subscriptionID
        $vnetTemp | Should -Not -BeNullOrEmpty
        $vnetTemp.Count | Should -Be 1
        $vnetTemp.Type | Should -Be $vnet.Type
        $vnetTemp.Id | Should -Be $vnet.Id
    }

    It 'Retrieve failure' {
        try {
            Get-AzAksArcVirtualNetwork -Name "DoesNotExist" `
                -ResourceGroupName $env.resourceGroupName `
                -SubscriptionId $env.subscriptionID
        } catch {
            $_.Exception.Message -like "*ResourceNotFound*" | Should -BeTrue
        }
    }

    It 'RetrieveViaIdentity' {
        $vnetTemp = $vnet | Get-AzAksArcVirtualNetwork
        $vnetTemp | Should -Not -BeNullOrEmpty
        $vnetTemp.Count | Should -Be 1
        $vnetTemp.Type | Should -Be $vnet.Type
        $vnetTemp.Id | Should -Be $vnet.Id
    }
}
