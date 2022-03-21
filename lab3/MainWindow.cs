using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class MainWindow : Form
    {
        public DeliveryOrder returnedOrder;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            listBoxOrders.DataSource = Program.logic.GetList();
        }

        private void ListBoxOrders_DblClk(object sender, MouseEventArgs e)
        {
            int index = listBoxOrders.SelectedIndex;

            if (index < 0)
                throw new Exception("Не выбрана запись");

            MessageBox.Show(Program.logic.GetList()[index].ToString());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var form = new AdditionForm();
            if (form.ShowDialog(this) == DialogResult.OK)
                Program.logic.AddRecord(returnedOrder);
            listBoxOrders.DataSource = Program.logic.GetList();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            int index = listBoxOrders.SelectedIndex;

            var order = Program.logic.GetList()[index];

            if (!Program.logic.DeleteRecord(order))
                throw new Exception("Ошибка удаления");

            listBoxOrders.DataSource = Program.logic.GetList();
        }

        private void listBoxOrders_SelectedValueChanged(object sender, EventArgs e)
        {
            changeButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            var index = listBoxOrders.SelectedIndex;
            var order = Program.logic.GetList()[index];
            var form = new AdditionForm(order);
            if(form.ShowDialog(this) == DialogResult.OK)
            {
                returnedOrder.id = order.id;
                Program.logic.AddRecord(returnedOrder);
            }
            listBoxOrders.DataSource = Program.logic.GetList();
        }

        private void createReportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            var path = saveFileDialog.FileName;

            Program.logic.GenerateReport(startDateBox.Value.Date, endDateBox.Value.Date, path);
        }

        private void listBoxOrders_DataSourceChanged(object sender, EventArgs e)
        {
            if (((List<DeliveryOrder>)listBoxOrders.DataSource).Count == 0)
            {
                changeButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }
    }
}
