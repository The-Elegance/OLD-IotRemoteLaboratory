namespace VirtualTestStand
{
    public static class Topics
    {
        // teriminal data from stand (all output)
        public const string TerminalDataFrom = "/lab/stand/0/serial/in";
        // terminal data from user (commands)
        public const string TerminalDataTo = "/lab/stand/0/serial/out";
        // button with led state (0/1) | Port - id of button
        public const string LedButtonState = "/lab/stand/0/gpio/led/<PORT>";
        // button without led state (0/1) | Port - id of button
        public const string ButtonNoLedState = "/lab/stand/0/gpio/button/<PORT>";
        // code complied output
        public const string DebugCodeOutput = "/lab/stand/0/debug/upload";
        // led on/off -> (0/1)
        public const string LedState = "/lab/stand/0/led";
        // webcamera on/off -> (0/1)
        public const string Webcamera = "/lab/stand/0/webcamera";
    }
}
