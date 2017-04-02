using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
  public  class Childe
    {
      int carnet;
      String name;
      String apellidos;
      String direccion;
      String sexo;
      String anionac;
      String poblacion;
      public Childe(int carnet, String name, String apellidos, String direccion, String sexo, String anionac, String poblacion)
      {
          this.carnet = carnet;
          this.name = name;
          this.apellidos = apellidos;
          this.direccion = direccion;
          this.sexo = sexo;
          this.anionac = anionac;
          this.poblacion = poblacion;
      }
      public int Carnet
      {
          get { return carnet; }
          set { carnet = value; }
      }

      public String Name
      {
          get { return name; }
          set { name = value; }
      }

      public String Apellidos
      {
          get { return apellidos; }
          set { apellidos = value; }
      }

      public String Direccion
      {
          get { return direccion; }
          set { direccion = value; }
      }
      public String Sexo
      {
          get { return sexo; }
          set { sexo = value; }
      }
      public String Anionac
      {
          get { return anionac; }
          set { anionac = value; }
      }
      public String Poblacion
      {
          get { return poblacion; }
          set { poblacion = value; }
      }
      
    }


	
}
