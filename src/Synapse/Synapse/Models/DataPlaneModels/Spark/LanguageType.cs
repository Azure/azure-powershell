// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
