using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessApp.Model;
using Color = ChessApp.Model.Color;
using Figure = ChessApp.Model.Figure;

namespace ChessApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Dictionary<string, int> map = new() {
        {"a", 0}, {"b", 1},
        {"c", 2}, {"d", 3},
        {"e", 4}, {"f", 5},
        {"g", 6}, {"h", 7}};

        readonly Dictionary<int, string> mapRev = new() {
        {0, "a"}, {1, "b"},
        {2, "c"}, {3, "d"},
        {4, "e"}, {5, "f"},
        {6, "g"}, {7, "h"}};

        private Figure figure = new Queen(Color.White, (0, 0));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fix(object sender, RoutedEventArgs e)
        {
            string pos = position.Text;
            string column = pos[..1].ToLower();
            string row = pos[1..];
            int columnNumber = map.TryGetValue(column, out int value) ? value : -1;
            int rowNumber = Convert.ToInt32(row) - 1;

            if (columnNumber < 0 || columnNumber > 7 || rowNumber < 0 || rowNumber > 7)
            {
                MessageBox.Show("Некорректная позиция!");
                return;
            }

            Color color = rb4.IsChecked == true ? Color.White : (rb5.IsChecked == true ? Color.Black : Color.White);

            figure = rb1.IsChecked == true ? new Queen(color, (rowNumber, columnNumber)) :
                     rb2.IsChecked == true ? new Bishop(color, (rowNumber, columnNumber)) :
                     rb3.IsChecked == true ? new Rook(color, (rowNumber, columnNumber)) :
                     null; // обработать случаи, когда переключатель не установлен
        }
        result.Text = figure.ToString();
            string typeOfFigure = "";
            if (figure is Rook) typeOfFigure = "Ладья";
            if (figure is Queen) typeOfFigure = "Ферзь";
            if (figure is Bishop) typeOfFigure = "Слон";
            string colorOfFigure = "";
            if (figure.Color == Color.White) colorOfFigure = "Белый";
            if (figure.Color == Color.Black) colorOfFigure = "Черный";
            type.Text = colorOfFigure + " " + typeOfFigure;
        }
        private void MakeMove(object sender, RoutedEventArgs e)
        {
            string pos = positionTo.Text;
            string col = pos[..1].ToLower();
            string row = pos[1..];
            int colNumber = map.ContainsKey(col) ? map[col] : -1;
            int rowNumber = Convert.ToInt32(row) - 1;
            if (figure.MakeMove(rowNumber, colNumber))
            {
                result.Text = figure.ToString();
                string typeOfFigure = "";
                if (figure is Rook) typeOfFigure = "Ладья";
                if (figure is Queen) typeOfFigure = "Ферзь";
                if (figure is Bishop) typeOfFigure = "Слон";
                string colorOfFigure = "";
                if (figure.Color == Color.White) colorOfFigure = "Белый";
                if (figure.Color == Color.Black) colorOfFigure = "Черный";
                type.Text = colorOfFigure + " " + typeOfFigure;
            }
            else {
                MessageBox.Show("Ход невозможен");
            }
        }
    }
}