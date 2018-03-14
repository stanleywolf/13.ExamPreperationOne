using System;
using System.Collections.Generic;
using System.Text;

public abstract class Providers : Unit
{
    private const double MAX_VALUE = 10000;

    private double energyOutput;

    protected Providers(string id, double energyOutput) :
        base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            if (value < 0 || value > MAX_VALUE)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine +
               $"Energy Output: {EnergyOutput}";
    }
}