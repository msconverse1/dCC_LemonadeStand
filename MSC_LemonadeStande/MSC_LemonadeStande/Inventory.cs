﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC_LemonadeStande
{
    class Inventory
    {
        int ice1;
        int sugar1;
        int lemons1;
        int cups;
        public Ice Ice;
        public Sugar Sugar;
        public Lemons Lemons;
        private double startingMoney;
        private double remainingMoney;
        private double collectedMoney;

        public double CollectedMoney { get => collectedMoney; set => collectedMoney = value; }
        public double RemainingMoney { get => remainingMoney; set => remainingMoney = value; }
        public double StartingMoney { get => startingMoney; set => startingMoney = value; }
        public int Ice1 { get => ice1; set => ice1 = value; }
        public int Sugar1 { get => sugar1; set => sugar1 = value; }
        public int Lemons1 { get => lemons1; set => lemons1 = value; }
        public int Cups { get => cups; set => cups = value; }

        public Inventory()
        {
            StartingMoney = 20.00;
            RemainingMoney = StartingMoney;
            Ice = new Ice();
            Sugar = new Sugar();
            Lemons = new Lemons();

        }
        public void CalculateSpentMoney(double spent)
        {
            RemainingMoney -= spent;
        }  
        public void AddIce(int ice)
        {
            Ice1 = ice;
        }
       // public void Add
    }
}
