# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

Describe 'Elastic SAN volume compatibility' {
    It 'Loads the complete parent manifest surface and private assembly from the imported module' {
        $parentModules = @(Get-Module -All Az.ElasticSan -ErrorAction Stop | Where-Object {
            $_.NestedModules | Where-Object Name -EQ 'Az.ElasticSan'
        })
        $parentModules.Count | Should -Be 1 -Because 'exactly one parent module must be loaded for package validation'
        $module = $parentModules[0]
        $manifestPath = Join-Path $module.ModuleBase 'Az.ElasticSan.psd1'
        $manifest = Test-ModuleManifest -Path $manifestPath -ErrorAction Stop
        $manifest.Name | Should -Be 'Az.ElasticSan'
        $data = Import-PowerShellDataFile $manifestPath
        Compare-Object @($data.FunctionsToExport | Sort-Object) @($module.ExportedFunctions.Keys | Sort-Object) | Should -BeNullOrEmpty
        $expectedAssembly = Join-Path (Join-Path (Join-Path $module.ModuleBase 'ElasticSan.Autorest') 'bin') 'Az.ElasticSan.private.dll'
        [Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Volume].Assembly.Location | Should -Be (Resolve-Path $expectedAssembly).Path
    }

    Describe 'Elastic SAN IOPS output compatibility' {
        $models = @(
            @{ Model = 'ElasticSan'; Property = 'TotalReservedIops'; Alias = 'TotalReservedIop'; WireName = 'totalReservedIops'; Nested = $true; Writable = $false },
            @{ Model = 'ElasticSanProperties'; Property = 'TotalReservedIops'; Alias = 'TotalReservedIop'; WireName = 'totalReservedIops'; Nested = $false; Writable = $false },
            @{ Model = 'VolumeGroup'; Property = 'ReservedIops'; Alias = 'ReservedIop'; WireName = 'reservedIops'; Nested = $true; Writable = $true },
            @{ Model = 'VolumeGroupProperties'; Property = 'ReservedIops'; Alias = 'ReservedIop'; WireName = 'reservedIops'; Nested = $false; Writable = $true },
            @{ Model = 'VolumeGroupUpdate'; Property = 'ReservedIops'; Alias = 'ReservedIop'; WireName = 'reservedIops'; Nested = $true; Writable = $true },
            @{ Model = 'VolumeGroupUpdateProperties'; Property = 'ReservedIops'; Alias = 'ReservedIop'; WireName = 'reservedIops'; Nested = $false; Writable = $true }
        )

        It '<Model> exposes plural and legacy properties with matching types and accessors on the public interface' -TestCases $models {
            param($Model, $Property, $Alias, $Writable)

            $interface = "Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.I$Model" -as [type]
            foreach ($name in @($Property, $Alias)) {
                $metadata = $interface.GetProperty($name)
                $metadata | Should -Not -BeNullOrEmpty
                $metadata.PropertyType | Should -Be ([Nullable[int]])
                $metadata.CanRead | Should -Be $true
                $metadata.CanWrite | Should -Be $Writable
            }
        }

        It '<Model> deserializes plural REST fields without changing the wire format' -TestCases @($models | Where-Object Model -NotMatch 'Update') {
            param($Model, $Property, $Alias, $WireName, $Nested)

            $type = "Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.$Model" -as [type]
            foreach ($value in @(0, 10000, [int]::MaxValue)) {
                $json = '{"' + $WireName + '":' + $value + '}'
                if ($Nested) {
                    $json = '{"properties":' + $json + '}'
                }
                $resource = $type::FromJsonString($json)
                $resource.$Property | Should -Be $value
                $resource.$Alias | Should -Be $value
                $body = $resource.ToJsonString() | ConvertFrom-Json
                if ($Nested) {
                    $body = $body.properties
                }
                $body.$WireName | Should -Be $value
                $body.PSObject.Properties.Name | Should -Not -Contain ($WireName -replace 's$')
            }
            $empty = $type::FromJsonString('{}')
            $empty.$Property | Should -BeNullOrEmpty
            $empty.$Alias | Should -BeNullOrEmpty
        }

        $inputCases = foreach ($model in $models) {
            foreach ($kind in @('Dictionary', 'PSObject')) {
                foreach ($names in @('Canonical', 'Alias', 'Both')) {
                    $case = $model.Clone()
                    $case.Kind = $kind
                    $case.Names = $names
                    $case
                }
            }
        }
        It '<Model> accepts <Names> properties from <Kind> inputs' -TestCases $inputCases {
            param($Model, $Property, $Alias, $Kind, $Names)

            $type = "Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.$Model" -as [type]
            foreach ($value in @(0, 10000, [int]::MaxValue)) {
                $inputProperties = @{}
                if ($Names -in @('Canonical', 'Both')) {
                    $inputProperties[$Property] = $value
                }
                if ($Names -in @('Alias', 'Both')) {
                    $inputProperties[$Alias] = $value
                }
                $canonical = $type::DeserializeFromDictionary(@{ $Property = $value })
                $resource = if ($Kind -eq 'Dictionary') {
                    $type::DeserializeFromDictionary($inputProperties)
                } else {
                    $type::DeserializeFromPSObject([pscustomobject]$inputProperties)
                }
                $resource.$Property | Should -Be $canonical.$Property
                $resource.$Alias | Should -Be $canonical.$Property
            }
        }

        It '<Model> serializes either name using only the plural REST field' -TestCases $models {
            param($Model, $Property, $Alias, $WireName, $Nested)

            $type = "Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.$Model" -as [type]
            foreach ($name in @($Property, $Alias)) {
                $resource = $type::DeserializeFromDictionary(@{ $name = 10000 })
                $body = $resource.ToJsonString() | ConvertFrom-Json
                if ($Nested) {
                    $body = $body.properties
                }
                $body.$WireName | Should -Be 10000
                $body.PSObject.Properties.Name | Should -Not -Contain ($WireName -replace 's$')
            }
        }

        It '<Model> rejects conflicting names and invalid legacy values' -TestCases $models {
            param($Model, $Property, $Alias)

            $type = "Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.$Model" -as [type]
            $conflict = @{ $Property = 10000; $Alias = 20000 }
            { $type::DeserializeFromDictionary($conflict) } | Should -Throw "Specify matching values for $Alias and $Property"
            { $type::DeserializeFromPSObject([pscustomobject]$conflict) } | Should -Throw "Specify matching values for $Alias and $Property"
            { $type::DeserializeFromDictionary(@{ $Alias = 'invalid' }) } | Should -Throw
            { $type::DeserializeFromPSObject([pscustomobject]@{ $Alias = 'invalid' }) } | Should -Throw
        }

        It '<Model> keeps writable aliases synchronized in both directions' -TestCases @($models | Where-Object Writable) {
            param($Model, $Property, $Alias)

            $type = "Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.$Model" -as [type]
            $resource = [Activator]::CreateInstance($type)
            $resource.$Alias = 10000
            $resource.$Property | Should -Be 10000
            $resource.$Property = 20000
            $resource.$Alias | Should -Be 20000
            $resource.$Alias = $null
            $resource.$Property | Should -Be $resource.$Alias
        }
    }

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
