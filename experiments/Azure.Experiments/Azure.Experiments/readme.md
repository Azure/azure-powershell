# Stages

1. Get a current Azure state. Each resource has a function to get information from Azure.
   The function is an asynchronous operation.
2. Analyze the state. For example, extract a location from the state.
   The analysis is a syncronous operation. On this stage, a user interaction may be required.
   All decisions has to be made on this stage.
3. Create a graph of create/update operations. This operation is synchronous.
4. Execute the graph. This operation is asynchronous and may require a progress bar, AsJob etc.
   It can also create several resources simultaneously.