using System;
using System.Windows.Forms;

namespace Gear_Builder_VKR
{
    public partial class FolderSelectionForm : Form
    {
        private FolderBrowserDialog folderBrowserDialog;

        public FolderSelectionForm()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;  // Опционально, позволяет создавать новую папку в диалоге
        }

        public string SelectedPath => folderBrowserDialog.SelectedPath;

        private void button1_Click(object sender, EventArgs e)
        {
            // Метод ShowDialog вызывается для folderBrowserDialog, а не для формы FolderSelectionForm
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                GlobalData.FolderPath = folderBrowserDialog.SelectedPath;  // Присваивание пути из диалога в глобальную переменную
                pastePath.Text = folderBrowserDialog.SelectedPath;         // Отображение выбранного пути в текстовом поле
                OK.Enabled = true;
            }
            else
            {
                MessageBox.Show("Построение отменено пользователем.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();  // Простое закрытие формы
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GlobalData.FolderPath))  // Проверка, что путь не пустой
            {
                DialogResult = DialogResult.OK;  // Устанавливаем результат диалога
                Close();                        // Закрываем форму
            }
            else
            {
                MessageBox.Show("Не выбрана директория.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}