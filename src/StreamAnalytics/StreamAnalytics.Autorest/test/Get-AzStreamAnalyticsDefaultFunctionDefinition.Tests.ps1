$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsDefaultFunctionDefinition.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsDefaultFunctionDefinition' {
    # Please add function of the stream analytics job in portal that type is Microsoft.MachineLearningServices. Then get endpoint of the machine learning services
    # Create machine learning services doc link:https://learn.microsoft.com/en-us/azure/machine-learning/tutorial-first-experiment-automated-ml
    It 'RetrieveExpanded' {
      Get-AzStreamAnalyticsDefaultFunctionDefinition -ResourceGroupName $env.resourceGroup -JobName $env.job01 -Name $env.mlsfunction -BindingType Microsoft.MachineLearningServices -Endpoint "http://875da830-4d5f-44f1-b221-718a5f26a21d.eastus.azurecontainer.io/score" -UdfType Scalar
    }
}
