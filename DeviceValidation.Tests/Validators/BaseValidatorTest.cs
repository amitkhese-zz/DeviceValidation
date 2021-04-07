using System;
using System.Collections.Generic;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;

namespace DeviceV2Tests.Validators
{
    public abstract class BaseValidatorTest
    {
        protected Device CreateDeviceData()
        {
            var device = new Device()
            {
                ActivityLog = CreateActivityLog(),
                AlarmsDefinition = CreateAlarmsDefinition(),
                Battery = CreateBattery(),
                BatteryStatus = CreateBatteryStatus(),
                BootEvent = CreateBootEvent(),
                CallLog = CreateCallLog(),
                CellReadings = CreateCellReadings(),
                ContactDefinition = CreateContactDefinition(),
                DisplaySettings = CreateDisplaySettings(),
                Emergency911 = CreateEmergency911(),
                FirmwareInformation = CreateFirmwareInformation(),
                GeoFenceDefinition = CreateGeoFenceDefinition(),
                GeoFenceEvent = CreateGeoFenceEvent(),
                HardwareEnabled = CreateHardwareEnabled(),
                HardwareInformation = CreateHardwareInformation(),
                LightEvent = CreateLightEvent(),
                Location = CreateLocation(),
                LocationSettings = CreateLocationSettings(),
                PresetMessages = CreatePresentMessages(),
                ProximityEvent = CreateProximityEvent(),
                RewardDefinition = CreateRewardDefinition(),
                SmsLog = CreateSmsLog(),
                SosEvent = CreateSosEvent(),
                SoundSettings = CreateSoundSettings(),
                TaskCompletionEvent = CreateTaskCompletionEvent(),
                TasksDefinition = CreateTaskDefinition(),
                Temperature = CreateTemperature(),
                TemperatureSettings = CreateTemperatureSettings(),
                WifiReadings = CreateWiFiReadings(),
                LocationOverrideByWifi = CreateLocationOverrideByWifi()
            };

            return device;
        }

        protected ActivityLog CreateActivityLog()
        {
            return new ActivityLog()
            {
                Metadata = CreateMetaData(),
                Results = new List<Results>()
                    {
                        new Results()
                        {
                            Count = 12,
                            EndTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                            StartTime = DateTimeOffset.Now.AddSeconds(-12500).ToUnixTimeMilliseconds()
                        }
                    }
            };
        }

        protected AlarmsDefinition CreateAlarmsDefinition()
        {
            return new AlarmsDefinition()
            {
                Metadata = CreateMetaData(),
                Alarm = new List<Alarm>()
                    {
                        new Alarm()
                        {
                            Id = "Uniquely identifier",
                            Title = "Title displayed for the Alarm",
                            Days = new Dictionary<string, bool>()
                            {
                                { "1", true },
                                { "2", true },
                                { "3", true },
                                { "4", true },
                                { "5", true },
                                { "6", false },
                                { "7", false }
                            },
                            School = false,
                            Snooze = false,
                            Date = "2021-02-13",
                            Time = "13:15:00",
                            Duration = 1700
                        }
                    }
            };
        }

        protected Battery CreateBattery()
        {
            return new Battery()
            {
                Metadata = CreateMetaData(),
                BatteryLevel = 75
            };
        }

        protected BatteryStatus CreateBatteryStatus()
        {
            return new BatteryStatus()
            {
                Metadata = CreateMetaData(),
                Status = BatteryStatusEnum.CHARGING
            };
        }

        protected BootEvent CreateBootEvent()
        {
            return new BootEvent()
            {
                Metadata = CreateMetaData(),
                BootType = BootType.OFF
            };
        }

        protected CallLog CreateCallLog()
        {
            return new CallLog()
            {
                Metadata = CreateMetaData(),
                Log = new List<CallLogItem>()
                    {
                        new CallLogItem()
                        {
                            Timestamp = DateTime.Now.AddDays(-1).Millisecond,
                            ContactId = "Mom",
                            Msisdn = "2061231234",
                            Duration = 24,
                            Type = 5 // Missed Call from Parents
                        }
                    }
            };
        }

        protected CellTowerReadings CreateCellReadings()
        {
            return new CellTowerReadings()
            {
                Metadata = CreateMetaData(),
                Network = "CDMA",
                Scan = new List<CellTowerScan>()
                    {
                        new CellTowerScan()
                        {
                            CellTowerId = "someCellTowerID",
                            LocationAreaCode = "206",
                            MobileCountryCode = "222",
                            MobileNetworkCode = "444",
                            SignalStrength = -52
                        }
                    }
            };
        }

