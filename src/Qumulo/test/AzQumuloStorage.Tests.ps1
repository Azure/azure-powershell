if(($null -eq $TestName) -or ($TestName -contains 'AzQumuloStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzQumuloStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzQumuloStorage' {
    #New
    It 'CreateExpanded' {
        {
            $password = ConvertTo-SecureString $env.secureString -AsPlainText
            #For Get, Update, remove 1
            $qumuloObject = New-AzQumuloFileSystem -Name $env.qumulo1Name -ResourceGroupName $env.resourceGroup -AdminPassword $password -DelegatedSubnetId /subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualNetworkName)/subnets/$($env.subnetName) -InitialCapacity 50 -Location $env.region -MarketplaceOfferId $env.offerID -MarketplacePlanId $env.planID -MarketplacePublisherId $env.publisherID -StorageSku Standard -UserEmail $env.testerEmail -AvailabilityZone 1 -Tag @{"123"="abc"}
            $qumuloObject.Name | Should -Be $env.qumulo1Name
        } | Should -Not -Throw
    }

    # It 'List' {
    #     {
    #         $result = Get-AzQumuloFileSystem -SubscriptionId $env.SubscriptionId 
    #         $result.Count | Should -BeGreaterThan 4
    #     } | Should -Not -Throw
    # }

    It 'Get' {
        { Get-AzQumuloFileSystem -ResourceGroupName $env.resourceGroup -Name $env.qumulo1Name } | Should -Not -Throw
    }

    It 'List1' {
        {
            #Find one group of most resouces
            $result = Get-AzQumuloFileSystem -ResourceGroupName "pp-test"
            $result.Count | Should -BeGreaterThan 5
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            Update-AzQumuloFileSystem -ResourceGroupName $env.resourceGroup -Name $env.qumulo1Name -Tag @{"123"="abc"}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $fileSystem = Get-AzQumuloFileSystem -ResourceGroupName $env.resourceGroup -Name $env.qumulo1Name
            Update-AzQumuloFileSystem -InputObject $fileSystem -Tag @{"456"="def"}
        } | Should -Not -Throw
    }
    
    It 'Delete' {
        {
            Remove-AzQumuloFileSystem -Name $env.qumulo1Name -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $password = ConvertTo-SecureString $env.secureString -AsPlainText
            $qumuloObject1 = New-AzQumuloFileSystem -Name $env.qumulo2Name -ResourceGroupName $env.resourceGroup -AdminPassword $password -DelegatedSubnetId /subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualNetworkName)/subnets/$($env.subnetName) -InitialCapacity 50 -Location $env.region -MarketplaceOfferId $env.offerID -MarketplacePlanId $env.planID -MarketplacePublisherId $env.publisherID -StorageSku Standard -UserEmail $env.testerEmail -AvailabilityZone 1 -Tag @{"678"="fgh"}
            $qumuloObject1.Name | Should -Be $env.qumulo2Name
            
            Remove-AzQumuloFileSystem -InputObject $qumuloObject1
         } | Should -Not -Throw
    }
}
