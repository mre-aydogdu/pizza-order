using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Order
{
    public partial class OrderInvoiceForm : Form
    {
        public OrderInvoiceForm()
        {
            InitializeComponent();
        }


        // Bu fonksiyon kullanıcı çıkış tuşuna bastığında çalışır.
        // Uygulamayı düzgün bir şekilde kapatmak için.

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Bu metod kullanıcı siparişini ekranda görüp onayladıktan sonra çalışıyor
        // Pizzanın son fiyatı hesaplanıp burda görüntüleniyor

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            double tax = 0.18; // %18 vergilendirme ekliyouz
            double taxAmount = 0.00; 
            double SubTotal = 0.00; 
            double total = 0.00; 
      
            // bu döngü toplam ücreti vermesi için listedeki bütün ürünleri topluyor 
            
            foreach (ListViewItem item in SubTotalListView.Items)
            {
                total += Convert.ToDouble(item.SubItems[1].Text);
            }

            taxAmount = tax * total; 
            SubTotal = total + taxAmount; 

            PizzaPrice.Text = "₺" + total.ToString("0.00"); 
            taxPriceLabel.Text = "₺" + taxAmount.ToString("0.00"); 
            TotalPrice.Text = "₺" + SubTotal.ToString("0.00"); 

            // siparişin oluştuğuna dair bildirim ekranı

            MessageBox.Show("Siparisiniz Alinmistir, İyi günler Dileriz",
                "Dodinos Pizza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                  

        }
    }
}
