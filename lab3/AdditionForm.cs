using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab3
{
    public partial class AdditionForm : Form
    {
        public AdditionForm()
        {
            InitializeComponent();
        }

        public AdditionForm(DeliveryOrder order)
            : this()
        {
            clientNameBox.Text = order.ClientName;
            dateBox.Text = order.Date.ToString("yy-MM-dd");
            countBox.Value = order.Count;

            if (order is PizzaOrder)
            {
                pizzaRadio.Checked = true;
                pizzaTypeBox.Text = ((PizzaOrder)order).PizzaType;
                sizeBox.Text = ((PizzaOrder)order).Size.ToString();
            }
            else if(order is DrinkOrder)
            {
                drinkRadio.Checked = true;
                drinkTypeBox.Text = ((DrinkOrder)order).DrinkType;
                volumeBox.Text = ((DrinkOrder)order).Volume.ToString();
            }
            pizzaRadio_CheckedChanged(this, EventArgs.Empty);
        }

        private void pizzaRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (pizzaRadio.Checked)
            {
                pizzaTypeBox.Enabled = true;
                sizeBox.Enabled = true;
                drinkTypeBox.Enabled = false;
                volumeBox.Enabled = false;
            }
            else if(drinkRadio.Checked)
            {
                drinkTypeBox.Enabled = true;
                volumeBox.Enabled = true;
                pizzaTypeBox.Enabled = false;
                sizeBox.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DeliveryOrder order = null;

            var cName = clientNameBox.Text;
            if (cName.Length == 0)
                throw new Exception("Не введен ФИО");
            var date = dateBox.Text;
            var count = (int)countBox.Value;
            if (pizzaRadio.Checked)
            {
                var pType = pizzaTypeBox.Text;
                if (pType.Length == 0)
                    throw new Exception("Не введен вид пиццы");
                if (!int.TryParse(sizeBox.Text, out int size))
                    throw new Exception("Введен некорректный размер пиццы");
                order = new PizzaOrder(cName, date, count, pType, size);
            }
            else if (drinkRadio.Checked)
            {
                var dType = drinkTypeBox.Text;
                if (dType.Length == 0)
                    throw new Exception("Не введен вид напитка");
                if (!float.TryParse(volumeBox.Text, out float volume))
                    throw new Exception("Введен некорректный объем напитка");
                order = new DrinkOrder(cName, date, count, dType, volume);
            }

            if (order is null)
                throw new Exception("Ошибка добавления заказа");
            ((MainWindow)Owner).returnedOrder = order;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
