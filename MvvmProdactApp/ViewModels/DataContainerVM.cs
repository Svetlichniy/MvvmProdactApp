using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MvvmProdactApp.Models;
using MvvmProdactApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MvvmProdactApp.ViewModels
{
    public class DataContainerVM : NotifyInterface
    {
        private DataContainer selectedContainer;
        private SeriesCollection series;

        public SeriesCollection Series
        {
            get { return series; }
            set
            {
                series = value;
                RaisePropertyChangedEvent("Series");
            }
        }

        public DataContainerVM()
        {
            AppService.DataContainerVM = this;
            var TreeVM = AppService.TreeNavigationVM;
            if (TreeVM != null && TreeVM.SelectedTreeItem != null)
                SelectedContainer = TreeVM.SelectedTreeItem as DataContainer;

        }

        private void BuildChart()
        {
            var Prodacts = SelectedContainer.Prodacts
                        .Where(e => e.Discriminator.Equals("ProdactObject"))
                        .Cast<ProdactObject>().ToList();

            var Assemblies = Prodacts.Where(e => e.Props.Section.Name.Equals("Сборочная единица")).Count();
            var StandartParts = Prodacts.Where(e => e.Props.Section.Name.Equals("Стандартное изделие")).Count();
            var Parts = Prodacts.Where(e => e.Props.Section.Name.Equals("Деталь")).Count();

            Series = new SeriesCollection()
            {
                new PieSeries()
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(Assemblies),
                    },

                    Title = "Сборочные единицы",
                    ToolTip = "Сборочные единицы"
                },

                new PieSeries()
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(StandartParts),
                    },

                    Title = "Стандартные изделия",
                    ToolTip = "Стандартные"
                },

                new PieSeries()
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(Parts),
                    },

                    Title = "Детали",
                    ToolTip = "Детали"
                }
            };
        }

        public DataContainer SelectedContainer
        {
            get { return selectedContainer; }
            set
            {
                selectedContainer = value;
                RaisePropertyChangedEvent("SelectedContainer");
                BuildChart();
            }
        }

    }
}
