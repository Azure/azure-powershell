$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataMigrationSqlServiceNode.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDataMigrationSqlServiceNode' {
    It 'DeleteExpanded' -skip {
        $temp =  Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName $env.RemoveNode.GroupName -SqlMigrationServiceName $env.RemoveNode.SqlMigrationServiceName
        $nodeList = $temp.Node
        $cnt1 = $nodeList.Count
        if($cnt1 -eq 0)
        {
            $assert = $true
            $assert | should be $true
        }
        else{
            $instance =  Remove-AzDataMigrationSqlServiceNode -ResourceGroupName $env.RemoveNode.GroupName -SqlMigrationServiceName $env.RemoveNode.SqlMigrationServiceName -NodeName $nodeList[0].NodeName
            $temp =  Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName $env.RemoveNode.GroupName -SqlMigrationServiceName $env.RemoveNode.SqlMigrationServiceName
            $nodeList = $temp.Node
            $cnt2 = $nodeList.Count
            $assert = ($cnt1-$cnt2 -eq 1)
            $assert | should be $true
        }
    }

    It 'DeleteViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
