﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NFX;
using ProtoBuf;

namespace GLD.SerializerBenchmark.TestData
{
    public class SimleObjectDescription : ITestDataDescription
    {
        public string Name { get { return "Simle Object"; }}
        public string Description { get{ return "Plain object with numbers and IDs, no arrays."; }}
        public Type DataType { get { return typeof (SimleObject); } }
        public List<Type> SecondaryDataTypes { get { return null; } }

        private readonly SimleObject _data = SimleObject.Generate();
        public object Data { get { return _data; }  }
    }
    [ProtoContract]
    [DataContract]
    [Serializable]
    public class SimleObject
    {
        ///// <summary>
        ///// Required by some serilizers (i.e. XML)
        ///// </summary>
        //public SimleObject() { }       

 
        [ProtoMember(1)]
        [DataMember]
        public string Id;

        [ProtoMember(2)]
        [DataMember]
        public string DataSource;

        [ProtoMember(3)]
        [DataMember]
        public DateTime TimeStamp;

        [ProtoMember(4)]
        [DataMember]
        public int Param1;

        [ProtoMember(5)]
        [DataMember]
        public uint Param2;

        [ProtoMember(6)]
        [DataMember]
        public double Measurement;

        [ProtoMember(7)]
        [DataMember]
        public long AssociatedProblemID;

        [ProtoMember(8)]
        [DataMember]
        public long AssociatedLogID;

        [ProtoMember(9)]
        [DataMember]
        public bool WasProcessed;

        public static SimleObject Generate()
        {
            return new SimleObject()
            {
                Id = Guid.NewGuid().ToString(),
                DataSource = Guid.NewGuid().ToString(),
                TimeStamp = DateTime.Now,
                Param1 = ExternalRandomGenerator.Instance.NextRandomInteger,
                Param2 = (uint)ExternalRandomGenerator.Instance.NextRandomInteger,
                Measurement = ExternalRandomGenerator.Instance.NextRandomDouble,
                AssociatedProblemID = 123,
                AssociatedLogID = 89032,
                WasProcessed = true
            };
        }
    }

}