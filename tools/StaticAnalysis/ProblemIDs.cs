namespace StaticAnalysis.ProblemIds
{
    public static class SignatureProblemId
    {
        public const int ForceWithoutShouldProcessAttribute = 8000;
        public const int ConfirmLeveleWithNoShouldProcess = 8010;
        public const int ActionIndicatesShouldProcess = 8100;
        public const int ConfirmLevelChange = 8200;
        public const int CmdletWithUnapprovedVerb = 8300;
        public const int CmdletWithPluralNoun = 8400;
        public const int ParameterWithPluralNoun = 8410;
        public const int ParameterWithOutOfRangePosition = 8420;
        public const int ParameterSetWithSpace = 8500;
        public const int MultipleParameterSetsWithNoDefault = 8510;
        public const int CmdletWithNoOutputType = 8600;
        public const int ParameterSetWithStrictMandatoryEqual = 8700;
        public const int ParameterSetWithLenientMandatoryEqual = 8710;
        //public const int EmptyDefaultParameterSet = 8800;
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
        public const int RemovedShouldProcess = 1030;
        public const int RemovedPaging = 1040;
        public const int RemovedParameterSet = 1050;
        public const int ChangeDefaultParameter = 1060;
        public const int ChangedOutputElementType = 1070;
        public const int ChangedOutputGenericType = 1080;
        public const int ChangedOutputGenericTypeArgument = 1090;
        public const int DifferentOutputGenericTypeArgumentSize = 1100;
        public const int RemovedParameter = 2000;
        public const int RemovedParameterAlias = 2010;
        public const int ChangedParameterType = 2020;
        public const int MandatoryParameter = 2030;
        public const int RemovedValidateSetValue = 2040;
        public const int AddedValidateSet = 2050;
        public const int PositionChange = 2060;
        public const int ValueFromPipeline = 2070;
        public const int ValueFromPipelineByPropertyName = 2080;
        public const int AddedValidateNotNullOrEmpty = 2090;
        public const int RemovedParameterFromParameterSet = 2100;
        public const int ChangedParameterElementType = 2110;
        public const int ChangedParameterGenericType = 2120;
        public const int ChangedParameterGenericTypeArgument = 2130;
        public const int DifferentParameterGenericTypeArgumentSize = 2140;
        public const int AddedValidateRange = 2150;
        public const int ChangedValidateRangeMinimum = 2160;
        public const int ChangedValidateRangeMaximum = 2170;
        public const int ChangedPropertyType = 3000;
        public const int RemovedProperty = 3010;
        public const int ChangedElementType = 3020;
        public const int ChangedGenericType = 3030;
        public const int ChangedGenericTypeArgument = 3040;
        public const int DifferentGenericTypeArgumentSize = 3050;
    }
}
