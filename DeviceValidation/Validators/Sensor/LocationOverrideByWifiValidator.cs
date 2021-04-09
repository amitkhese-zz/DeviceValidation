﻿using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.CustomValidationRules;
using FluentValidation;

namespace DeviceV2.Validators.Sensor
{
    public class LocationOverrideByWifiValidator : AbstractValidator<LocationOverrideByWifi>
    {
        public LocationOverrideByWifiValidator(string productId)
        {
            RuleFor(x => x.Metadata).SetValidator(new MetaDataValidator());
            RuleFor(x => x.Accuracy)
                .TransformToNotNullableDecimal()
                .ValidateRadius(productId);
            RuleFor(x => x.Latitude)
                .TransformToNotNullableDecimal()
                .ValidateLatitude();
            RuleFor(x => x.Longitude)
                .TransformToNotNullableDecimal()
                .ValidateLongitude();
        }
    }
}
