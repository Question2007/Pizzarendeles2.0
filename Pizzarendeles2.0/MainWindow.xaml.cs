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

namespace Pizzarendeles2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> pizzak = new List<string> { "Margherita", "Sonkás", "Hawaii", "Gombás", "Négy sajtos", "Magyaros" };
        List<string> meretek = new List<string> { "Kicsi", "Közepes", "Nagy" };

        public MainWindow()
        {
            InitializeComponent();
            lbox_pizzak.ItemsSource = pizzak;
            lbox_meretek.ItemsSource = meretek;
        }

        private void Kivalasztas(object sender, SelectionChangedEventArgs e)
        {
            string kivalasztott = lbox_pizzak.SelectedItem as string;
            if (kivalasztott != null)
            {
                tb_pizza_felirat.Text = "A választott pizza: " + kivalasztott;

            }
            else
            {
                tb_pizza_felirat.Text = "Nincs kiválasztott elem";

            }
        }

        private void Btn_torles_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztott = lbox_pizzak.SelectedItem as string;
            if (kivalasztott != null)
            {
                if (MessageBox.Show($"Biztosan kivánja törölni a {kivalasztott} elemet?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    pizzak.Remove(kivalasztott);
                    lbox_pizzak.ItemsSource = pizzak;
                    lbox_pizzak.Items.Refresh();
                }

            }
            else if (kivalasztott == null || tb_pizza_felirat.Text == null)
            {
                MessageBox.Show("Nincs kiválasztott elem", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MeretKivalasztas(object sender, SelectionChangedEventArgs e)
        {
            string kivalasztott = lbox_meretek.SelectedItem as string;
            if (kivalasztott != null)
            {
                tb_meret_felirat.Text = "A választott méret: " + kivalasztott;
            }
            else
            {
                tb_meret_felirat.Text = "Nincs kiválasztott elem";
            }
        }

        private void btn_megrendeles_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_pizzak.SelectedItem != null && lbox_meretek.SelectedItem != null)
            {
                string pizza = lbox_pizzak.SelectedItem as string;
                string meret = lbox_meretek.SelectedItem as string;
                MessageBox.Show($"A megrendelés sikeres!", "Megrendelés", MessageBoxButton.OK, MessageBoxImage.Information);
                lbox_megrendelesek.Items.Add($"{pizza} - {meret}");
                tb_rendelesek_szama.Text = $"Rendelések száma: {lbox_megrendelesek.Items.Count}";
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy pizzát és egy méretet a megrendeléshez!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_rendeles_torles_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztott = lbox_megrendelesek.SelectedItem as string;
            if (kivalasztott != null)
            {
                if (MessageBox.Show($"Biztosan kivánja törölni a {kivalasztott} elemet?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    lbox_megrendelesek.Items.Remove(kivalasztott);
                    lbox_megrendelesek.Items.Refresh();
                    tb_rendelesek_szama.Text = $"Rendelések száma: {lbox_megrendelesek.Items.Count}";
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_osszes_torles_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Biztosan kivánja törölni az összes elemet?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                lbox_megrendelesek.Items.Clear();
                lbox_megrendelesek.Items.Refresh();
                tb_rendelesek_szama.Text = $"Rendelések száma: {lbox_megrendelesek.Items.Count}";
            }
        }

        private void tb_pizza_kereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_kereses_Click(object sender, RoutedEventArgs e)
        {
            List<string> talalatok = new List<string> { };
            string keresett = tb_pizza_kereses.Text.ToLower();
            if (keresett != "")
            {
                for (int i = 0; i < pizzak.Count; i++)
                {
                    if (pizzak[i].ToLower().Contains(keresett))
                    {
                        talalatok.Add(pizzak[i]);
                    }
                }
                string kimenet = string.Join(", ", talalatok);
                MessageBox.Show($"A keresett pizza megtalálható: {kimenet}", "Keresés", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else if (keresett == null || keresett == "")
            {
                MessageBox.Show("Kérlek adj meg egy keresendő szöveget", "Keresés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}