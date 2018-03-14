using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvesters
{
    private int sonicFactor;
    public override string Type => "Sonic";

    public SonicHarvester(string id, double oreOutput, double energyReq, int sonicFactor) :
        base(id, oreOutput, energyReq / sonicFactor)
    {
             
    }
}