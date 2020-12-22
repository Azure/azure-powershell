using StaticAnalysis.BreakingChangeAnalyzer;
using StaticAnalysis.DependencyAnalyzer;

using System;
using System.Collections.Generic;
using System.Text;

using Tools.Common.Issues;

namespace StaticAnalysis
{
    public static class ReportRecordFactory
    {
        public static IReportRecord Create(string type)
        {
            if (type.Equals("BreakingChangeIssue"))
            {
                return new BreakingChangeIssue();
            }
            if (type.Equals("AssemblyVersionConflict"))
            {
                return new AssemblyVersionConflict();
            }
            if (type.Equals("SharedAssemblyConflict"))
            {
                return new SharedAssemblyConflict();
            }
            if (type.Equals("MissingAssembly"))
            {
                return new MissingAssembly();
            }
            if (type.Equals("ExtraAssembly"))
            {
                return new ExtraAssembly();
            }

            return null;
        }
    }
}
