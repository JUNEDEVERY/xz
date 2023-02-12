using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Z.classes;

namespace Z.pages
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();

            lvMaterial.ItemsSource = db.entities.Product.ToList();
            cmbFiltres.Items.Add("Все типы");
            foreach (ProductType productType in db.entities.ProductType.ToList())
            {
                cmbFiltres.Items.Add(productType.Title);
            }
            cmbFiltres.SelectedIndex = 0;
            cmbSorted.SelectedIndex = 0;
            tbCount.Text = db.entities.Product.ToList().Count + " из " + db.entities.Product.ToList().Count;

        }
        private void cmbSorted_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtres();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtres();
        }

        void Filtres()
        {
            List<Product> products = db.entities.Product.ToList();

            ComboBoxItem comboBoxItem = (ComboBoxItem)cmbSorted.SelectedItem;
            switch (comboBoxItem.Content)
            {
                case "По умолчанию":

                    products = products;

                    break;

                case "По возрастанию наименования":

                    products = products.OrderBy(x => x.Title).ToList();
                    break;

                case "По убыванию наименования":
                    products = products.OrderByDescending(x => x.Title).ToList();
                    break;

                case "По возрастанию номера производственного цеха":
                    products = products.OrderBy(x => x.ProductionWorkshopNumber).ToList();
                    break;
                case "По убыванию номера производственного цеха":

                    products = products.OrderByDescending(x => x.ProductionWorkshopNumber).ToList();

                    break;

                case "По возрастанию минимальной стоимости для агента":

                    products = products.OrderBy(x => x.MinCostForAgent).ToList();
                    break;
                case "По убыванию минимальной стоимости для агента":
                    products = products.OrderByDescending(x => x.MinCostForAgent).ToList();
                    break;

            }



            //   if (tbSearch.Text != "")
            //   {
            //       products = products.Where(x => x.Title.ToLower().Contains(tbSearch.Text.ToLower()) || (x.Description.ToLower().Contains(tbSearch.Text.ToLower()))).ToList();
            //   }
            //   if (cmbFiltres.SelectedIndex != 0 )
            //   {
            //       products = products.Where(x => x.Title == cmbFiltres.SelectedValue).ToList();
            //   }
            lvMaterial.ItemsSource = products;
            //   if (products.Count == 0)
            //   {
            //       MessageBox.Show("По вашему запросу ничего не найдено");
            //   }
            //   tbCount.Text = products.Count + "из" + db.entities.Product.ToList().Count;

        }




    }
}
