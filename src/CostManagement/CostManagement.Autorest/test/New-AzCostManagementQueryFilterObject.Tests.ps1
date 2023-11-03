$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCostManagementQueryFilterObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzCostManagementQueryFilterObject' {
    It '__AllParameterSets' {
        { 
            $orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Operator 'In' -Value @('East US', 'West Europe') 
            $orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Operator 'In' -Value @('UAT', 'Prod') 
            $andOr = New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimension $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))

            $dimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Operator 'In' -Value 'API'
            $andDimension = New-AzCostManagementQueryFilterObject -Dimension $dimension
            $fileter = New-AzCostManagementQueryFilterObject -And @($andOr, $andDimension) 
        } | Should -Not -Throw
    }
}
