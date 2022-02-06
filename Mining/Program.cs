using System;
using System.Globalization;
using Mining.Entities;

namespace MyNamespace {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("RIG: ON or OFF?");
            Console.Write("Digite qual a porcentagem desejada? ");
            double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Digite o consumo da RIG em watts: ");
            double consumption = double.Parse(Console.ReadLine());
            Console.Write("Digite o valor por watts consumido: R$");
            double valueConsum = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Digite o valor gerado pela RIG por dia em dolar: $");
            double value = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Cotação do Dolar: R$");
            double dolar = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Energy energy = new Energy(consumption, valueConsum);
            Performance performance = new Performance(value, dolar);
            PayBack payBack = new PayBack(energy, performance, percentage);
            
            Console.Write("Digite a quantidade de modelos de GPU's: ");
            int quantity = int.Parse(Console.ReadLine());
            for (int i = 1; i <= quantity; i++) {
                Console.WriteLine($"Equipamento #{i}");
                Console.Write("Modelo da GPU: ");
                string model = Console.ReadLine();
                Console.Write("Valor da GPU: R$");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantidade: ");
                int qtdGpu = int.Parse(Console.ReadLine());

                Equipment equipment = new Equipment(model, price, qtdGpu);
                payBack.AddEquipment(equipment);
            }

            Console.WriteLine(payBack);
        }
    }
} 

