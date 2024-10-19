using BicycleApp_Lab4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace BicycleApp_Lab4
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            this.Load += fMain_Load; // Переконайтеся, що подія Load прив'язана
        }


        private void fMain_Load(object sender, EventArgs e)
        {
            gvBicycles.AutoGenerateColumns = false;

            // Створюємо і додаємо колонки
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Brand";
            column.Name = "Марка";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Model";
            column.Name = "Модель";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Type";
            column.Name = "Тип";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Weight";
            column.Name = "Вага (кг)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Mileage";
            column.Name = "Пробіг (км)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "GearCount";
            column.Name = "Кількість передач";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Distance";
            column.Name = "Відстань (км)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Time";
            column.Name = "Час (год)";
            gvBicycles.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Speed";
            column.Name = "Швидкість (км/год)";
            gvBicycles.Columns.Add(column);

            // Прив'язуємо BindingSource до DataGridView
            gvBicycles.DataSource = bindSrcBicycles;
        }

        

        private void gvBicycles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindSrcBicycles_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fBicycle bicycleForm = new fBicycle();

            // Відображаємо форму як модальне вікно
            if (bicycleForm.ShowDialog() == DialogResult.OK)
            {
                // Отримуємо новий велосипед з форми
                Bicycle newBicycle = (Bicycle)bicycleForm.Tag;

                // Додаємо новий велосипед у BindingSource
                bindSrcBicycles.Add(newBicycle);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvBicycles.CurrentRow != null)
            {
                Bicycle selectedBicycle = (Bicycle)bindSrcBicycles.Current;
                fBicycle bicycleForm = new fBicycle(selectedBicycle);

                if (bicycleForm.ShowDialog() == DialogResult.OK)
                {
                    bindSrcBicycles[bindSrcBicycles.Position] = bicycleForm.Tag;
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть велосипед для редагування.");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gvBicycles.CurrentRow != null)
            {
                bindSrcBicycles.RemoveCurrent();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть велосипед для видалення.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bindSrcBicycles.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
