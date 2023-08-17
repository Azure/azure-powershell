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
        Remove-AzImageBuilderTemplate -Name $env.newTemplateName1 -ResourceGroupName $env.rg
        $template = Get-AzImageBuilderTemplate -ResourceGroupName $env.rg 
        $template.Name| Should -Not -Contain $env.newTemplateName1
    }

    It 'DeleteViaIdentity' {
        $template2 =  Get-AzImageBuilderTemplate -Name $env.newTemplateName2 -ResourceGroupName $env.rg
        Remove-AzImageBuilderTemplate -InputObject $template2
        $template = Get-AzImageBuilderTemplate -ResourceGroupName $env.rg
        $template.Name| Should -Not -Contain $env.newTemplateName2
    }
}
