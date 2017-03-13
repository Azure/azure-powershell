Due to conflicting versions of Microsoft.Azure.Mgmt.Sql, scenario tests for
Hyak-based cmdlets cannot refer to any AutoRest-based cmdlets. This is a
problem because all scenario tests need to create servers, databases, and/or
elastic pools, and those have been migrated to AutoRest-based cmdlets.
The solution is to just have copy of the original Hyak-based server/db/pool
cmdlets here in the test project for scenario tests to use, which is what these
files are for.
