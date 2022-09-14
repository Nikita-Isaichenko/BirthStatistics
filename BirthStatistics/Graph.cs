using System.Windows.Forms;
using System.Drawing;
using ZedGraph;

namespace BirthStatistics
{
    class  Graph
    {
        private GraphPane _pane;

        private double[] _dataSetSizes;

        private double[] _dataSetPercentages;

        public void DrawGraph()
        {           
            _pane.Title.Text = "График частоты рождения женщин относительно мужчин";
            _pane.YAxis.Title.Text = "Процент рожденных женщин";
            _pane.XAxis.Title.Text = "Кол-во людей в выборке";
            _pane.XAxis.Type = AxisType.Log;
            _pane.XAxis.Scale.Mag = 0;
            _pane.YAxis.Scale.Mag = 0;
            _pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list = new PointPairList();
            PointPairList vlist = new PointPairList();
                
            for (int i = 0; i < _dataSetSizes.Length; i++)
            {
                // добавим в список точку
                list.Add(_dataSetSizes[i], _dataSetPercentages[i]);
                vlist.Add(_dataSetSizes[i], 48.9);
            }

            LineItem myCurve = _pane.AddCurve("Sinc", list, Color.Blue, SymbolType.None);
            LineItem Curve = _pane.AddCurve("Sinc", vlist, Color.Red, SymbolType.None);

            _pane.AxisChange();
        }

        public Graph(GraphPane pane, double[] dataSetSizes, double[] dataSetPercentages)
        {
            _pane = pane;
            _dataSetSizes = dataSetSizes;
            _dataSetPercentages = dataSetPercentages;
        }
    }
}
