using System;
using System.IO;
using System.Windows.Forms;
using ZedGraph;

namespace BirthStatistics
{
    public partial class MainForm : Form
    {
        private double[] _dSS;

        private double[] _dSP;

        private GraphPane _pane;

        private Statistics _statistics;

        private Graph _graph;
        public MainForm()
        {
            InitializeComponent();
         
            _statistics = new Statistics("WholeYear.csv", "dataSetSizes.json", "dataSetPercentages.json");
            _pane = GraphControl.GraphPane;
           
            if (!(File.Exists(@"..\..\DataSet\dataSetSizes.json") &
                File.Exists(@"..\..\DataSet\dataSetPercentages.json")))
            {
                _statistics.CreatingDataSetsForGraph();
                
            }

            _dSP = Serializer.LoadFromFile("dataSetPercentages.json");
            _dSS = Serializer.LoadFromFile("dataSetSizes.json");
            
            _graph = new Graph(_pane, _dSS, _dSP);
            _graph.DrawGraph();

            GraphControl.Invalidate();
        }       
    }     
}
