if(($null -eq $TestName) -or ($TestName -contains 'Deploy-AzCdnEdgeActionVersionCode'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Deploy-AzCdnEdgeActionVersionCode.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Deploy-AzCdnEdgeActionVersionCode' {
    It 'DeployExpanded' {
        $script:EdgeActionName = "eavc"
        $script:TestResourceGroup = $env.ResourceGroupName
        
        # Create test edge action first (required for version creation)
        New-AzCdnEdgeAction -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -SkuName "Standard" -SkuTier "Standard" -Location "global"
        # Test creating edge action version with expanded parameters
        $version = "v1"
        $version2 = "v2"


        New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version -DeploymentType "zip" -IsDefaultVersion $false -Location "global"

        New-AzCdnEdgeActionVersion -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version2 -DeploymentType "zip" -IsDefaultVersion $false -Location "global"
        
        Deploy-AzCdnEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Name $version2 -Version $version2 -Content "UEsDBBQACAAIAPx8xVoAAAAAAAAAAAAAAAAOACAAZWRnZV9hY3Rpb24uanN1eAsAAQQAAAAABAAAAABVVA0AB7wcQmjOHEJovBxCaF2PwQrCMBBE70L/YelFPdgqeCse/AVFEEQkJCOtyEaTjYrivxuNluJestl5M8vuA2tpLFOt2BzhBriAZUiPrEexLsqRwznAC83ooxXff9Ul/MmyRwdJgw7D9trK2rLgJkWcRSIxZUlLCE3HE1qxClJb19xhyIuS4ElbgwT+stslu7cWs6O1mzY3hmooA0diqWHTaCUgqdFedFU+9gdogfkLT06/6a9Hi0THN5H9bVyWiwvIq59LguN0XJX1ni9QSwcINUDKiL4AAABVAQAAUEsBAhQDFAAIAAgA/HzFWjVAyoi+AAAAVQEAAA4AGAAAAAAAAAAAALaBAAAAAGVkZ2VfYWN0aW9uLmpzdXgLAAEEAAAAAAQAAAAAVVQFAAG8HEJoUEsFBgAAAAABAAEAVAAAABoBAAAAAA=="
        
        Get-AzCdnEdgeActionVersionCode -ResourceGroupName $script:TestResourceGroup -EdgeActionName $script:EdgeActionName -Version $version2
    }

    It 'DeployViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Deploy' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentityEdgeActionExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentityEdgeAction' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeployViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
