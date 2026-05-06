# Post-Merge Test Helper
# Provides HTTP pipeline handler for routing PS cmdlet requests to the
# post-merge test Managed Resolver Frontend endpoint with client certificate auth.
# Uses a compiled C# class (PostMergeTestPipelineStep) with implicit conversion
# to SendAsyncStep, matching the PipelineMock pattern.

$script:PostMergeTestEndpoint = "https://s1.westus2.test.azuremresolver.net"
$script:PostMergeTestCertSubjectName = "CN=tests.clients.test.azuremresolver.net"
$script:PostMergeTestTenantId = "f686d426-8d16-42db-81b7-ab578e110ccd"

function Get-PostMergeTestCertificate {
    <#
    .SYNOPSIS
    Loads the post-merge test client certificate from the local certificate store.
    Prefers non-expired certificates sorted by latest expiry.
    #>
    $allCerts = @()
    $allCerts += Get-ChildItem -Path Cert:\CurrentUser\My | Where-Object { $_.Subject -eq $script:PostMergeTestCertSubjectName }
    $allCerts += Get-ChildItem -Path Cert:\LocalMachine\My | Where-Object { $_.Subject -eq $script:PostMergeTestCertSubjectName }

    if ($allCerts.Count -eq 0) {
        throw "Post-merge test client certificate '$($script:PostMergeTestCertSubjectName)' not found in certificate store. Please install the certificate first."
    }

    # Prefer non-expired certs, sorted by latest expiry
    $now = [DateTime]::UtcNow
    $cert = $allCerts | Where-Object { $_.NotAfter -gt $now } | Sort-Object NotAfter -Descending | Select-Object -First 1
    if (-not $cert) {
        $cert = $allCerts | Sort-Object NotAfter -Descending | Select-Object -First 1
        Write-Warning "No valid (non-expired) post-merge test certificates found. Using expired cert with thumbprint $($cert.Thumbprint) (expired $($cert.NotAfter))."
    }
    return $cert
}

function Initialize-PostMergeTestType {
    <#
    .SYNOPSIS
    Compiles the PostMergeTestPipelineStep C# class that implements the same
    implicit-to-SendAsyncStep pattern as PipelineMock.
    #>
    if (-not ([System.Management.Automation.PSTypeName]'PostMergeTestPipelineStep').Type) {
        $moduleAssembly = [Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime.PipelineMock].Assembly.Location
        Add-Type -ReferencedAssemblies @(
            $moduleAssembly,
            'System.Net.Http',
            'System.Threading.Tasks',
            'netstandard'
        ) -TypeDefinition @'
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Runtime;

public class PostMergeTestPipelineStep
{
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;
    private readonly string _tenantId;

    public PostMergeTestPipelineStep(HttpClient httpClient, string endpoint, string tenantId)
    {
        _httpClient = httpClient;
        _endpoint = endpoint.TrimEnd('/');
        _tenantId = tenantId;
    }

    public static implicit operator SendAsyncStep(PostMergeTestPipelineStep step)
    {
        return step.SendAsync;
    }

    public async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        IEventListener callback,
        ISendAsync next)
    {
        var originalUri = request.RequestUri;

        // Only rewrite ARM URLs; LRO polling URLs already point to test endpoint
        if (!originalUri.Host.Equals("management.azure.com", System.StringComparison.OrdinalIgnoreCase))
        {
            // Already targeting test endpoint (e.g., Azure-AsyncOperation polling)
            request.Headers.Authorization = null;
            request.Headers.TryAddWithoutValidation("x-ms-client-tenant-id", _tenantId);
            return await _httpClient.SendAsync(request, CancellationToken.None).ConfigureAwait(false);
        }

        var path = originalUri.PathAndQuery;

        // Determine the route prefix based on the resource path
        string routePrefix;
        if (path.Contains("dnsResolverPolicies") || path.Contains("dnsResolverDomainLists"))
        {
            routePrefix = "api/dnsresolverpolicy";
        }
        else
        {
            routePrefix = "api/mresolver";
        }

        // Rewrite the URL: management.azure.com/{path} -> endpoint/{routePrefix}/{path}
        request.RequestUri = new Uri($"{_endpoint}/{routePrefix}{path}");

        // Remove bearer token auth - we use client cert instead
        request.Headers.Authorization = null;
        request.Headers.TryAddWithoutValidation("x-ms-client-tenant-id", _tenantId);

        // Send via our cert-auth HttpClient, bypassing the default pipeline
        return await _httpClient.SendAsync(request, CancellationToken.None).ConfigureAwait(false);
    }
}
'@
    }
}

function New-PostMergeTestHttpPipelineStep {
    <#
    .SYNOPSIS
    Creates an HTTP pipeline step that rewrites ARM URLs to the post-merge test
    Frontend endpoint and uses client certificate authentication.

    .DESCRIPTION
    Returns a PostMergeTestPipelineStep object that has implicit conversion to
    SendAsyncStep (same pattern as PipelineMock). The step:
    1. Rewrites the request URL from management.azure.com to the test Frontend
    2. Prefixes the path with the appropriate controller route
    3. Uses client certificate for authentication instead of bearer token
    #>

    Initialize-PostMergeTestType

    $cert = Get-PostMergeTestCertificate

    $handler = [System.Net.Http.HttpClientHandler]::new()
    $null = $handler.ClientCertificates.Add($cert)
    $handler.ServerCertificateCustomValidationCallback = [System.Net.Http.HttpClientHandler]::DangerousAcceptAnyServerCertificateValidator
    $httpClient = [System.Net.Http.HttpClient]::new($handler)

    return [PostMergeTestPipelineStep]::new($httpClient, $script:PostMergeTestEndpoint, $script:PostMergeTestTenantId)
}
