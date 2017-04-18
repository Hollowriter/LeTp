using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Charcito
{
    class EstructuraDePosicion
    {
        BinaryFormatter elFormatero = new BinaryFormatter();
        FileStream posicionamientoDelJugador;
        /*public void Posicionado(Personaje jugador ,Position donde)
         {
             if (!File.Exists("Posicionamiento.txt"))
             {
                 posicionamientoDelJugador = File.Create("Posicionamiento.txt");
                 donde.x = 5;
                 donde.y = 5;
             }
             else
             {
                 using (posicionamientoDelJugador = File.OpenRead("Posicionamiento.txt"))
                 {
                     donde = (Position)elFormatero.Deserialize(posicionamientoDelJugador);
                 }
             }
         }*/
        public void Guardado(Personaje jugador, Position donde)
        {
            donde.x = jugador.GetX();
            donde.y = jugador.GetY();
            using (posicionamientoDelJugador = File.OpenWrite("Posicionamiento.txt"))
            {
                elFormatero.Serialize(posicionamientoDelJugador, donde);
            }
            posicionamientoDelJugador.Close();
        }
    }
}
