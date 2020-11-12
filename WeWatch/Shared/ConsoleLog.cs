using System;

namespace WeWatch
{
    public static class Log
    {
        // Create enumerated data type named LogType.
        /// <summary>
        /// Values are as defined in RFC 5424.
        /// </summary>
        public enum LogType { Emerg, Alert, Crit, Err, Warning, Notice, Info, Debug };

        // backing field for LogLevel property
        private static int? _logLevel = null;
        // Create a public property that will act as an accessor to the above backing field.
        // If _logLevel is null, it has not been set by the property yet.
        /// <summary>
        /// Allows setting of the program's log level once during runtime. If called LogLevel is set to a default of 4.
        /// </summary>
        /// <value>Set LogLevel, equivalent to int value of LogType.</value>
        public static int LogLevel
        {
            get
            {
                if (_logLevel == null)
                    _logLevel = 4;
                return (int)_logLevel;
            }
            set
            {
                if (_logLevel == null)
                {
                    if (value >= 0 && value <= 7)
                        _logLevel = value;
                    else
                        throw new ArgumentOutOfRangeException("Value must be less than or equal to 7, and greater than or equal to 0");
                }
                else
                    throw new InvalidOperationException("LogLevel already set");
            }
        }

        /// <summary>
        /// Write a message to the console at a specified LogType. Respects previously set program wide logLevel.
        /// </summary>
        /// <param name="message">String to write to console.</param>
        /// <param name="logType">Specifies severity of the log</param>
        public static void WriteLine(string message, LogType logType)
        {
            // Check logType against every value in LogType type, 
            // then check if it should print to console based on the set logLevel,
            // and finally print to console if both previous conditions are met.
            switch (logType)
            {
                case LogType.Emerg:
                    if (LogLevel >= 0)
                        Console.WriteLine("Emergency: {0}", message);
                    break;
                case LogType.Alert:
                    if (LogLevel >= 1)
                        Console.WriteLine("Alert: {0}", message);
                    break;
                case LogType.Crit:
                    if (LogLevel >= 2)
                        Console.WriteLine("Critical: {0}", message);
                    break;
                case LogType.Err:
                    if (LogLevel >= 3)
                        Console.WriteLine("Error: {0}", message);
                    break;
                case LogType.Warning:
                    if (LogLevel >= 4)
                        Console.WriteLine("Warning: {0}", message);
                    break;
                case LogType.Notice:
                    if (LogLevel >= 5)
                        Console.WriteLine("Notice: {0}", message);
                    break;
                case LogType.Info:
                    if (LogLevel >= 6)
                        Console.WriteLine("Info: {0}", message);
                    break;
                case LogType.Debug:
                    if (LogLevel >= 7)
                        Console.WriteLine("Debug: {0}", message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("LogType invalid.");
            }
        }
    }
}