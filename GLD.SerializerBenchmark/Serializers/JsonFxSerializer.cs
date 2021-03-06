///
/// https://github.com/jsonfx/jsonfx
/// PM> Install-Package JsonFx
/// by Stephen McKamey
/// 

using System.IO;
using JsonFx.Json;

namespace GLD.SerializerBenchmark.Serializers
{
    internal class JsonFxSerializer : SerDeser
    {
        private static readonly JsonWriter _jw = new JsonWriter();
        private static readonly JsonReader _jr = new JsonReader();

        #region ISerDeser Members

        public override string Name
        {
            get { return "JsonFx"; }
        }

        public override string Serialize(object serializable)
        {
            return _jw.Write(serializable);
        }

        public override object Deserialize(string serialized)
        {
            return _jr.Read(serialized, _primaryType);
        }

        public override void Serialize(object serializable, Stream outputStream)
        {
            var sw = new StreamWriter(outputStream);
            _jw.Write(serializable, sw);
            sw.Flush();
        }

        public override object Deserialize(Stream inputStream)
        {
            inputStream.Seek(0, SeekOrigin.Begin);
            return _jr.Read(new StreamReader(inputStream), _primaryType);
        }

        #endregion
    }
}