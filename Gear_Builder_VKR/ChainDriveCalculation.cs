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


namespace Gear_Builder_VKR
{
    public static class GlobalData
    {
        public static List<ChainDriveCalculation> Calculations = new List<ChainDriveCalculation>();
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
        public void RebuildModel(ChainDriveCalculation calculation)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
            ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
            ksVariableCollection varcoll = kPart.VariableCollection();
            varcoll.refresh();

            SetVariable(varcoll, "NN", calculation.Nn);
            SetVariable(varcoll, "n1", calculation.N1);
            SetVariable(varcoll, "n2", calculation.N2);
            SetVariable(varcoll, "M", calculation.M);
            SetVariable(varcoll, "U", calculation.U);
            SetVariable(varcoll, "z1", calculation.Z1);
            SetVariable(varcoll, "z2", calculation.Z2);
            SetVariable(varcoll, "t", calculation.TFin);
            SetVariable(varcoll, "Af", calculation.Af);
            SetVariable(varcoll, "A", calculation.A);
            SetVariable(varcoll, "d1", calculation.D1);
            SetVariable(varcoll, "d2", calculation.D2);
            SetVariable(varcoll, "L", calculation.La);
            SetVariable(varcoll, "da1", calculation.Da1);
            SetVariable(varcoll, "da2", calculation.Da2);

            IApplication application = (IApplication)Marshal.GetActiveObject("Kompas.Application.7");
            IKompasDocument3D document3D = (IKompasDocument3D)application.ActiveDocument;
            IPart7 part = document3D.TopPart;

            List<IPart7> parts = new List<IPart7>();

            Recursion recursion = new Recursion();
            recursion.GetDetails(part, parts);

            
            
            


        }

        public class ModelUpdater
        {
            public void UpdateComponentParameters(List<IPart7> parts, Dictionary<string, double> parameters)
            {
                foreach (IPart7 part in parts)
                {
                    IVariableTable variableTable = part.VariableTable;
                    int count = variableTable.RowsCount;

                    for (int rowIndex = 0; rowIndex < count; rowIndex++)
                    {
                        string varName = variableTable.VarName[rowIndex];

                        // Проверяем, содержится ли такая переменная в словаре параметров для обновления
                        if (parameters.ContainsKey(varName))
                        {
                            variableTable.Cell[rowIndex, 1] = parameters[varName]; // Предполагаем, что значение переменной находится во втором столбце
                            variableTable.ApplyVars(rowIndex); // Применяем изменения к детали
                        }
                    }

                    
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


}
