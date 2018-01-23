using StaticAnalysis.BreakingChangeAnalyzer;
using StaticAnalysis.ProblemIds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace StaticAnalysis.Test
{
    public class BreakingChangeAnalyzerTests
    {
        string _testCmdletDirPath, _exceptionsDirPath;
        BreakingChangeAnalyzer.BreakingChangeAnalyzer cmdletBreakingChangeAnalyzer;
        AnalysisLogger analysisLogger;
        ITestOutputHelper xunitOutput;

        public BreakingChangeAnalyzerTests(ITestOutputHelper testOutput)
        {
            _testCmdletDirPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            _exceptionsDirPath = Path.Combine(_testCmdletDirPath, "Exceptions");

            analysisLogger = new AnalysisLogger(_testCmdletDirPath, _exceptionsDirPath);
            cmdletBreakingChangeAnalyzer = new StaticAnalysis.BreakingChangeAnalyzer.BreakingChangeAnalyzer();
            cmdletBreakingChangeAnalyzer.Logger = analysisLogger;

            xunitOutput = testOutput;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveCmdlet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveCmdlet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveCmdlet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedCmdlet)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedCmdlet));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveCmdletAlias()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveCmdletAlias", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveCmdletAlias\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedCmdletAlias)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedCmdletAlias));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAliasForChangedCmdlet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-AddAliasForChangedCmdlet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-AddAliasForChangedCmdlet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSupportsShouldProcess()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveSupportsShouldProcess\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedShouldProcess)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedShouldProcess));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSupportsPaging()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveSupportsPaging", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveSupportsPaging\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedPaging)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedPaging));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveParameterAlias()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveParameterAlias", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveParameterAlias\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedParameterAlias)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedParameterAlias));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAliasForChangedParameter()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-AddAliasForChangedParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-AddAliasForChangedParameter\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MakeParameterRequired()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-MakeParameterRequired", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-MakeParameterRequired\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.MandatoryParameter)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.MandatoryParameter));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeParameterOrder()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterOrder", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeParameterOrder\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(3, testReport.ProblemIdList.Count);
            foreach (var problemId in testReport.ProblemIdList)
            {
                Assert.Equal(BreakingChangeProblemId.PositionChange, problemId);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeValidateSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeValidateSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeValidateSet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(2, testReport.ProblemIdList.Count);
            foreach (var problemId in testReport.ProblemIdList)
            {
                Assert.Equal(BreakingChangeProblemId.RemovedValidateSetValue, problemId);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddValidateSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-AddValidateSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-AddValidateSet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.AddedValidateSet)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.AddedValidateSet));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeOutputType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeOutputType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeOutputType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedOutputType)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedOutputType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeParameterType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeParameterType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedParameterType)).SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedParameterType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveValueFromPipeline()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveValueFromPipeline", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveValueFromPipeline\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ValueFromPipeline))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ValueFromPipeline));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveValueFromPipelineByPropertyName()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveValueFromPipelineByPropertyName", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveValueFromPipelineByPropertyName\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ValueFromPipelineByPropertyName))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ValueFromPipelineByPropertyName));
        }

        [Fact(Skip = "Will fix as part of breaking change tool refactor: https://github.com/Azure/azure-powershell/issues/3507")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddParameterSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-AddParameterSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-AddParameterSet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveParameterFromParameterSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveParameterFromParameterSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveParameterFromParameterSet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeParameterSetForParameter()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterSetForParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeParameterSetForParameter\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedParameterFromParameterSet))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedParameterFromParameterSet));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeDefaultParameterSet()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeDefaultParameterSet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeDefaultParameterSet\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangeDefaultParameter))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangeDefaultParameter));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddValidateNotNullOrEmpty()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-AddValidateNotNullOrEmpty", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-AddValidateNotNullOrEmpty\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.AddedValidateNotNullOrEmpty))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.AddedValidateNotNullOrEmpty));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangePropertyType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangePropertyType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangePropertyType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedPropertyType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedPropertyType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveProperty()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-RemoveProperty", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-RemoveProperty\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.RemovedProperty))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.RemovedProperty));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeParameterElementType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterElementType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeParameterElementType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedParameterElementType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedParameterElementType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeParameterGenericType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterGenericType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeParameterGenericType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedGenericType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedGenericType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeParameterGenericTypeArgument()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeParameterGenericTypeArgument", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeParameterGenericTypeArgument\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedGenericType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedGenericType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DifferentParameterGenericTypeArgumentSize()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-DifferentParameterGenericTypeArgumentSize", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-DifferentParameterGenericTypeArgumentSize\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedGenericType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedGenericType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeElementType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeElementType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeElementType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedElementType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedElementType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeGenericType()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeGenericType", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeGenericType\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedGenericType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedGenericType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeGenericTypeArgument()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangeGenericTypeArgument", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-ChangeGenericTypeArgument\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedGenericType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedGenericType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DifferentGenericTypeArgumentSize()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-DifferentGenericTypeArgumentSize", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            string output = "Test-DifferentGenericTypeArgumentSize\nProblemId Count: " + testReport.ProblemIdList.Count;

            foreach (var problemId in testReport.ProblemIdList)
            {
                output += "\nProblemId: " + problemId;
            }

            xunitOutput.WriteLine(output);

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedGenericType))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedGenericType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddValidateRange()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-AddedValidateRange", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.AddedValidateRange))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.AddedValidateRange));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeValidateRangeMinimum()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangedValidateRangeMinimum", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedValidateRangeMinimum))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedValidateRangeMinimum));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeValidateRangeMaximum()
        {
            cmdletBreakingChangeAnalyzer.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Test-ChangedValidateRangeMaximum", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletBreakingChangeAnalyzer.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList
                .Where<int>((problemId) => problemId.Equals(BreakingChangeProblemId.ChangedValidateRangeMaximum))
                            .SingleOrDefault<int>().Equals(BreakingChangeProblemId.ChangedValidateRangeMaximum));
        }
    }
}
