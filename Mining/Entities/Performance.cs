namespace Mining.Entities; 

public class Performance {
    public double Earnings { get; set; }
    public double Dolar { get; set; }

    public Performance() {
    }

    public Performance(double earnings, double dolar) {
        Earnings = earnings;
        Dolar = dolar;
    }

    public double Conversion() {
        return Earnings * Dolar;
    }
}
