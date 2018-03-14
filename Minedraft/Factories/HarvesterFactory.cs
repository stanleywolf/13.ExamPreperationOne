using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
    public Harvesters CreateHarvester(List<string> args)
    {
        var type = args[0];
        var id = args[1];
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput,energyReq, int.Parse(args[4]));
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyReq);
                default:
                throw new ArgumentException();
        }
        
    }

    
}