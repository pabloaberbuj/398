using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_UI
{
    class CrearInstancia
    {
        public static Camara CrearCamara(string marca, string modelo, string SN)
        {
            Camara camara = new Camara()
            {
                Marca = marca,
                Modelo = modelo,
                NumSerie = SN,
            };
            return camara;
        }

        public static Electrometro CrearElectrometro(string marca, string modelo, string SN)
        {
            Electrometro electrometro = new Electrometro()
            {
                Marca = marca,
                Modelo = modelo,
                NumSerie = SN,
            };
            return electrometro;
        }

        public static SistemaDosimetrico CrearSistDosim(string marcaCam, string modeloCam, string SNCam, string marcaElec, string modeloElec, string SNElec,
            double factorCal, double tension, string hazRef, double tempRef, double presionRef, double HumedadRef, string fechaCal, string laboCal)
            //EsPredet inicia como false siempre
        {
            SistemaDosimetrico sistemadosim = new SistemaDosimetrico()
            {
                MarcaCam = marcaCam,
                ModeloCam = modeloCam,
                NumSerieCam = SNCam,
                MarcaElec = marcaElec,
                ModeloElec = modeloElec,
                NumSerieElec = SNElec,
                FactorCalibracion = factorCal,
                Tension = tension,
                HazDeRef = hazRef,
                TempRef = tempRef,
                PresionRef = presionRef,
                HumedadRef = HumedadRef,
                FechaCalibracion = fechaCal,
                LaboCalibracion = laboCal,
                EsPredet = false,
            };
            return sistemadosim;
        }
    }
}
