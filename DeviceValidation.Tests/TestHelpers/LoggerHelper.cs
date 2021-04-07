using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace DeviceV2Tests.TestHelpers
{
    public static class LoggerHelper
    {
        public static void VerifyExceptionLogged<T>(this Mock<ILogger> loggerMock, string message, string exceptionMessage)
            where T : Exception
        {
            loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(message)),
                    It.Is<T>((v, t) => (v as T).Message.Contains(exceptionMessage)),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once());
        }

        public static void VerifyMessageLogged(this Mock<ILogger> loggerMock, LogLevel logLevel, string message)
        {
            loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == logLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(message)),
                    null,
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once());
        }
    }
}
