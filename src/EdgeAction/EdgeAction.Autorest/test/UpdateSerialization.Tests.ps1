# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 5.1
if ($TestName -and $TestName -notcontains 'Generated parent Update request serialization (offline transport)') { return }

$offlineModule = New-Module -Name EdgeActionUpdateSerializationTests -ArgumentList $PSScriptRoot -ScriptBlock {
param($TestRoot)
$PSDefaultParameterValues = $PSDefaultParameterValues.Clone()
$PSDefaultParameterValues.Remove('*:HttpPipelinePrepend')
# Requires the existing local build. The generated client uses an in-memory terminal, never HTTP.
. (Join-Path $TestRoot 'OfflineTestHelpers.ps1')
Export-ModuleMember
}
try {
$offlineModule | Import-Module -Force
InModuleScope EdgeActionUpdateSerializationTests {
Describe 'Generated parent Update request serialization (offline transport)' {
BeforeAll {
$binary = Get-EdgeActionOfflineTestAssembly $TestRoot
$null = [System.Reflection.Assembly]::LoadFrom($binary)
if (-not ('EdgeActionUpdateWireProbe' -as [type])) {
    $references = @($binary, 'netstandard', 'System.Net.Http', 'System.Runtime')
    if ($PSEdition -eq 'Core') { $references += 'System.Net.Primitives', 'System.Collections' }
    Add-Type -ErrorAction Stop -ReferencedAssemblies $references -TypeDefinition @'
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.EdgeAction;
using Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Models;
using Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime;

public sealed class EdgeActionUpdateWireProbe : ISendAsync, IEventListener {
    public string Body { get; private set; }
    public CancellationToken Token { get { return CancellationToken.None; } }
    public Action Cancel { get { return () => {}; } }
    public Task Signal(string id, CancellationToken token, Func<EventData> data) { return Task.CompletedTask; }
    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener listener) {
        Body = await request.Content.ReadAsStringAsync();
        return new HttpResponseMessage(HttpStatusCode.OK) {
            Content = new StringContent("{\"name\":\"offline\"}")
        };
    }
    public static async Task<string> Capture(bool rawJson, bool empty) {
        var probe = new EdgeActionUpdateWireProbe();
        var client = new Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.EdgeAction();
        Func<HttpResponseMessage, Task<IEdgeAction>, Task> ok = (response, body) => Task.CompletedTask;
        Func<HttpResponseMessage, Task<IErrorResponse>, Task> error =
            (response, body) => { throw new InvalidOperationException("Unexpected offline response."); };
        if (rawJson) {
            await client.EdgeActionsUpdateViaJsonString("offline", "powershelltests", "offline",
                "{\"tags\":{}}", ok, error, probe, probe);
        } else {
            var body = new EdgeActionUpdate();
            body.Tag = new EdgeActionUpdateTags();
            if (!empty) { body.Tag.Add("Purpose", "offline"); }
            await client.EdgeActionsUpdate("offline", "powershelltests", "offline",
                body, ok, error, probe, probe, SerializationMode.IncludeUpdate);
        }
        return probe.Body;
    }
}
'@
}
}

    It 'serializes nonempty expanded tags' {
        $body = [EdgeActionUpdateWireProbe]::Capture($false, $false).GetAwaiter().GetResult() | ConvertFrom-Json
        @($body.PSObject.Properties).Count | Should -Be 1
        $body.tags.Purpose | Should -Be 'offline'
    }
    It 'exposes the current expanded empty-tag omission rather than treating it as clearing' {
        $body = [EdgeActionUpdateWireProbe]::Capture($false, $true).GetAwaiter().GetResult() | ConvertFrom-Json
        $body.PSObject.Properties.Name | Should -Not -Contain 'tags'
        @($body.PSObject.Properties).Count | Should -Be 0
    }
    It 'preserves explicit JSON tag clearing byte for byte' {
        [EdgeActionUpdateWireProbe]::Capture($true, $true).GetAwaiter().GetResult() | Should -Be '{"tags":{}}'
    }
}
}
} finally {
    Remove-Module -ModuleInfo $offlineModule -Force
}
