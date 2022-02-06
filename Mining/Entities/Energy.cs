namespace Mining.Entities; 

public class Energy {
    public double Consumption { get; set; }
    public double EnergyValue { get; set; }

    public Energy() {
    }

    public Energy(double consumption, double energyValue) {
        Consumption = consumption;
        EnergyValue = energyValue;
    }

    public double ValueConsumption() {
        double result = ((Consumption / 1000) * 24) * EnergyValue;
        return result;
    }
}
