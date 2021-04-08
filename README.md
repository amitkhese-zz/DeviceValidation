We have a C# class library that does validation of incoming telemetry from an Iot device. Right now, we consider location readings with an accuracy over 500 meters to be invalid. We want to be able to configure this accuracy threshold by product. For the TRACKER product, we want the location accuracy threshold for to be 100 meters. For all other products, we want it to remain 500 meters.
- The IotDeviceSchema class has a ProductId field that can be used to determine which product we are processing
- We are using v9 of the FluentValidation library
- There is no need to extract the accuracy thresholds to external configuration. Hard coding is fine.
- Choose one of the following for submission:
    - Submit an e-mail patch
    - Fork the repo to your own Github instance and submit a PR to your own repo. Do not submit a PR to this repo.
