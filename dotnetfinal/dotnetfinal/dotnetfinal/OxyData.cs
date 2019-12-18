using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;

namespace dotnetfinal
{
    public class OxyData
    {
        public PlotModel ScatteredModel { get; set; }


        public OxyData(List<Coordinate> list)
        {
            ScatteredModel = CreateScatteredChart(list);
        }

        private PlotModel CreateScatteredChart(List<Coordinate> list)
        {
            var model = new PlotModel { Title = "ScatterSeries" };
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

            for (int i = 0; i < list.Count - 1; i++)
            {
                scatterSeries.Points.Add(new ScatterPoint(list[i].XValue, list[i].YValue, 3));
            }

            model.Series.Add(scatterSeries);

            return model;
        }
    }
}
