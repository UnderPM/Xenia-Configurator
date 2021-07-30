namespace Xenia_Configurator
{
    internal class Section
    {
        private string name;
        private string[][] values;

        public string GetName()
        {
            return name;
        }

        public string GetValue(string key)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i][0] == key)
                {
                    return values[i][1];
                }
            }
            throw new KeyNotFoundException($"Key {key} not found on Section {name}!");
        }

        public string[][] GetValues()
        {
            return values;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetValue(string key, string value)
        {
            bool error = true;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i][0] == key)
                {
                    values[i][1] = value;
                    error = false;
                }
            }
            if (error)
            {
                throw new KeyNotFoundException($"Key {key} not found on Section {name}!");
            }
        }

        public void SetValues(string[][] values)
        {
            this.values = values;
        }
    }

    [System.Serializable]
    public class KeyNotFoundException : System.Exception
    {
        public KeyNotFoundException() : base() { }
        public KeyNotFoundException(string message) : base(message) { }
        public KeyNotFoundException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected KeyNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}