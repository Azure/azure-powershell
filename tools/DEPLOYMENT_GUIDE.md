# Azure PowerShell .tar.gz Content Type Fix - Deployment Guide

## Problem Resolved
Fixed issue where Az .tar.gz files were uploaded with content-type "application/octet-stream" instead of "application/x-gzip", breaking offline installation scripts.

## Files Changed/Added

### New Files
- `tools/StorageUploadHelper.psm1` - Core helper module for content type detection
- `tools/UploadReleaseArtifacts.ps1` - Dedicated release artifact upload script  
- `tools/Test-StorageUploadHelper.ps1` - Test suite (24 tests)
- `tools/Demo-ContentTypeFix.ps1` - Demonstration script
- `tools/StorageUploadHelper.md` - Documentation

### Modified Files  
- `tools/AutomationTestFramework/Management/ModuleUploader.ps1` - Updated to use helper
- `tools/TestFx/Live/SaveLiveTestResult.ps1` - Updated to use helper

## Deployment Steps

### For Release Pipeline Integration
1. **Update release scripts** that upload to azpspackage.blob.core.windows.net:
   ```powershell
   # Replace existing uploads with:
   Import-Module "tools/StorageUploadHelper.psm1"
   Set-AzStorageBlobContentWithCorrectType -Container "release" -File "Az-Cmdlets-14.0.0.tar.gz" -Blob "Az-Cmdlets-14.0.0.tar.gz" -Context $context -Force
   ```

2. **For new release artifacts**:
   ```powershell
   .\tools\UploadReleaseArtifacts.ps1 -StorageAccountName "azpspackage" -ContainerName "release" -ResourceGroupName "rg-azps" -LocalPath "artifacts" -FilePattern "*.tar.gz"
   ```

### Verification Commands
```powershell
# Test the helper module
.\tools\Test-StorageUploadHelper.ps1

# Demonstrate the fix  
.\tools\Demo-ContentTypeFix.ps1

# Verify content type detection
Import-Module "tools/StorageUploadHelper.psm1"
Get-ContentTypeFromExtension "Az-Cmdlets-14.0.0.tar.gz"
# Should return: application/x-gzip
```

### Backward Compatibility
- All existing function parameters are supported
- No breaking changes to existing scripts
- Drop-in replacement for `Set-AzStorageBlobContent`

## Expected Results
- ✅ .tar.gz files: `Content-Type: application/x-gzip`  
- ✅ .msi files: `Content-Type: application/x-msi`
- ✅ .zip files: `Content-Type: application/zip`
- ✅ Offline installation scripts work correctly
- ✅ Web browsers handle downloads properly

## Testing
All 24 test cases pass including:
- Critical .tar.gz content type detection
- Case sensitivity handling
- Compound extension support (.tar.gz, .tar.bz2, etc.)
- PowerShell file types (.ps1, .psm1, .psd1)
- Fallback to application/octet-stream for unknown types

## Next Release Validation
After deploying this fix, verify the next release has correct content types:
```bash
curl -I https://azpspackage.blob.core.windows.net/release/Az-Cmdlets-[VERSION].tar.gz
# Should show: Content-Type: application/x-gzip
```