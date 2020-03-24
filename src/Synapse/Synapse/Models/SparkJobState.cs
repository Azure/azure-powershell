using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public static class SparkJobState
    {
        public const string Succeeded = nameof(Succeeded);
        public const string Failed = nameof(Failed);
        public const string Cancelled = nameof(Cancelled);
        public const string Running = nameof(Running);
    }

    public static class SparkJobLivyState
    {
        public const string Error = "error";
        public const string Dead = "dead";
        public const string Success = "success";
        public const string Killed = "killed";
        public const string Idle = "idle";
        public const string Running = "running";
        public const string Starting = "starting";

        public static List<string> FinalStates = new List<string>
        {
            Error,
            Dead,
            Success,
            Killed
        };

        public static List<string> SessionSubmissionFinalStates = new List<string>
        {
            Idle,
            Error,
            Dead,
            Success,
            Killed
        };

        public static List<string> SessionCancellationFinalStates = new List<string>
        {
            Error,
            Dead,
            Success,
            Killed
        };

        public static List<string> SessionSubmissionSucceededStates = new List<string>
        {
            Idle
        };

        public static List<string> BatchSubmissionFinalStates = new List<string>
        {
            Starting,
            Running,
            Error,
            Dead,
            Success,
            Killed
        };

        public static List<string> BatchExecutionFinalStates = new List<string>
        {
            Error,
            Dead,
            Success,
            Killed
        };
    }

    public static class SparkSessionStatementLivyState
    {
        public const string Starting = "starting";
        public const string Waiting = "waiting";
        public const string Running = "running";
        public const string Cancelling = "cancelling";
        public const string Ok = "ok";
        public const string Error = "error";

        public static List<string> ExecutingStates = new List<string>
        {
            Starting,
            Waiting,
            Running,
            Cancelling
        };

        public static List<string> CancellableStates = new List<string>
        {
            Starting,
            Waiting,
            Running
        };
    }
}
