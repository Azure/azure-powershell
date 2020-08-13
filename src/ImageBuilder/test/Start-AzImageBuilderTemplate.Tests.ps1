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
        Start-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup
        $template.LastRunStatus.RunState | Should -Be 'Succeeded'
    }

    It 'RunViaIdentity' {
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup
        Start-AzImageBuilderTemplate -InputObject $template
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup
        $template.LastRunStatus.RunState | Should -Be 'Succeeded'
    }
}
