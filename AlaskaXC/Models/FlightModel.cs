using System;
using System.Collections.Generic;

namespace AlaskaXC.Models
{
    public class FlightModel
    {
        public long OrigZuluOffset { get; set; }
        public long DestZuluOffset { get; set; }
        public long FltId { get; set; }
        public Carrier Carrier { get; set; }
        public string Orig { get; set; }
        public string Dest { get; set; }
        public long CutOffTime { get; set; }
        public long FltDirection { get; set; }
        public DateTimeOffset SchedDepTime { get; set; }
        public DateTimeOffset EstDepTime { get; set; }
        public DateTimeOffset SchedArrTime { get; set; }
        public DateTimeOffset EstArrTime { get; set; }
        public ActualTime ActualTime { get; set; }
        public DestGateUnion DestGate { get; set; }
        public string OrigGate { get; set; }
        public List<CodeShare> CodeShares { get; set; }
        public long TailId { get; set; }
        public string FleetType { get; set; }
        public Status Status { get; set; }
    }

    public partial class CodeShare
    {
        public string FltId { get; set; }
        public string Carrier { get; set; }
    }

    public enum ActualTime { Empty, The0706Pm };

    public enum Carrier { As, Oo, Qx };

    public enum DestGateEnum { A1, C1, C3, C4, C7, E4, E96, Empty, Hg };

    public enum Status { Cancel, Empty, OnTime };

    public partial struct DestGateUnion
    {
        public DestGateEnum? Enum;
        public long? Integer;

        public static implicit operator DestGateUnion(DestGateEnum Enum) => new DestGateUnion { Enum = Enum };
        public static implicit operator DestGateUnion(long Integer) => new DestGateUnion { Integer = Integer };
    }
}