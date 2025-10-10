# Azure PowerShell SQL SDK Comparison Analysis

## Purpose
This document analyzes the two SQL SDKs used in the Azure PowerShell Sql module to understand why both exist and whether the legacy SDK can be removed.

## Background

The Azure PowerShell `Az.Sql` module currently depends on two separate SDKs:

1. **Sql.LegacySdk** (`src/Sql/Sql.LegacySdk`)
2. **Sql.Management.Sdk** (`src/Sql/Sql.Management.Sdk`)

This analysis examines the differences, usage patterns, and migration feasibility.

---

## Key Findings

### 1. Technical Differences

#### Sql.LegacySdk
- **Framework**: Hyak.Common (older Microsoft Azure SDK framework)
- **API Versions**: 2014-04-01, 2015-05-01-preview
- **Code Generation**: Pre-AutoRest tool
- **Credential Type**: `SubscriptionCloudCredentials`
- **Base Class**: `ServiceClient<SqlManagementClient>`
- **Operations**: 33 operation types (66 files)
- **Status**: No longer actively maintained for new features

#### Sql.Management.Sdk  
- **Framework**: Microsoft.Rest (modern Azure SDK framework)
- **API Versions**: Multiple modern versions (2021+)
- **Code Generation**: AutoRest (modern code generator)
- **Credential Type**: `ServiceClientCredentials`
- **Base Class**: `Microsoft.Rest.ServiceClient<SqlManagementClient>`
- **Operations**: 95+ operation types (190 files)
- **Status**: Actively maintained and updated

### 2. API Coverage Comparison

#### Operations Available in BOTH SDKs
The following operations exist in both SDKs (newer versions in Management.Sdk):
- Databases
- Elastic Pools
- Failover Groups
- Firewall Rules
- Replication Links
- Server Operations
- Capabilities
- Auditing
- Data Masking
- Transparent Data Encryption

#### Operations UNIQUE to LegacySdk

These operations **only** exist in the LegacySdk and have **no modern equivalent**:

| Operation | Purpose | Cmdlets Affected | Status |
|-----------|---------|-----------------|--------|
| **ServiceObjective** | Get database service objectives (performance tiers) | `Get-AzSqlServerServiceObjective` | Deprecated API |
| **ServiceTierAdvisor** | Get database/server upgrade recommendations | `Get-AzSqlUpgradeDatabaseHint`<br>`Get-AzSqlUpgradeServerHint` | Deprecated API |
| **ServerCommunicationLink** | Cross-subscription server links for geo-replication | `New-AzSqlServerCommunicationLink`<br>`Get-AzSqlServerCommunicationLink`<br>`Remove-AzSqlServerCommunicationLink` | Deprecated API |
| **ServerDisasterRecoveryConfiguration** | Legacy DR configuration | `New-AzSqlServerDisasterRecoveryConfiguration`<br>`Get-AzSqlServerDisasterRecoveryConfiguration`<br>`Set-AzSqlServerDisasterRecoveryConfiguration`<br>`Remove-AzSqlServerDisasterRecoveryConfiguration`<br>`Get-AzSqlServerDisasterRecoveryConfigurationActivity` | Deprecated API |
| **ServerUpgrade** | SQL Server version upgrades | Various server upgrade cmdlets | Deprecated API |
| **RecommendedElasticPool** | Get elastic pool recommendations | `Get-AzSqlElasticPoolRecommendation` | Deprecated API |
| **RecommendedIndex** | Database index recommendations | Index recommendation cmdlets | Deprecated API |
| **DatabaseActivation** | Pause/Resume SQL Data Warehouse databases | Database activation cmdlets | Some overlap with DW |

#### Operations UNIQUE to Management.Sdk

The Management.Sdk includes 60+ modern operations not available in LegacySdk:
- **Managed Instance** operations (40+ operations)
- **Job Agent** operations (elastic jobs)
- **Advanced Threat Protection** settings
- **Ledger Digest Uploads**
- **Sensitivity Labels** (data classification)
- **Server Trust Groups**
- **IPv6 Firewall Rules**
- **Distributed Availability Groups**
- **Server Configuration Options**
- Many more modern Azure SQL features

### 3. Usage Statistics

Analysis of the main `Az.Sql` module codebase:

- **Files using LegacySdk**: 75 C# files
- **References to LegacySdk**: 211 occurrences
- **Primary usage areas**:
  - Data Sync operations
  - Firewall rules
  - Database operations (legacy versions)
  - Index recommendations
  - Service tier advisors
  - Server communication links
  - Disaster recovery configurations
  - Database activation (pause/resume)

