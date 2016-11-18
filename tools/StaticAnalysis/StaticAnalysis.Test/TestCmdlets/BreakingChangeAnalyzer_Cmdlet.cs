namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveCmdletAlias
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveCmdletAlias")]
    public class TestRemoveCmdletAlias : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveCmdletAlias BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.AddAliasForChangedCmdlet
{
    using System.Management.Automation;

    [Alias("Test-AddAliasForChangedCmdlet")]
    [Cmdlet(VerbsDiagnostic.Test, "ChangedCmdlet")]
    public class TestAddAliasForChangedCmdlet : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-AddAliasForChangeCmdlet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveSupportsShouldProcess
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveSupportsShouldProcess")]
    public class TestRemoveSupportsShouldProcess : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveSupportsShouldProcess BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveSupportsPaging
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveSupportsPaging")]
    public class TestRemoveSupportsPaging : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveSupportsPaging BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveParameter
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveParameter")]
    public class TestRemoveParameter : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveParameter BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveParameterAlias
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveParameterAlias")]
    public class TestRemoveParameterAlias : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Switch { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveParameterAlias BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.AddAliasForChangedParameter
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "AddAliasForChangedParameter")]
    public class TestAddAliasForChangedParameter : Cmdlet
    {
        [Alias("Parameter")]
        [Parameter(Mandatory = false)]
        public string ChangedParameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-AddAliasForChangedParameter BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.MakeParameterRequired
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "MakeParameterRequired")]
    public class TestMakeParameterRequired : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public SwitchParameter Switch { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-MakeParameterRequired BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeParameterOrder
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "ChangeParameterOrder")]
    public class TestChangeParameterOrder : Cmdlet
    {
        [Parameter(Position = 1)]
        public SwitchParameter FirstSwitch { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter SecondSwitch { get; set; }

        [Parameter(Position = 0)]
        public SwitchParameter ThirdSwitch { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeParameterOrder BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeValidateSet
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "ChangeValidateSet")]
    public class TestChangeValidateSet : Cmdlet
    {
        [Parameter(Mandatory = false)]
        [ValidateSet("First")]
        public string Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeValidateSet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.AddValidateSet
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "AddValidateSet")]
    public class TestAddValidateSet : Cmdlet
    {
        [Parameter(Mandatory = false)]
        [ValidateSet("Foo")]
        public string Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-AddValidateSet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeOutputType
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "ChangeOutputType"), OutputType(typeof(int))]
    public class TestChangeOutputType : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeOutputType BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeOutputTypeName
{
    using System.Management.Automation;

    public class ChangedOutput
    {
        public string PropertyOne { get; set; }
        public int PropertyTwo { get; set; }
        public bool PropertyThree { get; set; }
    }

    [Cmdlet(VerbsDiagnostic.Test, "ChangeOutputTypeName"), OutputType(typeof(ChangedOutput))]
    public class TestChangeOutputTypeName : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeOutputTypeName BeginProcess()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangePropertyType
{
    using System.Management.Automation;

    public class TestType
    {
        public int PropertyOne { get; set; }
        public int PropertyTwo { get; set; }
        public bool PropertyThree { get; set; }
    }

    public class TestOutput
    {
        public string PropertyOne { get; set; }
        public TestType PropertyTwo { get; set; }
    }

    [Cmdlet(VerbsDiagnostic.Test, "ChangePropertyType"), OutputType(typeof(TestOutput))]
    public class TestChangePropertyType : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangePropertyType BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveProperty
{
    using System.Management.Automation;

    public class TestType
    {
        public int PropertyTwo { get; set; }
        public bool PropertyThree { get; set; }
    }

    public class TestOutput
    {
        public string PropertyOne { get; set; }
        public TestType PropertyTwo { get; set; }
    }

    [Cmdlet(VerbsDiagnostic.Test, "RemoveProperty"), OutputType(typeof(TestOutput))]
    public class TestRemoveProperty : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveProperty BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeParameterType
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "ChangeParameterType")]
    public class TestChangeParameterType : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public int Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeParameterType BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveValueFromPipeline
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveValueFromPipeline")]
    public class TestRemoveValueFromPipeline : Cmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = false)]
        public string Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveValueFromPipeline BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveValueFromPipelineByPropertyName
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveValueFromPipelineByPropertyName")]
    public class TestRemoveValueFromPipelineByPropertyName : Cmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false)]
        public string Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveValueFromPipelineByPropertyName BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.AddParameterSet
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "AddParameterSet")]
    public class TestAddParameterSet : Cmdlet
    {
        [Parameter(ParameterSetName = "SampleParameterSet", Mandatory = false)]
        public string Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-AddParameterSet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.RemoveParameterFromParameterSet
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "RemoveParameterFromParameterSet")]
    public class TestRemovedParameterFromParameterSet : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public string Foo { get; set; }

        [Parameter(ParameterSetName = "SampleParameterSet", Mandatory = false)]
        public string Bar { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-RemoveParameterFromParameterSet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeParameterSetForParameter
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "ChangeParameterSetForParameter")]
    public class TestChangeParameterSetForParameter : Cmdlet
    {
        [Parameter(ParameterSetName = "NewParameterSet", Mandatory = false)]
        public string Foo { get; set; }

        [Parameter(ParameterSetName = "SampleParameterSet", Mandatory = false)]
        public string Bar { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeParameterSetForParameter BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.ChangeDefaultParameterSet
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "ChangeDefaultParameterSet", DefaultParameterSetName = "Bar")]
    public class TestChangeDefaultParameterSet : Cmdlet
    {
        [Parameter(ParameterSetName = "Foo", Mandatory = false)]
        public string First { get; set; }

        [Parameter(ParameterSetName = "Bar", Mandatory = false)]
        public string Second { get; set; }

        [Parameter(Mandatory = false)]
        public string Third { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-ChangeDefaultParameterSet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.BreakingChange.AddValidateNotNullOrEmpty
{
    using System.Management.Automation;

    [Cmdlet(VerbsDiagnostic.Test, "AddValidateNotNullOrEmpty")]
    public class TestAddValidateNotNullOrEmpty : Cmdlet
    {
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Parameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Test-AddValidateSet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}