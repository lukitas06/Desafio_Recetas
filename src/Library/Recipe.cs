//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        double GetProductionCost( )
        {
            double totalCost=0.00;
            foreach(Step step in this.steps){
                totalCost+= (step.Input.UnitCost)+(step.Equipment.HourlyCost*step.Time);
            }
            return totalCost;
        }


        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {   
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time} ");
            }
            Console.WriteLine($"Total: {this.GetProductionCost()}");
        }
//Usando el patron Expert, le di la responsabilidad a esta clase, ya que es la que conoce todo acerca de la receta:
//las lineas, con los productos, costos, equipamentos y tiempo de uso.

        
    }
}