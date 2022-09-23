if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzCdnCanProfileMigrate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCdnCanProfileMigrate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzCdnCanProfileMigrate' -Tag 'LiveOnly' {
    It 'CanExpanded' {
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        {
            $subId = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
            $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)

            try
            {
                Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
                New-AzResourceGroup -Name $ResourceGroupName -Location $env.location -SubscriptionId $subId

                $frontDoorCdnProfileName = 'fdp-' + (RandomString -allChars $false -len 6);
                Write-Host -ForegroundColor Green "Use frontDoorCdnProfileName : $($frontDoorCdnProfileName)"

                $profileSku = "Standard_AzureFrontDoor";
                New-AzFrontDoorCdnProfile -SkuName $profileSku -Name $frontDoorCdnProfileName -ResourceGroupName $ResourceGroupName -Location Global -SubscriptionId $subId

                $classicResourceReferenceId = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Network/profiles/$frontDoorCdnProfileName"
                
                $canMigrate = Invoke-AzCdnCanProfileMigrate -ResourceGroupName $ResourceGroupName -ClassicResourceReferenceId $classicResourceReferenceId
                $canMigrate.CanMigrate | Should -BeTrue
            } Finally
            {
                Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
            }
        }
    }

    It 'Can' -skip {
        {

        } | Should -Not -Throw
    }

    It 'CanViaIdentityExpanded' -skip {
        {

        } | Should -Not -Throw
    }

    It 'CanViaIdentity' -skip {
        {

        } | Should -Not -Throw
    }
}
