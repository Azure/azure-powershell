namespace StaticAnalysis.ProblemIds
{
    public static class SignatureProblemId
    {
        public const int ForceWithoutShouldProcessAttribute = 8000;
        public const int ConfirmLeveleWithNoShouldProcess = 8010;
        public const int ActionIndicatesShouldProcess = 8100;
        public const int ConfirmLevelChange = 8200;
        public const int CmdletWithDestructiveVerbNoForce = 8210;
        public const int CmdletWithUnapprovedVerb = 8300;
        public const int CmdletWithPluralNoun = 8400;
        public const int ParameterWithPluralNoun = 8410;
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
}
