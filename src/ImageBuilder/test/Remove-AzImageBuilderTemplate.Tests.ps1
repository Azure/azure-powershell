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
        Remove-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName13 -ResourceGroupName $env.ResourceGroup
        $template = Get-AzImageBuilderTemplate -ResourceGroupName $env.ResourceGroup 
        $template.Name| Should -Not -Contain $env.Resources.Template.templateName13
    }

    It 'DeleteViaIdentity' {
        $template =  Get-AzImageBuilderTemplate -ImageTemplateName $env.Resources.Template.templateName16 -ResourceGroupName $env.ResourceGroup
        Remove-AzImageBuilderTemplate -InputObject $template
        $template = Get-AzImageBuilderTemplate -ResourceGroupName $env.ResourceGroup
        $template.Name| Should -Not -Contain $env.Resources.Template.templateName16
    }
}
