## Example Analysis

### What is the purpose of example analysis?
As we know, our cmdlet help markdown is handwritten, which is an error-prone process. Example analysis is one of steps of static analysis, which checks the syntax correctness and completeness of cmdlet help markdown, especially for code blocks in example sections. 

### What will be checked by example analyzer?
Example analyzer will check 
- if there are any missing section heading, like '## EXAMPLES', '## PARAMETERS' and so on.
- if code block type is defined clearly like ```powershell
- if customized rules are violated. Customized rules include
   - Invalid_Cmdlet
   - Is_Alias
   - Capitalization_Conventions_Violated
   - Unknown_Parameter_Set
   - Invalid_Parameter_Name
   - Duplicate_Parameter_Name
   - Unassigned_Parameter
   - Unassigned_Variable
   - Unbinded_Expression
   - Mismatched_Parameter_Value_Type

### What will be ignore by example analyzer?
 - If the example begins with `<!-- Aladdin Generated Example -->` or matches with regex `<!-- Skip.*-->`, its scan will be skipped.

### Miscellaneous
 - 
