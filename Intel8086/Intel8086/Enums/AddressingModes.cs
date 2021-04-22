using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Intel8086.Enums {
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum AddressingModes {
        [Description("Indeksowy")]
        Index,
        [Description("Bazowy")]
        Base,
        [Description("Indeksowo-bazowy")]
        IndexBase
    }
}