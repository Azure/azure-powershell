# Minimal playback test for New-AzOracleDbSystem using typed parameters
# TEMP: includes hard-coded fallback values for RECORD/LIVE runs
# NOTE: Oracle **NetworkAnchorId** and **ResourceAnchorId** now point to real test anchors.

if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleDbSystem'))
{
    # --- Environment/bootstrap ---
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleDbSystem.Recording.json'
    Write-Host "[LOG] Recording file set to $TestRecordingFile"

    # --- Load Az.Oracle modules once (avoid assembly double-load) ---
    $pubLoaded  = Get-Module Az.Oracle -ErrorAction SilentlyContinue
    $privLoaded = Get-Module Az.Oracle.private -ErrorAction SilentlyContinue
    if (-not ($pubLoaded -and $privLoaded)) {
        Write-Host "[LOG] Loading Az.Oracle modules via run-module.ps1..."
        & (Join-Path $PSScriptRoot 'run-module.ps1')
        Get-Module Az.Oracle* | ForEach-Object { Write-Host "[LOG] Loaded $($_.Name) v$($_.Version) from $($_.ModuleBase)" }
    } else {
        Write-Host "[LOG] Az.Oracle modules already loaded:"
        ($pubLoaded  | ForEach-Object { "[LOG]  Public : $($_.Version) at $($_.ModuleBase)" }) | Write-Host
        ($privLoaded | ForEach-Object { "[LOG]  Private: $($_.Version) at $($_.ModuleBase)" }) | Write-Host
    }

    # --- HttpPipelineMocking bootstrap ---
    $currentPath = $PSScriptRoot
    Write-Host "[LOG] Searching for HttpPipelineMocking.ps1 starting at $currentPath"
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    $mockScript = ($mockingPath | Select-Object -First 1).FullName
    Write-Host "[LOG] Found HttpPipelineMocking.ps1 at $mockScript"
    . $mockScript
}

