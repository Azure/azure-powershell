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
        string testCmdletDirPath, exceptionsDirPath;
        SignatureVerifier.SignatureVerifier cmdletSignatureVerifier;
        AnalysisLogger analysisLogger;

        public SignatureVerifierTests()
        {
            testCmdletDirPath = System.Environment.CurrentDirectory;
            exceptionsDirPath = Path.Combine(testCmdletDirPath, "Exceptions");

            analysisLogger = new AnalysisLogger(testCmdletDirPath, exceptionsDirPath);
            cmdletSignatureVerifier = new StaticAnalysis.SignatureVerifier.SignatureVerifier();
            cmdletSignatureVerifier.Logger = analysisLogger;
        }

        #region Verb Cmdlets and SupportsShouldProcess
        /// <summary>
        /// 
        /// </summary>
        [Fact(Skip = "Failing on-demand build, unable to repo locally")]
        public void AddVerbWithoutSupportsShouldProcessParameter()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Add-AddVerbWithoutSupportsShouldProcessParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();

            Assert.True(testReport.ProblemIdList.Count == 1);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ActionIndicatesShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ActionIndicatesShouldProcess));
        }

        [Fact]
        public void AddVerbWithSupportsShouldProcessParameter()
        {   
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Add-AddVerbWithSupportsShouldProcessParameter", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 0);
            //Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ActionIndicatesShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ActionIndicatesShouldProcess));
        }
        #endregion

        #region ForceSwitch and SupportsShouldProcess

        [Fact(Skip = "Failing on-demand build, unable to repo locally")]
        public void ForceParameterWithoutSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ForceParameterWithoutSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 1);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ForceWithoutShouldProcessAttribute)).SingleOrDefault<int>().Equals(SignatureProblemId.ForceWithoutShouldProcessAttribute));
        }

        [Fact]
        public void ForceParameterWithSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ForceParameterWithSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 0);
        }

        #endregion

        #region ConfirmImpact and SupportsShouldProcess
        [Fact]
        public void ConfirmImpactWithSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ConfirmImpactWithSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 0);
        }

        [Fact(Skip = "Failing on-demand build, unable to repo locally")]
        public void ConfirmImpactWithoutSupportsShouldProcess()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Test-ConfirmImpactWithoutSupportsShouldProcess", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 2);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ConfirmLeveleWithNoShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ConfirmLeveleWithNoShouldProcess));
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ConfirmLevelChange)).SingleOrDefault<int>().Equals(SignatureProblemId.ConfirmLevelChange));
        }
        #endregion

        #region IsShouldContinueVerb and ForceSwitch
        [Fact]
        public void ShouldContinueVerbWithForceSwitch()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Copy-ShouldContinueVerbWithForceSwitch", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 0);
        }

        [Fact(Skip = "Failing on-demand build, unable to repo locally")]
        public void ShouldContinueVerbWithoutForceSwitch()
        {
            cmdletSignatureVerifier.Analyze(
                new List<string> { Environment.CurrentDirectory },
                ((dirList) => { return new List<string> { Environment.CurrentDirectory }; }),
                (cmdletName) => cmdletName.Equals("Export-ShouldContinueVerbWithoutForceSwitch", StringComparison.OrdinalIgnoreCase));

            AnalysisReport testReport = cmdletSignatureVerifier.GetAnalysisReport();
            Assert.True(testReport.ProblemIdList.Count == 2);
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.CmdletWithDestructiveVerbNoForce)).SingleOrDefault<int>().Equals(SignatureProblemId.CmdletWithDestructiveVerbNoForce));
            Assert.True(testReport.ProblemIdList.Where<int>((problemId) => problemId.Equals(SignatureProblemId.ActionIndicatesShouldProcess)).SingleOrDefault<int>().Equals(SignatureProblemId.ActionIndicatesShouldProcess));
        }
        #endregion
    }
}
