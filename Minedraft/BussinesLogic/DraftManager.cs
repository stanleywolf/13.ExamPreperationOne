﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvesters> harvesters;
    private List<Providers> providers;

    private HarvesterFactory harvesterFactory;
    private ProvidersFactory providersFactory;

    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        harvesters = new List<Harvesters>();
        providers = new List<Providers>();
        harvesterFactory = new HarvesterFactory();
        providersFactory = new ProvidersFactory();
        mode = "Full";
        totalEnergyStored = 0;
        totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = harvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providersFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        var dayEnergyprovided = providers.Sum(p => p.EnergyOutput);
        totalEnergyStored += dayEnergyprovided;
        double dayEnergyRequired, dayMinedOre;
        if (mode == "Full")
        {
            dayEnergyRequired = harvesters.Sum(h => h.EnergyReq);
            dayMinedOre = harvesters.Sum(h => h.OreOutput);
        }
        else if (mode == "Half")
        {
            dayEnergyRequired = harvesters.Sum(h => h.EnergyReq) * 0.6;
            dayMinedOre = harvesters.Sum(h => h.OreOutput) * 0.5;
        }
        else
        {
            dayEnergyRequired = 0;
            dayMinedOre = 0;
        }
        if (totalEnergyStored >= dayEnergyRequired)
        {
            totalMinedOre += dayMinedOre;
            totalEnergyStored -= dayEnergyRequired;
        }
        return "A day has passed." + Environment.NewLine +
               $"Energy Provided: {dayEnergyprovided}" + Environment.NewLine +
               $"Plumbus Ore Mined: {dayMinedOre}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        //string id = arguments[0];
        //var harvesters = this.harvesters.FirstOrDefault(h => h.Id == id);
        //if (harvesters != null)
        //{
        //    return harvesters.ToString();
        //}
        //else
        //{
        //    var provider = this.providers.FirstOrDefault(h => h.Id == id);
        //    if (provider != null)
        //    {
        //        return provider.ToString();
        //    }
        //    else
        //    {
        //    return $"No element found with id - {id}";
        //    }
        //}        
        string id = arguments[0];
        Unit unit = (Unit)harvesters.FirstOrDefault(h => h.Id == id) ?? providers.FirstOrDefault(p => p.Id == id);

        if (unit != null)
            return unit.ToString();
        else
            return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
               $"Total Mined Plumbus Ore: {totalMinedOre}";
    }


}