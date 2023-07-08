if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDevCenterDevDelayDevBoxAction')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDevCenterDevDelayDevBoxAction.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDevCenterDevDelayDevBoxAction' {
    It 'Delay1' -skip {
        Invoke-AzDevCenterDevDelayDevBoxAction -Endpoint <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
        -DelayTime
    }

    It 'Delay' -skip {
        Invoke-AzDevCenterDevDelayDevBoxAction -Endpoint <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
        -ActionName <String> -DelayTime <TimeSpan>
    }

    It 'DelayViaIdentity' -skip {
        Invoke-AzDevCenterDevDelayDevBoxAction -Endpoint <String> -InputObject <IDevCenterdataIdentity> -DelayTime
    }

    It 'DelayViaIdentityByDevCenter' -skip {
        Invoke-AzDevCenterDevDelayDevBoxAction -DevCenter <String> -InputObject <IDevCenterdataIdentity> -DelayTime
    }

    It 'Delay1ByDevCenter' -skip {
        Invoke-AzDevCenterDevDelayDevBoxAction -DevCenter <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
        -DelayTime
    }

    It 'DelayByDevCenter' -skip {
        Invoke-AzDevCenterDevDelayDevBoxAction -DevCenter <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
        -ActionName <String> -DelayTime
    }
}
