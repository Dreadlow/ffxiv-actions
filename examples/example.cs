namespace example
{
    public enum PositionalDirection
    {
        None,
        Flank,
        Rear,
        Front
    }

    public class ActionData
    {
        public ActionData()
        {
            Statuses = new List<StatusData>();
            Potency = new PotencyData();
        }

        public class StatusData
        {
            public StatusData()
            {
                Flags = new Dictionary<string, object>();
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public int Duration { get; set; }
            public int Param { get; set; }

            public Dictionary<string, object> Flags { get; set; }
        }

        public class PotencyData
        {
            public int Base { get; set; }
            public int Combo { get; set; }

            public int Positional { get; set; }
            public int PositionalCombo { get; set; }

            public int Heal { get; set; }
            public int SelfHeal { get; set; }

            public int MPGainPercentage { get; set; }
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public PositionalDirection PositionalDirection { get; set; }

        public PotencyData Potency { get; set; }

        public List<StatusData> Statuses { get; set; }
    }

    class Program
    {
        void Main(string[] args)
        {
            var dir = new DirectoryInfo(args[0]);
            
            var actions = new Dictionary<int, ActionData>();

            foreach (var f in dir.GetFiles("*.json", SearchOption.AllDirectories))
            {
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ActionData>(File.ReadAllText(f.FullName));
                actions[obj.Id] = obj;
            }
            
            // do stuff
        }
    }

}
