if(($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkAnalyticsDataProduct'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzNetworkAnalyticsDataProduct.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkAnalyticsDataProduct' {

    It 'Create DataProduct with maximum set of properties' {
        {
            $CreateDataProductJob = New-AzNetworkAnalyticsDataProduct -Name $env.DataProductNameForMaxSet -Product $env.Product -MajorVersion $env.MajorVersion -Publisher $env.Publisher -Location $env.Location -ResourceGroupName $env.ResourceGroupName -PurviewAccount $env.PurviewAccount -CurrentMinorVersion $env.CurrentMinorVersion -NetworkaclAllowedQueryIPRangeList $env.NetworkaclAllowedQueryIPRangeList -PurviewCollection $env.PurviewCollection -CustomerEncryptionKeyName $env.CustomerEncryptionKeyName -NetworkaclDefaultAction $env.NetworkaclDefaultAction -Redundancy $env.Redundancy -CustomerEncryptionKeyVaultUri $env.CustomerEncryptionKeyVaultUri -NetworkaclIPRule @(@{ value = "1.1.1.1"; action = "Allow"}) -Tag @{ envType = "prod"; region = "us"} -CustomerEncryptionKeyVersion $env.CustomerEncryptionKeyVersion -NetworkaclVirtualNetworkRule @(@{ id = "/subscriptions/susbcription/resourceGroups/resourceGroupName/providers/Microsoft.Network/virtualNetworks/checkVnet/subnets/default"; state = "Provisioning"; action = "Allow"}) -CustomerManagedKeyEncryptionEnabled $env.CustomerManagedKeyEncryptionEnabled -Owner $env.Owner -IdentityType $env.IdentityType -PrivateLinksEnabled $env.PrivateLinksEnabled -PublicNetworkAccess $env.PublicNetworkAccess -IdentityUserAssignedIdentity @{"/subscriptions/susbcriptionId/resourcegroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/aa1221aa1-id"=@{}} -AsJob
            Wait-Job $CreateDataProductJob
            $JobResult = Receive-Job $CreateDataProductJob
            $JobResult.Name | Should -be $env.DataProductNameForMaxSet
            $JobResult.Product | should -be $env.Product
        } | Should -Not -Throw
    }

    It 'Create DataProduct with minimum set of properties' {
        {
            $CreateDataProductJob = New-AzNetworkAnalyticsDataProduct -Name $env.DataProductName -Product $env.Product -MajorVersion $env.MajorVersion -Publisher $env.Publisher -Location $env.Location -ResourceGroupName $env.ResourceGroupName -AsJob
            Wait-Job $CreateDataProductJob
            $JobResult = Receive-Job $CreateDataProductJob
            $JobResult.Name | Should -be $env.DataProductName
            $JobResult.Product | should -be $env.Product
        } | Should -Not -Throw
    }

    It 'Get DataProduct by Name' {
        $GetDataProduct = Get-AzNetworkAnalyticsDataProduct -ResourceGroupName $env.ResourceGroupName -Name $env.DataProductName
        $GetDataProduct.Name | should -be $env.DataProductName
        $GetDataProduct.Product | should -be $env.Product
    }

    It 'List DataProduct for a Subscription' {
        $GetDataProductsPerSub = Get-AzNetworkAnalyticsDataProduct
        $GetDataProductsPerSub.Count | Should -BeGreaterOrEqual 1
        $GetDataProductsPerSub.Name.Contains($env.DataProductName)| Should -Be $true
        $GetDataProductsPerSub.Name.Contains($env.DataProductNameForMaxSet)| Should -Be $true
        $GetDataProductsPerSub.Location.Contains($env.Location)| Should -Be $true
    }

    It 'List DataProduct for a ResourceGroup' {
        $GetDataProductsPerRG = Get-AzNetworkAnalyticsDataProduct -ResourceGroupName $env.ResourceGroupName
        $GetDataProductsPerRG.Count | Should -BeGreaterOrEqual 1
        $GetDataProductsPerRG.Name.Contains($env.DataProductName)| Should -Be $true
        $GetDataProductsPerRG.Name.Contains($env.DataProductNameForMaxSet)| Should -Be $true
        $GetDataProductsPerRG.Location.Contains($env.Location)| Should -Be $true
    }

    It 'Add Data Product User Role' {
        $AddRoleForUserOne = Add-AzNetworkAnalyticsDataProductUserRole -ResourceGroupName $env.ResourceGroupName -DataProductName $env.DataProductName -PrincipalId $env.UserOnePrincipalId -Role $env.Role -RoleId $env.RoleId  -UserName $env.UserOneName -PrincipalType $env.PrincipalType  -DataTypeScope $env.DataTypeScope
        $AddRoleForUserOne.UserOnePrincipalId | should -be $env.PrincipalId
        $AddRoleForUserTwo = Add-AzNetworkAnalyticsDataProductUserRole -ResourceGroupName $env.ResourceGroupName -DataProductName $env.DataProductName -PrincipalId $env.UserTwoPrincipalId -Role $env.Role -RoleId $env.RoleId  -UserName $env.UserTwoName -PrincipalType $env.PrincipalType  -DataTypeScope $env.DataTypeScope
        $AddRoleForUserTwo.UserTwoPrincipalId | should -be $env.PrincipalId
    }

    It 'List Data Product User Role by Data Product' {
        $GetDataProductUserRole = Get-AzNetworkAnalyticsDataProductRoleAssignment -ResourceGroupName $env.ResourceGroupName -DataProductName $env.DataProductName
        $GetDataProductUserRole.Count | Should -BeGreaterOrEqual 1
        $GetDataProductUserRole.RoleAssignmentResponse.PrincipalId.Contains($env.UserOnePrincipalId)| Should -Be $true
        $GetDataProductUserRole.RoleAssignmentResponse.PrincipalId.Contains($env.UserTwoPrincipalId)| Should -Be $true
    }

    It 'Remove Data Product User Role' {
        {
            Remove-AzNetworkAnalyticsDataProductUserRole -ResourceGroupName $env.ResourceGroupName -DataProductName $env.DataProductName -Role $env.Role -PrincipalType $env.PrincipalType -RoleId $env.RoleId -PrincipalId $env.UserOnePrincipalId -DataTypeScope $env.DataTypeScope -RoleAssignmentId $env.RoleAssignmentId -UserName $env.UserOneName
            #Write-Host "Sleeping for 1 minutes"
            #Start-TestSleep -Seconds 60
            $GetDataProductUserRole = Get-AzNetworkAnalyticsDataProductRoleAssignment -ResourceGroupName $env.ResourceGroupName -DataProductName $env.DataProductName
            $GetDataProductUserRole.RoleAssignmentResponse.PrincipalId.Contains($env.UserOnePrincipalId)| Should -Be $false
        } | Should -Not -Throw
    }

    It 'Delete DataProduct' {
        {
            $DeleteDataProductJob = Remove-AzNetworkAnalyticsDataProduct -ResourceGroupName $env.ResourceGroupName -Name $env.DataProductName -AsJob
            Wait-Job $DeleteDataProductJob
            Receive-Job $DeleteDataProductJob
            $DeleteDataProductMaxSetJob = Remove-AzNetworkAnalyticsDataProduct -ResourceGroupName $env.ResourceGroupName -Name $env.DataProductNameForMaxSet -AsJob
            Wait-Job $DeleteDataProductMaxSetJob
            Receive-Job $DeleteDataProductMaxSetJob
        } | Should -Not -Throw
    }
}
