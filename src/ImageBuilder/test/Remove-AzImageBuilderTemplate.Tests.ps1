$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzImageBuilderTemplate.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzImageBuilderTemplate' {
    It 'Delete' {
        Remove-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup
        (Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName11 -ResourceGroupName $env.ResourceGroup) | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $template =  Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup
        Remove-AzImageBuilderTemplate -InputObject $template
        (Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName12 -ResourceGroupName $env.ResourceGroup) | Should -Throw
    }
}
