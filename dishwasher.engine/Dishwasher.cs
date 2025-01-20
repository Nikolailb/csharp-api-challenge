namespace dishwasher.engine
{
    public class Dishwasher
    {
        public static List<WashingProgram> Programs { get; } = [
            new WashingProgram {Name = "Intensive 70", WaterConsumption = 13.5, ElectricConsumption = 1.35, Runtime = 150 },
            new WashingProgram {Name = "Eco 50", WaterConsumption = 9.0, ElectricConsumption = 0.65, Runtime = 60 },
            new WashingProgram {Name = "Half Load", WaterConsumption = 10.5, ElectricConsumption = 1.1, Runtime = 40 },
            new WashingProgram {Name = "Clean Cycle", WaterConsumption = 14.0, ElectricConsumption = 1.45, Runtime = 55 },
        ];
    }
}

