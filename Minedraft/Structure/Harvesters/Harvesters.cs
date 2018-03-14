using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvesters:Unit
{
    private const double MAX_VALUE = 20000;

    private double oreOutput;
    private double energyReq;

    protected Harvesters(string id,double oreOutput, double energyReq):base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyReq = energyReq;
    }
    
    public double OreOutput
    {
        get { return oreOutput; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }
    public double EnergyReq
    {
        get { return energyReq; }
        private set
        {
            if (value < 0 || value > MAX_VALUE)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyReq");
            }
            energyReq = value;
        }
    }

    public override string ToString()
    {
        return $"{Type} Harvester - {Id}" + Environment.NewLine +
        $"Ore Output: {OreOutput}" + Environment.NewLine + 
        $"Energy Requirement: {EnergyReq}";
    }
}