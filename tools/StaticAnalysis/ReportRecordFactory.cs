//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using StaticAnalysis.BreakingChangeAnalyzer;
using StaticAnalysis.DependencyAnalyzer;
using StaticAnalysis.HelpAnalyzer;
using StaticAnalysis.SignatureVerifier;
using StaticAnalysis.ExampleAnalyzer;
using StaticAnalysis.UXMetadataAnalyzer;
using StaticAnalysis.GeneratedSdkAnalyzer;

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
            if (type.Equals(typeof(BreakingChangeIssue).FullName))
            {
                return new BreakingChangeIssue();
            }
            if (type.Equals(typeof(AssemblyVersionConflict).FullName))
            {
                return new AssemblyVersionConflict();
            }
            if (type.Equals(typeof(SharedAssemblyConflict).FullName))
            {
                return new SharedAssemblyConflict();
            }
            if (type.Equals(typeof(MissingAssembly).FullName))
            {
                return new MissingAssembly();
            }
            if (type.Equals(typeof(ExtraAssembly).FullName))
            {
                return new ExtraAssembly();
            }
            if (type.Equals(typeof(HelpIssue).FullName))
            {
                return new HelpIssue();
            }
            if (type.Equals(typeof(SignatureIssue).FullName))
            {
                return new SignatureIssue();
            }
            if (type.Equals(typeof(ExampleIssue).FullName))
            {
                return new ExampleIssue();
            }
            if (type.Equals(typeof(UXMetadataIssue).FullName))
            {
                return new UXMetadataIssue();
            }
            if (type.Equals(typeof(GeneratedSdkIssue).FullName))
            {
                return new GeneratedSdkIssue();
            }

            return null;
        }
    }
}
