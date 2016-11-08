namespace StaticAnalysis.ProblemIds
{
    public static class SignatureProblemId
    {
        public const int ForceWithoutShouldProcessAttribute = 8000;
        public const int ConfirmLeveleWithNoShouldProcess = 8010;
        public const int ActionIndicatesShouldProcess = 8100;
        public const int ConfirmLevelChange = 8200;
        public const int CmdletWithDestructiveVerbNoForce = 8210;
        public const int CmdletWithDestructiveVerb = 98300;
        public const int CmdletWithForceParameter = 98310;
    }

    public static class HelpProblemId
    {
        public const int MissingHelp = 6050;
        public const int MissingHelpFile = 6000;
    }

    public static class DependencyProblemId
    {
        public const int NoAssemblyVersionEvidence = 1000;
        public const int ReferenceDoesNotMatchAssemblyVersion = 1010;
        public const int ExtraAssemblyRecord = 2000;
        public const int MissingAssemblyRecord = 3000;
        public const int AssemblyVersionFileVersionMismatch = 7000;
        public const int CommonAuthenticationMismatch = 7010;
    }

    public static class BreakingChangeProblemId
    {
        public const int RemovedCmdlet = 1000;
        public const int RemovedCmdletAlias = 1010;
        public const int ChangedOutputType = 1020;
        public const int ChangedOutputTypeProperty = 1030;
        public const int RemovedParameter = 2000;
        public const int RemovedParameterAlias = 2010;
        public const int ChangedParameterType = 2020;
        public const int ChangedParameterTypeProperty = 2030;
        public const int RemovedParameterTypeProperty = 2040;
        public const int MandatoryParameter = 2050;
        public const int ValidateSet = 2060;
        public const int PositionChange = 2070;
        public const int ValueFromPipeline = 2080;
        public const int ValueFromPipelineByPropertyName = 2090;
        public const int RemovedShouldProcess = 3000;
        public const int RemovedPaging = 3010;
    }
}
