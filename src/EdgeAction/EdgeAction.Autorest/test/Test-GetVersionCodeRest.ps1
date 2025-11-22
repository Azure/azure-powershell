# Test script to call Get Version Code REST API directly and examine the response
# This helps us understand the response format and how to handle base64-encoded content

param(
    [Parameter(Mandatory)]
    [string]$SubscriptionId,
    
    [Parameter(Mandatory)]
    [string]$ResourceGroupName,
    
    [Parameter(Mandatory)]
    [string]$EdgeActionName,
    
    [Parameter(Mandatory)]
    [string]$Version
)

# Import Az.Accounts to get access token
Import-Module Az.Accounts -Force

# Get the access token
$context = Get-AzContext
if (-not $context) {
    Write-Error "Not logged in to Azure. Please run Connect-AzAccount first."
    exit 1
}

$token = (Get-AzAccessToken -ResourceUrl "https://management.azure.com").Token

# Build the REST API URL
$apiVersion = "2025-09-01-preview"
$url = "https://management.azure.com/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Cdn/edgeActions/$EdgeActionName/versions/$Version/getVersionCode?api-version=$apiVersion"

Write-Host "Calling API: $url" -ForegroundColor Cyan

# Make the REST API call
$headers = @{
    "Authorization" = "Bearer $token"
    "Content-Type" = "application/json"
}

try {
    $response = Invoke-RestMethod -Uri $url -Method Post -Headers $headers -Body "{}"
    
    Write-Host "`nResponse received successfully!" -ForegroundColor Green
    Write-Host "Response Type: $($response.GetType().FullName)"
    
    # Display response properties
    Write-Host "`nResponse Properties:" -ForegroundColor Yellow
    $response | Get-Member -MemberType Properties | ForEach-Object {
        $propName = $_.Name
        $propValue = $response.$propName
        
        if ($propName -eq "Content" -or $propName -eq "content") {
            $contentLength = if ($propValue) { $propValue.Length } else { 0 }
            Write-Host "  $propName : [Base64 String - Length: $contentLength]"
            
            if ($contentLength -gt 0 -and $contentLength -lt 100) {
                Write-Host "    Preview: $($propValue.Substring(0, [Math]::Min(50, $contentLength)))..."
            }
        } else {
            Write-Host "  $propName : $propValue"
        }
    }
    
    # Try to decode and save the content if it exists
    if ($response.Content -or $response.content) {
        $base64Content = if ($response.Content) { $response.Content } else { $response.content }
        
        Write-Host "`nAttempting to decode base64 content..." -ForegroundColor Cyan
        try {
            $bytes = [System.Convert]::FromBase64String($base64Content)
            Write-Host "Successfully decoded! Byte array length: $($bytes.Length)" -ForegroundColor Green
            
            # Save to a file
            $outputPath = Join-Path $PSScriptRoot "version_code_output.zip"
            [System.IO.File]::WriteAllBytes($outputPath, $bytes)
            Write-Host "Saved decoded content to: $outputPath" -ForegroundColor Green
            
            # Verify it's a valid ZIP file
            try {
                Add-Type -AssemblyName System.IO.Compression.FileSystem
                $zip = [System.IO.Compression.ZipFile]::OpenRead($outputPath)
                Write-Host "`nZIP file contents:" -ForegroundColor Yellow
                $zip.Entries | ForEach-Object {
                    Write-Host "  - $($_.FullName) ($($_.Length) bytes)"
                }
                $zip.Dispose()
            } catch {
                Write-Host "Note: Decoded content is not a valid ZIP file: $_" -ForegroundColor Yellow
            }
        } catch {
            Write-Host "Failed to decode base64: $_" -ForegroundColor Red
        }
    } else {
        Write-Host "`nNo 'Content' property found in response" -ForegroundColor Yellow
    }
    
} catch {
    Write-Host "`nAPI call failed!" -ForegroundColor Red
    Write-Host "Status Code: $($_.Exception.Response.StatusCode.value__)"
    Write-Host "Status Description: $($_.Exception.Response.StatusDescription)"
    Write-Host "Error: $_"
    
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $responseBody = $reader.ReadToEnd()
        Write-Host "Response Body: $responseBody"
    }
}
