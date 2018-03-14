using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester:Harvesters
{
    public override string Type => "Hammer";

    public HammerHarvester(string id, double oreOutput, double energyReq) :
        base(id, oreOutput *3, energyReq * 2)
    {
        
    }

}