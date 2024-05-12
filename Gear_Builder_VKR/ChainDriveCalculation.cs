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
using System.IO;


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
        public double A1 {  get; set; }

        //ниже - для геометрических характеристик частей звена
        public double D1_ { get; set; }
        public double B1 { get; set; }
        public double D4_ { get; set; }
        public double B7 { get; set; }
        public double H1_ { get; set; }
        public double D3_ { get; set; }
        public double Rn { get; set; }


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
        //Чтобы обработать ситуации, когда переменная не существует в сборке, и избежать ошибок при попытке установить ссылку на несуществующий параметр, вы можете добавить проверку на null для каждой переменной перед тем, как вызывать метод SetLink. Это гарантирует, что ссылка будет установлена только если переменная действительно существует в вашем документе. Вот как можно модифицировать ваш код:
        void SetVariableLink(ksVariable variable, string assemblyPath, string paramName)
        {
            if (variable != null)
            {
                variable.SetLink(assemblyPath, paramName);
            }
            else
            {
                // Логирование или вывод сообщения, что переменная не найдена (по желанию)
                System.Diagnostics.Debug.WriteLine($"Variable {paramName} not found.");
            }
        }
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

            ksVariable t = varcoll.GetByName("t");
            ksVariable d4_ =varcoll.GetByName("d4_");
            ksVariable d2_ =varcoll.GetByName("d2_");
            ksVariable d1_ =varcoll.GetByName("d1_");
            ksVariable h1_ =varcoll.GetByName("h1_");
            ksVariable d3_ =varcoll.GetByName("d3_");
            ksVariable b1_ =varcoll.GetByName("b1_");
            ksVariable b7_ =varcoll.GetByName("b7_");


            SetVariableLink(varcoll.GetByName("t"), assemblyPath, "t");
            SetVariableLink(varcoll.GetByName("d4_"), assemblyPath, "d4_");
            SetVariableLink(varcoll.GetByName("d2_"), assemblyPath, "d2_");
            SetVariableLink(varcoll.GetByName("d1_"), assemblyPath, "d1_");
            SetVariableLink(varcoll.GetByName("h1_"), assemblyPath, "h1_");
            SetVariableLink(varcoll.GetByName("d3_"), assemblyPath, "d3_");
            SetVariableLink(varcoll.GetByName("b1_"), assemblyPath, "b1");
            SetVariableLink(varcoll.GetByName("b7_"), assemblyPath, "b7");



            varcoll.refresh();
        }
        public static bool isFirstClick = true; 
        public void RebuildModel(ChainDriveCalculation calculation)
        {
            KompasObject kompas;
            try
            {
                  kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            }
            catch { kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5")); }
            if (kompas == null) return;
            kompas.Visible=true;
            
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
            if (isFirstClick) {
                while (kompas_document_3D != null)
                {
                    kompas_document_3D.close();
                    kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
                }
            }
            
            //IApplication application = (IApplication)Marshal.GetActiveObject("KOMPAS.Application.7");
            //IDocuments documents = (IDocuments)application.Documents;

            string assemblyPath = $"{GlobalData.FolderPath}\\Параметрическая цепь 19,05.a3d";
            if (kompas_document_3D == null && isFirstClick)
          {
                ProcessPart("Стяжка", assemblyPath);
                ProcessPart("Part3", assemblyPath);
                ProcessPart("Ось", assemblyPath);
                isFirstClick = false;
          }
            
            //try
            //{
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                kompas_document_3D = (ksDocument3D)kompas.Document3D();
                //application = (IApplication)Marshal.GetActiveObject("KOMPAS.Application.7");
                //documents = (IDocuments)application.Documents;

                kompas_document_3D.Open(assemblyPath);
                kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
                
                ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
                ksVariableCollection varcoll = kPart.VariableCollection();
            Console.WriteLine(calculation.A1);

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
                SetVariable(varcoll, "a1", calculation.A1);
                

                SetVariable(varcoll, "d1_", calculation.D1_);
                SetVariable(varcoll, "b1", calculation.B1);
                SetVariable(varcoll, "d4_", calculation.D4_);
                SetVariable(varcoll, "b7", calculation.B7);
                SetVariable(varcoll, "h1_", calculation.H1_);
                SetVariable(varcoll, "d3_", calculation.D3_);
                

                

                kPart.RebuildModel();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ошибка при открытии файла сборки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    SelectFolderAndRetry();
            //}
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
            
        }
    }
   

}