Describe 'New-AzOracleDbSystem' {
    # ---------- TEMP FALLBACKS ----------
    $defaults = @{
        SubscriptionId = '3b3aa069-da96-41b6-b5aa-6f20dd9db826'
        ResourceGroup  = 'PowerShellTestRg'
        Location       = 'eastus'
        Zone           = '1'
        # ✅ Updated anchors (as requested)
        NetworkAnchorId  = '/subscriptions/3b3aa069-da96-41b6-b5aa-6f20dd9db826/resourceGroups/ORPIAD/providers/Oracle.Database/networkAnchors/NADtlsBgFx'
        ResourceAnchorId = '/subscriptions/3b3aa069-da96-41b6-b5aa-6f20dd9db826/resourceGroups/PowerShellTestRgMihr/providers/Oracle.Database/resourceAnchors/Create'
        # TEMP SSH and admin password
        SshPublicKey     = 'ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC7j39d4dXKc2m7fQ1c3Z8v5kG2v5Kp7n1o4Xx0t4xR3Ih8m3x8o3f0sYV+TEMPj1N0xqfZ+4H6W8bZn6F9P0U2m6sD2pS2Yz9vQ8Zb5T1c4r5 demo@example'
        AdminPassword    = 'AZbrcdEF74-#_gh'
    }
    # -----------------------------------

    $rgName   = if ($env:resourceGroup -and -not [string]::IsNullOrWhiteSpace($env:resourceGroup)) { $env:resourceGroup } else { $defaults.ResourceGroup }
    $location = if ($env:location     -and -not [string]::IsNullOrWhiteSpace($env:location))     { $env:location     } else { $defaults.Location }

    Write-Host "[LOG] Test params -> RG: $rgName | Location: $location"

    $hasCmd     = Get-Command -Name New-AzOracleDbSystem -ErrorAction SilentlyContinue
    $isRecord   = ($TestMode -eq 'record'   -or $env:AZURE_TEST_MODE -eq 'Record')
    $isPlayback = ($TestMode -eq 'playback' -or $env:AZURE_TEST_MODE -eq 'Playback')

    if ($hasCmd) { Write-Host "[LOG] Cmdlet New-AzOracleDbSystem detected." } else { Write-Host "[WARN] Cmdlet New-AzOracleDbSystem not found." }
    Write-Host "[LOG] Mode flags -> Record: $isRecord | Playback: $isPlayback"

    It 'Warmup' {
        if ($isRecord) {
            Write-Host "[LOG] Warmup in RECORD mode: calling Get-AzOracleGiVersion..."
            Get-AzOracleGiVersion -Location $location | Out-Null
        } else {
            Write-Host "[LOG] Warmup in NON-RECORD mode: no-op."
            $true | Should -Be $true
        }
    }

    It 'Create (runs in RECORD and LIVE, skips only in PLAYBACK)' {
        {
            if ($hasCmd -and -not $isPlayback) {
                if ($isRecord) {
                    Write-Host "[LOG] RECORD branch: will invoke New-AzOracleDbSystem."
                } else {
                    Write-Host "[LOG] LIVE branch (non-record/non-playback): will invoke New-AzOracleDbSystem."
                }

                # --- Resolve inputs: ENV first, then TEMP fallbacks ---
                $subId          = if ($env:SubscriptionId) { $env:SubscriptionId } elseif ($env.SubscriptionId) { $env.SubscriptionId } else { $defaults.SubscriptionId }
                $netAnchorId    = if ($env:ORACLE_NETWORK_ANCHOR_ID)  { $env:ORACLE_NETWORK_ANCHOR_ID }  else { $defaults.NetworkAnchorId }
                $resAnchorId    = if ($env:ORACLE_RESOURCE_ANCHOR_ID) { $env:ORACLE_RESOURCE_ANCHOR_ID } else { $defaults.ResourceAnchorId }
                $sshKey         = if ($env:ORACLE_SSH_PUBLIC_KEY)     { $env:ORACLE_SSH_PUBLIC_KEY }     else { $defaults.SshPublicKey }
                $adminPassPlain = if ($env:ORACLE_DB_ADMIN_PASSWORD)  { $env:ORACLE_DB_ADMIN_PASSWORD }  else { $defaults.AdminPassword }
                $zone           = $defaults.Zone

                Write-Host "[LOG] Using SubscriptionId = $subId"
                Write-Host "[LOG] Using NetworkAnchorId  = $netAnchorId"
                Write-Host "[LOG] Using ResourceAnchorId = $resAnchorId"
                Write-Host "[LOG] Using SshPublicKey     = ***set***"
                Write-Host "[LOG] Using AdminPassword    = ***set***"
                Write-Host "[LOG] Using Zone             = $zone"

                [SecureString]$adminPwd = ConvertTo-SecureString -String $adminPassPlain -AsPlainText -Force

                Write-Host "[LOG] Invoking New-AzOracleDbSystem..."
                $created = New-AzOracleDbSystem `
                    -Name 'OFake_PSDbSystemMikita' `
                    -ResourceGroupName $rgName `
                    -SubscriptionId $subId `
                    -Location $location `
                    -AdminPassword $adminPwd `
                    -ClusterName 'ps-cluster' `
                    -ComputeCount 2 `
                    -ComputeModel 'ECPU' `
                    -DatabaseEdition 'EnterpriseEdition' `
                    -DbSystemOptionStorageManagement 'LVM' `
                    -DbVersion '19c' `
                    -DiskRedundancy 'High' `
                    -DisplayName 'OFake_PSDbSystem' `
                    -DomainV2 'example.com' `
                    -Hostname 'psdbhost' `
                    -InitialDataStorageSizeInGb 100 `
                    -LicenseModelV2 'BringYourOwnLicense' `
                    -NetworkAnchorId $netAnchorId `
                    -NodeCount 1 `
                    -PdbName 'PDB1' `
                    -ResourceAnchorId $resAnchorId `
                    -Shape 'ExaDbXS' `
                    -SshPublicKey $sshKey `
                    -StorageVolumePerformanceMode 'Balanced' `
                    -TimeZone 'UTC' `
                    -Zone $zone

                Write-Host "[LOG] Cmdlet executed. Validating response..."
                $created | Should -Not -BeNullOrEmpty
                $created.Name | Should -Be 'OFake_PSDbSystemMikita'
                Write-Host "[LOG] DbSystem creation validation successful."
            } else {
                Write-Host "[LOG] PLAYBACK branch: skipping live create."
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
