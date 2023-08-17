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
    
    //ExampleProblemId is also defined in tools\StaticAnalysis\ExampleAnalyzer, the range is 5000-5199
    public static class ExampleProblemId
    {
        public const int Invalid_Cmdlet = 5000; 
        public const int Unknown_Parameter_Set = 5010; 
        public const int Invalid_Parameter_Name = 5011;
        public const int Duplicate_Parameter_Name = 5012; 
        public const int Unassigned_Parameter = 5013; 
        public const int Unbinded_Parameter_Name = 5014;
        public const int MissingSynopsis = 5040; 
        public const int MissingDescription = 5041; 
        public const int MissingExample = 5042; 
        public const int MissingExampleTitle = 5043;
        public const int MissingExampleCode = 5044; 
        public const int MissingExampleOutput = 5045; 
        public const int MissingExampleDescription = 5046;
        public const int NeedDeleting = 5050; 
        public const int NeedSplitting = 5051; 
        public const int Is_Alias = 5100; 
        public const int Capitalization_Conventions_Violated = 5101;
        public const int Unassigned_Variable = 5110; 
        public const int Mismatched_Parameter_Value_Type = 5111;
    }
}
