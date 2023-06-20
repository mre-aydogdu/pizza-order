/* 
 * C#
 * Bu program bir pizza sipariş otomasyonunun demosu olacak şekilde hazırlamıştır. 
 * Kullanıcı pizza tipini, büyüklüğünü, extra malzemeleri seçebilir
 * Kullanıcı kendi pizzasını oluşturma seçeneğini de seçebilir, 
 */


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
    public partial class PizzaOrderForm : Form
    {

        // Kaynakları Resource olarak sonradan kullanılmak üzere ekliyoruz
        // Belirli değişkenler üzerinde tutuluyor ve sonrasında Resources klasöründen erişim sağlanıyor
        public Image leftSideJalapeno = Properties.Resource1.LeftSideJalapeno;
        public Image leftSideUnselected = Properties.Resource1.button_left;
        public Image leftSideSelected = Properties.Resource1.button_left_selected;
        public Image leftSideSpinach = Properties.Resource1.LeftSideSpinach;
        public Image RHJalapeno = Properties.Resource1.RHJalapeno;
        public Image RHOnion = Properties.Resource1.RHOnion;
        public Image RHPepper = Properties.Resource1.RHPepper;
        public Image RHMushroom = Properties.Resource1.RHMushroom;
        public Image RHPineapple = Properties.Resource1.RHPineapple;
        public Image WholeUnselected = Properties.Resource1.button_whole;
        public Image leftSideOnion = Properties.Resource1.LeftSideOnion;
        public Image Wholeselected = Properties.Resource1.button_whole_selected;
        public Image RightUnselected = Properties.Resource1.button_right;
        public Image RightSelected = Properties.Resource1.button_right_selected;
        public Image LHPineapple = Properties.Resource1.LHPineapple;
        public Image OnionPizza = Properties.Resource1.OnionPizza;
        public Image SpinachPizza = Properties.Resource1.SpinachPizza1;
        public Image PineapplePizza = Properties.Resource1.PineapplePizza1;
        public Image JalapenoPizza = Properties.Resource1.JalapenoPizza;
        public Image PeppersPizza = Properties.Resource1.GreenPepperPizza;
        public Image MushroomPizza = Properties.Resource1.MushroomPizza;
        public Image DefaultPizza = Properties.Resource1.DefaultPizza;
        public Image LeftHalfPepper = Properties.Resource1.LeftHalfPepper;

        // Extra malzemelerin ilk fiyatlarını belirledik
        // Bize uygun olan Double tipini seçiyoruz
        public double Personal = 5.99;
        public double Small = 7.99;
        public double Medium = 9.99;
        public double Large = 12.99;
        public double Alfredo = 1;
        public double Tomato = 1;
        public double Cheddar = 1;
        public double Mozarella = 1;
        public double Feta = 1;
        public double Chicken = 1;
        public double Pepperoni = 1;
        public double Sausage = 1;
        public double Onions = 1;
        public double Peppers = 1;
        public double Mushroom = 1;
        public double Jalapeno = 1;
        public double Spinach = 1;
        public double Pineapple = 1;

        // Sipariş Fatura formunu oluşturduk
        public static OrderInvoiceForm order = new OrderInvoiceForm();

        public static double Cost = 0.00; // Vergilendirmeden önceki toplam fiyat
        public static double Subtotal = 0.00; // Sonrasındaki Fiyat
        public static double TaxRate = 0.18; // Vergi yüzdesi

        public PizzaOrderForm()
        {
            InitializeComponent();
        }

        // Clear tuşuna basıldığında formu temizlemesi için bir method oluşturduyoruz 
        private void ClearButton_Click(object sender, EventArgs e)
        {

            PizzaOrderForm NewForm = new PizzaOrderForm();
            NewForm.Show();  // Show the new form
            this.Dispose(false); // Get rid of the old form

        }

        // Bu method Siparişi onayla butonuna basıldıktan sonraki bütün işlemleri halletmek için yapılıyor'
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Personele özel pizza seçilmiş ise
            if (PersonalRadioButton.Checked == true)
            {
                
                ListViewItem item = new ListViewItem("Personel Pizzası Boyutu");
                item.SubItems.Add("5");
                order.SubTotalListView.Items.Add(item);
            }
            // Küçük pizza boyutu seçilmiş ise
            else if (SmallRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Küçük Pizza Boyutu");
                item.SubItems.Add("7");
                order.SubTotalListView.Items.Add(item);
            }

            // Orta boy Pizza seçilmiş ise
            else if (MediumRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Orta Pizza Boyutu");
                item.SubItems.Add("9");
                order.SubTotalListView.Items.Add(item);
            }

            // Büyük Boy pizza seçilmiş ise
            else if (LargeRadioButton.Checked == true)
            {
                ListViewItem item = new ListViewItem("Büyük Pizza Boyutu");
                item.SubItems.Add("12");
                order.SubTotalListView.Items.Add(item);
            }

            // Extra Cheddar seçili ise
            if (CheddarCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Cheddar Peynirli");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Extra alfredo malzemesi var ise 
            if (AlfredoCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Alfredo Soslu");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Eğer Domates eklenmişse 
            if (TomatoCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Domates Soslu");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Eğer extra mozarella seçilmiş ise 
            if (MozarellaCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Mozarella Peynirli");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Eğer extra beyaz peynir seçilmiş ise 
            if (FetaCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Beyaz Peynirli");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Eğer extra tavuk seçilmiş ise
            if (ChickenCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Tavuklu");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Eğer pepperoni extra eklenmiş ise 
            if (PepperoniCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Pepperonili");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            // Eğer sosis eklenmiş ise 
            if (SausageCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Sosisli");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            if (OnionCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Soğanlı");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            if (MushroomCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Mantarlı");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            if (SpinachCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Ispannaklı");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            if (PineapplecheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Ananaslı");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            if (GreenPeppersCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Yeşil Biberli");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }

            if (JalapenoCheckBox.Checked == true)
            {
                ListViewItem item = new ListViewItem("Jalapenolu");
                item.SubItems.Add("1");
                order.SubTotalListView.Items.Add(item);
            }


            order.Show(); // Sipraiş özetini gösteriyoruz
            this.Hide(); // Açık olan formu gizliyoruz


        }



        private void AlfredoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (AlfredoCheckBox.Checked == true)
            {
                TomatoCheckBox.Enabled = false;
            }

            else if (AlfredoCheckBox.Checked == false)
            {
                TomatoCheckBox.Enabled = true;
            }

        }


        private void TomatoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (TomatoCheckBox.Checked == true)
            {
                AlfredoCheckBox.Enabled = false;

            }
            else if (TomatoCheckBox.Checked == false)
            {
                AlfredoCheckBox.Enabled = true;

            }
        }

        // Bu metod kullanıcı kendi pizzasını kendisi yapmak isterse çalışır
        // Pizza customize edilebilir

        private void BuildOwnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BuildOwnRadioButton.Checked == true)
            {
                BuildOwnGroupBox.Enabled = true;
            }
            else if (BuildOwnRadioButton.Checked == false)
            {
                BuildOwnGroupBox.Enabled = false;
            }
        }

        //biraz daha görsellik katmak için seçilen çeşitlere göre ekrana resim ekliyoruz

        private void OnionsLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (OnionCheckBox.Checked)
            {

                OnionsLeftPictureBox.Image = leftSideSelected; 
                OnionsWholePictureBox.Image = WholeUnselected; 
                OnionsRightPictureBox.Image = RightUnselected; 
                PizzaPictureBox.Image = leftSideOnion; 

            }
        }

       

        private void OnionsWholePictureBox_Click(object sender, EventArgs e)
        {
            if (OnionCheckBox.Checked)
            {
                OnionsWholePictureBox.Image = Wholeselected; 
                OnionsLeftPictureBox.Image = leftSideUnselected; 
                OnionsRightPictureBox.Image = RightUnselected; 
                PizzaPictureBox.Image = OnionPizza;


            }
        }


        

        private void OnionsRightPictureBox_Click(object sender, EventArgs e)
        {
            if (OnionCheckBox.Checked)
            {

                OnionsRightPictureBox.Image = RightSelected; 
                OnionsLeftPictureBox.Image = leftSideUnselected; 
                OnionsWholePictureBox.Image = WholeUnselected; 
                PizzaPictureBox.Image = RHOnion;
            }
        }

        
        private void PeppersLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (GreenPeppersCheckBox.Checked)
            {
                PeppersLeftPictureBox.Image = leftSideSelected;
                PeppersWholePictureBox.Image = WholeUnselected;
                PeppersRightPictureBox.Image = RightUnselected; 
                PizzaPictureBox.Image = LeftHalfPepper;
            }
        }

        

        private void PeppersWholePictureBox_Click(object sender, EventArgs e)
        {
            if (GreenPeppersCheckBox.Checked)
            {
                PeppersWholePictureBox.Image = Wholeselected;
                PeppersLeftPictureBox.Image = leftSideUnselected; 
                PeppersRightPictureBox.Image = RightUnselected; 
                PizzaPictureBox.Image = PeppersPizza;
            }
        }

       
        private void PeppersRightPictureBox_Click(object sender, EventArgs e)
        {
            if (GreenPeppersCheckBox.Checked)
            {
                PeppersRightPictureBox.Image = RightSelected;
                PeppersLeftPictureBox.Image = leftSideUnselected;
                PeppersWholePictureBox.Image = WholeUnselected; 
                PizzaPictureBox.Image = RHPepper;
            }

        }

       
        private void MushroomLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (MushroomCheckBox.Checked)
            {
                MushroomLeftPictureBox.Image = leftSideSelected;
                MushroomWholePictureBox.Image = WholeUnselected; 
                MushroomRightPictureBox.Image = RightUnselected; 
            }

        }

        
        private void JalapenoLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (JalapenoCheckBox.Checked)
            {
                JalapenoLeftPictureBox.Image = leftSideSelected;
                JalapenoWholePictureBox.Image = WholeUnselected; // İşaretlemeyi iptal et
                JalapenoRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = leftSideJalapeno;
            }
        }

    

        private void SpinachLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (SpinachCheckBox.Checked)
            {
                SpinachLeftPictureBox.Image = leftSideSelected;
                SpinachWholePictureBox.Image = WholeUnselected; // İşaretlemeyi iptal et
                SpinachRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = leftSideSpinach;

            }
        }

        
        private void PineappleLeftPictureBox_Click(object sender, EventArgs e)
        {
            if (PineapplecheckBox.Checked)
            {
                PineappleLeftPictureBox.Image = leftSideSelected;
                PineappleWholePictureBox.Image = WholeUnselected; // İşaretlemeyi iptal et
                PineappleRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = LHPineapple;
            }
        }

        

        private void MushroomWholePictureBox_Click(object sender, EventArgs e)
        {
            if (MushroomCheckBox.Checked)
            {
                MushroomWholePictureBox.Image = Wholeselected;
                MushroomLeftPictureBox.Image = leftSideUnselected; // İşaretlemeyi iptal et
                MushroomRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = MushroomPizza;
            }
        }

        

        private void JalapenoWholePictureBox_Click(object sender, EventArgs e)
        {
            if (JalapenoCheckBox.Checked)
            {
                JalapenoWholePictureBox.Image = Wholeselected;
                JalapenoLeftPictureBox.Image = leftSideUnselected; // İşaretlemeyi iptal et
                JalapenoRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = JalapenoPizza;
            }
        }

        

        private void SpinachWholePictureBox_Click(object sender, EventArgs e)
        {
            if (SpinachCheckBox.Checked)
            {
                SpinachWholePictureBox.Image = Wholeselected;
                SpinachLeftPictureBox.Image = leftSideUnselected; // İşaretlemeyi iptal et
                SpinachRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = SpinachPizza;
            }
        }


        private void PineappleWholePictureBox_Click(object sender, EventArgs e)
        {
            if (PineapplecheckBox.Checked)
            {
                PineappleWholePictureBox.Image = Wholeselected;
                PineappleLeftPictureBox.Image = leftSideUnselected; // İşaretlemeyi iptal et
                PineappleRightPictureBox.Image = RightUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = PineapplePizza;
            }
        }

        
        private void MushroomRightPictureBox_Click(object sender, EventArgs e)
        {
            if (MushroomCheckBox.Checked)
            {
                MushroomRightPictureBox.Image = RightSelected;
                MushroomLeftPictureBox.Image = leftSideUnselected; // İşaretlemeyi iptal et
                MushroomWholePictureBox.Image = WholeUnselected; // İşaretlemeyi iptal et
                PizzaPictureBox.Image = RHMushroom;
            }
        }

        

        private void JalapenoRightPictureBox_Click(object sender, EventArgs e)
        {
            if (JalapenoCheckBox.Checked)
            {
                JalapenoRightPictureBox.Image = RightSelected;
                JalapenoLeftPictureBox.Image = leftSideUnselected; // İşaretlemeyi iptal et
                JalapenoWholePictureBox.Image = WholeUnselected; 
                PizzaPictureBox.Image = RHJalapeno;
            }
        }

        

        private void SpinachRightPictureBox_Click(object sender, EventArgs e)
        {
            if (SpinachCheckBox.Checked)
            {
                SpinachRightPictureBox.Image = RightSelected;
                SpinachLeftPictureBox.Image = leftSideUnselected; 
                SpinachWholePictureBox.Image = WholeUnselected; 
            }
        }

        

        private void PineappleRightPictureBox_Click(object sender, EventArgs e)
        {
            if (PineapplecheckBox.Checked)
            {
                PineappleRightPictureBox.Image = RightSelected;
                PineappleLeftPictureBox.Image = leftSideUnselected; 
                PineappleWholePictureBox.Image = WholeUnselected; 
                PizzaPictureBox.Image = RHPineapple;
            }
        }

        // Bu default bir pizza resmini genel ekranda görmek için kullanılıyor
        

        private void PizzaOrderForm_Load(object sender, EventArgs e)
        {
            PizzaPictureBox.Image = DefaultPizza;
        }
    
    }
}
