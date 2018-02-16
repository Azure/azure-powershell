/// <summary>
/// Tests for testing Static Analysis tool for cmdLets Signature issues
/// </summary>
namespace StaticAnalysis.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Xunit;
    using System.Linq;
    using StaticAnalysis.ProblemIds;
    using System.Reflection;

    /// <summary>
    /// Add a way to send filterDirectory, FiltercmdLets delegates to the analyze method.
    /// Add a switch to skip analyze
    /// Split the test between, testing Main vs testing Analyze
    /// 
    /// Add Rule Engine that deals with Parameter Rules (mutually exclusive parameters, mandatory parameter rules, force parameter rule)
    /// 
    /// </summary>
    public class SignatureVerifierTests
    {
        string _testCmdletDirPath, _exceptionsDirPath;
        SignatureVerifier.SignatureVerifier cmdletSignatureVerifier;
        AnalysisLogger analysisLogger;

        public SignatureVerifierTests()
        {
            _testCmdletDirPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            _exceptionsDirPath = Path.Combine(_testCmdletDirPath, "Exceptions");

            analysisLogger = new AnalysisLogger(_testCmdletDirPath, _exceptionsDirPath);
            cmdletSignatureVerifier = new StaticAnalysis.SignatureVerifier.SignatureVerifier();
            cmdletSignatureVerifier.Logger = analysisLogger;
        }

        #region Verb Cmdlets and SupportsShouldProcess
        /// <summary>
        /// 
        /// </summary>        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddVerbWithoutSupportsShouldProcessParameter()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath},
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Add-AddVerbWithoutSupportsShouldProcessParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();

            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ActionIndicatesShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ActionIndicatesShouldProcess));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddVerbWithSupportsShouldProcessParameter()
        {   
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath},
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Add-AddVerbWithSupportsShouldProcessParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
            //Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ActionIndicatesShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ActionIndicatesShouldProcess));
        }
        #endregion

        #region ForceSwitch and SupportsShouldProcess
                
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ForceParameterWithoutSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Test-ForceParameterWithoutSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            analysisLogger.Info("Foo");


            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ForceWithoutShouldProcessAttribute)).SingleOrDefault<int>().Equals(SignatureProblemId.ForceWithoutShouldProcessAttribute));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ForceParameterWithSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Test-ForceParameterWithSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        #endregion

        #region ConfirmImpact and SupportsShouldProcess
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmImpactWithSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Test-ConfirmImpactWithSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmImpactWithoutSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Test-ConfirmImpactWithoutSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(2, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ConfirmLeveleWithNoShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ConfirmLeveleWithNoShouldProcess));
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ConfirmLevelChange)).SingleOrDefault<int>().Equals(SignatureProblemId.ConfirmLevelChange));
        }
        #endregion

        #region IsShouldContinueVerb
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldContinueVerbWithForceSwitch()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath}; }),
                (cmdletName) => cmdletName.Equals("Copy-ShouldContinueVerbWithForceSwitch", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }
        #endregion

        #region CmdletWithUnapprovedVerb
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CmdletWithApprovedVerb()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Get-SampleCmdlet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CmdletWithUnapprovedVerb()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Prepare-SampleCmdlet", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.CmdletWithUnapprovedVerb)).SingleOrDefault<int>().Equals(SignatureProblemId.CmdletWithUnapprovedVerb));
        }
        #endregion

        #region CmdletWithPluralNoun
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CmdletWithSingularNoun()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Get-SampleKey", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CmdletWithPluralNoun()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Get-SampleKeys", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.CmdletWithPluralNoun)).SingleOrDefault<int>().Equals(SignatureProblemId.CmdletWithPluralNoun));
        }
        #endregion

        #region ParameterWithPluralNoun
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParameterWithSingularNoun()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Get-SampleFoo", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParameterWithPluralNoun()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Get-SampleBar", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(1, testReport.ProblemIdList.Count);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ParameterWithPluralNoun)).SingleOrDefault<int>().Equals(SignatureProblemId.ParameterWithPluralNoun));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CmdletAndParameterWithSingularNounInList()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { _testCmdletDirPath },
                ((dirList) => { return new List<string> { _testCmdletDirPath }; }),
                (cmdletName) => cmdletName.Equals("Get-SampleValue", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.Equal(0, testReport.ProblemIdList.Count);
        }
        #endregion
    }
}
