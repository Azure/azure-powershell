# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.0
# Requires the existing local build. The generated client uses an in-memory terminal, never HTTP.
$binary = Join-Path $PSScriptRoot '..' '..' '..' '..' '..' 'artifacts' 'Debug' 'Az.EdgeAction' 'EdgeAction.Autorest' 'bin' 'Az.EdgeAction.private.dll'
if (-not (Test-Path $binary)) { throw 'Build Az.EdgeAction before running the offline serialization tests.' }
Import-Module $binary
if (-not ('EdgeActionUpdateWireProbe' -as [type])) {
    Add-Type -ErrorAction Stop -ReferencedAssemblies $binary, 'netstandard', 'System.Net.Http', 'System.Net.Primitives', 'System.Runtime', 'System.Collections' -TypeDefinition @'
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
    public CancellationToken Token => CancellationToken.None;
    public Action Cancel => () => {};
    public Task Signal(string id, CancellationToken token, Func<EventData> data) => Task.CompletedTask;
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
            (response, body) => throw new InvalidOperationException("Unexpected offline response.");
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

Describe 'Generated parent Update request serialization (offline transport)' {
    It 'serializes nonempty expanded tags' {
        $body = [EdgeActionUpdateWireProbe]::Capture($false, $false).GetAwaiter().GetResult() | ConvertFrom-Json -AsHashtable
        $body.Count | Should -Be 1
        $body.tags.Purpose | Should -Be 'offline'
    }
    It 'exposes the current expanded empty-tag omission rather than treating it as clearing' {
        $body = [EdgeActionUpdateWireProbe]::Capture($false, $true).GetAwaiter().GetResult() | ConvertFrom-Json -AsHashtable
        $body.ContainsKey('tags') | Should -Be $false
        $body.Count | Should -Be 0
    }
    It 'preserves explicit JSON tag clearing byte for byte' {
        [EdgeActionUpdateWireProbe]::Capture($true, $true).GetAwaiter().GetResult() | Should -Be '{"tags":{}}'
    }
}
