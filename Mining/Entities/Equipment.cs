namespace Mining.Entities; 

public class Equipment {
    public string Name { get; set; }
    public double Value { get; set; }
    public int Quantity { get; set; }

    public Equipment() {
    }

    public Equipment(string name, double value, int quantity) {
        Name = name;
        Value = value;
        Quantity = quantity;
    }

    public double SubTotal() {
        return Value * Quantity;
    }
}
