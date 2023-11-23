if (($null -eq $TestName) -or ($TestName -contains 'Repair-AzDevCenterUserDevBox')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Repair-AzDevCenterUserDevBox.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Repair-AzDevCenterUserDevBox' {
    It 'Repair' {
        $repairOperation = Repair-AzDevCenterUserDevBox -Endpoint "https://003b06c3-d471-4452-9686-9e7f3ca85f0a-amlim-dc-euap.centraluseuap.devcenter.azure.com/" -Name "devbox2" -ProjectName "amlim-project"
        $repairOperation.Status | Should -Be "Succeeded"

        if ($Record -or $Live) {
            $repairOperation = Repair-AzDevCenterUserDevBox -DevCenterName "amlim-dc-euap" -Name "devbox3" -ProjectName "amlim-project"
            $repairOperation.Status | Should -Be "Succeeded"
        } }

    It 'RepairViaIdentity' {
        $devBoxInput = @{"DevBoxName" = "devbox4"; "UserId" = "me"; "ProjectName" = "amlim-project" }

        $repairOperation = Repair-AzDevCenterUserDevBox -Endpoint "https://003b06c3-d471-4452-9686-9e7f3ca85f0a-amlim-dc-euap.centraluseuap.devcenter.azure.com/" -InputObject $devBoxInput
        $repairOperation.Status | Should -Be "Succeeded"

        if ($Record -or $Live) {
            $repairOperation = Repair-AzDevCenterUserDevBox -DevCenterName "amlim-dc-euap" -InputObject $devBoxInput
            $repairOperation.Status | Should -Be "Succeeded"
        }
    }
}
