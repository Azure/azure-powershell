# Solution: Find .tests.ps1 Files with "live" Keyword

## Task Completed ✓

Found all `.tests.ps1` files in test folders under `src/` that contain the keyword "live" (case-insensitive), excluding files in LiveTests folders.

## Results

**Total Files Found: 179**

## Deliverables

### 1. **live-test-files.txt**
- Plain text list of all 179 file paths
- One file path per line
- Easy to process programmatically
- Example usage: `cat live-test-files.txt`

### 2. **Find-LiveTestFiles.ps1**
- Cross-platform PowerShell script
- Compatible with Windows, Linux, and macOS
- Provides detailed progress messages
- Example usage: `pwsh -File Find-LiveTestFiles.ps1`

### 3. **LIVE_TEST_FILES_REPORT.md**
- Comprehensive documentation
- Includes statistics and examples
- Usage instructions and verification details

### 4. **live-test-files-output.txt**
- Complete output with progress messages
- Shows search statistics

## Search Criteria

✓ **Location**: `src/` directory  
✓ **File Pattern**: `*.tests.ps1` (case-insensitive)  
✓ **Path Filter**: Files must be in `test` folders  
✓ **Content Filter**: Must contain "live" keyword (case-insensitive)  
✓ **Exclusion**: Files in `LiveTests` folders are excluded  

## Verification

The solution has been verified to:

1. ✅ Include only `.tests.ps1` files
2. ✅ Include only files in test folders under src/
3. ✅ Include only files containing "live" keyword
4. ✅ Exclude all files in `LiveTests` folders
5. ✅ Search the entire `src` directory comprehensively

## Statistics

- Total `.tests.ps1` files in test folders: **4,623**
- Files containing "live" keyword: **179**
- Percentage: **~3.87%**
- Files in LiveTests folders: **0** (correctly excluded)

## Common Patterns Found

Most files use "live" in these contexts:

1. **Test Tags**: `Describe 'TestName' -Tag 'LiveOnly'`
2. **Variable Names**: Contains words like `DeliveryInfoScheduledDateTime`
3. **Comments**: References to live testing

The most common pattern is the `'LiveOnly'` tag used in Pester test descriptions.

## Module Distribution

Files were found across many Azure service modules including:

- AksArc
- App
- AppConfiguration
- Cdn
- Compute
- ContainerInstance
- DataBox
- DataProtection
- DataTransfer
- Functions
- ImportExport
- NewRelic
- Resources
- ScVmm
- SecurityInsights
- SelfHelp
- ServiceBus
- SignalR
- SqlVirtualMachine
- Storage
- Synapse

## Quick Reference

```bash
# View all file paths
cat live-test-files.txt

# Count total files
wc -l live-test-files.txt

# Filter by specific module (e.g., Compute)
grep "Compute" live-test-files.txt

# Run the PowerShell script
pwsh -File Find-LiveTestFiles.ps1

# Save to custom output file
pwsh -File Find-LiveTestFiles.ps1 > my-results.txt
```

## Files Committed

All deliverables have been committed to the repository:
- Find-LiveTestFiles.ps1
- LIVE_TEST_FILES_REPORT.md
- live-test-files-output.txt
- live-test-files.txt
- SOLUTION_SUMMARY.md (this file)

---

**Task completed successfully!** All requirements have been met and verified.
