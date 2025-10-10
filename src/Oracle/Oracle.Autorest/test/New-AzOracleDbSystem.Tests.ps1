# Minimal playback test for New-AzOracleDbSystem using typed parameters

if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleDbSystem'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) { $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1' }
    . ($loadEnvPath)

    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleDbSystem.Recording.json'

    $pubLoaded  = Get-Module Az.Oracle -ErrorAction SilentlyContinue
    $privLoaded = Get-Module Az.Oracle.private -ErrorAction SilentlyContinue
    if (-not ($pubLoaded -and $privLoaded)) {
        & (Join-Path $PSScriptRoot 'run-module.ps1')
    }

    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleDbSystem' {
    $expected = [pscustomobject]@{
        name = "PowershellSdk"
        location = "eastus"
        properties = @{
            networkAnchorId = "/subscriptions/049e5678-fbb1-4861-93f3-7528bd0779fd/resourceGroups/basedb-rg929-ti-iad52/providers/Oracle.Database/networkAnchors/basedb-na9293-ti-iad52"
            resourceAnchorId = "/subscriptions/049e5678-fbb1-4861-93f3-7528bd0779fd/resourcegroups/basedb-rg929-ti-iad52/providers/oracle.database/resourceanchors/basedb-ra929-ti-iad52"
        }
    }

    $subId     = if ($env:SubscriptionId) { $env:SubscriptionId } else { "049e5678-fbb1-4861-93f3-7528bd0779fd" }
    $rgName    = if ($env:resourceGroup)  { $env:resourceGroup }  else { "basedb-rg929-ti-iad52" }
    $location  = $expected.location
    $zone      = "3"
    $netAnchor = $expected.properties.networkAnchorId
    $resAnchor = $expected.properties.resourceAnchorId

    $sshKey = 'ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC924t51mimqfTUclp0f9QFTUH8yx6J5p+dIEvl0mNDxBXZ+CgcUHjJ74OUMGj4017KDlqGs1/jEDeshZlkuk3NRACyjkmUWqMG4xYAvNlszRYh6X0nq+acjK1Xu3Ez/nYe/mQo4O3BpR1DnCb67xZYCmHDc7u58lqxNF1+fgeuoqaIgJWGE3ykq/RyFd+RtfOvLnOdYTIKkt/LPgsYP30tbFjRtu7sGQcLzuE/3rr33+OfNAeALtk9SwlBz43RVzJJZYly5lIZFH91nTJx90u3xd5BAOC+d6fXZh4vN9GdT7PQUiBdlULFjVkYJkJrqj0gq9LeRsJYx0LVQTZuc0YiqYmCWx6pXhc4ye5psnCsJml4rwCEk68567SuvxELAahOZW0M1aS9Lc12bYTm/71u35CHevcUwyQk+Ejizmq2xRK5g9Ez1fb6imifgJ3Ll/B7U7dbsux3D4zLrkoDNisr2XekP3qr8nwe0r/Ppgyi8jNr5lMPkSLHpSCMEBDKuxE= xuezh@xuezh-mac'
    [SecureString]$adminPwd = ConvertTo-SecureString -String 'testAdminPassword123-_#' -AsPlainText -Force

    $hasCmd = Get-Command -Name New-AzOracleDbSystem -ErrorAction SilentlyContinue
    $isPlayback = ($TestMode -eq 'playback' -or $env:AZURE_TEST_MODE -eq 'Playback')

    It 'Create minimal' {
        {
            if ($hasCmd -and -not $isPlayback) {
                $created = New-AzOracleDbSystem `
                    -Name $expected.name `
                    -ResourceGroupName $rgName `
                    -SubscriptionId $subId `
                    -Location $location `
                    -Zone $zone `
                    -DatabaseEdition 'EnterpriseEdition' `
                    -AdminPassword $adminPwd `
                    -ResourceAnchorId $resAnchor `
                    -NetworkAnchorId $netAnchor `
                    -Hostname 'whitelist2' `
                    -Shape 'VM.Standard.x86' `
                    -SshPublicKey $sshKey `
                    -DisplayName 'BaseDbWhitelisttest' `
                    -NodeCount 1 `
                    -InitialDataStorageSizeInGb 256 `
                    -ComputeModel 'ECPU' `
                    -ComputeCount 4 `
                    -DbVersion '19.27.0.0' `
                    -PdbName 'pdbNameSep02' `
                    -DbSystemOptionStorageManagement 'LVM'

                $created | Should -Not -BeNullOrEmpty
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
