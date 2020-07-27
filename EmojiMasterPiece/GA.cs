using EmojiMasterPiece;
using GATesting.GA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GA
{
    public class GA<T> where T : IFitness
    {
        int PopulationSize { get; }
        readonly Func<T,T,T> mateFunction;
        readonly Func<T> creatorFunction;
        List<T> population;
        public float top, reproduction;
        public GA(int populationSize, Func<T,T,T> mateFunction, Func<T> creatorFunction,
            float reproduction,
            float top)
        {
            this.top = top;
            this.reproduction = reproduction;
            this.PopulationSize = populationSize;
            this.creatorFunction = creatorFunction;
            this.mateFunction = mateFunction;
            ResetPopulation();
        }
        public void ResetPopulation()
        {
            population = ParallelEnumerable.Range(0, PopulationSize).Select(x => creatorFunction()).ToList();
        }

        public void Eval()
        {
            population.Sort((a, b) => {
                if (a.Measure() > b.Measure())
                    return -1;
                else if (a.Measure() == b.Measure())
                    return 0;
                else
                    return 1;
            });
            List<T> newPopulation = population.GetRange(0,Math.Max(1,(int)(PopulationSize*top)));
            newPopulation.AddRange(ParallelEnumerable.Range(0, PopulationSize- Math.Max(1, (int)(PopulationSize * top))).Select(i =>
            {
                if (StaticRandom.Rand(10)<=2)
                    return creatorFunction();
                return mateFunction(population[i], population[GlobalImageData.rand.Next(0, Math.Max(1,(int)(PopulationSize*reproduction)))]);
            }
            ));
            population.Clear();
            population = newPopulation;
        }
        public T GetBestContender() => population.First();
    }
}
