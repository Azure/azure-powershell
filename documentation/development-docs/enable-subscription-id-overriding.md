# How to: Enable Subscription ID Overriding in Your Module

## Background

## Steps

1. {add attribute}
    ```
    code sample
    ```
1. if any cmdlet implememts IDynamicParameter already, make sure
    1. `GetDynamicParameters()` is decorates with [`new` keyword](link placeholder)
    1. `base.GetDynamicParameters()` is called and the results are combined
        ```
        code sample
        ```

## Troubleshooting

### Static analysis fails
