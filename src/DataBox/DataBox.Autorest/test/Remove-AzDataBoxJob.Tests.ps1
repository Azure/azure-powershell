$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataBoxJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDataBoxJob' {
    It 'Delete'{
        Remove-AzDataBoxJob -Name $env.JobNameImport -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId  
        Remove-AzDataBoxJob -Name $env.JobNameUAI -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId   
        Remove-AzDataBoxJob -Name $env.JobNameExport -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId   
        Remove-AzDataBoxJob -Name $env.JobNameScheduleOrder -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId  
        Remove-AzDataBoxJob -Name $env.JobNameHeavy -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId   
        Remove-AzDataBoxJob -Name $env.JobNameDisk -ResourceGroupName $env.ResourceGroup -SubscriptionId $env.SubscriptionId    
    }
}
