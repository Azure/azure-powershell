using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public static class LanguageType
    {
        public const string Spark = "spark";

        public const string PySpark = "pyspark";

        public const string SparkDotNet = "sparkdotnet";

        public const string SparkSql = "sql";

        public const string Python = "python";

        public const string Scala = "scala";

        public const string CSharp = "csharp";

        public static string Parse(string language)
        {
            switch (language?.ToLower())
            {
                case "python": case "pyspark": return PySpark;
                case "csharp": case "sparkdotnet": return SparkDotNet;
                case "scala": case "spark": return Spark;
                case "sql": return SparkSql;
                default: return language;
            }
        }
    }
}
