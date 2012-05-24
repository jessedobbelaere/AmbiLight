using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseThreading {
    
    /// <summary>
    /// The Source Enum
    /// </summary>
    public enum Source {
        Screencap ,
        ScreencapThreaded 
    }

    /// <summary>
    /// The Arduino modes Enum
    /// </summary>
    public enum ArduinoModes {
        Strobe,
        PoliceLight,
        SingelColor, 
        Colorcycle
    }

    /// <summary>
    /// The Region methods
    /// </summary>
    public enum RegioMethodes {
        Manueel,
        Automatisch
    }
}
