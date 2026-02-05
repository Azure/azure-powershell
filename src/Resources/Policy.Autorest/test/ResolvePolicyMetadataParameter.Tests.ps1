# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'ResolvePolicyMetadataParameter'

# This validates the ResolvePolicyMetadataParameter function that parses the Metadata parameter value for several cmdlets
Describe 'ResolvePolicyMetadataParameter' { 

    BeforeAll {
        $simplePSObjectMetadata = @'
@{
    version    = "1.0.0";
    category   = "ScenarioTest";
    enabled    = false;
    createdOn  = "10/04/2024 00:20:02";
    createdOnWithoutQuotes  = 10/04/2024 00:20:02;
    dateTimeTestVal = "2024-10-04T00:20:02Z";
    mixedStringNumber = "Test123 Value";
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
        $resolved = ResolvePolicyMetadataParameter -MetadataValue $simplePSObjectMetadata
        $resolved.version | Should -Be '1.0.0'
        $resolved.category | Should -Be 'ScenarioTest'
        $resolved.enabled | Should -Be "false"
        $resolved.createdOn | Should -Be '10/04/2024 00:20:02'
        $resolved.createdOnWithoutQuotes | Should -Be '10/04/2024 00:20:02'
        $resolved.dateTimeTestVal | Should -Be '2024-10-04T00:20:02Z'
        $resolved.mixedStringNumber | Should -Be 'Test123 Value'
    }

    It 'Parse complex PSObject metadata' {
        $resolved = ResolvePolicyMetadataParameter -MetadataValue $complexPSObjectMetadata
        $resolved.version | Should -Be '1.0.0'
        $resolved.category | Should -Be 'ScenarioTest'
        $resolved.tags | Should -Contain 'ps'
        $resolved.details.location | Should -Be 'Redmond'
        $resolved.config.enabled | Should -BeTrue
        $resolved.config.retries | Should -Be 3
        $resolved.config.limits.maxItems | Should -Be 100
    }

    It 'Parse hashtable string metadata' {
        $resolved = ResolvePolicyMetadataParameter -MetadataValue $hashtableStringMetadata
        $resolved.name | Should -Be 'Alice'
        $resolved.enabled | Should -BeFalse
        $resolved.count | Should -Be 5
    }

    It 'Parse complex hashtable string metadata' {
        $resolved = ResolvePolicyMetadataParameter -MetadataValue $complexHashtableStringMetadata
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
            $resolved = ResolvePolicyMetadataParameter -MetadataValue $metadata
            $resolved.TestKey | Should -Be 'TestValue'
        }
        finally {
            # clean up the temporary file
            Remove-Item -Path $metadata -ErrorAction SilentlyContinue -Force
        }
    }

    It 'Ensure parsing invalid JSON metadata throws' {
        { ResolvePolicyMetadataParameter -MetadataValue $invalidJson } | Should -Throw 'Unrecognized metadata format - value: [{ "name": "Bob", "enabled": true ], type: [string]'
    }

    It 'Parse nested arrays in metadata' {
        $nestedArrayMetadata = '{ "name": "NestedTest", "matrix": [[1,2,3],[4,5,6],[7,8,9]], "tags": [["a","b"],["c","d"]] }'
        $resolved = ResolvePolicyMetadataParameter -MetadataValue $nestedArrayMetadata
        $resolved.name | Should -Be 'NestedTest'
        $resolved.matrix[0] | Should -Be @(1,2,3)
        $resolved.matrix[2][1] | Should -Be 8
        $resolved.tags[1] | Should -Be @('c','d')
    }

    It 'Ensure parsing invalid hashtable literal throws' {
        $invalidHashtable = '@{ version = "1.0.0"; category "ScenarioTest"; enabled = false; }'
        { ResolvePolicyMetadataParameter -MetadataValue $invalidHashtable } | Should -Throw 'Invalid PSCustomObject or hashtable literal'
    }

    It 'Parse hashtable converted to PSCustomObject' {
        $metadataPreConversion = "{'Meta1': 'Value1', 'Meta2': { 'Meta22': 'Value22' }, 'Meta3': null}"
        
        # Convert string to JSON format seen when piped between cmdlets
        $jsonString = $metadataPreConversion | ConvertFrom-Json

        # Convert to PSCustomObject and then attempt to resolve
        $psCustomObject = ConvertObjectToPSObject $jsonString
        $resolved = ResolvePolicyMetadataParameter -MetadataValue $psCustomObject
        $resolved.Meta1 | Should -Be 'Value1'
        $resolved.Meta2.Meta22 | Should -Be 'Value22'
        $resolved.Meta3 | Should -Be $null
    }
}