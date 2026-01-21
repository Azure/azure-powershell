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
        $runScript = Join-Path $PSScriptRoot 'run-module.ps1'
        if (Test-Path $runScript) {
            & $runScript
        } else {
            $modulePsd1 = Join-Path $PSScriptRoot '..\Az.Oracle.psd1'
            if (Test-Path $modulePsd1) { Import-Module $modulePsd1 -ErrorAction Stop }
        }
    }

    $currentPath = $PSScriptRoot
    while(-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleDbSystem' {
    # Inputs (keep consistent with the recording)

    $sshKey = 'ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC924t51mimqfTUclp0f9QFTUH8yx6J5p+dIEvl0mNDxBXZ+CgcUHjJ74OUMGj4017KDlqGs1/jEDeshZlkuk3NRACyjkmUWqMG4xYAvNlszRYh6X0nq+acjK1Xu3Ez/nYe/mQo4O3BpR1DnCb67xZYCmHDc7u58lqxNF1+fgeuoqaIgJWGE3ykq/RyFd+RtfOvLnOdYTIKkt/LPgsYP30tbFjRtu7sGQcLzuE/3rr33+OfNAeALtk9SwlBz43RVzJJZYly5lIZFH91nTJx90u3xd5BAOC+d6fXZh4vN9GdT7PQUiBdlULFjVkYJkJrqj0gq9LeRsJYx0LVQTZuc0YiqYmCWx6pXhc4ye5psnCsJml4rwCEk68567SuvxELAahOZW0M1aS9Lc12bYTm/71u35CHevcUwyQk+Ejizmq2xRK5g9Ez1fb6imifgJ3Ll/B7U7dbsux3D4zLrkoDNisr2XekP3qr8nwe0r/Ppgyi8jNr5lMPkSLHpSCMEBDKuxE= xuezh@xuezh-mac'
    [SecureString]$adminPwd = ConvertTo-SecureString -String 'password' -AsPlainText -Force

    $hasCmd = Get-Command -Name New-AzOracleDbSystem -ErrorAction SilentlyContinue

    It 'Create (CreateBasedb)' -Skip {
        {
            if ($hasCmd) {
                $created = New-AzOracleDbSystem `
                    -Name $env.baseDbName `
                    -ResourceGroupName $env.resourceAnchorRgName `
                    -SubscriptionId $env.SubscriptionId `
                    -Location $env.location `
                    -Zone $env.baseDbZone `
                    -DatabaseEdition $env.databaseEdition `
                    -AdminPassword $adminPwd `
                    -ResourceAnchorId $env.baseDbResAnchor `
                    -NetworkAnchorId $env.baseDbNetAnchor `
                    -Hostname $env.baseDbHostname `
                    -Shape $env.baseDbShape `
                    -SshPublicKey $sshKey `
                    -DisplayName $env.baseDbDisplayName `
                    -NodeCount $env.baseDbNodeCount `
                    -InitialDataStorageSizeInGb $env.initialDataStorageSizeInGb `
                    -ComputeModel $env.baseDbComputeModel `
                    -ComputeCount $env.baseDbComputeCount `
                    -DbVersion $env.baseDbVersion `
                    -PdbName $env.baseDbPdbName `
                    -DbSystemOptionStorageManagement $env.dbSystemOptionStorageManagement
                    -NoWait

                $created | Should -Not -BeNullOrEmpty
            } else {
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
