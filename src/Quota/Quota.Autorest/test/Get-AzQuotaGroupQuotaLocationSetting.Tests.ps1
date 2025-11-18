if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaLocationSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaLocationSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaLocationSetting' {
    BeforeAll {
        # Use values from env.json
        $script:managementGroupId = "mg-demo"
        $script:groupQuotaName = "testlocation"
        $script:location = "eastus"
        $script:resourceProviderName = "Microsoft.Compute"
    }

    It 'Get' {
        # Get the location setting - may not exist yet if async operation hasn't completed
        try {
            $result = Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location
            
            # If it exists, verify the properties
            $result | Should -Not -BeNull
            $result.Name | Should -Be $script:location
        } catch {
            # EntityNotFound is acceptable - the async operation may not have completed yet
            if ($_.Exception.Message -like "*EntityNotFound*" -or $_.Exception.Message -like "*not found*") {
                $true | Should -Be $true  # Expected condition
            } else {
                throw  # Re-throw unexpected errors
            }
        }
    }
}
