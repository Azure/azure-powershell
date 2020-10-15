$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDatabricksWorkspace.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDatabricksWorkspace' {
    It 'Delete' {
        $name = "databricks-test" + $env.rstr5
        New-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup -Location eastus
        { Remove-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $name = "databricks-test" + $env.rstr7
        $res = New-AzDatabricksWorkspace -Name $name -ResourceGroupName $env.resourceGroup -Location eastus
        { Remove-AzDatabricksWorkspace -InputObject $res } | Should -Not -Throw
    }
}
