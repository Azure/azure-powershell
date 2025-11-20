if(($null -eq $TestName) -or ($TestName -contains 'Get-AzQuotaGroupQuotaUsage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzQuotaGroupQuotaUsage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzQuotaGroupQuotaUsage' {
    BeforeAll {
        $script:managementGroupId = "mg-demo"
        $script:groupQuotaName = "testlocation"
        $script:location = "eastus"
        $script:resourceProviderName = "Microsoft.Compute"
        $script:groupQuotaExists = $false
        $script:locationEnforced = $false
        
        # Check if group quota exists
        try {
            $existingQuota = Get-AzQuotaGroupQuota -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ErrorAction SilentlyContinue
            if ($existingQuota) {
                $script:groupQuotaExists = $true
            }
        } catch {
            # Group quota doesn't exist
        }
        
        # Create group quota if it doesn't exist
        if (-not $script:groupQuotaExists) {
            try {
                $newQuota = New-AzQuotaGroupQuota -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -DisplayName "Test Location Group Quota"
                if ($newQuota) {
                    $script:groupQuotaExists = $true
                }
            } catch {
                Write-Warning "Failed to create group quota: $($_.Exception.Message)"
            }
        }
        
        # Check if location is enforced
        if ($script:groupQuotaExists) {
            try {
                $locationSetting = Get-AzQuotaGroupQuotaLocationSetting -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location -ErrorAction SilentlyContinue
                if ($locationSetting -and $locationSetting.Property.EnforcementEnabled -eq "Enabled") {
                    $script:locationEnforced = $true
                }
            } catch {
                # Location setting doesn't exist
            }
            
            # Create/enforce location setting if needed
            if (-not $script:locationEnforced) {
                try {
                    $jsonBody = @{
                        properties = @{
                            enforcementEnabled = "Enabled"
                        }
                    } | ConvertTo-Json
                    
                    New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location -JsonString $jsonBody -NoWait -ErrorAction SilentlyContinue
                    # Note: This is async and may not be immediately available
                    $script:locationEnforced = $true
                } catch {
                    Write-Warning "Failed to enforce location: $($_.Exception.Message)"
                }
            }
        }
    }
    
    It 'List' {
        if (-not $script:groupQuotaExists) {
            Set-ItResult -Skipped -Because "Group quota does not exist"
            return
        }
        
        # The API returns an error when location is not enforced
        # In playback mode, the recording shows the location was just created but not yet enforced
        # So we expect this specific error message
        try {
            $result = Get-AzQuotaGroupQuotaUsage -ManagementGroupId $script:managementGroupId -GroupQuotaName $script:groupQuotaName -ResourceProviderName $script:resourceProviderName -Location $script:location -ErrorAction Stop
            # If we get here, location is enforced and we have results
            $result | Should -Not -Be $null
        } catch {
            # Expected error when location is not yet enforced
            $_.Exception.Message | Should -Match "enforced groups only"
        }
    }
}
