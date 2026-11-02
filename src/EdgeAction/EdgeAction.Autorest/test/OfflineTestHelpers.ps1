# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.

function Get-EdgeActionOfflineTestAssembly {
    param([string]$TestRoot)
    $loadedType = 'Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.PipelineMock' -as [type]
    if ($loadedType) { return $loadedType.Assembly.Location }
    $moduleRoot = Split-Path $TestRoot
    $binary = Join-Path $moduleRoot 'bin/Az.EdgeAction.private.dll'
    if (Test-Path -LiteralPath $binary) { return $binary }
    $directory = Get-Item -LiteralPath $moduleRoot
    while ($directory -and -not (Test-Path -LiteralPath (Join-Path $directory.FullName 'build.proj'))) {
        $directory = $directory.Parent
    }
    if ($directory) {
        $binary = Join-Path $directory.FullName 'artifacts/Debug/Az.EdgeAction/EdgeAction.Autorest/bin/Az.EdgeAction.private.dll'
        if (Test-Path -LiteralPath $binary) { return $binary }
    }
    throw 'Build Az.EdgeAction before running the offline binary regression tests.'
}