### 4. Why Two SDKs Exist

**Historical Reasons:**
1. **API Evolution**: Azure SQL REST APIs evolved from v1 (2014-04-01) to v2+ (2015+)
2. **Framework Migration**: Microsoft moved from Hyak.Common to Microsoft.Rest framework
3. **Backward Compatibility**: Existing cmdlets needed to continue working
4. **Deprecated Features**: Some Azure SQL features were deprecated but cmdlets remain for customer compatibility

**Technical Reasons:**
1. **No Direct Migration Path**: Some LegacySdk operations don't have exact equivalents in newer APIs
2. **Breaking Changes**: Replacing LegacySdk would break existing PowerShell scripts
3. **Customer Scripts**: Many customers rely on legacy cmdlets in production automation

---

## Can We Remove LegacySdk?

### Answer: **NO - Not without breaking changes**

### Blockers

1. **Active Cmdlets with No Modern Replacement**
   - `Get-AzSqlServerServiceObjective` - Widely used to list available service tiers
   - `*-AzSqlServerCommunicationLink` - Used for cross-subscription geo-replication setup
   - `Get-AzSql*Hint` cmdlets - Used for upgrade planning
   - DR configuration cmdlets - Used for disaster recovery setup

2. **Breaking Change Impact**
   - These cmdlets are publicly documented
   - Customers use them in production scripts
   - No direct replacement functionality in some cases

3. **Azure Service Constraints**
   - Some features were deprecated by Azure SQL service itself
   - No newer API endpoints for these operations
   - Azure recommends alternative approaches but no API equivalence

---

## Recommended Migration Path

### Phase 1: Deprecation Warnings (Next Minor Release - Az 12.x)

1. **Add Obsolete Attributes** to cmdlets that only use LegacySdk:
   ```csharp
   [Obsolete("This cmdlet uses a deprecated Azure SQL API. Please use [alternative] instead. This cmdlet will be removed in Az 14.0.")]
   ```

2. **Document Alternatives** for each deprecated cmdlet:
   - ServiceObjective → Use Azure Portal, Azure CLI, or direct API calls
   - ServerCommunicationLink → Use Failover Groups instead
   - UpgradeHints → Azure provides upgrade compatibility reports in portal
   - DR Configuration → Use Failover Groups or newer geo-replication APIs

3. **Update Documentation**:
   - Mark cmdlets as deprecated in help documentation
   - Add migration guides
   - Provide examples with modern alternatives

### Phase 2: Removal Notice (Major Release - Az 13.0)

1. **Add Breaking Change Warnings**:
   - Include in release notes
   - Add warning messages to cmdlet execution
   - Update migration documentation

2. **Provide Transition Period**:
   - Keep cmdlets functional but with prominent warnings
   - Monitor usage telemetry (if available)
   - Engage with customer feedback

### Phase 3: Removal (Major Release - Az 14.0+)

1. **Remove LegacySdk Dependency**:
   - Remove project reference from `Sql.csproj`
   - Delete `Sql.LegacySdk` project
   - Remove related cmdlets and code

2. **Clean Up**:
   - Remove 75+ files that reference LegacySdk
   - Update tests
   - Update documentation

---

## Migration Examples

### ServiceObjective → Modern Alternative

**Old (LegacySdk):**
```powershell
Get-AzSqlServerServiceObjective -ResourceGroupName "rg" -ServerName "server"
```

**New (Alternative approach):**
```powershell
# Use Azure CLI or direct ARM API
az sql db list-editions --location eastus --output table

# Or query available SKUs via Azure Resource Manager
Get-AzSqlCapability -LocationName "eastus"
```

### ServerCommunicationLink → Failover Groups

**Old (LegacySdk):**
```powershell
New-AzSqlServerCommunicationLink -ResourceGroupName "rg" -ServerName "server" -LinkName "link" -PartnerServer "partner"
```

**New (Management.Sdk):**
```powershell
# Use Failover Groups (modern replacement for geo-replication)
New-AzSqlDatabaseFailoverGroup -ResourceGroupName "rg" -ServerName "server" -FailoverGroupName "fg" -PartnerServerName "partner"
```

### DR Configuration → Failover Groups

**Old (LegacySdk):**
```powershell
New-AzSqlServerDisasterRecoveryConfiguration -ResourceGroupName "rg" -ServerName "server" -ConfigurationName "config"
```