        protected ContactDefinition CreateContactDefinition()
        {
            return new ContactDefinition()
            {
                Metadata = CreateMetaData(),
                Id = "ContactUUID",
                Contacts = new List<Contact>()
                    {
                        new Contact()
                        {
                            Id = "ContactID",
                            Type = ContactType.ADMIN,
                            Emergency = false,
                            Msisdn = "1234561234",
                            DisplayName = "Itsme",
                            IconUrl = "https://www.somevalidurl.com/icon1234"
                        }
                    }
            };
        }

        protected DisplaySettings CreateDisplaySettings()
        {
            return new DisplaySettings()
            {
                Metadata = CreateMetaData(),
                ThemeId = "ThemeId"
            };
        }

        protected Emergency911 CreateEmergency911()
        {
            return new Emergency911()
            {
                Metadata = CreateMetaData()
            };
        }

        protected FirmwareInformation CreateFirmwareInformation()
        {
            return new FirmwareInformation()
            {
                Metadata = CreateMetaData(),
                FirmwareVersion = "1.0.1",
                FirmwareFailureCode = null,
                FirmwareInstallationCode = FirmwareInstallationCode.NONE,
                FirmwareAppliesTo = "1.0.2",
                FirmwareTarget = "1.0.3",
                FirmwareState = FirmwareState.IN_PROGRESS,
                FirmwareUrl = "https://www.somevalidurl.com/firmware-version"
            };
        }

        protected GeoFenceDefinition CreateGeoFenceDefinition()
        {
            return new GeoFenceDefinition()
            {
                Metadata = CreateMetaData(),
                GeoFen = new List<Geofence>
                {
                    new Geofence()
                    {
                        Id = "Some Id",
                        Name = "Some Name",
                        Options = new GeofenceOptions()
                        {
                            Days = new Dictionary<string, bool>()
                            {
                                { "1", true },
                                { "2", true },
                                { "3", true },
                                { "4", true },
                                { "5", true },
                                { "6", false },
                                { "7", false }
                            },
                            Date = "2021-02-13",
                            Time = "13:15:00",
                            Duration = 1700,
                            Silent = false,
                            Enabled = true
                        },
                        Points = new List<GeofencePoint>()
                        {
                            new GeofencePoint()
                            {
                                Latitude = 47.474190m,
                                Longitude = -122.206650m
                            }
                        },
                        Type = GeoFenceType.POINT,
                        Radius = 10.0m
                    }
                },
            };
        }

        protected GeoFenceEvent CreateGeoFenceEvent()
        {
            return new GeoFenceEvent()
            {
                Metadata = CreateMetaData(),
                GeofenceID = "GeofenceEventID",
                Status = GeoFenceEventStatus.ENTER
            };
        }

        protected HardwareEnabled CreateHardwareEnabled()
        {
            return new HardwareEnabled()
            {
                Metadata = CreateMetaData(),
                AirplaneMode = false,
                Camera = false,
                CameraOrientation = "90",
                LightSensor = false,
                SilentMode = false,
                TemperatureSensor = false
            };
        }

        protected HardwareInformation CreateHardwareInformation()
        {
            return new HardwareInformation()
            {
                Metadata = CreateMetaData(),
                Simulated = false,
                HardwareVersion = "v1-2020-01-01",
                Imei = "123456789012345",
                Manufacturer = "QTC",
                Model = "QTC123"
            };
        }

        protected LightEvent CreateLightEvent()
        {
            return new LightEvent()
            {
                Metadata = CreateMetaData(),
                LightChange = LightChangeTypes.LTD
            };
        }

        protected LocationOverrideByWifi CreateLocationOverrideByWifi()
        {
            return new LocationOverrideByWifi()
            {
                Metadata = CreateMetaData(),
                Id = "LocationID",
                Accuracy = 10.5m,
                DeviceId = "validDeviceID",
                Latitude = 23.000001m,
                Longitude = -23.000001m
            };
        }

        protected Location CreateLocation()
        {
            return new Location()
            {
                Metadata = CreateMetaData(),
                Id = "LocationID",
                Accuracy = 10.5m,
                Altitude = 10.5m,
                DeviceId = "validDeviceID",
                Speed = 5,
                Latitude = 23.000001m,
                Longitude = -23.000001m
            };
        }

