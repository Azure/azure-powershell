# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'ResolvePolicyMetadataParameter'

# This validates the ResolvePolicyMetadataParameter function that parses the Metadata parameter value for several cmdlets
Describe 'ResolvePolicyMetadataParameter' { 

    BeforeAll {
        $simplePSObjectMetadata= @'
@{
    version    = "1.0.0";
    category   = "ScenarioTest";
}
'@
        $complexPSObjectMetadata = @'
@{
    version    = "1.0.0";
    category   = "ScenarioTest";
    tags       = @("ps", "safe", "nested");
    details    = @{
        location = "Redmond";
        level    = "Senior";
        features = @("AST", "Parser", "Security");
    };
    config     = @{
        retries = 3;
        enabled = $true;
        limits  = @{
            maxItems = 100;
            timeout  = 30;
        };
    };
}
'@
        $hashtableStringMetadata = '{ "name": "Alice", "enabled": false, "count": 5 }'
        $complexHashtableStringMetadata = '{ "name": "Bob", "enabled": true, "details": { "location": "NYC", "level": "Junior", "skills": ["PowerShell", "Azure", "DevOps"] }, "config": { "retries": 2, "limits": { "maxItems": 50, "timeout": 15 } } }'
        $invalidJson = '{ "name": "Bob", "enabled": true '
    }

    It 'Parse simple PSObject metadata' {
        $resolved = ResolvePolicyMetadataParameter -Metadata $simplePSObjectMetadata
        $resolved.version | Should -Be '1.0.0'
        $resolved.category | Should -Be 'ScenarioTest'
    }

    It 'Parse complex PSObject metadata' {
        $resolved = ResolvePolicyMetadataParameter -Metadata $complexPSObjectMetadata
        $resolved.version | Should -Be '1.0.0'
        $resolved.category | Should -Be 'ScenarioTest'
        $resolved.tags | Should -Contain 'ps'
        $resolved.details.location | Should -Be 'Redmond'
        $resolved.config.enabled | Should -BeTrue
        $resolved.config.retries | Should -Be 3
        $resolved.config.limits.maxItems | Should -Be 100
    }

    It 'Parse hashtable string metadata' {
        $resolved = ResolvePolicyMetadataParameter -Metadata $hashtableStringMetadata
        $resolved.name | Should -Be 'Alice'
        $resolved.enabled | Should -BeFalse
        $resolved.count | Should -Be 5
    }

    It 'Parse complex hashtable string metadata' {
        $resolved = ResolvePolicyMetadataParameter -Metadata $complexHashtableStringMetadata
        $resolved.name | Should -Be 'Bob'
        $resolved.enabled | Should -BeTrue
        $resolved.details.location | Should -Be 'NYC'
        $resolved.details.skills | Should -Contain 'Azure'
        $resolved.config.limits.timeout | Should -Be 15
    }

    It 'Parse metadata in file content' {
        # create a temporary file with metadata content
        $fileContent = '{"TestKey": "TestValue"}'
        $metadata = Join-Path $PSScriptRoot 'PolicyMetadata.json'
        Set-Content -Path $metadata -Value $fileContent
        try {
            $resolved = ResolvePolicyMetadataParameter -Metadata $metadata
            $resolved.TestKey | Should -Be 'TestValue'
        }
        finally {
            # clean up the temporary file
            Remove-Item -Path $metadata -ErrorAction SilentlyContinue -Force
        }
    }

    It 'Ensure parsing invalid JSON metadata throws' {
        { ResolvePolicyMetadataParameter -Metadata $invalidJson } | Should -Throw 'Unrecognized metadata format - value: [{ "name": "Bob", "enabled": true ], type: [string]'
    }

    It 'Parse nested arrays in metadata' {
        $nestedArrayMetadata = '{ "name": "NestedTest", "matrix": [[1,2,3],[4,5,6],[7,8,9]], "tags": [["a","b"],["c","d"]] }'
        $resolved = ResolvePolicyMetadataParameter -Metadata $nestedArrayMetadata
        $resolved.name | Should -Be 'NestedTest'
        $resolved.matrix[0] | Should -Be @(1,2,3)
        $resolved.matrix[2][1] | Should -Be 8
        $resolved.tags[1] | Should -Be @('c','d')
    }
}