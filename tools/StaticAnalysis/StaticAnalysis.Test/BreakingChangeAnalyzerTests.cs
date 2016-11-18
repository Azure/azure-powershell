using StaticAnalysis.ProblemIds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StaticAnalysis.Test
{
    public class BreakingChangeAnalyzerTests
    {
        string testCmdletDirPath, exceptionsDirPath;
        BreakingChangeAnalyzer.BreakingChangeAnalyzer cmdletBreakingChangeAnalyzer;
        AnalysisLogger analysisLogger;

        public BreakingChangeAnalyzerTests()
        {
            testCmdletDirPath = System.Environment.CurrentDirectory;
            exceptionsDirPath = Path.Combine(testCmdletDirPath, "Exceptions");

            analysisLogger = new AnalysisLogger(testCmdletDirPath, exceptionsDirPath);
            cmdletBreakingChangeAnalyzer = new StaticAnalysis.BreakingChangeAnalyzer.BreakingChangeAnalyzer();
            cmdletBreakingChangeAnalyzer.Logger = analysisLogger;
        }

        [Fact()]
        public void RemoveCmdlet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveCmdlet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedCmdlet)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedCmdlet));
        }

        [Fact()]
        public void RemoveCmdletAlias()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveCmdletAlias", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedCmdletAlias)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedCmdletAlias));
        }

        [Fact()]
        public void AddAliasForChangedCmdlet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-AddAliasForChangedCmdlet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact()]
        public void RemoveSupportsShouldProcess()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedShouldProcess)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedShouldProcess));
        }

        [Fact()]
        public void RemoveSupportsPaging()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveSupportsPaging", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedPaging)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedPaging));
        }

        [Fact()]
        public void RemoveParameter()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedParameter)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedParameter));
        }

        [Fact()]
        public void RemoveParameterAlias()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveParameterAlias", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedParameterAlias)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedParameterAlias));
        }

        [Fact()]
        public void AddAliasForChangedParameter()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-AddAliasForChangedParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact()]
        public void MakeParameterRequired()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-MakeParameterRequired", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.MandatoryParameter)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.MandatoryParameter));
        }

        [Fact()]
        public void ChangeParameterOrder()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterOrder", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(3, testReport.ProblemIdList.Count);
            foreach (var problemId in testReport.ProblemIdList)
            {
                Assert.Equal(BreakingChangeProblemId.PositionChange, problemId);
            }
        }

        [Fact()]
        public void ChangeValidateSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeValidateSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(2, testReport.ProblemIdList.Count);
            foreach (var problemId in testReport.ProblemIdList)
            {
                Assert.Equal(BreakingChangeProblemId.RemovedValidateSetValue, problemId);
            }
        }

        [Fact()]
        public void AddValidateSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-AddValidateSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.AddedValidateSet)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.AddedValidateSet));
        }

        [Fact()]
        public void ChangeOutputType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeOutputType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedOutputType)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedOutputType));
        }

        [Fact()]
        public void ChangeOutputTypeName()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeOutputTypeName", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact()]
        public void ChangeParameterType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedParameterType)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedParameterType));
        }

        [Fact()]
        public void RemoveValueFromPipeline()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveValueFromPipeline", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ValueFromPipeline))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ValueFromPipeline));
        }

        [Fact()]
        public void RemoveValueFromPipelineByPropertyName()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveValueFromPipelineByPropertyName", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ValueFromPipelineByPropertyName))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ValueFromPipelineByPropertyName));
        }

        [Fact()]
        public void AddParameterSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-AddParameterSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact()]
        public void RemoveParameterFromParameterSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveParameterFromParameterSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact()]
        public void ChangeParameterSetForParameter()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterSetForParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedParameterFromParameterSet))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedParameterFromParameterSet));
        }

        [Fact()]
        public void ChangeDefaultParameterSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeDefaultParameterSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangeDefaultParameter))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangeDefaultParameter));
        }

        [Fact()]
        public void AddValidateNotNullOrEmpty()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-AddValidateNotNullOrEmpty", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.AddedValidateNotNullOrEmpty))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.AddedValidateNotNullOrEmpty));
        }

        [Fact()]
        public void ChangePropertyType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangePropertyType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedPropertyType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedPropertyType));
        }

        [Fact()]
        public void RemoveProperty()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveProperty", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedProperty))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedProperty));
        }
    }
}
