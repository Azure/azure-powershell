---
applyTo: "**/help/*.md"
---

## Reference help documentation requirements

When writing reference documents for PowerShell cmdlets, please follow these guidelines to ensure readability and helpfulness:

1. **Avoid over-simplified description** - For parameters and cmdlets, avoid over-simplified description such as "Some help", or simply repeating the parameter name.
2. **Allow placeholders for -ProgressAction** - there's a limitation in the tooling that the `-ProgressAction` parameter will have a placeholder description in the documents, e.g. `{{ Fill ProgressAction Description }}`. This is expected so do not leave review comments on that.
