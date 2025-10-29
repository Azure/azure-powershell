# Live Test Files Report

## Summary

This report identifies all `.tests.ps1` files in test folders under the `src` directory that contain the keyword "live" (case-insensitive), excluding files in `LiveTests` folders.

## Results

**Total files found: 179**

All matching file paths are available in: `live-test-files.txt`

## Search Criteria

- **Location**: All test folders under `src/` directory
- **File pattern**: `*.tests.ps1` (case-insensitive)
- **Content filter**: Files containing the keyword "live" (case-insensitive)
- **Exclusions**: Files in `LiveTests` folders are excluded

## Files Included

### Scripts
1. **Find-LiveTestFiles.ps1** - PowerShell script to find and list files
   - Cross-platform compatible (Windows, Linux, macOS)
   - Provides detailed output with counts and colored messages
   - Can be run with: `pwsh -File Find-LiveTestFiles.ps1`

2. **live-test-files.txt** - Complete list of 179 matching file paths
   - Plain text format, one file path per line
   - Easy to process with scripts or tools

3. **live-test-files-output.txt** - Full output from Find-LiveTestFiles.ps1
   - Includes search progress messages and summary

## Sample Files Found

The search found files across many Azure service modules, including:

- **AksArc**: Kubernetes cluster management tests
- **AppConfiguration**: Configuration store tests
- **Cdn**: Content Delivery Network tests
- **Compute**: VM and gallery application tests
- **ContainerInstance**: Container instance tests
- **DataBox**: Data Box job tests
- **DataProtection**: Backup and recovery tests
- **Functions**: Azure Functions tests
- **ScVmm**: System Center Virtual Machine Manager tests
- **SecurityInsights**: Azure Sentinel tests
- **ServiceBus**: Messaging service tests
- **SqlVirtualMachine**: SQL VM tests
- **Storage**: Storage service tests
- **Synapse**: Analytics service tests

## Common Patterns

Most files containing "live" use it in test tags:
- `Describe 'TestName' -Tag 'LiveOnly'` - Tests that only run in live mode
- Comments referencing live testing requirements

## Usage Examples

### View all matching files
```bash
cat live-test-files.txt
```

### Count matching files
```bash
wc -l live-test-files.txt
# Output: 179 live-test-files.txt
```

### Filter by module (e.g., Compute)
```bash
grep "Compute" live-test-files.txt
```

### Run the PowerShell script
```powershell
pwsh -File Find-LiveTestFiles.ps1
```

### Save results to a new file
```powershell
pwsh -File Find-LiveTestFiles.ps1 | Out-File my-results.txt
```

## Verification

The results have been verified to:
1. ✅ Include only `.tests.ps1` files
2. ✅ Include only files in test folders
3. ✅ Include only files containing "live" keyword
4. ✅ Exclude all files in `LiveTests` folders
5. ✅ Cover the entire `src` directory

## Statistics

- Total `.tests.ps1` files in test folders: 4,623
- Files containing "live" keyword: 179
- Percentage: ~3.87%
- Files in LiveTests folders: 0 (correctly excluded)