        protected LocationSettings CreateLocationSettings()
        {
            return new LocationSettings()
            {
                Metadata = CreateMetaData(),
                State = LocationSettingsState.NORMAL
            };
        }

        protected PresetMessages CreatePresentMessages()
        {
            return new PresetMessages()
            {
                Metadata = CreateMetaData(),
                PresetMsgs = new List<PresetMsgData>()
                {
                    new PresetMsgData()
                    {
                        Id = "messageID",
                        Text = "Some awesome message"
                    }
                }
            };
        }

        protected ProximityEvent CreateProximityEvent()
        {
            return new ProximityEvent()
            {
                Metadata = CreateMetaData(),
                CloseToObject = false
            };
        }

        protected RewardDefinition CreateRewardDefinition()
        {
            return new RewardDefinition()
            {
                Metadata = CreateMetaData(),
                Rewards = new List<Reward>()
                {
                    new Reward()
                    {
                        RewardId = "SomeAwesomeRewardID",
                        RewardMessage = "YAY!!! You got rewarded by MOM!",
                        RewardType = RewardType.STAR,
                        RewardValue = 100,
                        RewardUrl = "https://findrewardsomeurl.com/rewards/rewardID"
                    }
                }
            };
        }

        protected SmsLog CreateSmsLog()
        {
            return new SmsLog()
            {
                Metadata = CreateMetaData(),
                Log = new List<SmsLogItem>()
                {
                    new SmsLogItem()
                    {
                        From = "2224445555",
                        To = new List<string>()
                        {
                            "4974339296",
                            "59145678464",
                            "13332224455"
                        },
                        Direction = 0, // incoming
                        Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                        Type = 2 // Regular Message
                    }
                }
            };
        }

        protected SosEvent CreateSosEvent()
        {
            return new SosEvent()
            {
                Metadata = CreateMetaData()
            };
        }

        protected SoundSettings CreateSoundSettings()
        {
            return new SoundSettings()
            {
                Metadata = CreateMetaData(),
                CallRingTone = "JingleBell",
                NotificationTone = "Drum",
                RingMode = 2,
                Sound = false,
                Volume = 0
            };
        }

        protected TaskCompletionEvent CreateTaskCompletionEvent()
        {
            return new TaskCompletionEvent()
            {
                Metadata = CreateMetaData(),
                TaskCompletionStatus = TaskCompletionStatus.DOLATER,
                TaskId = "ValidTaskID"
            };
        }

        protected TasksDefinition CreateTaskDefinition()
        {
            return new TasksDefinition()
            {
                Metadata = CreateMetaData(),
                Task = new List<DeviceTask>()
                {
                    new DeviceTask()
                    {
                        Days = new Dictionary<string, bool>()
                            {
                                { "1", true },
                                { "2", true },
                                { "3", true },
                                { "4", true },
                                { "5", true },
                                { "6", false },
                                { "7", false }
                            },
                        Id = "SomeDeviceTaskID",
                        Message = "This is awesome device task",
                        Reminder = true,
                        RewardId = "AwesomeRewardID",
                        Silent = false,
                        Title = "Make Loud Device Task",
                        Date = "2021-02-13",
                        Time = "13:15:00",
                        Duration = 1700
                    }
                }
            };
        }

        protected Temperature CreateTemperature()
        {
            return new Temperature()
            {
                Metadata = CreateMetaData(),
                Temp = 20
            };
        }

        protected TemperatureSettings CreateTemperatureSettings()
        {
            return new TemperatureSettings()
            {
                Metadata = CreateMetaData(),
                LowerBoundThresholdTemperature = 0,
                UpperBoundThresholdTemperature = 100,
                MinimumOperatingTemperature = 10,
                MaximumOperatingTemperature = 50
            };
        }

        protected WiFiReadings CreateWiFiReadings()
        {
            return new WiFiReadings()
            {
                Metadata = CreateMetaData(),
                Scan = new List<WiFiScan>()
                {
                    new WiFiScan()
                    {
                        SignalStrength = 10,
                        Channel = 80,
                        Bssid = "FF:FF:FF:FF:FF:FF"
                    }
                }
            };
        }

        protected Metadata CreateMetaData()
        {
            return new Metadata()
            {
                Source = "Some Source",
                LastUpdated = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Version = 1
            };
        }
    }
}
