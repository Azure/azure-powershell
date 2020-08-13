$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzImageBuilderTemplate' {
    It 'Cancel' {
        Start-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup -NoWait
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        Stop-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName10 -ResourceGroupName $env.ResourceGroup
        $template.LastRunStatusRunState | Should -Be 'Canceling'
    }

    It 'CancelViaIdentity' {
        Start-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup -NoWait
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup
        Stop-AzImageBuilderTemplate -InputObject $template
        $template = Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup
        $template.LastRunStatusRunState | Should -Be 'Canceling'
    }
}
