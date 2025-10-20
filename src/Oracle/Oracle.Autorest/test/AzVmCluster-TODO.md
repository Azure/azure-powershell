# TODO: Fix and Align AzVmCluster Recordings for Test Pass

- [x] Analyze failed test output and map ‘Missing Request’ messages to AzVmCluster.Recording.json
- [x] Review all requests in AzVmCluster.Recording.json for completeness and consistency
- [x] For each "Missing Request" error in Pester output:
  - [x] Find the exact key in the JSON (string comparison) — if no match, the key is missing
  - [x] If mismatched, check request details for differences (API version, URL, query params)
  - [x] Document each discrepancy

**Root Cause Finding:**  
OperationStatus polling requests (URLs containing /operationStatuses/{UUID}*{ID}) use UUIDs generated at runtime, which usually do not match those in the original .json recording. Unless the .json was created with the exact calls occurring during this playback, the keys don't exist and playback fails.

**Remediation Approach:**  
- Patch the recording JSON: For every “Missing Request” error referencing an operationStatus UUID not present in the .json, inject a new entry under that key with a valid (previously recorded, or canned) "Succeeded" or "Completed" response.
- (Optional) Automate this with a script that reuses an existing successful response payload any time an unknown operationStatuses key is requested (for rapid test unblock).

- [ ] Re-run test suite after patching, confirm fewer missing request failures
- [ ] Document process, workaround, and root cause(s) in this file for future reference
