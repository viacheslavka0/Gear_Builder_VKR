using Gear_Builder_VKR;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gear_Builder_VKR
{

    public static class GlobalData
    {
        public static List<ChainDriveCalculation> Calculations = new List<ChainDriveCalculation>();
        public static string FolderPath { get; set; }
    }
    public class ChainDriveCalculation
    {
        public double Nn { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }
        public double M { get; set; }
        public double U { get; set; }
        public double Z1 { get; set; }
        public double Z2 { get; set; }
        public double T { get; set; }
        public double TFin { get; set; }
        public double A { get; set; }
        public double Af { get; set; }
        public double La { get; set; }
        public double Da1 { get; set; }
        public double Da2 { get; set; }
        public double D1 { get; set; }
        public double D2 { get; set; }
        //ниже - для геометрических характеристик частей звена
        public double D1_ { get; set; }
        public double B1 { get; set; }
        public double D4_ { get; set; }
        public double B7 { get; set; }
        public double H1_ { get; set; }
        public double D3_ { get; set; }


    }
    // Создайте список для хранения расчетов
    public class Recursion
    {
        public void GetDetails(IPart7 part, List<IPart7>parts)
        {
            parts.Add(part);
            foreach (IPart7 item in part.Parts)
            {
                if (item.Detail == true) parts.Add(item);
                if (item.Detail == false) GetDetails(item, parts);
            }
        }
    }
    public class ModelRebuilder
    {
        private void ProcessPart(string partName, string assemblyPath)
        {
            
            IApplication application = (IApplication)Marshal.GetActiveObject("KOMPAS.Application.7");
            
            IDocuments documents = (IDocuments)application.Documents;
            var document = documents.Open($"{GlobalData.FolderPath}//{partName}.m3d");
            if (document == null)
            {
                MessageBox.Show($"Не удалось открыть файл: {partName}.m3d", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
            ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
            ksVariableCollection varcoll = kPart.VariableCollection();

            ksVariable a = varcoll.GetByName("t");
            if (a != null)
            {
                bool result = a.SetLink(assemblyPath, "t");
                MessageBox.Show("Link set successfully: " + result);
                varcoll.refresh();
            }
            else
            {
                MessageBox.Show("Variable not found");
            }
            varcoll.refresh();
        }
        private bool isFirstClick = true; 
        public void RebuildModel(ChainDriveCalculation calculation)
        {
        
        string assemblyPath = $"{GlobalData.FolderPath}\\Параметрическая цепь 19,05.a3d";
          if (isFirstClick)
            {
                ProcessPart("Стяжка", assemblyPath);
                ProcessPart("Part3", assemblyPath);
                isFirstClick = false;
            }
            


            try
            {
                IApplication application = (IApplication)Marshal.GetActiveObject("KOMPAS.Application.7");
                IDocuments documents = (IDocuments)application.Documents;
                var document = documents.Open(assemblyPath);
                if (document == null)
                {
                    throw new InvalidOperationException("Не удалось открыть документ сборки.");
                }

                KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
                ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
                ksVariableCollection varcoll = kPart.VariableCollection();

                SetVariable(varcoll, "NN", calculation.Nn);
                SetVariable(varcoll, "n1", calculation.N1);
                SetVariable(varcoll, "n2", calculation.N2);
                SetVariable(varcoll, "M", calculation.M);
                SetVariable(varcoll, "U", calculation.U);
                SetVariable(varcoll, "z1", calculation.Z1);
                SetVariable(varcoll, "z2", calculation.Z2);
                SetVariable(varcoll, "t", calculation.TFin);
                SetVariable(varcoll, "A", calculation.Af);
                SetVariable(varcoll, "A_F", calculation.A);
                SetVariable(varcoll, "d1", calculation.D1);
                SetVariable(varcoll, "d2", calculation.D2);
                SetVariable(varcoll, "L", calculation.La);
                SetVariable(varcoll, "da1", calculation.Da1);
                SetVariable(varcoll, "da2", calculation.Da2);

                

                kPart.RebuildModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла сборки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectFolderAndRetry();
            }


           //kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");

           
           //kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
           //kompas = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
           //kompas = kPart.VariableCollection();
            
           // ksVariable a = varcoll.GetByName("t");
            //if (a != null)
            //{
            //    bool result = a.SetLink("C:\\Users\\Вячеслав\\Desktop\\распаковка\\Новая библиотека\\Параметрическая цепь 19,05.a3d", "t");
            //    MessageBox.Show("Link set successfully: " + result);
            //}
            //else
            //{
            //    MessageBox.Show("Variable not found");
            //}
            //varcoll.refresh();
           
           //varcoll.refresh();


            //IApplication application = (IApplication)Marshal.GetActiveObject("KOMPAS.Application.7");

            //Получаем список всех документов
            //var documents = application.Documents;
            //for (int i = 0; i < documents.Count; i++)
            //{
            //    var document = (IKompasDocument3D)documents[i];
            //    if (document != null && document.Name.Contains("Part3"))
            //    {
            //        Найден нужный документ, получаем его верхнюю часть
            //        IPart7 part = document.TopPart;
            //        IVariableTable varTable = part.VariableTable;

            //        Перебор всех переменных в таблице
            //        for (int rowIndex = 0; rowIndex < varTable.RowsCount; rowIndex++)
            //        {
            //            string varName = varTable.VarName[rowIndex];

            //            if (varName == "t")
            //            {
            //                Создание объекта IVariable7 для управления переменной
            //                IVariable7 variable = ;
            //                if (variable != null)
            //                {
            //                    Устанавливаем ссылку через метод SetLink
            //                    bool result = variable.SetLink("C:\\Users\\Вячеслав\\Desktop\\распаковка\\Новая библиотека\\Параметрическая цепь 19,05.a3d", "t");
            //                    if (result)
            //                    {
            //                        Console.WriteLine("Ссылка установлена успешно.");
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("Не удалось установить ссылку.");
            //                    }
            //                    break;
            //                }
            //            }
            //        }
            //    }



            //SetVariable(varcoll, "NN", calculation.Nn);
            //SetVariable(varcoll, "n1", calculation.N1);
            //SetVariable(varcoll, "n2", calculation.N2);
            //SetVariable(varcoll, "M", calculation.M);
            //SetVariable(varcoll, "U", calculation.U);
            //SetVariable(varcoll, "z1", calculation.Z1);
            //SetVariable(varcoll, "z2", calculation.Z2);
            //SetVariable(varcoll, "t", calculation.TFin);
            //SetVariable(varcoll, "A", calculation.Af);
            //SetVariable(varcoll, "A_F", calculation.A);
            //SetVariable(varcoll, "d1", calculation.D1);
            //SetVariable(varcoll, "d2", calculation.D2);
            //SetVariable(varcoll, "L", calculation.La);
            //SetVariable(varcoll, "da1", calculation.Da1);
            //SetVariable(varcoll, "da2", calculation.Da2);

            //kPart.RebuildModel();

        }

        private void SelectFolderAndRetry()
        {
            // Запрашиваем пользователя выбрать папку снова
            using (FolderSelectionForm form = new FolderSelectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GlobalData.FolderPath = form.SelectedPath;
                    RebuildModel(GlobalData.Calculations[GlobalData.Calculations.Count-1]); // Рекурсивный вызов функции для повторной попытки
                }
                else
                {
                    MessageBox.Show("Построение отменено пользователем.");
                }
            }
        }



        private void SetVariable(ksVariableCollection varcoll, string name, double value)
        {
            ksVariable var = varcoll.GetByName(name, true, true);
            if (var != null)
            {
                var.value = value;
            }
        }
    }
    public class ModelUpdater
    {
        public void UpdateComponentParameters(Dictionary<string, double> parameters)
        {
            //IApplication application = (IApplication)Marshal.GetActiveObject("Kompas.Application.7");
            //IKompasDocument3D document3D = (IKompasDocument3D)application.Doc;
            //IPart7 part = document3D.;

            //var documents = application.Documents;
            //for (int i = 0; i < documents.Count; i++)
            //{
            //    MessageBox.Show("1");
            //}


            //List<IPart7> parts = new List<IPart7>();

            //Recursion recursion = new Recursion();
            //recursion.GetDetails(part, parts);

            //foreach (IPart7 item in parts)
            //{
            //    IVariableTable variableTable = item.VariableTable;
            //    int count = variableTable.RowsCount;
            //    //MessageBox.Show("1");

            //    for (int rowIndex = 0; rowIndex < count; rowIndex++)
            //    {
            //        string varName = variableTable.VarName[rowIndex];

            //        // Проверяем, содержится ли такая переменная в словаре параметров для обновления
            //        if (parameters.ContainsKey(varName))
            //        {
            //            variableTable.Cell[rowIndex, 1] = parameters[varName]; // Предполагаем, что значение переменной находится во втором столбце
            //            variableTable.ApplyVars(rowIndex); // Применяем изменения к детали
            //        }
            //    }


            //}

        }
    }
   

}
