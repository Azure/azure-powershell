<?xml version=""1.0"" encoding=""UTF-8"" ?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
<xs:element name=""shiporder"">
  <xs:complexType>
    <xs:sequence>
      <xs:element name=""orderperson"" type=""xs:string""/>
      <xs:element name=""shipto"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""name"" type=""xs:string""/>
            <xs:element name=""address"" type=""xs:string""/>
            <xs:element name=""city"" type=""xs:string""/>
            <xs:element name=""country"" type=""xs:string""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name=""item"" maxOccurs=""unbounded"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""title"" type=""xs:string""/>
            <xs:element name=""note"" type=""xs:string"" minOccurs=""0""/>
            <xs:element name=""quantity"" type=""xs:positiveInteger""/>
            <xs:element name=""price"" type=""xs:decimal""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
    </xs:sequence>
    <xs:attribute name=""orderid"" type=""xs:string"" use=""required""/>
  </xs:complexType>
</xs:element>
</xs:schema> 