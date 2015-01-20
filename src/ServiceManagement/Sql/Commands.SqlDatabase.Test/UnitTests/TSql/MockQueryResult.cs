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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    [Serializable]
    public class MockQueryResult
    {
        /// <summary>
        /// Mock Query id 
        /// </summary>
        private string mockId;

        /// <summary>
        /// Name of the database being queried
        /// </summary>
        private string databaseName;

        /// <summary>
        /// The command being executed
        /// </summary>
        private string commandText;

        /// <summary>
        /// The result if the result is a scalar
        /// </summary>
        private object scalarResult;

        /// <summary>
        /// The result if the result is a data set
        /// </summary>
        private MockDataSet dataSetResult;

        /// <summary>
        /// The result if an exception is thrown
        /// </summary>
        private MockException exceptionResult;

        /// <summary>
        /// Gets or sets the mock id for this query
        /// </summary>
        [XmlElement]
        public string MockId
        {
            get { return this.mockId; }
            set { this.mockId = value; }
        }

        /// <summary>
        /// Gets or sets the name of the database being queried
        /// </summary>
        [XmlElement]
        public string DatabaseName
        {
            get { return this.databaseName; }
            set { this.databaseName = value; }
        }

        /// <summary>
        /// Gets or sets the command that is being recorded
        /// </summary>
        [XmlElement]
        public string CommandText
        {
            get { return this.commandText; }
            set { this.commandText = value; }
        }

        /// <summary>
        /// Gets or sets the scalar result of the query
        /// </summary>
        [XmlElement]
        public object ScalarResult
        {
            get { return this.scalarResult; }
            set { this.scalarResult = value; }
        }

        /// <summary>
        /// Gets or sets the data set result of the query
        /// </summary>
        [XmlElement]
        public MockDataSet DataSetResult
        {
            get { return this.dataSetResult; }
            set { this.dataSetResult = value; }
        }

        /// <summary>
        /// gets or sets the exception result of the query
        /// </summary>
        [XmlElement]
        public MockException ExceptionResult
        {
            get { return this.exceptionResult; }
            set { this.exceptionResult = value; }
        }
    }

    /// <summary>
    /// Represents a dataset that was recorded
    /// </summary>
    public class MockDataSet : IXmlSerializable
    {
        /// <summary>
        /// The data set
        /// </summary>
        private DataSet dataSet;

        /// <summary>
        /// Constructor
        /// </summary>
        public MockDataSet()
        {
        }

        /// <summary>
        /// Constructor that sets the data set
        /// </summary>
        /// <param name="dataSet">The dataset to initialize this instance with</param>
        public MockDataSet(DataSet dataSet)
        {
            this.dataSet = dataSet;
        }

        /// <summary>
        /// Gets or sets the data set for the mock
        /// </summary>
        public DataSet DataSet
        {
            get { return this.dataSet; }
            set { this.dataSet = value; }
        }

        #region IXmlSerializable Members

        /// <summary>
        /// No schema
        /// </summary>
        /// <returns>Always null</returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Helper function to parse the xml into a dataset
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.dataSet = new DataSet();
            this.dataSet.ReadXml(reader, XmlReadMode.ReadSchema);
        }

        /// <summary>
        /// Helper function to write the dataset to XML
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            this.dataSet.WriteXml(writer, XmlWriteMode.WriteSchema);
        }

        #endregion
    }

    /// <summary>
    /// Represents an exception in the mock
    /// </summary>
    public class MockException : IXmlSerializable
    {
        /// <summary>
        /// Type key for binary exception data
        /// </summary>
        private const string BinaryExceptionTypeKey = "MockExceptionBinary";

        /// <summary>
        /// Type key for sql exception data
        /// </summary>
        private const string SqlExceptionTypeKey = "SqlException";

        /// <summary>
        /// The exception
        /// </summary>
        private Exception exception;

        /// <summary>
        /// C'tor.
        /// </summary>
        public MockException()
        {
        }

        /// <summary>
        /// Constructor that initializes the class with an exception 
        /// </summary>
        /// <param name="exception">The exception data to initialize the instance with</param>
        public MockException(Exception exception)
        {
            this.exception = exception;
        }

        /// <summary>
        /// Gets or sets the exception
        /// </summary>
        public Exception Exception
        {
            get { return this.exception; }
            set { this.exception = value; }
        }

        #region IXmlSerializable Members

        /// <summary>
        /// No schema
        /// </summary>
        /// <returns>Always null</returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Helper function to get data from the XmlReader and transform it into a MockException
        /// </summary>
        /// <param name="reader">The reader to read from</param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();
            string mockExceptionType = reader.Name;
            if (mockExceptionType == BinaryExceptionTypeKey)
            {
                // Deserialize a binary serialized exception.
                reader.ReadStartElement();
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(System.Convert.FromBase64String(reader.ReadContentAsString()));
                this.exception = (Exception)formatter.Deserialize(stream);
                reader.ReadEndElement();
            }
            else if (mockExceptionType == SqlExceptionTypeKey)
            {
                // Deserialize a SqlException.
                this.exception = DeserializeSqlException(reader);
            }
            else
            {
                // Unknown mock exception type
                throw new XmlException(string.Format("Unknown mock exception type '{0}' in mock query result.", mockExceptionType));
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// Helper function to store the MockException in xml
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            Type exceptionType = this.exception.GetType();
            if (exceptionType == typeof(SqlException))
            {
                // For SqlExceptions, serialize in text form, for easy viewing/editing
                writer.WriteStartElement(SqlExceptionTypeKey);
                if (exception.Data.Contains("HelpLink.ProdVer"))
                {
                    writer.WriteStartElement("serverVersion");
                    writer.WriteValue(exception.Data["HelpLink.ProdVer"]);
                    writer.WriteEndElement();
                }
                foreach (SqlError error in ((SqlException)exception).Errors)
                {
                    writer.WriteStartElement("SqlError");
                    foreach (KeyValuePair<string, string> pair in new KeyValuePair<string, string>[]{
                        new KeyValuePair<string, string>("infoNumber", error.Number.ToString()),
                        new KeyValuePair<string, string>("errorState", error.State.ToString()),
                        new KeyValuePair<string, string>("errorClass", error.Class.ToString()),
                        new KeyValuePair<string, string>("server", error.Server),
                        new KeyValuePair<string, string>("errorMessage", error.Message),
                        new KeyValuePair<string, string>("procedure", error.Procedure),
                        new KeyValuePair<string, string>("lineNumber", error.LineNumber.ToString())})
                    {
                        writer.WriteStartElement(pair.Key);
                        writer.WriteValue(pair.Value);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            else if (exceptionType.IsSerializable)
            {
                // For any other serializable exceptions, use the BinaryFormatter to generate serialize it in binary form, and save it in Xml as Base64.
                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this.exception);
                string serializedException = System.Convert.ToBase64String(stream.ToArray());
                writer.WriteStartElement(BinaryExceptionTypeKey);
                writer.WriteValue(serializedException);
                writer.WriteEndElement();
            }
            else
            {
                // Non-Serializable exceptions, nothing can be done at this time
                throw new XmlException(string.Format("Unknown mock exception type '{0}' for serialization.", exceptionType.ToString()));
            }
        }

        #endregion

        #region Deserializer Helpers

        /// <summary>
        /// Custom helper to deserialize a SqlException object from Xml.
        /// </summary>
        private static SqlException DeserializeSqlException(System.Xml.XmlReader reader)
        {
            // SqlException constructor takes in two parameters, an errorCollection and a serverVersion.
            SqlErrorCollection errorCollection = (SqlErrorCollection)typeof(SqlErrorCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, System.Type.EmptyTypes, null).Invoke(null); ;
            string serverVersion = null;

            // Read the subtree and fill in the parameters.
            int startDepth = reader.Depth;
            reader.ReadStartElement();
            while (reader.Depth > startDepth)
            {
                switch (reader.Name)
                {
                    case "serverVersion":
                        serverVersion = reader.ReadElementContentAsString();
                        break;
                    case "SqlError":
                        SqlError newSqlError = DeserializeSqlError(reader);
                        errorCollection.GetType().GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(errorCollection, new object[] { newSqlError });
                        break;
                }
            }
            reader.ReadEndElement();

            // Use reflection to create the SqlException.
            Type sqlExceptionType = typeof(SqlException);
            Type[] types = { typeof(SqlErrorCollection), typeof(String) };
            MethodInfo info = sqlExceptionType.GetMethod("CreateException", BindingFlags.Static | BindingFlags.NonPublic, null, types, null);
            return (SqlException)info.Invoke(null, new object[] { errorCollection, serverVersion });
        }

        /// <summary>
        /// Custom helper to deserialize a SqlError object from Xml.
        /// </summary>
        private static SqlError DeserializeSqlError(System.Xml.XmlReader reader)
        {
            Dictionary<string, string> sqlErrorParameters = new Dictionary<string, string>();

            // Read the subtree and fill in the parameters.
            int startDepth = reader.Depth;
            reader.ReadStartElement();
            while (reader.Depth > startDepth)
            {
                string name = reader.Name;
                string value = reader.ReadElementContentAsString();
                sqlErrorParameters.Add(name, value);
            }
            reader.ReadEndElement();
            // Make sure all parameters were defined.
            if ((!sqlErrorParameters.ContainsKey("infoNumber")) ||
                (!sqlErrorParameters.ContainsKey("errorState")) ||
                (!sqlErrorParameters.ContainsKey("errorClass")) ||
                (!sqlErrorParameters.ContainsKey("server")) ||
                (!sqlErrorParameters.ContainsKey("errorMessage")) ||
                (!sqlErrorParameters.ContainsKey("procedure")) ||
                (!sqlErrorParameters.ContainsKey("lineNumber")))
            {
                // Incomplete definition
                throw new XmlException("Incomplete definition of 'SqlError' in mock query result.");
            }

            // Using reflection to create a new SqlError object.
            SqlError newSqlError = (SqlError)typeof(SqlError).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { 
                typeof(int), typeof(byte), typeof(byte), typeof(string), typeof(string), typeof(string), typeof(int) }, null).Invoke(new object[]{
                int.Parse(sqlErrorParameters["infoNumber"]), 
                byte.Parse(sqlErrorParameters["errorState"]), 
                byte.Parse(sqlErrorParameters["errorClass"]),
                sqlErrorParameters["server"], 
                sqlErrorParameters["errorMessage"], 
                sqlErrorParameters["procedure"],
                int.Parse(sqlErrorParameters["lineNumber"])});
            return newSqlError;
        }

        #endregion

    }

    /// <summary>
    /// Represents a mock query result set
    /// </summary>
    [Serializable]
    public class MockQueryResultSet
    {
        /// <summary>
        /// a list of all the results for the command
        /// </summary>
        private List<MockQueryResult> commandResults = new List<MockQueryResult>();

        /// <summary>
        /// Gets or sets the list of all the results for the command
        /// </summary>
        [XmlElement("MockQueryResult")]
        public List<MockQueryResult> CommandResults
        {
            get { return this.commandResults; }
            set { this.commandResults = value; }
        }

        /// <summary>
        /// Helper function to deserialize the mock query result set from the stream
        /// </summary>
        /// <param name="stream">Stream containing query results</param>
        /// <returns>An instance of <see cref="MockQueryResultSet"/></returns>
        public static MockQueryResultSet Deserialize(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MockQueryResultSet));
            using (StreamReader reader = new StreamReader(stream))
            {
                return (MockQueryResultSet)serializer.Deserialize(reader);
            }
        }


        /// <summary>
        /// Serializes the provided <see cref="MockQueryResultSet"/> into the stream
        /// </summary>
        /// <param name="stream">Where to output the serialization</param>
        /// <param name="value">What to serialize</param>
        public static void Serialize(Stream stream, MockQueryResultSet value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MockQueryResultSet));
            using (StreamWriter writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}
