$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzImageBuilderTemplate' {
    It 'Run' {
        Start-AzImageBuilderTemplate -Name $env.templateName -ResourceGroupName $env.rg
        $template = Get-AzImageBuilderTemplate -Name $env.templateName -ResourceGroupName $env.rg
        $template.LastRunStatusRunState | Should -Be 'Succeeded'
    }

    It 'RunViaIdentity' -Skip {
        $template = Get-AzImageBuilderTemplate -Name $env.templateName -ResourceGroupName $env.rg
        Start-AzImageBuilderTemplate -InputObject $template
        $template = Get-AzImageBuilderTemplate -Name $env.templateName -ResourceGroupName $env.rg
        $template.LastRunStatusRunState | Should -Be 'Succeeded'
    }
}
