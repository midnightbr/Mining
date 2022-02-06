using System.Globalization;
using System.Text;
using Mining.Entities.Enums;

namespace Mining.Entities; 

public class PayBack {
    public Energy Energy { get; set; }
    public Performance Performance { get; set; }
    public double Percentage { get; set; }
    public List<Equipment> Equipments { get; set; } = new List<Equipment>();

    public PayBack() {
    }

    public PayBack(Energy energy, Performance performance, double percentage) {
        Energy = energy;
        Performance = performance;
        Percentage = percentage;
    }

    public void AddEquipment(Equipment equipment) {
        Equipments.Add(equipment);
    }

    public void RemoveEquipment(Equipment equipment) {
        Equipments.Remove(equipment);
    }

    public double TotalInvested() {
        double total = 0.0;
        foreach (Equipment equipment in Equipments) {
            total += equipment.SubTotal();
        }

        return total;
    }

    public double Profit(int num) {
        double income = Performance.Conversion();
        double cost = Energy.ValueConsumption();
        double profit = (income - cost) * 30;

        double result = 0.0;

        switch (num) {
            case 1:
                result = profit;
                break;
            case 2:
                double investment = TotalInvested();
                double percentage = (profit * 100) / investment;
                result = percentage;
                    break;
            default:
                Console.Write("Opção Invalida");
                break;
        }

        return result;
    }

    public Status OnOrOff() {
        double energy = Energy.ValueConsumption() * 30;
        double performance = Performance.Conversion() * 30;
        double investment = TotalInvested() * (Percentage/100);

        if (performance - energy > investment) {
            return Status.On;
        }
        else {
            return Status.Off;
        }
    }

    public override string ToString() {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendLine("RESULTADO");
        foreach (Equipment equipment in Equipments) {
            builder.AppendLine($"Model: {equipment.Name}");
            builder.AppendLine($"Preço: R${equipment.Value}");
            builder.AppendLine($"Quantidade: {equipment.Quantity}");
        }
        builder.AppendLine();
        builder.AppendLine($"Total Investido: R${TotalInvested()}");
        builder.AppendLine($"Custo: " +
                           $"R${Energy.ValueConsumption().ToString("F2", CultureInfo.InvariantCulture)}");
        builder.AppendLine($"Rendimento: " +
                           $"R${Performance.Conversion().ToString("F2", CultureInfo.InvariantCulture)}");
        builder.AppendLine($"Lucro: " +
                           $"R${Profit(1).ToString("F2", CultureInfo.InvariantCulture)}");
        builder.AppendLine($"Porcetagem:" +
                           $"{Profit(2).ToString("F3", CultureInfo.InvariantCulture)}%");
        builder.AppendLine($"Vale apena: {OnOrOff()}");
        return builder.ToString();
    }
}
