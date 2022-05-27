if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerForWebApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerForWebApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerForWebApp' {
    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'New Key Vault connection' -skip { 
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.keyvaultId
        $authInfo = New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject
        $newLinker = New-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo
        # assert the linker create successfully
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp
        $linkers.Name.Contains($env.newLinker) | Should -Be $true

        $updateLinker = Update-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo -ClientType dotnet
        
        $null = Remove-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp  -LinkerName $env.newLinker
        
        # assert the linker delete successfully
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp
        if($linkers -ne $null){
            $linkers.Name.Contains($env.newLinker) | Should -Be $false
        }
    }

    It 'New postgresql connection' { 
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.postgresqId
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject -Name $env.postgresUsername -SecretKeyVaultUri $env.secretUri
        $newLinker = New-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo
        # assert the linker create successfully
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp
        $linkers.Name.Contains($env.newLinker) | Should -Be $true

        $updateLinker = Update-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo -ClientType dotnet
        
        $null = Remove-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp  -LinkerName $env.newLinker
        
        # assert the linker delete successfully
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp
        if($linkers -ne $null){
            $linkers.Name.Contains($env.newLinker) | Should -Be $false
        }
    }

    It 'New storage connection' { 
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.storageId
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject
        $newLinker = New-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo
        # assert the linker create successfully
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp
        $linkers.Name.Contains($env.newLinker) | Should -Be $true

        $null = Remove-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp  -LinkerName $env.newLinker
        
        # assert the linker delete successfully
        $linkers = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.webapp
        if($linkers -ne $null){
            $linkers.Name.Contains($env.newLinker) | Should -Be $false
        }
    }
}
