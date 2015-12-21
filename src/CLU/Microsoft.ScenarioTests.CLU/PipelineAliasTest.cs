using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Management.Automation;

namespace Microsoft.CLU.Test
{

    public class TestRecord
    {
        public const string DefaultName = "This is the name...";
        public const string DefaultValue = "This is the value!";
        public const string DefaultSomethingElseValue = "This is the SomethingElse value.";

        public TestRecord()
        {
            Name = DefaultName;
            Value = DefaultValue;
            SomethingElse = DefaultSomethingElseValue;
        }

        [Parameter(Mandatory = false)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public string Value { get; set; }

        [Parameter(Mandatory = false)]
        public string SomethingElse { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "TestRecord"), OutputType(typeof(TestRecord))]
    public class NewTestRecord : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            WriteObject(new TestRecord());
        }
    }

    [Cmdlet(VerbsCommon.Show, "TestRecord")]
    public class ShowTestRecord : PSCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Name")]
        public string RecordName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Val")]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string SomethingElse { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ErrorRecord errorRecord = null;
            if (!String.Equals(TestRecord.DefaultValue, Value))
            {
                errorRecord = new ErrorRecord(
                        new InvalidOperationException($"Value mismatch - got {Value}, expected {TestRecord.DefaultValue}"),
                        "TestAssert",
                        ErrorCategory.InvalidOperation,
                        this);
                this.WriteError(errorRecord);
            }
            else if (!String.Equals(TestRecord.DefaultName, RecordName))
            {
                errorRecord = new ErrorRecord(
                        new InvalidOperationException($"Value mismatch - got {RecordName}, expected {TestRecord.DefaultName}"),
                        "TestAssert",
                        ErrorCategory.InvalidOperation,
                        this);
                this.WriteError(errorRecord);
            }
            else if (!String.Equals(TestRecord.DefaultSomethingElseValue, SomethingElse))
            {
                errorRecord = new ErrorRecord(
                        new InvalidOperationException($"Value mismatch - got {SomethingElse}, expected {TestRecord.DefaultSomethingElseValue}"),
                        "TestAssert",
                        ErrorCategory.InvalidOperation,
                        this);
                this.WriteError(errorRecord);
            }

            if (errorRecord != null)
            {
                ThrowTerminatingError(errorRecord);
            }
            WriteObject(new TestRecord() { Name = $"Matched {RecordName}", Value = $"Matched {Value}", SomethingElse = $"Matched {SomethingElse}" });
        }
    }

    [Cmdlet(VerbsCommon.Show, "TestRecordFromParameter")]
    public class ShowTestRecordFromParameter : PSCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [Alias("Rec")]
        public TestRecord Record { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(Record);
        }
    }
}