**New (Management.Sdk):**
```powershell
# Use Failover Groups
New-AzSqlDatabaseFailoverGroup -ResourceGroupName "rg" -ServerName "server" -FailoverGroupName "fg" -PartnerResourceGroupName "partner-rg" -PartnerServerName "partner-server"
```

---

## Impact Assessment

### Customer Impact
- **High Impact**: Customers using legacy cmdlets will need to update scripts
- **Medium Impact**: Migration path exists for most scenarios
- **Low Impact**: Features are already deprecated by Azure

### Development Impact
- **Maintenance Reduction**: Eliminate 75 files and 211 references
- **Code Simplification**: Single SDK to maintain
- **Modernization**: Align with Azure best practices

### Timeline
- **Earliest Removal**: Az 14.0 (18-24 months from now)
- **Deprecation Start**: Az 12.1 (3-6 months from now)

---

## Recommendations

### Immediate Actions (Az 12.x)

1. ✅ **Add deprecation warnings** to all LegacySdk-only cmdlets
2. ✅ **Create migration guide** documenting alternatives
3. ✅ **Update help documentation** to reflect deprecation
4. ✅ **Notify customers** via blog post and release notes

### Medium-Term Actions (Az 13.x)

1. ✅ **Increase warning visibility** in cmdlet output
2. ✅ **Monitor usage** through telemetry
3. ✅ **Gather feedback** on migration challenges
4. ✅ **Refine migration guidance** based on feedback

### Long-Term Actions (Az 14.x+)

1. ✅ **Remove LegacySdk** dependency
2. ✅ **Remove deprecated cmdlets**
3. ✅ **Clean up codebase**
4. ✅ **Validate no regressions** in remaining functionality

---

## Conclusion

**The LegacySdk exists to maintain backward compatibility with deprecated Azure SQL features.** While these features are no longer recommended by Azure, removing them would break existing customer scripts.

**Recommendation**: 
- **Keep LegacySdk** for now (Az 12.x)
- **Deprecate** legacy cmdlets with clear warnings and migration guidance
- **Plan removal** for Az 14.0 after appropriate deprecation period
- **Focus new development** exclusively on Management.Sdk

This approach balances:
- ✅ Customer compatibility
- ✅ Technical debt reduction  
- ✅ Azure best practices alignment
- ✅ Reasonable migration timeline

---

## Appendix: Detailed Operation Lists

### LegacySdk Operations (33 total)
1. AuditingPolicy
2. BlobAuditing
3. Capabilities
4. DatabaseActivation
5. DatabaseAdvisor
6. DatabaseBackup
7. DatabaseOperations
8. DatabaseRecommendedAction
9. DataMasking
10. DataSync
11. ElasticPoolAdvisor
12. ElasticPoolOperations
13. ElasticPoolRecommendedAction
14. FailoverGroup
15. FirewallRule
16. ImportExport
17. JobAccount
18. RecommendedElasticPool
19. RecommendedIndex
20. ReplicationLink
21. SecureConnectionPolicy
22. SecurityAlertPolicy
23. ServerAdministrator
24. ServerAdvisor
25. ServerCommunicationLink ⚠️ Unique
26. ServerDisasterRecoveryConfiguration ⚠️ Unique
27. ServerKey
28. ServerOperations
29. ServerRecommendedAction
30. ServerUpgrade ⚠️ Unique
31. ServiceObjective ⚠️ Unique
32. ServiceTierAdvisor ⚠️ Unique
33. TransparentDataEncryption

### Management.Sdk Unique Operations (60+ examples)
1. ManagedInstances
2. ManagedDatabases
3. ManagedInstanceAdministrators
4. ManagedInstanceKeys
5. ManagedInstanceEncryptionProtectors
6. InstanceFailoverGroups
7. InstancePools
8. JobAgents
9. JobCredentials
10. Jobs
11. JobSteps
12. JobExecutions
13. ServerAdvancedThreatProtectionSettings
14. DatabaseAdvancedThreatProtectionSettings
15. ManagedInstanceAdvancedThreatProtectionSettings
16. LedgerDigestUploads
17. ManagedLedgerDigestUploads
18. SensitivityLabels
19. RecommendedSensitivityLabels
20. DatabaseVulnerabilityAssessments
21. ServerVulnerabilityAssessments
22. ServerTrustGroups
23. ServerTrustCertificates
24. IPv6FirewallRules
25. DistributedAvailabilityGroups
26. ServerConfigurationOptions
27. ... and 35+ more

---

**Document Version**: 1.0  
**Date**: 2025-10-10  
**Author**: Analysis based on Azure PowerShell repository structure
