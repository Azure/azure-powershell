# ----------------------------------------------------------------------------------
#
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

<#
.SYNOPSIS
    Tests for the StorageUploadHelper module content type detection.
.DESCRIPTION
    This script tests the Get-ContentTypeFromExtension function to ensure it returns
    the correct MIME types for various file extensions, particularly for .tar.gz files.
#>

# Import the module to test
Import-Module "$PSScriptRoot\StorageUploadHelper.psm1" -Force

# Test cases for content type detection
$testCases = @(
    # Compound extensions (these are the critical ones for the bug fix)
    @{ File = "Az-Cmdlets-13.5.0.tar.gz"; Expected = "application/x-gzip" },
    @{ File = "package.tar.gz"; Expected = "application/x-gzip" },
    @{ File = "archive.tar.bz2"; Expected = "application/x-bzip2" },
    @{ File = "data.tar.xz"; Expected = "application/x-xz" },
    
    # Single extensions
    @{ File = "file.gz"; Expected = "application/x-gzip" },
    @{ File = "file.gzip"; Expected = "application/x-gzip" },
    @{ File = "archive.tar"; Expected = "application/x-tar" },
    @{ File = "package.zip"; Expected = "application/zip" },
    @{ File = "installer.msi"; Expected = "application/x-msi" },
    @{ File = "program.exe"; Expected = "application/x-msdownload" },
    @{ File = "library.dll"; Expected = "application/x-msdownload" },
    @{ File = "data.json"; Expected = "application/json" },
    @{ File = "config.xml"; Expected = "application/xml" },
    @{ File = "readme.txt"; Expected = "text/plain" },
    @{ File = "script.ps1"; Expected = "text/plain" },
    @{ File = "module.psm1"; Expected = "text/plain" },
    @{ File = "manifest.psd1"; Expected = "text/plain" },
    @{ File = "config.ps1xml"; Expected = "application/xml" },
    @{ File = "package.nupkg"; Expected = "application/zip" },
    
    # Case insensitivity tests
    @{ File = "FILE.TAR.GZ"; Expected = "application/x-gzip" },
    @{ File = "Package.ZIP"; Expected = "application/zip" },
    @{ File = "Script.PS1"; Expected = "text/plain" },
    
    # Default case
    @{ File = "unknown.xyz"; Expected = "application/octet-stream" },
    @{ File = "noextension"; Expected = "application/octet-stream" }
)

Write-Host "Running content type detection tests..."
Write-Host ""

$passedTests = 0
$failedTests = 0

foreach ($testCase in $testCases) {
    $actual = Get-ContentTypeFromExtension -FilePath $testCase.File
    $expected = $testCase.Expected
    
    if ($actual -eq $expected) {
        Write-Host "✓ PASS: '$($testCase.File)' -> '$actual'" -ForegroundColor Green
        $passedTests++
    } else {
        Write-Host "✗ FAIL: '$($testCase.File)' -> Expected: '$expected', Actual: '$actual'" -ForegroundColor Red
        $failedTests++
    }
}

Write-Host ""
Write-Host "Test Results:"
Write-Host "  Passed: $passedTests" -ForegroundColor Green
Write-Host "  Failed: $failedTests" -ForegroundColor Red
Write-Host "  Total:  $($passedTests + $failedTests)"

if ($failedTests -eq 0) {
    Write-Host ""
    Write-Host "All tests passed! ✓" -ForegroundColor Green
    exit 0
} else {
    Write-Host ""
    Write-Host "Some tests failed! ✗" -ForegroundColor Red
    exit 1
}