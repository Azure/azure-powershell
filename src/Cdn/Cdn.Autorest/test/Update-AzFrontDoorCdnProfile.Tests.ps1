if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFrontDoorCdnProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFrontDoorCdnProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFrontDoorCdnProfile' {
    BeforeAll {
        $script:profileName = 'fdp-pstest-upd'
        New-AzFrontDoorCdnProfile -SkuName 'Standard_AzureFrontDoor' -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Location Global | Out-Null
    }

    AfterAll {
        Remove-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
    }

    It 'UpdateExpanded' {
        $rule = New-AzFrontDoorCdnProfileScrubbingRulesObject -MatchVariable RequestIPAddress -State Enabled
        Update-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName -Tag @{ Tag1 = 11 } -OriginResponseTimeoutSecond 30 -IdentityType SystemAssigned -LogScrubbingRule @($rule) -LogScrubbingState Enabled
        $u = Get-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName
        $u.Tag['Tag1'] | Should -Be '11'
        $u.OriginResponseTimeoutSecond | Should -Be '30'
        $u.IdentityType | Should -Be 'SystemAssigned'
        $u.LogScrubbingRule.Count | Should -Be 1
    }

    It 'UpdateViaIdentityExpanded' {
        $p = Get-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName
        Update-AzFrontDoorCdnProfile -Tag @{ Tag1 = 33 } -OriginResponseTimeoutSecond 60 -InputObject $p
        $u = Get-AzFrontDoorCdnProfile -Name $script:profileName -ResourceGroupName $env.ResourceGroupName
        $u.Tag['Tag1'] | Should -Be '33'
        $u.OriginResponseTimeoutSecond | Should -Be '60'
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
