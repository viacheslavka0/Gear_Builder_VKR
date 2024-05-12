using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gear_Builder_VKR
{
    public partial class Operating_condition : Form
    {
        public static int SelectedOilingIndex { get; set; } = 0;
        public static int SelectedPressureIndex { get; set; } = 0;
        public static int SelectedModeIndex { get; set; } = 0;
        public static int SelectedTensionIndex { get; set; } = 0;

        public Operating_condition()
        {
            InitializeComponent();

            // Восстановление выбранных индексов при инициализации
            Oiling.SelectedIndex = SelectedOilingIndex;
            Preassure.SelectedIndex = SelectedPressureIndex;
            Mode.SelectedIndex = SelectedModeIndex;
            Tension.SelectedIndex = SelectedTensionIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Close();
        }

        private void Operating_condition_Load(object sender, EventArgs e)
        {

        }

        OperationConditions operationConditions = new OperationConditions();

        private void button2_Click(object sender, EventArgs e)
        {
            // Сохранение выбранных индексов
            SelectedOilingIndex = Oiling.SelectedIndex;
            SelectedPressureIndex = Preassure.SelectedIndex;
            SelectedModeIndex = Mode.SelectedIndex;
            SelectedTensionIndex = Tension.SelectedIndex;

            // Расчёт коэффициентов
            string oil = Oiling.SelectedItem.ToString();
            string preassure = Preassure.SelectedItem.ToString();
            string mode = Mode.SelectedItem.ToString();
            string tension = Tension.SelectedItem.ToString();
            OperationConditions operationConditions = new OperationConditions();
            operationConditions.CalculateCoefficients(oil, preassure, mode, tension);

            Close();
        }
    }
}

    public class OperationConditions
    {
        public double K1 { get;  set; }
        public double K2 { get;  set; }
        public double K3 { get; set; }
        public double K4 { get;  set; }

        // Пример метода для установки коэффициентов
        public void SetCoefficients(double k1, double k2, double k3, double k4)
        {
            K1 = k1;
            K2 = k2;
            K3 = k3;
            K4 = k4;
        }

        // Вы можете добавить методы для расчёта коэффициентов на основе входных данных формы
        public void CalculateCoefficients(string oil, string preassure, string mode, string tension)
        {

            // Здесь будет логика расчёта коэффициентов
            // Например:
            switch (oil)
            {
                case "Непрерывный (в маслянной ванне или от насоса)":
                    K1 = 0.9;
                    break;
                case "Капельный":
                    K1 = 1.2;
                    break;
                case "Периодический":
                    K1 = 1.5;
                    break;
            }

            switch (preassure)
            {
                case "Постоянная или близкая к ней":
                    K2 = 1;
                    break;
                case "Переменная":
                    K2 = 1.3;
                    break;
                case "Ударная":
                    K2 = 2;
                    break;
            }

            switch (mode)
            {
                case "Односменный":
                    K3 = 1;
                    break;
                case "Двусменный":
                    K3 = 1.3;
                    break;
                case "Трехсменный":
                    K3 = 2;
                    break;
            }

            switch (tension)
            {
                case "Автоматическая":
                    K4 = 1;
                    break;
                case "Периодическая":
                    K4 = 1.25;
                    break;
            }

        }
    }


