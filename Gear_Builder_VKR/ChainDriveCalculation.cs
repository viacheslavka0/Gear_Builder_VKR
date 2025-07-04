﻿using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Newtonsoft.Json;

using System.IO;


namespace Gear_Builder_VKR
{

    public static class GlobalData
    {
        public static List<ChainDriveCalculation> Calculations = new List<ChainDriveCalculation>();
        public static string FolderPath { get; set; }

        public static void SaveCalculationsToFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(Calculations, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }   

        public static void LoadCalculationsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Calculations = JsonConvert.DeserializeObject<List<ChainDriveCalculation>>(json);
            }
        }
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
        public double A1 { get; set; }
        public double D1_ { get; set; }
        public double B1 { get; set; }
        public double D4_ { get; set; }
        public double B7 { get; set; }
        public double H1_ { get; set; }
        public double D3_ { get; set; }
        public double Rn { get; set; }
        //параметры для звездочек
        public double Dn1 { get; set; }
        public double R { get; set; }
        public double Dvn1 { get; set; }
        public double Alpha1 { get; set; }
        public double Fi1 { get; set; }
        public double Y1 { get; set; }
        public double Beta1 { get; set; }
        public double R11 { get; set; }
        public double Fg1 { get; set; }
        public double R21 { get; set; }
        //параметры для звездочек
        public double Dn2 { get; set; }
        public double Dvn2 { get; set; }
        public double Alpha2 { get; set; }
        public double Fi2 { get; set; }
        public double Y2 { get; set; }
        public double Beta2 { get; set; }
        public double R12 { get; set; }
        public double Fg2 { get; set; }
        public double R22 { get; set; }


    }
    // Создайте список для хранения расчетов
    public class Recursion
    {
        public void GetDetails(IPart7 part, List<IPart7> parts)
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
        
        void SetVariableLink(ksVariable variable, string assemblyPath, string paramName)
        {
            if (variable != null)
            {
                variable.SetLink(assemblyPath, paramName);
            }
        }
        private void ProcessPart(string partName, string assemblyPath)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.Document3D();
            kompas_document_3D.Open($"{GlobalData.FolderPath}//{partName}.m3d");

            kompas.ActiveDocument3D();
            ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
            ksVariableCollection varcoll = kPart.VariableCollection();

            SetVariableLink(varcoll.GetByName("t"), assemblyPath, "t");
            SetVariableLink(varcoll.GetByName("d4_"), assemblyPath, "d4_");
            SetVariableLink(varcoll.GetByName("d2_"), assemblyPath, "d2_");
            SetVariableLink(varcoll.GetByName("d1_"), assemblyPath, "d1_");
            SetVariableLink(varcoll.GetByName("h1_"), assemblyPath, "h1_");
            SetVariableLink(varcoll.GetByName("d3_"), assemblyPath, "d3_");
            SetVariableLink(varcoll.GetByName("b1_"), assemblyPath, "b1");
            SetVariableLink(varcoll.GetByName("b7_"), assemblyPath, "b7");

            varcoll.refresh();
            kPart.RebuildModel();
            kompas_document_3D.Save();
            kompas_document_3D.close();
        }

        private void StarBuild(string partName, string assemblyPath, ChainDriveCalculation calculation)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.Document3D();
            kompas_document_3D.Open($"{GlobalData.FolderPath}//{partName}.m3d");
            kompas.ActiveDocument3D();
            ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
            ksVariableCollection varcoll = kPart.VariableCollection();

            if (partName == "Ведущая звездочка")
            {
                SetVariable(varcoll, "d_d", calculation.D1);
                SetVariable(varcoll, "d_n", calculation.Dn1);
                SetVariable(varcoll, "d_vp", calculation.Dvn1);
                SetVariable(varcoll, "alpha", calculation.Alpha1);
                SetVariable(varcoll, "fi", calculation.Fi1);
                SetVariable(varcoll, "y", calculation.Y1);
                SetVariable(varcoll, "beta", calculation.Beta1);
                SetVariable(varcoll, "r1", calculation.R);
                SetVariable(varcoll, "r2", calculation.R21);
                SetVariable(varcoll, "fg", calculation.Fg1);
                SetVariable(varcoll, "z1", calculation.Z1);
            }
            else
            {
                SetVariable(varcoll, "d_d", calculation.D2);     
                SetVariable(varcoll, "d_n", calculation.Dn2);
                SetVariable(varcoll, "d_vp", calculation.Dvn2);
                SetVariable(varcoll, "alpha", calculation.Alpha2);
                SetVariable(varcoll, "fi", calculation.Fi2);
                SetVariable(varcoll, "y", calculation.Y2);
                SetVariable(varcoll, "beta", calculation.Beta2);
                SetVariable(varcoll, "r1", calculation.R);
                SetVariable(varcoll, "r2", calculation.R22);
                SetVariable(varcoll, "fg", calculation.Fg2);
                SetVariable(varcoll, "z2", calculation.Z2);
            }

            varcoll.refresh();
            kPart.RebuildModel();
            kompas_document_3D.Save();
            kompas_document_3D.close();
        }

        private void GearBuild(string assemblyPath, ChainDriveCalculation calculation)
        {
            KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.Document3D();
            kompas_document_3D.Open(assemblyPath);

            kompas.ActiveDocument3D();
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
            SetVariable(varcoll, "a1", calculation.A1);
            SetVariable(varcoll, "d1_", calculation.D1_);
            SetVariable(varcoll, "b1", calculation.B1);
            SetVariable(varcoll, "d4_", calculation.D4_);
            SetVariable(varcoll, "b7", calculation.B7);
            SetVariable(varcoll, "h1_", calculation.H1_);

            varcoll.refresh();
            kPart.RebuildModel();

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
            kompas.Visible = true;

            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
            while (kompas_document_3D != null)
            {
                kompas_document_3D.close();
                kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
            }
            string assemblyPath = $"{GlobalData.FolderPath}\\Параметрическая цепь 19,05.a3d";
            if (kompas_document_3D == null && isFirstClick)
            {
                ProcessPart("Стяжка", assemblyPath);
                ProcessPart("Part3", assemblyPath);
                ProcessPart("Ось", assemblyPath);
                isFirstClick = false;
            }
            StarBuild("Ведущая звездочка", assemblyPath, calculation);
            StarBuild("Ведомая звездочка", assemblyPath, calculation);

            GearBuild(assemblyPath, calculation);
        }



        private void SelectFolderAndRetry()
        {
            // Запрашиваем пользователя выбрать папку снова
            using (FolderSelectionForm form = new FolderSelectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GlobalData.FolderPath = form.SelectedPath;
                    RebuildModel(GlobalData.Calculations[GlobalData.Calculations.Count - 1]); // Рекурсивный вызов функции для повторной попытки
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
