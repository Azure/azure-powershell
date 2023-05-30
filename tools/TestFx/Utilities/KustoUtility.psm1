# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [guid] $TenantId,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [guid] $ServicePrincipalId,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $ServicePrincipalSecret,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterName,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $ClusterRegion
)

function InitializeKustoPackages {
    [CmdletBinding()]
    param ()

    $kustoPackagesDirectoryName = "KustoPackages"
    $kustoPackagesDirectory = Join-Path -Path . -ChildPath $kustoPackagesDirectoryName
    if (Test-Path -LiteralPath $kustoPackagesDirectory) {
        Remove-Item -LiteralPath $kustoPackagesDirectory -Recurse -Force
    }

    New-Item -Path . -Name $kustoPackagesDirectoryName -ItemType Directory -Force

    $kustoPackages = @(
        @{ PackageName = "Azure.Core"; PackageVersion = "1.30.0"; DllName = "Azure.Core.dll" },
        @{ PackageName = "Azure.Data.Tables"; PackageVersion = "12.8.0"; DllName = "Azure.Data.Tables.dll" },
        @{ PackageName = "Azure.Storage.Blobs"; PackageVersion = "12.13.0"; DllName = "Azure.Storage.Blobs.dll" },
        @{ PackageName = "Azure.Storage.Common"; PackageVersion = "12.12.0"; DllName = "Azure.Storage.Common.dll" },
        @{ PackageName = "Azure.Storage.Queues"; PackageVersion = "12.11.0"; DllName = "Azure.Storage.Queues.dll" },
        @{ PackageName = "Microsoft.Azure.Kusto.Cloud.Platform"; PackageVersion = "11.2.2"; DllName = "Kusto.Cloud.Platform.dll" },
        @{ PackageName = "Microsoft.Azure.Kusto.Cloud.Platform.Aad"; PackageVersion = "11.2.2"; DllName = "Kusto.Cloud.Platform.Aad.dll" },
        @{ PackageName = "Microsoft.Azure.Kusto.Data"; PackageVersion = "11.2.2"; DllName = "Kusto.Data.dll" },
        @{ PackageName = "Microsoft.Azure.Kusto.Ingest"; PackageVersion = "11.2.2"; DllName = "Kusto.Ingest.dll" },
        @{ PackageName = "Microsoft.Identity.Client"; PackageVersion = "4.48.0"; DllName = "Microsoft.Identity.Client.dll" },
        @{ PackageName = "Microsoft.IdentityModel.Abstractions"; PackageVersion = "6.22.0"; DllName = "Microsoft.IdentityModel.Abstractions.dll" },
        @{ PackageName = "Microsoft.IO.RecyclableMemoryStream"; PackageVersion = "2.2.0"; DllName = "Microsoft.IO.RecyclableMemoryStream.dll" },
        @{ PackageName = "System.Memory.Data"; PackageVersion = "1.0.2"; DllName = "System.Memory.Data.dll" }
    )

    $kustoPackages | ForEach-Object {
        $packageName = $_["PackageName"]
        $packageVersion = $_["PackageVersion"]
        $packageDll = $_["DllName"]
        Install-Package -Name $packageName -RequiredVersion $packageVersion -Source "https://www.nuget.org/api/v2" -Destination $kustoPackagesDirectory -SkipDependencies -ExcludeVersion -Force
        Add-Type -LiteralPath (Join-Path -Path $kustoPackagesDirectory -ChildPath $packageName | Join-Path -ChildPath "lib" | Join-Path -ChildPath "netstandard2.0" | Join-Path -ChildPath $packageDll) -ErrorAction SilentlyContinue
    }
}

function Add-KustoData {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $DatabaseName,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $TableName,

        [Parameter(Mandatory)]
        [ValidateScript({ (Test-Path -LiteralPath $_ -PathType Leaf) -and ($_ -like "*.csv") })]
        [string[]] $CsvFile
    )

    $ingestUri = "https://ingest-$ClusterName.$ClusterRegion.kusto.windows.net"
    $ingestBuilder = [Kusto.Data.KustoConnectionStringBuilder]::new($ingestUri).WithAadApplicationKeyAuthentication($ServicePrincipalId, $ServicePrincipalSecret, $TenantId.ToString())
    IngestDataFromCsv -IngestBuilder $ingestBuilder -DatabaseName $DatabaseName -TableName $TableName -CsvFile $CsvFile
}

function IngestDataFromCsv {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [ValidateNotNull()]
        $IngestBuilder,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $DatabaseName,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $TableName,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string[]] $CsvFile
    )

    try {
        $ingestClient = [Kusto.Ingest.KustoIngestFactory]::CreateQueuedIngestClient($IngestBuilder)
        $ingestionProps = [Kusto.Ingest.KustoQueuedIngestionProperties]::new($DatabaseName, $TableName)
        $ingestionProps.Format = [Kusto.Data.Common.DataSourceFormat]::csv
        $ingestionProps.IgnoreFirstRecord = $true

        $ingestionMapping = [Kusto.Ingest.IngestionMapping]::new()
        $ingestionMapping.IngestionMappingKind = [Kusto.Data.Ingestion.IngestionMappingKind]::Csv
        $ingestionMapping.IngestionMappingReference = "$($TableName)_csv_mapping"

        $ingestionProps.IngestionMapping = $ingestionMapping

        $CsvFile | ForEach-Object {
            Write-Host "##[section]Start to import the file $_."
            $ingestClient.IngestFromStorageAsync($_, $ingestionProps).GetAwaiter().GetResult() | Out-Null
            Write-Host "##[section]Successfully imported the file $_."
        }
    }
    catch {
        throw $_
    }
    finally {
        if ($null -ne $ingestClient) {
            $ingestClient.Dispose()
        }
    }
}

function Get-KustoQueryData {
    param (
        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $DatabaseName,

        [Parameter(Mandatory)]
        [ValidateNotNullOrEmpty()]
        [string] $Query
    )

    $queryUri = "https://$ClusterName.$ClusterRegion.kusto.windows.net"
    $queryBuilder = [Kusto.Data.KustoConnectionStringBuilder]::new($queryUri).WithAadApplicationKeyAuthentication($ServicePrincipalId, $ServicePrincipalSecret, $TenantId.ToString())
    $queryClient = [Kusto.Data.Net.Client.KustoClientFactory]::CreateCslQueryProvider($queryBuilder)
    $queryResult = $queryClient.ExecuteQuery($DatabaseName, $Query, $null)
    $results = @()
    while ($queryResult.Read()) {
        $resultObj = [PSCustomObject]@{}
        for ($i = 0; $i -lt $queryResult.FieldCount; $i ++) {
            $propName = $queryResult.GetName($i)
            $propValue = $queryResult.GetValue($i)

            $resultObj | Add-Member -NotePropertyName $propName -NotePropertyValue $propValue
        }
        $results += $resultObj
    }

    $results
}

InitializeKustoPackages
