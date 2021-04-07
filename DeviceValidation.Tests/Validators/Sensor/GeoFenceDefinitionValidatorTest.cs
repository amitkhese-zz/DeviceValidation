using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation.TestHelper;
using Xunit;

namespace DeviceV2Tests.Validators.Sensor
{
    public class GeoFenceDefinitionValidatorTest : BaseValidatorTest
    {
        private readonly GeoFenceDefinitionValidator validator =
            new GeoFenceDefinitionValidator();

        [Fact]
        public void HappyPath()
        {
            var model = CreateGeoFenceDefinition();
            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void InvalidGeofence_Optional_Days_Optional_Dates()
        {
            var model = CreateGeoFenceDefinition();
            var invalidGeofence = new Geofence()
            {
                Id = "invalidId",
                Name = "Invalid Geofence",
                Options = new GeofenceOptions()
                {
                    Enabled = false,
                    Silent = false
                },
                Points = new List<GeofencePoint>()
                {
                    new GeofencePoint()
                    {
                        Latitude = 89.000001m,
                        Longitude = -179.000001m
                    }
                },
                Radius = 10.0m,
                Type = GeoFenceType.POINT
            };

            model.GeoFen.Add(invalidGeofence);

            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(91.000001, -181.000001)]
        [InlineData(-91.000001, 181.000001)]
        public void InvalidGeofence(decimal latitude, decimal longitude)
        {
            var model = CreateGeoFenceDefinition();
            var invalidGeofence = new Geofence()
            {
                Id = "invalidId",
                Name = "Invalid Geofence",
                Options = new GeofenceOptions()
                {
                    Date = "2021-02-13",
                    Time = "13:15:00",
                    Duration = 1700,
                    Days = new Dictionary<string, bool>()
                    {
                        { "8", false }
                    },
                    Enabled = false,
                    Silent = false
                },
                Points = new List<GeofencePoint>()
                {
                    new GeofencePoint()
                    {
                        Latitude = latitude,
                        Longitude = longitude
                    }
                },
                Radius = 10.0m,
                Type = GeoFenceType.POINT
            };

            model.GeoFen.Add(invalidGeofence);

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor("GeoFen[1].Options.Days");
            result.ShouldHaveValidationErrorFor("GeoFen[1].Points[0].Latitude");
            result.ShouldHaveValidationErrorFor("GeoFen[1].Points[0].Longitude");
        }
    }
}
