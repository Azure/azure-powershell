. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Backup-AzWebApp' {
    It 'BackupBySiteObject' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
