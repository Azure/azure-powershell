# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

Describe 'Elastic SAN volume compatibility' {
    It 'Retains the writable string property on IVolume' {
        $property = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IVolume].GetProperty('ManagedByResourceId')
        $property.PropertyType | Should -Be ([string])
        $property.CanRead | Should -Be $true
        $property.CanWrite | Should -Be $true
    }

    It 'Maps the legacy property to the new managedBy wire format' {
        $volume = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::new()
        $volume.ManagedByResourceId = '/subscriptions/test/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm'
        $volume.ManagedBy.Count | Should -Be 1
        $volume.ManagedBy[0].ResourceId.Count | Should -Be 1
        $volume.ManagedBy[0].ResourceId[0] | Should -Be $volume.ManagedByResourceId
        $json = $volume.ToString() | ConvertFrom-Json
        $json.properties.managedBy[0].resourceIds[0] | Should -Be $volume.ManagedByResourceId
        $json.properties.PSObject.Properties.Name | Should -Not -Contain 'managedByResourceId'
        $json.properties.PSObject.Properties.Name | Should -Not -Contain 'resourceId'
    }

    It 'Projects the first ID without modifying multiple owners' {
        $owner = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.ManagedByResources]::new()
        $owner.ResourceId = @('first', 'second')
        $volume = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::new()
        $volume.ManagedBy = @($owner)
        $volume.ManagedByResourceId | Should -Be 'first'
        $volume.ManagedBy[0].ResourceId.Count | Should -Be 2
        $volume.ManagedByResourceId = 'replacement'
        $volume.ManagedBy[0].ResourceId.Count | Should -Be 1
        $volume.ManagedByResourceId | Should -Be 'replacement'
        $volume.ManagedByResourceId = $null
        $volume.ManagedBy | Should -BeNullOrEmpty
        $volume.ManagedByResourceId | Should -BeNullOrEmpty
    }

    It 'Accepts legacy hashtable and PSObject inputs' {
        $volume = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::DeserializeFromDictionary(@{ ManagedByResourceId = 'legacy' })
        $volume.ManagedBy[0].ResourceId[0] | Should -Be 'legacy'
        $volume = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::DeserializeFromPSObject([pscustomobject]@{ ManagedByResourceId = 'legacy' })
        $volume.ManagedBy[0].ResourceId[0] | Should -Be 'legacy'
        $volume = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::DeserializeFromDictionary(@{ ManagedByResourceId = $null })
        $volume.ManagedBy | Should -BeNullOrEmpty
    }

    It 'Preserves array-only inputs and all resource IDs' {
        $volume = [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::DeserializeFromDictionary(@{
            ManagedBy = @(@{ ResourceId = @('first', 'second') })
        })
        $volume.ManagedByResourceId | Should -Be 'first'
        $volume.ManagedBy[0].ResourceId.Count | Should -Be 2
    }

    It 'Rejects hashtable and PSObject inputs specifying both properties' {
        { [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::DeserializeFromDictionary(@{ ManagedByResourceId = 'legacy'; ManagedBy = @() }) } | Should -Throw 'Specify either ManagedBy or ManagedByResourceId, not both.'
        { [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume]::DeserializeFromPSObject([pscustomobject]@{ ManagedByResourceId = 'legacy'; ManagedBy = @() }) } | Should -Throw 'Specify either ManagedBy or ManagedByResourceId, not both.'
    }

    It 'Exports Restore from the parent module' {
        $moduleRoot = Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
        $parentManifest = Join-Path $moduleRoot 'Az.ElasticSan.psd1'
        if (-not (Test-Path $parentManifest)) {
            $parentManifest = Join-Path (Join-Path $moduleRoot 'ElasticSan') 'Az.ElasticSan.psd1'
        }
        (Import-PowerShellDataFile $parentManifest).FunctionsToExport | Should -Contain 'Restore-AzElasticSanVolume'
        (Get-Command Restore-AzElasticSanVolume -Module Az.ElasticSan -ErrorAction Stop).Name | Should -Be 'Restore-AzElasticSanVolume'
    }

    It 'Preserves the existing throughput parameter name' {
        (Get-Command Update-AzElasticSan -Module Az.ElasticSan -ErrorAction Stop).Parameters.ContainsKey('TotalMBps') | Should -Be $true
    }
}
